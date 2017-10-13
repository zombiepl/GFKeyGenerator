using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace FGSaveToFile
{
    public class Storage : IStorage
    {
        private SaveFileDialog _save;
        
        public bool Save(List<string> dataList)
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
                MessageBox.Show("Zjebało się: " + e.Message);
                throw;
            }
        }
    }
}