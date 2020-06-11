import { Component, OnInit } from '@angular/core';
import { Pet } from '../petModel/Pet';
import { PetService } from '../APIGetters/pet.service';

@Component({
  selector: 'app-pets',
  templateUrl: './pets.component.html',
  styleUrls: ['./pets.component.css']
})
export class PetsComponent implements OnInit {
  pets: Pet[];


  constructor(private petService: PetService) { }

  ngOnInit() {
    this.getPets();
  }

 getPets()
 {
   this.petService.getPets().subscribe((pets: Pet[]) =>
    {
      this.pets = pets;
    }, error => {
      console.log(error);
    });
 }


}
