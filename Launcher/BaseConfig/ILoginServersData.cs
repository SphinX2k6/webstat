using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.BaseConfig
{
	// Token: 0x0200467C RID: 18044
	[NullableContext(1)]
	[Nullable(0)]
	public class ILoginServersData
	{
		// Token: 0x0401AC9C RID: 109724
		public string name;

		// Token: 0x0401AC9D RID: 109725
		public string ip;

		// Token: 0x0401AC9E RID: 109726
		public string id;

		// Token: 0x0401AC9F RID: 109727
		public string Region;

		// Token: 0x0401ACA0 RID: 109728
		public string PingUrl;

		// Token: 0x0401ACA1 RID: 109729
		public ITDConfig TDCfg;

		// Token: 0x0401ACA2 RID: 109730
		public ITDConfig KDCfg;

		// Token: 0x0401ACA3 RID: 109731
		public List<string> LoginUrl;
	}
}
