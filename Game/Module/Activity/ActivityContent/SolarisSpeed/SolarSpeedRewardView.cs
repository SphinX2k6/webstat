using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SolarisSpeed
{
	// Token: 0x02006392 RID: 25490
	[NullableContext(1)]
	[Nullable(0)]
	public class SolarSpeedRewardView : UiViewBase
	{
		// Token: 0x06040021 RID: 262177 RVA: 0x01067DB4 File Offset: 0x01065FB4
		public SolarSpeedRewardView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06040022 RID: 262178 RVA: 0x01067DC0 File Offset: 0x01065FC0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06040023 RID: 262179 RVA: 0x01067E4C File Offset: 0x0106604C
		protected override UniTask OnBeforeStartAsync()
		{
			SolarSpeedRewardView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SolarSpeedRewardView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040024 RID: 262180 RVA: 0x01067E90 File Offset: 0x01066090
		protected override void OnStart()
		{
			ISolarSpeedRewardViewData solarSpeedRewardViewData = this.OpenParam as ISolarSpeedRewardViewData;
			this.CaptionItem.SetTitleByTextIdAndArgNew(solarSpeedRewardViewData.TitleTextId, Array.Empty<object>());
			this.CaptionItem.SetTitleIcon(solarSpeedRewardViewData.TitleIconPath);
			this.CaptionItem.SetCloseCallBack(new Action(this.HandleOnCloseClick));
			UUIText text = base.GetText(2);
			if (text != null)
			{
				text.SetUIActive(false);
			}
			this.RefreshByOpenParam();
			this.CaptionPlayer.LitePlayAsync("Start", false, false);
			this.RewardPlayer.LitePlayAsync("Start", false, false);
		}

		// Token: 0x06040025 RID: 262181 RVA: 0x01067F28 File Offset: 0x01066128
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<int>(EEventName.SolarSpeedClickRewardTab, new Action<int>(this.HandleSolarSpeedClickRewardTab));
			Singleton<EventSystem>.Instance.Add(EEventName.SolarSpeedRewarded, new Action(this.HandleSolarSpeedRewarded));
			Singleton<EventSystem>.Instance.Add<string>(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.HandleOnActivitySequenceEmitEvent));
		}

		// Token: 0x06040026 RID: 262182 RVA: 0x01067F8C File Offset: 0x0106618C
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.SolarSpeedClickRewardTab, new Action<int>(this.HandleSolarSpeedClickRewardTab));
			Singleton<EventSystem>.Instance.Remove(EEventName.SolarSpeedRewarded, new Action(this.HandleSolarSpeedRewarded));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.HandleOnActivitySequenceEmitEvent));
		}

		// Token: 0x06040027 RID: 262183 RVA: 0x01067FED File Offset: 0x010661ED
		protected override void OnBeforeShow()
		{
			this.CaptionPlayer.LitePlayAsync("Start", false, false);
			this.RewardPlayer.LitePlayAsync("Start", false, false);
		}

		// Token: 0x06040028 RID: 262184 RVA: 0x01068018 File Offset: 0x01066218
		protected override UniTask OnBeforeHideAsync()
		{
			SolarSpeedRewardView.<OnBeforeHideAsync>d__11 <OnBeforeHideAsync>d__;
			<OnBeforeHideAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeHideAsync>d__.<>4__this = this;
			<OnBeforeHideAsync>d__.<>1__state = -1;
			<OnBeforeHideAsync>d__.<>t__builder.Start<SolarSpeedRewardView.<OnBeforeHideAsync>d__11>(ref <OnBeforeHideAsync>d__);
			return <OnBeforeHideAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040029 RID: 262185 RVA: 0x0106805C File Offset: 0x0106625C
		private void RefreshByOpenParam()
		{
			ISolarSpeedRewardViewData solarSpeedRewardViewData = this.OpenParam as ISolarSpeedRewardViewData;
			this.RewardItem.OpenParam = solarSpeedRewardViewData.RewardPanelData;
			this.RewardItem.RefreshByOpenParam();
		}

		// Token: 0x0604002A RID: 262186 RVA: 0x01068091 File Offset: 0x01066291
		private void HandleOnCloseClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x0604002B RID: 262187 RVA: 0x0106809C File Offset: 0x0106629C
		private void HandleSolarSpeedClickRewardTab(int id)
		{
			ISolarSpeedRewardViewData solarSpeedRewardViewData = ModelBase<SolarSpeedModel>.Instance.BuildSolarSpeedRewardViewDataById(id);
			this.OpenParam = solarSpeedRewardViewData;
			this.RewardItem.OpenParam = solarSpeedRewardViewData.RewardPanelData;
			this.RewardItem.RefreshByOpenParam();
			this.RewardPlayer.LiteStop();
			this.RewardPlayer.LitePlayAsync("Switch", false, false);
		}

		// Token: 0x0604002C RID: 262188 RVA: 0x010680F8 File Offset: 0x010662F8
		private void HandleSolarSpeedRewarded()
		{
			SolarSpeedModel instance = ModelBase<SolarSpeedModel>.Instance;
			if (instance.CurrentChosenTabInRewardView == null)
			{
				return;
			}
			this.OpenParam = instance.BuildSolarSpeedRewardViewDataById(instance.CurrentChosenTabInRewardView.Value);
			this.RefreshByOpenParam();
		}

		// Token: 0x0604002D RID: 262189 RVA: 0x0106813C File Offset: 0x0106633C
		private void HandleOnActivitySequenceEmitEvent(string param)
		{
			this.RewardItem.PlayStart(param);
		}

		// Token: 0x04023F0B RID: 147211
		private PopupCaptionItem CaptionItem;

		// Token: 0x04023F0C RID: 147212
		private SolarSpeedRewardPanel RewardItem;

		// Token: 0x04023F0D RID: 147213
		private UiSequencePlayer CaptionPlayer;

		// Token: 0x04023F0E RID: 147214
		private UiSequencePlayer RewardPlayer;

		// Token: 0x0200C3ED RID: 50157
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x0403C593 RID: 247187
			public const int CaptionItem = 0;

			// Token: 0x0403C594 RID: 247188
			public const int RewardItem = 1;

			// Token: 0x0403C595 RID: 247189
			public const int PointText = 2;
		}
	}
}
