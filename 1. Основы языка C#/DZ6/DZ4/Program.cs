using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ4
{
    //Корбун Т.И.
    /*
     **Считайте файл различными способами. 
     * Смотрите “Пример записи файла различными способами”. 
     * Создайте методы, которые возвращают массив byte (FileStream, BufferedStream), строку для StreamReader и массив int для BinaryReader.
     */

    class Program
    {
        static void Main(string[] args)
        {
            long kbyte = 1024;
            long mbyte = 1024 * kbyte;
            long gbyte = 1024 * mbyte;
            long size = kbyte;
            //Write FileStream
            //Write BinaryStream
            //Write StreamReader/StreamWriter
            //Write BufferedStream

            //Примеры различной записи
            Console.WriteLine("Запись:");
            Console.WriteLine("FileStream. Milliseconds:{0}", FileStreamSampleWrite("bigdata0.bin", size));
            Console.WriteLine("BinaryStream. Milliseconds:{0}", BinaryStreamSampleWrite("bigdata1.bin", size));
            Console.WriteLine("StreamWriter. Milliseconds:{0}", StreamWriterSample("bigdata2.bin", size));
            Console.WriteLine("BufferedStream. Milliseconds:{0}", BufferedStreamSampleWrite("bigdata3.bin", size));

            //Примеры различного чтения
            Console.WriteLine("\nЧтение:");
            byte[] tmp1 = FileStreamSampleRead("bigdata0.bin", size);
            Console.WriteLine("{0}, size: {1}", tmp1, tmp1.Length);
            int[] tmp2 = BinaryStreamSampleRead("bigdata1.bin", size);
            Console.WriteLine("{0}, size: {1}", tmp2, tmp2.Length);
            string tmp3 = StreamReaderSample("bigdata2.bin");
            Console.WriteLine("{0}, length: {1}", tmp3, tmp3.Length);
            byte[] tmp4 = BufferedStreamSampleRead("bigdata3.bin", size);
            Console.WriteLine("{0}, size: {1}", tmp4, tmp4.Length);

            Console.ReadKey();
        }

        static long FileStreamSampleWrite(string filename, long size)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
            for (int i = 0; i < size; i++)
                fs.WriteByte(0);
            fs.Close();
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        static byte[] FileStreamSampleRead(string filename, long size)
        {
            List<byte> result = new List<byte>();
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            for (int i = 0; i < size; i++)
                result.Add((byte)fs.ReadByte());
            fs.Close();
            return result.ToArray();
        }

        static long BinaryStreamSampleWrite(string filename, long size)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            for (int i = 0; i < size; i++)
                bw.Write((byte)0);
            bw.Close();
            fs.Close();
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        static int[] BinaryStreamSampleRead(string filename, long size)
        {
            List<int> result = new List<int>();
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            for (int i = 0; i < size; i++)
                result.Add(br.Read());
            br.Close();
            fs.Close();
            return result.ToArray();
        }

        static long StreamWriterSample(string filename, long size)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            for (int i = 0; i < size; i++)
                sw.Write(0);
            sw.Close();
            fs.Close();
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        static string StreamReaderSample(string filename)
        {
            string result = "";
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            result = sr.ReadToEnd();
            sr.Close();
            fs.Close();
            return result;
        }

        static long BufferedStreamSampleWrite(string filename, long size)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
            int countPart = 4;//количество частей
            int bufsize = (int)(size / countPart);
            byte[] buffer = new byte[size];
            BufferedStream bs = new BufferedStream(fs, bufsize);
            //bs.Write(buffer, 0, (int)size);//Error!
            for (int i = 0; i < countPart; i++)
                bs.Write(buffer, 0, (int)bufsize);
            bs.Close();
            fs.Close();
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        static byte[] BufferedStreamSampleRead(string filename, long size)
        {
            List<byte> result = new List<byte>();
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            int countPart = 4;//количество частей
            int bufsize = (int)(size / countPart);
            byte[] buffer = new byte[size];
            BufferedStream bs = new BufferedStream(fs, bufsize);
            //bs.Write(buffer, 0, (int)size);//Error!
            for (int i = 0; i < countPart; i++)
            {
                bs.Read(buffer, 0, (int)bufsize);
                result.AddRange(buffer);
            }
            bs.Close();
            fs.Close();
            return result.ToArray();
        }
    }
}

