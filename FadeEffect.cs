using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

// Token: 0x02002A8D RID: 10893
[NullableContext(2)]
[Nullable(0)]
public class FadeEffect : IFadeEffect
{
	// Token: 0x17001C57 RID: 7255
	// (get) Token: 0x06015CE5 RID: 89317 RVA: 0x0060BEA8 File Offset: 0x0060A0A8
	// (set) Token: 0x06015CE6 RID: 89318 RVA: 0x0060BEB0 File Offset: 0x0060A0B0
	public EFadeInScreenShowType? FadeColor { get; set; }

	// Token: 0x17001C58 RID: 7256
	// (get) Token: 0x06015CE7 RID: 89319 RVA: 0x0060BEB9 File Offset: 0x0060A0B9
	// (set) Token: 0x06015CE8 RID: 89320 RVA: 0x0060BEC1 File Offset: 0x0060A0C1
	public float? FadeInTime { get; set; }

	// Token: 0x17001C59 RID: 7257
	// (get) Token: 0x06015CE9 RID: 89321 RVA: 0x0060BECA File Offset: 0x0060A0CA
	// (set) Token: 0x06015CEA RID: 89322 RVA: 0x0060BED2 File Offset: 0x0060A0D2
	public float? FadeOutTime { get; set; }

	// Token: 0x17001C5A RID: 7258
	// (get) Token: 0x06015CEB RID: 89323 RVA: 0x0060BEDB File Offset: 0x0060A0DB
	// (set) Token: 0x06015CEC RID: 89324 RVA: 0x0060BEE3 File Offset: 0x0060A0E3
	public string ScreenEffect { get; set; }
}
