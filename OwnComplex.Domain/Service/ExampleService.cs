using OwnComplex.Domain.Entities;
using OwnComplex.Domain.ValueObjects;
using System.Runtime.CompilerServices;

namespace OwnComplex.Domain.Service;

public class ExampleService
{
    private readonly ILogger _logger;

    public ExampleService(ILogger logger, ITenantIdAccessor tenantIdAccessor)
    {
        _logger = logger;

        tenantIdAccessor.SetTenantId(Guid.NewGuid());
    }

    public async Task Example1LoadAPerson(IPeopleService scoup1, IPeopleService scoup2)
    {
                                                                                                                                                                                _logger.LogInformation("---------------------------+++++++++++++---------------------------");
                                                                                                                                                                                _logger.LogInformation("---------------------------Example1LoadAPerson");
        var peopleService = scoup1; _logger.LogInformation("--------------------------------   scoup1");

        var thinPersonId = await CallWithMetric(peopleService.AddThinPerson);
        var fatPersonId = await CallWithMetric(peopleService.AddFatPerson);

        var thinPerson = await CallWithMetric(() => peopleService.GetPerson(thinPersonId), "Get thin person in context");
        var fatPerson = await CallWithMetric(() => peopleService.GetPerson(fatPersonId), "Get FAT person in context");


        peopleService = scoup2; _logger.LogInformation("--------------------------------   scoup2");

        var thinPersonOnNewContext = await CallWithMetric(() => peopleService.GetPerson(thinPersonId), "Get thin person in new context");
        var fatPersonOnNewContext = await CallWithMetric(() => peopleService.GetPerson(fatPersonId), "Get FAT person in new context");

        var response = $"{fatPersonOnNewContext.FirstName} like {thinPersonOnNewContext.FirstName}' new car";

                                                                                                                                                                                _logger.LogInformation("---------------------------+++++++++++++---------------------------");
                                                                                                                                                                                _logger.LogInformation("-------------------------------------------------------------------");
    }


    public async Task Example2HiddenId(IPeopleService scoup1, IPeopleService scoup2, IPeopleService scoup3)
    {
                                                                                                                                                                                _logger.LogInformation("---------------------------+++++++++++++---------------------------");
                                                                                                                                                                                _logger.LogInformation("---------------------------Example2HiddenId");
        var peopleService = scoup1; _logger.LogInformation("--------------------------------   scoup1");

        var thinPersonId = await peopleService.AddThinPerson();
        var thinPerson = await peopleService.GetPerson(thinPersonId);
        thinPerson.SetTags(new List<Tag>(thinPerson.Tags)
        {
            Tag.Create("Krystian Team")
        });
        await peopleService.UpdateByTracking(); _logger.LogInformation($"Thin person id: {thinPerson.Id}, Tags :\n{string.Join("\n", thinPerson.Tags)}");




        peopleService = scoup2; _logger.LogInformation("--------------------------------   scoup2");

        var thinPerson2 = await peopleService.GetPerson(thinPersonId);
        thinPerson2.SetTags(new List<Tag>(thinPerson2.Tags.Where(x => x.Name != "Krystian Team"))
        {
            Tag.Random(),
            Tag.Random(),
            Tag.Random(),
            Tag.Random()
        });
        await peopleService.UpdateByTracking(); _logger.LogInformation($"Thin person id: {thinPerson2.Id}, Tags :\n{string.Join("\n", thinPerson2.Tags)}");




        peopleService = scoup3; _logger.LogInformation("--------------------------------   scoup3");

        var thinPerson3 = await peopleService.GetPerson(thinPersonId);
        var collection = new List<Tag>(thinPerson3.Tags.Select(x => Tag.Create(x.Name)));
        thinPerson3.SetTags(collection);
        await peopleService.UpdateByTracking(); _logger.LogInformation($"Thin person id: {thinPerson3.Id}, Tags :\n{string.Join("\n", thinPerson3.Tags)}");

        _logger.LogInformation("Let's go and check Tag table");
                                                                                                                                                                                _logger.LogInformation("---------------------------+++++++++++++---------------------------");
                                                                                                                                                                                _logger.LogInformation("-------------------------------------------------------------------");
    }


