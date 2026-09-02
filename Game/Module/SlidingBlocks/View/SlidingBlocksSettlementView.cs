using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Extension;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.SlidingBlocks.View
{
	// Token: 0x02004F15 RID: 20245
	[NullableContext(1)]
	[Nullable(0)]
	public class SlidingBlocksSettlementView : UiViewBase
	{
		// Token: 0x06034513 RID: 214291 RVA: 0x00D174FA File Offset: 0x00D156FA
		public SlidingBlocksSettlementView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06034514 RID: 214292 RVA: 0x00D17510 File Offset: 0x00D15710
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUITexture)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(18, typeof(UUIItem)),
				new ValueTuple<int, Type>(19, typeof(UUIText)),
				new ValueTuple<int, Type>(20, typeof(UUIItem)),
				new ValueTuple<int, Type>(21, typeof(UUIVerticalLayout)),
				new ValueTuple<int, Type>(22, typeof(UUIItem)),
				new ValueTuple<int, Type>(23, typeof(UUIItem))
			};
		}

		// Token: 0x06034515 RID: 214293 RVA: 0x00D1764C File Offset: 0x00D1584C
		protected override UniTask OnBeforeStartAsync()
		{
			SlidingBlocksSettlementView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SlidingBlocksSettlementView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06034516 RID: 214294 RVA: 0x00D17690 File Offset: 0x00D15890
		private UniTask NewCubeResult(int historyScore, List<TItem> rewardList)
		{
			SlidingBlocksSettlementView.<NewCubeResult>d__7 <NewCubeResult>d__;
			<NewCubeResult>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewCubeResult>d__.<>4__this = this;
			<NewCubeResult>d__.historyScore = historyScore;
			<NewCubeResult>d__.rewardList = rewardList;
			<NewCubeResult>d__.<>1__state = -1;
			<NewCubeResult>d__.<>t__builder.Start<SlidingBlocksSettlementView.<NewCubeResult>d__7>(ref <NewCubeResult>d__);
			return <NewCubeResult>d__.<>t__builder.Task;
		}

		// Token: 0x06034517 RID: 214295 RVA: 0x00D176E4 File Offset: 0x00D158E4
		private void InitButtons(int instanceId)
		{
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
			List<IRewardExploreConfirmButton> list = new List<IRewardExploreConfirmButton>();
			RewardExploreConfirmButtonData rewardExploreConfirmButtonData = new RewardExploreConfirmButtonData();
			rewardExploreConfirmButtonData.ButtonTextId = "Text_ButtonTextExit_Text";
			rewardExploreConfirmButtonData.DescriptionTextId = "GenericPromptTypes_2_GeneralText";
			rewardExploreConfirmButtonData.DescriptionArgs = null;
			rewardExploreConfirmButtonData.TimeDown = new int?(config.Value.AutoLeaveTime * Singleton<TimeUtil>.Instance.InverseMillisecond);
			rewardExploreConfirmButtonData.IsTimeDownCloseView = true;
			rewardExploreConfirmButtonData.OnTimeDownOnCallback = delegate()
			{
				ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeon().Forget<bool>();
			};
			rewardExploreConfirmButtonData.IsClickedCloseView = false;
			rewardExploreConfirmButtonData.OnClickedCallback = delegate(int index)
			{
				ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeon().Finally(delegate()
				{
					base.CloseMe(null);
				});
			};
			RewardExploreConfirmButtonData item = rewardExploreConfirmButtonData;
			list.Add(item);
			RewardExploreConfirmButtonData item2 = new RewardExploreConfirmButtonData
			{
				ButtonTextId = "Text_ChallengeAgain_Text",
				DescriptionTextId = null,
				DescriptionArgs = null,
				IsTimeDownCloseView = false,
				IsClickedCloseView = false,
				OnClickedCallback = delegate(int index)
				{
					ControllerBase<InstanceDungeonEntranceController>.Instance.RestartInstanceDungeon().Finally(delegate()
					{
						base.CloseMe(null);
					});
				}
			};
			list.Add(item2);
			if (list != null && list != null && list.Count > 0)
			{
				int num = 0;
				foreach (IRewardExploreConfirmButton buttonData in list)
				{
					this.NewButton(buttonData, num);
					num++;
				}
			}
		}

		// Token: 0x06034518 RID: 214296 RVA: 0x00D17840 File Offset: 0x00D15A40
		private RewardExploreConfirmButton NewButton(IRewardExploreConfirmButton buttonData, int buttonIndex)
		{
			UUIItem item = base.GetItem(5);
			UUIItem item2 = base.GetItem(4);
			RewardExploreConfirmButton rewardExploreConfirmButton = new RewardExploreConfirmButton(Singleton<LguiUtil>.Instance.DuplicateActor(item.GetOwner(), item2), buttonIndex);
			rewardExploreConfirmButton.Refresh(buttonData);
			rewardExploreConfirmButton.SetActive(true);
			this.ButtonList.Add(rewardExploreConfirmButton);
			return rewardExploreConfirmButton;
		}

		// Token: 0x06034519 RID: 214297 RVA: 0x00D17890 File Offset: 0x00D15A90
		protected override void OnAfterShow()
		{
		}

		// Token: 0x0603451A RID: 214298 RVA: 0x00D17894 File Offset: 0x00D15A94
		protected override void OnAfterPlayStartSequence()
		{
			this.UiViewSequence.PlaySequence(this.IsSuccess ? "Success" : "Fail", true, null);
		}

		// Token: 0x0603451B RID: 214299 RVA: 0x00D178CA File Offset: 0x00D15ACA
		protected override void OnBeforeDestroy()
		{
		}

		// Token: 0x0401E2DB RID: 123611
		[Nullable(2)]
		private CubeResultItem CubeResultItem;

		// Token: 0x0401E2DC RID: 123612
		private readonly List<RewardExploreConfirmButton> ButtonList = new List<RewardExploreConfirmButton>();

		// Token: 0x0401E2DD RID: 123613
		private bool IsSuccess;

		// Token: 0x0200AF49 RID: 44873
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403664C RID: 222796
			TitleItem,
			// Token: 0x0403664D RID: 222797
			TitleText,
			// Token: 0x0403664E RID: 222798
			TitleTexture,
			// Token: 0x0403664F RID: 222799
			ContentItem,
			// Token: 0x04036650 RID: 222800
			ButtonHorizontalItem,
			// Token: 0x04036651 RID: 222801
			ButtonItem,
			// Token: 0x04036652 RID: 222802
			ToggleItem,
			// Token: 0x04036653 RID: 222803
			DoubleTip = 18,
			// Token: 0x04036654 RID: 222804
			DoubleTipTxt,
			// Token: 0x04036655 RID: 222805
			Content,
			// Token: 0x04036656 RID: 222806
			FriendItem,
			// Token: 0x04036657 RID: 222807
			FriendGrid,
			// Token: 0x04036658 RID: 222808
			ItemTeam
		}
	}
}
