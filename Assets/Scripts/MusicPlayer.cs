using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private void Awake()
    {
        var numMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;
        if (numMusicPlayers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
