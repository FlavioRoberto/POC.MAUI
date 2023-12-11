using ControleFinanceiro.Domain.BuildingBlocks.Interfaces;

namespace ControleFinanceiro.MAUI.Extensions
{
    public static  class IUExtension
    {
        public static void PushModal<T>(this ContentPage contentPage) where T : ContentPage
        {
            var page = contentPage.Handler.MauiContext.Services.GetService<T>();
            contentPage.Navigation.PushModalAsync(page);
        }

        public static void PushModal<Page,Data>(this ContentPage contentPage, Data content) where Page : ContentPage, ContentPageWithData<Data>
        {
            var page = contentPage.Handler.MauiContext.Services.GetService<Page>();
            page.SetData(content);
            contentPage.Navigation.PushModalAsync(page);
        }
    }
}

