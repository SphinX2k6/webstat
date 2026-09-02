using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Reward;

namespace CSharpScript.Game.Module.Activity.ActivityContent.LineCross
{
	// Token: 0x02006768 RID: 26472
	[NullableContext(2)]
	[Nullable(0)]
	public class LineCrossDetailViewModel
	{
		// Token: 0x1700A0CC RID: 41164
		// (get) Token: 0x06041FCA RID: 270282 RVA: 0x010EE4D8 File Offset: 0x010EC6D8
		// (set) Token: 0x06041FCB RID: 270283 RVA: 0x010EE4E0 File Offset: 0x010EC6E0
		public LineCrossActivityData LineCrossActivityData { get; set; }

		// Token: 0x1700A0CD RID: 41165
		// (get) Token: 0x06041FCC RID: 270284 RVA: 0x010EE4E9 File Offset: 0x010EC6E9
		// (set) Token: 0x06041FCD RID: 270285 RVA: 0x010EE4F1 File Offset: 0x010EC6F1
		private LineCrossDetailView Panel { get; set; }

		// Token: 0x06041FCE RID: 270286 RVA: 0x010EE4FC File Offset: 0x010EC6FC
		[NullableContext(1)]
		public void RegisterView(LineCrossDetailView view)
		{
			this.Panel = view;
			LineCrossGroup value = ConfigBase<LineCrossConfig>.Instance.GetLineCrossGroupByGroupId(this.GroupId).Value;
			this.SelectChallengeId = value.ChallengeList(0);
			for (int i = 0; i < value.ChallengeListLength; i++)
			{
				int num = value.ChallengeList(i);
				if (!ModelBase<LineCrossModel>.Instance.GetChallengeFinishState(this.LineCrossActivityData.Id, num))
				{
					this.SelectChallengeId = num;
					return;
				}
			}
		}

		// Token: 0x06041FCF RID: 270287 RVA: 0x010EE572 File Offset: 0x010EC772
		public void OnSelectChallenge(int challengeId)
		{
			this.SelectChallengeId = challengeId;
			this.RefreshRewardLayout();
			this.RefreshTitleText();
			this.RefreshDifficultDescText();
			this.RefreshDescText();
			this.RefreshDifficultSelection();
			this.SaveCurrentChallengeRedDotState();
			this.PlaySwitchSequence();
		}

		// Token: 0x06041FD0 RID: 270288 RVA: 0x010EE5A5 File Offset: 0x010EC7A5
		public void OnShowView()
		{
			this.RefreshRewardLayout();
			this.RefreshNumSprite();
			this.RefreshDescText();
			this.RefreshTitleText();
			this.RefreshDifficultDescText();
			this.RefreshDifficultItem();
			this.RefreshDifficultSelection();
			this.RefreshMiddle();
			this.SaveCurrentChallengeRedDotState();
		}

		// Token: 0x06041FD1 RID: 270289 RVA: 0x010EE5E0 File Offset: 0x010EC7E0
		public bool GetCurrentChallengeFinishRewardState()
		{
			LineCrossActivityData lineCrossActivityData = ModelBase<ActivityModel>.Instance.GetActivityById(this.LineCrossActivityData.Id) as LineCrossActivityData;
			return lineCrossActivityData != null && lineCrossActivityData.GetChallengeIfGetReward(this.SelectChallengeId);
		}

		// Token: 0x06041FD2 RID: 270290 RVA: 0x010EE61C File Offset: 0x010EC81C
		public void RefreshRewardLayout()
		{
			int rewardId = ConfigBase<LineCrossConfig>.Instance.GetLineCrossChallengeById(this.SelectChallengeId).Value.RewardId;
			if (rewardId == 0)
			{
				return;
			}
			List<TItem> dropPackagePreviewItemList = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(rewardId);
			LineCrossDetailView panel = this.Panel;
			if (panel == null)
			{
				return;
			}
			panel.RefreshRewardLayout(dropPackagePreviewItemList);
		}

		// Token: 0x06041FD3 RID: 270291 RVA: 0x010EE66C File Offset: 0x010EC86C
		private void RefreshDifficultItem()
		{
			int[] source = ConfigBase<LineCrossConfig>.Instance.GetLineCrossGroupByGroupId(this.GroupId).Value.GetChallengeListArray() ?? Array.Empty<int>();
			LineCrossDetailView panel = this.Panel;
			if (panel == null)
			{
				return;
			}
			panel.RefreshDifficultItem(source.ToList<int>(), this.SelectChallengeId);
		}

		// Token: 0x06041FD4 RID: 270292 RVA: 0x010EE6BF File Offset: 0x010EC8BF
		private void RefreshDifficultSelection()
		{
			LineCrossDetailView panel = this.Panel;
			if (panel == null)
			{
				return;
			}
			panel.RefreshDifficultItemSelection(this.SelectChallengeId);
		}

