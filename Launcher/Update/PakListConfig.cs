using System;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.BaseConfig;

namespace CSharpScript.Launcher.Update
{
	// Token: 0x020044C7 RID: 17607
	[NullableContext(1)]
	[Nullable(0)]
	public class PakListConfig
	{
		// Token: 0x0602E775 RID: 190325 RVA: 0x00B000A1 File Offset: 0x00AFE2A1
		public PakListConfig()
		{
		}

		// Token: 0x0602E776 RID: 190326 RVA: 0x00B000CC File Offset: 0x00AFE2CC
		public PakListConfig(Partial<PakListConfig> data)
		{
			this.Hash = (data.GetValue<string>(([Nullable(1)] PakListConfig d) => d.Hash) ?? "");
			this.Random = (data.GetValue<string>(([Nullable(1)] PakListConfig d) => d.Random) ?? "");
			this.Key = (data.GetValue<string>(([Nullable(1)] PakListConfig d) => d.Key) ?? "");
			this.UpdateTime = data.GetValue<int>((PakListConfig d) => d.UpdateTime);
		}

		// Token: 0x0401A641 RID: 108097
		public string Hash = "";

		// Token: 0x0401A642 RID: 108098
		public string Random = "";

		// Token: 0x0401A643 RID: 108099
		public string Key = "";

		// Token: 0x0401A644 RID: 108100
		public int UpdateTime;
	}
}
