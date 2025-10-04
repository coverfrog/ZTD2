public interface ITimerCallback
{
    void OnTimerProgress(float currentSec, float targetSec);
    void OnTimerComplete(float currentSec, float targetSec);
}