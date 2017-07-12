using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Behaviors;
using Prism.Navigation;
using TheBooth.ViewModels;
using Xamarin.Forms;

namespace TheBooth.Common
{
    public class PageAppearingBehavoir : Behavior<TabbedPage>
    {
        public static readonly BindableProperty CommandProperty =
          BindableProperty.Create<PageAppearingBehavoir, ICommand>(x => x.Command, null);
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }



        protected override void OnAttachedTo(TabbedPage bindable)
        {

            bindable.Appearing += bindable_OnAppearing;
            base.OnAttachedTo(bindable);
        }

        private void bindable_OnAppearing(object sender, EventArgs e)
        {
            var context = (sender as TabbedPage).BindingContext as BaseViewModel;
            if (context != null)
            {

            }
            //if (Command != null)
            //{
            //    Command.Execute(null);
            //}
        }


        protected override void OnDetachingFrom(TabbedPage bindable)
        {
            bindable.Appearing -= bindable_OnAppearing;
            base.OnDetachingFrom(bindable);
        }
    }

    public class ContentPageAppearingBehavoir : Behavior<ContentPage>
    {
        public static readonly BindableProperty CommandProperty =
          BindableProperty.Create<ContentPageAppearingBehavoir, ICommand>(x => x.Command, null);
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }



        protected override void OnAttachedTo(ContentPage bindable)
        {

            bindable.Appearing += bindable_OnAppearing;
            base.OnAttachedTo(bindable);
        }

        private void bindable_OnAppearing(object sender, EventArgs e)
        {
            var context = (sender as ContentPage).BindingContext as BaseViewModel;
            if (context != null)
            {
                
            }
                //context.Refresh();
            //if (Command != null)
            //{
            //    Command.Execute(null);
            //}
        }


        protected override void OnDetachingFrom(ContentPage bindable)
        {
            bindable.Appearing -= bindable_OnAppearing;
            base.OnDetachingFrom(bindable);
        }
    }


    public class BehaviorBase<T> : Behavior<T> where T : BindableObject
    {
        public T AssociatedObject { get; private set; }

        protected override void OnAttachedTo(T bindable)
        {
            base.OnAttachedTo(bindable);

            AssociatedObject = bindable;
            if (bindable.BindingContext != null)
            {
                BindingContext = bindable.BindingContext;
            }
            bindable.BindingContextChanged += OnBindingContextChanged;
        }

        protected override void OnDetachingFrom(T bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.BindingContextChanged -= OnBindingContextChanged;
        }

        void OnBindingContextChanged(object sender, EventArgs e)
        {
            OnBindingContextChanged();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            BindingContext = AssociatedObject.BindingContext;
        }
    }

    public interface IMultiPageNavigationAware
    {
        void OnInternalNavigatedFrom(NavigationParameters parameters);
        void OnInternalNavigatedTo(NavigationParameters parameters);
    }
    public class MultiPageNavigationBehavior : BehaviorBase<MultiPage<Page>>
    {
        private Page _lastSelectedPage;
        protected override void OnAttachedTo(MultiPage<Page> bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.CurrentPageChanged += CurrentPageChangedHandler;
        }

        protected override void OnDetachingFrom(MultiPage<Page> bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.CurrentPageChanged -= CurrentPageChangedHandler;
        }


        private void CurrentPageChangedHandler(object sender, EventArgs e)
        {
            NavigationParameters parameters = new NavigationParameters();
            if (_lastSelectedPage != null)
            {
                var lastPageContextAware = _lastSelectedPage.BindingContext as IMultiPageNavigationAware;
                lastPageContextAware.OnInternalNavigatedFrom(parameters);
            }
            var newPageContextAware = AssociatedObject.CurrentPage.BindingContext as IMultiPageNavigationAware;
            newPageContextAware.OnInternalNavigatedTo(parameters);

            _lastSelectedPage = AssociatedObject.CurrentPage;
        }
    }
}
