using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Spring25
{
	// Token: 0x02006360 RID: 25440
	[NullableContext(1)]
	[Nullable(0)]
	public class ActivitySpring25SubView : ActivitySubViewBase
	{
		// Token: 0x17009CCE RID: 40142
		// (get) Token: 0x0603FDF0 RID: 261616 RVA: 0x010623F8 File Offset: 0x010605F8
		// (set) Token: 0x0603FDF1 RID: 261617 RVA: 0x01062400 File Offset: 0x01060600
		private ActivityTitleTypeA TitleComponent { get; set; }

		// Token: 0x17009CCF RID: 40143
		// (get) Token: 0x0603FDF2 RID: 261618 RVA: 0x01062409 File Offset: 0x01060609
		// (set) Token: 0x0603FDF3 RID: 261619 RVA: 0x01062411 File Offset: 0x01060611
		private ActivityDescriptionTypeA DescriptionComponent { get; set; }

		// Token: 0x17009CD0 RID: 40144
		// (get) Token: 0x0603FDF4 RID: 261620 RVA: 0x0106241A File Offset: 0x0106061A
		// (set) Token: 0x0603FDF5 RID: 261621 RVA: 0x01062422 File Offset: 0x01060622
		private ActivityRewardList<CommonItemSmallItemGrid, TItem> RewardListComponent { get; set; }

		// Token: 0x17009CD1 RID: 40145
		// (get) Token: 0x0603FDF6 RID: 261622 RVA: 0x0106242B File Offset: 0x0106062B
		// (set) Token: 0x0603FDF7 RID: 261623 RVA: 0x01062433 File Offset: 0x01060633
		private ActivityFunctionalTypeA FunctionalComponent { get; set; }

		// Token: 0x0603FDF8 RID: 261624 RVA: 0x0106243C File Offset: 0x0106063C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
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
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603FDF9 RID: 261625 RVA: 0x01062590 File Offset: 0x01060790
		protected override UniTask OnBeforeStartAsync()
		{
			ActivitySpring25SubView.<OnBeforeStartAsync>d__18 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<ActivitySpring25SubView.<OnBeforeStartAsync>d__18>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603FDFA RID: 261626 RVA: 0x010625D4 File Offset: 0x010607D4
		protected override void OnStart()
		{
			ActivityBaseData activityBaseData = this.ActivityBaseData;
			Activity? activity = (activityBaseData != null) ? activityBaseData.LocalConfig : null;
			Spring25ActivitySubViewData spring25ActivitySubViewData = ModelBase<Spring25Model>.Instance.BuildActivitySubViewData();
			ActivityTitleTypeA titleComponent = this.TitleComponent;
			if (titleComponent != null)
			{
				titleComponent.SetActivityBaseData(this.ActivityBaseData);
			}
			ActivityTitleTypeA titleComponent2 = this.TitleComponent;
			if (titleComponent2 != null)
			{
				ActivityBaseData activityBaseData2 = this.ActivityBaseData;
				titleComponent2.SetTitleByText((activityBaseData2 != null) ? activityBaseData2.GetTitle() : null);
			}
			ActivityTitleTypeA titleComponent3 = this.TitleComponent;
			if (titleComponent3 != null)
			{
				titleComponent3.SetSubTitleVisible(!StringUtils.IsEmpty((activity != null) ? activity.GetValueOrDefault().DescTheme : null));
			}
			if (((activity != null) ? activity.GetValueOrDefault().DescTheme : null) != null)
			{
				ActivityTitleTypeA titleComponent4 = this.TitleComponent;
				if (titleComponent4 != null)
				{
					titleComponent4.SetSubTitleByTextId(activity.Value.DescTheme, Array.Empty<string>());
				}
			}
			this.RefreshTimerText();
			ActivityDescriptionTypeA descriptionComponent = this.DescriptionComponent;
			if (descriptionComponent != null)
			{
				descriptionComponent.SetContentVisible(!StringUtils.IsEmpty((activity != null) ? activity.GetValueOrDefault().Desc : null));
			}
			if (((activity != null) ? activity.GetValueOrDefault().Desc : null) != null)
			{
				ActivityDescriptionTypeA descriptionComponent2 = this.DescriptionComponent;
				if (descriptionComponent2 != null)
				{
					descriptionComponent2.SetContentByTextId(activity.Value.Desc, Array.Empty<string>());
				}
			}
			ActivityBaseData activityBaseData3 = this.ActivityBaseData;
			List<TItem> dataList = (activityBaseData3 != null) ? activityBaseData3.GetPreviewReward(null) : null;
			ActivityRewardList<CommonItemSmallItemGrid, TItem> rewardListComponent = this.RewardListComponent;
			if (rewardListComponent != null)
			{
				rewardListComponent.InitGridLayout(new Func<CommonItemSmallItemGrid>(this.RewardListComponent.InitCommonGridItem));
			}
			ActivityRewardList<CommonItemSmallItemGrid, TItem> rewardListComponent2 = this.RewardListComponent;
			if (rewardListComponent2 != null)
			{
				rewardListComponent2.RefreshItemLayout(dataList, null);
			}
			ActivityRewardList<CommonItemSmallItemGrid, TItem> rewardListComponent3 = this.RewardListComponent;
			if (rewardListComponent3 != null)
			{
				rewardListComponent3.SetTitleByTextId(spring25ActivitySubViewData.RewardTextId);
			}
			ActivityFunctionalTypeA functionalComponent = this.FunctionalComponent;
			if (functionalComponent != null)
			{
				ActivityButtonItem functionButton = functionalComponent.FunctionButton;
				if (functionButton != null)
				{
					functionButton.SetFunction(new Action(this.HandleOnClickConfirm));
				}
			}
			ActivityFunctionalTypeA functionalComponent2 = this.FunctionalComponent;
			if (functionalComponent2 != null)
			{
				ActivityButtonItem functionButton2 = functionalComponent2.FunctionButton;
				if (functionButton2 != null)
				{
					functionButton2.SetLocalTextNew(spring25ActivitySubViewData.ButtonTextId, Array.Empty<object>());
				}
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), spring25ActivitySubViewData.ProgressTextId, Array.Empty<object>());
			UUIText text = base.GetText(5);
			if (text != null)
			{
				text.SetText(spring25ActivitySubViewData.Current, true);
			}
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(6), spring25ActivitySubViewData.TotalTextId, new <>z__ReadOnlySingleElementList<object>(spring25ActivitySubViewData.TotalTextArg));
			UUITexture texture = base.GetTexture(8);
			if (texture != null)
			{
				texture.SetUIActive(spring25ActivitySubViewData.IsMale);
			}
			UUITexture texture2 = base.GetTexture(7);
			if (texture2 == null)
			{
				return;
			}
			texture2.SetUIActive(!spring25ActivitySubViewData.IsMale);
		}

		// Token: 0x0603FDFB RID: 261627 RVA: 0x0106287A File Offset: 0x01060A7A
		protected override void OnBeforeShow()
		{
			base.OnBeforeShow();
			ActivityFunctionalTypeA functionalComponent = this.FunctionalComponent;
			if (functionalComponent == null)
			{
				return;
			}
			ActivityButtonItem functionButton = functionalComponent.FunctionButton;
			if (functionButton == null)
			{
				return;
			}
			functionButton.BindRedDot(ERedDotName.Spring25Enter, 0);
		}

		// Token: 0x0603FDFC RID: 261628 RVA: 0x010628A2 File Offset: 0x01060AA2
		protected override void OnAfterHide()
		{
			base.OnAfterHide();
			ActivityFunctionalTypeA functionalComponent = this.FunctionalComponent;
			if (functionalComponent == null)
			{
				return;
			}
			ActivityButtonItem functionButton = functionalComponent.FunctionButton;
			if (functionButton == null)
			{
				return;
			}
			functionButton.UnBindGivenUid(0);
		}

		// Token: 0x0603FDFD RID: 261629 RVA: 0x010628C5 File Offset: 0x01060AC5
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.Spring25InviteDone, new Action(this.HandleSpring25InviteDone));
		}

		// Token: 0x0603FDFE RID: 261630 RVA: 0x010628E3 File Offset: 0x01060AE3
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.Spring25InviteDone, new Action(this.HandleSpring25InviteDone));
		}

		// Token: 0x0603FDFF RID: 261631 RVA: 0x01062901 File Offset: 0x01060B01
		protected override void OnTimer(float delta)
		{
			this.RefreshTimerText();
		}

		// Token: 0x0603FE00 RID: 261632 RVA: 0x0106290C File Offset: 0x01060B0C
		private void RefreshTimerText()
		{
			ValueTuple<bool, string, long> timeVisibleAndRemainTime = this.GetTimeVisibleAndRemainTime();
			bool item = timeVisibleAndRemainTime.Item1;
			string item2 = timeVisibleAndRemainTime.Item2;
			ActivityTitleTypeA titleComponent = this.TitleComponent;
			if (titleComponent != null)
			{
				titleComponent.SetTimeTextVisible(item);
			}
			if (item)
			{
				ActivityTitleTypeA titleComponent2 = this.TitleComponent;
				if (titleComponent2 == null)
				{
					return;
				}
				titleComponent2.SetTimeTextByText(item2);
			}
		}

		// Token: 0x0603FE01 RID: 261633 RVA: 0x01062954 File Offset: 0x01060B54
		private void HandleOnClickConfirm()
		{
			ControllerBase<ActivitySpring25Controller>.Instance.HandleConfirmClickInActivitySubView();
		}

		// Token: 0x0603FE02 RID: 261634 RVA: 0x01062960 File Offset: 0x01060B60
		private void HandleSpring25InviteDone()
		{
			Spring25ActivitySubViewData spring25ActivitySubViewData = ModelBase<Spring25Model>.Instance.BuildActivitySubViewData();
			UUIText text = base.GetText(5);
			if (text != null)
			{
				text.SetText(spring25ActivitySubViewData.Current, true);
			}
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(6), spring25ActivitySubViewData.TotalTextId, new <>z__ReadOnlySingleElementList<object>(spring25ActivitySubViewData.TotalTextArg));
		}

		// Token: 0x0200C3C0 RID: 50112
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x0403C4B7 RID: 246967
			public const int ActivityTitleItem = 0;

			// Token: 0x0403C4B8 RID: 246968
			public const int ActivityDescItem = 1;

			// Token: 0x0403C4B9 RID: 246969
			public const int ActivityRewardItem = 2;

			// Token: 0x0403C4BA RID: 246970
			public const int ActivityFunctionItem = 3;

			// Token: 0x0403C4BB RID: 246971
			public const int ProgressText = 4;

			// Token: 0x0403C4BC RID: 246972
			public const int CurrentNumText = 5;

			// Token: 0x0403C4BD RID: 246973
			public const int TotalNumText = 6;

			// Token: 0x0403C4BE RID: 246974
			public const int FemaleTexture = 7;

			// Token: 0x0403C4BF RID: 246975
			public const int MaleTexture = 8;
		}
	}
}
