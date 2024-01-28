using System;
using Extensions;
using Enums;
using UnityEngine.Events;

namespace Signals
{
    public class CoreGameSignals : MonoSingleton<CoreGameSignals>
    {
        public Func<float> OnGetLaughMeter = () => 0;
        public UnityAction<GainOrLose, short> OnChangeHealth = delegate {  };
        public UnityAction<GameStates> OnChangingGameStates = delegate {  };
        public Func<LaughMeterLevels> OnGetLaughMeterLevels = () => LaughMeterLevels.Easy;
        public UnityAction<float> OnIncreaseLaughMeter = delegate {  };
        public UnityAction OnChangeSprite = delegate {  };
        public Func<int> OnGetRingCount = () => 0;
        public UnityAction OnChangeFace = delegate {  };
        public UnityAction OnChangeHealthIcon = delegate {  };
        public Func<short> OnGetHealth = () => 0;
        public UnityAction OnHitPlayer = delegate {  };
        public Func<bool> OnGetHit = () => false;
        public Func<int> OnGetScore = () => 0;
        public UnityAction<int> OnIncreaseScore = delegate {  };
    }
}
