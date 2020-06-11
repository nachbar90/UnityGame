using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetBookAPI.DataTransferFiles;
using PetBookAPI.Model;

namespace PetBookAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        public IPetsRepository petsRepository;
        public IMapper mapper;

        public PetsController(IPetsRepository petsRepository, IMapper mapper)
        {
            this.petsRepository = petsRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPets()
        {
            //List<PetDTO> petsDTO = new List<PetDTO>();
            var pets = await petsRepository.GetPets();

            /* foreach (var pet in pets)
             {
                 var petDTO = new PetDTO
                 {
                     Id = pet.Id,
                     Name = pet.Name,
                     Gender = pet.Gender,
                     Description = pet.Description,
                     Age = pet.Age,
                     City = pet.City,
                     Photos = pet.Photos,
                     Photo = pet.Photos.Where(p => p.MainPhoto == true).Select(p => p.Url).FirstOrDefault()
                 };

                 petsDTO.Add(petDTO);
             }    */
            var petsDTO = mapper.Map<IEnumerable<PetDTO>>(pets);


            return Ok(petsDTO);
        }

        [HttpGet("{petId}")]
        public async Task<IActionResult> GetPet(int petId)
        {
            var pet = await petsRepository.GetPet(petId);

            var petDTO = mapper.Map<PetDTO>(pet);

            return Ok(petDTO);
        }

        [HttpPut("{petId}")]
        public async Task<IActionResult> Update(EditPetDTO editPetDTO , int petId)
        {
            if (petId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();
            var pet = await petsRepository.GetPet(petId);

            mapper.Map(editPetDTO, pet);

            if (await petsRepository.Save())
            {
                return NoContent();
            }
            throw new Exception("Server nie zapisał zmian");


        }
    }
}