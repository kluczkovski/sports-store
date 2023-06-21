using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using SportsStore.WebApp.Models.ViewModels;

namespace SportsStore.WebApp.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper 
    {
        private readonly IUrlHelperFactory _urlHelperFactory;

        public PageLinkTagHelper(IUrlHelperFactory helperFactory)
        {
            _urlHelperFactory = helperFactory;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext?  ViewContext { get; set; }

        public PagingInfoViewModel? PageModel { get; set; }

        public string? PageAction { get; set; }

        public bool PageClassesEnabled { get; set; } = false;

        public string PageClass { get; set; } = String.Empty;

        public string PageClassNormal { get; set; } = String.Empty;

        public string PageClassSelected { get; set; } = String.Empty;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (ViewContext != null && PageModel != null)
            {
                var urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);

                var result = new TagBuilder("div");

                for(int i = 1; i <= PageModel.TotalPage; i++)
                {
                    var tag = new TagBuilder("a");
                    tag.Attributes["href"] = urlHelper.Action(PageAction, new { productPage = i });
                    if (PageClassesEnabled)
                    {
                        tag.AddCssClass(PageClass);
                        tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                    }
                    tag.InnerHtml.Append(i.ToString());
                    result.InnerHtml.AppendHtml(tag);
                }

                output.Content.AppendHtml(result.InnerHtml);
            }
        }
    }
}

