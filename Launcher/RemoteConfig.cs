using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.BaseConfig;

namespace CSharpScript.Launcher
{
	// Token: 0x0200449B RID: 17563
	[NullableContext(1)]
	[Nullable(0)]
	public class RemoteConfig
	{
		// Token: 0x0602E51F RID: 189727 RVA: 0x00ADF39C File Offset: 0x00ADD59C
		public RemoteConfig()
		{
		}

		// Token: 0x0602E520 RID: 189728 RVA: 0x00ADF3E8 File Offset: 0x00ADD5E8
		public RemoteConfig(Partial<RemoteConfig> data)
		{
			this.PackageVersion = (data.GetValue<string>(([Nullable(1)] RemoteConfig r) => r.PackageVersion) ?? "");
			this.LauncherVersion = (data.GetValue<string>(([Nullable(1)] RemoteConfig r) => r.LauncherVersion) ?? "");
			this.ResourceVersion = (data.GetValue<string>(([Nullable(1)] RemoteConfig r) => r.ResourceVersion) ?? "");
			this.ChangeList = (data.GetValue<string>(([Nullable(1)] RemoteConfig r) => r.ChangeList) ?? "");
			this.UpdateTime = data.GetValue<long?>((RemoteConfig r) => r.UpdateTime);
			this.LauncherIndexSha1 = new Dictionary<string, string>();
			Dictionary<string, string> value = data.GetValue<Dictionary<string, string>>(([Nullable(1)] RemoteConfig d) => d.LauncherIndexSha1);
			if (value != null)
			{
				foreach (KeyValuePair<string, string> keyValuePair in value)
				{
					this.LauncherIndexSha1[keyValuePair.Key] = keyValuePair.Value;
				}
			}
			this.ResourceIndexSha1 = new Dictionary<string, string>();
			Dictionary<string, string> value2 = data.GetValue<Dictionary<string, string>>(([Nullable(1)] RemoteConfig d) => d.ResourceIndexSha1);
			if (value2 != null)
			{
				foreach (KeyValuePair<string, string> keyValuePair2 in value2)
				{
					this.ResourceIndexSha1[keyValuePair2.Key] = keyValuePair2.Value;
				}
			}
			this.Versions = new List<VersionItem>();
			List<VersionItem> value3 = data.GetValue<List<VersionItem>>(([Nullable(1)] RemoteConfig d) => d.Versions);
			if (value3 != null)
			{
				foreach (VersionItem value4 in value3)
				{
					this.Versions.Add(new VersionItem(new Partial<VersionItem>(value4)));
				}
			}
		}

		// Token: 0x0401A4DF RID: 107743
		public string PackageVersion = "";

		// Token: 0x0401A4E0 RID: 107744
		public string LauncherVersion = "";

		// Token: 0x0401A4E1 RID: 107745
		public string ResourceVersion = "";

		// Token: 0x0401A4E2 RID: 107746
		public string ChangeList = "";

		// Token: 0x0401A4E3 RID: 107747
		public long? UpdateTime = new long?(0L);

		// Token: 0x0401A4E4 RID: 107748
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public Dictionary<string, string> LauncherIndexSha1;

		// Token: 0x0401A4E5 RID: 107749
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public Dictionary<string, string> ResourceIndexSha1;

		// Token: 0x0401A4E6 RID: 107750
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<VersionItem> Versions;
	}
}
