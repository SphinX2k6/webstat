using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.DeckBuilder
{
	// Token: 0x020054FB RID: 21755
	[NullableContext(1)]
	public interface IDeckBuilderDeckSlotsPanelData
	{
		// Token: 0x17008EDF RID: 36575
		// (get) Token: 0x060376EC RID: 227052
		// (set) Token: 0x060376ED RID: 227053
		DeckInfo DeckInfo { get; set; }

		// Token: 0x17008EE0 RID: 36576
		// (get) Token: 0x060376EE RID: 227054
		// (set) Token: 0x060376EF RID: 227055
		float? SlotLongPressStartTime { get; set; }

		// Token: 0x17008EE1 RID: 36577
		// (get) Token: 0x060376F0 RID: 227056
		// (set) Token: 0x060376F1 RID: 227057
		float? SlotLongPressEndTime { get; set; }

		// Token: 0x17008EE2 RID: 36578
		// (get) Token: 0x060376F2 RID: 227058
		// (set) Token: 0x060376F3 RID: 227059
		[Nullable(new byte[]
		{
			2,
			1
		})]
		Action<DeckBuilderCardSlotItem> OnCoreSlotItemSortClick { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x17008EE3 RID: 36579
		// (get) Token: 0x060376F4 RID: 227060
		// (set) Token: 0x060376F5 RID: 227061
		[Nullable(new byte[]
		{
			2,
			1
		})]
		Action<DeckBuilderCardSlotItem, float> OnCoreSlotItemLongPress { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x17008EE4 RID: 36580
		// (get) Token: 0x060376F6 RID: 227062
		// (set) Token: 0x060376F7 RID: 227063
		[Nullable(2)]
		Action OnSlotItemLongPressEnd { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17008EE5 RID: 36581
		// (get) Token: 0x060376F8 RID: 227064
		// (set) Token: 0x060376F9 RID: 227065
		[Nullable(new byte[]
		{
			2,
			1
		})]
		Action<DeckBuilderCardSlotItem, EToggleState> OnCoreSlotItemToggleStateChange { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x17008EE6 RID: 36582
		// (get) Token: 0x060376FA RID: 227066
		// (set) Token: 0x060376FB RID: 227067
		Func<DeckBuilderCardSlotItem, bool> CanCoreSlotItemToggleChange { get; set; }

		// Token: 0x17008EE7 RID: 36583
		// (get) Token: 0x060376FC RID: 227068
		// (set) Token: 0x060376FD RID: 227069
		[Nullable(new byte[]
		{
			2,
			1
		})]
		Action<DeckBuilderCardSlotItem> OnNormalSlotItemSortClick { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x17008EE8 RID: 36584
		// (get) Token: 0x060376FE RID: 227070
		// (set) Token: 0x060376FF RID: 227071
		[Nullable(new byte[]
		{
			2,
			1
		})]
		Action<DeckBuilderCardSlotItem, float> OnNormalSlotItemLongPress { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x17008EE9 RID: 36585
		// (get) Token: 0x06037700 RID: 227072
		// (set) Token: 0x06037701 RID: 227073
		[Nullable(new byte[]
		{
			2,
			1
		})]
		Action<DeckBuilderCardSlotItem, EToggleState> OnNormalSlotItemToggleStateChange { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x17008EEA RID: 36586
		// (get) Token: 0x06037702 RID: 227074
		// (set) Token: 0x06037703 RID: 227075
		Func<DeckBuilderCardSlotItem, bool> CanNormalSlotItemToggleChange { get; set; }

		// Token: 0x17008EEB RID: 36587
		// (get) Token: 0x06037704 RID: 227076
		// (set) Token: 0x06037705 RID: 227077
		[Nullable(new byte[]
		{
			2,
			1
		})]
		Action<DeckBuilderCardSlotItem, EToggleState> OnFieldSlotItemToggleStateChange { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x17008EEC RID: 36588
		// (get) Token: 0x06037706 RID: 227078
		// (set) Token: 0x06037707 RID: 227079
		Func<DeckBuilderCardSlotItem, bool> CanFieldSlotItemToggleChange { get; set; }

		// Token: 0x17008EED RID: 36589
		// (get) Token: 0x06037708 RID: 227080
		// (set) Token: 0x06037709 RID: 227081
		[Nullable(new byte[]
		{
			2,
			1
		})]
		Action<DeckBuilderCardSlotItem> OnFieldCardItemEffectBtnClick { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x17008EEE RID: 36590
		// (get) Token: 0x0603770A RID: 227082
		// (set) Token: 0x0603770B RID: 227083
		[Nullable(2)]
		Action<int> OnSlotCardPointEnterCallback { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17008EEF RID: 36591
		// (get) Token: 0x0603770C RID: 227084
		// (set) Token: 0x0603770D RID: 227085
		[Nullable(2)]
		Action OnSlotCardPointExitCallback { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17008EF0 RID: 36592
		// (get) Token: 0x0603770E RID: 227086
		// (set) Token: 0x0603770F RID: 227087
		CardSlotSortContext SortContext { get; set; }

		// Token: 0x17008EF1 RID: 36593
		// (get) Token: 0x06037710 RID: 227088
		// (set) Token: 0x06037711 RID: 227089
		bool ShowLocked { get; set; }

		// Token: 0x17008EF2 RID: 36594
		// (get) Token: 0x06037712 RID: 227090
		// (set) Token: 0x06037713 RID: 227091
		bool ShowOutlook { get; set; }

		// Token: 0x17008EF3 RID: 36595
		// (get) Token: 0x06037714 RID: 227092
		// (set) Token: 0x06037715 RID: 227093
		bool IsNeedFieldCard { get; set; }

		// Token: 0x17008EF4 RID: 36596
		// (get) Token: 0x06037716 RID: 227094
		// (set) Token: 0x06037717 RID: 227095
		bool IsNeedRequestCheckCardSkillUnlock { get; set; }
	}
}
