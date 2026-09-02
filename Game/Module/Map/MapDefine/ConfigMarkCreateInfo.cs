using System;
using Aki.Config;

namespace CSharpScript.Game.Module.Map.MapDefine
{
	// Token: 0x020058B1 RID: 22705
	public class ConfigMarkCreateInfo : MarkCreateInfo
	{
		// Token: 0x06039ADF RID: 236255 RVA: 0x00E9FC21 File Offset: 0x00E9DE21
		public ConfigMarkCreateInfo(MapMark markConfig, int? markId) : base(EMarkCreateType.ConfigMark)
		{
			this.MarkConfig = markConfig;
			if (markId == null)
			{
				this.MarkId = markConfig.MarkId;
			}
		}

		// Token: 0x04020B04 RID: 133892
		public int MarkId;

		// Token: 0x04020B05 RID: 133893
		public MapMark MarkConfig;
	}
}
