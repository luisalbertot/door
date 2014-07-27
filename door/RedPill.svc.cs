using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web;
using knockknock.readify.net;

namespace door
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RedPill" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RedPill.svc or RedPill.svc.cs at the Solution Explorer and start debugging.
    public class RedPill : IRedPill
    {
        public ContactDetails WhoAreYou()
        {
            log(DateTime.Now + " - WhoAreYou();" + Environment.NewLine);
            return BluePill.WhoAreYou();
        }

        public long FibonacciNumber(long n)
        {
            log(DateTime.Now + " - FibonacciNumber(" + n + ")=");

            long fib;
            try
            {
                Convert.ToInt64(BluePill.FibonnaciAprox(n));
            }
            catch(System.OverflowException)
            {
                log("ArgumentOutOfRangeException;" + Environment.NewLine);
                throw new System.ServiceModel.FaultException<System.ArgumentOutOfRangeException>(new System.ArgumentOutOfRangeException("Fibonacci result will be 'too long'"), new FaultReason("Fibonacci result will be 'too long'"));
            }
            fib = BluePill.Fibonnaci(n);
            log(fib + ";" + Environment.NewLine);
            return fib;
        }



        public TriangleType WhatShapeIsThis(int a, int b, int c)
        {
            log(DateTime.Now + " - WhatShapeIsThis(" + a + "," + b + "," + c + ")=");
            TriangleType triangleType = BluePill.WhatShapeIsThis(a, b, c);
            log(triangleType + ";" + Environment.NewLine);
            return triangleType;
        }

        public string ReverseWords(string s)
        {
            log(DateTime.Now + " - ReverseWords(\"" + s + "\")=");
            string result = null;
            if (s != null)
            {
                result = BluePill.ReverseWords(s);
                log("\"" + result + "\";" + Environment.NewLine);
            }
            else
            {
                log("ArgumentNullException;" + Environment.NewLine);
                throw new System.ServiceModel.FaultException<System.ArgumentNullException>(new System.ArgumentNullException("Parameter can't be null"), new FaultReason("Parameter can't be null"));
            }
            return result;
        }

        private void log(string text)
        {
            File.AppendAllText(HttpContext.Current.Server.MapPath("~/App_Data/log.txt"), text);
        }

    }
}
