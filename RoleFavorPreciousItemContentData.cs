using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02002851 RID: 10321
[NullableContext(1)]
[Nullable(0)]
public class RoleFavorPreciousItemContentData : RoleFavorContentDataBase
{
	// Token: 0x0601478B RID: 83851 RVA: 0x005AEB88 File Offset: 0x005ACD88
	public RoleFavorPreciousItemContentData(int roleId, FavorGoods configData) : base(roleId)
	{
		this.ConfigData = configData;
	}

	// Token: 0x17001AB4 RID: 6836
	// (get) Token: 0x0601478C RID: 83852 RVA: 0x005AEB98 File Offset: 0x005ACD98
	public override int ConfigId
	{
		get
		{
			return this.ConfigData.Id;
		}
	}

	// Token: 0x17001AB5 RID: 6837
	// (get) Token: 0x0601478D RID: 83853 RVA: 0x005AEBA5 File Offset: 0x005ACDA5
	public override int ConfigConGroupId
	{
		get
		{
			return this.ConfigData.CondGroupId;
		}
	}

	// Token: 0x17001AB6 RID: 6838
	// (get) Token: 0x0601478E RID: 83854 RVA: 0x005AEBB2 File Offset: 0x005ACDB2
	public override string TitleTextId
	{
		get
		{
			return this.ConfigData.Title;
		}
	}

	// Token: 0x17001AB7 RID: 6839
	// (get) Token: 0x0601478F RID: 83855 RVA: 0x005AEBBF File Offset: 0x005ACDBF
	public override string ContentTextId
	{
		get
		{
			return this.ConfigData.Content;
		}
	}

	// Token: 0x06014790 RID: 83856 RVA: 0x005AEBCC File Offset: 0x005ACDCC
	protected override EFavorContentType GetFavorContentType()
	{
		return EFavorContentType.PreciousItem;
	}

	// Token: 0x04009E37 RID: 40503
	public FavorGoods ConfigData;
}
