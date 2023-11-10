using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OwnComplex.Domain.Service;
using OwnComplex.Domain.ValueObjects;
using static System.Formats.Asn1.AsnWriter;

namespace OwnComplex.EF6
{
    internal class Worker : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly ExampleService _example;

        public Worker(IServiceScopeFactory serviceScopeFactory, ExampleService example)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _example = example;
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
           await Example1LoadAPerson();
           //await Example2HiddenId();
           //await Example3OwnOneWithOwnMany();
           //await Example4GuidAsIdInOwnMany();
           //await Example5IndexForFirstNameAndEmailAdress();
        }

        private async Task Example1LoadAPerson()
        {
            using var scope1 = _serviceScopeFactory.CreateScope();
            using var peopleService1 = scope1.ServiceProvider.GetRequiredService<IPeopleService>();
            using var scope2 = _serviceScopeFactory.CreateScope();
            using var peopleService2 = scope2.ServiceProvider.GetRequiredService<IPeopleService>();

            await _example.Example1LoadAPerson(peopleService1, peopleService2);
        }

        private async Task Example2HiddenId()
        {
            using var scope1 = _serviceScopeFactory.CreateScope();
            using var peopleService1 = scope1.ServiceProvider.GetRequiredService<IPeopleService>();
            using var scope2 = _serviceScopeFactory.CreateScope();
            using var peopleService2 = scope2.ServiceProvider.GetRequiredService<IPeopleService>();
            using var scope3 = _serviceScopeFactory.CreateScope();
            using var peopleService3 = scope3.ServiceProvider.GetRequiredService<IPeopleService>();

            await _example.Example2HiddenId(peopleService1, peopleService2, peopleService3);
        }


        private async Task Example3OwnOneWithOwnMany()
        {
            using var scope1 = _serviceScopeFactory.CreateScope();
            using var peopleService1 = scope1.ServiceProvider.GetRequiredService<IPeopleService>();
            using var scope2 = _serviceScopeFactory.CreateScope();
            using var peopleService2 = scope2.ServiceProvider.GetRequiredService<IPeopleService>();
            using var scope3 = _serviceScopeFactory.CreateScope();
            using var peopleService3 = scope3.ServiceProvider.GetRequiredService<IPeopleService>();

            await _example.Example3OwnOneWithOwnMany(peopleService1, peopleService2, peopleService3);
        }

        private async Task Example4GuidAsIdInOwnMany()
        {
            using var scope1 = _serviceScopeFactory.CreateScope();
            using var peopleService1 = scope1.ServiceProvider.GetRequiredService<IPeopleService>();
            using var scope2 = _serviceScopeFactory.CreateScope();
            using var peopleService2 = scope2.ServiceProvider.GetRequiredService<IPeopleService>();
            using var scope3 = _serviceScopeFactory.CreateScope();
            using var peopleService3 = scope3.ServiceProvider.GetRequiredService<IPeopleService>();

            await _example.Example4GuidAsIdInOwnMany(peopleService1, peopleService2, peopleService3);
        }

        private async Task Example5IndexForFirstNameAndEmailAdress()
        {
            await _example.Example5IndexForFirstNameAndEmailAdress();
        }

    }
}