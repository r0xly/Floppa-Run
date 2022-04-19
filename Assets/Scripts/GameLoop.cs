using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoop : MonoBehaviour
{
    private static GameState State = new GameState();
    public static float Speed => GameLoop.State.Speed;
    public static float Score => GameLoop.State.Score;
    public static float Health => GameLoop.State.Health;
    public static int MaxHealth => GameLoop.State.MaxHealth;
    public static bool Paused = true;

    void Awake()
    {
        Paused = true;
        State.Reset(); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Paused)
            Paused = false;

        if (Paused) return;
        GameLoop.State.Score += 0.0025f;
        GameLoop.State.Speed = Mathf.Clamp(GameLoop.State.Speed + 0.00001f, 0, 50);

        // Player died restart game
        if (GameLoop.State.Health <= 0)
            SceneManager.LoadScene((int)Scenes.Game);
    }

    public static void DamagePlayer()
    {
        // Removing 1 will remove 2, so I made it remove 0.5
        GameLoop.State.Health -= 0.5f;
    }

    public static void HealPlayer() {
        GameLoop.State.Health += 0.5f;
    }

}
