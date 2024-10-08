namespace TempLaboClini.Domain.ValueObjects
{
   using System;
   using System.Text.RegularExpressions;

    public class Email
    {
         public string Address { get; private set; }

          public Email(string address)
           {
           Address = address;
           }
     }
}
