using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Inventory;

// Token: 0x020012D4 RID: 4820
[NullableContext(1)]
[Nullable(0)]
public class AbyssRewardInfo
{
	// Token: 0x060081B4 RID: 33204 RVA: 0x002249EA File Offset: 0x00222BEA
	public int GetId()
	{
		return this.Id;
	}

	// Token: 0x060081B5 RID: 33205 RVA: 0x002249F4 File Offset: 0x00222BF4
	public AbyssReward GetConfig()
	{
		return ConfigBase<DangoAbyssConfig>.Instance.GetAbyssRewardById(this.Id).Value;
	}

	// Token: 0x060081B6 RID: 33206 RVA: 0x00224A19 File Offset: 0x00222C19
	public bool GetHasGetReward()
	{
		return this.HasGetReward;
	}

	// Token: 0x060081B7 RID: 33207 RVA: 0x00224A21 File Offset: 0x00222C21
	public bool GetCanGetReward()
	{
		return this.CurrentProgress == this.TargetProgress;
	}

	// Token: 0x060081B8 RID: 33208 RVA: 0x00224A31 File Offset: 0x00222C31
	public int GetCurrentProgress()
	{
		return this.CurrentProgress;
	}

	// Token: 0x060081B9 RID: 33209 RVA: 0x00224A39 File Offset: 0x00222C39
	public int GetTargetProgress()
	{
		return this.TargetProgress;
	}

	// Token: 0x060081BA RID: 33210 RVA: 0x00224A41 File Offset: 0x00222C41
	public bool GetIfUnlock()
	{
		return this.IfUnlock;
	}

	// Token: 0x060081BB RID: 33211 RVA: 0x00224A4C File Offset: 0x00222C4C
	public int GetRewardType()
	{
		int rewardType = this.GetConfig().RewardType;
		return ConfigBase<DangoAbyssConfig>.Instance.GetAbyssRewardTypeById(rewardType).Value.RewardType;
	}

	// Token: 0x060081BC RID: 33212 RVA: 0x00224A84 File Offset: 0x00222C84
	public int GetTabId()
	{
		int rewardType = this.GetConfig().RewardType;
		return ConfigBase<DangoAbyssConfig>.Instance.GetAbyssRewardTypeById(rewardType).Value.TabId;
	}

	// Token: 0x060081BD RID: 33213 RVA: 0x00224ABC File Offset: 0x00222CBC
	public int[] GetAllSameRewardTypeRewardId()
	{
		List<int> list = new List<int>();
		foreach (AbyssReward abyssReward in ConfigBase<DangoAbyssConfig>.Instance.GetAllAbyssReward())
		{
			if (abyssReward.RewardType == this.GetConfig().RewardType)
			{
				global::AbyssRewardInfo rewardInfoById = ModelBase<DangoAbyssModel>.Instance.GetRewardInfoById(abyssReward.Id);
				if (rewardInfoById != null && rewardInfoById.GetRewardTaskState() == EActivityTaskState.FinishedAndUnclaimed)
				{
					list.Add(abyssReward.Id);
				}
			}
		}
		return list.ToArray();
	}

	// Token: 0x060081BE RID: 33214 RVA: 0x00224B58 File Offset: 0x00222D58
	public EActivityTaskState GetRewardTaskState()
	{
		EActivityTaskState result = EActivityTaskState.Active;
		if (this.HasGetReward)
		{
			result = EActivityTaskState.FinishedAndClaimed;
		}
		else if (this.GetCanGetReward())
		{
			result = EActivityTaskState.FinishedAndUnclaimed;
		}
		return result;
	}

	// Token: 0x060081BF RID: 33215 RVA: 0x00224B80 File Offset: 0x00222D80
	public IActivityRewardData GetActivityRewardData()
	{
		EActivityTaskState rewardTaskState = this.GetRewardTaskState();
		int currentProgress = this.CurrentProgress;
		int targetProgress = this.TargetProgress;
		AbyssReward config = this.GetConfig();
		return new ActivityRewardData
		{
			Id = new int?(this.GetId()),
			NameText = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew(config.Title, null), new string[]
			{
				targetProgress.ToString()
			}),
			NameTextArgs = new string[]
			{
				currentProgress.ToString() ?? "",
				targetProgress.ToString() ?? ""
			},
			RewardState = TaskStateToRewardStateResolver.Value[rewardTaskState],
			ClickFunction = delegate
			{
				ControllerBase<DangoAbyssActivityController>.Instance.RequestGetAbyssRewardList(this.GetAllSameRewardTypeRewardId());
			},
			RewardList = this.GetRewardItems(this.GetDropId()),
			RewardButtonText = ConfigMultiTextLang.GetLocalTextNew(this.GetButtonText((int)TaskStateToRewardStateResolver.Value[rewardTaskState]), null)
		};
	}

	// Token: 0x060081C0 RID: 33216 RVA: 0x00224C78 File Offset: 0x00222E78
	private string GetButtonText(int state)
	{
		string result = "";
		switch (state)
		{
		case 0:
			result = "PrefabTextItem_1443074454_Text";
			break;
		case 1:
			result = "CollectActivity_state_CanRecive";
			break;
		case 2:
			result = "CollectActivity_state_recived";
			break;
		}
		return result;
	}

	// Token: 0x060081C1 RID: 33217 RVA: 0x00224CB8 File Offset: 0x00222EB8
	private int GetDropId()
	{
		return this.GetConfig().DropId;
	}

	// Token: 0x060081C2 RID: 33218 RVA: 0x00224CD4 File Offset: 0x00222ED4
	private TItem[] GetRewardItems(int dropId)
	{
		List<TItem> list = new List<TItem>();
		DropPackage? config = ConfigDropPackageById.GetConfig(dropId, true);
		int dropPreviewLength = config.Value.DropPreviewLength;
		for (int i = 0; i < dropPreviewLength; i++)
		{
			DicIntInt? dicIntInt = config.Value.DropPreview(i);
			int key = dicIntInt.Value.Key;
			int value = dicIntInt.Value.Value;
			list.Add(new TItem(new InventoryDefine.GetItemData(key, 0), value));
		}
		return list.ToArray();
	}

	// Token: 0x060081C3 RID: 33219 RVA: 0x00224D61 File Offset: 0x00222F61
	public void Pharse(Aki.Protocol.AbyssRewardInfo data)
	{
		this.Id = data.Id;
		this.HasGetReward = data.Rewarded;
		this.CurrentProgress = data.Current;
		this.TargetProgress = data.Target;
		this.IfUnlock = data.IsFinish;
	}

	// Token: 0x04003DCC RID: 15820
	private int Id;

	// Token: 0x04003DCD RID: 15821
	private bool HasGetReward;

	// Token: 0x04003DCE RID: 15822
	private int CurrentProgress;

	// Token: 0x04003DCF RID: 15823
	private int TargetProgress;

	// Token: 0x04003DD0 RID: 15824
	private bool IfUnlock;
}
