using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace DocNanzDCMS
{
    public class AttachedProperties : DependencyObject
    {
        public static readonly DependencyProperty MenuStateProperty = DependencyProperty.RegisterAttached("MenuState", typeof(Visibility), typeof(AttachedProperties), new FrameworkPropertyMetadata(Visibility.Collapsed));

        public static void SetMenuState(DependencyObject element, Visibility value)
        {
            element.SetValue(MenuStateProperty, value);
        }

        public static Visibility GetMenuState(DependencyObject element)
        {
            return (Visibility)element.GetValue(MenuStateProperty);
        }

        public static readonly DependencyProperty IconProperty = DependencyProperty.RegisterAttached("Icon", typeof(ImageSource), typeof(AttachedProperties), new FrameworkPropertyMetadata(new ImageBrush().ImageSource));

        public static void SetIcon(DependencyObject element, ImageSource value)
        {
            element.SetValue(IconProperty, value);
        }

        public static ImageSource GetIcon(DependencyObject element)
        {
            return (ImageSource)element.GetValue(IconProperty);
        }

        public static readonly DependencyProperty LabelProperty = DependencyProperty.RegisterAttached("Label", typeof(String), typeof(AttachedProperties), new FrameworkPropertyMetadata(""));

        public static void SetLabel(DependencyObject element, String value)
        {
            element.SetValue(LabelProperty, value);
        }

        public static String GetLabel(DependencyObject element)
        {
            return (String)element.GetValue(LabelProperty);
        }

        public static readonly DependencyProperty ErrorProperty = DependencyProperty.RegisterAttached("Error", typeof(String), typeof(AttachedProperties), new FrameworkPropertyMetadata(""));

        public static void SetError(DependencyObject element, String value)
        {
            element.SetValue(ErrorProperty, value);
        }

        public static String GetError(DependencyObject element)
        {
            return (String)element.GetValue(ErrorProperty);
        }
    }
}
