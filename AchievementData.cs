using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Core.Common;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Launcher.Platform.PlatformSdk;

// Token: 0x02000FCE RID: 4046
[NullableContext(1)]
[Nullable(0)]
public class AchievementData
{
	// Token: 0x17000829 RID: 2089
	// (get) Token: 0x060067ED RID: 26605 RVA: 0x001B177B File Offset: 0x001AF97B
	// (set) Token: 0x060067EE RID: 26606 RVA: 0x001B1783 File Offset: 0x001AF983
	public long UUID { get; set; }

	// Token: 0x060067EF RID: 26607 RVA: 0x001B178C File Offset: 0x001AF98C
	public void OnSetUUID(long uuid)
	{
		this.Id = (int)this.UUID;
		this.NextAchievementId = ConfigBase<AchievementConfig>.Instance.GetAchievementNextLink(this.Id);
	}

	// Token: 0x060067F0 RID: 26608 RVA: 0x001B17B4 File Offset: 0x001AF9B4
	public unsafe void PrintUnsafeAddress()
	{
		fixed (int?* ptr = &this.FinishTime)
		{
		}
	}

	// Token: 0x060067F1 RID: 26609 RVA: 0x001B17D0 File Offset: 0x001AF9D0
	public AchievementData(int id)
	{
		this.Id = id;
		this.NextAchievementId = ConfigBase<AchievementConfig>.Instance.GetAchievementNextLink(this.Id);
	}

	// Token: 0x060067F2 RID: 26610 RVA: 0x001B1829 File Offset: 0x001AFA29
	public void SetLastLink(int link)
	{
		this.LastAchievementId = link;
	}

	// Token: 0x060067F3 RID: 26611 RVA: 0x001B1834 File Offset: 0x001AFA34
	public void Phrase(AchievementEntry message)
	{
		this.FinishTime = new int?((int)message.FinishTime);
		this.HasGetRewardState = new bool?(message.IsReceive);
		this.CurrentProgress = new int?(message.Progress.CurProgress);
		this.MaxProgress = new int?(message.Progress.TotalProgress);
		this.InitThirdPartyTrophyId();
		this.UpdateThirdPartyTrophyData();
	}

	// Token: 0x060067F4 RID: 26612 RVA: 0x001B189C File Offset: 0x001AFA9C
	private void UpdateThirdPartyTrophyData()
	{
		string thirdPartyTrophyId = this.GetThirdPartyTrophyId();
		if (this.GetFinishState() != EAchievementStateEnum.UnFinished && thirdPartyTrophyId != "-1")
		{
			ControllerBase<KuroSdkController>.Instance.UnlockSdkTrophy(thirdPartyTrophyId);
		}
	}

	// Token: 0x060067F5 RID: 26613 RVA: 0x001B18D0 File Offset: 0x001AFAD0
	public int GetId()
	{
		return this.Id;
	}

	// Token: 0x060067F6 RID: 26614 RVA: 0x001B18D8 File Offset: 0x001AFAD8
	private void InitThirdPartyTrophyId()
	{
		if (this.ThirdPartyTrophyId == "-1")
		{
			if (Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn)
			{
				this.ThirdPartyTrophyId = ConfigBase<AchievementConfig>.Instance.GetThirdPartyTrophyId(this.Id).ToString();
				return;
			}
			if (Singleton<Info>.Instance.IsXboxPlatform())
			{
				this.ThirdPartyTrophyId = ConfigBase<AchievementConfig>.Instance.GetXSXExternalTrophyId(this.Id);
				return;
			}
			this.ThirdPartyTrophyId = ConfigBase<AchievementConfig>.Instance.GetExternalTrophyId(this.Id);
		}
	}

	// Token: 0x060067F7 RID: 26615 RVA: 0x001B195B File Offset: 0x001AFB5B
	public string GetThirdPartyTrophyId()
	{
		return this.ThirdPartyTrophyId;
	}

	// Token: 0x060067F8 RID: 26616 RVA: 0x001B1963 File Offset: 0x001AFB63
	public bool RedPoint()
	{
		return EAchievementStateEnum.CanGetReward == this.GetFinishState() && this.GetShowState();
	}

