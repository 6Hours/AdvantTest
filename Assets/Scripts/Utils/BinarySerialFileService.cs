using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace MyCore.Utils
{
    public abstract class BinarySerialFileService : MonoBehaviour
    {
        public static void SaveInFile(object obj, string name)
        {
            var path = Application.persistentDataPath + '/' + name + ".dat";

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file;
            file = File.Create(path);
            bf.Serialize(file, obj);
            file.Close();
            Debug.Log("Save " + (obj.GetType().ToString()));
        }

        public static T LoadFromFile<T>(ref T obj, string name)
        {
            var path = Application.persistentDataPath + '/' + name + ".dat";

            if (File.Exists(path))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(path, FileMode.Open);
                obj = (T)bf.Deserialize(file);
                file.Close();
                Debug.Log("Load " + (obj.GetType().ToString()));
                return obj;
            }
            return default(T);
        }
    }
}
