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
    [HtmlTargetElement("speakers",Attributes ="[asp-for='SpeakerID']")]
    public class SpeakerTagHelper : TagHelper
    {
        private readonly ISpeakerService service;
        [HtmlAttributeName("asp-for")]
        public ModelExpression For { get; set; }
        public SpeakerTagHelper(ISpeakerService service)
        {
            this.service = service;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "select";
            output.Attributes.SetAttribute("id", For.Name);
            output.Attributes.SetAttribute("name", For.Name);

            var currentSpeakerId = For.Model == null ? 0 : (int)For.Model;

            var speakers = service.GetAllSpeakers().Where(x => x.Active);//var speakers=service.GetAllActiveSpeakers();

            TagBuilder defaultOption = new TagBuilder("option")
            {
                TagRenderMode = TagRenderMode.Normal
            };
            defaultOption.Attributes.Add("value", "");
            defaultOption.InnerHtml.Append("Please select a Speaker...");
            output.Content.AppendHtml(defaultOption);

            foreach (var speaker in speakers)
            {
                TagBuilder option = new TagBuilder("option")
                {
                    TagRenderMode = TagRenderMode.Normal
                };

                if (speaker.ID == currentSpeakerId)
                {
                    option.Attributes.Add("selected", "selected");
                }
                option.Attributes.Add("value", speaker.ID.ToString());
                option.InnerHtml.Append(speaker.FullName);

                output.Content.AppendHtml(option);

            }
        }



    }
}
