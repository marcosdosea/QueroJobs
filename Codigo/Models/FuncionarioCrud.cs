using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QueroJobs.Models
{
    public class FuncionarioCrud
    {
        [Key]
        [RegularExpression(@"^([0-9]{2}[\.]?[0-9]{3}[\.]?[0-9]{3}[\/]?[0-9]{4}[-]?[0-9]{2})|([0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?[0-9]{2})$",ErrorMessage ="Tem que seguir o padrão de cpf! Exemplo: 000.000.000-00")]
        public int Cpf { get; set; }


        [Required(ErrorMessage = "O campo nome completo é obrigatório!")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Tem que ter no mínimo 3 e no máximo 60 caracteres!")]
        [Display(Name = "Nome completo")]
        public string Nome { get; set; }

        [Required(ErrorMessage ="O campo email é obrigatório!")]
        [DataType(DataType.EmailAddress)]
        [Display(Name ="Email")]
        public string Email { get; set; }   

        [Required(ErrorMessage ="O campo senha é obrigatório")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O campo deficiência é obrigatório!")]
        [StringLength(20, ErrorMessage = "Máximo de 20 caracteres!")]
        [Display(Name ="Possui deficiências")]
        public string Deficiencia { get; set; }

        [Required(ErrorMessage = "O campo Gênero é obrigatório!")]
        [StringLength(10, ErrorMessage = "Máximo de 10 caracteres!")]
        [Display(Name = "Gênero")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "O campo data de nascimento é obrigatório!")]
        [DataType(DataType.DateTime, ErrorMessage = "Formato de data inválido!")]
        [Display(Name = "Data de nascimento")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O campo CEP é obrigatório")]
        [DataType(DataType.PostalCode, ErrorMessage ="Cep digitado é inválido!")]
        [Display(Name ="CEP")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "O campo estado é obrigatório!")]
        [StringLength(2, ErrorMessage ="Máximo de 2 caracteres!")]
        [Display(Name ="Estado")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "O campo cidade é obrigatório!")]
        [StringLength(30, ErrorMessage = "Máximo de 30 caracteres!")]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O campo bairro é obrigatório!")]
        [StringLength(30, ErrorMessage = "Máximo de 30 caracteres!")]
        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O campo endereco é obrigatório!")]
        [StringLength(30, ErrorMessage = "Máximo de 30 caracteres!")]
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "O campo número da casa é obrigatório")]
        [Range(0,99999,ErrorMessage ="O domínio de número de casa é entre 0 e 99999")]
        [Display(Name ="Número da casa")]
        public int NumeroCasa { get; set; }
        
        [StringLength(100, ErrorMessage ="Limite de caracteres de 100")]
        [Display(Name ="Complemento do endereço")]
        public string Complemento { get; set; }

        [Required(ErrorMessage ="O campo celular/telefone é obrigatório!")]
        [DataType(DataType.PhoneNumber)]
        public int Celular { get; set; }

    }
}
