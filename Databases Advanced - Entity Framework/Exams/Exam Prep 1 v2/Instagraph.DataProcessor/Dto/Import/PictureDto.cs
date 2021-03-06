﻿namespace Instagraph.DataProcessor.Dto.Import
{
    using System.ComponentModel.DataAnnotations;

    public class PictureDto
    {
        [Required]
        public string Path { get; set; }

        [Required]
        [Range(typeof(decimal), "1", "79228162514264337593543950335")]
        public decimal Size { get; set; }
    }
}