using Microsoft.AspNetCore.Mvc;
using Stimulsoft.Report;
using Stimulsoft.Report.Angular;
using Stimulsoft.Report.Web;

namespace ConcertTicket.Controllers;

public class PrintTicket
{
    [Controller]
    public class ViewerController : Controller

    {
        [HttpPost]
        public IActionResult InitViewer()

        {
            var requestParams = StiAngularViewer.GetRequestParams(this);

            var options = new StiAngularViewerOptions();

            options.Actions.ViewerEvent = "ViewerEvent";

            return StiAngularViewer.ViewerDataResult(requestParams, options);
        }


        [HttpPost]
        public IActionResult ViewerEvent()

        {
            var requestParams = StiAngularViewer.GetRequestParams(this);


            if (requestParams.Action == StiAction.GetReport)

            {
                var report = StiReport.CreateNewReport();

                var path = StiAngularHelper.MapPath(this, $"Reports/MasterDetail.mrt");

                report.Load(path);

                return StiAngularViewer.GetReportResult(this, report);
            }


            return StiAngularViewer.ProcessRequestResult(this);
        }
    }
}