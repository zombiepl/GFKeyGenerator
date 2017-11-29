using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;

namespace FGSaveToFile
{
    public class Storage : IStorage
    {
        private static SaveFileDialog _save;
        
        public static bool Save(List<string> dataList)
        {
            try
            {
                _save = new SaveFileDialog();
                if (_save.ShowDialog() == DialogResult.OK)
                {

                    using (StreamWriter writer = new StreamWriter(_save.OpenFile()))
                    {
                        foreach (var item in dataList)
                        {
                            writer.WriteLine(item);
                        }
                        writer.Close();
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Something is wrong " + e.Message);
                throw;
            }
            
        }
        
    }
}