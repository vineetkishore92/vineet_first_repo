using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTransferBusinessLayer
{
    partial class DataHandlerPartial
    {
        Dictionary<string, KeyValuePair<int, int>> dictOFS1 = new Dictionary<string, KeyValuePair<int, int>>();
        static int index = 1;
        int lengthOfString_Satellite1 = 2;
        int timePerByteInHour_Satellite1 = 1;

        /// <summary>
        /// method to transfer data from Curiosity2 to Satellite 1
        /// </summary>
        /// <param name="memory capacity of satellite 1"></param>
        /// <param name="memory capacity of satellite 2"></param>
        /// <param name="memory capacity of satellite 3"></param>
        /// <param name="message"></param>
        /// <returns>total time taken by message to reach Satellite 1 from MARS in hours</returns>
        internal int transferFromMarsToS1(int m1, int m2, int m3, string message)
        {            
            List<KeyValuePair<int, string>> listToS1 = new List<KeyValuePair<int, string>>();
            string[] strMessageArray = message.Split(' ');
            Dictionary<string, bool> dictToCheckRemove = new Dictionary<string, bool>();

            //To search whether data already lies wih Satellite 1
            foreach (string str in strMessageArray)
            {
                if (!dictOFS1.ContainsKey(str))
                {
                    KeyValuePair<int, string> kvp = new KeyValuePair<int, string>(0, str);
                    listToS1.Add(new KeyValuePair<int, string>(0, str));
                    if (str.Length == lengthOfString_Satellite1)
                    {
                        if (dictOFS1.Count() < m1)
                        {
                            dictOFS1.Add(str, new KeyValuePair<int, int>(index, 1));
                            index++;
                            if(!dictToCheckRemove.ContainsKey(str))
                            dictToCheckRemove.Add(str, false);
                        }
                        else
                        {
                            if (!dictToCheckRemove.ContainsKey(str))
                            dictToCheckRemove.Add(str, true);


                        }
                    }
                }
                else
                {
                    if (!dictToCheckRemove.ContainsKey(str))
                    dictToCheckRemove.Add(str, false);
                    var x = dictOFS1[str];
                    listToS1.Add(new KeyValuePair<int, string>(1, x.Key.ToString()));
                    dictOFS1[str] = new KeyValuePair<int, int>(x.Key, x.Value + 1);
                }
            }

            //to remove least used item from memory of satellite 1
            if (dictToCheckRemove.Count(x => x.Value == true) > 0 && dictToCheckRemove.Count > 0
                && dictToCheckRemove.Count(y => y.Value == false) < m1)
            {
                Dictionary<string, int> dictRefference = new Dictionary<string, int>();                
                foreach (var kvpS1 in dictOFS1)
                {
                    if (!dictToCheckRemove.ContainsKey(kvpS1.Key))
                    {
                        if(!dictRefference.ContainsKey(kvpS1.Key))
                        dictRefference.Add(kvpS1.Key, kvpS1.Value.Value);
                    }
                }
                var itemToRemove = dictRefference.OrderBy(x => x.Value).FirstOrDefault();
                dictOFS1.Remove(itemToRemove.Key);
                foreach (var kvpCheckToRemove in dictToCheckRemove)
                {
                    if (kvpCheckToRemove.Value == true)
                    {
                        if (dictOFS1.Count < m1)
                        {
                            if(!dictOFS1.ContainsKey(kvpCheckToRemove.Key))
                            dictOFS1.Add(kvpCheckToRemove.Key, new KeyValuePair<int, int>(index, 1));
                            index++;
                        }
                    }
                }
            }
            
            //to calculate no of bytes to be transferred
            int whiteSpaceChar = 0;
            if (listToS1.Count(x => x.Key == 0) > 0 && strMessageArray.Count() > 1)
            {
                whiteSpaceChar = listToS1.Count(x => x.Key == 0) - 1;
            }
            int charCount = 0;
            foreach (var kvp in listToS1)
            {
                if (kvp.Key == 0)
                {
                    charCount = charCount + kvp.Value.Length;
                }
            }

            int totalBytesToTransfer = charCount + whiteSpaceChar;
            int totalTime = totalBytesToTransfer * timePerByteInHour_Satellite1;
            totalTime = totalTime + transferFromS1ToS2(m2, m3, listToS1);
            return totalTime;
        }
    }
}
