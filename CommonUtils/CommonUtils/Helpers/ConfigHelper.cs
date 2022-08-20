using System.Configuration;

namespace CommonUtils.Helpers
{
    /// <summary>
    /// Помошник работы с конфигурационным файлом программы
    /// </summary>
    public static class ConfigHelper
    {
        #region Методы

        /// <summary>
        /// Получение значения элемента секции настройки приложения файла App.config
        /// </summary>
        /// <param name="key">Название элемента</param>
        /// <param name="defaultValue">Значение элемента по умолчанию </param>
        /// <returns>Значение элемента</returns>
        public static string GetAppSettingValue(string key, string defaultValue)
        {
            var value = ConfigurationManager.AppSettings[key];

            return string.IsNullOrWhiteSpace(value) ? defaultValue : value;
        }

        #endregion
    }
}
