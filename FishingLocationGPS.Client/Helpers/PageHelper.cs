using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace FishingLocationGPS.Client.Helpers
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
            List<Control> controls = GetLogicalChildCollection<Control>(currentGrid);

            if (controls.Any(item => item.Name.Contains("_")))
            {
                var changeNameList = controls.Where(item => item.Name.Contains("_"));
                
                foreach (var changeNameControl in changeNameList)
                {
                    controls.First(item => item.Name == changeNameControl.Name).Name = changeNameControl.Name.Split('_')[1];                  
                }
            }

            var result = new TResult();
            var type = result.GetType();
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var property in properties)
            {
                object value = null;
                if (controls.Any(item => item.Name == property.Name))
                {
                    var control = controls.First(item => item.Name == property.Name);
                    if (control is TextBox)
                    {
                        var textBox = (TextBox)control;
                        value = textBox.Text;
                    }
                    else if (control is CalendarDatePicker)
                    {
                        var datePicker = (CalendarDatePicker)control;
                        value = datePicker.Date;
                    }
                    else if (control is DatePicker)
                    {
                        var datePicker = (DatePicker)control;
                        value = datePicker.Date;
                    }

                    if (property.PropertyType == typeof(String))
                    {
                        try
                        {
                            value = value.ToString().Trim();
                        }
                        catch (Exception ex)
                        {
                            value = "";
                        }
                    }
                    else if (property.PropertyType == typeof(DateTime))
                    {
                        try
                        {
                            DateTime outValue = new DateTime();
                            bool isDate = DateTime.TryParse(value.ToString(), out outValue);
                            if (isDate == true)
                            {
                                value = outValue;
                            }
                        }
                        catch (Exception ex)
                        {
                            value = new DateTime();
                        }
                    }
                    else if (property.PropertyType == typeof(DateTime?))
                    {
                        try
                        {
                            DateTime outValue = new DateTime();
                            bool isValid = DateTime.TryParse(value.ToString(), out outValue);
                            if (isValid == true)
                            {
                                value = outValue;
                            }
                        }
                        catch (Exception ex)
                        {
                            value = null;
                        }
                    }
                    else if (property.PropertyType == typeof(int))
                    {
                        try
                        {
                            int outValue = 0;
                            bool isValid = int.TryParse(value.ToString(), out outValue);
                            if (isValid == true)
                            {
                                value = outValue;
                            }
                        }
                        catch (Exception ex)
                        {
                            value = 0;
                        }
                    }
                    else if (property.PropertyType == typeof(int?))
                    {
                        try
                        {
                            int outValue = 0;
                            bool isValid = int.TryParse(value.ToString(), out outValue);
                            if (isValid == true)
                            {
                                value = outValue;
                            }
                        }
                        catch (Exception ex)
                        {
                            value = null;
                        }
                    }
                    else if (property.PropertyType == typeof(Decimal))
                    {
                        try
                        {
                            Decimal outValue = 0;
                            bool isDate = Decimal.TryParse(value.ToString(), out outValue);
                            if (isDate == true)
                            {
                                value = outValue;
                            }
                        }
                        catch (Exception ex)
                        {
                            value = 0;
                        }
                    }
                    else if (property.PropertyType == typeof(Decimal?))
                    {
                        try
                        {
                            Decimal outValue = 0;
                            bool isDate = Decimal.TryParse(value.ToString(), out outValue);
                            if (isDate == true)
                            {
                                value = outValue;
                            }
                        }
                        catch (Exception ex)
                        {
                            value = null;
                        }
                    }
                    if (property.CanWrite == true)
                    {
                        property.SetValue(result, value, null);
                    }
                }
            }       
            
            return result;
        }

        public static async Task<bool> ValidateObject(object obj)
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
                var dailog = new MessageDialog(formattedError);
                await dailog.ShowAsync();
            }

            return isValid;
        }
    }
}