		// Token: 0x06041FD5 RID: 270293 RVA: 0x010EE6D8 File Offset: 0x010EC8D8
		private void RefreshNumSprite()
		{
			int num = this.GridIndex + 1;
			LineCrossDetailView panel = this.Panel;
			if (panel == null)
			{
				return;
			}
			panel.RefreshNumText(num);
		}

		// Token: 0x06041FD6 RID: 270294 RVA: 0x010EE700 File Offset: 0x010EC900
		private void RefreshTitleText()
		{
			string name = ConfigBase<LineCrossConfig>.Instance.GetLineCrossChallengeById(this.SelectChallengeId).Value.Name;
			LineCrossDetailView panel = this.Panel;
			if (panel == null)
			{
				return;
			}
			panel.RefreshTitleText(name);
		}

		// Token: 0x06041FD7 RID: 270295 RVA: 0x010EE740 File Offset: 0x010EC940
		private void RefreshDifficultDescText()
		{
			string difficultDesc = ConfigBase<LineCrossConfig>.Instance.GetLineCrossChallengeById(this.SelectChallengeId).Value.DifficultDesc;
			LineCrossDetailView panel = this.Panel;
			if (panel == null)
			{
				return;
			}
			panel.RefreshDifficultDescText(difficultDesc);
		}

		// Token: 0x06041FD8 RID: 270296 RVA: 0x010EE780 File Offset: 0x010EC980
		private void RefreshDescText()
		{
			string desc = ConfigBase<LineCrossConfig>.Instance.GetLineCrossChallengeById(this.SelectChallengeId).Value.Desc;
			LineCrossDetailView panel = this.Panel;
			if (panel == null)
			{
				return;
			}
			panel.ShowDescText(desc);
		}

		// Token: 0x06041FD9 RID: 270297 RVA: 0x010EE7C0 File Offset: 0x010EC9C0
		private void RefreshMiddle()
		{
			bool ifHiddenGroup = ModelBase<LineCrossModel>.Instance.GetIfHiddenGroup(this.LineCrossActivityData.Id, this.GroupId);
			ELineCrossGroupState groupState = ModelBase<LineCrossModel>.Instance.GetGroupState(this.LineCrossActivityData.Id, this.GroupId);
			LineCrossDetailView panel = this.Panel;
			if (panel == null)
			{
				return;
			}
			panel.RefreshMiddleByChallengeState(ifHiddenGroup, groupState);
		}

		// Token: 0x06041FDA RID: 270298 RVA: 0x010EE817 File Offset: 0x010ECA17
		private void PlaySwitchSequence()
		{
			LineCrossDetailView panel = this.Panel;
			if (panel == null)
			{
				return;
			}
			panel.PlaySwitchSequence();
		}

		// Token: 0x06041FDB RID: 270299 RVA: 0x010EE82C File Offset: 0x010ECA2C
		[NullableContext(1)]
		public string GetChallengeTitleId(int challengeId)
		{
			return ConfigBase<LineCrossConfig>.Instance.GetLineCrossChallengeById(challengeId).Value.SubTitle;
		}

		// Token: 0x06041FDC RID: 270300 RVA: 0x010EE854 File Offset: 0x010ECA54
		public bool GetChallengeLockState(int challengeId)
		{
			return !ModelBase<LineCrossModel>.Instance.GetChallengeRequireFinishState(this.LineCrossActivityData.Id, challengeId);
		}

		// Token: 0x06041FDD RID: 270301 RVA: 0x010EE870 File Offset: 0x010ECA70
		public bool GetChallengeFinishState(int challengeId)
		{
			LineCrossActivityData lineCrossActivityData = ModelBase<ActivityModel>.Instance.GetActivityById(this.LineCrossActivityData.Id) as LineCrossActivityData;
			return lineCrossActivityData != null && lineCrossActivityData.GetChallengeIfGetReward(challengeId);
		}

		// Token: 0x06041FDE RID: 270302 RVA: 0x010EE8A4 File Offset: 0x010ECAA4
		public int GetCurrentChallengeId()
		{
			return this.SelectChallengeId;
		}

		// Token: 0x06041FDF RID: 270303 RVA: 0x010EE8AC File Offset: 0x010ECAAC
		public void SaveCurrentChallengeRedDotState()
		{
			int currentChallengeId = this.GetCurrentChallengeId();
			ModelBase<LineCrossModel>.Instance.SaveChallengeRedDotState(this.LineCrossActivityData.Id, currentChallengeId);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshLineCrossGroupRedDot, this.GroupId);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshLineCrossChallengeRedDot, currentChallengeId);
		}

		// Token: 0x04024CED RID: 150765
		private int SelectChallengeId;

		// Token: 0x04024CEE RID: 150766
		public int GroupId;

		// Token: 0x04024CEF RID: 150767
		public int GridIndex;
	}
}
