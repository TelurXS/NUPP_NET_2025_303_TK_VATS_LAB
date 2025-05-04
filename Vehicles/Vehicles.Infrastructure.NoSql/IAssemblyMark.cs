using System.Reflection;

namespace Vehicles.Infrastructure.NoSql;

public interface IAssemblyMark
{
    public static Assembly Assembly => typeof(IAssemblyMark).Assembly;
}