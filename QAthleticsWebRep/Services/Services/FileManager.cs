using QAthleticsWebRep.Services.IServices;

namespace QAthleticsWebRep.Services.Services
{
    public class FileManager: IFileManager
    {
        private string baseUrl = "https://stgqafplayers.blob.core.windows.net/conqafresults";
        private string sasToken = "sp=racwdl&st=2024-12-09T17:59:43Z&se=2030-12-31T01:59:43Z&spr=https&sv=2022-11-02&sr=c&sig=Ui5qWxeNbNwPMoV1prw%2FVf5uxliaIH1hvIJDgc62S6g%3D";

        public string GetImageUrl(string imagePath)
        {
			return $"{baseUrl}/{imagePath}?{sasToken}&cacheBust={DateTime.UtcNow.Ticks}";
		}
    }
}
