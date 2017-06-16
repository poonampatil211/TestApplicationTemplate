using StructureMap;
using Tavisca.Platform.Common.Logging;
using Tavisca.Platform.Common.ExceptionManagement;
using Tavisca.Common.Plugins.Stubs.Logging;
using Tavisca.Common.Plugins.Stubs.Metadata;
using Tavisca.Connector.Hotels.WebAPI;
using Tavisca.Connector.Hotels.Translators;
using Tavisca.Common.Plugins.Stubs.SupplierCall;
using Tavisca.Connector.Hotels.Model.Metadata;

namespace Tavisca181.Host
{
    public class ComponentRegistry : Registry
    {
        public ComponentRegistry()
        {
            
#if !Tavisca
            For(typeof(Platform.Common.Configurations.IConfigurationProvider)).Use(typeof(Common.Plugins.Stubs.Configuration.FileConfiguration));
            For(typeof(ILogWriter)).Use(typeof(FileLogger));
            For<IHotelMetadata>().Use<ServiceBasedMetadata>();
#else

#endif
            For<IErrorHandler>().Use<ErrorHandler>();
            ForConcreteType<CallContextCreator>().Configure.Ctor<string>("applicationName").Is("ConnectorShell").Ctor<string>("applicationShortName").Is("Search");
            For<BaseSerializerFactory>().Use<TranslatorFactory>();

            For<ISupplierCall>().Use<HttpClientSupplierCall>();
            For<Model.Search.IHotelSearch>().Use<DummySupplier.Search.HotelSearch>();
            ForConcreteType<DummySupplier.Search.TransformSearch>();
            For<Model.Book.IHotelBook>().Use<DummySupplier.Book.HotelBook>();
            ForConcreteType<DummySupplier.Book.TransformBook>();
            For<Model.RoomRates.IHotelRoomRates>().Use<DummySupplier.RoomRates.HotelRoomRates>();
            ForConcreteType<DummySupplier.RoomRates.TransformRoomRates>();
            For<Model.RateRules.IHotelRateRules>().Use<DummySupplier.RateRules.HotelRateRules>();
            ForConcreteType<DummySupplier.RateRules.TransformRateRules>();
            For<Model.Cancel.IHotelCancel>().Use<DummySupplier.Cancel.HotelCancel>();
            ForConcreteType<DummySupplier.Cancel.TransformCancel>();
        }
    }
}
