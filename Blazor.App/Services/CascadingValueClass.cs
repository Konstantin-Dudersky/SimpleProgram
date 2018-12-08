using System.Collections.Generic;
using SimpleProgram.Lib.Tag;
using SimpleProgramBlazorLib;

namespace Blazor.App.Services
{
    public sealed class CascadingValueClass : CascadingValueClassBase
    {
        public CascadingValueClass(SortedDictionary<string, ITag> tagDict) : base(tagDict)
        {
            
        }
    }
}