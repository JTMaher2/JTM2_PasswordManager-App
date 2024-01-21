// MIT License
// Copyright JTMaher2

namespace JTM2_Passwords_Mobile_App
{
    /// <summary>
    /// Represents an item entity.
    /// </summary>
    public class Item : BaseEntity
    {
        /// <summary>
        /// Gets or sets the item name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the item description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the item master password.
        /// </summary>
        public string M_StrMasterPassword { get; set; }
    }
}