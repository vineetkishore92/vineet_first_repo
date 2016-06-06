using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTransferBusinessLayer
{
    partial class DataHandlerPartial
    {
        int timePerByteInHour_Earth = 1;
        /// <summary>
        /// method to transfer data from Satellite 3 to Earth
        /// </summary>
        /// <param name="message"></param>
        /// <returns>total time taken by message to reach earth from Satellie 3 in hours</returns>
        int transferFromS3ToNASA(string message)
        {
            //to calculate no of bytes to be transferred
            int totalTime = message.Length * timePerByteInHour_Earth;
            return totalTime;
        }
    }
}
