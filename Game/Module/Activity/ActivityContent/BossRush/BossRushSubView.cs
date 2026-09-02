using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.BossRush
{
	// Token: 0x020069CE RID: 27086
	[NullableContext(2)]
	[Nullable(0)]
	public class BossRushSubView : ActivitySubViewBase
	{
		// Token: 0x06043259 RID: 275033 RVA: 0x011401C0 File Offset: 0x0113E3C0
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(5, typeof(UUIText)),
				new ValueTuple<int, Type>(6, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(4, new Action(this.OnClickRewardbtn))
			};
		}

		// Token: 0x0604325A RID: 275034 RVA: 0x01140295 File Offset: 0x0113E495
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.BossRushDataUpdate, new Action(this.OnBossRushDataUpdate));
		}

		// Token: 0x0604325B RID: 275035 RVA: 0x011402B3 File Offset: 0x0113E4B3
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.BossRushDataUpdate, new Action(this.OnBossRushDataUpdate));
		}

		// Token: 0x0604325C RID: 275036 RVA: 0x011402D1 File Offset: 0x0113E4D1
		private void OnClickRewardbtn()
		{
			ModelBase<BossRushModel>.Instance.OnlyOpenRewardView = true;
			ControllerBase<BossRushController>.Instance.OpenBossRushView(this.ActivityBaseData.Id);
		}

		// Token: 0x0604325D RID: 275037 RVA: 0x011402F4 File Offset: 0x0113E4F4
		private void OnBossRushDataUpdate()
		{
			this.RefreshRedDot();
		}

		// Token: 0x0604325E RID: 275038 RVA: 0x011402FC File Offset: 0x0113E4FC
		protected override UniTask OnBeforeStartAsync()
		{
			BossRushSubView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<BossRushSubView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0604325F RID: 275039 RVA: 0x0114033F File Offset: 0x0113E53F
		protected override void OnStart()
		{
			this.BossRushData = (this.ActivityBaseData as BossRushData);
		}

		// Token: 0x06043260 RID: 275040 RVA: 0x01140352 File Offset: 0x0113E552
		protected override void OnBeforeShow()
		{
			this.BindRedDot();
		}

		// Token: 0x06043261 RID: 275041 RVA: 0x0114035A File Offset: 0x0113E55A
		protected override void OnBeforeHide()
		{
			this.RemoveRedDot();
		}

		// Token: 0x06043262 RID: 275042 RVA: 0x01140364 File Offset: 0x0113E564
		protected override void OnRefreshView()
		{
			Activity? localConfig = this.ActivityBaseData.LocalConfig;
			if (localConfig == null)
			{
				return;
			}
			this.RefreshDesc();
			this.RefreshTitle();
			this.RefreshReward();
			this.RefreshFunctionalComponent();
			this.RefreshRedDot();
			this.RefreshState();
			this.TryShowNewUnlockTips();
			this.RefreshProgressText();
		}

		// Token: 0x06043263 RID: 275043 RVA: 0x011403B8 File Offset: 0x0113E5B8
		private void RefreshProgressText()
		{
			int finishTaskCount = this.BossRushData.GetFinishTaskCount();
			int allTaskCount = this.BossRushData.GetAllTaskCount();
			UUIText text = base.GetText(5);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(finishTaskCount);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(allTaskCount);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}

		// Token: 0x06043264 RID: 275044 RVA: 0x01140416 File Offset: 0x0113E616
		private void BindRedDot()
		{
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.BossRushReward, base.GetItem(6), null, this.BossRushData.Id);
		}

		// Token: 0x06043265 RID: 275045 RVA: 0x0114043A File Offset: 0x0113E63A
		private void RemoveRedDot()
		{
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.BossRushReward, base.GetItem(6), 0);
		}

		// Token: 0x06043266 RID: 275046 RVA: 0x01140454 File Offset: 0x0113E654
		private void TryShowNewUnlockTips()
		{
			if (this.BossRushData.GetNewUnlockState())
			{
				this.BossRushData.CacheNewUnlock();
				DifficultUnlockTipsData difficultUnlockTipsData = new DifficultUnlockTipsData();
				difficultUnlockTipsData.Text = "BossRushUnlockTips";
				Singleton<UiManager>.Instance.OpenView(EUiViewName.DifficultUnlockTipView, difficultUnlockTipsData, null);
			}
		}

		// Token: 0x06043267 RID: 275047 RVA: 0x0114049C File Offset: 0x0113E69C
		private void RefreshState()
		{
			bool flag = this.ActivityBaseData.IsUnLock();
			this.FunctionalComponent.SetPanelConditionVisible(!flag);
			if (!flag)
			{
				this.FunctionalComponent.SetPerformanceConditionLock(this.ActivityBaseData.ConditionGroupId, this.ActivityBaseData.Id);
			}
			this.FunctionalComponent.FunctionButton.SetUiActive(flag);
		}

		// Token: 0x06043268 RID: 275048 RVA: 0x011404FC File Offset: 0x0113E6FC
		private void RefreshTitle()
		{
			this.TitleComponent.SetActivityBaseData(this.ActivityBaseData);
			this.TitleComponent.SetTitleByText(this.ActivityBaseData.GetTitle());
			ValueTuple<bool, string, long> timeVisibleAndRemainTime = this.GetTimeVisibleAndRemainTime();
			bool item = timeVisibleAndRemainTime.Item1;
			string item2 = timeVisibleAndRemainTime.Item2;
			this.TitleComponent.SetTimeTextVisible(item);
			if (item)
			{
				this.TitleComponent.SetTimeTextByText(item2);
			}
		}

		// Token: 0x06043269 RID: 275049 RVA: 0x01140560 File Offset: 0x0113E760
		private void RefreshDesc()
		{
			Activity? localConfig = this.ActivityBaseData.LocalConfig;
			string descTheme = localConfig.Value.DescTheme;
			string desc = localConfig.Value.Desc;
			bool flag = !StringUtils.IsEmpty(descTheme);
			this.TitleComponent.SetSubTitleVisible(flag);
			if (flag)
			{
				this.TitleComponent.SetSubTitleByTextId(descTheme, Array.Empty<string>());
			}
			this.DescriptionComponent.SetContentByTextId(desc, Array.Empty<string>());
		}

		// Token: 0x0604326A RID: 275050 RVA: 0x011405D8 File Offset: 0x0113E7D8
		private void RefreshReward()
		{
			List<TItem> previewReward = this.ActivityBaseData.GetPreviewReward(null);
			this.RewardListComponent.SetTitleByTextId("BossRushCollectReward");
			this.RewardListComponent.RefreshItemLayout(previewReward, null);
		}

		// Token: 0x0604326B RID: 275051 RVA: 0x01140617 File Offset: 0x0113E817
		protected override void OnTimer(float gap)
		{
			base.OnTimer(gap);
			this.RefreshTitle();
		}

		// Token: 0x0604326C RID: 275052 RVA: 0x01140628 File Offset: 0x0113E828
		private void RefreshFunctionalComponent()
		{
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew("BossRushEnterText", null);
			this.FunctionalComponent.FunctionButton.SetText(localTextNew);
		}

		// Token: 0x0604326D RID: 275053 RVA: 0x01140654 File Offset: 0x0113E854
		private void FunctionExecute()
		{
			if (!this.ActivityBaseData.GetPreGuideQuestFinishState())
			{
				int unFinishPreGuideQuestId = this.ActivityBaseData.GetUnFinishPreGuideQuestId();
				Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, unFinishPreGuideQuestId, null);
				return;
			}
			ControllerBase<BossRushController>.Instance.OpenBossRushView(this.ActivityBaseData.Id);
		}

		// Token: 0x0604326E RID: 275054 RVA: 0x011406A8 File Offset: 0x0113E8A8
		private void RefreshRedDot()
		{
			bool flag = this.BossRushData.EntranceRedDot();
			bool preGuideQuestFinishState = this.BossRushData.GetPreGuideQuestFinishState();
			this.FunctionalComponent.FunctionButton.SetRedDotVisible(preGuideQuestFinishState && flag);
		}

		// Token: 0x040256A4 RID: 153252
		private BossRushData BossRushData;

		// Token: 0x040256A5 RID: 153253
		private ActivityTitleTypeA TitleComponent;

		// Token: 0x040256A6 RID: 153254
		private ActivityDescriptionTypeA DescriptionComponent;

		// Token: 0x040256A7 RID: 153255
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private ActivityRewardList<CommonItemSmallItemGrid, TItem> RewardListComponent;

		// Token: 0x040256A8 RID: 153256
		private ActivityFunctionalArea FunctionalComponent;

		// Token: 0x0200C952 RID: 51538
		[NullableContext(0)]
		private enum EComponent
		{
			// Token: 0x0403DEB0 RID: 253616
			TitleItem,
			// Token: 0x0403DEB1 RID: 253617
			DescItem,
			// Token: 0x0403DEB2 RID: 253618
			RewardItem,
			// Token: 0x0403DEB3 RID: 253619
			FunctionalAreaItem,
			// Token: 0x0403DEB4 RID: 253620
			RewardBtn,
			// Token: 0x0403DEB5 RID: 253621
			RewardProgress,
			// Token: 0x0403DEB6 RID: 253622
			RewardRedDot
		}
	}
}
