namespace POC.MAUI.Base
{
    public static  class  PopUpExtension
    {
        public static void OnClosePageClicked(this ContentPage content)
        {
            content.Navigation.PopModalAsync();
        }
    }
}

