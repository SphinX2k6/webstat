using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PayShop;

// Token: 0x020023EC RID: 9196
[NullableContext(1)]
[Nullable(0)]
public class IGiftItemRegistryEntry
{
	// Token: 0x1700166F RID: 5743
	// (get) Token: 0x06011CC8 RID: 72904 RVA: 0x004E56AB File Offset: 0x004E38AB
	// (set) Token: 0x06011CC9 RID: 72905 RVA: 0x004E56B3 File Offset: 0x004E38B3
	public Func<PayShopGoods, bool> Check { get; set; }

	// Token: 0x17001670 RID: 5744
	// (get) Token: 0x06011CCA RID: 72906 RVA: 0x004E56BC File Offset: 0x004E38BC
	// (set) Token: 0x06011CCB RID: 72907 RVA: 0x004E56C4 File Offset: 0x004E38C4
	public string Resource { get; set; }

	// Token: 0x17001671 RID: 5745
	// (get) Token: 0x06011CCC RID: 72908 RVA: 0x004E56CD File Offset: 0x004E38CD
	// (set) Token: 0x06011CCD RID: 72909 RVA: 0x004E56D5 File Offset: 0x004E38D5
	public Func<IGiftDisplayItem> Create { get; set; }
}
