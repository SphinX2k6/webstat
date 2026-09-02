using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Coop
{
	// Token: 0x02006989 RID: 27017
	[NullableContext(2)]
	[Nullable(0)]
	public class CoopActivityView : ActivitySubViewBase
	{
		// Token: 0x060430A5 RID: 274597 RVA: 0x0113758C File Offset: 0x0113578C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem))
			};
		}

		// Token: 0x060430A6 RID: 274598 RVA: 0x01137628 File Offset: 0x01135828
		protected override void OnSetData()
		{
			this.Data = (this.ActivityBaseData as CoopActivityData);
		}

		// Token: 0x060430A7 RID: 274599 RVA: 0x0113763C File Offset: 0x0113583C
		protected override UniTask OnBeforeStartAsync()
		{
			CoopActivityView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<CoopActivityView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060430A8 RID: 274600 RVA: 0x01137680 File Offset: 0x01135880
		protected override void OnBeforeShow()
		{
			ActivitySubViewGeneralInfo generalInfo = this.GeneralInfo;
			if (generalInfo != null)
			{
				generalInfo.SetBtnText("Coop_Role_Tracking_Task", Array.Empty<object>());
			}
			ActivitySubViewGeneralInfo generalInfo2 = this.GeneralInfo;
			if (generalInfo2 != null)
			{
				generalInfo2.SetFunctionRedDotVisible(this.Data.IsAnyRoleHasRedDot() || this.Data.IsHasCoopSpRewardRedDot());
			}
			this.RefreshRewardButton();
		}

		// Token: 0x060430A9 RID: 274601 RVA: 0x011376DA File Offset: 0x011358DA
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshCommonActivityRedDot));
		}

		// Token: 0x060430AA RID: 274602 RVA: 0x011376F8 File Offset: 0x011358F8
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshCommonActivityRedDot));
		}

		// Token: 0x060430AB RID: 274603 RVA: 0x01137718 File Offset: 0x01135918
		private void RefreshRewardButton()
		{
			int claimedRewardCount = this.Data.GetClaimedRewardCount();
			CoopRewardButton rewardButton = this.RewardButton;
			if (rewardButton != null)
			{
				rewardButton.RefreshRewardCount(claimedRewardCount);
			}
			CoopRewardButton rewardButton2 = this.RewardButton;
			if (rewardButton2 == null)
			{
				return;
			}
			rewardButton2.SetRedDotShow(this.Data.IsHasCoopSpRewardRedDot());
		}

		// Token: 0x060430AC RID: 274604 RVA: 0x01137760 File Offset: 0x01135960
		private void OnRefreshCommonActivityRedDot(int id)
		{
			CoopActivityData data = this.Data;
			int? num = (data != null) ? new int?(data.Id) : null;
			if (!(id == num.GetValueOrDefault() & num != null))
			{
				return;
			}
			ActivitySubViewGeneralInfo generalInfo = this.GeneralInfo;
			if (generalInfo != null)
			{
				generalInfo.SetFunctionRedDotVisible(this.Data.IsAnyRoleHasRedDot() || this.Data.IsHasCoopSpRewardRedDot());
			}
			this.RefreshRewardButton();
		}

		// Token: 0x060430AD RID: 274605 RVA: 0x011377D4 File Offset: 0x011359D4
		private void OnBtnClick(ActivityBaseData _)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.CoopEntranceView, this.Data, null);
		}

		// Token: 0x060430AE RID: 274606 RVA: 0x011377EC File Offset: 0x011359EC
		private void OnClickRewardBtn()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.CoopSpRewardView, this.Data, null);
		}

		// Token: 0x04025554 RID: 152916
		protected CoopActivityData Data;

		// Token: 0x04025555 RID: 152917
		protected ActivitySubViewGeneralInfo GeneralInfo;

		// Token: 0x04025556 RID: 152918
		private CoopRewardButton RewardButton;
	}
}
