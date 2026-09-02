using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x0200115A RID: 4442
[NullableContext(2)]
[Nullable(0)]
public struct RecommendTagDisplay
{
	// Token: 0x0400389E RID: 14494
	public ERecommendTagStyle Style;

	// Token: 0x0400389F RID: 14495
	public string Text;

	// Token: 0x040038A0 RID: 14496
	public RecommendTextLocalize? TextLocalize;

	// Token: 0x040038A1 RID: 14497
	[Nullable(1)]
	public string BgSpritePath;

	// Token: 0x040038A2 RID: 14498
	public string IconSpritePath;

	// Token: 0x040038A3 RID: 14499
	public FColor? IconColor;
}
