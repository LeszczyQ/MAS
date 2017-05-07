using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASTEST
{
    public interface IMonitor
    {
        bool WsparcieMST { get; set; }
        bool Dotykowy { get; set; }
        bool Lcd3D { get; set; }
        double RozmiarMatrycy { get; set; }
        string RozdzielczoscMatrycy { get; set; }

    }
}
