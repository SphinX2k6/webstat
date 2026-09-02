using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x020023B2 RID: 9138
[NullableContext(1)]
[Nullable(0)]
public class PayShopRecommendData
{
	// Token: 0x06011A07 RID: 72199 RVA: 0x004D6190 File Offset: 0x004D4390
	public void Phrase(PayShopRecommendConfigInfo info)
	{
		this.Id = info.Id;
		this.RecommendType = info.RecommendType;
		this.RecommendId = info.RecommendId;
		this.TabName = info.TabName;
		this.PrefabPath = info.PrefabPath;
		this.Sort = info.Sort;
		this.Show = info.Show;
		this.TabImage = info.TabImage;
	}

	// Token: 0x04008A0D RID: 35341
	public int Id;

	// Token: 0x04008A0E RID: 35342
	public int RecommendType;

	// Token: 0x04008A0F RID: 35343
	public int RecommendId;

	// Token: 0x04008A10 RID: 35344
	public string TabName = "";

	// Token: 0x04008A11 RID: 35345
	public string PrefabPath = "";

	// Token: 0x04008A12 RID: 35346
	public int Sort;

	// Token: 0x04008A13 RID: 35347
	public bool Show = true;

	// Token: 0x04008A14 RID: 35348
	public string TabImage = "";
}
