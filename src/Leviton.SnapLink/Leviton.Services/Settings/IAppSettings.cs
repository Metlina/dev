using Leviton.Common.Settings;

namespace Leviton.Services.Settings
{
    public interface IAppSettings
    {
        ISetting<bool> FirstRun { get; }
    }
}
