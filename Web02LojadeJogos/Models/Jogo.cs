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
        public string JogoVersao { get; set; }

        [Display(Name = "Desenvolvedor")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O nome da desenvolvedora deve ter entre 5 e 100 caracteres")]
        public string JogoDesenvolvedor { get; set; }

        [Display(Name = "Gênero")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string JogoGenero { get; set; }

        [Display(Name = "Faixa etária")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(1, 100, ErrorMessage = "A faixa etária deve estar entre 1 e 100 anos")]
        public byte JogoFaixaEtaria { get; set; }

        [Display(Name = "Plataforma")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string JogoPlataforma { get; set; }
        
        [Display(Name = "Lançamento")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime JogoLancamento
        {
            get
            {
                return this.jogoLancamento.HasValue
                    ? this.jogoLancamento.Value
                    : DateTime.Now;
            }
            set
            {
                this.jogoLancamento = value;
            }
        }

        private DateTime? jogoLancamento = null;

        [Display(Name = "Sinopse")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(255, MinimumLength = 30, ErrorMessage = "A sinopse deve ter entre 30 e 255 caracteres")]
        public string JogoSinopse { get; set; }
    }
}