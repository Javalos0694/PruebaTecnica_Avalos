namespace LibeyTechnicalTestTest
{
    [TestClass]
    public class ApiTests
    {
        private readonly HttpClient _httpClient;
        public ApiTests()
        {
            _httpClient = new HttpClient();
        }

        [TestMethod]
        public async Task GetUsersByDocumentNumber_ReturnSuccess()
        {
            string documentNumber = "12345678";
            string apiUrl = $"https://localhost:44397/LibeyUser/users?filter={documentNumber}";


            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
            string responseBody = await response.Content.ReadAsStringAsync();

            Assert.IsTrue(response.IsSuccessStatusCode, "La API no respondió con éxito.");
            Assert.IsFalse(string.IsNullOrEmpty(responseBody), "La respuesta está vacía.");
        }

        [TestMethod]
        public async Task GetUsersByName_ReturnSuccess()
        {
            string name = "Jose";
            string apiUrl = $"https://localhost:44397/LibeyUser/users?filter={name}";


            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
            string responseBody = await response.Content.ReadAsStringAsync();

            Assert.IsTrue(response.IsSuccessStatusCode, "La API no respondió con éxito.");
            Assert.IsFalse(string.IsNullOrEmpty(responseBody), "La respuesta está vacía.");
        }
    }
}
