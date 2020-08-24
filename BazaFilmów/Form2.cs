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
using System.Text.RegularExpressions;

namespace BazaFilmów
{
    public partial class Terminy : Form
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
 public class Termin
 {
     public string KtoWypozycza { get; set; }
     public string Tytul { get; set; }
     public string Wypozyczono { get; set; }
     public string Zwrot { get; set; }
     public int Ilosc { get; set; }
     
     public Termin()
     {
     }
     public Termin(string nKtoWypozycza, string nTytul, string nWypozyczono, string nZwrot, int nIlosc)
     {
         KtoWypozycza = nKtoWypozycza;
         Tytul = nTytul;
         Wypozyczono = nWypozyczono;
         Zwrot = nZwrot;
         Ilosc = nIlosc;
     }
 }
        public Terminy()
        {
            InitializeComponent();
            TerminDeserializacja();
            dataGridView1.DataSource = TerminList;

        }
        
List<Film> FilmList = new List<Film>();
List<Termin> TerminList = new List<Termin>();
public void Deserializacja()
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
public void Serializacja()
        {
            XmlRootAttribute oRootAttr = new XmlRootAttribute();
            oRootAttr.ElementName = "Film";
            oRootAttr.IsNullable = true;
            XmlSerializer oSerializer = new XmlSerializer(typeof(List<Film>), oRootAttr);
            StreamWriter oStreamWriter = null;
            oStreamWriter = new StreamWriter("BazaFilmow.xml");
            oSerializer.Serialize(oStreamWriter, FilmList);
            oStreamWriter.Dispose();
        }
 public void TerminDeserializacja()
        {
            XmlRootAttribute oRootAttr = new XmlRootAttribute();
            oRootAttr.ElementName = "Termin";
            oRootAttr.IsNullable = true;
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Termin>), oRootAttr);
            TextReader reader = new StreamReader("Terminy.xml");
            object obj = deserializer.Deserialize(reader);
            TerminList = (List<Termin>)obj;
            reader.Close();

        }
 public void TerminSerializacja()
        {
            XmlRootAttribute oRootAttr = new XmlRootAttribute();
            oRootAttr.ElementName = "Termin";
            oRootAttr.IsNullable = true;
            XmlSerializer oSerializer = new XmlSerializer(typeof(List<Termin>), oRootAttr);
            StreamWriter oStreamWriter = null;
            oStreamWriter = new StreamWriter("Terminy.xml");
            oSerializer.Serialize(oStreamWriter, TerminList);
            oStreamWriter.Dispose();
        }

 private void buttonZwrot_Click(object sender, EventArgs e)
 {
     int ile ;
     ile = 0;
     ile = Convert.ToInt32(textBoxIle.Text);
     TerminDeserializacja();
     int x = TerminList.Count;
     //labelCount.Text = x.ToString();
     //FilmList.RemoveAt(2);
     //string y = dataGridView1.SelectedRows.Count.ToString();
     int i = dataGridView1.CurrentCell.RowIndex;
     dataContainer.index = dataGridView1.CurrentCell.RowIndex;
     //int a = dataContainer.index;
     if (ile >= TerminList[i].Ilosc || ile == 0)
     { 
     
     
     Deserializacja();

     string name = TerminList[i].Tytul;
     int filmIndex = FilmList.FindIndex(item => item.Tytul==name);
     label1.Text = filmIndex.ToString();
         Film films = FilmList[filmIndex];
         films.Dostepnosc = FilmList[filmIndex].Dostepnosc + TerminList[i].Ilosc;
         films.Wypozyczonych = FilmList[filmIndex].Wypozyczonych - TerminList[i].Ilosc;
         FilmList[filmIndex] = films;
         Serializacja();
         
             TerminList.RemoveAt(i);
             TerminSerializacja();
             dataGridView1.DataSource = TerminList;
     }
     else
     {
         Deserializacja();

         string name = TerminList[i].Tytul;
         int filmIndex = FilmList.FindIndex(item => item.Tytul == name);
         label1.Text = filmIndex.ToString();
         Film films = FilmList[filmIndex];
         films.Dostepnosc = FilmList[filmIndex].Dostepnosc + ile;
         films.Wypozyczonych = FilmList[filmIndex].Wypozyczonych - ile;
         FilmList[filmIndex] = films;
         Serializacja();

         TerminList[i].Ilosc = (TerminList[i].Ilosc - ile);
         TerminSerializacja();
         dataGridView1.DataSource = TerminList;
     }
 }
    }
}
