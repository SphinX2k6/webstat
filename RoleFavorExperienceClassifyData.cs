using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02002848 RID: 10312
[NullableContext(1)]
[Nullable(0)]
public class RoleFavorExperienceClassifyData : RoleFavorClassifyDataBase
{
	// Token: 0x06014753 RID: 83795 RVA: 0x005AE67A File Offset: 0x005AC87A
	public RoleFavorExperienceClassifyData(string titleTableId, int roleId, EFavorExperienceType experienceType) : base(titleTableId, roleId)
	{
		this.ExperienceType = experienceType;
	}

	// Token: 0x06014754 RID: 83796 RVA: 0x005AE692 File Offset: 0x005AC892
	protected override EFavorTabType GetFavorTabType()
	{
		return EFavorTabType.Experience;
	}

	// Token: 0x06014755 RID: 83797 RVA: 0x005AE695 File Offset: 0x005AC895
	protected override void InitContentDataList()
	{
		if (this.ExperienceType == EFavorExperienceType.File)
		{
			this.InitRoleInfoContentData();
			return;
		}
		this.InitRoleStoryContentData();
	}

	// Token: 0x06014756 RID: 83798 RVA: 0x005AE6AD File Offset: 0x005AC8AD
	private void InitRoleInfoContentData()
	{
		this.ContentDataList.Clear();
		this.ContentDataList.Add(this.CreateRoleInfoContentData(EFavorExperienceSubType.RoleBaseInfo));
		this.ContentDataList.Add(this.CreateRoleInfoContentData(EFavorExperienceSubType.RolePowerFile));
	}

	// Token: 0x06014757 RID: 83799 RVA: 0x005AE6E0 File Offset: 0x005AC8E0
	private void InitRoleStoryContentData()
	{
		this.ContentDataList.Clear();
		IReadOnlyList<FavorStory> favorStoryConfig = ConfigBase<RoleFavorConfig>.Instance.GetFavorStoryConfig(this.RoleId);
		if (favorStoryConfig == null)
		{
			return;
		}
		int count = favorStoryConfig.Count;
		for (int i = 0; i < count; i++)
		{
			FavorStory config = favorStoryConfig[i];
			this.ContentDataList.Add(this.CreateRoleStoryContentData(config));
		}
	}

	// Token: 0x06014758 RID: 83800 RVA: 0x005AE73C File Offset: 0x005AC93C
	private RoleFavorRoleInfoContentData CreateRoleInfoContentData(EFavorExperienceSubType favorRoleInfoType)
	{
		int roleId = this.RoleId;
		FavorRoleInfo? favorRoleInfoConfig = ConfigBase<RoleFavorConfig>.Instance.GetFavorRoleInfoConfig(roleId);
		if (favorRoleInfoConfig == null)
		{
			throw new Exception("GetFavorRoleInfoConfig failed");
		}
		return new RoleFavorRoleInfoContentData(roleId, favorRoleInfoType, favorRoleInfoConfig.Value);
	}

	// Token: 0x06014759 RID: 83801 RVA: 0x005AE77E File Offset: 0x005AC97E
	private RoleFavorStoryContentData CreateRoleStoryContentData(FavorStory config)
	{
		return new RoleFavorStoryContentData(this.RoleId, config);
	}

	// Token: 0x04009E29 RID: 40489
	private readonly EFavorExperienceType ExperienceType = EFavorExperienceType.File;
}
