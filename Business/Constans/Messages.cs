using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constans
{
	public static class Messages
	{
		public static string CarAdded = "Araba eklendi";
		public static string CarNameInvalid = "Araba ismi geçersiz";
		public static string MaintenanceTime = "Sistem bakımda";
		public static string CarsListed = "Arabalar listelendi";
		public static string CarDeleted = "Araba silindi";

		public static string ColorAdded = $"Renk başarılı bir şekilde eklendi";
		public static string ColorDeleted = $"Renk başarılı bir şekilde silindi";
		public static string ColorUpdated = $"Renk başarılı bir şekilde güncellendi";
		public static string ColorsListed = $"Renkler başarılı bir şekilde getirildi";
		public static string ColorGeted= $"Renk başarılı bir şekilde geldi";


		public static string Rented = "Kiralama işleminiz başarılı bir şekilde oluşturuldu";
		public static string RentInvalid = "Kiralama işleminiz başarısız";
		public static string ReturnDateUpdated = "Araç teslim işleminiz başarılı";
		public static string ReturnDateNotUpdated = "Araç teslim işleminiz başarısız";

		public static string BrandAdded =	$"Marka başarılı bir şekilde eklendi";
		public static string BrandDeleted = $"Marka başarılı bir şekilde silindi";
		public static string BrandUpdated = $"Marka başarılı bir şekilde güncellendi";
		public static string BrandsListed = $"Markalar başarılı bir şekilde getirildi";
		public static string BrandGeted =	$"Marka başarılı bir şekilde geldi";

		public static string CustomerAdded = $"Müşteri başarılı bir şekilde eklendi";
		public static string CustomerDeleted = $"Müşteri başarılı bir şekilde silindi";
		public static string CustomerUpdated = $"Müşteri başarılı bir şekilde güncellendi";
		public static string CustomersListed = $"Müşteriler başarılı bir şekilde getirildi";
		public static string CustomerGeted = $"Müşteri başarılı bir şekilde geldi";

		public static string UserAdded = $"Kullanıcı başarılı bir şekilde eklendi";
		public static string UserDeleted = $"Kullanıcı başarılı bir şekilde silindi";
		public static string UserUpdated = $"Kullanıcı başarılı bir şekilde güncellendi";
		public static string UsersListed = $"Kullanıcılar başarılı bir şekilde getirildi";
		public static string UserGeted = $"Kullanıcı başarılı bir şekilde geldi";





		public static string CarImageLimitExceeded = "Bir arabaya en fazla 5 adet resim yükleyebilirsiniz.";

		public static string AuthorizationDenied = "Yetkiniz yok";

		public static string UserRegistered = "Kayıt başarılı bir şekilde gerçekleşti";

		public static string UserNotFound = "Kullanıcı bulunamadı";

		public static string PasswordError = "Parola hatası";

		public static string SuccessfulLogin = "Başarılı giriş";

		public static string UserAlreadyExists = "Kullanıcı mevcut";

		public static string AccessTokenCreated = "Token oluşturuldu";
	}
}
