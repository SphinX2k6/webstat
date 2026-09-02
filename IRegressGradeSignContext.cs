using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02001528 RID: 5416
[NullableContext(1)]
[Nullable(0)]
public struct IRegressGradeSignContext
{
	// Token: 0x17000D0E RID: 3342
	// (get) Token: 0x060097BE RID: 38846 RVA: 0x0027C332 File Offset: 0x0027A532
	// (set) Token: 0x060097BF RID: 38847 RVA: 0x0027C33A File Offset: 0x0027A53A
	public UUIButtonComponent Btn { readonly get; set; }

	// Token: 0x17000D0F RID: 3343
	// (get) Token: 0x060097C0 RID: 38848 RVA: 0x0027C343 File Offset: 0x0027A543
	// (set) Token: 0x060097C1 RID: 38849 RVA: 0x0027C34B File Offset: 0x0027A54B
	public UUIItem RedDotItem { readonly get; set; }

	// Token: 0x17000D10 RID: 3344
	// (get) Token: 0x060097C2 RID: 38850 RVA: 0x0027C354 File Offset: 0x0027A554
	// (set) Token: 0x060097C3 RID: 38851 RVA: 0x0027C35C File Offset: 0x0027A55C
	public UUITexture CurrencyTexNode { readonly get; set; }

	// Token: 0x17000D11 RID: 3345
	// (get) Token: 0x060097C4 RID: 38852 RVA: 0x0027C365 File Offset: 0x0027A565
	// (set) Token: 0x060097C5 RID: 38853 RVA: 0x0027C36D File Offset: 0x0027A56D
	public UUIText CurrencyText { readonly get; set; }

	// Token: 0x17000D12 RID: 3346
	// (get) Token: 0x060097C6 RID: 38854 RVA: 0x0027C376 File Offset: 0x0027A576
	// (set) Token: 0x060097C7 RID: 38855 RVA: 0x0027C37E File Offset: 0x0027A57E
	public UUIItem BubbleNode { readonly get; set; }
}
