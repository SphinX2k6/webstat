using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x020050FF RID: 20735
	public class RoguelikeEntryData
	{
		// Token: 0x06035737 RID: 218935 RVA: 0x00D6A984 File Offset: 0x00D68B84
		public RogueHotEntry GetConfig()
		{
			return ConfigBase<RoguelikeConfig>.Instance.GetRogueHotEntryConfig(this.Id).Value;
		}

		// Token: 0x0401EB39 RID: 125753
		public int Id;

		// Token: 0x0401EB3A RID: 125754
		public int GroupId;

		// Token: 0x0401EB3B RID: 125755
		public ERoguelikeEntryType Type = ERoguelikeEntryType.Type1;

		// Token: 0x0401EB3C RID: 125756
		public int OverviewId;

		// Token: 0x0401EB3D RID: 125757
		[Nullable(1)]
		public List<int> OverviewParam = new List<int>();

		// Token: 0x0401EB3E RID: 125758
		[Nullable(2)]
		public Action<bool, bool> SetEntryToggleState;
	}
}
