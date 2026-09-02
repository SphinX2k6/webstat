using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.BaseConfig;

namespace CSharpScript.Launcher
{
	// Token: 0x0200449D RID: 17565
	[NullableContext(1)]
	[Nullable(0)]
	public class RemoteVersionConfig
	{
		// Token: 0x0602E522 RID: 189730 RVA: 0x00ADF6E9 File Offset: 0x00ADD8E9
		public RemoteVersionConfig()
		{
		}

		// Token: 0x0602E523 RID: 189731 RVA: 0x00ADF720 File Offset: 0x00ADD920
		public RemoteVersionConfig(Partial<RemoteVersionConfig> data)
		{
			this.PackageVersion = (data.GetValue<string>(([Nullable(1)] RemoteVersionConfig r) => r.PackageVersion) ?? "");
			this.ChangeList = (data.GetValue<string>(([Nullable(1)] RemoteVersionConfig r) => r.ChangeList) ?? "");
			this.UpdateTime = data.GetValue<long?>((RemoteVersionConfig r) => r.UpdateTime);
			this.ResVersions = new Dictionary<string, VersionItem>();
			Dictionary<string, VersionItem> value = data.GetValue<Dictionary<string, VersionItem>>(([Nullable(1)] RemoteVersionConfig d) => d.ResVersions);
			if (value != null)
			{
				foreach (KeyValuePair<string, VersionItem> keyValuePair in value)
				{
					this.ResVersions[keyValuePair.Key] = new VersionItem(new Partial<VersionItem>(keyValuePair.Value));
				}
			}
		}

		// Token: 0x0401A4EA RID: 107754
		public string PackageVersion = "";

		// Token: 0x0401A4EB RID: 107755
		public string ChangeList = "";

		// Token: 0x0401A4EC RID: 107756
		public long? UpdateTime = new long?(0L);

		// Token: 0x0401A4ED RID: 107757
		public Dictionary<string, VersionItem> ResVersions = new Dictionary<string, VersionItem>();
	}
}
