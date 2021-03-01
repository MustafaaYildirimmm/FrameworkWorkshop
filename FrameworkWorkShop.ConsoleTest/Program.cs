using FluentValidation;
using FrameworkWorkShop.Business.ValidationRules.FluentValidation;
using FrameworkWorkShop.Core.Entities;
using FrameworkWorkShop.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkWorkShop.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IValidator xc = (IValidator)Activator.CreateInstance(typeof(ProductValidator));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
