﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Our.Umbraco.Tuple.Models;
using Umbraco.Core.Models;
using Umbraco.Core.PropertyEditors;
using Umbraco.Web.Editors;
using Umbraco.Web.Models.ContentEditing;
using Umbraco.Web.Mvc;

namespace Our.Umbraco.Tuple.Web.Controllers
{
    [PluginController("Tuple")]
    public class TupleApiController : UmbracoAuthorizedJsonController
    {
        public IEnumerable<DataTypeBasicModel> GetDataTypesByKey([FromUri] Guid[] keys)
        {
            var dataTypes = new List<DataTypeBasicModel>();

            if (keys != null)
            {
                var entities = Services.EntityService.GetAll(UmbracoObjectTypes.DataType, keys);
                if (entities != null)
                {
                    var ids = entities.Select(x => x.Id).ToArray();
                    var dtds = Services.DataTypeService.GetAllDataTypeDefinitions(ids);

                    foreach (var key in keys)
                    {
                        var entity = entities.FirstOrDefault(x => x.Key == key);
                        if (entity == null)
                            continue;

                        var dtd = dtds.FirstOrDefault(x => x.Id == entity.Id);
                        if (dtd == null)
                            continue;

                        var editor = PropertyEditorResolver.Current.GetByAlias(dtd.PropertyEditorAlias);

                        dataTypes.Add(new DataTypeBasicModel
                        {
                            id = entity.Id,
                            key = entity.Key,
                            name = entity.Name,
                            icon = editor.Icon,
                            description = dtd.PropertyEditorAlias
                        });
                    }
                }
            }

            return dataTypes;
        }

        public IEnumerable<TupleContentPropertyDisplay> GetPropertyTypeScaffoldsByKey([FromUri] Guid[] keys)
        {
            var items = new List<TupleContentPropertyDisplay>();

            if (keys != null)
            {
                var entities = Services.EntityService.GetAll(UmbracoObjectTypes.DataType, keys);
                if (entities != null)
                {
                    var ids = entities.Select(x => x.Id).ToArray();
                    var dtds = Services.DataTypeService.GetAllDataTypeDefinitions(ids);

                    foreach (var key in keys)
                    {
                        var entity = entities.FirstOrDefault(x => x.Key == key);
                        if (entity == null)
                            continue;

                        var dtd = dtds.FirstOrDefault(x => x.Id == entity.Id);
                        if (dtd == null)
                            continue;

                        // TODO: Review this, if there are duplicate DTDs, then we don't need to re-query for the prevalues
                        // (maybe change `items` to be a dictionary lookup? (with DTD.Id as the key?)

                        var preVals = Services.DataTypeService.GetPreValuesCollectionByDataTypeId(dtd.Id);
                        var editor = PropertyEditorResolver.Current.GetByAlias(dtd.PropertyEditorAlias);

                        items.Add(new TupleContentPropertyDisplay
                        {
                            DataTypeGuid = key,
                            Editor = dtd.PropertyEditorAlias,
                            Validation = new PropertyTypeValidation() { },
                            View = editor.ValueEditor.View,
                            Config = editor.PreValueEditor.ConvertDbToEditor(editor.DefaultPreValues, preVals),
                        });
                    }
                }
            }

            return items;
        }
    }
}