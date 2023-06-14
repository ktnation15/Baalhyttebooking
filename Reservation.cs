using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baalhyttebooking
{
    public class Reservation
    {
        private int _id;

        public int ID
        {
            get { return _id; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Id skal være større end 0.");
                }
                _id = value;
            }
        }
        public DateTime Tidspunkt { get; set; }
        public BoerneGruppe BoerneGruppe { get; set; }

        public Reservation(int id, DateTime tidspunkt, BoerneGruppe boerneGruppe)
        {
            ID = id;
            Tidspunkt = tidspunkt;
            BoerneGruppe = boerneGruppe;
        }

        public override string ToString()
        {
            return $"Reservation - Id: {ID}, Tidspunkt: {Tidspunkt}, BoerneGruppe: {BoerneGruppe.ToString()}";
        }
    }
}
