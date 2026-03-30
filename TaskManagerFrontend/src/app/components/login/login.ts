import { Component, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterLink],
  templateUrl: './login.html',
  styleUrl: './login.css'
})
export class LoginComponent {
  private authService = inject(AuthService);
  private router = inject(Router);

  credentials = {
    username: '',
    password: ''
  };

  loading = signal<boolean>(false);
  errorMessage = signal<string | null>(null);

  onSubmit(): void {
    this.loading.set(true);
    this.errorMessage.set(null);

    this.authService.login(this.credentials).subscribe({
      next: (res) => {
        if (res.success) {
          this.router.navigate(['/tasks']);
        }
      },
      error: (err) => {
        this.errorMessage.set(err.error?.message || 'Login failed. Please check your credentials.');
        this.loading.set(false);
      }
    });
  }
}
