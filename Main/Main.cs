using Godot;

public partial class Main : Node2D
{
    private int _score = 0;
    private int _lifeCount = 6;
    private Vector2 _screenSize;
    private Hud _hud;
    private Ball _ball;
    private BrickGrid _brickGrid;
    private int _round = 1;
    
    public override void _Ready()
    {
        _hud = GetNode<Hud>("Hud");
        _brickGrid = GetNode<BrickGrid>("BrickGrid");
        _ball = GetNode<Ball>("Ball");
        _screenSize = GetViewportRect().Size;
        _hud.UpdateLifeCount(_lifeCount);
    }

    public async override void _Process(double delta)
    {
        if(_ball.Position.Y > _screenSize.Y & _lifeCount > 0)
        {
            DecreaseLifeCount();
            if(_lifeCount > 0)
            {
                _ball.Serve();
            }
            _ball.SetIsFollowing(true);
        }
    }

    public void DecreaseLifeCount()
    {
        _lifeCount -= 1;
        _hud.UpdateLifeCount(_lifeCount);
        if(_lifeCount == 0)
        {
            _hud.ShowGameOver();
        }
    }

    public void IncrementScore(int points)
    {
         _score += points;
         _hud.UpdateScore(_score);
    }

    public bool IsBrickGridEmpty()
    {
        return _brickGrid.IsGridEmpty();
    }

    public void HandleClearGrid()
    {
        _round += 1;
        _ball.SetIsFollowing(true);
        _brickGrid.GenerateBricks();
    }

    public int GetLifeCount()
    {
        return _lifeCount;
    }
}
