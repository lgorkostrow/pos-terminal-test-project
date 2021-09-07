using System;
using System.Linq;
using Autofac;
using PosTerminal.Console.DI;
using PosTerminal.Console.Exceptions;
using PosTerminal.Console.Models;
using PosTerminal.Console.Services;
using PosTerminal.Core.Services;

namespace PosTerminal.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            using var scope = DIService.Current.Container.BeginLifetimeScope();
            
            var service = scope.Resolve<ICoinChangeService>();
            var inputData = BuildInputData(scope, args);
            
            System.Console.WriteLine($"The price is {inputData.Price} \n" +
                                     $"The amount of given money is {inputData.DenominationsSum}");
            
            ValidateInputData(scope, inputData);
            var result = service.Calculate(inputData.DefinedDenominations, inputData.Change);
            
            System.Console.WriteLine($"The change is {string.Join(", ", result)}");
        }

        private static InputData BuildInputData(ILifetimeScope scope, string[] args)
        {
            var settings = scope.Resolve<IApplicationSettingsService>().Get();
            
            var price = decimal.Parse(args[0]);
            var denominations = args.Skip(1).Select(decimal.Parse).ToArray();
            
            var inputData = new InputData(settings.GetDenominationsForCurrentCountry(), price, denominations);

            return inputData;
        }

        private static void ValidateInputData(ILifetimeScope scope, InputData inputData)
        {
            var validator = scope.Resolve<IValidator>();

            try
            {
                validator.Validate(inputData);
            }
            catch (ValidationException e)
            {
                System.Console.WriteLine(e.Message);
                Environment.Exit(1);
            }
        }
    }
}