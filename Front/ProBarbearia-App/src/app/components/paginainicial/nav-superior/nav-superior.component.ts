import { Component, OnInit } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { navbarData } from '../nav-data';

@Component({
  selector: 'app-nav-superior',
  templateUrl: './nav-superior.component.html',
  styleUrls: ['./nav-superior.component.scss']
})
export class NavSuperiorComponent implements OnInit {

  navData = navbarData;
  routerLink = "" as string;
  constructor(private router: Router) { }

  ngOnInit(): void {
    this.routerLink= this.router.url;
    console.log( this.routerLink);

  }


}
