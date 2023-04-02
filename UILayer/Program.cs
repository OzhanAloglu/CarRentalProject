
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

class Program
{
    static void Main(string[] args)
    {
        CarTest();

    }

    private static void CarTest()
    {
        CarManager carManager = new CarManager(new EfCarDal());

        var result = carManager.GetCarDetails();

        if (result.Success==true)
        {

            foreach (var item in result.Data)
            {
                Console.WriteLine(item.CarName+" : "+item.BrandName+" : "+item.ColorName+" : "+item.DailyPrice);
            }
        
        }

        else
        {
            Console.WriteLine(result.Message);
        }
        

      
    }
}