using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x0200284B RID: 10315
[NullableContext(1)]
[Nullable(0)]
public class RoleFavorPreciousItemClassifyData : RoleFavorClassifyDataBase
{
	// Token: 0x06014762 RID: 83810 RVA: 0x005AE910 File Offset: 0x005ACB10
	public RoleFavorPreciousItemClassifyData(string titleTableId, int roleId) : base(titleTableId, roleId)
	{
	}

	// Token: 0x06014763 RID: 83811 RVA: 0x005AE91A File Offset: 0x005ACB1A
	protected override EFavorTabType GetFavorTabType()
	{
		return EFavorTabType.PreciousItem;
	}

	// Token: 0x06014764 RID: 83812 RVA: 0x005AE920 File Offset: 0x005ACB20
	protected override void InitContentDataList()
	{
		this.ContentDataList.Clear();
		IReadOnlyList<FavorGoods> favorGoodsConfig = ConfigBase<RoleFavorConfig>.Instance.GetFavorGoodsConfig(this.RoleId);
		if (favorGoodsConfig == null)
		{
			return;
		}
		int count = favorGoodsConfig.Count;
		for (int i = 0; i < count; i++)
		{
			FavorGoods config = favorGoodsConfig[i];
			this.ContentDataList.Add(this.CreatePreciousItemContentData(config));
		}
	}

	// Token: 0x06014765 RID: 83813 RVA: 0x005AE97A File Offset: 0x005ACB7A
	private RoleFavorPreciousItemContentData CreatePreciousItemContentData(FavorGoods config)
	{
		return new RoleFavorPreciousItemContentData(this.RoleId, config);
	}
}
