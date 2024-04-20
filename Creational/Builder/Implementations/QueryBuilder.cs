namespace Builder.Implementations;

public class QueryBuilder
{
    private string? _selectClause;
    private string? _fromClause;
    private string?_whereClause;

    public QueryBuilder Select(string? selectClause)
    {
        _selectClause = selectClause;
        return this;
    }

    public QueryBuilder From(string fromClause)
    {
        _fromClause = fromClause;
        return this;
    }

    public QueryBuilder Where(string whereClause)
    {
        _whereClause = whereClause;
        return this;
    }

    public string Build()
    {
        return $"{_selectClause} {_fromClause} {_whereClause}";
    }
}
public class QueryDirector(QueryBuilder builder)
{
    public void Construct()
    {
        builder.Select("SELECT *");
        builder.From("FROM Users");
        builder.Where("WHERE Age > 21");
    }

    public void Show()
    {
        var query = builder.Build();
        Console.WriteLine(query);
    }
}