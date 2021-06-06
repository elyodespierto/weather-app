using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class City
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public bool Enabled { get; set; }

        public string BeautyCountry => Country == "AR" ? "Argentina" : Country;
    }
}
