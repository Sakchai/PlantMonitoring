

using System;

namespace Plant.Model
{
    /// <summary>
    /// Represents the data provider manager
    /// </summary>
    public partial class DataProviderManager : IDataProviderManager
    {
        #region Methods

        /// <summary>
        /// Gets data provider by specific type
        /// </summary>
        /// <param name="dataProviderType">Data provider type</param>
        /// <returns></returns>
        public static IPlantDataProvider GetDataProvider(DataProviderType dataProviderType)
        {
            switch (dataProviderType)
            {
                case DataProviderType.Oracle:
                    return new OraclePlantDataProvider();
                default:
                    throw new Exception($"Not supported data provider name: '{dataProviderType}'");
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets data provider
        /// </summary>
        public IPlantDataProvider DataProvider
        {
            get
            {
                var dataProviderType = DataProviderType.Oracle;

                return GetDataProvider(dataProviderType);
            }
        }

        #endregion
    }
}
