using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Merriweather.Helpers
{
    public static class HtmlHelpers
    {
        public static string Truncate(this HtmlHelper helper, string input, int length)
        {
            if (input.Length <= length)
            {
                return input;
            }
            else
            {
                return input.Substring(0, length) + "...";
            }
        }

        public static HtmlString CheckBoxList<T, TModel, TValue, TText>(this HtmlHelper<TModel> helper,
            string listName, string valueProperty,
            string textProperty,
            Dictionary<T, bool> checkedList,
            Func<T, TValue> value,
            Func<T, TText> text)
        {
            var builder = new StringBuilder();
            for (int i = 0; i < checkedList.Count; i++)
            {
                T item = checkedList.Keys.ToList()[i];
                builder.AppendLine("<p>");
                builder.AppendLine(
                    helper.Hidden(listName + "[" + i + "].Key." + valueProperty, value(item)).ToHtmlString());
                builder.AppendLine(
                    helper.Hidden(listName + "[" + i + "].Key." + textProperty, text(item)).ToHtmlString());
                builder.AppendLine(helper.CheckBox(listName + "[" + i + "].Value", checkedList[item]).ToHtmlString());
                builder.AppendLine(text(item).ToString());
                builder.AppendLine("</p>");
            }
            return new HtmlString(builder.ToString());
        }
    }
}
