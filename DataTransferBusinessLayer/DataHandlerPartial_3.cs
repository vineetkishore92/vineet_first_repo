using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTransferBusinessLayer
{
    partial class DataHandlerPartial
    {
        Dictionary<string, KeyValuePair<int, int>> dictOFS3 = new Dictionary<string, KeyValuePair<int, int>>();
        int lengthOfString_Satellite3 = 4;
        int timePerByteInHour_Satellite3 = 5;

        /// <summary>
        /// method to transfer data from Satellite 2 to Satellite 3
        /// </summary>
        /// <param name="memory capacity of satellite 3"></param>
        /// <param name="listToS2"></param>
        /// <returns>total time taken by message to reach Satellite 3 from Satellie 2 in hours</returns>
        int transferFromS2ToS3(int m3, List<KeyValuePair<int, string>> listToS2)
        {
            //To read data transferred from Satellite 2 and decode it to original format
            StringBuilder sb = new StringBuilder();
            foreach (var kvp in listToS2)
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
            List<KeyValuePair<int, string>> listToS3 = new List<KeyValuePair<int, string>>();
            string[] strMessageArray = message.Split(' ');            
            Dictionary<string, bool> dictToCheckRemove = new Dictionary<string, bool>();

            //To search whether data already lies wih Satellite 1
            foreach (string str in strMessageArray)
            {
                if (!dictOFS3.ContainsKey(str))
                {
                    listToS3.Add(new KeyValuePair<int, string>(0, str));
                    if (str.Length == lengthOfString_Satellite3)
                    {
                        if (dictOFS3.Count() < m3)
                        {
                            dictOFS3.Add(str, new KeyValuePair<int, int>(index, 1));
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
                    var x = dictOFS3[str];
                    listToS3.Add(new KeyValuePair<int, string>(1, x.Key.ToString()));
                    dictOFS3[str] = new KeyValuePair<int, int>(x.Key, x.Value + 1);
                }
            }

            //to remove least used item from memory of satellite 3
            if (dictToCheckRemove.Count(x => x.Value == true) > 0 && dictToCheckRemove.Count > 0
                && dictToCheckRemove.Count(y => y.Value == false) < m3)
            {
                Dictionary<string, int> dictRefference = new Dictionary<string, int>();
                foreach (var kvpS3 in dictOFS3)
                {
                    if (!dictToCheckRemove.ContainsKey(kvpS3.Key))
                    {
                        dictRefference.Add(kvpS3.Key, kvpS3.Value.Value);
                    }
                }
                var itemToRemove = dictRefference.OrderBy(x => x.Value).FirstOrDefault();
                dictOFS3.Remove(itemToRemove.Key);
                foreach (var kvpCheckToRemove in dictToCheckRemove)
                {
                    if (kvpCheckToRemove.Value == true)
                    {
                        if (dictOFS3.Count < m3)
                        {
                            dictOFS3.Add(kvpCheckToRemove.Key, new KeyValuePair<int, int>(index, 1));
                            index++;
                        }
                    }
                }
            }

            //to calculate no of bytes to be transferred
            int whiteSpaceChar = 0;
            if (listToS3.Count(x => x.Key == 0) > 0 && strMessageArray.Count() > 1)
            {
                whiteSpaceChar = listToS3.Count(x => x.Key == 0) - 1;
            }
            int charCount = 0;
            foreach (var kvp in listToS3)
            {
                if (kvp.Key == 0)
                {
                    charCount = charCount + kvp.Value.Length;
                }
            }
            int totalBytesToTransfer = charCount + whiteSpaceChar;
            int totalTime = totalBytesToTransfer * timePerByteInHour_Satellite3;
            totalTime = totalTime + transferFromS3ToNASA(message);
            return totalTime;
        }
    }
}
