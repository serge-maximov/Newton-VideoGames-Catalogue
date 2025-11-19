import { Component, inject} from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { VGameService } from '../../services/vgame.service';
import { VideoGame } from '../../services/vgame.model';

@Component({
  selector: 'app-vgame-list',
  standalone: true,
  imports: [CommonModule, RouterLink ],
  templateUrl: './vgame-list.component.html',
  styleUrl: './vgame-list.component.css',
})
export class VGameListComponent {
  private svc = inject(VGameService);
  vgames = this.svc.getVGamesSignal();  // Signal<VideoGame[]>

}
