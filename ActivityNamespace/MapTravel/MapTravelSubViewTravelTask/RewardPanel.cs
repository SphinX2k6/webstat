using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace ActivityNamespace.MapTravel.MapTravelSubViewTravelTask
{
	// Token: 0x020043C8 RID: 17352
	internal class RewardPanel : UiPanelBase
	{
		// Token: 0x0602E205 RID: 188933 RVA: 0x00AD85DA File Offset: 0x00AD67DA
		[NullableContext(1)]
		public RewardPanel(ActivityMapTravelData ActivityBaseData)
		{
			this.ActivityBaseData = ActivityBaseData;
		}

		// Token: 0x0602E206 RID: 188934 RVA: 0x00AD85EC File Offset: 0x00AD67EC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickedButton));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0602E207 RID: 188935 RVA: 0x00AD8718 File Offset: 0x00AD6918
		protected override UniTask OnBeforeStartAsync()
		{
			RewardPanel.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RewardPanel.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0602E208 RID: 188936 RVA: 0x00AD875B File Offset: 0x00AD695B
		protected override void OnBeforeShow()
		{
			this.Refresh();
		}

		// Token: 0x0602E209 RID: 188937 RVA: 0x00AD8764 File Offset: 0x00AD6964
		public void Refresh()
		{
			MapTravelConfig activityConfig = this.ActivityBaseData.GetActivityConfig();
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

		// Token: 0x0602E20A RID: 188938 RVA: 0x00AD8876 File Offset: 0x00AD6A76
		private void OnClickedButton()
		{
			ControllerBase<ActivityMapTravelController>.Instance.RequestTakeTaskFinalReward();
		}

		// Token: 0x0401A17D RID: 106877
		[Nullable(1)]
		private ActivityMapTravelData ActivityBaseData;

		// Token: 0x0401A17E RID: 106878
		[Nullable(2)]
		private ActivitySmallItemGrid RewardItemGrid;

		// Token: 0x0200A638 RID: 42552
		private class EPanelReward
		{
			// Token: 0x04033660 RID: 210528
			public const int RewardGrid = 0;

			// Token: 0x04033661 RID: 210529
			public const int ButtonReward = 1;

			// Token: 0x04033662 RID: 210530
			public const int ItemDone = 2;

			// Token: 0x04033663 RID: 210531
			public const int ProgressBar = 3;

			// Token: 0x04033664 RID: 210532
			public const int ItemGoing = 4;

			// Token: 0x04033665 RID: 210533
			public const int TxtProgress = 5;
		}
	}
}
