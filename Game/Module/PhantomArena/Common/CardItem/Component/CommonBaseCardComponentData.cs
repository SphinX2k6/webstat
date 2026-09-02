using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardItem.Component
{
	// Token: 0x0200555B RID: 21851
	[NullableContext(1)]
	[Nullable(0)]
	public class CommonBaseCardComponentData : ICommonBaseCardComponentData
	{
		// Token: 0x17008F62 RID: 36706
		// (get) Token: 0x06037AFD RID: 228093 RVA: 0x00E1F3BB File Offset: 0x00E1D5BB
		// (set) Token: 0x06037AFE RID: 228094 RVA: 0x00E1F3C3 File Offset: 0x00E1D5C3
		public int CardId { get; set; }

		// Token: 0x17008F63 RID: 36707
		// (get) Token: 0x06037AFF RID: 228095 RVA: 0x00E1F3CC File Offset: 0x00E1D5CC
		// (set) Token: 0x06037B00 RID: 228096 RVA: 0x00E1F3D4 File Offset: 0x00E1D5D4
		public int Cost { get; set; }

		// Token: 0x17008F64 RID: 36708
		// (get) Token: 0x06037B01 RID: 228097 RVA: 0x00E1F3DD File Offset: 0x00E1D5DD
		// (set) Token: 0x06037B02 RID: 228098 RVA: 0x00E1F3E5 File Offset: 0x00E1D5E5
		public int Attack { get; set; }

		// Token: 0x17008F65 RID: 36709
		// (get) Token: 0x06037B03 RID: 228099 RVA: 0x00E1F3EE File Offset: 0x00E1D5EE
		// (set) Token: 0x06037B04 RID: 228100 RVA: 0x00E1F3F6 File Offset: 0x00E1D5F6
		public int Life { get; set; }

		// Token: 0x17008F66 RID: 36710
		// (get) Token: 0x06037B05 RID: 228101 RVA: 0x00E1F3FF File Offset: 0x00E1D5FF
		// (set) Token: 0x06037B06 RID: 228102 RVA: 0x00E1F407 File Offset: 0x00E1D607
		public int Element { get; set; }

		// Token: 0x17008F67 RID: 36711
		// (get) Token: 0x06037B07 RID: 228103 RVA: 0x00E1F410 File Offset: 0x00E1D610
		// (set) Token: 0x06037B08 RID: 228104 RVA: 0x00E1F418 File Offset: 0x00E1D618
		public bool ShowCardFaceTexture { get; set; }

		// Token: 0x17008F68 RID: 36712
		// (get) Token: 0x06037B09 RID: 228105 RVA: 0x00E1F421 File Offset: 0x00E1D621
		// (set) Token: 0x06037B0A RID: 228106 RVA: 0x00E1F429 File Offset: 0x00E1D629
		public bool OutlookUnlocked { get; set; }

		// Token: 0x17008F69 RID: 36713
		// (get) Token: 0x06037B0B RID: 228107 RVA: 0x00E1F432 File Offset: 0x00E1D632
		// (set) Token: 0x06037B0C RID: 228108 RVA: 0x00E1F43A File Offset: 0x00E1D63A
		public string CardFaceTexturePath { get; set; }

		// Token: 0x17008F6A RID: 36714
		// (get) Token: 0x06037B0D RID: 228109 RVA: 0x00E1F443 File Offset: 0x00E1D643
		// (set) Token: 0x06037B0E RID: 228110 RVA: 0x00E1F44B File Offset: 0x00E1D64B
		public EToggleState? ToggleState { get; set; }

		// Token: 0x17008F6B RID: 36715
		// (get) Token: 0x06037B0F RID: 228111 RVA: 0x00E1F454 File Offset: 0x00E1D654
		// (set) Token: 0x06037B10 RID: 228112 RVA: 0x00E1F45C File Offset: 0x00E1D65C
		public Action OnPointerUp { get; set; }

		// Token: 0x17008F6C RID: 36716
		// (get) Token: 0x06037B11 RID: 228113 RVA: 0x00E1F465 File Offset: 0x00E1D665
		// (set) Token: 0x06037B12 RID: 228114 RVA: 0x00E1F46D File Offset: 0x00E1D66D
		public Action<EToggleState> OnToggleStateChanged { get; set; }

		// Token: 0x17008F6D RID: 36717
		// (get) Token: 0x06037B13 RID: 228115 RVA: 0x00E1F476 File Offset: 0x00E1D676
		// (set) Token: 0x06037B14 RID: 228116 RVA: 0x00E1F47E File Offset: 0x00E1D67E
		public Func<bool> CanToggleExecuteChange { get; set; }
	}
}
