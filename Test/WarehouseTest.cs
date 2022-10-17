using API;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;
using Xunit.Abstractions;

namespace Test
{
    public class WarehouseTest
    {
        private readonly ITestOutputHelper _outputHelper;

        // We created an instance of all API making a reference to Program Class
        private readonly WebApplicationFactory<Program> _webApplicationFactory;

        public WarehouseTest(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
            _webApplicationFactory = new WebApplicationFactory<Program>();
        }

        [Fact]
        public async void GetWarehouses()
        {
            //Arrange
            var client = _webApplicationFactory.CreateDefaultClient();

            //Act
            var response = await client.GetAsync("/api/warehouse");

            //Assert
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var responseContent = response.Content.ReadAsStringAsync().Result;
            Assert.NotNull(responseContent);
            //Assert.NotEmpty(responseContent);
            Assert.False(string.IsNullOrEmpty(responseContent));


            _outputHelper.WriteLine(JsonConvert.SerializeObject(responseContent));
        }
    }
}