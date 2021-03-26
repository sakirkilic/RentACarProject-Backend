
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
	class Program
	{
		static void Main(string[] args)
		{

			//CarManager carManager = new CarManager(new EfCarDal());
			
			//ColorManager colorManager = new ColorManager(new EfColorDal());

			//BrandManager brandManager = new BrandManager(new EfBrandDal());

			#region CarsData
			//carManager.Update(new Car {BrandId=2,ColorId=5,DailyPrice=500, Description="İ3",CarId=4,ModelYear="2017" });
			//carManager.Update(new Car {BrandId=3,ColorId=3,DailyPrice=60, Description="Albea",CarId=5,ModelYear="2012" });
			//carManager.Update(new Car {BrandId=3,ColorId=4,DailyPrice=50, Description="Doblo",CarId=6,ModelYear="2010" });
			//carManager.Update(new Car {BrandId=3,ColorId=5,DailyPrice=80, Description="Linea",CarId=7,ModelYear="2011" });
			//carManager.Update(new Car {BrandId=5,ColorId=2,DailyPrice=500, Description="Mustang",CarId=8,ModelYear="2020" });
			//carManager.Update(new Car {BrandId=5,ColorId=1,DailyPrice=150, Description="Focus",CarId=9,ModelYear="2017" });
			//carManager.Update(new Car {BrandId=4,ColorId=5,DailyPrice=300, Description="A3 Cabrio",CarId=10,ModelYear="2017" });
			//carManager.Update(new Car {BrandId=4,ColorId=3,DailyPrice=250, Description="A6 Sedan",CarId=11,ModelYear="2017" }); 
			#endregion

			 
			//foreach (var item in carManager.GetAll().Data)
			//{
			//	Console.WriteLine(item.CarId.ToString().PadRight(5)+item.BrandId.ToString().PadRight(5)+item.ColorId.ToString().PadRight(5)+item.Description.PadRight(15)+item.DailyPrice.ToString().PadRight(10)+item.ModelYear);
			//}


			//foreach (var item in carManager.GetCarDetails())
			//{
			//	Console.WriteLine(item.BrandName.PadRight(15)+item.Description.PadRight(15)+item.DailyPrice.ToString().PadRight(10)+item.ColorName);
			//}

			//foreach (var item in brandManager.GetAll())
			//{
			//	Console.WriteLine(item.BrandName);
			//}

			//foreach (var item in carManager.GetCarsByBrandId(3).Data)
			//{
			//	Console.WriteLine(item.CarId.ToString().PadRight(5) + item.BrandId.ToString().PadRight(5) + item.ColorId.ToString().PadRight(5) + item.Description.PadRight(15) + item.DailyPrice.ToString().PadRight(10) + item.ModelYear);
			//}
			
			#region All Brand Simple
			//List<Brand> brands = new List<Brand>() { new Brand { BrandName = "Mercedes" }, new Brand { BrandName = "Bmw" }, new Brand {BrandName="Fiat" },new Brand { BrandName = "Audi" }, new Brand {BrandName="Ford" } };

			//foreach (var item in brands)
			//{
			//	brandManager.Add(item);
			//}
			//foreach (var item in brandManager.GetAll())
			//{
			//	Console.WriteLine(item.BrandId+"     "+item.BrandName);
			//}

			//Console.WriteLine(brandManager.GetById(3).BrandName); 
			#endregion

			#region All Color Simple
			#region Renk ekle ve listele
			//List<Color> colors = new List<Color>() { new Color {ColorName="Sarı" }, new Color { ColorName = "Mor" }, new Color { ColorName = "Beyaz" }, new Color { ColorName = "Siyah" }, new Color { ColorName = "Gri" } };

			//foreach (var item in colors)
			//{
			//	colorManager.Add(item);
			//} 
			#endregion

			//colorManager.Delete(colorManager.GetById(8));
			//Console.WriteLine(colorManager.GetById(3).ColorName);
			//colorManager.Update(new Color { ColorId = 3, ColorName = "Yeşil" });


			//foreach (var item in colorManager.GetAll())
			//{
			//	Console.WriteLine(item.ColorId+"       "+item.ColorName);
			//}


			//GettAllSimple(carManager); 
			#endregion





		}

		//private static void GettAllSimple(CarManager carManager)
		//{
		//	foreach (var item in carManager.GetAll().Data)
		//	{
		//		Console.WriteLine(item.CarId + "       " + item.Description);
		//	}
		//}
	}
}
