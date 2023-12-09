namespace ControleFinanceiro.MAUI.Extensions
{
    public static  class IUExtension
    {
        public static void OnClosePageClicked(this ContentPage content)
        {
            content.Navigation.PopModalAsync();
        }

        public static void PushModal<T>(this ContentPage contentPage) where T : ContentPage
        {
            var page = contentPage.Handler.MauiContext.Services.GetService<T>();
            contentPage.Navigation.PushModalAsync(page);
        }
    }
}

