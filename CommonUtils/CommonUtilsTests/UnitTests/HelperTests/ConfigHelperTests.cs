using CommonUtils.Helpers;
using CommonUtilsTests.Base;
using CommonUtilsTests.Helpers;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace CommonUtilsTests.UnitTests.HelperTests
{
    /// <summary>
    /// Модульное тестирование класса <see cref="ConfigHelper"/>
    /// </summary>
    public class ConfigHelperTests : TestBase
    {
        #region Конструкторы

        ///<inheritdoc/>
        public ConfigHelperTests(ITestOutputHelper output) : base(output) { }

        #endregion

        #region Методы

        /// <summary>
        /// Тестирование метода <see cref="GetAppSettingValue"/> при наличии в файле App.Config элемента со значением в секции App.Settings 
        /// </summary>
        [Fact]
        public void GetAppSettingValue()
        {
            _output.WriteLine($"Входные параметры теста: отсутствуют");

            var defaultValue = "MetropolisLight";
            var key = "DefaultApplicationThemeName";

            AppSettingsHelper.RemoveAllElementsAndAddElement(key, defaultValue);

            var expected = ConfigHelper.GetAppSettingValue(key, defaultValue);

            expected.Should().NotBeNullOrWhiteSpace()
                             .And
                             .Be(defaultValue);
        }

        /// <summary>
        /// Тестирование метода <see cref="GetAppSettingValue"/> при наличии в файле App.Config элемента с другим именем и любым значением в секции App.Settings 
        /// </summary>
        [Fact]
        public void GetAppSettingValueWithOtherElement()
        {
            _output.WriteLine($"Входные параметры теста: отсутствуют");

            var defaultValue = "MetropolisLight";
            var key = "DefaultApplicationThemeName";

            AppSettingsHelper.RemoveAllElementsAndAddElement(string.Concat(key, 1), defaultValue);

            var expected = ConfigHelper.GetAppSettingValue(key, defaultValue);

            expected.Should().NotBeNullOrWhiteSpace()
                             .And
                             .Be(defaultValue);
        }

        /// <summary>
        /// Тестирование метода <see cref="GetAppSettingValue"/> при отсутствии в файле App.Config элементов в секции App.Settings 
        /// </summary>
        [Fact]
        public void GetAppSettingValueWithoutElements()
        {
            _output.WriteLine($"Входные параметры теста: отсутствуют");

            var defaultValue = "MetropolisLight";
            var key = "DefaultApplicationThemeName";

            AppSettingsHelper.RemoveAllElements();

            var expected = ConfigHelper.GetAppSettingValue(key, defaultValue);

            expected.Should().NotBeNullOrWhiteSpace()
                             .And
                             .Be(defaultValue);
        }

        #endregion
    }
}
