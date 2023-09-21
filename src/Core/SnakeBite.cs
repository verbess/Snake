using Snake.Utilities;

namespace Snake;

/// <summary>
/// Represents the main entry point of the framework.
/// </summary>
/// <remarks>
/// <see cref="SnakeBite" /> is not thread-safe. It is suitable for single-threaded environments, and its methods should
/// be called from the designated location, usually at the global entry/exit point of the game.
/// </remarks>
public static class SnakeBite
{
    private const string ModuleNameFormat = @"{0}.{1}";
    private const int InterfaceNameIndex = 1;
    private static readonly List<Module> s_modules;
    private static List<IUpdatable> s_updatables;

    /// <summary>
    /// Initializes the static fields of the <see cref="SnakeBite" /> class.
    /// </summary>
    static SnakeBite()
    {
        s_modules = new List<Module>();
        s_updatables = new List<IUpdatable>();
    }

    /// <summary>
    /// Updates the modules with the specified elapsed time.
    /// </summary>
    /// <param name="logicalElapse">The logical elapsed time in seconds.</param>
    /// <param name="realElapse">The real elapsed time in seconds.</param>
    public static void Update(double logicalElapse, double realElapse)
    {
        foreach (IUpdatable updatable in s_updatables)
        {
            updatable.Update(logicalElapse, realElapse);
        }
    }

    /// <summary>
    /// Shuts down the modules and releases any resources held by them.
    /// </summary>
    public static void Shutdown()
    {
        var modules = s_modules.OrderBy(m => m.Priority).ToList();
        foreach (Module module in modules)
        {
            module.Shutdown();
        }

        s_modules.Clear();
    }

    /// <summary>
    /// Gets a module that implements the specified interface type <typeparamref name="T" />.
    /// </summary>
    /// <typeparam name="T">The type of the interface implemented by the module to get.</typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentException"><typeparamref name="T" /> is not an interface type.</exception>
    /// <exception cref="SnakeException">
    /// If the module that implements the specified interface type <typeparamref name="T" /> cannot be found or was not
    /// a standard Snake module.
    /// </exception>
    public static T Get<T>()
        where T : class
    {
        var type = typeof(T);
        if (!type.IsInterface)
        {
            throw new ArgumentException(Messages.Argument_MustBeInterface);
        }

        string moduleName = Stringify.Format(ModuleNameFormat, type.Namespace, type.Name[InterfaceNameIndex..]);
        Type moduleType =
            Type.GetType(moduleName)
            ?? throw new SnakeException(Stringify.Format(Messages.Snake_ModuleNotFound, moduleName));
        if (!moduleType.IsAssignableTo(type) || !moduleType.IsAssignableTo(typeof(Module)))
        {
            throw new SnakeException(Stringify.Format(Messages.Snake_NotStandardModule, moduleName));
        }

        Module module = s_modules.FirstOrDefault(m => m.GetType() == moduleType) ?? Add(moduleType);

        return module as T ?? throw new SnakeException();
    }

    private static Module Add(Type moduleType)
    {
        Module module =
            Activator.CreateInstance(moduleType, true) as Module
            ?? throw new SnakeException(Stringify.Format(Messages.Snake_ModuleCreationFailed, moduleType.FullName));

        s_modules.Add(module);
        s_updatables = s_modules.OrderByDescending(m => m.Priority).OfType<IUpdatable>().ToList();

        return module;
    }
}
