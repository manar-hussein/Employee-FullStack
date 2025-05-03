import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ButtonModule } from 'primeng/button';
import { PrimeNG } from 'primeng/config';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { NavBarComponent } from "./Components/nav-bar/nav-bar.component";
@Component({
  selector: 'app-root',
  imports: [RouterOutlet, ButtonModule, MatSlideToggleModule, NavBarComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {
  title = 'EmployeeManagmenet';

  constructor(private primeng: PrimeNG) {}
  ngOnInit() {
    this.primeng.ripple.set(true);
}

toggleDarkMode() {
  const element = document.querySelector('html');
  element?.classList.toggle('my-app-dark');
  
}


}
