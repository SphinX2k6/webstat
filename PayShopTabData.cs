using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x020023B3 RID: 9139
[NullableContext(1)]
[Nullable(0)]
public class PayShopTabData
{
	// Token: 0x06011A09 RID: 72201 RVA: 0x004D6230 File Offset: 0x004D4430
	public void Phrase(PayShopTabConfigInfo info)
	{
		this.ShopId = info.ShopId;
		this.TabId = info.TabId;
		this.Sort = info.Sort;
		this.Name = info.Name;
		this.Logic = info.Logic;
		this.Enable = info.Enable;
		this.SpriteBgPath = info.TabSelectSpritePath;
		this.TextureBgPath = info.TabContentPath;
		this.BeginTime = info.BeginTime;
		this.EndTime = info.EndTime;
		this.MoneyList = info.Money.ToList<int>();
	}

	// Token: 0x04008A15 RID: 35349
	public int ShopId;

	// Token: 0x04008A16 RID: 35350
	public int TabId;

	// Token: 0x04008A17 RID: 35351
	public int Sort;

	// Token: 0x04008A18 RID: 35352
	public string Name = "";

	// Token: 0x04008A19 RID: 35353
	public int Logic;

	// Token: 0x04008A1A RID: 35354
	public bool Enable = true;

	// Token: 0x04008A1B RID: 35355
	public string SpriteBgPath = "";

	// Token: 0x04008A1C RID: 35356
	public string TextureBgPath = "";

	// Token: 0x04008A1D RID: 35357
	public long BeginTime;

	// Token: 0x04008A1E RID: 35358
	public long EndTime;

	// Token: 0x04008A1F RID: 35359
	public List<int> MoneyList = new List<int>();
}
