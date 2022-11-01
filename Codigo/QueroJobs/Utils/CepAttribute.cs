using System.ComponentModel.DataAnnotations;


namespace Utils;

/// <summary>
/// Validação customizada para CPF
/// </summary>
public class CEPAttribute : ValidationAttribute
{
    /// <summary>
    /// Construtor
    /// </summary>
    public CEPAttribute() { }

    /// <summary>
    /// Validação server
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
#pragma warning disable CS8765 // A nulidade do tipo de parâmetro 'value' não corresponde ao membro substituído (possivelmente devido a atributos de nulidade).
    public override bool IsValid(object value)
#pragma warning restore CS8765 // A nulidade do tipo de parâmetro 'value' não corresponde ao membro substituído (possivelmente devido a atributos de nulidade).
    {
        if (value == null || string.IsNullOrEmpty(value.ToString()))
            return true;
        var valueNoEspecial = Methods.RemoveSpecialsCaracts((string)value);
        if (valueNoEspecial.ToString().Length != 8)
            return false;
        if (valueNoEspecial.ToString().StartsWith("0"))
            return false;
        return true;
    }

    public string ErrorMessage =>
        $"CEP Inválido";
}
