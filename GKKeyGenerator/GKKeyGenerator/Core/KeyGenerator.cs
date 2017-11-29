using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using GKKeyGenerator.Interfaces.Core;
using GKKeyGenerator.Interfaces.Models;
using GKKeyGenerator.Models;
//using System.Runtime.Serialization.Formatters.Binary.BinaryFormatter;

namespace GKKeyGenerator.Core
{
    public class KeyGenerator : IKeyGenerator
    {
        public string NIP { get; set; }
        public string Product { get; set; }
        public string ProductModule { get; set; }
        public int NumberOfModule { get; set; }
        public DateTime ValidDate { get; set; }
        public string MagicWord { get; set; }//klucz przekazywany do pliku 
        
        
        public string GenerateKey(string companyNIP, CustomerModules customerModules)
        {
            MagicWord = "";

            foreach (var list in customerModules.ProductList)
            {
                MagicWord = list.Key.Name.Trim()+";";
                foreach (var modules in list.Value)
                {
                    MagicWord += modules.Name.Trim()+";";
                }
                
            }
            MagicWord += companyNIP.Trim();
            //Debug.WriteLine(MagicWord);
            return MagicWord;
        }
    }
}