using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public class Messages
    {
        public const string Added = "Eklendi";
        public const string Deleted = "Silindi";
        public const string Updated = "Güncellendi";
        public const string Listed = "Listelendi";
        public const string NotListed = "Listelenmedi";
        public const string NotAdded = "Eklenemedi";
        public const string UserNotFound = "Kullanıcı Bulunamadı";
        public const string SystemLoginSuccessful = "Sisteme Giriş Başarılı";
        public static string SystemLoginFailed = "Sisteme Giriş Başarısız";
        public static string UserNameAlreadyExsist = "Bu kullanıcı mevcut";
        public static string UserRegistered = "Kullanıcı kaydedildi";
    }
}
