using System;
using Leviton.Common.Settings;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace Leviton.Services.Settings
{
    public class AppSettings : IAppSettings
    {
        #region Helpers for properties initialization
        private readonly Dictionary<string, object> _settings = new Dictionary<string, object>();

        private ISetting<T> GetSetting<T>([CallerMemberName]string keyName = null, T defaultValue = default(T))
        {
            object o;
            if (_settings.TryGetValue(keyName, out o))
            {
                return o as ISetting<T>;
            }

            var newSetting = LocalSetting<T>.Create(keyName, defaultValue);
            _settings.Add(keyName, newSetting);
            return newSetting;
        }
        #endregion

        public ISetting<bool> FirstRun
        {
            get { return GetSetting<bool>(defaultValue: true); }
        }
    }
}
