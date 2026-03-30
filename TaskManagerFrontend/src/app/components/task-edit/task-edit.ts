import { Component, OnInit, inject, signal, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { Task, TaskService } from '../../services/task.service';

@Component({
  selector: 'app-task-edit',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterLink],
  templateUrl: './task-edit.html',
  styleUrl: './task-edit.css'
})
export class TaskEditComponent implements OnInit {
  private route = inject(ActivatedRoute);
  private router = inject(Router);
  private taskService = inject(TaskService);
  private cdr = inject(ChangeDetectorRef);

  isEditMode = signal<boolean>(false);
  taskId?: number;
  task: Task = {
    title: '',
    description: '',
    isCompleted: false
  };

  ngOnInit(): void {
    const idParam = this.route.snapshot.paramMap.get('id');
    if (idParam) {
      this.isEditMode.set(true);
      this.taskId = +idParam;
      this.loadTask(this.taskId);
    }
  }

  loadTask(id: number): void {
    this.taskService.getTask(id).subscribe({
      next: (data) => {
        this.task = data;
        this.cdr.detectChanges(); // Force UI refresh for zoneless mode
      },
      error: (err) => console.error('Error loading task', err)
    });
  }

  onSubmit(): void {
    if (this.isEditMode() && this.taskId) {
      this.taskService.updateTask(this.taskId, this.task).subscribe(() => {
        this.router.navigate(['/tasks']);
      });
    } else {
      this.taskService.createTask(this.task).subscribe(() => {
        this.router.navigate(['/tasks']);
      });
    }
  }
}



