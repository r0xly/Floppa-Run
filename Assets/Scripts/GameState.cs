public class GameState {
    public float Health;
    public float Score;
    public readonly int MaxHealth; 
    public float Speed;
    private readonly float InitialSpeed;

    public GameState(float speed = 7.8f, int maxHealth = 3) {
        this.Score = 0;
        this.MaxHealth = maxHealth;
        this.Health = maxHealth;
        this.Speed = speed;
        this.InitialSpeed = speed; 
    }

    public void Reset() {
        this.Score = 0;
        this.Health = this.MaxHealth;
        this.Speed = this.InitialSpeed;
    }
}