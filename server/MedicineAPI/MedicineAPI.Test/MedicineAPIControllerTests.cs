using MedicineModel;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace MedicineAPI.Test
{
    [Collection("Integration Tests")]
    public class MedicineAPIControllerTests
    {
        private readonly WebApplicationFactory<Startup> _factory;
        public MedicineAPIControllerTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        
        [Theory]
        [MemberData(nameof(NewMedicineData))]
        public async Task TestPost(Medicine medicine, string expectedName)
        {
            var client = _factory.CreateClient();
            string strPayLoad = JsonSerializer.Serialize<Medicine>(medicine, new JsonSerializerOptions());
            var response = await client.PostAsync($"api/Medicine", new StringContent(strPayLoad, Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
            Assert.NotNull(response.Content);

            string res = response.Content.ReadAsStringAsync().Result;
            var med = JsonSerializer.Deserialize<Medicine>(res, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            var actualName = med.Name;

            Assert.Equal(expectedName, actualName);
        }

        [Theory]
        [MemberData(nameof(UpdateMedicineData))]
        public async Task TestPut(Medicine medicine, Guid expectedId)
        {
            var client = _factory.CreateClient();
            string strPayLoad = JsonSerializer.Serialize<Medicine>(medicine, new JsonSerializerOptions());
            var response = await client.PutAsync($"api/Medicine", new StringContent(strPayLoad, Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
            Assert.NotNull(response.Content);

            string res = response.Content.ReadAsStringAsync().Result;
            var med = JsonSerializer.Deserialize<Medicine>(res, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            var actualId = med.Id;

            Assert.Equal(expectedId, actualId);
        }

        [Fact]
        public async Task TestGetAll()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/Medicine");

            response.EnsureSuccessStatusCode();
            Assert.NotNull(response.Content);
        }

        [Theory]
        [InlineData("Update1")]
        //[InlineData("")]
        public async Task TestSearch(string name)
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync($"api/Medicine/search/{name}");

            response.EnsureSuccessStatusCode();
            Assert.NotNull(response.Content);
        }

        [Theory]
        [InlineData("8ec63327-fe25-450e-8162-c4701b3c1b9b")]
        public async Task TestGetById(string id)
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync($"api/Medicine/{id}");

            response.EnsureSuccessStatusCode();
            Assert.NotNull(response.Content);
        }

        public static IEnumerable<object[]> NewMedicineData()
        {
            Medicine medicine1 = new Medicine
            {
                Id = Guid.Parse("8ec63327-fe25-450e-8162-c4701b3c1b9b"),
                Name = "Name1",
                Brand = "Brand1",
                Price = 10,
                Quantity = 5,
                Expiry = DateTime.UtcNow.AddDays(365)
            };
            return new List<object[]>
            {
                new object[] { medicine1, medicine1.Name}
            };
        }
        public static IEnumerable<object[]> UpdateMedicineData()
        {
            Medicine medicine1 = new Medicine
            {
                Id = Guid.Parse("8ec63327-fe25-450e-8162-c4701b3c1b9b"),
                Name = "Update1",
                Brand = "UpdateBrand1",
                Price = 10,
                Quantity = 5,
                Expiry = DateTime.UtcNow.AddDays(365)
            };
            return new List<object[]>
            {
                new object[] { medicine1, medicine1.Id}
            };
        }
    }
}
