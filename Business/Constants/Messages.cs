using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string ProductsListed = "Ürünler listelendi";
        public static string ProductDeleted = "Ürün kaldırıldı";
        public static string ProductUpdated = "Ürün Güncellendi";
        public static string ProductCountOfCategoryError = "Kategorideki ürün limitini aştınız";
        public static string ProductNameAlreadyExsists = "Bu isimde başka bir ürün var";
        public static string CategoryLimitExceeded = "Kategori limiti aşıldığı için yeni ürün eklenemiyor";
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserRegistered = "Kayıt oldu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola Hatalı";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserAlreadyExists = "Kullanıcı zaten var";
        public static string AccessTokenCreated = "Token oluşturuldu";
        public static string ProductImageAdded = "Ürün görseli eklendi.";
        public static string ProductImageDoesNotFound = "Ürün görseli bulunamadı.";
        public static string ProductImageDeleted = "Ürün görseli silindi.";
        public static string ProductImageUpdated = "Ürün görseli güncellendi.";
        public static string CarImageLimitExceeded = "Ürün görsel limiti dolu.(5)";
    }
}
