using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.BaseConfig;

namespace CSharpScript.Launcher
{
	// Token: 0x0200449A RID: 17562
	[NullableContext(1)]
	[Nullable(0)]
	public class VersionItem
	{
		// Token: 0x0602E51D RID: 189725 RVA: 0x00ADF24D File Offset: 0x00ADD44D
		public VersionItem()
		{
		}

		// Token: 0x0602E51E RID: 189726 RVA: 0x00ADF278 File Offset: 0x00ADD478
		public VersionItem(Partial<VersionItem> data)
		{
			this.Name = (data.GetValue<string>(([Nullable(1)] VersionItem v) => v.Name) ?? "");
			this.Version = (data.GetValue<string>(([Nullable(1)] VersionItem v) => v.Version) ?? "");
			this.IndexSha1 = new Dictionary<string, string>();
			Dictionary<string, string> value = data.GetValue<Dictionary<string, string>>(([Nullable(1)] VersionItem v) => v.IndexSha1);
			if (value != null)
			{
				foreach (KeyValuePair<string, string> keyValuePair in value)
				{
					this.IndexSha1[keyValuePair.Key] = keyValuePair.Value;
				}
			}
		}

		// Token: 0x0401A4DC RID: 107740
		public string Name = "";

		// Token: 0x0401A4DD RID: 107741
		public string Version = "";

		// Token: 0x0401A4DE RID: 107742
		public Dictionary<string, string> IndexSha1 = new Dictionary<string, string>();
	}
}
