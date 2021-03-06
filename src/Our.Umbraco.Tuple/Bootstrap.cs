﻿using Newtonsoft.Json;
using Our.Umbraco.Tuple.ValueConverters;
using Umbraco.Core;
using Umbraco.Core.Sync;
using Umbraco.Web.Cache;

namespace Our.Umbraco.Tuple
{
    public class Bootstrap : ApplicationEventHandler
    {
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            DataTypeCacheRefresher.CacheUpdated += (sender, e) =>
            {
                if (e.MessageType != MessageType.RefreshByJson)
                    return;

                // NOTE: The properties for the JSON payload are available here: (Currently there isn't a public API to deserialize the payload)
                // https://github.com/umbraco/Umbraco-CMS/blob/release-7.6.0/src/Umbraco.Web/Cache/DataTypeCacheRefresher.cs#L66-L70
                // TODO: Once `DataTypeCacheRefresher.DeserializeFromJsonPayload` is public, we can deserialize correctly.
                // https://github.com/umbraco/Umbraco-CMS/blob/release-7.6.0/src/Umbraco.Web/Cache/DataTypeCacheRefresher.cs#L27
                var payload = JsonConvert.DeserializeAnonymousType((string)e.MessageObject, new[] { new { Id = default(int) } });
                if (payload == null)
                    return;

                foreach (var item in payload)
                {
                    TupleValueConverter.ClearDataTypeCache(item.Id);
                }
            };
        }
    }
}