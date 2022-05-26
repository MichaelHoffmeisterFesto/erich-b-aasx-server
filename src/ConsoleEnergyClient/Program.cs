using AdminShellNS;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ConsoleEnergyClient
{
    internal class Program
    {
        static HttpClient client = new HttpClient();

        static async Task<AdminShell.Submodel> GetSubmodel(string aasId, string smIdShort)
        {
            AdminShell.Submodel submodel = null;
            var path =  $"/aas/{aasId}/submodels/{smIdShort}/complete";
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();

                using (TextReader reader = new StringReader(json))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Converters.Add(new AdminShellConverters.JsonAasxConverter("modelType", "name"));
                    submodel = (AdminShell.Submodel)serializer.Deserialize(reader, typeof(AdminShell.Submodel));
                }
            }
            return submodel;
        }

        static async Task Test()
        {
            // retrieve energy Submodel
            var sm = await GetSubmodel("3", "Energy_model_harmonized");
            var mm = AdminShell.Key.MatchMode.Relaxed;

            // access electrical energy
            var smcEe = sm?.submodelElements?.FindFirstSemanticIdAs<AdminShell.SubmodelElementCollection>(
                new AdminShell.Key(AdminShell.Key.ConceptDescription, false, AdminShell.Identification.IRI,
                    "https://admin-shell.io/sandbox/idta/carbon-reporting/cd/electrical-energy/1/0"), mm);

            // access each phase current
            foreach (var smcPhase in smcEe?.value?.FindAllSemanticIdAs<AdminShell.SubmodelElementCollection>(
                new AdminShell.Key(AdminShell.Key.ConceptDescription, false, AdminShell.Identification.IRI,
                    "https://admin-shell.io/sandbox/idta/carbon-reporting/cd/electrical-phase/1/0"), mm))
            {
                // get phase index
                var pi = smcPhase.value.FindFirstSemanticIdAs<AdminShell.Property>(new AdminShell.Key(AdminShell.Key.ConceptDescription, false, AdminShell.Identification.IRI,
                    "https://admin-shell.io/sandbox/idta/carbon-reporting/cd/index-scope/1/0"), mm)?.value?.Trim();

                // get phase current
                var curr = smcPhase.value.FindFirstSemanticIdAs<AdminShell.Property>(new AdminShell.Key(AdminShell.Key.ConceptDescription, false, AdminShell.Identification.IRI,
                    "https://admin-shell.io/sandbox/idta/carbon-reporting/cd/current/1/0"), mm)?.value;

                // found?
                if (pi == "0" && curr != null && double.TryParse(curr, out var f))
                    Console.WriteLine($"Found phase L1 {f:0.00}");
            }
        }

        static void Main(string[] args)
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("http://localhost:51710/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            while (true)
            {
                Console.WriteLine("Hello World!");
                Test().GetAwaiter().GetResult();
                System.Threading.Thread.Sleep(2000);
            }
        }
    }
}
