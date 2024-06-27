using FilesystemOperations.Exceptions;
using FilesystemOperations.Models.Parameters;

namespace FilesystemOperations.Entities.Parser;

public static class ParameterParser
{
    public static IReadOnlyList<ParameterWithValue>? Parse(string[] singleRequest)
    {
        int fromPosition = (singleRequest.Select((s, i) => new { Index = i, Value = s })
            .FirstOrDefault(x => x.Value.StartsWith("-", StringComparison.CurrentCulture)) ?? new { Index = -1, Value = string.Empty }).Index;
        if (fromPosition == -1 || singleRequest is null)
        {
            return null;
        }

        var paramValue = new List<Tuple<string, string>>();
        for (int i = fromPosition; i < singleRequest.Length; i += 2)
        {
            if (!singleRequest[i].StartsWith("-", StringComparison.CurrentCulture)
                || singleRequest[i + 1].StartsWith("-", StringComparison.CurrentCulture))
            {
                throw new ParserException();
            }

            paramValue.Add(new Tuple<string, string>(singleRequest[i], singleRequest[i + 1]));
        }

        return paramValue
            .Select(x => new ParameterWithValue(x.Item1, x.Item2)).ToList();
    }
}