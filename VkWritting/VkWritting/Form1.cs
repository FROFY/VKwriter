using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using xNet;

namespace VkWritting
{
    public partial class Form1 : Form
    {
        public bool check = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            while (check)
            {
                var request = new HttpRequest();
                string response = request.Get("https://api.vk.com/method/messages.searchConversations?q=" + " " + "&count=" + textBox2.Text + "&extended=1" + "&access_token=" + textBox1.Text + "&v=5.122").ToString();
                request.Close();
                richTextBox1.Clear();
                Root root;
                root = JsonConvert.DeserializeObject<Root>(response);
                for (int i = 0; i < root.response.count; i++)
                {
                    richTextBox1.Text += root.response.items[i].peer.id.ToString() + '\n';
                    if (root.response.items[i].peer.id < 0)
                        root.response.items[i].peer.id = Math.Abs(root.response.items[i].peer.id);
                    Send(root.response.items[i].peer.id, root.response.profiles[i].first_name, root.response.profiles[i].last_name);
                }
            };
        }

        public void Send(int id, string fname, string lname)
        {
            var request = new HttpRequest();
            string response = request.Get("https://api.vk.com/method/messages.setActivity?user_id=" + id + "&type=audiomessage" + "&access_token=" + textBox1.Text + "&v=5.122").ToString();
            request.Close();
            richTextBox2.Text += "Пользователю " + fname + " " + lname + " записывается голосовое сообщение..." + '\n' + response;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            check = false;
        }
    }
}
