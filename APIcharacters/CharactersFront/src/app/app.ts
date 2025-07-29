import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {Character} from './character';
import { provideHttpClient } from '@angular/common/http';
import { bootstrapApplication } from '@angular/platform-browser';


bootstrapApplication(Character, {
  providers: [provideHttpClient()]
});


@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('CharactersFront');
  constructor(private characterService :Character) {}

  obterTodosPersonagens(){
    this.characterService.obterTodos();
  }
}
