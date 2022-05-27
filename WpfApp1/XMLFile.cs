using System.Collections.Generic;
using System.Xml.Linq;

namespace WpfApp1
{
    class XMLFIle
    {
        private string FileName;
        public XMLFIle(string fileName)
        {
            FileName = fileName;
        }

        public IEnumerable<XElement> ReadXML()
        {
            XDocument xdoc = XDocument.Load(FileName);
            IEnumerable<XElement> product = xdoc.Descendants("produkt");
            return product;
        }
    }


    public class Product
    {
        private int id;
        private int ilosc_wariantow;
        private string nazwa;
        private string dlugi_opis;
        private string waga;
        private string kod;
        private string ean;
        private int status;
        private string typ;
        private string cena_zewnetrzna;
        private string cena_zewnetrzna_hurt;
        private string vat;
        private List<string> zdjecia;

        public int Id { get => id; set { id = value; } }
        public int Ilosc_wariantow { get => ilosc_wariantow; set { ilosc_wariantow = value; } }
        public string Nazwa { get => nazwa; set { nazwa = value; } }
        public string Dlugi_opis { get => dlugi_opis; set { dlugi_opis = value; } }
        public string Waga { get => waga; set { waga = value; } }
        public string Kod { get => kod; set { kod = value; } }
        public string Ean { get => ean; set { ean = value; } }
        public int Status { get => status; set { status = value; } }
        public string Typ { get => typ; set { typ = value; } }
        public string Cena_zewnetrzna_hurt { get => cena_zewnetrzna_hurt; set { cena_zewnetrzna_hurt = value; } }
        public string Cena_zewnetrzna { get => cena_zewnetrzna; set { cena_zewnetrzna = value; } }
        public string Vat { get => vat; set { vat = value; } }

        public List<string> Zdjecia { get => zdjecia; set { zdjecia = value; } }
        public int Ilosc_zdjec { get { if (zdjecia != null) return zdjecia.Count; return 0; } }

        public string Marza { get => ""; }
        public void GetProduct(XNode properts)
        {
            XElement property = properts.Parent;
            switch (property.Name.ToString())
            {
                case nameof(id): { Id = int.Parse(property.Value); break; }
                case nameof(ilosc_wariantow): { Ilosc_wariantow = int.Parse(property.Value); break; }
                case nameof(zdjecia):
                    {
                        zdjecia = new();
                        foreach (XElement item in property.Descendants())
                        {
                            zdjecia.Add(item.Value);
                        }
                        break;
                    }
                case nameof(nazwa): { Nazwa = property.Value; break; }
                case nameof(dlugi_opis): { Dlugi_opis = property.Value; break; }
                case nameof(waga): { Waga = property.Value; break; }
                case nameof(kod): { Kod = property.Value; break; }
                case nameof(ean): { Ean = property.Value; break; }
                case nameof(status): { Status = int.Parse(property.Value); break; }
                case nameof(typ): { Typ = property.Value; break; }
                case nameof(cena_zewnetrzna_hurt): { Cena_zewnetrzna_hurt = property.Value; break; }
                case nameof(cena_zewnetrzna): { Cena_zewnetrzna = property.Value; break; }
                case nameof(vat): { Vat = property.Value; break; }
            }
        }
    }
}
