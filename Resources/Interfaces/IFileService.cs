namespace Resources.Interfaces;

public interface IFileService
{
    bool SaveToFile(string content);
    string GetFromFile();

}
