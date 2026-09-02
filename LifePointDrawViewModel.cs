using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Reward;

// Token: 0x02001350 RID: 4944
[NullableContext(1)]
[Nullable(0)]
public class LifePointDrawViewModel
{
	// Token: 0x06008733 RID: 34611 RVA: 0x00239BD0 File Offset: 0x00237DD0
	public void RegisterView(LifePointDrawDetailView view)
	{
		this.Panel = view;
		this.SelectChallengeId = ConfigBase<LifePointDrawConfig>.Instance.GetLifePointGroupByGroupId(this.GroupId).Value.ChallengeList(0);
	}

	// Token: 0x06008734 RID: 34612 RVA: 0x00239C0B File Offset: 0x00237E0B
	public void OnSelectChallenge(int challengeId)
	{
		this.SelectChallengeId = challengeId;
		this.RefreshLayout();
		this.RefreshDifficultTexture();
		this.RefreshRewardLayout();
		this.RefreshTitleText();
		this.RefreshDescText();
		this.SaveCurrentChallengeRedDotState();
		this.PlaySwitchSequence();
	}

	// Token: 0x06008735 RID: 34613 RVA: 0x00239C40 File Offset: 0x00237E40
	public void RefreshLayout()
	{
		LifePointGroup value = ConfigBase<LifePointDrawConfig>.Instance.GetLifePointGroupByGroupId(this.GroupId).Value;
		LifePointDrawDetailView panel = this.Panel;
		if (panel == null)
		{
			return;
		}
		panel.RefreshLayout(value.GetChallengeListArray().ToList<int>());
	}

	// Token: 0x06008736 RID: 34614 RVA: 0x00239C82 File Offset: 0x00237E82
	public void OnShowView()
	{
		this.RefreshLayout();
		this.RefreshNumSprite();
		this.RefreshDifficultTexture();
		this.RefreshRewardLayout();
		this.RefreshTitleText();
		this.RefreshDescText();
		this.SaveCurrentChallengeRedDotState();
	}

	// Token: 0x06008737 RID: 34615 RVA: 0x00239CAE File Offset: 0x00237EAE
	public bool CheckChallengeIfSelect(int challengeId)
	{
		return this.SelectChallengeId == challengeId;
	}

	// Token: 0x06008738 RID: 34616 RVA: 0x00239CB9 File Offset: 0x00237EB9
	public bool GetChallengeLockState(int challengeId)
	{
		return !ModelBase<LifePointDrawModel>.Instance.GetChallengeRequireFinishState(this.LifePointDrawActivityData.Id, challengeId);
	}

	// Token: 0x06008739 RID: 34617 RVA: 0x00239CD4 File Offset: 0x00237ED4
	private void RefreshNumSprite()
	{
		string levelNumResource = ConfigBase<LifePointDrawConfig>.Instance.GetLifePointGroupByGroupId(this.GroupId).Value.LevelNumResource;
		LifePointDrawDetailView panel = this.Panel;
		if (panel == null)
		{
			return;
		}
		panel.RefreshLevelNumSprite(levelNumResource);
	}

	// Token: 0x0600873A RID: 34618 RVA: 0x00239D14 File Offset: 0x00237F14
	private void RefreshTitleText()
	{
		string name = ConfigBase<LifePointDrawConfig>.Instance.GetLifePointChallengeById(this.SelectChallengeId).Value.Name;
		LifePointDrawDetailView panel = this.Panel;
		if (panel == null)
		{
			return;
		}
		panel.ShowRightUpTitle(name);
	}

	// Token: 0x0600873B RID: 34619 RVA: 0x00239D54 File Offset: 0x00237F54
	private void RefreshDescText()
	{
		string desc = ConfigBase<LifePointDrawConfig>.Instance.GetLifePointChallengeById(this.SelectChallengeId).Value.Desc;
		LifePointDrawDetailView panel = this.Panel;
		if (panel == null)
		{
			return;
		}
		panel.ShowDescText(desc);
	}

