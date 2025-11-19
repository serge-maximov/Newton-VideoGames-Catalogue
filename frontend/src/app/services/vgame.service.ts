import { Injectable, inject, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { toSignal } from '@angular/core/rxjs-interop';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

export interface VideoGame {
  id: number;
  title: string;
  genre: string;
  releaseYear: number;
  platform: string;
  description: string;
  rating?: string;
  price: number;
}


@Injectable({  providedIn: 'root' })
export class VGameService {

  //  private vgames: VideoGame[] = [
  //   { id: 1, title: 'Halo', genre: 'FPS', releaseYear: 2001, platform: 'Xbox', description: 'A sci-fi first-person shooter.', rating: 'M', price: 59.99 },
  //   { id: 2, title: 'The Witcher 3', genre: 'RPG', releaseYear: 2015, platform: 'PC', description: 'An open-world fantasy RPG.', rating: 'M', price: 39.99},
  // ];  
   private http = inject(HttpClient);
   private apiUrl = `${environment.apiUrl}/vgames`; 
   private base = '/api/vgames'; // adapt to backend; for testing -  mock this

  /** Load all games (read : return Signal )*/
  getVGamesSignal() {
    const games$ = this.http.get<VideoGame[]>(this.apiUrl);
    return toSignal(games$, { initialValue: [] }); // Signal for zoneless
  }

  /** Load single game (read: return Signal ) */
  getVGameSignal(id: number) {
    const game$ = this.http.get<VideoGame>(`${this.apiUrl}/${id}`);
    return toSignal(game$, {
        initialValue: {
          id: 0,
          title: '',
          genre: '',
          releaseYear: 2000,
          platform: '',
          description: '',
          price: 0 }});
  }

  /** ---- WRITE - Observables (one-shot)   -------------  */
  createVGame(vg: VideoGame): Observable<VideoGame> {
    return this.http.post<VideoGame>(this.apiUrl, vg);
  }

  updateVGame(vg: VideoGame): Observable<unknown> {
    return this.http.put(`${this.apiUrl}/${vg.id}`, vg);
  }

  deleteVGame(id: number): Observable<unknown> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }

   /** --------ver:  WRITE ( return Observables) ----------  */
  // createVGame(vg: VideoGame) {
  //   return this.http.post<VideoGame>(this.apiUrl, vg);  
  // }

  // updateVGame(vg: VideoGame) {
  //   return this.http.put(`${this.apiUrl}/${vg.id}`, vg); 
  // }

  // deleteVGame(id: number) {
  //   return this.http.delete(`${this.apiUrl}/${id}`);   
  // }


  /** ------------ver: TODO: CRUD ( write : return Signals ) ------ */
  // createVGame(vg:VideoGame){
  //   const create$ = this.http.post(this.apiUrl, vg);  
  //   return toSignal(create$, { initialValue: vg });
  // }

  // updateVGame(vg:VideoGame){
  //   const update$ = this.http.put(`${this.apiUrl}/${vg.id}`, vg);  
  //   return toSignal(update$, { initialValue: vg });
  // }
}
