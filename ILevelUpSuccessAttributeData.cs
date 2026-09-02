using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002895 RID: 10389
[NullableContext(2)]
public interface ILevelUpSuccessAttributeData
{
	// Token: 0x17001AFD RID: 6909
	// (get) Token: 0x06014929 RID: 84265
	// (set) Token: 0x0601492A RID: 84266
	string Title { get; set; }

	// Token: 0x17001AFE RID: 6910
	// (get) Token: 0x0601492B RID: 84267
	// (set) Token: 0x0601492C RID: 84268
	string AudioId { get; set; }

	// Token: 0x17001AFF RID: 6911
	// (get) Token: 0x0601492D RID: 84269
	// (set) Token: 0x0601492E RID: 84270
	ILevelInfo LevelInfo { get; set; }

	// Token: 0x17001B00 RID: 6912
	// (get) Token: 0x0601492F RID: 84271
	// (set) Token: 0x06014930 RID: 84272
	[Nullable(1)]
	List<IAttributeInfo> AttributeInfo { [NullableContext(1)] get; [NullableContext(1)] set; }

	// Token: 0x17001B01 RID: 6913
	// (get) Token: 0x06014931 RID: 84273
	// (set) Token: 0x06014932 RID: 84274
	bool? IsShowArrow { get; set; }

	// Token: 0x17001B02 RID: 6914
	// (get) Token: 0x06014933 RID: 84275
	// (set) Token: 0x06014934 RID: 84276
	string ClickText { get; set; }

	// Token: 0x17001B03 RID: 6915
	// (get) Token: 0x06014935 RID: 84277
	// (set) Token: 0x06014936 RID: 84278
	Action ClickFunction { get; set; }

	// Token: 0x17001B04 RID: 6916
	// (get) Token: 0x06014937 RID: 84279
	// (set) Token: 0x06014938 RID: 84280
	bool? WiderScrollView { get; set; }

	// Token: 0x17001B05 RID: 6917
	// (get) Token: 0x06014939 RID: 84281
	// (set) Token: 0x0601493A RID: 84282
	IStrengthUpgradeData StrengthUpgradeData { get; set; }
}
