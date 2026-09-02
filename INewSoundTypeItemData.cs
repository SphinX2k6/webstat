using System;
using CSharpScript.Game.Module.AdventureGuide;
using CSharpScript.Game.Ui;

// Token: 0x0200175B RID: 5979
public interface INewSoundTypeItemData
{
	// Token: 0x17000DCE RID: 3534
	// (get) Token: 0x0600A80E RID: 43022
	// (set) Token: 0x0600A80F RID: 43023
	EUiTabViewName? FromTabViewName { get; set; }

	// Token: 0x17000DCF RID: 3535
	// (get) Token: 0x0600A810 RID: 43024
	// (set) Token: 0x0600A811 RID: 43025
	EDungeonType TypeId { get; set; }
}
