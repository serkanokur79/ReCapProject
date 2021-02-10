using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    interface IBrandService
    {
        List<Brand> GetAllBrands();
        Brand GetBrandById(int brandId);
        void Add(Brand brand);
        void Update(Brand brand);
        void Delete(Brand brand);
    }
}
