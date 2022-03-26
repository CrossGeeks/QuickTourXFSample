using System.Collections.Generic;
using System.Linq;
using QuickTourXFSample.Views.QuickTourSteps;

namespace QuickTourXFSample
{
    public class QuickTourBuilder<T>
        where T : BaseQuickTourPage, IQuickTourLauncher, new()
    {
        public static QuickTourBuilder<T> Initialize()
            => new QuickTourBuilder<T>(new T());

        public QuickTourBuilder<T> Next(BaseQuickTourPage page)
        {
            _pages.Last().NextPage = page;

            AddPage(page);

            return this;
        }

        public IQuickTourLauncher Build()
         => _pages.Select(page =>
                         {
                             page.TotalSteps = _pages.Count;
                             return page;
                         })
                  .ToList()
                  .OfType<IQuickTourLauncher>()
                  .First();

        private QuickTourBuilder(T initialPage) => AddPage(initialPage);

        private void AddPage(BaseQuickTourPage page)
        {
            _pages ??= new List<BaseQuickTourPage>();

            _pages.Add(page);

            page.ActualStep = _pages.Count;
        }

        private IList<BaseQuickTourPage> _pages;
    }
}
