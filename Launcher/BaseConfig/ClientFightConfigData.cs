using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.BaseConfig
{
	// Token: 0x02004672 RID: 18034
	[NullableContext(1)]
	[Nullable(0)]
	public class ClientFightConfigData : IClientFightConfigData
	{
		// Token: 0x170080BA RID: 32954
		// (get) Token: 0x0602F02C RID: 192556 RVA: 0x00B22EB8 File Offset: 0x00B210B8
		// (set) Token: 0x0602F02D RID: 192557 RVA: 0x00B22EC0 File Offset: 0x00B210C0
		public string clientMd5 { get; set; } = string.Empty;
	}
}
