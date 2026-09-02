using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher
{
	// Token: 0x0200449E RID: 17566
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RemoteInfo : Singleton<RemoteInfo>
	{
		// Token: 0x17007FC0 RID: 32704
		// (get) Token: 0x0602E524 RID: 189732 RVA: 0x00ADF888 File Offset: 0x00ADDA88
		// (set) Token: 0x0602E525 RID: 189733 RVA: 0x00ADF890 File Offset: 0x00ADDA90
		public RemoteVersionConfig NewConfig
		{
			get
			{
				return this.VersionConfig;
			}
			set
			{
				this.VersionConfig = value;
			}
		}

		// Token: 0x0401A4EE RID: 107758
		private RemoteVersionConfig VersionConfig;

		// Token: 0x0401A4EF RID: 107759
		public RemoteConfig Config;

		// Token: 0x0401A4F0 RID: 107760
		public RemoteVersionConfig PreVerConfig;
	}
}
