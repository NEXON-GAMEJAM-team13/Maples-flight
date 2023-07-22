[System.Serializable]
public class GameData
{
    public int nowScore;
    public int bestScore;

    private void Awake()
    {
        Reset();
    }

    public void Reset()
    {
        nowScore = 0;
        bestScore = 0;
    }


}
