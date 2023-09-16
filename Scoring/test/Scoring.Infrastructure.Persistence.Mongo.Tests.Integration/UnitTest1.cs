
using Framework.Core.Specifications;
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
        public async void Test1()
        {
            BsonClassMap.RegisterClassMap<Specification<Applicant>>(map =>
            {
                map.AutoMap();
                map.SetIsRootClass(true);

                map.AddKnownType(typeof(WorkingExperience));
                map.AddKnownType(typeof(AndSpecification<Applicant>));
                map.AddKnownType(typeof(OrSpecification<Applicant>));

            });

            var client = new MongoClient("mongodb://root:changeit@localhost");
            var database = client.GetDatabase("Scoring");
            var repository = new MongoRuleRepository(database);
            //var spec = new WorkingExperience(TimeSpan.FromDays(365))
            //    .And(new WorkingExperience(TimeSpan.FromDays(10)));
            //var rule = new Rule(Guid.NewGuid(), "Test Rule", spec);

            //await repository.Add(rule);

            var ru =await  repository.Get(Guid.Parse("742c4757-5c67-8346-9230-ebc8fc247040"));

        } 
    }
}