﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediRed.Models
{
    public class Patient: Person
    {
        public Diagnostic Diagnostic { get; set; }
        public string Treatment { get; set; }
    }
}