﻿// Copyright @Frankie Yu - All Rights Reserved
// Filename: GiraffeHealthCareConsumer.cs
// Created By  :  Frankie
// Created Date:  22/08/2019  20:32
// Last Edit:
//    Author:   Frankie
//    Date:     26/08/2019  09:30

namespace ZooService.Core.Consumers
{
    using System;

    using ZooService.Core.Abstracts;
    using ZooService.Core.Models;

    public class GiraffeHealthCareConsumer : AbstractAnimalHealthCareConsumer
    {
        private readonly Animal animal = new Animal { Id = Guid.NewGuid(), Category = "Giraffe" };
        public override Animal Animal { get => base.Animal ?? this.animal; set => base.Animal = value; }
        public override int? ReducedHealth()
        {
            if (!this.Animal.SurvivalSituation)
            {
                return null;
            }

            var reducedHealthNumber = base.ReducedHealth();
            this.Animal.ReducedHealthNumber = reducedHealthNumber.Value;
            this.Animal.CurrentAnimalHealthNumber -= this.Animal.ReducedHealthNumber;
            this.Animal.SurvivalSituation = this.Animal.CurrentAnimalHealthNumber >= ZooServiceConfiguration.GiraffeSurvivalHealthNumber;
            return reducedHealthNumber;
        }
    }
}