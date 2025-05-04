using System.Reflection;

namespace Vehicles.Infrastructure.MsSql;

public interface IAssemblyMark
{
    public static Assembly Assembly => typeof(IAssemblyMark).Assembly;
}