	// Token: 0x060067F9 RID: 26617 RVA: 0x001B197B File Offset: 0x001AFB7B
	public string GetIconPath()
	{
		return ConfigBase<AchievementConfig>.Instance.GetAchievementIcon(this.Id);
	}

	// Token: 0x060067FA RID: 26618 RVA: 0x001B198D File Offset: 0x001AFB8D
	public bool IfSingleAchievement()
	{
		return this.NextAchievementId == -1;
	}

	// Token: 0x060067FB RID: 26619 RVA: 0x001B199C File Offset: 0x001AFB9C
	public bool GetShowState()
	{
		return this.MaxProgress != null && (!this.GetHiddenState() || this.GetFinishState() != EAchievementStateEnum.UnFinished) && (this.LastAchievementId == -1 || ModelBase<AchievementModel>.Instance.GetAchievementData(this.LastAchievementId).GetFinishState() == EAchievementStateEnum.HaveGetReward) && (this.GetFinishState() != EAchievementStateEnum.HaveGetReward || this.NextAchievementId <= 0);
	}

	// Token: 0x060067FC RID: 26620 RVA: 0x001B1A02 File Offset: 0x001AFC02
	public bool GetHiddenState()
	{
		return ConfigBase<AchievementConfig>.Instance.GetAchievementHiddenState(this.Id);
	}

	// Token: 0x060067FD RID: 26621 RVA: 0x001B1A14 File Offset: 0x001AFC14
	public string GetReplaceDesc(string searchText)
	{
		string desc = this.GetDesc();
		StringBuilder stringBuilder = new StringBuilder();
		string stringConfig = ConfigCommonParamById.GetStringConfig("TutorialSearchColor");
		stringBuilder.Append("<color=");
		StringBuilder stringBuilder2 = stringBuilder;
		StringBuilder stringBuilder3 = stringBuilder2;
		StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(1, 1, stringBuilder2);
		appendInterpolatedStringHandler.AppendFormatted((stringConfig != null) ? stringConfig.ToLower() : null);
		appendInterpolatedStringHandler.AppendLiteral(">");
		stringBuilder3.Append(ref appendInterpolatedStringHandler);
		stringBuilder.Append(searchText);
		stringBuilder.Append("</color>");
		string oldValue = searchText ?? "";
		return desc.Replace(oldValue, stringBuilder.ToString());
	}

	// Token: 0x060067FE RID: 26622 RVA: 0x001B1AA4 File Offset: 0x001AFCA4
	public string GetReplaceTitle(string searchText)
	{
		string title = this.GetTitle();
		StringBuilder stringBuilder = new StringBuilder();
		string stringConfig = ConfigCommonParamById.GetStringConfig("TutorialSearchColor");
		stringBuilder.Append("<color=");
		StringBuilder stringBuilder2 = stringBuilder;
		StringBuilder stringBuilder3 = stringBuilder2;
		StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(1, 1, stringBuilder2);
		appendInterpolatedStringHandler.AppendFormatted((stringConfig != null) ? stringConfig.ToLower() : null);
		appendInterpolatedStringHandler.AppendLiteral(">");
		stringBuilder3.Append(ref appendInterpolatedStringHandler);
		stringBuilder.Append(searchText);
		stringBuilder.Append("</color>");
		string oldValue = searchText ?? "";
		return title.Replace(oldValue, stringBuilder.ToString());
	}

	// Token: 0x060067FF RID: 26623 RVA: 0x001B1B33 File Offset: 0x001AFD33
	public string GetDesc()
	{
		return ConfigBase<AchievementConfig>.Instance.GetAchievementDesc(this.Id);
	}

	// Token: 0x06006800 RID: 26624 RVA: 0x001B1B45 File Offset: 0x001AFD45
	public string GetTitle()
	{
		return ConfigBase<AchievementConfig>.Instance.GetAchievementTitle(this.Id);
	}

