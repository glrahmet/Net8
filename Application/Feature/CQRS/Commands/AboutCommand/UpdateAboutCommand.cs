﻿using Application.Feature.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feature.CQRS.Commands.AboutCommand
{
    public class UpdateAboutCommand : AboutBaseClass
    {
        public UpdateAboutCommand(int id)
        {
            Id = id;
        } 
        public int Id { get; set; }

    }
}
