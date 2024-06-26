﻿using FileManagement.ExtensionMethods;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace FileManagement.Infrastructure
{
    public class ViewDefinition
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public string RootName { get; set; }
        public string EntryName { get; set; }
        public IList<ColumnDefinition> Columns { get; set; }
        public string AccessToken { get; set; }
    }

    public class ColumnDefinition
    {
        public string Name { get; set; }
        public string Alias { get; set; }
    }

    public class ViewDefinitions: Collection<ViewDefinition>
    {
        public ViewDefinition GetViewDefition(string name)
        {
            return this.FirstOrDefault(view => view.Alias.EqualsIgnoreCase(name));
        }
    }
}
