using Framework.Core.Specifications;
using Framework.Persistence.Mongo;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Scoring.Domain.Model.Applicants;
using Scoring.Domain.Model.Rules;
using Scoring.Domain.Model.Rules.Criterias;


namespace Scoring.Infrastructure.Persistence.Mongo.Tests.Integration
{
    public class UnitTest1
    {
        [Fact]
        public async void Retrive()
        {
            MappingRegistration.RegisterAll(typeof(UnitTest1).Assembly);

            var client = new MongoClient("mongodb://root:changeit@localhost");
            var database = client.GetDatabase("Scoring");
            var repository = new MongoRuleRepository(database);
            var spec = new WorkingExperience(TimeSpan.FromDays(365))
                .And(new WorkingExperience(TimeSpan.FromDays(10)));
            var rule = new Rule(Guid.NewGuid(), "Test Rule", spec);
            rule.Activate();
            rule.SetCalculation(CalculationStrategy.IncreasePointsTo(1000));
            await repository.Add(rule);

            var ru = await repository.Get(rule.Id);

        }

        [Fact]
        public async void RetriveAll()
        {
            MappingRegistration.RegisterAll(typeof(UnitTest1).Assembly);

            var client = new MongoClient("mongodb://root:changeit@localhost");
            var database = client.GetDatabase("Scoring");
            var repository = new MongoRuleRepository(database);
             

            var ru = await repository.GetActiveRules();

        }


        public class RuleMapping : IBsonMapping
        {
            public void Register()
            {

                BsonClassMap.RegisterClassMap<Specification<Applicant>>(map =>
                {
                    map.AutoMap();

                    map.AddKnownType(typeof(WorkingExperience));
                    map.AddKnownType(typeof(AndSpecification<Applicant>));
                    map.AddKnownType(typeof(OrSpecification<Applicant>));
                });

                BsonClassMap.RegisterClassMap<CompositeSpecification<Applicant>>(map =>
                {
                    map.AutoMap();
                    map.SetIsRootClass(true);
                    map.AddKnownType(typeof(AndSpecification<Applicant>));
                    map.AddKnownType(typeof(OrSpecification<Applicant>));
                });

                BsonClassMap.RegisterClassMap<WorkingExperience>(map =>
                {
                    map.AutoMap();
                    map.SetDiscriminator("WE");
 
                });


            }

        }
    }
}