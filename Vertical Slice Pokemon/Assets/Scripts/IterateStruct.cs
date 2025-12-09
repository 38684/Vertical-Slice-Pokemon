using System.Reflection;

public static class IterateStruct<T>
{
    public static void IterateOverStruct(T structure)
    {
        // Source - https://stackoverflow.com/a
        // Posted by Jon Skeet, modified by community. See post 'Timeline' for change history
        // Retrieved 2025-12-03, License - CC BY-SA 3.0

        foreach (var field in typeof(T).GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
        {
            Debug.LogFormat("{0} = {1}", field.Name, field.GetValue(structure));
        }
    }
}
