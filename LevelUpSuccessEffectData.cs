using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002892 RID: 10386
[NullableContext(2)]
[Nullable(0)]
public class LevelUpSuccessEffectData : ILevelUpSuccessEffectData
{
	// Token: 0x17001AF0 RID: 6896
	// (get) Token: 0x0601490D RID: 84237 RVA: 0x005B2C87 File Offset: 0x005B0E87
	// (set) Token: 0x0601490E RID: 84238 RVA: 0x005B2C8F File Offset: 0x005B0E8F
	public string Title { get; set; }

	// Token: 0x17001AF1 RID: 6897
	// (get) Token: 0x0601490F RID: 84239 RVA: 0x005B2C98 File Offset: 0x005B0E98
	// (set) Token: 0x06014910 RID: 84240 RVA: 0x005B2CA0 File Offset: 0x005B0EA0
	public string AudioId { get; set; }

	// Token: 0x17001AF2 RID: 6898
	// (get) Token: 0x06014911 RID: 84241 RVA: 0x005B2CA9 File Offset: 0x005B0EA9
	// (set) Token: 0x06014912 RID: 84242 RVA: 0x005B2CB1 File Offset: 0x005B0EB1
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<SingleText> TextList { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }

	// Token: 0x17001AF3 RID: 6899
	// (get) Token: 0x06014913 RID: 84243 RVA: 0x005B2CBA File Offset: 0x005B0EBA
	// (set) Token: 0x06014914 RID: 84244 RVA: 0x005B2CC2 File Offset: 0x005B0EC2
	public string ClickText { get; set; }

	// Token: 0x17001AF4 RID: 6900
	// (get) Token: 0x06014915 RID: 84245 RVA: 0x005B2CCB File Offset: 0x005B0ECB
	// (set) Token: 0x06014916 RID: 84246 RVA: 0x005B2CD3 File Offset: 0x005B0ED3
	public Action ClickFunction { get; set; }
}
