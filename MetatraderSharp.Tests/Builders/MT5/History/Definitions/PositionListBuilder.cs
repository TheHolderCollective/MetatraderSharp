using MetatraderSharp.MTsocketAPI.Responses.MT5;

namespace MetatraderSharp.Tests.Builders.MT5;

public class PositionListBuilder
{
    private List<Position> _positions = [];

    public PositionListBuilder()
    {
        _positions.Add(new PositionBuilder().Build());
    }

    public PositionListBuilder WithNoDefaultPositions()
    {
        _positions.Clear();
        return this;
    }

    public PositionListBuilder WithPosition(Position newPosition)
    {
        _positions.Add(newPosition);
        return this;
    }

    public List<Position> Build()
    {
        return _positions;
    }
}
