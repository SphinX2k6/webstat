using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Plot
{
	// Token: 0x0200536D RID: 21357
	[NullableContext(1)]
	public interface IAbpStateConfig
	{
		// Token: 0x17008D7E RID: 36222
		// (get) Token: 0x06036744 RID: 223044
		// (set) Token: 0x06036745 RID: 223045
		string Abp { get; set; }

		// Token: 0x17008D7F RID: 36223
		// (get) Token: 0x06036746 RID: 223046
		// (set) Token: 0x06036747 RID: 223047
		string State1 { get; set; }

		// Token: 0x17008D80 RID: 36224
		// (get) Token: 0x06036748 RID: 223048
		// (set) Token: 0x06036749 RID: 223049
		string State2 { get; set; }
	}
}
