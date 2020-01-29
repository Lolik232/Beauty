using Beauty.WPF.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beauty.WPF.Interfaces
{
    public interface IView
    {
        ViewAnimations ViewLoadAnimation { get; set; }
        ViewAnimations ViewUnloadAnimation { get; set; }
        float AnimationTime { get; set; }
        bool ShouldAnimateOut { get; set; }
        object ViewModelObject { get; set; }
        Task AnimateInAsync();
        Task AnimateOutAsync();
    }
}
