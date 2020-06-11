import { Component, OnInit } from '@angular/core';
import { PetService } from '../APIGetters/pet.service';
import { Pet } from '../petModel/Pet';
import { AlertifyService } from '../APIGetters/alertify.service';
import { ActivatedRoute, Router, RouterEvent, NavigationEnd } from '@angular/router';
import { TokenService } from '../APIGetters/token.service';
import { filter } from 'rxjs/operators';
import { NgxGalleryImage, NgxGalleryOptions, NgxGalleryAnimation } from 'ngx-gallery-9';

@Component({
  selector: 'app-singlepet',
  templateUrl: './singlepet.component.html',
  styleUrls: ['./singlepet.component.css']
})
export class SinglepetComponent implements OnInit {
  pet: Pet;
  galleryOptions: NgxGalleryOptions[];
  galleryImages: NgxGalleryImage[];

  constructor(private petService: PetService, private route: ActivatedRoute, private router: Router, private tokenService: TokenService) { }

  ngOnInit() {
    this.getPet();
    this.router.events.pipe(
      filter((event: RouterEvent) => event instanceof NavigationEnd)
    ).subscribe(() => {
      this.getPet();
    });

    this.galleryOptions = [
      {
          width: '600px',
          height: '400px',
          thumbnailsColumns: 4,
          imageAnimation: NgxGalleryAnimation.Slide
      },
      // max-width 800
      {
          breakpoint: 800,
          width: '100%',
          height: '600px',
          imagePercent: 80,
          thumbnailsPercent: 20,
          thumbnailsMargin: 20,
          thumbnailMargin: 20
      },
      // max-width 400
      {
          breakpoint: 400,
          preview: false
      }
  ];

   // this.galleryImages = this.setupPhotosURLs();
  }

  getPet()
  {
    this.petService.getPet(this.route.snapshot.params['petId']).subscribe((pet: Pet) => {
      console.log('testujmy ' + pet);
      this.pet = pet;
      this.galleryImages = this.setupPhotosURLs();
    }, error => {
      console.log(error);
    });

  }

  isProfileOfCurrentUser()
  {
    const idFromToken = this.tokenService.getUserIdFromToken();
    if (this.pet?.id == idFromToken)
    {
      return true;
    } else
    {
      return false;
    }

  }

  setupPhotosURLs() {
    const images = [];
    console.log(this.pet);
    for (let i = 0; i < this.pet.photos.length; i++) {
      console.log('zdjecie url ' + this.pet.photos[i].url);
      images.push({
        small: this.pet.photos[i].url,
        medium: this.pet.photos[i].url,
        big: this.pet.photos[i].url,
        description: this.pet.photos[i].description
      });
    }
    return images;
  }
}
