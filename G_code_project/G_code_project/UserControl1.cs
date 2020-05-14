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
        
        bool firstLineValid = true;

        public string g91_90(string g91_in)
        {
            G_code_out.Text = "Working on that for you...";
            firstLineValid = true;
            string[] separated_lines = g91_in.Split('\n');                                                              // convert input to 1d array of each line 
            float[,] coords_g91 = to_coord_arr(separated_lines);                                                        // convert values to floats
            float[,] coords_g90 = coords_g91;
            coords_g90 = to_coord_g90(coords_g91);
            string g90_out = to_pretty_string(coords_g91);                                                              // convert back to string and add labels

            if (firstLineValid == false)                                                                                // check that the first line has valid values
            {
                return "Please check that the first line inlcudes values for all axes and try again";
            }
            else
            {
                return g90_out;                                                                                         // return the final output
            }

            float[,] to_coord_arr(string[] text_in)
            {
                int i = 0;
                float[,] coords = new float[separated_lines.Length, 3];                                                 // makes 2d array, [line, xyz]
                foreach (string s in text_in)
                {
                    int j = 0;
                    foreach (char c in "xyz")
                    {
                        string pattern = $@"\b{c}\d+\b";                                                                // looks for digit directly after 'x' or 'y' or 'z'
                        Regex rx = new Regex(pattern,
                        RegexOptions.Compiled | RegexOptions.IgnoreCase);
                        if (string.IsNullOrEmpty(rx.Match(text_in[i]).Value))
                        {
                            if (i > 0)                                                                                  // if no match then keep the previous axis value
                            {
                                coords[i, j] = coords[i - 1, j];

                            }
                            else                                                                                        // if no match in the first line then there is a problem
                            {
                                firstLineValid = false;
                            }
                        }
                        else
                        {
                            coords[i, j] = float.Parse(rx.Match(text_in[i]).Value.Remove(0, 1));                        // sets current coords = the match it found, removing the 'x' or 'y' or 'z'
                        }
                        j++;
                    }
                    i++;
                }
                return coords;
            }
            float[,] to_coord_g90(float[,] coords_in)
            {
                coords_g90[0, 0] = coords_in[0, 0];                                
                coords_g90[0, 1] = coords_in[0, 1];                                     
                coords_g90[0, 2] = coords_in[0, 1];                                      
                for (int i = 1; i < separated_lines.Length; i++)
                {
                    coords_g90[i, 0] = coords_in[i, 0] + coords_in[i - 1, 0];                                       // converts x coordinate
                    coords_g90[i, 1] = coords_in[i, 1] + coords_in[i - 1, 1];                                       // converts y coordinate
                    coords_g90[i, 2] = coords_in[i, 2] + coords_in[i - 1, 2];                                       // converts z coordinate
                }
                //coords_g90[separated_lines.Length - 1, 0] = coords_g90[separated_lines.Length - 2, 0];                  // last line is a copy of previous line...
                //coords_g90[separated_lines.Length - 1, 1] = coords_g90[separated_lines.Length - 2, 1];                  // need to change but can't just delete a line from an array
                //coords_g90[separated_lines.Length - 1, 2] = coords_g90[separated_lines.Length - 2, 2];                  // 
                return coords_g90;
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

        public string g90_91(string g90_in)
            {
                G_code_out.Text = "Working on that for you...";
                firstLineValid = true;
                string[] separated_lines = g90_in.Split('\n');                                                              // convert input to 1d array of each line 
                float[,] coords_g90 = to_coord_arr(separated_lines);                                                        // convert values to floats
                float[,] coords_g91 = coords_g90;                                                                           // create output array copied from input for now
                coords_g91 = to_coord_g91(coords_g90);                                                                      // convert the g90 values to g91
                string g91_out = to_pretty_string(coords_g91);                                                              // convert back to string and add labels
                if (firstLineValid == false)                                                                                // check that the first line has valid values
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
                    float[,] coords = new float[separated_lines.Length, 3];                                                 // makes 2d array, [line, xyz]
                    foreach (string s in text_in)
                    {
                        int j = 0;
                        foreach (char c in "xyz")   
                        {
                            string pattern = $@"\b{c}\d+\b";                                                                // looks for digit directly after 'x' or 'y' or 'z'
                            Regex rx = new Regex(pattern,
                            RegexOptions.Compiled | RegexOptions.IgnoreCase);
                            if (string.IsNullOrEmpty(rx.Match(text_in[i]).Value))
                            {
                                if (i > 0)                                                                                  // if no match then keep the previous axis value
                                {
                                    coords[i, j] = coords[i - 1, j];
                                    
                                }
                                else                                                                                        // if no match in the first line then there is a problem
                                {
                                    firstLineValid = false;
                                }
                            }
                            else
                            {
                                coords[i, j] = float.Parse(rx.Match(text_in[i]).Value.Remove(0, 1));                        // sets current coords = the match it found, removing the 'x' or 'y' or 'z'
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

            private void Convert_to_g91_button_click(object sender, EventArgs e)                                                   // "convert to g91" button runs method 
            {
                G_code_out.Text = g90_91(G_code_in.Text);                                                                   // method for converting G code
            }

            private void Convert_to_g90_button_Click(object sender, EventArgs e)
            {
                G_code_in.Text = g91_90(G_code_out.Text);
            }

            private void Help_button_Click(object sender, EventArgs e)                                                      // display the help message in output box
            {
                G_code_out.Text = "This is a tool to convert G code from global coordinates to relative coordinates (and more later on).  \n\nInput your current global coordinates in the left box and click the 'Convert' button to output the converted code in the right box.  \n\nMake sure that at least the first line of global coordinates includes values for X, Y, and Z.";
            }


    }
    }  


