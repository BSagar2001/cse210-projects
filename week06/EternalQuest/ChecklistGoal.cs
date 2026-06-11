public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonus;

    public ChecklistGoal(
        string name,
        string description,
        int points,
        int targetCount,
        int bonus)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonus = bonus;
        _currentCount = 0;
    }

    public ChecklistGoal(
        string name,
        string description,
        int points,
        int targetCount,
        int bonus,
        int currentCount)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonus = bonus;
        _currentCount = currentCount;
    }

    public override int RecordEvent()
    {
        if (_currentCount < _targetCount)
        {
            _currentCount++;

            if (_currentCount == _targetCount)
            {
                return GetPoints() + _bonus;
            }

            return GetPoints();
        }

        return 0;
    }

    public override bool IsComplete()
    {
        return _currentCount >= _targetCount;
    }

    public override string GetStatus()
    {
        return $"[{(IsComplete() ? "X" : " ")}] {GetName()} ({GetDescription()}) -- Completed {_currentCount}/{_targetCount}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{GetName()}|{GetDescription()}|{GetPoints()}|{_bonus}|{_currentCount}|{_targetCount}";
    }
}