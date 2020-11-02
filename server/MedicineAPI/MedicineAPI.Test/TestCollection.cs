using Microsoft.AspNetCore.Mvc.Testing;
using System;
using Xunit;

namespace MedicineAPI.Test
{
    [CollectionDefinition("Integration Tests")]
    public class TestCollection : ICollectionFixture<WebApplicationFactory<MedicineAPI.Startup>>
    {
       
    }
}
