using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

var path = args[0];
var jsonStr = File.ReadAllText(path);

var json = JsonConvert.DeserializeObject<AppSettingsRoot>(jsonStr);

var cdAppSettings = new List<CdAppsetting>();

foreach (var item in json.Values)
{
    Console.WriteLine(item.Key + ": " + item.Value);
    cdAppSettings.Add(new CdAppsetting()
    {
        name = item.Key,
        value = item.Value.ToString(),
    });
}

File.WriteAllText("app-settings.json", JsonConvert.SerializeObject(cdAppSettings));

Console.ReadLine();

class AppSettingsRoot
{
    public bool IsEncrypted { get; set; }
    public JObject Values { get; set; }
}

class CdAppsetting
{
    public string name { get; set; }
    public string value { get; set; }
}