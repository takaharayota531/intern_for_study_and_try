using System;
using FancyScrollView;

namespace FancyScrollView.TakaharaNext{


    class Context:FancyScrollRectContext
    {
        public int SelectedIndex = -1;
        public Action<int> OnCellClicked;

    }
}