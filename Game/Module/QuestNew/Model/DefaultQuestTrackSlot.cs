using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.QuestNew.Model
{
	// Token: 0x0200530E RID: 21262
	[NullableContext(2)]
	[Nullable(0)]
	public class DefaultQuestTrackSlot : IQuestTrackSlot
	{
		// Token: 0x06036481 RID: 222337 RVA: 0x00DAF0EE File Offset: 0x00DAD2EE
		public Quest GetTrack()
		{
			return this.CurTrackQuest;
		}

		// Token: 0x06036482 RID: 222338 RVA: 0x00DAF0F6 File Offset: 0x00DAD2F6
		public void SetTrack(Quest quest)
		{
			this.CurTrackQuest = quest;
		}

		// Token: 0x06036483 RID: 222339 RVA: 0x00DAF0FF File Offset: 0x00DAD2FF
		[NullableContext(1)]
		public bool Accept(Quest quest)
		{
			return true;
		}

		// Token: 0x0401F34B RID: 127819
		private Quest CurTrackQuest;
	}
}
