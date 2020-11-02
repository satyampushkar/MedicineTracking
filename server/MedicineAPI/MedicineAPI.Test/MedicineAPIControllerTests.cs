using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
