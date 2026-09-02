using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Util
{
	// Token: 0x02004C64 RID: 19556
	[NullableContext(2)]
	public interface ILayoutItem<TILayoutItemItem>
	{
		// Token: 0x17008782 RID: 34690
		// (get) Token: 0x06032F6F RID: 208751
		// (set) Token: 0x06032F70 RID: 208752
		[Nullable(1)]
		object Key { [NullableContext(1)] get; [NullableContext(1)] set; }

		// Token: 0x17008783 RID: 34691
		// (get) Token: 0x06032F71 RID: 208753
		// (set) Token: 0x06032F72 RID: 208754
		TILayoutItemItem Value { get; set; }
	}
}
