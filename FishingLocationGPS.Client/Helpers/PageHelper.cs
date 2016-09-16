using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace FishingLocationGPS.Helpers
{
    public class PageHelper
    {
        public static List<T> GetLogicalChildCollection<T>(object parent) where T : DependencyObject
        {
            List<T> logicalCollection = new List<T>();
            GetLogicalChildCollection(parent as DependencyObject, logicalCollection);
            return logicalCollection;
        }

        private static void GetLogicalChildCollection<T>(DependencyObject parent, List<T> logicalCollection) where T : DependencyObject
        {
            int count = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < count; i++)
            {
                DependencyObject current = VisualTreeHelper.GetChild(parent, i);
                if ((current.GetType()).Equals(typeof(T)) || (current.GetType().GetTypeInfo().IsSubclassOf(typeof(T))))
                {
                    T asType = (T)current;
                    logicalCollection.Add(asType);
                }
                GetLogicalChildCollection<T>(current, logicalCollection);
            }
        }

        public static void SetControls(Grid currentPage, bool isEnabled)
        {
            List<Button> buttons = GetLogicalChildCollection<Button>(currentPage);
            List<TextBox> textBoxes = GetLogicalChildCollection<TextBox>(currentPage);

        }

        public static TResult GetObject<TResult>(Grid currentGrid) where TResult : class, new()
        {
            List<TextBox> textBoxes = GetLogicalChildCollection<TextBox>(currentGrid);

            var result = new TResult();
            var type = result.GetType();
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var property in properties)
            {
                object value = null;
                if (textBoxes.Any(item => item.Name == property.Name))
                {
                    value = textBoxes.First(item => item.Name == property.Name).Text;
                    if (property.PropertyType.IsGenericParameter && property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        var genericArgs = property.PropertyType.GetGenericArguments();
                        if (genericArgs.Length > 0)
                        {
                            value = Convert.ChangeType(value, genericArgs[0]);
                        }
                    }
                    else
                    {
                        value = Convert.ChangeType(value, property.PropertyType);
                    }
                    bool isPropertySet = false;
                    if (value != null)
                    {
                        if (property.PropertyType == typeof(Int16) || property.PropertyType == typeof(Int32) || property.PropertyType == typeof(Int64))
                        {
                            if (value is string)
                            {
                                if (property.CanWrite) property.SetValue(result, int.Parse(value as string), null);
                                isPropertySet = true;
                            }
                        }
                        else if (property.PropertyType == typeof(string))
                        {
                            if (property.CanWrite) property.SetValue(result, value.ToString(), null);
                            isPropertySet = true;
                        }
                        else if (property.PropertyType == typeof(bool))
                        {
                            if (value is Int16 || value is Int32 || value is Int64)
                            {
                                switch ((int)value)
                                {
                                    case 0:
                                        if (property.CanWrite) property.SetValue(result, false, null);
                                        isPropertySet = true;
                                        break;
                                    case 1:
                                        if (property.CanWrite) property.SetValue(result, true, null);
                                        isPropertySet = true;
                                        break;
                                    default:
                                        throw new Exception("Cannot convert int " + value + " to bool");
                                }
                            }
                            else
                            {
                                if (property.CanWrite) property.SetValue(result, bool.Parse(value.ToString()), null);
                                isPropertySet = true;
                            }
                        }
                        else if (property.PropertyType == typeof(char) || property.PropertyType == typeof(char?))
                        {
                            if (property.CanWrite) property.SetValue(result, char.Parse(value.ToString()), null);
                            isPropertySet = true;
                        }
                    }
                    if (isPropertySet == false)
                    {
                        var attributes = property.GetCustomAttributes(true);
                        if (attributes != null && attributes.Count() > 0)
                        {
                            if (property.CanWrite) property.SetValue(result, value, null);
                        }
                        else
                        {
                            if (property.CanWrite) property.SetValue(result, value, null);
                        }

                    }
                }
            }

            return result;
        }

        public static bool ValidateObject(object obj)
        {
            var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            var context = new ValidationContext(obj, serviceProvider: null, items: null);
            var isValid = Validator.TryValidateObject(obj, context, results);

            if (!isValid)
            {
                var formattedError = "";
                foreach (var error in results)
                {
                    formattedError += error.ErrorMessage + "\n";
                }
                //MessageBox.Show(formattedError, "Errors");
            }

            return isValid;
        }
    }
}
