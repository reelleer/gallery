using Gallery.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace GalleryTest
{
    [TestClass]
    public class GalleryAppTest
    {
        [TestMethod]
        public async Task WebApiCall_HttpError()
        {
            var webApiCall = new WebApiCall
            {
                Timeout = TimeSpan.FromSeconds(10)
            };

            var content = await webApiCall.GetContentAsync("https://notadomain.dotcom.hello");

            var result = JsonConvert.DeserializeObject<SimpleResult>(content);

            Assert.AreEqual<string>("exception", result.Response);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(result.Error), "There is not message");
        }

        [TestMethod]
        public async Task Services_SearchResults()
        {
            var apiCall = new MockWebApiCall();

            var service = new SuperHeroService("", apiCall);

            var searchCriteria = "batman";

            var result = await service.SearchAsync(searchCriteria);

            Assert.IsFalse(result.Results is null, "No results");
            Assert.AreEqual<string>(searchCriteria, result.ResultsFor);
            Assert.AreEqual<string>(
                searchCriteria,
                result.Results[0].Name.ToLower()
            );
            Assert.AreEqual<string>(
                "Male",
                result.Results[0].Appearance.Gender
            );
        }

        [TestMethod]
        public async Task Services_DetailsResults()
        {
            var apiCall = new MockWebApiCall();

            var service = new SuperHeroService("", apiCall);

            var characterId = 644;

            var result = await service.GetDetailsAsync(characterId);

            Assert.IsFalse(result is null, "No result");
            Assert.AreEqual<int>(characterId, result.Id);
            Assert.AreEqual<string>("Male", result.Appearance.Gender);
            Assert.AreEqual<string>("good", result.Biography.Alignment);
        }
    }

    class SimpleResult : Gallery.Models.IResult
    {
        public string Error { get; set; }
        public string Response { get; set; }
    }

    class MockWebApiCall : WebApiCall
    {
        public override Task<string> GetContentAsync(string requestUri)
        {
            if (requestUri.Contains("batman"))
                return Task<string>.Run(() =>
                    "{\"response\":\"success\",\"results-for\":\"batman\",\"results\":[{\"id\":\"69\",\"name\":\"Batman\",\"powerstats\":{\"intelligence\":\"81\",\"strength\":\"40\",\"speed\":\"29\",\"durability\":\"55\",\"power\":\"63\",\"combat\":\"90\"},\"biography\":{\"full-name\":\"Terry McGinnis\",\"alter-egos\":\"No alter egos found.\",\"aliases\":[\"Batman II\",\"The Tomorrow Knight\",\"The second Dark Knight\",\"The Dark Knight of Tomorrow\",\"Batman Beyond\"],\"place-of-birth\":\"Gotham City, 25th Century\",\"first-appearance\":\"Batman Beyond #1\",\"publisher\":\"DC Comics\",\"alignment\":\"good\"},\"appearance\":{\"gender\":\"Male\",\"race\":\"Human\",\"height\":[\"5'10\",\"178 cm\"],\"weight\":[\"170 lb\",\"77 kg\"],\"eye-color\":\"Blue\",\"hair-color\":\"Black\"},\"work\":{\"occupation\":\"-\",\"base\":\"21st Century Gotham City\"},\"connections\":{\"group-affiliation\":\"Batman Family, Justice League Unlimited\",\"relatives\":\"Bruce Wayne (biological father), Warren McGinnis (father, deceased), Mary McGinnis (mother), Matt McGinnis (brother)\"},\"image\":{\"url\":\"https://www.superherodb.com/pictures2/portraits/10/100/10441.jpg\"}}]}"
                );

            return Task<string>.Run(() =>
                "{\"response\":\"success\",\"id\":\"644\",\"name\":\"Superman\",\"powerstats\":{\"intelligence\":\"94\",\"strength\":\"100\",\"speed\":\"100\",\"durability\":\"100\",\"power\":\"100\",\"combat\":\"85\"},\"biography\":{\"full-name\":\"Clark Kent\",\"alter-egos\":\"Superman Prime One-Million\",\"aliases\":[\"Clark Joseph Kent\",\"The Man of Steel\",\"the Man of Tomorrow\",\"the Last Son of Krypton\",\"Big Blue\",\"the Metropolis Marvel\",\"the Action Ace\"],\"place-of-birth\":\"Krypton\",\"first-appearance\":\"ACTION COMICS #1\",\"publisher\":\"Superman Prime One-Million\",\"alignment\":\"good\"},\"appearance\":{\"gender\":\"Male\",\"race\":\"Kryptonian\",\"height\":[\"6'3\",\"191 cm\"],\"weight\":[\"225 lb\",\"101 kg\"],\"eye-color\":\"Blue\",\"hair-color\":\"Black\"},\"work\":{\"occupation\":\"Reporter for the Daily Planet and novelist\",\"base\":\"Metropolis\"},\"connections\":{\"group-affiliation\":\"Justice League of America, The Legion of Super-Heroes (pre-Crisis as Superboy); Justice Society of America (pre-Crisis Earth-2 version); All-Star Squadron (pre-Crisis Earth-2 version)\",\"relatives\":\"Lois Lane (wife), Jor-El (father, deceased), Lara (mother, deceased), Jonathan Kent (adoptive father), Martha Kent (adoptive mother), Seyg-El (paternal grandfather, deceased), Zor-El (uncle, deceased), Alura (aunt, deceased), Supergirl (Kara Zor-El, cousin), Superboy (Kon-El/Conner Kent, partial clone)\"},\"image\":{\"url\":\"https://www.superherodb.com/pictures2/portraits/10/100/791.jpg\"}}"
            );
        }
    }
}
