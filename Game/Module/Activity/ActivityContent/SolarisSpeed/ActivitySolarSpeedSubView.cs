using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SolarisSpeed
{
	// Token: 0x02006390 RID: 25488
	[NullableContext(2)]
	[Nullable(0)]
	public class ActivitySolarSpeedSubView : ActivitySubViewBase
	{
		// Token: 0x06040005 RID: 262149 RVA: 0x01067434 File Offset: 0x01065634
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.HandleOnClickReward));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06040006 RID: 262150 RVA: 0x010675A0 File Offset: 0x010657A0
		protected override UniTask OnBeforeStartAsync()
		{
			ActivitySolarSpeedSubView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<ActivitySolarSpeedSubView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040007 RID: 262151 RVA: 0x010675E4 File Offset: 0x010657E4
		protected override void OnStart()
		{
			Activity? localConfig = this.ActivityBaseData.LocalConfig;
			ISolarSpeedActivitySubViewData solarSpeedActivitySubViewData = ModelBase<SolarSpeedModel>.Instance.BuildActivitySubViewData();
			this.TitleComponent.SetActivityBaseData(this.ActivityBaseData);
			this.TitleComponent.SetTitleByText(this.ActivityBaseData.GetTitle());
			this.TitleComponent.SetSubTitleVisible(!StringUtils.IsEmpty((localConfig != null) ? localConfig.GetValueOrDefault().DescTheme : null));
			if (((localConfig != null) ? localConfig.GetValueOrDefault().DescTheme : null) != null)
			{
				this.TitleComponent.SetSubTitleByTextId(localConfig.Value.DescTheme, Array.Empty<string>());
			}
			this.RefreshTimerText();
			this.DescriptionComponent.SetContentVisible(!StringUtils.IsEmpty((localConfig != null) ? localConfig.GetValueOrDefault().Desc : null));
			if (((localConfig != null) ? localConfig.GetValueOrDefault().Desc : null) != null)
			{
				this.DescriptionComponent.SetContentByTextId(localConfig.Value.Desc, Array.Empty<string>());
			}
			List<TItem> previewReward = this.ActivityBaseData.GetPreviewReward(null);
			this.RewardListComponent.InitGridLayout(new Func<CommonItemSmallItemGrid>(this.RewardListComponent.InitCommonGridItem));
			this.RewardListComponent.RefreshItemLayout(previewReward, null);
			this.RewardListComponent.SetTitleByTextId(solarSpeedActivitySubViewData.RewardTextId);
			bool flag = this.ActivityBaseData.IsUnLock();
			this.FunctionalComponent.SetPanelConditionVisible(!flag);
			this.FunctionalComponent.FunctionButton.SetActive(flag);
			if (flag)
			{
				this.FunctionalComponent.FunctionButton.SetFunction(new Action(this.HandleOnClickConfirm));
				this.FunctionalComponent.FunctionButton.SetLocalTextNew(solarSpeedActivitySubViewData.ButtonTextId, Array.Empty<object>());
			}
			else
			{
				this.FunctionalComponent.SetPerformanceConditionLock(this.ActivityBaseData.ConditionGroupId, this.ActivityBaseData.Id);
			}
			UUIItem item = base.GetItem(6);
			if (item != null)
			{
				item.SetUIActive(flag);
			}
			this.RewardProgressGetter = solarSpeedActivitySubViewData.RewardProgressCurrentGetter;
			this.RewardProgressTextId = solarSpeedActivitySubViewData.RewardProgressTextId;
			this.RewardProgressTotal = solarSpeedActivitySubViewData.RewardProgressTotal;
			if (flag)
			{
				string text = (this.RewardProgressGetter == null) ? "0" : this.RewardProgressGetter();
				Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(7), solarSpeedActivitySubViewData.RewardProgressTextId, new <>z__ReadOnlyArray<object>(new object[]
				{
					text,
					solarSpeedActivitySubViewData.RewardProgressTotal
				}));
			}
			this.RewardRedDotStateGetter = solarSpeedActivitySubViewData.RewardRedDotStateGetter;
			if (this.RewardRedDotStateGetter != null)
			{
				UUIItem item2 = base.GetItem(5);
				if (item2 != null)
				{
					item2.SetUIActive(this.RewardRedDotStateGetter());
				}
			}
			this.ConfirmRedDotStateGetter = solarSpeedActivitySubViewData.ConfirmRedDotStateGetter;
			if (this.ConfirmRedDotStateGetter != null)
			{
				ActivityFunctionalTypeA functionalComponent = this.FunctionalComponent;
				if (functionalComponent == null)
				{
					return;
				}
				functionalComponent.SetFunctionRedDotVisible(this.ConfirmRedDotStateGetter());
			}
		}

		// Token: 0x06040008 RID: 262152 RVA: 0x010678CE File Offset: 0x01065ACE
		protected override void OnBeforeShow()
		{
			base.OnBeforeShow();
		}

		// Token: 0x06040009 RID: 262153 RVA: 0x010678D6 File Offset: 0x01065AD6
		protected override void OnAfterHide()
		{
			base.OnAfterHide();
		}

		// Token: 0x0604000A RID: 262154 RVA: 0x010678DE File Offset: 0x01065ADE
		protected override void OnRefreshView()
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.SolarSpeedSubViewOnRefreshView);
		}

		// Token: 0x0604000B RID: 262155 RVA: 0x010678F0 File Offset: 0x01065AF0
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.SolarSpeedRewarded, new Action(this.HandleSolarSpeedRewarded));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.OnChallengeInstanceRedDot, new Action<int>(this.HandleOnChallengeInstanceRedDot));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.HandleRefreshCommonActivityRedDot));
		}

		// Token: 0x0604000C RID: 262156 RVA: 0x01067954 File Offset: 0x01065B54
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.SolarSpeedRewarded, new Action(this.HandleSolarSpeedRewarded));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnChallengeInstanceRedDot, new <>f__AnonymousDelegate2<int>(this.HandleOnChallengeInstanceRedDot));
			Singleton<EventSystem>.Instance.Remove(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.HandleRefreshCommonActivityRedDot));
		}

		// Token: 0x0604000D RID: 262157 RVA: 0x010679B5 File Offset: 0x01065BB5
		protected override void OnTimer(float delta)
		{
			this.RefreshTimerText();
		}

		// Token: 0x0604000E RID: 262158 RVA: 0x010679C0 File Offset: 0x01065BC0
		private void RefreshTimerText()
		{
			ValueTuple<bool, string, long> timeVisibleAndRemainTime = this.GetTimeVisibleAndRemainTime();
			bool item = timeVisibleAndRemainTime.Item1;
			string item2 = timeVisibleAndRemainTime.Item2;
			this.TitleComponent.SetTimeTextVisible(item);
			if (item)
			{
				this.TitleComponent.SetTimeTextByText(item2);
			}
		}

		// Token: 0x0604000F RID: 262159 RVA: 0x010679FD File Offset: 0x01065BFD
		private void HandleOnClickConfirm()
		{
			ControllerBase<ActivitySolarSpeedController>.Instance.HandleConfirmClickInActivitySubView();
		}

		// Token: 0x06040010 RID: 262160 RVA: 0x01067A09 File Offset: 0x01065C09
		private void HandleOnClickReward()
		{
			ControllerBase<ActivitySolarSpeedController>.Instance.HandleOnClickRewardInActivitySubView();
		}

		// Token: 0x06040011 RID: 262161 RVA: 0x01067A18 File Offset: 0x01065C18
		private void HandleSolarSpeedRewarded()
		{
			if (this.RewardRedDotStateGetter != null)
			{
				UUIItem item = base.GetItem(5);
				if (item != null)
				{
					item.SetUIActive(this.RewardRedDotStateGetter());
				}
			}
			if (this.RewardProgressGetter != null)
			{
				Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(7), this.RewardProgressTextId, new <>z__ReadOnlyArray<object>(new object[]
				{
					this.RewardProgressGetter(),
					this.RewardProgressTotal
				}));
			}
		}

		// Token: 0x06040012 RID: 262162 RVA: 0x01067A8B File Offset: 0x01065C8B
		private void HandleOnChallengeInstanceRedDot(int i = 0)
		{
			if (this.ConfirmRedDotStateGetter != null)
			{
				ActivityFunctionalTypeA functionalComponent = this.FunctionalComponent;
				if (functionalComponent == null)
				{
					return;
				}
				functionalComponent.SetFunctionRedDotVisible(this.ConfirmRedDotStateGetter());
			}
		}

		// Token: 0x06040013 RID: 262163 RVA: 0x01067AB0 File Offset: 0x01065CB0
		private void HandleRefreshCommonActivityRedDot(int activityId)
		{
			if (activityId != ModelBase<SolarSpeedModel>.Instance.CurrentActivityId)
			{
				return;
			}
			if (this.ConfirmRedDotStateGetter != null)
			{
				ActivityFunctionalTypeA functionalComponent = this.FunctionalComponent;
				if (functionalComponent == null)
				{
					return;
				}
				functionalComponent.SetFunctionRedDotVisible(this.ConfirmRedDotStateGetter());
			}
		}

		// Token: 0x04023EFE RID: 147198
		private ActivityTitleTypeA TitleComponent;

		// Token: 0x04023EFF RID: 147199
		private ActivityDescriptionTypeA DescriptionComponent;

		// Token: 0x04023F00 RID: 147200
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private ActivityRewardList<CommonItemSmallItemGrid, TItem> RewardListComponent;

		// Token: 0x04023F01 RID: 147201
		private ActivityFunctionalTypeA FunctionalComponent;

		// Token: 0x04023F02 RID: 147202
		private Func<bool> RewardRedDotStateGetter;

		// Token: 0x04023F03 RID: 147203
		private Func<bool> ConfirmRedDotStateGetter;

		// Token: 0x04023F04 RID: 147204
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Func<string> RewardProgressGetter;

		// Token: 0x04023F05 RID: 147205
		[Nullable(1)]
		private string RewardProgressTextId;

		// Token: 0x04023F06 RID: 147206
		[Nullable(1)]
		private string RewardProgressTotal;

		// Token: 0x0200C3E8 RID: 50152
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x0403C57A RID: 247162
			public const int ActivityTitleItem = 0;

			// Token: 0x0403C57B RID: 247163
			public const int ActivityDescItem = 1;

			// Token: 0x0403C57C RID: 247164
			public const int ActivityRewardItem = 2;

			// Token: 0x0403C57D RID: 247165
			public const int ActivityFunctionItem = 3;

			// Token: 0x0403C57E RID: 247166
			public const int RewardButton = 4;

			// Token: 0x0403C57F RID: 247167
			public const int RedDotItem = 5;

			// Token: 0x0403C580 RID: 247168
			public const int RewardRoot = 6;

			// Token: 0x0403C581 RID: 247169
			public const int RewardValueText = 7;
		}
	}
}
