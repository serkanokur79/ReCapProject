using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    interface IColorService
    {
        List<Color> GetAllColors();
        Color GetColorById(int colorId);
        void Add(Color color);
        void Update(Color color);
        void Delete(Color color);
    }
}
