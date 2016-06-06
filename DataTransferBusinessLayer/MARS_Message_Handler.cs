using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTransferBusinessLayer
{
    public class MARS_Message_Handler
    {
        DataHandlerPartial dataHandlerPartial = new DataHandlerPartial();

        /// <summary>
        /// method to call the data handler methods of satellite--Business layer
        /// </summary>
        /// <param name="messageToBeTransferred"></param>
        /// <param name="memory capacity of satellite 1"></param>
        /// <param name="memory capacity of satellite 2"></param>
        /// <param name="memory capacity of satellite 3"></param>
        /// <returns>total time taken by message to reach earth in hours</returns>
        public int messageProcessor(string messageToBeTransferred, int m1, int m2, int m3)
        {
            return dataHandlerPartial.transferFromMarsToS1(m1, m2, m3, messageToBeTransferred);            
        }
    }
}
