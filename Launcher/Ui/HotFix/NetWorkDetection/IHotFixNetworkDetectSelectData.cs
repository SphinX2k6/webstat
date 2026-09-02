using System;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.BaseConfig;

namespace CSharpScript.Launcher.Ui.HotFix.NetWorkDetection
{
	// Token: 0x0200451E RID: 17694
	[NullableContext(1)]
	public interface IHotFixNetworkDetectSelectData : IHotFixLayoutData
	{
		// Token: 0x17008048 RID: 32840
		// (get) Token: 0x0602E9D9 RID: 190937
		// (set) Token: 0x0602E9DA RID: 190938
		ILoginServersData LoginServersData { get; set; }
	}
}
