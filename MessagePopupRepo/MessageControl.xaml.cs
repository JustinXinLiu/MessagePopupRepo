using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MessagePopupRepo
{
    public sealed partial class MessageControl : UserControl
    {
        public MessageControl()
        {
            InitializeComponent();
        }

        public string Message
        {
            get => (string)GetValue(MessageProperty);
            set => SetValue(MessageProperty, value);
        }
        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(MessageControl), new PropertyMetadata(string.Empty));

        public bool IsOpened
        {
            get => (bool)GetValue(IsOpenedProperty);
            set => SetValue(IsOpenedProperty, value);
        }
        public static readonly DependencyProperty IsOpenedProperty =
            DependencyProperty.Register("IsOpened", typeof(bool), typeof(MessageControl), new PropertyMetadata(false, (s, e) =>
            {
                var self = (MessageControl)s;
                var isOpened = (bool)e.NewValue;

                if (isOpened)
                {
                    self.ShowAnimation.Begin();
                }
                else
                {
                    self.HideAnimation.Begin();
                }
            }));

    }
}
