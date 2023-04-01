
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

        foreach (var item in carManager.GetAll())
        {
            Console.WriteLine(item.Description);
        }
    }
}