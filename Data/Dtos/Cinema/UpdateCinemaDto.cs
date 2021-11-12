﻿using System.ComponentModel.DataAnnotations;

namespace Filmes.Rest.Api.Net5.Data.Dtos.Cinema
{
    public class UpdateCinemaDto
    {      
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }
    }
}
