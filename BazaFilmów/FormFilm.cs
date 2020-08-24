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
using System.Diagnostics;



namespace BazaFilmów
{
    public partial class FormFilm : Form
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
        public FormFilm()
        {
            InitializeComponent();
            Deserializacja();
            if (buttonActive.active == true) { 
            int i = dataContainer.index;
            label1.Text = i.ToString();
            textBoxTytul.Text = FilmList[i].Tytul;
            textBoxRezyser.Text = FilmList[i].Rezyser;
            textBoxGatunek.Text = FilmList[i].Gatunek;
            textBoxRok.Text = Convert.ToString(FilmList[i].Rok);
            textBoxCena.Text = Convert.ToString(FilmList[i].Cena);
            this.comboBoxNosnik.SelectedItem = FilmList[i].Nosnik;
            textBoxIloscKopii.Text = Convert.ToString(FilmList[i].IloscKopii);

            buttonZapisz.Visible = buttonActive.active;

            if (File.Exists(@"Image/Films/" + FilmList[i].Tytul + ".bmp"))
            {

                string imagePatch = @"Image/Films/" + FilmList[i].Tytul + ".bmp";
                FileStream bitmapFile = new FileStream(imagePatch, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                Image image = new Bitmap(bitmapFile);
               int width = image.Width;
               int height = image.Height;
                pictureBox1.Image = image;
                bitmapFile.Close();
               
                
            }
            else
            {
                pictureBox1.Image = Image.FromFile(@"Image/Films/Brak.bmp");
            }
            }
        }
        public bool test = false;
        List<Film> FilmList = new List<Film>();
        private void FormFilm_Load(object sender, EventArgs e)
        {

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


        private void buttonZamknij_Click(object sender, EventArgs e)
        {


            if (MessageBox.Show("Czy na pewno chcesz zamknąć okno?", "Ostrzeżenie", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                this.Close();
            }
        }

        private void buttonDodaj_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrWhiteSpace(textBoxTytul.Text)) || (string.IsNullOrWhiteSpace(textBoxRezyser.Text)) || (string.IsNullOrWhiteSpace(textBoxGatunek.Text)))
            {
                MessageBox.Show("Uzupełnij wszystkie dane");
                return;
            }
            else{
            int parsedValue;
            if ((!int.TryParse(textBoxRok.Text, out parsedValue)) || (!int.TryParse(textBoxCena.Text, out parsedValue)) || (!int.TryParse(textBoxIloscKopii.Text, out parsedValue)))
            {
                MessageBox.Show("W polach Cena, Rok, Ilosc Kopii muszą znajdować się liczby");
                return;
            }
            else
            {

            
            Deserializacja();
            int i = dataContainer.index;
            FilmList.Add(new Film(textBoxTytul.Text,
                textBoxRezyser.Text,
                textBoxGatunek.Text,
                Convert.ToInt32(textBoxRok.Text),
                Convert.ToInt32(textBoxCena.Text),
                this.comboBoxNosnik.GetItemText(this.comboBoxNosnik.SelectedItem),
                Convert.ToInt32(textBoxIloscKopii.Text),
                0,
                Convert.ToInt32(textBoxIloscKopii.Text)));
            Serializacja();
            string sourceDir = label1.Text;
            string backupDir = @"Image/Films/";
            string name = textBoxTytul.Text  + ".bmp";

            if (label1.Text != "label1") { 
            File.Copy(sourceDir, backupDir + name, true);
            
            }
            this.Close();
            }
            }

        }

        private void buttonNosnikAdd_Click(object sender, EventArgs e)
        {

            //buttonZapisz.Visible = true;


        }

        private void buttonZapisz_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrWhiteSpace(textBoxTytul.Text)) || (string.IsNullOrWhiteSpace(textBoxRezyser.Text)) || (string.IsNullOrWhiteSpace(textBoxGatunek.Text)))
            {
                MessageBox.Show("Uzupełnij wszystkie dane");
                return;
            }
            else{
            int parsedValue;
            if ((!int.TryParse(textBoxRok.Text, out parsedValue)) || (!int.TryParse(textBoxCena.Text, out parsedValue)) || (!int.TryParse(textBoxIloscKopii.Text, out parsedValue)))
            {
                MessageBox.Show("W polach Cena, Rok, Ilosc Kopii muszą znajdować się liczby");
                return;
            }
            else
            {

            if (MessageBox.Show("Czy na pewno chcesz Zapisać zmiany?", "Zapis", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Deserializacja();
                int i = dataContainer.index;
                if (test == false)
                {
                    System.IO.File.Move(@"Image/Films/" + FilmList[i].Tytul + ".bmp", @"Image/Films/" + textBoxTytul.Text + ".bmp");
                }

                FilmList[i] = (new Film(textBoxTytul.Text,
                    textBoxRezyser.Text,
                    textBoxGatunek.Text,
                    Convert.ToInt32(textBoxRok.Text),
                    Convert.ToInt32(textBoxCena.Text),
                    this.comboBoxNosnik.GetItemText(this.comboBoxNosnik.SelectedItem),
                    Convert.ToInt32(textBoxIloscKopii.Text),
                    licznik.liczba,
                    100));
             
                string sourceDir = label1.Text;
                string backupDir = @"Image/Films/";
                string name = textBoxTytul.Text + ".bmp";

                if (test == true)
                {
                File.Copy(sourceDir, backupDir + name, true);
                }
               
                Serializacja();
                this.Close();
            }
            }
            }
        }

        
        private void buttonDodajZdjecie_Click(object sender, EventArgs e)
        {
            test = true;
OpenFileDialog fdlog = new OpenFileDialog();
fdlog.Filter = "jpg files (*.jpg)|*.jpg";
fdlog.FilterIndex = 1;
fdlog.Multiselect = true;

if (fdlog.ShowDialog() == DialogResult.OK)
{
    string sFileName = fdlog.FileName;
    label1.Text = sFileName;
    pictureBox1.Image = Image.FromFile(sFileName);
    
    //pictureBox1.c
}

            //OpenFileDialog opf = new OpenFileDialog();
            //opf.ShowDialog();
            
            /*Stream myStream = null;
            
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            // Insert code to read the stream here.
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }*/
        }


    }
}

