using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6.hw
{
    class ClientInfo
    {
        public int Id { get; set; }
        public string name { get; set; }
        private string address { get; set; }
        private uint phoneNum { get; set; }

        public ClientInfo(int id, string name, string address, uint phoneNum)
        {
            this.Id = id;
            this.name = name;
            this.address = address;
            this.phoneNum = phoneNum;
        }
        public override bool Equals(object obj)
        {
            var client = obj as ClientInfo;
            return client != null && client.Id == this.Id;
        }
        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }
        public override string ToString()
        {
            return $"Client ID:{Id} \n Client Name:{name} \n Client Address:{address} \nClient PhoneNo:{phoneNum}";
        }
    }
}
