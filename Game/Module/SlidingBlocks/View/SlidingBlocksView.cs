using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Input;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.BattleUi.Views;
using CSharpScript.Game.Module.SlidingBlocks.View.Control;
using CSharpScript.Game.Module.SlidingBlocks.View.Mission;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.SlidingBlocks.View
{
	// Token: 0x02004F16 RID: 20246
	[NullableContext(2)]
	[Nullable(0)]
	public class SlidingBlocksView : UiTickViewBase, IUiProhibitRefreshData
	{
		// Token: 0x06034521 RID: 214305 RVA: 0x00D17922 File Offset: 0x00D15B22
		[NullableContext(1)]
		public SlidingBlocksView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06034522 RID: 214306 RVA: 0x00D1792C File Offset: 0x00D15B2C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 13;
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
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06034523 RID: 214307 RVA: 0x00D17B08 File Offset: 0x00D15D08
		protected override UniTask OnBeforeStartAsync()
		{
			SlidingBlocksView.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SlidingBlocksView.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06034524 RID: 214308 RVA: 0x00D17B4C File Offset: 0x00D15D4C
		private UniTask InitControlItem()
		{
			SlidingBlocksView.<InitControlItem>d__13 <InitControlItem>d__;
			<InitControlItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitControlItem>d__.<>4__this = this;
			<InitControlItem>d__.<>1__state = -1;
			<InitControlItem>d__.<>t__builder.Start<SlidingBlocksView.<InitControlItem>d__13>(ref <InitControlItem>d__);
			return <InitControlItem>d__.<>t__builder.Task;
		}

		// Token: 0x06034525 RID: 214309 RVA: 0x00D17B90 File Offset: 0x00D15D90
		private UniTask InitPrepareCountDownItem()
		{
			SlidingBlocksView.<InitPrepareCountDownItem>d__14 <InitPrepareCountDownItem>d__;
			<InitPrepareCountDownItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitPrepareCountDownItem>d__.<>4__this = this;
			<InitPrepareCountDownItem>d__.<>1__state = -1;
			<InitPrepareCountDownItem>d__.<>t__builder.Start<SlidingBlocksView.<InitPrepareCountDownItem>d__14>(ref <InitPrepareCountDownItem>d__);
			return <InitPrepareCountDownItem>d__.<>t__builder.Task;
		}

		// Token: 0x06034526 RID: 214310 RVA: 0x00D17BD4 File Offset: 0x00D15DD4
		private UniTask InitMissionItem()
		{
			SlidingBlocksView.<InitMissionItem>d__15 <InitMissionItem>d__;
			<InitMissionItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitMissionItem>d__.<>4__this = this;
			<InitMissionItem>d__.<>1__state = -1;
			<InitMissionItem>d__.<>t__builder.Start<SlidingBlocksView.<InitMissionItem>d__15>(ref <InitMissionItem>d__);
			return <InitMissionItem>d__.<>t__builder.Task;
		}

		// Token: 0x06034527 RID: 214311 RVA: 0x00D17C18 File Offset: 0x00D15E18
		private UniTask InitNextTetrominoItem()
		{
			SlidingBlocksView.<InitNextTetrominoItem>d__16 <InitNextTetrominoItem>d__;
			<InitNextTetrominoItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitNextTetrominoItem>d__.<>4__this = this;
			<InitNextTetrominoItem>d__.<>1__state = -1;
			<InitNextTetrominoItem>d__.<>t__builder.Start<SlidingBlocksView.<InitNextTetrominoItem>d__16>(ref <InitNextTetrominoItem>d__);
			return <InitNextTetrominoItem>d__.<>t__builder.Task;
		}

		// Token: 0x06034528 RID: 214312 RVA: 0x00D17C5C File Offset: 0x00D15E5C
		private UniTask InitCaptionItem()
		{
			SlidingBlocksView.<InitCaptionItem>d__17 <InitCaptionItem>d__;
			<InitCaptionItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitCaptionItem>d__.<>4__this = this;
			<InitCaptionItem>d__.<>1__state = -1;
			<InitCaptionItem>d__.<>t__builder.Start<SlidingBlocksView.<InitCaptionItem>d__17>(ref <InitCaptionItem>d__);
			return <InitCaptionItem>d__.<>t__builder.Task;
		}

		// Token: 0x06034529 RID: 214313 RVA: 0x00D17CA0 File Offset: 0x00D15EA0
		private UniTask InitEndlessSpeedUpTips()
		{
			SlidingBlocksView.<InitEndlessSpeedUpTips>d__18 <InitEndlessSpeedUpTips>d__;
			<InitEndlessSpeedUpTips>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitEndlessSpeedUpTips>d__.<>4__this = this;
			<InitEndlessSpeedUpTips>d__.<>1__state = -1;
			<InitEndlessSpeedUpTips>d__.<>t__builder.Start<SlidingBlocksView.<InitEndlessSpeedUpTips>d__18>(ref <InitEndlessSpeedUpTips>d__);
			return <InitEndlessSpeedUpTips>d__.<>t__builder.Task;
		}

		// Token: 0x0603452A RID: 214314 RVA: 0x00D17CE3 File Offset: 0x00D15EE3
		protected override void OnStart()
		{
			this.RegisterExtraUiProhibitRefresh();
			this.EnableInput(false);
		}

		// Token: 0x0603452B RID: 214315 RVA: 0x00D17CF4 File Offset: 0x00D15EF4
		protected override void OnAfterShow()
		{
			ControlItem controlItem = this.ControlItem;
			if (controlItem != null)
			{
				controlItem.Show(null);
			}
			NextTetrominoItem nextTetrominoItem = this.NextTetrominoItem;
			if (nextTetrominoItem != null)
			{
				nextTetrominoItem.Show(null);
			}
			MissionItem missionItem = this.MissionItem;
			if (missionItem != null)
			{
				missionItem.Show(null);
			}
			CaptionItem captionItem = this.CaptionItem;
			if (captionItem != null)
			{
				captionItem.Show(null);
			}
			if (ModelBase<SlidingBlocksModel>.Instance.GameData.PlayMode != ETetrisPlayMode.MainLine)
			{
				ModelBase<BattleUiModel>.Instance.ChildViewData.AddBattleUiCommonChildVisibleReason(EBattleUiCommonChildVisibleReason.SurvivorsRogue);
				Singleton<EventSystem>.Instance.Emit(EEventName.ActiveBattleView);
			}
			if (this.MissionViewItems != null)
			{
				foreach (MissionViewItem missionViewItem in this.MissionViewItems)
				{
					missionViewItem.OnPanelShow();
				}
			}
		}

		// Token: 0x0603452C RID: 214316 RVA: 0x00D17DC8 File Offset: 0x00D15FC8
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.SlidingBlockEndlessSpeedLevel, new Action(this.OnEndlessSpeedUp));
		}

		// Token: 0x0603452D RID: 214317 RVA: 0x00D17DE6 File Offset: 0x00D15FE6
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.SlidingBlockEndlessSpeedLevel, new Action(this.OnEndlessSpeedUp));
		}

		// Token: 0x0603452E RID: 214318 RVA: 0x00D17E04 File Offset: 0x00D16004
		protected override void OnAfterHide()
		{
			if (ModelBase<SlidingBlocksModel>.Instance.GameData.PlayMode != ETetrisPlayMode.MainLine)
			{
				ModelBase<BattleUiModel>.Instance.ChildViewData.RemoveBattleUiCommonChildVisibleReason(EBattleUiCommonChildVisibleReason.SurvivorsRogue);
			}
			if (this.MissionViewItems != null)
			{
				foreach (MissionViewItem missionViewItem in this.MissionViewItems)
				{
					missionViewItem.OnPanelHide();
				}
			}
		}

		// Token: 0x0603452F RID: 214319 RVA: 0x00D17E80 File Offset: 0x00D16080
		protected override void OnBeforeDestroy()
		{
			this.EnableInput(true);
			this.UnRegisterExtraUiProhibitRefresh();
			ControlItem controlItem = this.ControlItem;
			if (controlItem != null)
			{
				controlItem.Destroy(null);
			}
			PrepareCountDownItem prepareCountDownItem = this.PrepareCountDownItem;
			if (prepareCountDownItem != null)
			{
				prepareCountDownItem.Destroy(null);
			}
			NextTetrominoItem nextTetrominoItem = this.NextTetrominoItem;
			if (nextTetrominoItem != null)
			{
				nextTetrominoItem.Destroy(null);
			}
			MissionItem missionItem = this.MissionItem;
			if (missionItem != null)
			{
				missionItem.Destroy(null);
			}
			CaptionItem captionItem = this.CaptionItem;
			if (captionItem != null)
			{
				captionItem.Destroy(null);
			}
			if (this.MissionViewItems != null)
			{
				foreach (MissionViewItem missionViewItem in this.MissionViewItems)
				{
					missionViewItem.Destroy(null);
				}
			}
		}

		// Token: 0x06034530 RID: 214320 RVA: 0x00D17F40 File Offset: 0x00D16140
		protected override void OnTick(float delta)
		{
			this.UpdateGameTime();
			ControlItem controlItem = this.ControlItem;
			if (controlItem != null)
			{
				controlItem.OnTick(delta);
			}
			PrepareCountDownItem prepareCountDownItem = this.PrepareCountDownItem;
			if (prepareCountDownItem != null)
			{
				prepareCountDownItem.OnTick(delta);
			}
			NextTetrominoItem nextTetrominoItem = this.NextTetrominoItem;
			if (nextTetrominoItem != null)
			{
				nextTetrominoItem.OnTick(delta);
			}
			MissionItem missionItem = this.MissionItem;
			if (missionItem != null)
			{
				missionItem.OnTick(delta);
			}
			if (this.MissionViewItems != null)
			{
				foreach (MissionViewItem missionViewItem in this.MissionViewItems)
				{
					missionViewItem.OnRefresh(delta, 0);
				}
			}
			SlidingBlocksGameData gameData = ModelBase<SlidingBlocksModel>.Instance.GameData;
			base.GetText(9).SetText(gameData.SpeedLevel.ToString(), true);
			base.GetText(7).SetText(gameData.Score.ToString(), true);
		}

		// Token: 0x06034531 RID: 214321 RVA: 0x00D18024 File Offset: 0x00D16224
		private void UpdateGameTime()
		{
			UUIText text = base.GetText(5);
			if (!text.IsUIActiveInHierarchy())
			{
				return;
			}
			double time = ModelBase<SlidingBlocksModel>.Instance.GameData.Time;
			int num = (int)Math.Floor(time % Singleton<TimeUtil>.Instance.Hour / Singleton<TimeUtil>.Instance.Minute);
			int num2 = (int)Math.Floor(time % Singleton<TimeUtil>.Instance.Minute);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 2);
			defaultInterpolatedStringHandler.AppendFormatted((num < 10) ? "0" : "");
			defaultInterpolatedStringHandler.AppendFormatted<int>(num);
			string str = defaultInterpolatedStringHandler.ToStringAndClear();
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 2);
			defaultInterpolatedStringHandler.AppendFormatted((num2 < 10) ? "0" : "");
			defaultInterpolatedStringHandler.AppendFormatted<int>(num2);
			string str2 = defaultInterpolatedStringHandler.ToStringAndClear();
			text.SetText(str + ":" + str2, true);
		}

		// Token: 0x06034532 RID: 214322 RVA: 0x00D180F8 File Offset: 0x00D162F8
		public bool CheckCondition()
		{
			return true;
		}

		// Token: 0x06034533 RID: 214323 RVA: 0x00D180FB File Offset: 0x00D162FB
		[NullableContext(1)]
		public string[] GetDistributeTags()
		{
			return new string[]
			{
				"FightInputRoot.FightInput.ActionInput",
				"FightInputRoot.FightInput.AxisInput.MoveInput",
				"UiInputRoot"
			};
		}

		// Token: 0x06034534 RID: 214324 RVA: 0x00D1811B File Offset: 0x00D1631B
		private void RegisterExtraUiProhibitRefresh()
		{
			Singleton<UiProhibitFightInputCenter>.Instance.RegisterExtraRefreshData(this.ViewInfo.Name, this);
		}

		// Token: 0x06034535 RID: 214325 RVA: 0x00D18138 File Offset: 0x00D16338
		private void UnRegisterExtraUiProhibitRefresh()
		{
			Singleton<UiProhibitFightInputCenter>.Instance.UnRegisterExtraRefreshData(this.ViewInfo.Name);
		}

		// Token: 0x06034536 RID: 214326 RVA: 0x00D18154 File Offset: 0x00D16354
		private void EnableInput(bool enable)
		{
			int num = (int)EInputAction.MaxCount;
			for (int i = 0; i < num; i++)
			{
				if (i != (int)EInputAction.跳跃 && i != (int)EInputAction.攀爬 && i != (int)EInputAction.闪避)
				{
					ModelBase<BattleInputModel>.Instance.SetInputEnable((EInputAction)((byte)i), enable, EBattleInputReason.TetrisGame);
				}
			}
		}

		// Token: 0x06034537 RID: 214327 RVA: 0x00D181B2 File Offset: 0x00D163B2
		private void OnEndlessSpeedUp()
		{
			this.ShowSpeedUpAnim().Forget();
		}

		// Token: 0x06034538 RID: 214328 RVA: 0x00D181C0 File Offset: 0x00D163C0
		private UniTask ShowSpeedUpAnim()
		{
			SlidingBlocksView.<ShowSpeedUpAnim>d__33 <ShowSpeedUpAnim>d__;
			<ShowSpeedUpAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ShowSpeedUpAnim>d__.<>4__this = this;
			<ShowSpeedUpAnim>d__.<>1__state = -1;
			<ShowSpeedUpAnim>d__.<>t__builder.Start<SlidingBlocksView.<ShowSpeedUpAnim>d__33>(ref <ShowSpeedUpAnim>d__);
			return <ShowSpeedUpAnim>d__.<>t__builder.Task;
		}

		// Token: 0x0401E2DE RID: 123614
		private ControlItem ControlItem;

		// Token: 0x0401E2DF RID: 123615
		private PrepareCountDownItem PrepareCountDownItem;

		// Token: 0x0401E2E0 RID: 123616
		private NextTetrominoItem NextTetrominoItem;

		// Token: 0x0401E2E1 RID: 123617
		private CaptionItem CaptionItem;

		// Token: 0x0401E2E2 RID: 123618
		private MissionItem MissionItem;

		// Token: 0x0401E2E3 RID: 123619
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<MissionViewItem> MissionViewItems;

		// Token: 0x0401E2E4 RID: 123620
		private EndlessSpeedUpTips EndlessSpeedUpTips;

		// Token: 0x0401E2E5 RID: 123621
		private bool IsMobile;

		// Token: 0x0401E2E6 RID: 123622
		[Nullable(1)]
		private CustomPromise<UniTaskVoid> WaitLevelPlayTrackPromise;

		// Token: 0x0200AF4D RID: 44877
		[NullableContext(0)]
		private class EViewComponent
		{
			// Token: 0x04036666 RID: 222822
			public const int CaptionItem = 0;

			// Token: 0x04036667 RID: 222823
			public const int ContentItem = 1;

			// Token: 0x04036668 RID: 222824
			public const int MissionItem = 2;

			// Token: 0x04036669 RID: 222825
			public const int NextTetrominoItem = 3;

			// Token: 0x0403666A RID: 222826
			public const int TimeRootItem = 4;

			// Token: 0x0403666B RID: 222827
			public const int TimeText = 5;

			// Token: 0x0403666C RID: 222828
			public const int ScoreRootItem = 6;

			// Token: 0x0403666D RID: 222829
			public const int ScoreText = 7;

			// Token: 0x0403666E RID: 222830
			public const int SpeedRootItem = 8;

			// Token: 0x0403666F RID: 222831
			public const int SpeedText = 9;

			// Token: 0x04036670 RID: 222832
			public const int SpriteUp = 10;

			// Token: 0x04036671 RID: 222833
			public const int PanelTips = 11;

			// Token: 0x04036672 RID: 222834
			public const int BgTexture = 12;
		}
	}
}