    public async Task Example3OwnOneWithOwnMany(IPeopleService scoup1, IPeopleService scoup2, IPeopleService scoup3)
    {
                                                                                                                                                                                _logger.LogInformation("---------------------------+++++++++++++---------------------------");
                                                                                                                                                                                _logger.LogInformation("---------------------------Example3OwnOneWithOwnMany");
        var peopleService = scoup1; _logger.LogInformation("--------------------------------   scoup1");

        var thinPersonId = await peopleService.AddThinPerson();
        var thinPerson = await peopleService.GetPerson(thinPersonId);
                                                                                                 _logger.LogInformation(
                                                                                                     $"\nThin person id: {thinPerson.Id}, \n\nMedicalConditions:\n{string.Join("\n", thinPerson.MedicalDetails.MedicalConditions.ToList())}");


        peopleService = scoup2; _logger.LogInformation("--------------------------------   scoup2");

        var thinPerson2 = await peopleService.GetPerson(thinPersonId);
        
        thinPerson2.SetMedicalDetails(MedicalDetails.MultipleConditionsRandom());
        await peopleService.UpdateByTracking();
                                                                                                 _logger.LogInformation(
                                                                                                     $"\nThin person id: {thinPerson2.Id}, \n\nMedicalConditions:\n{string.Join("\n", thinPerson2.MedicalDetails.MedicalConditions.ToList())}");


        thinPerson2.SetMedicalDetails(MedicalDetails.SimpleRandom());
        await peopleService.UpdateByTracking();
                                                                                                 _logger.LogInformation(
                                                                                                     $"\nThin person id: {thinPerson2.Id}, \n\nMedicalConditions:\n{string.Join("\n", thinPerson2.MedicalDetails.MedicalConditions.ToList())}");


        peopleService = scoup3; _logger.LogInformation("--------------------------------   scoup3");

        var thinPerson3 = await peopleService.GetPerson(thinPersonId);
                                                                                                    _logger.LogInformation(
                                                                                                        $"\nThin person id: {thinPerson3.Id}, \n\nMedicalConditions:\n{string.Join("\n", thinPerson3.MedicalDetails.MedicalConditions.ToList())}");

                                                                                                                                                                                    _logger.LogInformation("---------------------------+++++++++++++---------------------------");
                                                                                                                                                                                    _logger.LogInformation("-------------------------------------------------------------------");
    }

    
    public async Task Example4GuidAsIdInOwnMany(IPeopleService scoup1, IPeopleService scoup2, IPeopleService scoup3)
    {
                                                                                                                                                                                    _logger.LogInformation("---------------------------+++++++++++++---------------------------");
                                                                                                                                                                                    _logger.LogInformation("---------------------------Example4GuidAsIdInOwnMany");

        var peopleService = scoup1; _logger.LogInformation("--------------------------------   scoup1");




        var emptyPersonId = await peopleService.AddThinPerson();
        var personWithRoleId = await peopleService.AddThinPerson(new List<EntityId>(){ EntityId.Random() }, EntityId.Random());

        var emptyPerson = await peopleService.GetPerson(emptyPersonId);
        var personWithRole = await peopleService.GetPerson(personWithRoleId);



        PrintPerson(emptyPerson, '+'); PrintPerson(personWithRole, '-');

        peopleService = scoup2; _logger.LogInformation("--------------------------------   scoup2");




        var emptyPerson2 = await peopleService.GetPerson(emptyPersonId);
        emptyPerson2.SetRoles(new List<EntityId>()
        {
            EntityId.Random(),
            EntityId.Random(),
        });
        emptyPerson2.AddRiskProfile(EntityId.Random());

        var personWithRole2 = await peopleService.GetPerson(personWithRoleId);
        personWithRole2.SetRoles(new List<EntityId>()
        {
            EntityId.Random(),
            EntityId.Random(),
        });
        personWithRole2.AddRiskProfile(EntityId.Random());
        personWithRole2.AddRiskProfile(EntityId.Random());

        await peopleService.UpdateByTracking();
        


        PrintPerson(emptyPerson2, '+'); PrintPerson(personWithRole2, '-');

        peopleService = scoup3; _logger.LogInformation("--------------------------------   scoup3 should equals scoup2");


        var emptyPerson3 = await peopleService.GetPerson(emptyPersonId);
        var personWithRole3 = await peopleService.GetPerson(personWithRoleId);



        PrintPerson(emptyPerson3, '+'); PrintPerson(personWithRole3, '-');
                                                                                                                                                                                     _logger.LogInformation("---------------------------+++++++++++++---------------------------");
                                                                                                                                                                                     _logger.LogInformation("-------------------------------------------------------------------");
    }

    private void PrintPerson(PersonEntity person, char mark, [CallerArgumentExpression("person")] string variableName = null)
    {
        _logger.LogInformation(("\n+++++++++++++++++\n" +
                               $"++++++++++++ Variable {variableName} with id: {person.Id}, \n" +
                               $"++Roles :\n++++{string.Join("\n+++", person.Roles)}\n" +
                               $"++RiskProfile :\n++++{string.Join("\n+++", person.RiskProfile)}\n" +
                               "+++++++++++++++++\n").Replace('+', mark));
    }

    public async Task Example5IndexForFirstNameAndEmailAdress()
    {
        _logger.LogInformation("---------------------------+++++++++++++---------------------------");
        _logger.LogInformation("---------------------------Example5IndexForFirstNameAndEmailAddress");
        _logger.LogInformation("Let's go to configuration entity and try to create index for FirstName and EmailAddress");
        _logger.LogInformation("---------------------------+++++++++++++---------------------------");
        _logger.LogInformation("-------------------------------------------------------------------");
    }

    private async Task<T> CallWithMetric<T>(Func<Task<T>> func, string? methodName = null)
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        var retValue = await func();
        watch.Stop();
        _logger.LogInformation($"Called in time: {watch.Elapsed:g}  Function: {methodName ?? func.Method.Name}");
        return retValue;
    }

    private async Task CallWithMetric(Action action, string? methodName = null)
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        action.DynamicInvoke();
        watch.Stop();
        _logger.LogInformation($"Called in time: {watch.Elapsed:g} Function: {methodName ?? action.Method.Name}");
    }

    private async Task CallWithMetric(Func<Task> action, string? methodName = null)
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        await action();
        watch.Stop();
        _logger.LogInformation($"Called in time: {watch.Elapsed:g} Function: {methodName ?? action.Method.Name}");
    }
}