	// Token: 0x06006801 RID: 26625 RVA: 0x001B1B58 File Offset: 0x001AFD58
	public int GetMaxStar()
	{
		if (this.IfSingleAchievement())
		{
			return ConfigBase<AchievementConfig>.Instance.GetAchievementLevel(this.Id);
		}
		AchievementData achievementData = ModelBase<AchievementModel>.Instance.GetAchievementData(this.Id);
		while (achievementData != null && achievementData.NextAchievementId > 0)
		{
			achievementData = ModelBase<AchievementModel>.Instance.GetAchievementData(achievementData.NextAchievementId);
		}
		return ConfigBase<AchievementConfig>.Instance.GetAchievementLevel(achievementData.GetId());
	}

	// Token: 0x06006802 RID: 26626 RVA: 0x001B1BC0 File Offset: 0x001AFDC0
	public int GetFinishedStar()
	{
		if (!this.GetShowState())
		{
			return 0;
		}
		int achievementLevel = ConfigBase<AchievementConfig>.Instance.GetAchievementLevel(this.Id);
		if (this.IfSingleAchievement())
		{
			if (this.GetFinishState() == EAchievementStateEnum.HaveGetReward || this.GetFinishState() == EAchievementStateEnum.CanGetReward)
			{
				return achievementLevel;
			}
			return 0;
		}
		else
		{
			int allLastAchievementStar = this.GetAllLastAchievementStar();
			if (this.GetFinishState() == EAchievementStateEnum.HaveGetReward || this.GetFinishState() == EAchievementStateEnum.CanGetReward)
			{
				return achievementLevel + allLastAchievementStar;
			}
			if (this.GetFinishState() == EAchievementStateEnum.UnFinished)
			{
				return allLastAchievementStar;
			}
			return ((achievementLevel - 1 >= 0) ? (achievementLevel - 1) : 0) + allLastAchievementStar;
		}
	}

	// Token: 0x06006803 RID: 26627 RVA: 0x001B1C3C File Offset: 0x001AFE3C
	private int GetAllLastAchievementStar()
	{
		int num = 0;
		AchievementData achievementData;
		for (int lastAchievementId = this.LastAchievementId; lastAchievementId != -1; lastAchievementId = achievementData.LastAchievementId)
		{
			achievementData = ModelBase<AchievementModel>.Instance.GetAchievementData(lastAchievementId);
			num += ConfigBase<AchievementConfig>.Instance.GetAchievementLevel(lastAchievementId);
		}
		return num;
	}

	// Token: 0x06006804 RID: 26628 RVA: 0x001B1C78 File Offset: 0x001AFE78
	public int GetAchievementShowStar()
	{
		if (!this.GetShowState())
		{
			return 0;
		}
		int achievementLevel = ConfigBase<AchievementConfig>.Instance.GetAchievementLevel(this.Id);
		if (this.IfSingleAchievement())
		{
			return achievementLevel;
		}
		if (this.GetFinishState() == EAchievementStateEnum.HaveGetReward || this.GetFinishState() == EAchievementStateEnum.CanGetReward)
		{
			return achievementLevel;
		}
		if (achievementLevel - 1 < 0)
		{
			return 0;
		}
		return achievementLevel - 1;
	}

	// Token: 0x06006805 RID: 26629 RVA: 0x001B1CC9 File Offset: 0x001AFEC9
	public int GetAchievementConfigStar()
	{
		return ConfigBase<AchievementConfig>.Instance.GetAchievementLevel(this.GetId());
	}

	// Token: 0x06006806 RID: 26630 RVA: 0x001B1CDB File Offset: 0x001AFEDB
	public int? GetCurrentProgress()
	{
		return this.CurrentProgress;
	}

	// Token: 0x06006807 RID: 26631 RVA: 0x001B1CE3 File Offset: 0x001AFEE3
	public int? GetMaxProgress()
	{
		return this.MaxProgress;
	}

