import { Injectable, EventEmitter } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class EmitterService {
  public valueEmitter: EventEmitter<boolean> = new EventEmitter();
}
