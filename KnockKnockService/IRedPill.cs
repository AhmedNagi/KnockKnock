using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace KnockKnockService
{
    [ServiceContract(Namespace = "http://KnockKnock.readify.net", ConfigurationName = "IRedPill")]
    public interface IRedPill
    {
        [OperationContract]
        Guid WhatIsYourToken();


        [OperationContract, FaultContract(typeof(ArgumentOutOfRangeException))]
        long FibonacciNumber(long n);

        [OperationContract]
        TriangleType WhatShapeIsThis(int a, int b, int c);


        [OperationContract, FaultContract(typeof(ArgumentNullException))]
        string ReverseWords(string word);
    }
}