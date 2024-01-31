using Extensions;
using UnityEngine.Events;

namespace Signals
{
    public class SoundSignals : MonoSingleton<SoundSignals>{
    
        public UnityAction OnMilkSound = delegate {  };
        public UnityAction OnPutToy = delegate {  };
    }
}
