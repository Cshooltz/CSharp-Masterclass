using System;
using System.Collections.Generic;
using System.Text;

namespace CSMasterClass
{
    class S6Box
    {
        public S6Box(int length, int height, int width)
        {
            this._Length = length;
            this._Height = height;
            Width = width;
            return;
        }
        
        // 9/21/2020 - I hate that properties and varliables have to have different names.
        // So what do I want my naming convention to be for properties?
        // What is important to me is external consistency, but I also want free access to fields if properties aren't necessary.
        // The instructor is using camelCase for fields and PascalCase for properties,
        // but this makes weird accesses where if you access a property it is capitalized, and the field is not, giving away what is a field and what is a property (they should be transparent).
        // The other convention I have seen is leading with an underscore on variables accessed via property. Perhaps this is the better solution. 
        // This way, externally, accessing properties and fields looks the exact same, and internally it is obvious which you are using.
        protected int _Length = 1;
        protected int _Height = 1;
        //protected int _Volume;

        public int Length
        {
            get => _Length;
            set => _Length = value;
        }
        public int Width { get; set; } = 1;

        public int Height
        {
            get => _Height; // arrow notation is shorthand for a single statement getter/setter.
            set
            {
                if (value < 0) _Height = -value;
                else _Height = value;
            }
        }

        public int Volume
        {
            get
            {
                return _Length*_Height*Width;
            }
        }

        public int FrontSurface
        {
            get => _Length * _Height;
        }

        public virtual void SetLength(int length)
        {
            if (length < 0)
            {
                throw new Exception("Length should be higher than zero.");
            }
            this._Length = length;
            return;
        }
        public int GetLength()
        {
            return this._Length;
        }

        public void DisplayInfo()
        {
            Console.WriteLine("Length is {0} and height is {1} and width is {2} so the volume is {3}", Length, Height, Width, Volume);
        }

    }
}
