﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Color:IEntity
    {
        public int Id { get; set; }
        public int ColorId { get; set; }
        public string ColorName { get; set; }

    }
}
