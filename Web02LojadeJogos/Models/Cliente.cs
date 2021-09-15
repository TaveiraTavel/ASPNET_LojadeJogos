using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web02LojadeJogos.Models
{
    public class Cliente
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O nome deve ter entre 5 e 100 caracteres")]
        public string CliNome { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "Formato: xxx.xxx.xxx-xx")]
        public string CliCpf { get; set; }

        [Display(Name = "Data de nascimento")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CliNasc
        {
            get
            {
                return this.cliNasc.HasValue
                    ? this.cliNasc.Value
                    : DateTime.Now;
            }
            set
            {
                this.cliNasc = value;
            }
        }

        private DateTime? cliNasc = null;

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Email inválido")]
        [StringLength(70, MinimumLength = 5, ErrorMessage = "O email deve ter entre 5 e 70 caracteres")]
        public string CliEmail { get; set; }

        [Display(Name = "Celular")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(11, MinimumLength = 8, ErrorMessage = "Apenas números, incluir DDD")]
        public string CliCelular { get; set; }

        [Display(Name = "Endereço")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(150, MinimumLength = 15, ErrorMessage = "O endereço deve ter entre 15 e 150 caracteres")]
        public string CliEndereco { get; set; }

    }
}