using Laboratorios_CampusTech.Models;

namespace Laboratorios_CampusTech.Data
{
    public static class ReservaData
    {
        private static List<Laboratorio> _reservas = new List<Laboratorio>();

        public static List<Laboratorio> GetAll()
        {
            return _reservas;
        }

        public static void Add(Laboratorio reserva)
        {
            _reservas.Add(reserva);
        }

        public static bool ExisteCodigo(string codigo)
        {
            return _reservas.Any(r => r.CodRes == codigo);
        }
    }
}
