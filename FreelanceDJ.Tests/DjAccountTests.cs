using FreelanceDJ.Data.Repos;
using FreelanceDJ.Models.DjAccount;
using Moq;
using NUnit.Framework;

namespace FreelanceDJ.Tests
{
    public class DjAccountTests
    {
        private readonly List<DjAccount> _djaccounts;

        public DjAccountTests()
        {
            _djaccounts = new List<DjAccount>
            {
                new()
                {
                    Id = new Guid(),
                    Name = "Dj Testino",
                    Description = "Dj Testino is eem leipe dj die goed kan testen",
                    Email = "DJ@Testino.MGMT.nl",
                    Phone = 31612345,
                    Price = 850,
                },

                new()
                 {
                    Id = new Guid(),
                    Name = "Dj Platinoza",
                    Description = "Dj Platinoza is eem gave club Dj die lekkere plaatjes mixt",
                    Email = "DJ@Platinoza.MGMT.com",
                    Phone = 316876543,
                    Price = 1200,
                }
            };
        }


        [Test]
        public async Task GetAllDjs_ReturnListWithDjs()
        {
            var data = new Mock<IFreelanceDJRepository>();
            data.Setup(m => m.GetAllDjAccounts()).ReturnsAsync(_djaccounts);
            var djAccountService = new Service.DjAccountService(data.Object);

            var djs = await djAccountService.GetAllDjs();

            Assert.AreEqual(djs.Count , _djaccounts.Count);
        }

        [Test]
        public async Task GetOneSpecificUser_ReturnThisUser()
        {
            var data = new Mock<IFreelanceDJRepository>();
            data.Setup(m => m.GetSpecificDjAccount(It.IsAny<Guid>())).ReturnsAsync(_djaccounts[0]);
            var djAccountService = new Service.DjAccountService(data.Object);

            var djaccount = await djAccountService.GetDjAccountById(It.IsAny<Guid>());

            Assert.AreEqual(djaccount, _djaccounts[0]);
        }

        [Test]
        public async Task GetOneWrongSpecificUser_ReturnThisUser()
        {
            var data = new Mock<IFreelanceDJRepository>();
            data.Setup(m => m.GetSpecificDjAccount(It.IsAny<Guid>())).ReturnsAsync(_djaccounts[0]);
            var djAccountService = new Service.DjAccountService(data.Object);

            var djaccount = await djAccountService.GetDjAccountById(It.IsAny<Guid>());

            Assert.AreNotEqual(djaccount, _djaccounts[1]);
        }

        [Test]
        public async Task DeleteOneSpecificUser_ReturnThisUser()
        {
            var data = new Mock<IFreelanceDJRepository>();
            data.Setup(m => m.DeleteSpecificDjAccount(It.IsAny<Guid>())).ReturnsAsync(_djaccounts[0]);
            var djAccountService = new Service.DjAccountService(data.Object);

            var djaccount = await djAccountService.DeleteDjAccountById(It.IsAny<Guid>());

            Assert.AreEqual(djaccount, _djaccounts[0]);
        }

        [Test]
        public async Task DeleteOneWrongSpecificUser_ReturnThisUser()
        {
            var data = new Mock<IFreelanceDJRepository>();
            data.Setup(m => m.DeleteSpecificDjAccount(It.IsAny<Guid>())).ReturnsAsync(_djaccounts[0]);
            var djAccountService = new Service.DjAccountService(data.Object);

            var djaccount = await djAccountService.DeleteDjAccountById(It.IsAny<Guid>());

            Assert.AreNotEqual(djaccount, _djaccounts[1]);
        }
    }
}