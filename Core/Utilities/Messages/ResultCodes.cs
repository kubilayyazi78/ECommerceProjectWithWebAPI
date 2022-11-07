using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Messages
{
    public enum ResultCodes
    {
        #region ERROR
        /// <summary>
        /// Kullanıcı Bulunamadı! 
        /// </summary>
        ERROR_UserNotFound = -20_001,
        #endregion
        #region INFO
        /// <summary>
        /// Kullanıcı başarıyla kaydedildi.
        /// </summary>
        INFO_UserRegistered = 1,

        #endregion

        #region VALIDATION
        /// <summary>
        /// Kullanıcı adı alanı boş geçilemez!
        /// </summary>
        VALIDATION_UserNameFieldCannotBeEmpty = -3001,
        #endregion

        #region LABEL
        /// <summary>
        /// Kullanıcı Adı
        /// </summary>
        LABEL_UserName = 7000,
        /// <summary>
        /// Kullanıcı Tip Adı
        /// </summary>
        LABEL_AppUserTypeName = 7001,
        /// <summary>
        /// Kullanıcı Profil Fotoğrafı
        /// </summary>
        LABEL_ProfileImageUrl = 7002,
        /// <summary>
        /// Kullanıcı Adı
        /// </summary>
        LABEL_FirstName = 7003,
        /// <summary>
        /// Kullanıcı Soyadı
        /// </summary>
        LABEL_LastName = 7004,
        /// <summary>
        /// Operasyonlar
        /// </summary>
        LABEL_Operations = 7005,
        /// <summary>
        /// Kullanıcı Listesi
        /// </summary>

        #endregion

        #region Button
        BUTTON_Add = 9000,
        BUTTON_Update = 9001,
        BUTTON_Delete = 9002,
        BUTTON_Detail = 9003,
        BUTTON_SignOut = 9004,
        #endregion

        #region Title
        PAGETITLE_AppUserList = 8000,

        PAGETITLE_AppUserAdd = 8001,

        PAGETITLE_AppUserDelete = 8002,

        PAGETITLE_AppUserUpdate = 8003,

        PAGETITLE_AppUserDetail = 8004,
        #endregion

        #region HTTP Status Code
        HTTP_OK = 200,
        HTTP_InternalServerError = 500,
        HTTP_BadRequest = 400,
        HTTP_Unauthorized = 401,
        HTTP_Forbidden = 403,
        HTTP_NotFound = 404,
        HTTP_Conflict = 409,
        #endregion

    }
}