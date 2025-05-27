using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP1
{
    public class Employee
    {
        #region cac thuoc tinh cua Employee
        private int _id;
        private string _id_card;
        private string _name;
        private string _email;
        private string _phone;
        #endregion

        public Employee ()
        {
            this._id = 1;
            this._id_card = "0922";
            this._name = "C";
        }

        public Employee(int _id, string _id_card, string _name,  string _email, string _phone)
        {
            this._id = _id;
            this._id_card = _id_card;
            this._name = _name;
            this._email = _email;
            this._phone = _phone;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Id_Card
        {
            get { return _id_card; }
            set { _id_card = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        public void PrintInfor ()
        {
            string msg = $"{Id}\t{Id_Card}\t{Name}\t{Email}\t{Phone}";
            Console.WriteLine(msg);
        }

        public override string ToString()
        {
            return $"{Id}\t{Id_Card}\t{Name}\t{Email}\t{Phone}";
        }
    }
}
