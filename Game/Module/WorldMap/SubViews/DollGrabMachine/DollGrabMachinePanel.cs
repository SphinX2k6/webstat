using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.LevelGamePlay.DollGrabMachine;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.WorldMap.SubViews.WorldMapSecondaryUiLayout;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.WorldMap.SubViews.DollGrabMachine
{
	// Token: 0x02004BC2 RID: 19394
	[NullableContext(1)]
	[Nullable(0)]
	public class DollGrabMachinePanel : WorldMapSecondaryUiLayoutA
	{
		// Token: 0x060329F7 RID: 207351 RVA: 0x00CAE15F File Offset: 0x00CAC35F
		public override string GetResourceId()
		{
			return "UiItem_GeneralPanel_Prefab";
		}

		// Token: 0x060329F8 RID: 207352 RVA: 0x00CAE168 File Offset: 0x00CAC368
		protected override UniTask OnBeforeStartAsync()
		{
			DollGrabMachinePanel.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<DollGrabMachinePanel.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060329F9 RID: 207353 RVA: 0x00CAE1AC File Offset: 0x00CAC3AC
		private UniTask InitRewardItemBar()
		{
			DollGrabMachinePanel.<InitRewardItemBar>d__4 <InitRewardItemBar>d__;
			<InitRewardItemBar>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitRewardItemBar>d__.<>4__this = this;
			<InitRewardItemBar>d__.<>1__state = -1;
			<InitRewardItemBar>d__.<>t__builder.Start<DollGrabMachinePanel.<InitRewardItemBar>d__4>(ref <InitRewardItemBar>d__);
			return <InitRewardItemBar>d__.<>t__builder.Task;
		}

		// Token: 0x060329FA RID: 207354 RVA: 0x00CAE1F0 File Offset: 0x00CAC3F0
		private UniTask CreateDollGrabMachineScore()
		{
			DollGrabMachinePanel.<CreateDollGrabMachineScore>d__5 <CreateDollGrabMachineScore>d__;
			<CreateDollGrabMachineScore>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateDollGrabMachineScore>d__.<>4__this = this;
			<CreateDollGrabMachineScore>d__.<>1__state = -1;
			<CreateDollGrabMachineScore>d__.<>t__builder.Start<DollGrabMachinePanel.<CreateDollGrabMachineScore>d__5>(ref <CreateDollGrabMachineScore>d__);
			return <CreateDollGrabMachineScore>d__.<>t__builder.Task;
		}

		// Token: 0x060329FB RID: 207355 RVA: 0x00CAE234 File Offset: 0x00CAC434
		private void RefreshScore()
		{
			DollGrabMachineMarkItem dollGrabMachineMarkItem = this.LayoutContext.MarkItem as DollGrabMachineMarkItem;
			if (dollGrabMachineMarkItem == null)
			{
				return;
			}
			int entityId = dollGrabMachineMarkItem.GetEntityId();
			bool flag = ModelBase<DollGrabModel>.Instance.IsDollGrabMachineDeliveryComplete(dollGrabMachineMarkItem.MapId, entityId);
			int dollGrabMachineDeliveryScore = ModelBase<DollGrabModel>.Instance.GetDollGrabMachineDeliveryScore(dollGrabMachineMarkItem.MapId, entityId);
			InstanceDungeonCostTip scoreItem = this.ScoreItem;
			if (scoreItem != null)
			{
				scoreItem.SetLeftTextNew("KClaw_EndlessReward_Desc", new object[]
				{
					dollGrabMachineDeliveryScore
				});
			}
			string resourceId = flag ? "SP_ComChoose" : "SP_LockRing";
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
			InstanceDungeonCostTip scoreItem2 = this.ScoreItem;
			if (scoreItem2 != null)
			{
				scoreItem2.SetSprStarByPath(resourcePath);
			}
			InstanceDungeonCostTip scoreItem3 = this.ScoreItem;
			if (scoreItem3 != null)
			{
				scoreItem3.SetSprStarChangeColor(flag);
			}
			InstanceDungeonCostTip scoreItem4 = this.ScoreItem;
			if (scoreItem4 != null)
			{
				scoreItem4.SetRightText("");
			}
			InstanceDungeonCostTip scoreItem5 = this.ScoreItem;
			if (scoreItem5 != null)
			{
				scoreItem5.SetHelpButtonVisible(false);
			}
			InstanceDungeonCostTip scoreItem6 = this.ScoreItem;
			if (scoreItem6 == null)
			{
				return;
			}
			scoreItem6.SetIconVisible(false);
		}

		// Token: 0x060329FC RID: 207356 RVA: 0x00CAE324 File Offset: 0x00CAC524
		private void RefreshReward()
		{
			DollGrabMachineMarkItem dollGrabMachineMarkItem = this.LayoutContext.MarkItem as DollGrabMachineMarkItem;
			if (dollGrabMachineMarkItem == null)
			{
				return;
			}
			int entityId = dollGrabMachineMarkItem.GetEntityId();
			CommonLevelPlayPanelRewardData dollGrabMachineReward = ModelBase<DollGrabModel>.Instance.GetDollGrabMachineReward(dollGrabMachineMarkItem.MapId, entityId);
			base.GetItem(8).SetUIActive(true);
			this.RewardsView.RebuildRewardsByLevelRewardData(dollGrabMachineReward);
		}

		// Token: 0x060329FD RID: 207357 RVA: 0x00CAE378 File Offset: 0x00CAC578
		protected override void OnShowWorldMapSecondaryUi(params object[] param)
		{
			if (param.Length != 0)
			{
				DollGrabMachineMarkItem dollGrabMachineMarkItem = param[0] as DollGrabMachineMarkItem;
				if (dollGrabMachineMarkItem != null)
				{
					this.LayoutContext.MarkItem = dollGrabMachineMarkItem;
					this.RefreshReward();
					this.RefreshScore();
					this.UpdateEnableFastMoveLayout();
					WorldMapSecondaryUiLayoutHelper.UpdateConfirmButtonTextWithFastMoveStyle(this.LayoutContext);
					WorldMapSecondaryUiLayoutHelper.UpdateTrackButtonTextWithTrackStyle(this.LayoutContext);
					WorldMapSecondaryUiLayoutHelper.UpdateIconAndTitle(this.LayoutContext);
					WorldMapSecondaryUiLayoutHelper.UpdateDesc(this.LayoutContext);
					WorldMapSecondaryUiLayoutHelper.UpdateAreaTxtByConfigMarkItem(this.LayoutContext);
					return;
				}
			}
		}

		// Token: 0x0401D7F0 RID: 120816
		[Nullable(2)]
		private InstanceDungeonCostTip ScoreItem;

		// Token: 0x0401D7F1 RID: 120817
		[Nullable(2)]
		private RewardItemBar RewardsView;
	}
}
