using System;

namespace Entidades
{
    public class ColunaBD : Attribute
    {
        public ColunaBD(string name)
        {
            Name = name;
        }
        public string Name { get; private set; }

    }
}