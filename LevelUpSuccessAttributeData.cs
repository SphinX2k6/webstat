using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002896 RID: 10390
[NullableContext(2)]
[Nullable(0)]
public class LevelUpSuccessAttributeData : ILevelUpSuccessAttributeData
{
	// Token: 0x17001B06 RID: 6918
	// (get) Token: 0x0601493B RID: 84283 RVA: 0x005B2D30 File Offset: 0x005B0F30
	// (set) Token: 0x0601493C RID: 84284 RVA: 0x005B2D38 File Offset: 0x005B0F38
	public string Title { get; set; }

	// Token: 0x17001B07 RID: 6919
	// (get) Token: 0x0601493D RID: 84285 RVA: 0x005B2D41 File Offset: 0x005B0F41
	// (set) Token: 0x0601493E RID: 84286 RVA: 0x005B2D49 File Offset: 0x005B0F49
	public string AudioId { get; set; }

	// Token: 0x17001B08 RID: 6920
	// (get) Token: 0x0601493F RID: 84287 RVA: 0x005B2D52 File Offset: 0x005B0F52
	// (set) Token: 0x06014940 RID: 84288 RVA: 0x005B2D5A File Offset: 0x005B0F5A
	public ILevelInfo LevelInfo { get; set; }

	// Token: 0x17001B09 RID: 6921
	// (get) Token: 0x06014941 RID: 84289 RVA: 0x005B2D63 File Offset: 0x005B0F63
	// (set) Token: 0x06014942 RID: 84290 RVA: 0x005B2D6B File Offset: 0x005B0F6B
	[Nullable(1)]
	public List<IAttributeInfo> AttributeInfo { [NullableContext(1)] get; [NullableContext(1)] set; }

	// Token: 0x17001B0A RID: 6922
	// (get) Token: 0x06014943 RID: 84291 RVA: 0x005B2D74 File Offset: 0x005B0F74
	// (set) Token: 0x06014944 RID: 84292 RVA: 0x005B2D7C File Offset: 0x005B0F7C
	public bool? IsShowArrow { get; set; }

	// Token: 0x17001B0B RID: 6923
	// (get) Token: 0x06014945 RID: 84293 RVA: 0x005B2D85 File Offset: 0x005B0F85
	// (set) Token: 0x06014946 RID: 84294 RVA: 0x005B2D8D File Offset: 0x005B0F8D
	public string ClickText { get; set; }

	// Token: 0x17001B0C RID: 6924
	// (get) Token: 0x06014947 RID: 84295 RVA: 0x005B2D96 File Offset: 0x005B0F96
	// (set) Token: 0x06014948 RID: 84296 RVA: 0x005B2D9E File Offset: 0x005B0F9E
	public Action ClickFunction { get; set; }

	// Token: 0x17001B0D RID: 6925
	// (get) Token: 0x06014949 RID: 84297 RVA: 0x005B2DA7 File Offset: 0x005B0FA7
	// (set) Token: 0x0601494A RID: 84298 RVA: 0x005B2DAF File Offset: 0x005B0FAF
	public bool? WiderScrollView { get; set; }

	// Token: 0x17001B0E RID: 6926
	// (get) Token: 0x0601494B RID: 84299 RVA: 0x005B2DB8 File Offset: 0x005B0FB8
	// (set) Token: 0x0601494C RID: 84300 RVA: 0x005B2DC0 File Offset: 0x005B0FC0
	public IStrengthUpgradeData StrengthUpgradeData { get; set; }
}
