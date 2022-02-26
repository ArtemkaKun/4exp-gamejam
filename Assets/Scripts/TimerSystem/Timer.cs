using System;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEngine;

namespace TimerSystem
{
    public class Timer : MonoBehaviour
    {
        public event Action OnTimerEnd;

        [field: SerializeField]
        private int TimeInSeconds { get; set; }
        [field: SerializeField]
        private int StepInSeconds { get; set; }
        [field: SerializeField]
        private TimerView View { get; set; }
        [field: SerializeField]
        private float InitialNumberOfYears { get; set; }
        [field: SerializeField]
        private float SecondsPerYear { get; set; }

        [Button]
        public void StartTimer()
        {
            TimerProcess().Forget();
        }

        private void Awake()
        {
            View.SetLeftTime(TimeSpan.FromSeconds(TimeInSeconds));
        }

        private async UniTaskVoid TimerProcess()
        {
            int leftTime = TimeInSeconds;
            View.SetLeftTime(TimeSpan.FromSeconds(leftTime));
            View.SetYears(CountYears(leftTime));
            View.ChangeTimerTextVisibility(true);

            while (leftTime > 0)
            {
                await UniTask.Delay(TimeSpan.FromSeconds(StepInSeconds));
                leftTime -= StepInSeconds;
                View.SetLeftTime(TimeSpan.FromSeconds(leftTime));
            }

            View.SetLeftTime(TimeSpan.Zero);
            View.SetYears(InitialNumberOfYears);
            OnTimerEnd?.Invoke();
            View.ChangeTimerTextVisibility(false);
        }

        private float CountYears(int leftTime)
        {
            return InitialNumberOfYears + Mathf.Floor((TimeInSeconds - leftTime) / SecondsPerYear);
        }
    }
}