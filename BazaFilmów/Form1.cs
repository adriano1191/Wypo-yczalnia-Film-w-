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
    public partial class Form1 : Form
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
        public Form1()
        {
            InitializeComponent();
            dataGridView1.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(dataGridView1_ColumnHeaderMouseClick);
           

            if (File.Exists("BazaFilmow.xml"))
            {
                Deserializacja();
                Formatowanie();

            }
            else
            {
                Serializacja();
            }
        }
        public DataGridView Dgv { get; set; }
        List<Film> FilmList = new List<Film>();
        
        public void Formatowanie()
        {
            //szerokosc kolumn
            dataGridView1.DataSource = FilmList;
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 80;
            dataGridView1.Columns[3].Width = 50;
            dataGridView1.Columns[4].Width = 60;
            dataGridView1.Columns[5].Width = 50;
            dataGridView1.Columns[6].Width = 60;
            dataGridView1.Columns[7].Width = 90;
            dataGridView1.Columns[8].Width = 70;
            //Format cenowy
            dataGridView1.Columns[4].DefaultCellStyle.Format = "c";

            //Wyrównanie do prawej oraz Wysrodkowanie naglowkow
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            //Wyrownanie do srodka kolumny Nosnik
            this.dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }
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
        public int i;





        private void buttonDodaj_Click(object sender, EventArgs e)
        {
            buttonActive.active = false;
            FormFilm newForm = new FormFilm();
            newForm.Show();

        }

        private void buttonZamknij_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Czy na pewno chcesz zamknąć program?", "Ostrzeżenie", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
            
        }
        
        public void buttonEdutuj_Click(object sender, EventArgs e)
        {
            dataContainer.index = dataGridView1.CurrentCell.RowIndex;
            int i = dataContainer.index;
            labelCount.Text = dataContainer.index.ToString();
            //licznik.liczba = FilmList[i].Wypozyczonych;
            buttonActive.active = true;
            FormFilm newForm = new FormFilm();
            newForm.Show();

        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            Deserializacja();

            dataGridView1.DataSource = FilmList;

            
        }




        //Sortowanie
        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);
            string columnIndex = dataGridView1.Columns[e.ColumnIndex].Name;
            //string columnName = dataGridView1.Columns[columnIndex].Name;
            textBoxSzukaj.Text = columnIndex;
            Deserializacja();
            if(columnIndex == "Tytul")
            {
                FilmList = FilmList.OrderBy(item => item.Tytul).ToList();
                Serializacja();
                dataGridView1.DataSource = FilmList;
            }
            if (columnIndex == "Rezyser")
            {
                FilmList = FilmList.OrderBy(item => item.Rezyser).ToList();
                Serializacja();
                dataGridView1.DataSource = FilmList;
            }
            if (columnIndex == "Gatunek")
            {
                FilmList = FilmList.OrderBy(item => item.Gatunek).ToList();
                Serializacja();
                dataGridView1.DataSource = FilmList;
            }
            if (columnIndex == "Rok")
            {
                FilmList = FilmList.OrderBy(item => item.Rok).ToList();
                Serializacja();
                dataGridView1.DataSource = FilmList;
            }
            if (columnIndex == "Cena")
            {
                FilmList = FilmList.OrderBy(item => item.Cena).ToList();
                Serializacja();
                dataGridView1.DataSource = FilmList;
            }
            if (columnIndex == "Nosnik")
            {
                FilmList = FilmList.OrderBy(item => item.Nosnik).ToList();
                Serializacja();
                dataGridView1.DataSource = FilmList;
            }
            if (columnIndex == "IloscKopii")
            {
                FilmList = FilmList.OrderBy(item => item.IloscKopii).ToList();
                Serializacja();
                dataGridView1.DataSource = FilmList;
            } if (columnIndex == "Wypozyczonych")
            {
                FilmList = FilmList.OrderBy(item => item.Wypozyczonych).ToList();
                Serializacja();
                dataGridView1.DataSource = FilmList;
            } if (columnIndex == "Dostepnosc")
            {
                FilmList = FilmList.OrderBy(item => item.Dostepnosc).ToList();
                Serializacja();
                dataGridView1.DataSource = FilmList;
            }

            



        }

        private void buttonUsun_Click(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentCell.RowIndex;
            //int i = dataContainer.index;
            labelCount.Text = i.ToString();
            if (MessageBox.Show("Czy na pewno chcesz usunąć zaznaczony obszar?", "Ostrzeżenie", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

           int x = FilmList.Count;
            //labelCount.Text = x.ToString();
            //FilmList.RemoveAt(2);
            //string y = dataGridView1.SelectedRows.Count.ToString();
           //int i = dataGridView1.CurrentCell.RowIndex;
            //int i = dataContainer.index;
           labelCount.Text = i.ToString();
           FilmList.RemoveAt(i);
            Serializacja();
            Deserializacja();
            dataGridView1.DataSource = FilmList;
            }
        }

        private void buttonSzukaj_Click(object sender, EventArgs e)
        {
            Deserializacja();
            List<Film> findFilm = new List<Film>();
            List<string> tmpFilm = new List<string>();
            string input = textBoxSzukaj.Text.Trim();
            //int intRok;
            //intRok= Convert.ToInt32(input);
           //findFilm = FilmList.FindAll(item => item.Tytul.Contains(input));
            //Ignorowanie wielkich Liter
            //findFilm = FilmList.FindAll(item => item.Tytul.IndexOf(input, StringComparison.OrdinalIgnoreCase) >= 0);
            tmpFilm = FilmList.ConvertAll(x => x.ToString());
            findFilm.AddRange(FilmList.FindAll(item => item.Tytul.IndexOf(input, StringComparison.OrdinalIgnoreCase) >= 0));
            findFilm.AddRange(FilmList.FindAll(item => item.Rezyser.IndexOf(input, StringComparison.OrdinalIgnoreCase) >= 0));
            findFilm.AddRange(FilmList.FindAll(item => item.Gatunek.IndexOf(input, StringComparison.OrdinalIgnoreCase) >= 0));

            findFilm = findFilm.Distinct().ToList();
            dataGridView1.DataSource = findFilm;
        }

        private void bazaAktorówToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BazaAktorow2 newForm = new BazaAktorow2();
            newForm.Show();
        }

        private void nowyAktorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonActive.active = false;
            FormAktor newFormAktor = new FormAktor();
            newFormAktor.Show();
            
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataContainer.index = dataGridView1.CurrentCell.RowIndex;
            int i = dataContainer.index;
            labelCount.Text = dataContainer.index.ToString();
            licznik.liczba = FilmList[i].Wypozyczonych;
            FormFilmView newFormFilmView = new FormFilmView();
            newFormFilmView.Show();
        }

        private void szukajToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Szukaj newFormFilmView = new Szukaj();
            newFormFilmView.Show();
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Terminy newFormFilmView = new Terminy();
            newFormFilmView.Show();
        }

        private void raportBazyFilmowejToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Raport_Bazy_Filmowej newFormFilmView = new Raport_Bazy_Filmowej();
            newFormFilmView.Show();
        }

        
    }
}
