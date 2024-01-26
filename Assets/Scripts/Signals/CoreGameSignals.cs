using System;
using Extensions;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class CoreGameSignals : MonoSingleton<CoreGameSignals>
    {
        public Func<float> OnGetLaughMeter = () => 0;
    }
}
