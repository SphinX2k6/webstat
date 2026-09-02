using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.Sequence.Assistant
{
	// Token: 0x020053A8 RID: 21416
	[NullableContext(1)]
	[Nullable(0)]
	public class CacheDialogueData
	{
		// Token: 0x060369F9 RID: 223737 RVA: 0x00DD554C File Offset: 0x00DD374C
		public CacheDialogueData(bool show, string dialogueId, float guardTime, float audioDelay, float audioTransitionDuration, ELanguageAudio languageAudio, float autoPlayDelay, TArray<int> unisonIdList)
		{
			this.Show = show;
			this.DialogueId = dialogueId;
			this.GuardTime = guardTime;
			this.AudioDelay = audioDelay;
			this.AudioTransitionDuration = audioTransitionDuration;
			this.LanguageAudio = languageAudio;
			this.AutoPlayDelay = autoPlayDelay;
			this.UnisonIdList = unisonIdList;
		}

		// Token: 0x0401F74F RID: 128847
		public readonly bool Show;

		// Token: 0x0401F750 RID: 128848
		public readonly string DialogueId;

		// Token: 0x0401F751 RID: 128849
		public readonly float GuardTime;

		// Token: 0x0401F752 RID: 128850
		public readonly float AudioDelay;

		// Token: 0x0401F753 RID: 128851
		public readonly float AudioTransitionDuration;

		// Token: 0x0401F754 RID: 128852
		public readonly ELanguageAudio LanguageAudio;

		// Token: 0x0401F755 RID: 128853
		public readonly float AutoPlayDelay;

		// Token: 0x0401F756 RID: 128854
		public readonly TArray<int> UnisonIdList;
	}
}
