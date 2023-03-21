using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class CacheBuffer
    {

        //存储文件列表的字符串
        public string fileList;
        //用于同步访问文件列表的锁对象
        public readonly object fileListLock = new object();
        //存储文件目录的哈希表
        public static readonly Hashtable fileContents = new Hashtable();
        //用于同步访问文件内容的锁对象
        public readonly object fileContentsLock = new object();

        //获取文件列表
        public string GetFileList()
        {
            lock (fileListLock)
            {
                return fileList;
            }
        }

        //设置文件列表
        public void SetFileList(string fileList)
        {
            lock (fileListLock)
            {
                this.fileList = fileList;
            }
        }

        //获取文件内容
        public byte[] GetFileContent(string fileName)
        {
            lock (fileContentsLock)
            {
                return (byte[])fileContents[fileName];
            }
        }

        //设置文件内容
        public void SetFileContent(string fileName, byte[] fileContent)
        {
            lock (fileContentsLock)
            {
                fileContents[fileName] = fileContent;
            }
        }
        
        //判断是否存在相同项
        public bool Exsits(string key)
        {
            return fileContents.ContainsKey(key);
        }

        //转换为byte形式
        public void SetFileData(string filePath, byte[] data)
        {
            fileContents[filePath] = data;
        }

        //清空缓存
        public void ClearCache()
        {
            fileContents.Clear();
        }

    }
}
