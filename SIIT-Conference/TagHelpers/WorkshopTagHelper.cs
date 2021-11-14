using Conference.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIIT_Conference.TagHelpers
{
    [HtmlTargetElement("workshops", Attributes = "[asp-for='WorkshopID']")]
    public class WorkshopTagHelper : TagHelper
    {
        private readonly IWorkshopService service;
        [HtmlAttributeName("asp-for")]
        public ModelExpression For { get; set; }
        public WorkshopTagHelper(IWorkshopService service)
        {
            this.service = service;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "select";
            output.Attributes.SetAttribute("id", For.Name);
            output.Attributes.SetAttribute("name", For.Name);

            var currentWorkshopId = For.Model == null ? 0 : (int)For.Model;

            var workshops = service.GetAllWorkshops().Where(x => x.Active);//var workshops=service.GetAllActiveWorkshops();

            TagBuilder defaultOption = new TagBuilder("option")
            {
                TagRenderMode = TagRenderMode.Normal
            };
            defaultOption.Attributes.Add("value", "");
            defaultOption.InnerHtml.Append("Please select a Workshop...");
            output.Content.AppendHtml(defaultOption);

            foreach (var workshop in workshops)
            {
                TagBuilder option = new TagBuilder("option")
                {
                    TagRenderMode = TagRenderMode.Normal
                };

                if (workshop.ID == currentWorkshopId)
                {
                    option.Attributes.Add("selected", "selected");
                }
                option.Attributes.Add("value", workshop.ID.ToString());
                option.InnerHtml.Append(workshop.Name);

                output.Content.AppendHtml(option);

            }
        }
    }
}
