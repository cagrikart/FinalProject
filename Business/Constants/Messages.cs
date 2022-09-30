using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz ";
        public static string MaintenanceTime = " Zaman doldu ";
        public static string ProductListed = " Ürünler listelendi";
        public static string CategoryListed = "   Category listelendi";
        public static string ProductCountOfCategoryError = " bu kategori de 10 dan fazla ürün olabilir.  ";
        public static string CategoryLimitExceded = "category sayısı doldu ";
        public static string AuthorizationDenied =" Yetkiniz yok aga ";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";

        public static string ProductNameAlreadyExists = "Ürün ismi zaten mevcut";
    }
}
