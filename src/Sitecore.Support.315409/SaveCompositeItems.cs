namespace Sitecore.Support.XA.Feature.Composites.EventHandlers
{
    using Sitecore.XA.Foundation.Presentation.Layout;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class SaveCompositeItems : Sitecore.XA.Feature.Composites.EventHandlers.SaveCompositeItems
    {
        protected override IList<RenderingModel> GetRenderingsFromCompositeSection(RenderingModel compositeRendering, int sectionIndex, IEnumerable<RenderingModel> injectedCompositeRenderings)
        {
            sectionIndex = sectionIndex + 1;
            string dPhId = GetDynamicPlaceholderId(compositeRendering);
            var renderingPattern = $"{compositeRendering.Placeholder}/{Sitecore.XA.Feature.Composites.Constants.CompositePlaceholderPattern}+-{sectionIndex}-{dPhId}";
            var renderings = injectedCompositeRenderings
                .Where(r => Regex.IsMatch(r.Placeholder, renderingPattern))
                .ToList();
            return renderings;
        }
    }
}