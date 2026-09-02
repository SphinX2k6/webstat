using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Prepare.DeckBuilder;

namespace CSharpScript.Game.Module.PhantomArena.Prepare
{
	// Token: 0x020054AF RID: 21679
	[NullableContext(1)]
	public interface IPhantomArenaDeckOverviewTabViewModel : IPhantomArenaTabViewModelBase
	{
		// Token: 0x17008E40 RID: 36416
		// (get) Token: 0x06037328 RID: 226088
		// (set) Token: 0x06037329 RID: 226089
		int UsedDeckIndex { get; set; }

		// Token: 0x17008E41 RID: 36417
		// (get) Token: 0x0603732A RID: 226090
		// (set) Token: 0x0603732B RID: 226091
		int SelectedDeckIndex { get; set; }

		// Token: 0x17008E42 RID: 36418
		// (get) Token: 0x0603732C RID: 226092
		// (set) Token: 0x0603732D RID: 226093
		[Nullable(2)]
		DeckInfo RecommendDeck { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17008E43 RID: 36419
		// (get) Token: 0x0603732E RID: 226094
		// (set) Token: 0x0603732F RID: 226095
		List<DeckInfo> EditableDeckList { get; set; }

		// Token: 0x17008E44 RID: 36420
		// (get) Token: 0x06037330 RID: 226096
		// (set) Token: 0x06037331 RID: 226097
		bool CanShowSelectBtnInDeckOverviewTabView { get; set; }

		// Token: 0x17008E45 RID: 36421
		// (get) Token: 0x06037332 RID: 226098
		// (set) Token: 0x06037333 RID: 226099
		bool DeckSelectedConfirmFlag { get; set; }

		// Token: 0x06037334 RID: 226100
		DeckInfo CreateEmptyTempDeck();

		// Token: 0x06037335 RID: 226101
		DeckInfo CreateTempDeckFromDeck(DeckInfo srcDeck);

		// Token: 0x06037336 RID: 226102
		void StartEditDeck(DeckInfo deck);

		// Token: 0x06037337 RID: 226103
		void UpdateEditableDeckList();

		// Token: 0x17008E46 RID: 36422
		// (get) Token: 0x06037338 RID: 226104
		// (set) Token: 0x06037339 RID: 226105
		Action<bool> HideRoleTexture { get; set; }

		// Token: 0x17008E47 RID: 36423
		// (get) Token: 0x0603733A RID: 226106
		// (set) Token: 0x0603733B RID: 226107
		Action<string> SetViewTitle { get; set; }

		// Token: 0x17008E48 RID: 36424
		// (get) Token: 0x0603733C RID: 226108
		// (set) Token: 0x0603733D RID: 226109
		Action<string> SetViewIcon { get; set; }

		// Token: 0x17008E49 RID: 36425
		// (get) Token: 0x0603733E RID: 226110
		// (set) Token: 0x0603733F RID: 226111
		Action<int> SetViewHelpId { get; set; }

		// Token: 0x17008E4A RID: 36426
		// (get) Token: 0x06037340 RID: 226112
		// (set) Token: 0x06037341 RID: 226113
		Action<bool> SetViewHelpBtnActive { get; set; }

		// Token: 0x06037342 RID: 226114
		void ReportDeckCreate(DeckInfo deckInfo);

		// Token: 0x06037343 RID: 226115
		void ReportDeckCover(DeckInfo deckInfo);

		// Token: 0x06037344 RID: 226116
		void ReportDeckDelete(DeckInfo deckInfo);

		// Token: 0x06037345 RID: 226117
		void SetOverrideCloseFunc(Action func);

		// Token: 0x06037346 RID: 226118
		void ResetOverrideCloseFunc();
	}
}
