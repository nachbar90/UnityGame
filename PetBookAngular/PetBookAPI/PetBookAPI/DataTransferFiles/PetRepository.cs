﻿using Microsoft.EntityFrameworkCore;
using PetBookAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetBookAPI.DataTransferFiles
{
    public class PetRepository : IPetsRepository
    {
        public Context context { get; set; }

        public PetRepository(Context context)
        {
            this.context = context;
        }

        public void AddPet(Pet pet)
        {
            context.Add(pet);
        }

        public void DeletePet(Pet pet)
        {
            context.Remove(pet);
        }

        public async Task<Pet> GetPet(int petId)
        {
            return await context.Pets.Include(pet => pet.Photos).FirstOrDefaultAsync(pet => pet.Id == petId);
        }

        public async Task<IEnumerable<Pet>> GetPets()
        {
            return await context.Pets.Include(pet => pet.Photos).ToListAsync();
        }

        public async Task<bool> Save()
        {
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<Photo> GetPhoto(int photoId)
        {
            return await context.Photos.FirstOrDefaultAsync(photo => photo.Id == photoId);
        }

        public async Task<Photo> GetMainPhoto(int petId)
        {
            return await context.Photos.FirstOrDefaultAsync(photo => photo.PetId == petId && photo.MainPhoto == true);
        }

        public void DeletePhoto(Photo photo)
        {
            context.Remove(photo);
        }
    }
}
