using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.QuestNew.Model
{
	// Token: 0x0200530D RID: 21261
	[NullableContext(2)]
	public interface IQuestTrackSlot
	{
		// Token: 0x0603647E RID: 222334
		Quest GetTrack();

		// Token: 0x0603647F RID: 222335
		void SetTrack(Quest quest);

		// Token: 0x06036480 RID: 222336
		[NullableContext(1)]
		bool Accept(Quest quest);
	}
}
