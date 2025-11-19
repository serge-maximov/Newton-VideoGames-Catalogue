import { Routes } from '@angular/router';
import {VGameListComponent} from './pages/vgame-list/vgame-list.component';
import {VGameEditComponent} from './pages/vgame-edit/vgame-edit.component'; 

/*  routes pointing to standalone components */ 
export const routes: Routes = [
   { path: '', redirectTo: 'vgames', pathMatch: 'full' },
   { path: 'vgames', component: VGameListComponent },
   { path: 'vgames/:id', component: VGameEditComponent },
   { path: '**', redirectTo: 'vgames' }
];

