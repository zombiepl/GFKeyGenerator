using System.Collections.Generic;

namespace FGSaveToFile
{
    public interface IStorage
    {
        bool Save(List<string >StringToSave);
    }
}