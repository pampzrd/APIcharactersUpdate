import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {environment} from '../environment/environment';
import {ICharacters} from './ICharacters';
import { firstValueFrom } from 'rxjs';



@Injectable({
  providedIn: 'root'
})
export class Character {
  constructor(private httpclient: HttpClient) {

  }
  async obterTodos(): Promise<ICharacters[]>  {
    const characters = await firstValueFrom(
      this.httpclient.get<ICharacters[]>(`${environment.apiUrl}`)
    );
    return characters;
  }}
