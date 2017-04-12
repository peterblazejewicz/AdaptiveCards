﻿using System.Windows;
using AdaptiveCards.Rendering;
#if WPF
using System.Windows.Controls;
#elif XAMARIN
using Xamarin.Forms;
#endif

namespace AdaptiveCards.Rendering
{
    public partial class XamlRenderer
        : AdaptiveRenderer<FrameworkElement, RenderContext>
    {
        /// <summary>
        /// Input.Date
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        protected override FrameworkElement Render(InputDate input, RenderContext context)
        {
            if (context.Options.AdaptiveCard.SupportsInteractivity)
            {
                var textBox = new TextBox() { Text = input.Value };
                textBox.Text = input.Placeholder;
                textBox.Style = this.GetStyle($"Adaptive.Input.Text.Date");
                textBox.DataContext = input;
                context.InputControls.Add(textBox);
                return textBox;
            }
            else
            {
                Container container = new Container() { Separation = input.Separation };
                container.Items.Add(new TextBlock() { Text = GetFallbackText(input) ?? input.Placeholder });
                if (input.Value != null)
                {

                    container.Items.Add(new TextBlock()
                    {
                        Text = input.Value,
                        Color = TextColor.Accent,
                        Wrap = true
                    });
                }
                return Render(container, context);
            }
        }
    }
}