namespace PageObjectPattert.Lection.Tests;

public class UploadDownloadFileTests : BaseTest
{
    [Test]
    public void DownloadTest()
    {
        // Click on download button/icon
        
        // assert that is fail is downloaded
        FileAssert.Exists(new FileInfo("my path to file"));
    }
}