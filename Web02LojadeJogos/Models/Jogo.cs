using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web02LojadeJogos.Models
{
    public class Jogo
    {
        [Display(Name = "Código")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(1, 99999, ErrorMessage = "O código deve estar entre 1 e 99999")]
        public ushort JogoCod { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O nome deve ter entre 5 e 100 caracteres")]
        public string JogoNome { get; set; }

        [Display(Name = "Versão")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "A versão deve ter entre 1 e 20 caracteres")]
        public string JogoVersao { get; set; }

        [Display(Name = "Desenvolvedor")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O nome da desenvolvedora deve ter entre 5 e 100 caracteres")]
        public string JogoDesenvolvedora { get; set; }

        [Display(Name = "Gênero")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(40, MinimumLength = 5, ErrorMessage = "O gênero deve ter entre 5 e 40 caracteres")]
        public string JogoGenero { get; set; }

        [Display(Name = "Faixa etária")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(1, 100, ErrorMessage = "A faixa etária deve estar entre 1 e 100 anos")]
        public byte JogoFaixaEtaria { get; set; }

        [Display(Name = "Plataforma")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(40, MinimumLength = 5, ErrorMessage = "A plataforma deve ter entre 5 e 40 caracteres")]
        public string JogoPlataforma { get; set; }
        
        [Display(Name = "Lançamento")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(1000, 9999, ErrorMessage = "O ano de lançamento deve ser entre 1000 e 9999")]
        public int JogoAnoLancamento { get; set; }

        [Display(Name = "Sinopse")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(255, MinimumLength = 30, ErrorMessage = "A sinopse deve ter entre 30 e 255 caracteres")]
        public string JogoSinopse { get; set; }
    }
}