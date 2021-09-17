using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web02LojadeJogos.Models
{
    public class Funcionario
    {
        [Display(Name = "Código")]
        public ushort FuncCod { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O nome deve ter entre 5 e 100 caracteres")]
        public string FuncNome { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "Formato: xxx.xxx.xxx-xx")]
        public string FuncCpf { get; set; }

        [Display(Name = "RG")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(14, MinimumLength = 10, ErrorMessage = "O RG deve ter entre 10 e 14 caracteres (com pontuação)")]
        public string FuncRg { get; set; }

        [Display(Name = "Data de nascimento")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FuncNasc
        {
            get
            {
                return this.funcNasc.HasValue
                    ? this.funcNasc.Value
                    : DateTime.Now;
            }
            set
            {
                this.funcNasc = value;
            }
        }

        private DateTime? funcNasc = null;

        [Display(Name = "Endereço")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(150, MinimumLength = 15, ErrorMessage = "O endereço deve ter entre 15 e 150 caracteres")]
        public string FuncEndereco { get; set; }

        [Display(Name = "Celular")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(11, MinimumLength = 8, ErrorMessage = "Apenas números, incluir DDD")]
        public string FuncCelular { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Email inválido")]
        [StringLength(70, MinimumLength = 5, ErrorMessage = "O email deve ter entre 5 e 70 caracteres")]
        public string FuncEmail { get; set; }

        [Display(Name = "Cargo")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "O cargo deve ter entre 5 e 30 caracteres")]
        public string FuncCargo { get; set; }
    }
}