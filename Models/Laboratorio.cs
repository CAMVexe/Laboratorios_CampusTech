using System.ComponentModel.DataAnnotations;

namespace Laboratorios_CampusTech.Models
{
    public class Laboratorio
    {
        [Required(ErrorMessage = "El nombre del profesor es obligatorio")]
        [MinLength(3, ErrorMessage = "El nombre del profesor debe tener al menos 3 letras")]
        public string ProfName { get; set; } = string.Empty;

        [Required(ErrorMessage = "La dirección de correo institucional es obligatoria")]
        [EmailAddress(ErrorMessage = "Formato de correo institucional incorrecto")]
        [RegularExpression(@"^[A-Za-z0-9._%+-]+@campus\.edu$", ErrorMessage = "El correo institucional debe pertener al dominio '@campus.edu'")]
        public string InstEmail { get; set; } = string.Empty;

        [Required(ErrorMessage = "El nombre del laboratorio es obligatorio")]
        public string LabName { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de la reservación es obligatoria")]
        [DataType(DataType.Date)]
        public DateTime FechaRes { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "La hora de inicio de la reserva es obligatoria")]
        [DataType(DataType.Time)]
        public DateTime HoraInicio { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "La hora de finalización de la reserva es obligatoria")]
        [DataType(DataType.Time)]
        public DateTime HoraFin { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "El motivo de la reserva es obligatorio")]
        [MinLength(5, ErrorMessage = "El motivo de la reserva debe tener al menos 5 caracteres")]
        [MaxLength(200, ErrorMessage = "El motivo de la reserva puede tener como máximo 200 caracteres")]
        public string Motivo { get; set; } = string.Empty; 

        [Required(ErrorMessage = "El código de la reserva es obligatorio")]
        [RegularExpression(@"^RES-\d{3}$", ErrorMessage = "El código de la reserva debe tener el formato 'RES-' seguido por 3 dígitos")]
        public string CodRes { get; set; } = string.Empty;
    }
}
