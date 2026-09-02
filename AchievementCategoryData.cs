using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02000FCF RID: 4047
[NullableContext(1)]
[Nullable(0)]
public class AchievementCategoryData
{
	// Token: 0x1700082A RID: 2090
	// (get) Token: 0x06006811 RID: 26641 RVA: 0x001B1E96 File Offset: 0x001B0096
	// (set) Token: 0x06006812 RID: 26642 RVA: 0x001B1E9E File Offset: 0x001B009E
	public long UUID { get; set; }

	// Token: 0x06006813 RID: 26643 RVA: 0x001B1EA7 File Offset: 0x001B00A7
	public void OnSetUUID(long uuid)
	{
		this.Id = (int)this.UUID;
	}

	// Token: 0x06006814 RID: 26644 RVA: 0x001B1EB6 File Offset: 0x001B00B6
	public AchievementCategoryData(int id)
	{
		this.Id = id;
	}

	// Token: 0x06006815 RID: 26645 RVA: 0x001B1EC5 File Offset: 0x001B00C5
	public int GetId()
	{
		return this.Id;
	}

	// Token: 0x06006816 RID: 26646 RVA: 0x001B1ECD File Offset: 0x001B00CD
	public EAchievementFunctionType GetFunctionType()
	{
		return (EAchievementFunctionType)ConfigBase<AchievementConfig>.Instance.GetCategoryFunctionType(this.Id);
	}

	// Token: 0x06006817 RID: 26647 RVA: 0x001B1EDF File Offset: 0x001B00DF
	public string GetOrignalTitle()
	{
		return ConfigBase<AchievementConfig>.Instance.GetCategoryOriginalTitle(this.Id);
	}

	// Token: 0x06006818 RID: 26648 RVA: 0x001B1EF1 File Offset: 0x001B00F1
	public string GetTitle()
	{
		return ConfigBase<AchievementConfig>.Instance.GetCategoryTitle(this.Id);
	}

	// Token: 0x06006819 RID: 26649 RVA: 0x001B1F03 File Offset: 0x001B0103
	public string GetTexture()
	{
		return ConfigBase<AchievementConfig>.Instance.GetCategoryTexture(this.Id);
	}

	// Token: 0x0600681A RID: 26650 RVA: 0x001B1F15 File Offset: 0x001B0115
	public string GetSprite()
	{
		return ConfigBase<AchievementConfig>.Instance.GetCategorySprite(this.Id);
	}

	// Token: 0x0600681B RID: 26651 RVA: 0x001B1F28 File Offset: 0x001B0128
	public string GetAchievementCategoryProgress()
	{
		List<AchievementGroupData> achievementCategoryGroups = ModelBase<AchievementModel>.Instance.GetAchievementCategoryGroups(this.Id, true);
		int num = 0;
		int num2 = 0;
		foreach (AchievementGroupData achievementGroupData in achievementCategoryGroups)
		{
			foreach (AchievementData achievementData in ModelBase<AchievementModel>.Instance.GetGroupAchievements(achievementGroupData.GetId(), false))
			{
				EAchievementStateEnum finishState = achievementData.GetFinishState();
				if ((!achievementData.GetHiddenState() || finishState != EAchievementStateEnum.UnFinished) && achievementData.GetMaxProgress() != null)
				{
					num++;
					if (finishState != EAchievementStateEnum.UnFinished)
					{
						num2++;
					}
				}
			}
		}
		int value = (int)Math.Round((double)num2 * 100.0 / (double)num);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
		defaultInterpolatedStringHandler.AppendFormatted<int>(value);
		defaultInterpolatedStringHandler.AppendLiteral("%");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x04003196 RID: 12694
	private int Id;
}
