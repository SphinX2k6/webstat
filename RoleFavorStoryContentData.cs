using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x0200284F RID: 10319
[NullableContext(1)]
[Nullable(0)]
public class RoleFavorStoryContentData : RoleFavorContentDataBase
{
	// Token: 0x0601477F RID: 83839 RVA: 0x005AEAE5 File Offset: 0x005ACCE5
	public RoleFavorStoryContentData(int roleId, FavorStory configData) : base(roleId)
	{
		this.ConfigData = configData;
	}

	// Token: 0x17001AAC RID: 6828
	// (get) Token: 0x06014780 RID: 83840 RVA: 0x005AEAFC File Offset: 0x005ACCFC
	public override int ConfigId
	{
		get
		{
			return this.ConfigData.Id;
		}
	}

	// Token: 0x17001AAD RID: 6829
	// (get) Token: 0x06014781 RID: 83841 RVA: 0x005AEB09 File Offset: 0x005ACD09
	public override int ConfigConGroupId
	{
		get
		{
			return this.ConfigData.CondGroupId;
		}
	}

	// Token: 0x17001AAE RID: 6830
	// (get) Token: 0x06014782 RID: 83842 RVA: 0x005AEB16 File Offset: 0x005ACD16
	public override string TitleTextId
	{
		get
		{
			return this.ConfigData.Title;
		}
	}

	// Token: 0x17001AAF RID: 6831
	// (get) Token: 0x06014783 RID: 83843 RVA: 0x005AEB23 File Offset: 0x005ACD23
	public override string ContentTextId
	{
		get
		{
			return this.ConfigData.Content;
		}
	}

	// Token: 0x06014784 RID: 83844 RVA: 0x005AEB30 File Offset: 0x005ACD30
	protected override EFavorContentType GetFavorContentType()
	{
		return EFavorContentType.ExperienceStory;
	}

	// Token: 0x04009E33 RID: 40499
	public FavorStory ConfigData;

	// Token: 0x04009E34 RID: 40500
	public EFavorExperienceSubType FavorExperienceSubType = EFavorExperienceSubType.RoleStory;
}
