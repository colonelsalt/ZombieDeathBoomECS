public interface IScoreComponent
{
    int pointsPerKill { get; }

    int currentScore { get; set; }
}