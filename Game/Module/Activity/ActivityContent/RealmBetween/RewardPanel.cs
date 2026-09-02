using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RealmBetween
{
	// Token: 0x02006553 RID: 25939
	[NullableContext(1)]
	[Nullable(0)]
	public class RewardPanel : UiPanelBase
	{
		// Token: 0x06040D16 RID: 265494 RVA: 0x0109F140 File Offset: 0x0109D340
		public RewardPanel(ActivityRealmBetweenData activityBaseData)
		{
			this.ActivityBaseData = activityBaseData;
		}

		// Token: 0x06040D17 RID: 265495 RVA: 0x0109F150 File Offset: 0x0109D350
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUISprite)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIText))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(1, new Action(this.OnClickedButton))
			};
		}

		// Token: 0x06040D18 RID: 265496 RVA: 0x0109F210 File Offset: 0x0109D410
		protected override UniTask OnBeforeStartAsync()
		{
			RewardPanel.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RewardPanel.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040D19 RID: 265497 RVA: 0x0109F253 File Offset: 0x0109D453
		protected override void OnBeforeShow()
		{
			this.Refresh();
		}

		// Token: 0x06040D1A RID: 265498 RVA: 0x0109F25C File Offset: 0x0109D45C
		public void Refresh()
		{
			RealmBetweenConfig activityConfig = this.ActivityBaseData.GetActivityConfig();
			FinalTravelTaskData taskFinalRewardData = this.ActivityBaseData.TaskFinalRewardData;
			TItem item = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(activityConfig.FinalRewardId)[0];
			bool flag = taskFinalRewardData.Current == taskFinalRewardData.Target;
			bool isReceived = taskFinalRewardData.IsReceived;
			base.GetSprite(3).SetFillAmount((float)taskFinalRewardData.Current / (float)taskFinalRewardData.Target);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), "MapTravelAllTaskProgress_Text", new <>z__ReadOnlyArray<object>(new object[]
			{
				taskFinalRewardData.Current,
				taskFinalRewardData.Target
			}));
			base.GetButton(1).RootUIComp.Get().SetUIActive(flag && !isReceived);
			base.GetItem(4).SetUIActive(!flag);
			base.GetItem(2).SetUIActive(isReceived);
			ItemGridData data = new ItemGridData
			{
				Item = item,
				HasClaimed = isReceived
			};
			this.RewardItemGrid.Refresh(data);
		}

		// Token: 0x06040D1B RID: 265499 RVA: 0x0109F36E File Offset: 0x0109D56E
		private void OnClickedButton()
		{
			ControllerBase<ActivityRealmBetweenController>.Instance.RequestTakeTaskFinalReward();
		}

		// Token: 0x040245E8 RID: 148968
		[Nullable(2)]
		private ActivitySmallItemGrid RewardItemGrid;

		// Token: 0x040245E9 RID: 148969
		protected ActivityRealmBetweenData ActivityBaseData;
	}
}
