using System;
using System.Collections.Generic;
using System.Text;

namespace OrderApp
{
    public class Shopper
    {
        public string Name { get; set; }

        private string CardID { get; set; }

        private string Code { get; set; }

        public Shopper() { }

        public Shopper(string Name)
        {
            this.Name = Name;
            this.CardID = CardID != null ? CardID : DateTime.Now.GetHashCode().ToString();
            this.Code = "123456";
        }

        public Shopper(string Name, string Code)
        {
            this.Name = Name;
            this.CardID = CardID != null ? CardID : DateTime.Now.GetHashCode().ToString();
            this.Code = Code != null ? Code : "";
        }

        public override bool Equals(object obj)
        {
            var shopper = obj as Shopper;
            return shopper != null &&
                   CardID == shopper.CardID &&
                   Name == shopper.Name;
        }

        public override int GetHashCode()
        {
            var hashCode = 1479869798;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CardID);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            return hashCode;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
