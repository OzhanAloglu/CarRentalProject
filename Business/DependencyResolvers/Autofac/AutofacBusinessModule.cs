using Autofac;
using Autofac.Core;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule :Module
    {

        //Bu class ın amacı istediğimiz kodu kullanmak için çağırdığımız zaman bize o kodun kullanılabilmesini sağlar. Örneğin aşağıda ben Car ile ilgili işlemleri yaparken CarManager sınıfını çağırdığım zaman, bana ICarService sınıfını gönder demektir.(Line 24). O sınıfın kullanımı için ise EfCarDal ve ICarDal kullanılması gerekir. Bir alt satırında ise bunların kullanımı için gerekli tanımlamaları yapmış oldum. Bunu Autofac ile sağladım. Autofac kullanmasaydım bunu farklı şekilde Startup.cs veyada Program.cs in içinde tanımlamam gerekirdi. Bundan kaçınmak için tanımlamayı burada Autofac ile yaptım. AutoFac in bir çok rakibide seçeneğide mevcut Ninject bunlardan en önemlisi. Bunun en önemli artısı artık her sınıfta bunları new leme ihtiyacı duymayacağımız olması.
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();   
            builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();


        }



    }
}
