﻿using Census.People.Domain.Entities;
using Census.People.Domain.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Census.People.Application.Commands
{
    public class BasePersonCommandHandler
    {
        readonly IPersonRepository PersonRepository;

        public BasePersonCommandHandler(IPersonRepository personRepository)
        {
            PersonRepository = personRepository;
        }

        public async Task Validate(Person person)
        {
            await CheckIfExists(person.Id, "Id");

            if (HasDefinedFather(person))
                await CheckIfExists(person.FatherId, "FatherId");

            if (HasDefinedMother(person))
                await CheckIfExists(person.MotherId, "MotherId");
        }

        public async Task CheckIfExists(string id, string field)
        {
            var person = await PersonRepository.GetPersonById(id);
            if (person == null) throw new ValidationException(
                new List<ValidationFailure>() { new ValidationFailure(field, "Valor Inválido") });
        }

        public Person RequestToEntity(BasePersonCommand request)
        {
            return new Person()
            {
                Id = request.Id,
                Name = request.Name,
                Education = request.Education,
                Race = request.Race,
                Sex = request.Sex,
                Address = request.Address,
                FatherId = request.FatherId,
                MotherId = request.MotherId
            };
        }

        private static bool HasDefinedMother(Person person)
        {
            return !String.IsNullOrEmpty(person.MotherId);
        }

        private static bool HasDefinedFather(Person person)
        {
            return !String.IsNullOrEmpty(person.FatherId);
        }
    }
}