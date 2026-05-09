using System.IO;
using BibleReader.Core.Models;

namespace BibleReader.Data.Services;

public class BibleService
{
    private readonly EstherLoader _estherLoader;

    public BibleService(string dataRoot)
    {
        var estherPath = Path.Combine(dataRoot, "OT", "kjv_esther.txt");
        _estherLoader = new EstherLoader(estherPath);
    }

    public Book LoadEsther()
    {
        return _estherLoader.Load();
    }
}
