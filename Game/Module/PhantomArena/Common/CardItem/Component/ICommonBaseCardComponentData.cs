using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardItem.Component
{
	// Token: 0x0200555A RID: 21850
	[NullableContext(1)]
	public interface ICommonBaseCardComponentData
	{
		// Token: 0x17008F56 RID: 36694
		// (get) Token: 0x06037AE5 RID: 228069
		// (set) Token: 0x06037AE6 RID: 228070
		int CardId { get; set; }

		// Token: 0x17008F57 RID: 36695
		// (get) Token: 0x06037AE7 RID: 228071
		// (set) Token: 0x06037AE8 RID: 228072
		int Cost { get; set; }

		// Token: 0x17008F58 RID: 36696
		// (get) Token: 0x06037AE9 RID: 228073
		// (set) Token: 0x06037AEA RID: 228074
		int Attack { get; set; }

		// Token: 0x17008F59 RID: 36697
		// (get) Token: 0x06037AEB RID: 228075
		// (set) Token: 0x06037AEC RID: 228076
		int Life { get; set; }

		// Token: 0x17008F5A RID: 36698
		// (get) Token: 0x06037AED RID: 228077
		// (set) Token: 0x06037AEE RID: 228078
		int Element { get; set; }

		// Token: 0x17008F5B RID: 36699
		// (get) Token: 0x06037AEF RID: 228079
		// (set) Token: 0x06037AF0 RID: 228080
		bool ShowCardFaceTexture { get; set; }

		// Token: 0x17008F5C RID: 36700
		// (get) Token: 0x06037AF1 RID: 228081
		// (set) Token: 0x06037AF2 RID: 228082
		bool OutlookUnlocked { get; set; }

		// Token: 0x17008F5D RID: 36701
		// (get) Token: 0x06037AF3 RID: 228083
		// (set) Token: 0x06037AF4 RID: 228084
		string CardFaceTexturePath { get; set; }

		// Token: 0x17008F5E RID: 36702
		// (get) Token: 0x06037AF5 RID: 228085
		// (set) Token: 0x06037AF6 RID: 228086
		EToggleState? ToggleState { get; set; }

		// Token: 0x17008F5F RID: 36703
		// (get) Token: 0x06037AF7 RID: 228087
		// (set) Token: 0x06037AF8 RID: 228088
		Action OnPointerUp { get; set; }

		// Token: 0x17008F60 RID: 36704
		// (get) Token: 0x06037AF9 RID: 228089
		// (set) Token: 0x06037AFA RID: 228090
		Action<EToggleState> OnToggleStateChanged { get; set; }

		// Token: 0x17008F61 RID: 36705
		// (get) Token: 0x06037AFB RID: 228091
		// (set) Token: 0x06037AFC RID: 228092
		Func<bool> CanToggleExecuteChange { get; set; }
	}
}
