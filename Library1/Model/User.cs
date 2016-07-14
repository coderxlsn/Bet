using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library1.Model
{
    public class User: IModel ,IEquatable<User> ,IComparable<User>
    {
        private int ID;
        private string Name;
        private DateTime DateShet;
        private int IdPartner;
        private Double summ;

        public double Summ
        {
            get
            {
                return summ;
            }

            set
            {
                summ = value;
            }
        }

        public int IdPartner1
        {
            get
            {
                return IdPartner;
            }

            set
            {
                IdPartner = value;
            }
        }

        public DateTime DateShet1
        {
            get
            {
                return DateShet;
            }

            set
            {
                DateShet = value;
            }
        }

        public string Name1
        {
            get
            {
                return Name;
            }

            set
            {
                Name = value;
            }
        }

        public int ID1
        {
            get
            {
                return ID;
            }

            set
            {
                ID = value;
            }
        }
        public override string ToString()
        {
            string result = "";
            result = result + "ID = " + ID;
            result = result + ";Name = " + Name;
            result = result + "; StartDate = " + DateShet;
            result = result + "; summ = " + summ;
            return result;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            User objAsPart = obj as User;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public int CompareTo(User compareUser)
        {
            if(compareUser == null)
            {
                return 1;
            }else
            {
                return this.DateShet.CompareTo(compareUser.DateShet);
            }
        }
        public override int GetHashCode()
        {
            return  (int)this.DateShet.Ticks;
        }
        public bool Equals(User other)
        {
            if (other == null) return false;
            return (this.DateShet.Equals(other.DateShet));
        }

    }
}
