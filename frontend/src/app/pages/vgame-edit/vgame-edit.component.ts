import { Component, effect, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink,  ActivatedRoute } from '@angular/router';
import { VGameService } from '../../services/vgame.service';
import { VideoGame } from '../../services/vgame.model';
import { firstValueFrom } from 'rxjs';
@Component({
  selector: 'app-vgame-edit',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterLink],
  templateUrl: './vgame-edit.component.html',
  styleUrl: './vgame-edit.component.css',
})
export class VGameEditComponent{

  private route = inject(ActivatedRoute);
  private router = inject(Router);
  private svc = inject(VGameService);

  /* parse id once */
  id = Number(this.route.snapshot.paramMap.get('id'));

   /* loadedSignal is a signal returned from the service (async -> initial value then server value)
      loadedSignal: if id===0 use an initial empty signal, else a service-provided signal  */
  loaded = this.id === 0
    ? signal<VideoGame>({
        id: 0,
        title: '',
        genre: '',
        releaseYear: new Date().getFullYear(),
        platform: '',
        description: '',
        price: 0,
      })
    : this.svc.getVGameSignal(this.id); // <-- service returns a Signal

  /* local editable signal (form bound) */
  vgame = signal<VideoGame>({ ...this.loaded() });

  /*  tracks a new item  */
  isNew = this.id === 0;

  constructor() {
    /* When the loaded signal updates (from HTTP), copy its value into the editable vgame  */
    effect(() => {
      const srv = this.loaded();
      /*  only set when it's a non-empty server response (id !== 0) OR when currently empty  */
      if (srv && srv.id !== 0) {
        this.vgame.set({ ...srv });
      }
    });
  } 

  /*  Save uses async/await (no subscribe). Returns a Promise. */
  async save(): Promise<void> {
    const payload = this.vgame();

    try {
      if (this.isNew) {
        /* create returns Observable<VideoGame>  */
        await firstValueFrom(this.svc.createVGame(payload));
        /*  optional: update local state or navigate  */
      } else {
        await firstValueFrom(this.svc.updateVGame(payload));
      }

      /* navigate back to list  */
      await this.router.navigate(['/vgames']);
    } catch (err) {
      console.error('Save failed', err);
      /* TODO : show user-friendly error  */
    }
  }

}
