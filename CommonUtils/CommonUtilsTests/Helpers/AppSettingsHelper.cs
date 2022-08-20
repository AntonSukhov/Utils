using System.Configuration;

namespace CommonUtilsTests.Helpers
{
    /// <summary>
    /// Помощник работы с файлом App.Config
    /// </summary>
    internal static class AppSettingsHelper
    {
        #region Поля

        /// <summary>
        /// Имя секции AppSettings
        /// </summary>
        private static readonly string sectionAppSettingsName = "appSettings";

        #endregion

        #region Методы

        /// <summary>
        /// Удаление всех элементов секции AppSettings и добавление нового элемента
        /// </summary>
        /// <typeparam name="TType">Тип данных значения</typeparam>
        /// <param name="key">Название элемента</param>
        /// <param name="value">Значение элемента</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void RemoveAllElementsAndAddElement<TType>(string key, TType value)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new Exception($"Invalid parameter value named {nameof(key)}");
            }

            var appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var appSettings = (AppSettingsSection)appConfig.GetSection(sectionAppSettingsName);

            foreach (var keyLocal in appSettings.Settings.AllKeys)
            {
                appSettings.Settings.Remove(keyLocal);
            }

            appSettings.Settings.Add(key, value?.ToString() ?? string.Empty);

            appConfig.Save(ConfigurationSaveMode.Modified);

            ConfigurationManager.RefreshSection(sectionAppSettingsName);
        }

        /// <summary>
        /// Удаление всех элементов секции AppSettings
        /// </summary>
        public static void RemoveAllElements()
        {
            var appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var appSettings = (AppSettingsSection)appConfig.GetSection(sectionAppSettingsName);

            foreach (var keyLocal in appSettings.Settings.AllKeys)
            {
                appSettings.Settings.Remove(keyLocal);
            }

            appConfig.Save(ConfigurationSaveMode.Modified);

            ConfigurationManager.RefreshSection(sectionAppSettingsName);
        }

        #endregion
    }
}
