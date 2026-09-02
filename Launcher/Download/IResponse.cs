using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.Download
{
	// Token: 0x02004623 RID: 17955
	[NullableContext(1)]
	public interface IResponse
	{
		// Token: 0x17008097 RID: 32919
		// (get) Token: 0x0602EE9F RID: 192159
		// (set) Token: 0x0602EEA0 RID: 192160
		int Code { get; set; }

		// Token: 0x17008098 RID: 32920
		// (get) Token: 0x0602EEA1 RID: 192161
		// (set) Token: 0x0602EEA2 RID: 192162
		string Result { get; set; }
	}
}
