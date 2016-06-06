using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTransferBusinessLayer
{
    partial class DataHandlerPartial
    {
        Dictionary<string, KeyValuePair<int, int>> dictOFS2 = new Dictionary<string, KeyValuePair<int, int>>();
        int lengthOfString_Satellite2 = 3;
        int timePerByteInHour_Satellite2 = 5;

        /// <summary>
        /// method to transfer data from Curiosity2 to Satellite 1 
        /// </summary>
        /// <param name="memory capacity of satellite 2"></param>
        /// <param name="memory capacity of satellite 3"></param>
        /// <param name="listToS1"></param>
        /// <returns>total time taken by message to reach Satellite 2 from Satellie 1 in hours</returns>
        int transferFromS1ToS2(int m2, int m3, List<KeyValuePair<int, string>> listToS1)
        {
            //To read data transferred from Satellite 1 and decode it to original format
            StringBuilder sb = new StringBuilder();
            foreach (var kvp in listToS1)
            {
                if (kvp.Key == 0)
                {
                    sb.Append(kvp.Value);
                    sb.Append(" ");
                }
                else
                {
                    int position1 = 0;
                    int.TryParse(kvp.Value, out position1);
                    foreach (var keyValue in dictOFS1)
                    {
                        if (keyValue.Value.Key == position1)
                        {
                            sb.Append(keyValue.Key);
                            sb.Append(" ");
                        }
                    }
                }
            }
            string message = sb.ToString().Trim();
            List<KeyValuePair<int, string>> listToS2 = new List<KeyValuePair<int, string>>();
            string[] strMessageArray = message.Split(' ');
            Dictionary<string, bool> dictToCheckRemove = new Dictionary<string, bool>();

            //To search whether data already lies wih Satellite 2
            foreach (string str in strMessageArray)
            {
                if (!dictOFS2.ContainsKey(str))
                {
                    listToS2.Add(new KeyValuePair<int, string>(0, str));
                    if (str.Length == lengthOfString_Satellite2)
                    {
                        if (dictOFS2.Count() < m2)
                        {
                            dictOFS2.Add(str, new KeyValuePair<int, int>(index, 1));
                            index++;
                        }
                        else
                        {
                            dictToCheckRemove.Add(str, true);
                        }
                    }
                }
                else
                {
                    var x = dictOFS2[str];
                    listToS2.Add(new KeyValuePair<int, string>(1, x.Key.ToString()));
                    dictOFS2[str] = new KeyValuePair<int, int>(x.Key, x.Value + 1);
                }
            }

            //to remove least used item from memory of satellite 2
            if (dictToCheckRemove.Count(x => x.Value == true) > 0 && dictToCheckRemove.Count > 0
                && dictToCheckRemove.Count(y => y.Value == false) < m2)
            {
                Dictionary<string, int> dictRefference = new Dictionary<string, int>();
                foreach (var kvpS2 in dictOFS2)
                {
                    if (!dictToCheckRemove.ContainsKey(kvpS2.Key))
                    {
                        dictRefference.Add(kvpS2.Key, kvpS2.Value.Value);
                    }
                }
                var itemToRemove = dictRefference.OrderBy(x => x.Value).FirstOrDefault();
                dictOFS2.Remove(itemToRemove.Key);
                foreach (var kvpCheckToRemove in dictToCheckRemove)
                {
                    if (kvpCheckToRemove.Value == true)
                    {
                        if (dictOFS2.Count < m2)
                        {
                            dictOFS2.Add(kvpCheckToRemove.Key, new KeyValuePair<int, int>(index, 1));
                            index++;
                        }
                    }
                }
            }

            //to calculate no of bytes to be transferred
            int whiteSpaceChar = 0;
            if (listToS2.Count(x => x.Key == 0) > 0 && strMessageArray.Count() > 1)
            {
                whiteSpaceChar = listToS2.Count(x => x.Key == 0) - 1;
            }
            int charCount = 0;
            foreach (var kvp in listToS2)
            {
                if (kvp.Key == 0)
                {
                    charCount = charCount + kvp.Value.Length;
                }
            }
            int totalBytesToTransfer = charCount + whiteSpaceChar;
            int totalTime = totalBytesToTransfer * timePerByteInHour_Satellite2;
            totalTime = totalTime + transferFromS2ToS3(m3, listToS2);
            return totalTime;
        }
    }
}
