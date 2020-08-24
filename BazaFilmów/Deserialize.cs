using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace BazaFilmów
{
[Serializable]
        public class Film
        {
            public string Tytul { get; set; }
            public string Rezyser { get; set; }
            public string Gatunek { get; set; }
            public int Rok { get; set; }
            public int Cena { get; set; }
            public string Nosnik { get; set; }
            public int IloscKopii { get; set; }
            public int Wypozyczonych { get; set; }
            public int Dostepnosc { get; set; }

            public Film()
            {
            }

            public Film(string nTytul, string nRezyser, string nGatunek, int nRok, int nCena, string nNosnik, int nIloscKopii, int nWypozyczonych, int nDostepnosc)
            {
                Tytul = nTytul;
                Rezyser = nRezyser;
                Gatunek = nGatunek;
                Rok = nRok;
                Cena = nCena;
                Nosnik = nNosnik;
                IloscKopii = nIloscKopii;
                Wypozyczonych = nWypozyczonych;
                Dostepnosc = nDostepnosc;
            }
        }
    class Deserialize
    {
        public static List<Film> FilmList = new List<Film>();
public static void Deserializacja()
        {
            XmlRootAttribute oRootAttr = new XmlRootAttribute();
            oRootAttr.ElementName = "Film";
            oRootAttr.IsNullable = true;
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Film>), oRootAttr);
            TextReader reader = new StreamReader("BazaFilmow.xml");
            object obj = deserializer.Deserialize(reader);
            FilmList = (List<Film>)obj;
            reader.Close();

        }

        }
    }

