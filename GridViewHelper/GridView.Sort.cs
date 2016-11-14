using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace GridViewHelper
{
    public enum SortIconTypes
    {
        NONE,
        ASCENDING,
        DESCENDING,
    }

    public class SortType
    {
        public String Icon_Text { get; set; }
        public String Icon_Name { get; set; }
    }

    public static class GridView_Sort
    {
        public static List<GridViewHelper.SortType> SortTypes { get; set; }

        public static void LoadSortTypes()
        {
            SortTypes = new List<SortType>();
            var sortNone = new SortType() { Icon_Name = SortIconTypes.NONE.ToString(), Icon_Text = "\xE8CB" };
            var sortAsc = new SortType() { Icon_Name = SortIconTypes.ASCENDING.ToString(), Icon_Text = "\xE110" };
            var sortDesc = new SortType() { Icon_Name = SortIconTypes.DESCENDING.ToString(), Icon_Text = "\xE1FD" };
            SortTypes.Add(sortNone);
            SortTypes.Add(sortAsc);
            SortTypes.Add(sortDesc);
        }

        public static SortIconTypes SortChanged(ref TextBlock iconBlock, ref GridView grid)
        {
            var iconText = iconBlock.Text;
            var strSortTypeName = SortTypes.First(item => item.Icon_Text == iconText).Icon_Name;
            SortIconTypes currentIconType;
            Enum.TryParse(strSortTypeName, out currentIconType);
            switch (currentIconType)
            {
                case SortIconTypes.NONE:
                    iconBlock.Text = SortTypes
                        .First(item => item.Icon_Name == SortIconTypes.ASCENDING.ToString())
                        .Icon_Text;
                    currentIconType = SortIconTypes.ASCENDING;
                    break;
                case SortIconTypes.ASCENDING:
                    iconBlock.Text = SortTypes
                        .First(item => item.Icon_Name == SortIconTypes.DESCENDING.ToString())
                        .Icon_Text;
                    currentIconType = SortIconTypes.DESCENDING;
                    break;
                case SortIconTypes.DESCENDING:
                    iconBlock.Text = SortTypes
                        .First(item => item.Icon_Name == SortIconTypes.NONE.ToString())
                        .Icon_Text;
                    currentIconType = SortIconTypes.NONE;
                    break;
            }
            
            return currentIconType;
        }

    }
}
