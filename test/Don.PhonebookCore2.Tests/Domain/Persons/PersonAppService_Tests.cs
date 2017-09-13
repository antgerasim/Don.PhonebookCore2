using System.Linq;
using System.Threading.Tasks;
using Abp.Runtime.Validation;
using Don.PhonebookCore2.Domain.Person;
using Don.PhonebookCore2.Domain.Person.Dto;
using Don.PhonebookCore2.Users;
using NSubstitute.Exceptions;
using Shouldly;
using Xunit;

namespace Don.PhonebookCore2.Tests.Domain.Persons
{
    public class PersonAppService_Tests : PhonebookCore2TestBase
    {
        private readonly IPersonAppService _personAppService;

        public PersonAppService_Tests()
        {
            _personAppService = Resolve<IPersonAppService>();
        }

        [Fact]
        public void Should_Get_All_People_Without_Any_Filter()
        {
            //Act
            var persons = _personAppService.GetPeople(new GetPeopleInput());

            //Assert
            persons.Items.Count.ShouldBe(2);
        }

        [Fact]
        public void Should_Get_People_With_Filter()
        {
            //Act
            var persons = _personAppService.GetPeople(new GetPeopleInput() {Filter = "Adams"});

            //Assert
            persons.Items.Count.ShouldBe(1);
            persons.Items[0].Name.ShouldBe("Douglas");
            persons.Items[0].Surname.ShouldBe("Adams");
        }

        [Fact]
        public async Task Should_Create_Person_With_Valid_Arghuments()
        {
            //act
            await _personAppService.CreatePerson(new CreatePersonInput()
            {
                Name = "Paris",
                Surname = "Hilton",
                EmailAddress = "paris@hilton.com"
            });

            //assert
            UsingDbContext(
                context =>
                {
                    var paris = context.Persons.FirstOrDefault(p => p.EmailAddress == "paris@hilton.com");
                    paris.ShouldNotBe(null);
                    paris.Name.ShouldBe("Paris");
                });
        }

        [Fact]
        public async Task Should_Create_Person_With_Invalid_Arghuments()
        {
            //act and assert
            await Assert.ThrowsAsync<AbpValidationException>(
                async () =>
                {
                    await _personAppService.CreatePerson(new CreatePersonInput()
                    {
                        Name = "Paris"
                    });
                });

        }
    }
}