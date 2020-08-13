using System;
using System.Collections.Generic;
using System.Text;

namespace JTM2_Passwords_Mobile_App
{
    public class JTM2_Password
    {
        public int PasswordId { get; set; } = -1;
        ///<summary>
        /// A string with the name of the website that the password is for
        ///</summary>
        public string PasswordSite { get; set; }

        ///<summary>
        /// A byte array with the encrypted text of the password
        ///</summary>
        public byte[] PasswordText { get; set; }

        ///<summary>
        /// A string with the text of the password
        ///</summary>
        public string PasswordPlainText { get; set; }

        ///<summary>
        /// A byte array with the IV of the password
        ///</summary>
        public byte[] PasswordIV { get; set; }

        ///<summary>
        /// A byte array with the salt of the password
        ///</summary>
        public byte[] PasswordSalt { get; set; }

        ///<summary>
        /// A string with the URL of the website
        /// </summary>
        public string PasswordUrl { get; set; }

        ///<summary>
        /// A string with any notes the user has about the password
        /// </summary>
        public string PasswordNotes { get; set; }

        ///<summary>
        /// An integer with the user id of the assigned user for the object
        ///</summary>
        public int AssignedUserId { get; set; }

        ///<summary>
        /// The ModuleId of where the object was created and gets displayed
        ///</summary>
        public int ModuleId { get; set; }

        ///<summary>
        /// An integer for the user id of the user who created the object
        ///</summary>
        public int CreatedByUserId { get; set; } = -1;

        ///<summary>
        /// An integer for the user id of the user who last updated the object
        ///</summary>
        public int LastModifiedByUserId { get; set; } = -1;

        ///<summary>
        /// The date the object was created
        ///</summary>
        public DateTime CreatedOnDate { get; set; } = DateTime.UtcNow;

        ///<summary>
        /// The date the object was updated
        ///</summary>
        public DateTime LastModifiedOnDate { get; set; } = DateTime.UtcNow;
    }
}
