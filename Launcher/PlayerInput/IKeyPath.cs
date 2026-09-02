using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.PlayerInput
{
	// Token: 0x0200454A RID: 17738
	[NullableContext(1)]
	public interface IKeyPath
	{
		// Token: 0x17008059 RID: 32857
		// (get) Token: 0x0602EAEB RID: 191211
		// (set) Token: 0x0602EAEC RID: 191212
		[Nullable(2)]
		string XBox { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x1700805A RID: 32858
		// (get) Token: 0x0602EAED RID: 191213
		// (set) Token: 0x0602EAEE RID: 191214
		string Ps { get; set; }
	}
}
