using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.HonamiStory;
using UnrealEngine;

// Token: 0x02001F3C RID: 7996
[NullableContext(2)]
[Nullable(0)]
public class HonamiStoryMainButtonConfig : IHonamiStoryMainButtonConfig
{
	// Token: 0x17001240 RID: 4672
	// (get) Token: 0x0600EF17 RID: 61207 RVA: 0x00415888 File Offset: 0x00413A88
	// (set) Token: 0x0600EF18 RID: 61208 RVA: 0x00415890 File Offset: 0x00413A90
	public EHonamiStoryMainButtonFunctionType Type { get; set; }

	// Token: 0x17001241 RID: 4673
	// (get) Token: 0x0600EF19 RID: 61209 RVA: 0x00415899 File Offset: 0x00413A99
	// (set) Token: 0x0600EF1A RID: 61210 RVA: 0x004158A1 File Offset: 0x00413AA1
	public EHonamiStoryMainComponent ComponentId { get; set; }

	// Token: 0x17001242 RID: 4674
	// (get) Token: 0x0600EF1B RID: 61211 RVA: 0x004158AA File Offset: 0x00413AAA
	// (set) Token: 0x0600EF1C RID: 61212 RVA: 0x004158B2 File Offset: 0x00413AB2
	public EFunctionType? FunctionId { get; set; }

	// Token: 0x17001243 RID: 4675
	// (get) Token: 0x0600EF1D RID: 61213 RVA: 0x004158BB File Offset: 0x00413ABB
	// (set) Token: 0x0600EF1E RID: 61214 RVA: 0x004158C3 File Offset: 0x00413AC3
	public Func<bool> ShowRedDot { get; set; }

	// Token: 0x17001244 RID: 4676
	// (get) Token: 0x0600EF1F RID: 61215 RVA: 0x004158CC File Offset: 0x00413ACC
	// (set) Token: 0x0600EF20 RID: 61216 RVA: 0x004158D4 File Offset: 0x00413AD4
	public Action<UUIText> SetTextCallback { get; set; }

	// Token: 0x17001245 RID: 4677
	// (get) Token: 0x0600EF21 RID: 61217 RVA: 0x004158DD File Offset: 0x00413ADD
	// (set) Token: 0x0600EF22 RID: 61218 RVA: 0x004158E5 File Offset: 0x00413AE5
	public Action OnClickCallback { get; set; }

	// Token: 0x17001246 RID: 4678
	// (get) Token: 0x0600EF23 RID: 61219 RVA: 0x004158EE File Offset: 0x00413AEE
	// (set) Token: 0x0600EF24 RID: 61220 RVA: 0x004158F6 File Offset: 0x00413AF6
	public Func<bool> ShowCallback { get; set; }

	// Token: 0x17001247 RID: 4679
	// (get) Token: 0x0600EF25 RID: 61221 RVA: 0x004158FF File Offset: 0x00413AFF
	// (set) Token: 0x0600EF26 RID: 61222 RVA: 0x00415907 File Offset: 0x00413B07
	public string SpecialSequenceName { get; set; }

	// Token: 0x17001248 RID: 4680
	// (get) Token: 0x0600EF27 RID: 61223 RVA: 0x00415910 File Offset: 0x00413B10
	// (set) Token: 0x0600EF28 RID: 61224 RVA: 0x00415918 File Offset: 0x00413B18
	public string SpecialParamName { get; set; }
}
