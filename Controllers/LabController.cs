using Microsoft.AspNetCore.Mvc;
using Laboratorios_CampusTech.Models;

namespace Laboratorios_CampusTech.Controllers
{
    public class LaboratorioController : Controller
    {
        private static List<Laboratorio> _reservas = new List<Laboratorio>();

        private readonly List<string> _labsValidos = new List<string>
        {
            "Lab-01", "Lab-02", "Lab-03", "Lab-Redes", "Lab-IA"
        };

        public IActionResult Index()
        {
            return View(_reservas);
        }

        public IActionResult Create()
        {
            ViewBag.Labs = _labsValidos;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Laboratorio reserva)
        {
            ViewBag.Labs = _labsValidos;

            if (!_labsValidos.Contains(reserva.LabName))
            {
                ModelState.AddModelError("LabName", "Debe seleccionar un laboratorio válido.");
            }

            if (reserva.FechaRes.Date < DateTime.Now.Date)
            {
                ModelState.AddModelError("FechaRes", "La fecha no puede estar en el pasado.");
            }

            if (reserva.HoraFin <= reserva.HoraInicio)
            {
                ModelState.AddModelError("HoraFin", "La hora de fin debe ser mayor que la hora de inicio.");
            }

            if (_reservas.Any(r => r.CodRes == reserva.CodRes))
            {
                ModelState.AddModelError("CodRes", "El código de reserva ya existe.");
            }

            if (!ModelState.IsValid)
            {
                return View(reserva);
            }

            _reservas.Add(reserva);

            return RedirectToAction("Index");
        }
    }
}
