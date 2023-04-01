using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarContext context = new CarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.Id equals b.Id
                             join cl in context.Colors on c.Id equals cl.Id
                             select new CarDetailDto
                             {
                                 CarName=c.Name,BrandName=b.Name,ColorName=cl.Name,DailyPrice=c.DailyPrice

                             };
                           
                return result.ToList();
            }
        }
    }
}
