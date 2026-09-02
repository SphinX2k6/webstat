using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005124 RID: 20772
	[NullableContext(2)]
	[Nullable(0)]
	public class RoguelikeAchieveSlotData
	{
		// Token: 0x060357D7 RID: 219095 RVA: 0x00D6DE9C File Offset: 0x00D6C09C
		public RoguelikeAchieveSlotData(int slotIndex, RogueArchiveInfoData archiveInfoData)
		{
			this.SlotIndex = slotIndex;
			this.ArchiveInfoData = archiveInfoData;
		}

		// Token: 0x0401EBF8 RID: 125944
		public int SlotIndex;

		// Token: 0x0401EBF9 RID: 125945
		public RogueArchiveInfoData ArchiveInfoData;
	}
}
