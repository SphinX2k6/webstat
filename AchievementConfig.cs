using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Reward;

// Token: 0x02000FCA RID: 4042
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class AchievementConfig : ConfigBase<AchievementConfig>
{
	// Token: 0x060067B4 RID: 26548 RVA: 0x001B0D73 File Offset: 0x001AEF73
	public Achievement? GetAchievementConfig(int achievementId)
	{
		return ConfigAchievementById.GetConfig(achievementId, true);
	}

	// Token: 0x060067B5 RID: 26549 RVA: 0x001B0D7C File Offset: 0x001AEF7C
	[NullableContext(2)]
	public IReadOnlyList<Achievement> GetAchievementGroupAchievementList(int groupId)
	{
		return ConfigAchievementByGroupId.GetConfigList(groupId, true);
	}

	// Token: 0x060067B6 RID: 26550 RVA: 0x001B0D85 File Offset: 0x001AEF85
	public AchievementStarLevel? GetAchievementStarLevelConfig(int level)
	{
		return ConfigAchievementStarLevelByLevel.GetConfig(level, true);
	}

	// Token: 0x060067B7 RID: 26551 RVA: 0x001B0D8E File Offset: 0x001AEF8E
	public AchievementGroup? GetAchievementGroupConfig(int achievementGroupId)
	{
		return ConfigAchievementGroupById.GetConfig(achievementGroupId, true);
	}

	// Token: 0x060067B8 RID: 26552 RVA: 0x001B0D97 File Offset: 0x001AEF97
	public AchievementCategory? GetAchievementCategory(int categoryId)
	{
		return ConfigAchievementCategoryById.GetConfig(categoryId, true);
	}

	// Token: 0x060067B9 RID: 26553 RVA: 0x001B0DA0 File Offset: 0x001AEFA0
	[NullableContext(2)]
	public IReadOnlyList<AchievementCategory> GetAllAchievementCategory()
	{
		return ConfigAchievementCategoryAll.GetConfigList(true);
	}

	// Token: 0x060067BA RID: 26554 RVA: 0x001B0DA8 File Offset: 0x001AEFA8
	[NullableContext(2)]
	public IReadOnlyList<AchievementGroup> GetAchievementCategoryGroups(int categoryId)
	{
		return ConfigAchievementGroupByCategory.GetConfigList(categoryId, true);
	}

	// Token: 0x060067BB RID: 26555 RVA: 0x001B0DB4 File Offset: 0x001AEFB4
	public string GetAchievementTitle(int achievementId)
	{
		return ConfigMultiTextLang.GetLocalTextNew(this.GetAchievementConfig(achievementId).Value.Name, null);
	}

	// Token: 0x060067BC RID: 26556 RVA: 0x001B0DE0 File Offset: 0x001AEFE0
	public string GetAchievementDesc(int achievementId)
	{
		return ConfigMultiTextLang.GetLocalTextNew(this.GetAchievementConfig(achievementId).Value.Desc, null);
	}

	// Token: 0x060067BD RID: 26557 RVA: 0x001B0E0C File Offset: 0x001AF00C
	public bool GetAchievementHiddenState(int achievementId)
	{
		return this.GetAchievementConfig(achievementId).Value.Hidden;
	}

	// Token: 0x060067BE RID: 26558 RVA: 0x001B0E30 File Offset: 0x001AF030
	public int GetAchievementNextLink(int achievementId)
	{
		Achievement? achievementConfig = this.GetAchievementConfig(achievementId);
		if (achievementConfig == null)
		{
			return 0;
		}
		return achievementConfig.Value.NextLink;
	}

	// Token: 0x060067BF RID: 26559 RVA: 0x001B0E60 File Offset: 0x001AF060
	public int GetThirdPartyTrophyId(int achievementId)
	{
		Achievement? achievementConfig = this.GetAchievementConfig(achievementId);
		if (achievementConfig == null)
		{
			return 0;
		}
		return achievementConfig.Value.ThirdPartyTrophyId;
	}

	// Token: 0x060067C0 RID: 26560 RVA: 0x001B0E90 File Offset: 0x001AF090
	public string GetExternalTrophyId(int achievementId)
	{
		Achievement? achievementConfig = this.GetAchievementConfig(achievementId);
		if (achievementConfig == null)
		{
			return string.Empty;
		}
		return achievementConfig.Value.ExternalTrophyId;
	}

	// Token: 0x060067C1 RID: 26561 RVA: 0x001B0EC4 File Offset: 0x001AF0C4
	public string GetXSXExternalTrophyId(int achievementId)
	{
		Achievement? achievementConfig = this.GetAchievementConfig(achievementId);
		if (achievementConfig == null)
		{
			return string.Empty;
		}
		return achievementConfig.Value.XSXExternalTrophyId;
	}

	// Token: 0x060067C2 RID: 26562 RVA: 0x001B0EF8 File Offset: 0x001AF0F8
	public int GetAchievementLevel(int achievementId)
	{
		Achievement? achievementConfig = this.GetAchievementConfig(achievementId);
		if (achievementConfig == null)
		{
			return 0;
		}
		return achievementConfig.Value.Level;
	}

	// Token: 0x060067C3 RID: 26563 RVA: 0x001B0F28 File Offset: 0x001AF128
	public int GetAchievementGroup(int achievementId)
	{
		Achievement? achievementConfig = this.GetAchievementConfig(achievementId);
		if (achievementConfig == null)
		{
			return 0;
		}
		return achievementConfig.Value.GroupId;
	}

	// Token: 0x060067C4 RID: 26564 RVA: 0x001B0F58 File Offset: 0x001AF158
	public string GetAchievementIcon(int achievementId)
	{
		Achievement? achievementConfig = this.GetAchievementConfig(achievementId);
		if (achievementConfig == null)
		{
			return string.Empty;
		}
		return achievementConfig.Value.IconPath;
	}

	// Token: 0x060067C5 RID: 26565 RVA: 0x001B0F8C File Offset: 0x001AF18C
	public DropPackage? GetAchievementReward(int achievementId)
	{
		int num = this.GetAchievementConfig(achievementId).Value.OverrideDropId;
		if (num > 0)
		{
			return ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackage(num);
		}
		num = this.GetAchievementStarLevelConfig(this.GetAchievementLevel(achievementId)).Value.DropId;
		return ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackage(num);
	}

	// Token: 0x060067C6 RID: 26566 RVA: 0x001B0FEC File Offset: 0x001AF1EC
	public string GetAchievementGroupTitleId(int groupId)
	{
		AchievementGroup? achievementGroupConfig = this.GetAchievementGroupConfig(groupId);
		return ((achievementGroupConfig != null) ? achievementGroupConfig.GetValueOrDefault().Name : null) ?? "";
	}

	// Token: 0x060067C7 RID: 26567 RVA: 0x001B1025 File Offset: 0x001AF225
	public string GetAchievementGroupTitle(int groupId)
	{
		return ConfigMultiTextLang.GetLocalTextNew(this.GetAchievementGroupTitleId(groupId), null);
	}

	// Token: 0x060067C8 RID: 26568 RVA: 0x001B1034 File Offset: 0x001AF234
	public int GetAchievementGroupSort(int groupId)
	{
		return this.GetAchievementGroupConfig(groupId).Value.Sort;
	}

	// Token: 0x060067C9 RID: 26569 RVA: 0x001B1058 File Offset: 0x001AF258
	public string GetAchievementGroupIcon(int groupId)
	{
		return this.GetAchievementGroupConfig(groupId).Value.Icon;
	}

	// Token: 0x060067CA RID: 26570 RVA: 0x001B107C File Offset: 0x001AF27C
	public string GetAchievementGroupSmallIcon(int groupId)
	{
		return this.GetAchievementGroupConfig(groupId).Value.SmallIcon;
	}

	// Token: 0x060067CB RID: 26571 RVA: 0x001B10A0 File Offset: 0x001AF2A0
	public string GetAchievementGroupBackgroundIcon(int groupId)
	{
		return this.GetAchievementGroupConfig(groupId).Value.BackgroundIcon;
	}

	// Token: 0x060067CC RID: 26572 RVA: 0x001B10C4 File Offset: 0x001AF2C4
	public bool GetAchievementGroupEnable(int groupId)
	{
		return this.GetAchievementGroupConfig(groupId).Value.Enable;
	}

	// Token: 0x060067CD RID: 26573 RVA: 0x001B10E8 File Offset: 0x001AF2E8
	public DropPackage? GetAchievementGroupReward(int groupId)
	{
		AchievementGroup? achievementGroupConfig = this.GetAchievementGroupConfig(groupId);
		if (achievementGroupConfig.Value.DropId == 0)
		{
			return null;
		}
		return ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackage(achievementGroupConfig.Value.DropId);
	}

	// Token: 0x060067CE RID: 26574 RVA: 0x001B1134 File Offset: 0x001AF334
	public int GetAchievementGroupCategory(int groupId)
	{
		return this.GetAchievementGroupConfig(groupId).Value.Category;
	}

	// Token: 0x060067CF RID: 26575 RVA: 0x001B1158 File Offset: 0x001AF358
	public string GetCategoryOriginalTitle(int categoryId)
	{
		AchievementCategory? achievementCategory = this.GetAchievementCategory(categoryId);
		return ((achievementCategory != null) ? achievementCategory.GetValueOrDefault().Name : null) ?? "";
	}

	// Token: 0x060067D0 RID: 26576 RVA: 0x001B1191 File Offset: 0x001AF391
	public string GetCategoryTitle(int categoryId)
	{
		return ConfigMultiTextLang.GetLocalTextNew(this.GetCategoryOriginalTitle(categoryId), null);
	}

	// Token: 0x060067D1 RID: 26577 RVA: 0x001B11A0 File Offset: 0x001AF3A0
	public string GetCategoryTexture(int categoryId)
	{
		AchievementCategory? achievementCategory = this.GetAchievementCategory(categoryId);
		return ((achievementCategory != null) ? achievementCategory.GetValueOrDefault().TexturePath : null) ?? "";
	}

	// Token: 0x060067D2 RID: 26578 RVA: 0x001B11DC File Offset: 0x001AF3DC
	public string GetCategorySprite(int categoryId)
	{
		AchievementCategory? achievementCategory = this.GetAchievementCategory(categoryId);
		return ((achievementCategory != null) ? achievementCategory.GetValueOrDefault().SpritePath : null) ?? "";
	}

	// Token: 0x060067D3 RID: 26579 RVA: 0x001B1218 File Offset: 0x001AF418
	public int GetCategoryFunctionType(int groupId)
	{
		return this.GetAchievementCategory(groupId).Value.FunctionType;
	}
}
