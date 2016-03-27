using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class UseStream
    {
        private Stream mainStream;
        public UseStream(Stream responseStream)
        {
            mainStream = responseStream;
        }
        public void WriteStream()
        {
            StreamReader Writer = new StreamReader(mainStream);
            string streamLine = "";
            while (streamLine != null)
            {

                streamLine = Writer.ReadLine();
                if (streamLine != null)
                    Console.WriteLine(streamLine);
            }
            Console.ReadLine();
        }
    }

