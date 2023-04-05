namespace JulietsStore.Infra;

[HtmlTargetElement("div", Attributes = "page-model")]
public class PageLinkTagHelper : TagHelper
{
    private readonly IUrlHelperFactory _factory;
    public PageLinkTagHelper(IUrlHelperFactory factory)
    {
        _factory = factory;
    }
    [ViewContext, HtmlAttributeNotBound]
    public ViewContext? ViewContext { get; set; } = new ViewContext();
    public PagingInfoViewModel? PageModel { get; set; }
    public string? PageAction { get; set; }
    [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
    public IDictionary<string, object> PageUrlValues { get; set; } = new Dictionary<string, object>();
    public bool PageClassesEnabled { get; set; } = false;
    public string PageClass { get; set; } = string.Empty;
    public string PageClassNormal { get; set; } = string.Empty;
    public string PageClassSelected { get; set; } = string.Empty;
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        if (ViewContext != null && PageModel != null)
        {
            var urlHelper = _factory.GetUrlHelper(ViewContext);
            var result = new TagBuilder("div");
            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                var tag = new TagBuilder("a");
                PageUrlValues["productPage"] = i;
                tag.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);
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