﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionControl.DataAccess.Entities
{
    public class WeightInfo : IBaseEntity
    {
        public int Id { get; set; }
        public decimal WeightValue { get; set; }
        public DateTime DateOfMeasurement { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}