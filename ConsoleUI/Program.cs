
using Business.Concrete;
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
		static void Main()
		{
			//Login();

			RentalManager rentalManager = new RentalManager(new EfRentalDal());

			Rental rental = new Rental { CarId = 6, CustomerId = 6, RentDate = DateTime.Now };
			rentalManager.Add(rental);
			//var result = rentalManager.Add(rental);
			//var result = rentalManager.UpdateRenturnDate(1);
			//var result = rentalManager.UpdateRenturnDate(2);
			//Console.WriteLine(result.Message);

			//var result =rentalManager.UpdateRenturnDate(1);
			//Console.WriteLine(result.Message);


			CarImageManager carImageManager = new CarImageManager(new EfCarImageDal());

			CarImage carImage = new CarImage { CarId = 3, Date = DateTime.Now, ImagePath = "Dosya Yolu" };

			

			//CarManager carManager = new CarManager(new EfCarDal());

			
			//var result =rentalManager.GetRentalDetailsById(1).Data;

			//foreach (var item in rentalManager.GetRentalDetailsById(1).Data)
			//{
			//	Console.WriteLine(item.FullName.PadRight(20)+item.Email.PadRight(20)+item.CompanyName.PadRight(10)+item.BrandName.PadRight(10)+item.Description+"  "+item.DailyPrice+"  "+ item.RentDate+"  "+item.ReturnDate);
			//}

		
		}

		private static void Login()
		{
			Console.WriteLine("Araç Kiralama İşlem Menüsü");
			Console.WriteLine("************************");
			Console.WriteLine("1) Araç Bilgi ve Veri Düzenleme Paneli");

			Console.Write("Lütfen bir işlem seçiniz :");
			int option = Convert.ToInt32(Console.ReadLine());


			switch (option)
			{
				case 1:
					CarSettings();
					break;
			}
		}

		private static void CarSettings()
		{
			ColorManager colorManager = new ColorManager(new EfColorDal());
			BrandManager brandManager = new BrandManager(new EfBrandDal());

			Console.WriteLine("\n1)Renk Ekleme\n2)Renk Güncelleme\n3)Renk Silme\n4)Marka Ekleme\n5)Marka Güncelleme\n6)Marka Silme");
			Console.Write("\nYapmak istediğiniz işlemi seçiniz :");

			int option = Convert.ToInt32(Console.ReadLine());


			switch (option)
			{
				case 1:
					ColorAdd(colorManager);
					break;
				case 2:
					ColorUpdate(colorManager);
					break;
				case 3:
					ColorDelete(colorManager);
					break;
				case 4:
					BrandAdd(brandManager);
					break;
				case 5:
					BrandUpdate(brandManager);
					break;
				case 6:
					BrandDelete(brandManager);
					break;
				default:
					break;
			}



			Console.Clear();
			Login();

		}

		private static void ColorAdd(ColorManager colorManager)
		{
			Console.Write("Eklemek istediğiniz rengi giriniz :");
			Color color = new Color { ColorName = Console.ReadLine() };
			colorManager.Add(color);

			Console.Clear();
			Login();
		}

		private static void ColorUpdate(ColorManager colorManager)
		{
			foreach (Color color in colorManager.GetAll().Data)
			{
				Console.WriteLine(color.ColorId.ToString().PadRight(10) + color.ColorName);
			}
			Console.WriteLine();
			Console.Write("Lütfen değiştirmek istediğiniz rengin numarasını giriniz :");
			int option = Convert.ToInt32(Console.ReadLine());
			var colorupdate = colorManager.GetById(option).Data;

			Console.Write("Yeni rengi giriniz :");
			Color updateColor = new Color { ColorId = colorupdate.ColorId, ColorName = Console.ReadLine() };
			colorManager.Update(updateColor);


			Console.Clear();
			Login();
		}

		private static void ColorDelete(ColorManager colorManager)
		{
			foreach (Color color in colorManager.GetAll().Data)
			{
				Console.WriteLine(color.ColorId.ToString().PadRight(10) + color.ColorName);
			}
			Console.WriteLine();
			Console.Write("Lütfen silmek istediğiniz rengin numarasını giriniz :");
			int option = Convert.ToInt32(Console.ReadLine());
			var colorDelete = colorManager.GetById(option).Data;
			colorManager.Delete(colorDelete);

			Console.Clear();
			Login();

		}


		private static void BrandAdd(BrandManager brandManager)
		{
			Console.Write("Eklemek istediğiniz marka giriniz :");
			Brand brand = new Brand { BrandName = Console.ReadLine() };
			brandManager.Add(brand);

			Console.Clear();
			Login();
		}

		private static void BrandUpdate(BrandManager brandManager)
		{
			foreach (Brand brand in brandManager.GetAll().Data)
			{
				Console.WriteLine(brand.BrandId.ToString().PadRight(10) + brand.BrandName);
			}
			Console.WriteLine();
			Console.Write("Lütfen değiştirmek istediğiniz markanın numarasını giriniz :");
			int option = Convert.ToInt32(Console.ReadLine());
			var brandUpdate = brandManager.GetById(option).Data;

			Console.Write("Yeni rengi giriniz :");
			Brand updateBrand = new Brand { BrandId = brandUpdate.BrandId, BrandName = Console.ReadLine() };
			brandManager.Update(updateBrand);




			Console.Clear();
			Login();

		}

		private static void BrandDelete(BrandManager brandManager)
		{
			foreach (Brand brand in brandManager.GetAll().Data)
			{
				Console.WriteLine(brand.BrandId.ToString().PadRight(10) + brand.BrandName);
			}
			Console.WriteLine();
			Console.Write("Lütfen silmek istediğiniz marka numarasını giriniz :");
			int option = Convert.ToInt32(Console.ReadLine());
			var brandDelete = brandManager.GetById(option).Data;
			brandManager.Delete(brandDelete);



			Console.Clear();
			Login();

		}




	}
}

