using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.BaseConfig
{
	// Token: 0x02004677 RID: 18039
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class BaseConfigModel : Singleton<BaseConfigModel>
	{
		// Token: 0x0602F05C RID: 192604 RVA: 0x00B24536 File Offset: 0x00B22736
		[NullableContext(2)]
		private void parseGrayBox(IGrayBoxConfig grayBoxConfig)
		{
		}

		// Token: 0x0602F05D RID: 192605 RVA: 0x00B24538 File Offset: 0x00B22738
		public void parseClientEntryJson(string parallelName, Dictionary<string, EntryJson> jsonFileData)
		{
			EntryJson defaultObject = null;
			EntryJson overrideObj = null;
			foreach (KeyValuePair<string, EntryJson> keyValuePair in jsonFileData)
			{
				string key = keyValuePair.Key;
				EntryJson value = keyValuePair.Value;
				if (key == "default")
				{
					defaultObject = value;
				}
				else if (key == parallelName)
				{
					overrideObj = value;
				}
			}
			EntryJson entryJson = new EntryJson(defaultObject, overrideObj);
			this.EntryJson = entryJson;
			this.parseGrayBox(entryJson.GrayBox);
		}

		// Token: 0x0401AC74 RID: 109684
		public Dictionary<string, string> BaseConfig = new Dictionary<string, string>();

		// Token: 0x0401AC75 RID: 109685
		public bool PublicConfigLoaded;

		// Token: 0x0401AC76 RID: 109686
		public Dictionary<string, string> BuildInfoMap = new Dictionary<string, string>();

		// Token: 0x0401AC77 RID: 109687
		public Dictionary<string, string> ConfigVersionMap = new Dictionary<string, string>();

		// Token: 0x0401AC78 RID: 109688
		public bool ParamsConfigInited;

		// Token: 0x0401AC79 RID: 109689
		[Nullable(2)]
		public EntryJson EntryJson;

		// Token: 0x0401AC7A RID: 109690
		public readonly Dictionary<string, IGrayBoxItem> GrayBoxConfigMap = new Dictionary<string, IGrayBoxItem>();

		// Token: 0x0401AC7B RID: 109691
		public readonly Dictionary<string, EHitResult> BoxResultMap = new Dictionary<string, EHitResult>();
	}
}
