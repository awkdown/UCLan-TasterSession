using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockingDemo_IsoFrameworks
{
    //1. rename
    //2. create tests (TDD approach) --> creat class library for tests
    public class LogAnalyser
    {
        private ILogger logger;
        private IWebservice webservice;
        public int minNameLength { get; set; }


        //fake object into production code; later would use real object
        public LogAnalyser(ILogger l)
        {
            logger = l;
        }

        //if change other constructor, it will break the other user case
        //don't strip out constructors
		public LogAnalyser(ILogger l, IWebservice w)
		{
			logger = l;
            webservice = w;
		}

		public void Analyse(string filename)
        {
            //no code first; just make it compile
            
            if(filename.Length < minNameLength)
            {
                try
                {
					logger.LogError("filename is too small");
				}
                catch(Exception ex)
                {
                    webservice.Write("Error from logger" + ex);
                }
                
            }
        }
    }
}
