import { Component, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterLink],
  templateUrl: './register.html',
  styleUrl: './register.css'
})
export class RegisterComponent {
  private authService = inject(AuthService);
  private router = inject(Router);

  user = {
    username: '',
    email: '',
    password: ''
  };

  loading = signal<boolean>(false);
  errorMessage = signal<string | null>(null);

  onSubmit(): void {
    this.loading.set(true);
    this.errorMessage.set(null);

    this.authService.register(this.user).subscribe({
      next: (res) => {
        if (res.success) {
          this.router.navigate(['/login']);
        }
      },
      error: (err) => {
        this.errorMessage.set(err.error?.message || 'Registration failed. Please check your data.');
        this.loading.set(false);
      }
    });
  }
}
