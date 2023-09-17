[System.Serializable]
public class GameData
{
    public int nowScore;
    public int bestScore;
    public bool[] isOpenedEnding = new bool[11];

    private void Awake()
    {
        Reset();
    }

    public void Reset()
    {
        nowScore = 0;
        bestScore = 0;
        for (int i = 0; i < 11; i++)
            isOpenedEnding[i] = false;
    }


}
