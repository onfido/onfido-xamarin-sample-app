using Android.App;
using Android.Widget;
using Android.OS;
using Com.Onfido.Android.Sdk.Capture;
using Com.Onfido.Android.Sdk.Capture.UI.Options;
using Com.Onfido.Android.Sdk.Capture.UI.Camera.Face;
using Com.Onfido.Api.Client.Data;

namespace OnfidoSDKSampleApp
{
    [Activity(Label = "OnfidoSDKSampleApp", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            FlowStep[] steps = { FlowStep.CaptureDocument, new FaceCaptureStep(FaceCaptureVariant.Video) };

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            IOnfido client = OnfidoFactory.Create(this).Client;
            Applicant applicant = Applicant.InvokeBuilder().WithFirstName("Dummy").WithLastName("Dummy").Build();
            OnfidoConfig config = OnfidoConfig.InvokeBuilder()
                .WithApplicant(applicant)
                .WithToken("TOKEN")
                .WithCustomFlow(steps)
                .Build();
            client.StartActivityForResult(this, 1, config);
        }
    }
}