	// Token: 0x06006808 RID: 26632 RVA: 0x001B1CEC File Offset: 0x001AFEEC
	public List<TItem> GetRewards()
	{
		if (this.Rewards.Count == 0)
		{
			this.Rewards = new List<TItem>();
			DropPackage? achievementReward = ConfigBase<AchievementConfig>.Instance.GetAchievementReward(this.Id);
			if (achievementReward != null)
			{
				int dropPreviewLength = achievementReward.Value.DropPreviewLength;
				for (int i = 0; i < dropPreviewLength; i++)
				{
					DicIntInt? dicIntInt = achievementReward.Value.DropPreview(i);
					int key = dicIntInt.Value.Key;
					int value = dicIntInt.Value.Value;
					TItem item = new TItem(new InventoryDefine.GetItemData(key, 0), value);
					this.Rewards.Add(item);
				}
			}
		}
		return this.Rewards;
	}

	// Token: 0x06006809 RID: 26633 RVA: 0x001B1DA4 File Offset: 0x001AFFA4
	public bool GetAllFinishState()
	{
		return (this.NextAchievementId == 0 || this.NextAchievementId == -1) && this.GetFinishState() == EAchievementStateEnum.CanGetReward;
	}

	// Token: 0x0600680A RID: 26634 RVA: 0x001B1DC2 File Offset: 0x001AFFC2
	public int GetNextLink()
	{
		return this.NextAchievementId;
	}

	// Token: 0x0600680B RID: 26635 RVA: 0x001B1DCA File Offset: 0x001AFFCA
	public bool GetIfLastAchievement()
	{
		return this.IfSingleAchievement() || this.NextAchievementId == 0;
	}

	// Token: 0x0600680C RID: 26636 RVA: 0x001B1DE1 File Offset: 0x001AFFE1
	public bool CanShowStarState()
	{
		return this.GetFinishState() == EAchievementStateEnum.HaveGetReward || this.GetFinishState() == EAchievementStateEnum.CanGetReward;
	}

	// Token: 0x0600680D RID: 26637 RVA: 0x001B1DF8 File Offset: 0x001AFFF8
	public EAchievementStateEnum GetFinishState()
	{
		if (this.HasGetRewardState.GetValueOrDefault())
		{
			return EAchievementStateEnum.HaveGetReward;
		}
		int? finishTime = this.FinishTime;
		int num = 0;
		if (finishTime.GetValueOrDefault() > num & finishTime != null)
		{
			return EAchievementStateEnum.CanGetReward;
		}
		return EAchievementStateEnum.UnFinished;
	}

	// Token: 0x0600680E RID: 26638 RVA: 0x001B1E34 File Offset: 0x001B0034
	public int GetFinishSort()
	{
		if (this.GetFinishState() == EAchievementStateEnum.HaveGetReward)
		{
			return 0;
		}
		if (this.GetFinishState() == EAchievementStateEnum.CanGetReward)
		{
			return 2;
		}
		return 1;
	}

	// Token: 0x0600680F RID: 26639 RVA: 0x001B1E50 File Offset: 0x001B0050
	public long? GetFinishTime()
	{
		int? finishTime = this.FinishTime;
		if (finishTime == null)
		{
			return null;
		}
		return new long?((long)finishTime.GetValueOrDefault());
	}

	// Token: 0x06006810 RID: 26640 RVA: 0x001B1E84 File Offset: 0x001B0084
	public int GetGroupId()
	{
		return ConfigBase<AchievementConfig>.Instance.GetAchievementGroup(this.Id);
	}

	// Token: 0x0400318C RID: 12684
	public int? FinishTime;

	// Token: 0x0400318D RID: 12685
	private int NextAchievementId;

	// Token: 0x0400318E RID: 12686
	private int LastAchievementId = -1;

	// Token: 0x0400318F RID: 12687
	private List<TItem> Rewards = new List<TItem>();

	// Token: 0x04003190 RID: 12688
	private bool? HasGetRewardState = new bool?(false);

	// Token: 0x04003191 RID: 12689
	private int? CurrentProgress;

	// Token: 0x04003192 RID: 12690
	private int? MaxProgress;

	// Token: 0x04003193 RID: 12691
	private string ThirdPartyTrophyId = "-1";

	// Token: 0x04003194 RID: 12692
	private int Id;
}
