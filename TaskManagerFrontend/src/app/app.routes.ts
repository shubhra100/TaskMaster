import { Routes } from '@angular/router';
import { HomeComponent } from './components/home/home';
import { TaskListComponent } from './components/task-list/task-list';
import { TaskEditComponent } from './components/task-edit/task-edit';
import { LoginComponent } from './components/login/login';
import { RegisterComponent } from './components/register/register';
import { authGuard } from './guards/auth.guard';

export const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'tasks', component: TaskListComponent, canActivate: [authGuard] },
  { path: 'tasks/add', component: TaskEditComponent, canActivate: [authGuard] },
  { path: 'tasks/edit/:id', component: TaskEditComponent, canActivate: [authGuard] },
  { path: '**', redirectTo: '' }
];



