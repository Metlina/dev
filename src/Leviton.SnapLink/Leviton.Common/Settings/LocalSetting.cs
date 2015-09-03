using System.Collections.Generic;
using Windows.Storage;

namespace Leviton.Common.Settings
{
    /// <summary>
    /// Implementation of ISetting which persists values in ApplicationData.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LocalSetting<T> : ISetting<T>
    {
        private T _value;

        public string SettingName { get; private set; }
        public T Value
        {
            get { return _value; }
            set
            {
                if (EqualityComparer<T>.Default.Equals(_value, value))
                    return;

                _value = value;
                OnSet();
            }
        }

        public LocalSetting(string settingName)
        {
            SettingName = settingName;

            Load();
        }

        public LocalSetting(string settingName, T defaultValue)
        {
            SettingName = settingName;

            if (!Load())
                _value = defaultValue;
        }

        protected bool Load()
        {
            var localSettings = ApplicationData.Current.LocalSettings;
            if (localSettings.Containers.ContainsKey("AppSettings"))
            {
                var container = localSettings.Containers["AppSettings"];
                if (container.Values.ContainsKey(SettingName))
                {
                    var val = container.Values[SettingName];
                    if (val is T)
                    {
                        _value = (T)val;
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Called when save is about to be performed.
        /// </summary>
        protected virtual void OnSet()
        {
            Save();
        }

        public void Save()
        {
            var localSettings = ApplicationData.Current.LocalSettings;
            if (!localSettings.Containers.ContainsKey("AppSettings"))
                localSettings.CreateContainer("AppSettings", ApplicationDataCreateDisposition.Always);

            var container = localSettings.Containers["AppSettings"];
            if (!container.Values.ContainsKey(SettingName))
                container.Values.Add(SettingName, Value);
            else
                container.Values[SettingName] = Value;
        }

        /// <summary>
        /// Implicit conversion to held type to simplify reading.
        /// </summary>
        /// <param name="setting"></param>
        /// <returns></returns>
        public static implicit operator T(LocalSetting<T> setting)
        {
            return setting.Value;
        }

        /// <summary>
        /// Helper method for creating local settings quick from the specified key
        /// and the specified default value.
        /// </summary>
        /// <param name="keyName"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static LocalSetting<T> Create(string keyName, T defaultValue)
        {
            return new LocalSetting<T>(keyName, defaultValue);
        }
    }
}
