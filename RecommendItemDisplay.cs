using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200115B RID: 4443
[NullableContext(1)]
[Nullable(0)]
public struct RecommendItemDisplay
{
	// Token: 0x040038A4 RID: 14500
	public int Id;

	// Token: 0x040038A5 RID: 14501
	public EActivityRecommendType Type;

	// Token: 0x040038A6 RID: 14502
	public string Title;

	// Token: 0x040038A7 RID: 14503
	public RecommendTextLocalize? SubTitle;

	// Token: 0x040038A8 RID: 14504
	public ERecommendIconSource IconSource;

	// Token: 0x040038A9 RID: 14505
	[Nullable(2)]
	public string IconSpritePath;

	// Token: 0x040038AA RID: 14506
	[Nullable(2)]
	public string IconTexturePath;

	// Token: 0x040038AB RID: 14507
	public RecommendTagDisplay? Tag;

	// Token: 0x040038AC RID: 14508
	public List<TItem> RewardList;

	// Token: 0x040038AD RID: 14509
	public bool ShowJumpBtn;

	// Token: 0x040038AE RID: 14510
	public bool ShowPreOpenBtn;

	// Token: 0x040038AF RID: 14511
	public bool ShowLockedBtn;

	// Token: 0x040038B0 RID: 14512
	public bool ShowDownMask;

	// Token: 0x040038B1 RID: 14513
	public bool IsMainQuestFinished;

	// Token: 0x040038B2 RID: 14514
	public bool IsBigIcon;
}