	// Token: 0x0600873C RID: 34620 RVA: 0x00239D93 File Offset: 0x00237F93
	private void PlaySwitchSequence()
	{
		LifePointDrawDetailView panel = this.Panel;
		if (panel == null)
		{
			return;
		}
		panel.PlaySwitchSequence();
	}

	// Token: 0x0600873D RID: 34621 RVA: 0x00239DA8 File Offset: 0x00237FA8
	private void RefreshDifficultTexture()
	{
		string difficultTexture = ConfigBase<LifePointDrawConfig>.Instance.GetLifePointChallengeById(this.SelectChallengeId).Value.DifficultTexture;
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(difficultTexture);
		LifePointDrawDetailView panel = this.Panel;
		if (panel == null)
		{
			return;
		}
		panel.RefreshDifficultTexture(resourcePath);
	}

	// Token: 0x0600873E RID: 34622 RVA: 0x00239DF4 File Offset: 0x00237FF4
	public string GetChallengeTitleId(int challengeId)
	{
		return ConfigBase<LifePointDrawConfig>.Instance.GetLifePointChallengeById(challengeId).Value.SubTitle;
	}

	// Token: 0x0600873F RID: 34623 RVA: 0x00239E1C File Offset: 0x0023801C
	public void RefreshRewardLayout()
	{
		int rewardId = ConfigBase<LifePointDrawConfig>.Instance.GetLifePointChallengeById(this.SelectChallengeId).Value.RewardId;
		List<TItem> dropPackagePreviewItemList = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(rewardId);
		LifePointDrawDetailView panel = this.Panel;
		if (panel == null)
		{
			return;
		}
		panel.RefreshRewardLayout(dropPackagePreviewItemList);
	}

	// Token: 0x06008740 RID: 34624 RVA: 0x00239E68 File Offset: 0x00238068
	public bool GetCurrentChallengeFinishRewardState()
	{
		LifePointDrawActivityData lifePointDrawActivityData = ModelBase<ActivityModel>.Instance.GetActivityById(this.LifePointDrawActivityData.Id) as LifePointDrawActivityData;
		return lifePointDrawActivityData != null && lifePointDrawActivityData.GetChallengeIfGetReward(this.SelectChallengeId);
	}

	// Token: 0x06008741 RID: 34625 RVA: 0x00239EA4 File Offset: 0x002380A4
	public bool GetChallengeFinishState(int challengeId)
	{
		LifePointDrawActivityData lifePointDrawActivityData = ModelBase<ActivityModel>.Instance.GetActivityById(this.LifePointDrawActivityData.Id) as LifePointDrawActivityData;
		return lifePointDrawActivityData != null && lifePointDrawActivityData.GetChallengeIfGetReward(challengeId);
	}

	// Token: 0x06008742 RID: 34626 RVA: 0x00239ED8 File Offset: 0x002380D8
	public int GetCurrentChallengeId()
	{
		return this.SelectChallengeId;
	}

	// Token: 0x06008743 RID: 34627 RVA: 0x00239EE0 File Offset: 0x002380E0
	public void SaveCurrentChallengeRedDotState()
	{
		int currentChallengeId = this.GetCurrentChallengeId();
		ModelBase<LifePointDrawModel>.Instance.SaveChallengeRedDotState(this.LifePointDrawActivityData.Id, currentChallengeId);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshLifePointDrawGroupRedDot, this.GroupId);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshLifePointDrawChallengeRedDot, currentChallengeId);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.LifePointDrawActivityData.Id);
	}

	// Token: 0x04003FBB RID: 16315
	[Nullable(2)]
	public LifePointDrawActivityData LifePointDrawActivityData;

	// Token: 0x04003FBC RID: 16316
	public int GroupId;

	// Token: 0x04003FBD RID: 16317
	private int SelectChallengeId;

	// Token: 0x04003FBE RID: 16318
	[Nullable(2)]
	private LifePointDrawDetailView Panel;
}
