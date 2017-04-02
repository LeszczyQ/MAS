using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASTEST
{
    interface IMonitor
    {
        bool WsparcieMST();
        bool Dotykowy();
        double RozmiarMatrycy();
        string RozdzielczoscMatrycy();
        bool Lcd3D();


    }
}
