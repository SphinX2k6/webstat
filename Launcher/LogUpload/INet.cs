using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.LogUpload
{
	// Token: 0x020045EC RID: 17900
	[NullableContext(1)]
	public interface INet
	{
		// Token: 0x17008087 RID: 32903
		// (get) Token: 0x0602EDAC RID: 191916
		// (set) Token: 0x0602EDAD RID: 191917
		Func<bool> IsServerConnected { get; set; }
	}
}
