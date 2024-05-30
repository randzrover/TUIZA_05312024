using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Entities;

public sealed class Item : Entity
{
    public Item(Guid id, string name, string description, string category, string url)
        : base(id)
    {
        Id = id;
        Name = name;
        Description = description;
        Category = category;
        Url = url;
    }

    private Item()
    {
    }

    public Guid Id { get; set; }

    public string Name { get; private set; }
    public string Description { get; private set; }
    public string Category { get; private set; }
    public string Url { get; private set; }
}