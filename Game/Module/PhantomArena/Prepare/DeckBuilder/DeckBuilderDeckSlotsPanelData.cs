using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.DeckBuilder
{
	// Token: 0x020054FC RID: 21756
	[NullableContext(1)]
	[Nullable(0)]
	public class DeckBuilderDeckSlotsPanelData : IDeckBuilderDeckSlotsPanelData
	{
		// Token: 0x17008EF5 RID: 36597
		// (get) Token: 0x06037718 RID: 227096 RVA: 0x00E0FF29 File Offset: 0x00E0E129
		// (set) Token: 0x06037719 RID: 227097 RVA: 0x00E0FF31 File Offset: 0x00E0E131
		public DeckInfo DeckInfo { get; set; }

		// Token: 0x17008EF6 RID: 36598
		// (get) Token: 0x0603771A RID: 227098 RVA: 0x00E0FF3A File Offset: 0x00E0E13A
		// (set) Token: 0x0603771B RID: 227099 RVA: 0x00E0FF42 File Offset: 0x00E0E142
		public float? SlotLongPressStartTime { get; set; }

		// Token: 0x17008EF7 RID: 36599
		// (get) Token: 0x0603771C RID: 227100 RVA: 0x00E0FF4B File Offset: 0x00E0E14B
		// (set) Token: 0x0603771D RID: 227101 RVA: 0x00E0FF53 File Offset: 0x00E0E153
		public float? SlotLongPressEndTime { get; set; }

		// Token: 0x17008EF8 RID: 36600
		// (get) Token: 0x0603771E RID: 227102 RVA: 0x00E0FF5C File Offset: 0x00E0E15C
		// (set) Token: 0x0603771F RID: 227103 RVA: 0x00E0FF64 File Offset: 0x00E0E164
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<DeckBuilderCardSlotItem> OnCoreSlotItemSortClick { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x17008EF9 RID: 36601
		// (get) Token: 0x06037720 RID: 227104 RVA: 0x00E0FF6D File Offset: 0x00E0E16D
		// (set) Token: 0x06037721 RID: 227105 RVA: 0x00E0FF75 File Offset: 0x00E0E175
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<DeckBuilderCardSlotItem, float> OnCoreSlotItemLongPress { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x17008EFA RID: 36602
		// (get) Token: 0x06037722 RID: 227106 RVA: 0x00E0FF7E File Offset: 0x00E0E17E
		// (set) Token: 0x06037723 RID: 227107 RVA: 0x00E0FF86 File Offset: 0x00E0E186
		[Nullable(2)]
		public Action OnSlotItemLongPressEnd { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17008EFB RID: 36603
		// (get) Token: 0x06037724 RID: 227108 RVA: 0x00E0FF8F File Offset: 0x00E0E18F
		// (set) Token: 0x06037725 RID: 227109 RVA: 0x00E0FF97 File Offset: 0x00E0E197
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<DeckBuilderCardSlotItem, EToggleState> OnCoreSlotItemToggleStateChange { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x17008EFC RID: 36604
		// (get) Token: 0x06037726 RID: 227110 RVA: 0x00E0FFA0 File Offset: 0x00E0E1A0
		// (set) Token: 0x06037727 RID: 227111 RVA: 0x00E0FFA8 File Offset: 0x00E0E1A8
		public Func<DeckBuilderCardSlotItem, bool> CanCoreSlotItemToggleChange { get; set; }

		// Token: 0x17008EFD RID: 36605
		// (get) Token: 0x06037728 RID: 227112 RVA: 0x00E0FFB1 File Offset: 0x00E0E1B1
		// (set) Token: 0x06037729 RID: 227113 RVA: 0x00E0FFB9 File Offset: 0x00E0E1B9
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<DeckBuilderCardSlotItem> OnNormalSlotItemSortClick { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x17008EFE RID: 36606
		// (get) Token: 0x0603772A RID: 227114 RVA: 0x00E0FFC2 File Offset: 0x00E0E1C2
		// (set) Token: 0x0603772B RID: 227115 RVA: 0x00E0FFCA File Offset: 0x00E0E1CA
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<DeckBuilderCardSlotItem, float> OnNormalSlotItemLongPress { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x17008EFF RID: 36607
		// (get) Token: 0x0603772C RID: 227116 RVA: 0x00E0FFD3 File Offset: 0x00E0E1D3
		// (set) Token: 0x0603772D RID: 227117 RVA: 0x00E0FFDB File Offset: 0x00E0E1DB
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<DeckBuilderCardSlotItem, EToggleState> OnNormalSlotItemToggleStateChange { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x17008F00 RID: 36608
		// (get) Token: 0x0603772E RID: 227118 RVA: 0x00E0FFE4 File Offset: 0x00E0E1E4
		// (set) Token: 0x0603772F RID: 227119 RVA: 0x00E0FFEC File Offset: 0x00E0E1EC
		public Func<DeckBuilderCardSlotItem, bool> CanNormalSlotItemToggleChange { get; set; }

		// Token: 0x17008F01 RID: 36609
		// (get) Token: 0x06037730 RID: 227120 RVA: 0x00E0FFF5 File Offset: 0x00E0E1F5
		// (set) Token: 0x06037731 RID: 227121 RVA: 0x00E0FFFD File Offset: 0x00E0E1FD
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<DeckBuilderCardSlotItem, EToggleState> OnFieldSlotItemToggleStateChange { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x17008F02 RID: 36610
		// (get) Token: 0x06037732 RID: 227122 RVA: 0x00E10006 File Offset: 0x00E0E206
		// (set) Token: 0x06037733 RID: 227123 RVA: 0x00E1000E File Offset: 0x00E0E20E
		public Func<DeckBuilderCardSlotItem, bool> CanFieldSlotItemToggleChange { get; set; }

		// Token: 0x17008F03 RID: 36611
		// (get) Token: 0x06037734 RID: 227124 RVA: 0x00E10017 File Offset: 0x00E0E217
		// (set) Token: 0x06037735 RID: 227125 RVA: 0x00E1001F File Offset: 0x00E0E21F
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<DeckBuilderCardSlotItem> OnFieldCardItemEffectBtnClick { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x17008F04 RID: 36612
		// (get) Token: 0x06037736 RID: 227126 RVA: 0x00E10028 File Offset: 0x00E0E228
		// (set) Token: 0x06037737 RID: 227127 RVA: 0x00E10030 File Offset: 0x00E0E230
		[Nullable(2)]
		public Action<int> OnSlotCardPointEnterCallback { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17008F05 RID: 36613
		// (get) Token: 0x06037738 RID: 227128 RVA: 0x00E10039 File Offset: 0x00E0E239
		// (set) Token: 0x06037739 RID: 227129 RVA: 0x00E10041 File Offset: 0x00E0E241
		[Nullable(2)]
		public Action OnSlotCardPointExitCallback { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17008F06 RID: 36614
		// (get) Token: 0x0603773A RID: 227130 RVA: 0x00E1004A File Offset: 0x00E0E24A
		// (set) Token: 0x0603773B RID: 227131 RVA: 0x00E10052 File Offset: 0x00E0E252
		public CardSlotSortContext SortContext { get; set; }

		// Token: 0x17008F07 RID: 36615
		// (get) Token: 0x0603773C RID: 227132 RVA: 0x00E1005B File Offset: 0x00E0E25B
		// (set) Token: 0x0603773D RID: 227133 RVA: 0x00E10063 File Offset: 0x00E0E263
		public bool ShowLocked { get; set; }

		// Token: 0x17008F08 RID: 36616
		// (get) Token: 0x0603773E RID: 227134 RVA: 0x00E1006C File Offset: 0x00E0E26C
		// (set) Token: 0x0603773F RID: 227135 RVA: 0x00E10074 File Offset: 0x00E0E274
		public bool ShowOutlook { get; set; }

		// Token: 0x17008F09 RID: 36617
		// (get) Token: 0x06037740 RID: 227136 RVA: 0x00E1007D File Offset: 0x00E0E27D
		// (set) Token: 0x06037741 RID: 227137 RVA: 0x00E10085 File Offset: 0x00E0E285
		public bool IsNeedFieldCard { get; set; }

		// Token: 0x17008F0A RID: 36618
		// (get) Token: 0x06037742 RID: 227138 RVA: 0x00E1008E File Offset: 0x00E0E28E
		// (set) Token: 0x06037743 RID: 227139 RVA: 0x00E10096 File Offset: 0x00E0E296
		public bool IsNeedRequestCheckCardSkillUnlock { get; set; }
	}
}
