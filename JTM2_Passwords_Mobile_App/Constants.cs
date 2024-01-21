using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.WebRequestMethods;

namespace JTM2_Passwords_Mobile_App
{
    class Constants
    { 
        public readonly static string JTM2_PasswordsUrl = "/DesktopModules/JTMaher_JTM2_PasswordsStencilJS/API/Item/GetItemsPage";
        public readonly static string JTM2_SavePasswordUrl = "/DesktopModules/JTMaher_JTM2_PasswordsStencilJS/API/Item/UpdateItemMobileApp";
        public readonly static string JTM2_DeletePasswordUrl = "/DesktopModules/JTMaher_JTM2_PasswordsStencilJS/API/Item/DeleteItemMobileApp";
        public readonly static string JTM2_CreatePasswordUrl = "/DesktopModules/JTMaher_JTM2_PasswordsStencilJS/API/Item/CreateItemMobileApp";
        public readonly static string JTM2_LoginUrl = "/DesktopModules/JwtAuth/API/mobile/login";
    }
}
