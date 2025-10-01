public interface ITimerCallback
{
    void OnTimerProgress(double currentSec, double targetSec);
    void OnTimerComplete(double currentSec, double targetSec);
}