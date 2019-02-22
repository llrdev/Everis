using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Teste.Business.Dto
{
    public class WordDTO
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Just letter in WordOne")]
        public string WordOne { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Just letter in WordTwo")]
        public string WordTwo { get; set; }
    }
}
