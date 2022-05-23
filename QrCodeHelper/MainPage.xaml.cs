using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Media;
using QrCodeHelper.ViewModels;

namespace QrCodeHelper;

public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    private async void OnCounterClicked(object sender, EventArgs e)
    {
        var result = await PickAndShow(PickOptions.Images);

        if (result is null)
            return;

        image.Source = result.FullPath;
        var stream = System.IO.File.Open(result.FullPath, System.IO.FileMode.Open);
        using (var skiaImage = SkiaSharp.SKBitmap.Decode(stream))
        {
            var skiaReader = new ZXing.SkiaSharp.BarcodeReader();
            var skiaResult = skiaReader.Decode(skiaImage);
            qrResult.Text = skiaResult?.Text ?? "未识别到结果！";
        }

        SemanticScreenReader.Announce(CounterBtn.Text);
    }

    async Task<FileResult> PickAndShow(PickOptions options)
    {
        try
        {
            var result = await FilePicker.PickAsync(options);

            return result;
        }
        catch
        {
            // The user canceled or something went wrong
        }

        return null;
    }
}

