using System;
using System.IO;
using System.Xml.Serialization;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace С_sharp_lab2
{
    public partial class Form1 : Form
    {
        int c = 0;
        
        public List<string> NM = new List<string>();
        public List<string> data = new List<string>();
        public bool pereuch = false;
        public bool pRab = true;
        public bool rab = true;
        string fileName = "xml.xml";
        Thread thread;
        Thread threadPereuch;
        public Form1()
        {
            InitializeComponent();
            Data.storage.storage.Add(new Product("морозиво",30,5,15));
            Data.storage.storage.Add(new Product("кола",30,15,45));
            Data.storage.storage.Add(new Product("сухарики", 20, 12, 36));
            Data.storage.storage.Add(new Product("палочки", 15, 10, 30));
            Data.storage.storage.Add(new Product("йогурт", 30, 25, 75));
            Data.storage.storage.Add(new Product("пиво", 40, 30, 90));
            Data.storage.storage.Add(new Product("крекери", 14, 15, 45));
            Data.storage.storage.Add(new Product("хліб", 20, 10, 30));

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach(var p in Data.storage.storage)
            {
                NM.Add(p.NameProduct);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rand = new Random();

            CheckForIllegalCrossThreadCalls = false;

            threadPereuch = new Thread(() =>
            {
                
                pRab = true;
                while (pRab)
                {
                    if (pereuch == true)
                    {

                        data.Add("Переоблік: ");
                        textBox1.AppendText("Переоблік:" + Environment.NewLine);
                        foreach (var p in Data.storage.storage)
                        {
                            var b = 5;
                            p.QuantityInStock += b;

                            Data.storage.Cashbox -= p.Price *b;
                           
                            data.Add($"поповнено {p.NameProduct} на {b}, каса - {Data.storage.Cashbox}");
                            textBox1.AppendText($"поповнено {p.NameProduct} на {b}, kassa - {Data.storage.Cashbox}" + Environment.NewLine);
                            var xml = new XmlSerializer(data.GetType());
                            using (var file = new FileStream(fileName, FileMode.Open))
                            {
                                xml.Serialize(file, data);
                            }
                            
                            Thread.Sleep(1000);
                        }
                    pereuch = false;
                }

                }
            });

            thread = new Thread(()=> 
           {
               c = 1;
               rab = true;
               data.Add("Магазин відкрито");
               textBox1.AppendText("Магазин відкрито" + Environment.NewLine);

               while (rab)
               {
                    if (pereuch == false)
                    {
                        var pr = NM[rand.Next(0, NM.Count)];
                       int kol = rand.Next(1, 6);

                       foreach (var p in Data.storage.storage)
                       {
                           if (p.NameProduct == pr)
                           {
                               if (p.QuantityInStock > kol)
                               {
                                   Data.storage.Cashbox += p.PriceForPeople * kol;
                                   p.QuantityInStock -= kol;
                                   
                                   data.Add($"куплено - {pr}, кількість - {kol}, каса - {Data.storage.Cashbox}");
                                   textBox1.AppendText($"куплено - {pr}, кількість - {kol}, каса - {Data.storage.Cashbox}"+ Environment.NewLine);
                                   
                                   
                                   var xml = new XmlSerializer(data.GetType());
                                   using (var file = new FileStream(fileName,FileMode.OpenOrCreate) )
                                   {
                                       xml.Serialize(file, data);
                                   }
                                       Thread.Sleep(1000);
                               }
                               else
                               {
                                   pereuch = true;
                               }
                           }
                       }
                   }

               }
               
           } );

            if (c==0)
            {
                thread.Start();
                threadPereuch.Start();
            }
            else
            {
                MessageBox.Show("Магазин відкрито");
                

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            c = 0;
            rab = false;
            pRab = false;
            data.Add("Магазин закрито");
            textBox1.AppendText("Магазин закрито" + Environment.NewLine);
        }

        private void додатиТоварToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.ShowDialog();
            foreach (var p in Data.storage.storage)
            {
                NM.Add(p.NameProduct);
            }
        }
    }
}
