﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStackDemo.ApplicationService.Commands.CommandModels.MobileSuits
{
    public class UpdateMobileSuitCommand
    {
        public int Id { get; set; }
        public string ModelCode { get; set; }
        public string ModelName { get; set; }
        public string OperatingSystem { get; set; }
        public string PowerOutput { get; set; }
        public string Armor { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Manufacturer { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string EditedBy { get; set; }
    }
}
