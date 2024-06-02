using System.ComponentModel.DataAnnotations;

namespace AppSettingsValidators.Configurations.Settings
{
    public class PoCoSettings
    {
        [Required]
        public string FieldOne { get; init; }

        [Required]
        public string FieldTwo { get; init; }
    }
}
