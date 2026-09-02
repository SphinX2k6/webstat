using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Prepare.DeckBuilder;

namespace CSharpScript.Game.Module.PhantomArena.Prepare
{
	// Token: 0x020054B0 RID: 21680
	[NullableContext(1)]
	public interface IPhantomArenaDeckBuilderTabViewModel : IPhantomArenaTabViewModelBase
	{
		// Token: 0x17008E4B RID: 36427
		// (get) Token: 0x06037347 RID: 226119
		// (set) Token: 0x06037348 RID: 226120
		Dictionary<int, int> QuicklyBuildDeckUseTimes { get; set; }

		// Token: 0x17008E4C RID: 36428
		// (get) Token: 0x06037349 RID: 226121
		// (set) Token: 0x0603734A RID: 226122
		int LastQuicklyBuildId { get; set; }

		// Token: 0x0603734B RID: 226123
		[NullableContext(2)]
		DeckInfo GetCurEditDeck();

		// Token: 0x0603734C RID: 226124
		bool CheckCurEditDeckHasChange();

		// Token: 0x0603734D RID: 226125
		[NullableContext(2)]
		PhantomArenaMainViewSwitchItem GetSwitchItem();

		// Token: 0x0603734E RID: 226126
		void UpdateEditableDeckList();

		// Token: 0x0603734F RID: 226127
		void SetOverrideCloseFunc(Action func);

		// Token: 0x06037350 RID: 226128
		void ResetOverrideCloseFunc();

		// Token: 0x17008E4D RID: 36429
		// (get) Token: 0x06037351 RID: 226129
		// (set) Token: 0x06037352 RID: 226130
		Action<string> SetViewTitle { get; set; }

		// Token: 0x17008E4E RID: 36430
		// (get) Token: 0x06037353 RID: 226131
		// (set) Token: 0x06037354 RID: 226132
		Action<string> SetViewIcon { get; set; }

		// Token: 0x17008E4F RID: 36431
		// (get) Token: 0x06037355 RID: 226133
		// (set) Token: 0x06037356 RID: 226134
		Action<int> SetViewHelpId { get; set; }

		// Token: 0x17008E50 RID: 36432
		// (get) Token: 0x06037357 RID: 226135
		// (set) Token: 0x06037358 RID: 226136
		Action<bool> SetViewHelpBtnActive { get; set; }

		// Token: 0x06037359 RID: 226137
		void EndEditDeck();

		// Token: 0x0603735A RID: 226138
		void RecordQuicklyBuildClick(int quicklyBuildId);

		// Token: 0x0603735B RID: 226139
		void ReportDeckCreate(DeckInfo deckInfo);

		// Token: 0x0603735C RID: 226140
		void ReportDeckCover(DeckInfo deckInfo);
	}
}
