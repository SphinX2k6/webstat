using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005104 RID: 20740
	[NullableContext(1)]
	[Nullable(0)]
	public class RogueArchiveInfoData
	{
		// Token: 0x17008C48 RID: 35912
		// (get) Token: 0x06035748 RID: 218952 RVA: 0x00D6ADC3 File Offset: 0x00D68FC3
		public int ShowIndex
		{
			get
			{
				return this.Index + 1;
			}
		}

		// Token: 0x06035749 RID: 218953 RVA: 0x00D6ADD0 File Offset: 0x00D68FD0
		public void Update(RogueArchiveInfo archiveInfo)
		{
			this.SlotId = archiveInfo.SlotId;
			this.HasData = archiveInfo.HasData;
			this.InstId = archiveInfo.InstId;
			this.SeasonId = archiveInfo.SeasonId;
			this.RoleIds = new List<int>(archiveInfo.RoleIds);
			if (archiveInfo.RoguelikeInstInfo != null)
			{
				this.RoguelikeInfo = new RoguelikeInfo(archiveInfo.RoguelikeInstInfo);
			}
			else
			{
				this.RoguelikeInfo = null;
			}
			if (this.RoguelikeInfo != null && archiveInfo.Attributes != null)
			{
				foreach (int num in archiveInfo.Attributes.Keys)
				{
					int num2 = archiveInfo.Attributes.ContainsKey(num) ? archiveInfo.Attributes[num] : 0;
					if (num2 != 0)
					{
						this.RoguelikeInfo.AttributeDict[Convert.ToInt32(num)] = num2;
					}
				}
			}
		}

		// Token: 0x0401EB4A RID: 125770
		public int SlotId;

		// Token: 0x0401EB4B RID: 125771
		public int Index;

		// Token: 0x0401EB4C RID: 125772
		public bool HasData;

		// Token: 0x0401EB4D RID: 125773
		public int InstId;

		// Token: 0x0401EB4E RID: 125774
		public int SeasonId;

		// Token: 0x0401EB4F RID: 125775
		public List<int> RoleIds = new List<int>();

		// Token: 0x0401EB50 RID: 125776
		[Nullable(2)]
		public RoguelikeInfo RoguelikeInfo;
	}
}
