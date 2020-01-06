using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace G_code_project
{

    public partial class UserControl1 : UserControl
    {
        
        static void Main()
        {
        }
        public UserControl1()
            {
                InitializeComponent();
            }

            public string g90_91(string g90_in)
            {
                G_code_out.Text = "Working on that for you...";
                string[] separated_lines = g90_in.Split('\n');                                                              // convert input to single array 
                float[,] coords_g90 = to_coord_arr(separated_lines);                                                        // convert values to floats
                float[,] coords_g91 = coords_g90;                                                                           // create output array copied from input for now
                coords_g91 = to_coord_g91(coords_g90);                                                                      // convert the g90 values to g91
                string g91_out = to_pretty_string(coords_g91);                                                              // convert back to string and add labels
                if (G_code_out.Text == "Please check that the first line inlcudes values for all axes and try again")       // check that the first line has valid values
                {
                    return "Please check that the first line inlcudes values for all axes and try again";
                }
                else
                {
                    return g91_out;                                                                                         // return the final output
                }

                float[,] to_coord_arr(string[] text_in)
                {
                    int i = 0;
                    float[,] coords = new float[separated_lines.Length, 3];
                    foreach (string s in text_in)
                    {
                        string axis = "xyz";                                                                                // Search for XYZ 1 at a time and output 
                        int j = 0;
                        foreach (char c in axis)
                        {
                            string pattern = $@"\b{c}\d+\b";
                            Regex rx = new Regex(pattern,
                            RegexOptions.Compiled | RegexOptions.IgnoreCase);
                            if (string.IsNullOrEmpty(rx.Match(text_in[i]).Value))
                            {
                                if (i > 0)
                                {
                                    coords[i, j] = coords[i - 1, j];
                                }
                                else
                                {
                                    G_code_out.Text = "Please check that the first line inlcudes values for all axes and try again";
                                }
                            }
                            else
                            {
                                coords[i, j] = float.Parse(rx.Match(text_in[i]).Value.Remove(0, 1));
                            }
                            j++;
                        }
                        i++;
                    }
                    return coords;
                }

                float[,] to_coord_g91(float[,] coords_in)
                {
                    for (int i = 1; i < separated_lines.Length; i++)
                    {
                        coords_g91[i - 1, 0] = coords_in[i, 0] - coords_in[i - 1, 0];                                       // converts x coordinate
                        coords_g91[i - 1, 1] = coords_in[i, 1] - coords_in[i - 1, 1];                                       // converts y coordinate
                        coords_g91[i - 1, 2] = coords_in[i, 2] - coords_in[i - 1, 2];                                       // converts z coordinate
                    }
                    coords_g91[separated_lines.Length - 1, 0] = coords_g91[separated_lines.Length - 2, 0];                  // last line is a copy of previous line...
                    coords_g91[separated_lines.Length - 1, 1] = coords_g91[separated_lines.Length - 2, 1];                  // need to change but can't just delete a line from an array
                    coords_g91[separated_lines.Length - 1, 2] = coords_g91[separated_lines.Length - 2, 2];                  // 
                    return coords_g91;
                }

                string to_pretty_string(float[,] coords_in)                                                                 // add labels to output coordinates and convert to string
                {
                    string pretty_out_arr = "";
                    for (int i = 0; i < separated_lines.Length - 1; i++)                                                      // outputs all but the last line 
                    {
                        pretty_out_arr += $"N{1000 + i * 5}    X{coords_in[i, 0]}    Y{coords_in[i, 1]}    Z{coords_in[i, 2]}\n";
                    }
                    return pretty_out_arr;
                }
            }

            private void Convert_button_Click(object sender, EventArgs e)                                                   // "convert" button runs method 
            {
                G_code_out.Text = g90_91(G_code_in.Text);                                                                   // method for converting G code
            }

            private void Help_button_Click(object sender, EventArgs e)                                                      // display the help message in output box
            {
                G_code_out.Text = "This is a tool to convert G code from global coordinates to relative coordinates (and more later on).  \n\nInput your current global coordinates in the left box and click the 'Convert' button to output the converted code in the right box.  \n\nMake sure that at least the first line of global coordinates includes values for X, Y, and Z.";
            }
        }
    }  


