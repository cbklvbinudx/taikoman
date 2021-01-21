using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace taikoman
{
    public partial class MainWindow : Window
    {
        static readonly string basetext = "[Events]" + "\n" +
                        "//Background and Video events" + "\n" +
                        "//Storyboard Layer 0 (Background)" + "\n" +
                        "//Storyboard Layer 1 (Fail)" + "\n" +
                        "//Storyboard Layer 2 (Pass)" + "\n" +
                        "//Storyboard Layer 3 (Foreground)" + "\n" +
                        "Sprite,Foreground,Centre,\"SB\\approachcircle.png\",0,0" + "\n" +
                        " M,0,0,,200,400" + "\n" +
                        " F,0,0,,0,1" + "\n" +
                        " S,0,0,,0.51" + "\n" +
                        " F,0,351327,,1,0" + "\n" +
                        "Sprite,Foreground,Centre,\"SB\\taikobigcircle.png\",0,0" + "\n" +
                        " M,0,0,,200,400" + "\n" +
                        " F,0,0,,0,1" + "\n" +
                        " S,0,0,,0.48" + "\n" +
                        " C,0,0,,211,211,211" + "\n" +
                        " F,0,351327,,1,0" + "\n" +
                        "Sprite,Foreground,Centre,\"SB\\approachcircle.png\",0,0" + "\n" +
                        " M,0,0,,280,400" + "\n" +
                        " F,0,0,,0,1" + "\n" +
                        " S,0,0,,0.51" + "\n" +
                        " F,0,351327,,1,0" + "\n" +
                        "Sprite,Foreground,Centre,\"SB\\taikobigcircle.png\",0,0" + "\n" +
                        " M,0,0,,280,400" + "\n" +
                        " F,0,0,,0,1" + "\n" +
                        " S,0,0,,0.48" + "\n" +
                        " C,0,0,,211,211,211" + "\n" +
                        " F,0,351327,,1,0" + "\n" +
                        "Sprite,Foreground,Centre,\"SB\\approachcircle.png\",0,0" + "\n" +
                        " M,0,0,,360,400" + "\n" +
                        " F,0,0,,0,1" + "\n" +
                        " S,0,0,,0.51" + "\n" +
                        " F,0,351327,,1,0" + "\n" +
                        "Sprite,Foreground,Centre,\"SB\\taikobigcircle.png\",0,0" + "\n" +
                        " M,0,0,,360,400" + "\n" +
                        " F,0,0,,0,1" + "\n" +
                        " S,0,0,,0.48" + "\n" +
                        " C,0,0,,211,211,211" + "\n" +
                        " F,0,351327,,1,0" + "\n" +
                        "Sprite,Foreground,Centre,\"SB\\approachcircle.png\",0,0" + "\n" +
                        " M,0,0,,440,400" + "\n" +
                        " F,0,0,,0,1" + "\n" +
                        " S,0,0,,0.51" + "\n" +
                        " F,0,351327,,1,0" + "\n" +
                        "Sprite,Foreground,Centre,\"SB\\taikobigcircle.png\",0,0" + "\n" +
                        " M,0,0,,440,400" + "\n" +
                        " F,0,0,,0,1" + "\n" +
                        " S,0,0,,0.48" + "\n" +
                        " C,0,0,,211,211,211" + "\n" +
                        " F,0,351327,,1,0" + "\n";

        string osufile;
        string osbfile;
        string resourcefolder;
        bool hitobjects = false;
        bool fileselected = false;
        bool scanned = false;
        bool filesadded = false;
        int loopcount;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            if (fileselected == true && hitobjects == false) // Only start generating when a file is selected and it hasn't been scanned yet
            {

                File.WriteAllText(osbfile, basetext);   // Write the lines for approach circles
                scanned = true;

                string[] readosufile = File.ReadAllLines(osufile);
                for (int i = 0; i < readosufile.Count(); i++)
                {
                    if (Equals(readosufile[i], "[HitObjects]"))
                    {
                        hitobjects = true;
                    }
                    else if (hitobjects)
                    {
                        string[] elements = readosufile[i].Split(',');

                        string timing = elements[2];
                        string colour = elements[4];
                        string spinner = elements[5];

                        int timingnotdone;
                        if (DTCheckBox.IsChecked == true)
                        {
                            timingnotdone = Int32.Parse(timing) - 1800;
                        }
                        else timingnotdone = Int32.Parse(timing) - 1200;
                        int timingdone = Int32.Parse(timing);

                        loopcount++;

                        string redright = "Sprite,Foreground,Centre,\"SB\\taikohitcircle.png\",0,197" + "\n" +
                                            " MX,0," + timingnotdone + "," + timingdone + ",360\n" +
                                            " MY,0," + timingnotdone + "," + timingdone + ",-640,400\n" +
                                            " F,0," + timingdone + ",,1,0\n" +
                                            " S,0," + timingdone + ",,0.456\n" +
                                            " C,0," + timingdone + ",,235,69,44\n" +
                                            "Sprite,Foreground,Centre,\"SB\\taikohitcircleoverlay.png\",0,197" + "\n" +
                                            " MX,0," + timingnotdone + "," + timingdone + ",360\n" +
                                            " MY,0," + timingnotdone + "," + timingdone + ",-640,400\n" +
                                            " F,0," + timingdone + ",,1,0\n" +
                                            " S,0," + timingdone + ",,0.456\n";

                        string redleft = "Sprite,Foreground,Centre,\"SB\\taikohitcircle.png\",0,197" + "\n" +
                                            " MX,0," + timingnotdone + "," + timingdone + ",280\n" +
                                            " MY,0," + timingnotdone + "," + timingdone + ",-640,400\n" +
                                            " F,0," + timingdone + ",,1,0\n" +
                                            " S,0," + timingdone + ",,0.456\n" +
                                            " C,0," + timingdone + ",,235,69,44\n" +
                                            "Sprite,Foreground,Centre,\"SB\\taikohitcircleoverlay.png\",0,197" + "\n" +
                                            " MX,0," + timingnotdone + "," + timingdone + ",280\n" +
                                            " MY,0," + timingnotdone + "," + timingdone + ",-640,400\n" +
                                            " F,0," + timingdone + ",,1,0\n" +
                                            " S,0," + timingdone + ",,0.456\n";

                        string blueright = "Sprite,Foreground,Centre,\"SB\\taikohitcircle.png\",0,197" + "\n" +
                                            " MX,0," + timingnotdone + "," + timingdone + ",200\n" +
                                            " MY,0," + timingnotdone + "," + timingdone + ",-640,400\n" +
                                            " F,0," + timingdone + ",,1,0\n" +
                                            " S,0," + timingdone + ",,0.456\n" +
                                            " C,0," + timingdone + ",,67,142,172\n" +
                                            "Sprite,Foreground,Centre,\"SB\\taikohitcircleoverlay.png\",0,197" + "\n" +
                                            " MX,0," + timingnotdone + "," + timingdone + ",200\n" +
                                            " MY,0," + timingnotdone + "," + timingdone + ",-640,400\n" +
                                            " F,0," + timingdone + ",,1,0\n" +
                                            " S,0," + timingdone + ",,0.456\n";

                        string blueleft = "Sprite,Foreground,Centre,\"SB\\taikohitcircle.png\",0,197" + "\n" +
                                            " MX,0," + timingnotdone + "," + timingdone + ",440\n" +
                                            " MY,0," + timingnotdone + "," + timingdone + ",-640,400\n" +
                                            " F,0," + timingdone + ",,1,0\n" +
                                            " S,0," + timingdone + ",,0.456\n" +
                                            " C,0," + timingdone + ",,67,142,172\n" +
                                            "Sprite,Foreground,Centre,\"SB\\taikohitcircleoverlay.png\",0,197" + "\n" +
                                            " MX,0," + timingnotdone + "," + timingdone + ",440\n" +
                                            " MY,0," + timingnotdone + "," + timingdone + ",-640,400\n" +
                                            " F,0," + timingdone + ",,1,0\n" +
                                            " S,0," + timingdone + ",,0.456\n";

                        if (spinner[0] != 48)
                        { // if the hitobject is a spinner stay in place
                            loopcount--;
                        }
                        else if (colour == "12" || colour == "6") 
                        {
                            File.AppendAllText(osbfile, blueright + blueleft); // big blue hitobject
                        }
                        else if (colour == "4")
                        {
                            File.AppendAllText(osbfile, redright + redleft); // big red hitobject
                        }
                        else if (loopcount % 2 == 0)    // check if the hitobject should be drawn on the right side or the left side, making it alternate
                        { 
                            if (colour == "8" || colour == "2") 
                            {
                                File.AppendAllText(osbfile, blueright);
                            }
                            else if (colour == "0")
                            {
                                File.AppendAllText(osbfile, redright);
                            }
                        }
                        else if (loopcount % 2 != 0)
                        {
                            if (colour == "8" || colour == "2")
                            {
                                File.AppendAllText(osbfile, blueleft);

                            }
                            else if (colour == "0") 
                            {
                                File.AppendAllText(osbfile, redleft);
                            }
                        }
                    }
                }
            }
            else if (fileselected == false)
            {
                MessageBox.Show("You need to select a .osu file to read first!");
            }
            else if (hitobjects)
            {
                MessageBox.Show("Already generated a storyboard for this map.");
            }

            if (scanned && !filesadded)
            {
                File.AppendAllText(osbfile, "//Storyboard Sound Samples"); // This line is required for the storyboard to work
                if (!Directory.Exists(resourcefolder))
                {
                    Directory.CreateDirectory(resourcefolder);
                }
                File.Copy(@"Resources\approachcircle.png", resourcefolder + "approachcircle.png", true);
                File.Copy(@"Resources\taikobigcircle.png", resourcefolder + "taikobigcircle.png", true);
                File.Copy(@"Resources\taikohitcircle.png", resourcefolder + "taikohitcircle.png", true);
                File.Copy(@"Resources\taikohitcircleoverlay.png", resourcefolder + "taikohitcircleoverlay.png", true);

                MessageBox.Show("Success!");

                filesadded = true;
            }
        }

        private void FileSelector_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == true)
            {
                if (!ofd.FileName.EndsWith(".osu"))
                {
                    MessageBox.Show("File needs to have a .osu extension.");
                }
                else
                {
                    FunnyText.Text = "Currently selected map: " + ofd.FileName.Substring(ofd.FileName.LastIndexOf('\\') + 1);
                    fileselected = true;
                    hitobjects = false;
                    scanned = false;
                    filesadded = false;
                    osufile = ofd.FileName; // Path to the .osu file to read
                    osbfile = ofd.FileName.Remove(ofd.FileName.LastIndexOf('[') - 1) + ".osb";  // Path to the .osb file to write
                    resourcefolder = ofd.FileName.Remove(ofd.FileName.LastIndexOf('\\')) + "\\SB\\";
                }
            }
        }
    }
}
