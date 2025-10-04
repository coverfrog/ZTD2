public interface ITimerCallback
{
    void OnTimerBegin(float currentSec, float targetSec);
    void OnTimerProgress(float currentSec, float targetSec);
    void OnTimerComplete(float currentSec, float targetSec);
}