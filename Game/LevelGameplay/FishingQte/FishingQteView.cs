using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.Fishing;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.FishingQte
{
	// Token: 0x02006E97 RID: 28311
	[NullableContext(2)]
	[Nullable(0)]
	public class FishingQteView : UiTickViewBase
	{
		// Token: 0x06044A6B RID: 281195 RVA: 0x011D7EA1 File Offset: 0x011D60A1
		[NullableContext(1)]
		public FishingQteView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06044A6C RID: 281196 RVA: 0x011D7EAC File Offset: 0x011D60AC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 11;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06044A6D RID: 281197 RVA: 0x011D8044 File Offset: 0x011D6244
		protected override UniTask OnBeforeStartAsync()
		{
			FishingQteView.<OnBeforeStartAsync>d__21 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<FishingQteView.<OnBeforeStartAsync>d__21>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06044A6E RID: 281198 RVA: 0x011D8087 File Offset: 0x011D6287
		protected override void OnStart()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnFishingQteStageUpdate, new Action<EFishingQteStage>(this.OnGameStageUpdate));
			Singleton<EventSystem>.Instance.Add(EEventName.OnFishingQteAreaChange, new Action<int>(this.OnFishingQteAreaChange));
			this.Init();
		}

		// Token: 0x06044A6F RID: 281199 RVA: 0x011D80C8 File Offset: 0x011D62C8
		private void Init()
		{
			this.GameInfo.SetGameStage(EFishingQteStage.Ready);
			this.TagItem.Refresh(ModelBase<FishingQteModel>.Instance.CurrentFishingPointConfigId);
			this.RefreshFishingPointCount();
			this.RingItem.InitRing();
			this.GameInfo.GetRingInfo().EnterNextValidArea();
			this.ButtonItem.SetPauseWithoutAnim(false);
			this.FishIconLayout.RefreshByData(new List<int>(Enumerable.Repeat<int>(0, this.GameInfo.MaxRound)), null, false);
			this.UiViewSequence.AddSequenceFinishEvent("Start", delegate(string _)
			{
				this.SetGameStart();
			}, false);
		}

		// Token: 0x06044A70 RID: 281200 RVA: 0x011D8163 File Offset: 0x011D6363
		protected override void OnBeforeShow()
		{
			this.CabinItem.RefreshCabin();
		}

		// Token: 0x06044A71 RID: 281201 RVA: 0x011D8170 File Offset: 0x011D6370
		protected override void OnAfterShow()
		{
		}

		// Token: 0x06044A72 RID: 281202 RVA: 0x011D8174 File Offset: 0x011D6374
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnFishingQteStageUpdate, new Action<EFishingQteStage>(this.OnGameStageUpdate));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnFishingQteAreaChange, new Action<int>(this.OnFishingQteAreaChange));
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.Clear();
			}
			this.LevelSequencePlayer = null;
		}

		// Token: 0x06044A73 RID: 281203 RVA: 0x011D81D1 File Offset: 0x011D63D1
		protected override void OnAfterDestroy()
		{
			Action finishCallback = this.FinishCallback;
			if (finishCallback == null)
			{
				return;
			}
			finishCallback();
		}

		// Token: 0x06044A74 RID: 281204 RVA: 0x011D81E4 File Offset: 0x011D63E4
		protected override void OnTick(float delta)
		{
			FishingProgressItem progressItem = this.ProgressItem;
			if (progressItem != null)
			{
				progressItem.OnTick(delta);
			}
			FishingQteRingItem ringItem = this.RingItem;
			if (ringItem != null)
			{
				ringItem.OnTick(delta);
			}
			FishingButtonItem buttonItem = this.ButtonItem;
			if (buttonItem != null)
			{
				buttonItem.OnTick(delta);
			}
			FishingGetScrollItem getScrollItem = this.GetScrollItem;
			if (getScrollItem != null)
			{
				getScrollItem.OnTick(delta);
			}
			if (this.GameInfo.IsGamePause())
			{
				return;
			}
			float num = delta / 1000f;
			this.GameInfo.CurrentScore += ModelBase<FishingQteModel>.Instance.ScoreUp * num;
			if (this.GameInfo.CurrentScore >= (float)this.GameConfig.MaxScore)
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.OnFishingQteScoreReachedMaximum);
				this.EnterNextRound();
			}
		}

		// Token: 0x06044A75 RID: 281205 RVA: 0x011D829C File Offset: 0x011D649C
		private void EnterNextRound()
		{
			ModelBase<FishingQteModel>.Instance.EnterNextRound();
			this.PlayAnim("FishSuccess");
			this.ProgressItem.EnterNextRound();
			this.RefreshFishingPointCount();
			long currentFishingPointCreatureDataId = ModelBase<FishingQteModel>.Instance.CurrentFishingPointCreatureDataId;
			ControllerBase<FishingQteController>.Instance.FishingGetRequest(currentFishingPointCreatureDataId, delegate(bool success, int? fishCount)
			{
				if (!success)
				{
					this.GameInfo.SetGameStage(EFishingQteStage.Pause);
					base.CloseMe(null);
					return;
				}
				if (this.GameInfo.CurrentRound == this.GameInfo.MaxRound)
				{
					this.SetGameEnd(fishCount.Value);
					return;
				}
				this.TipsTxt.ShowTip(EFishingTipsType.GetFish, fishCount.ToString(), null);
			});
		}

		// Token: 0x06044A76 RID: 281206 RVA: 0x011D82F4 File Offset: 0x011D64F4
		private UniTask InitTips()
		{
			FishingQteView.<InitTips>d__30 <InitTips>d__;
			<InitTips>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitTips>d__.<>4__this = this;
			<InitTips>d__.<>1__state = -1;
			<InitTips>d__.<>t__builder.Start<FishingQteView.<InitTips>d__30>(ref <InitTips>d__);
			return <InitTips>d__.<>t__builder.Task;
		}

		// Token: 0x06044A77 RID: 281207 RVA: 0x011D8338 File Offset: 0x011D6538
		private UniTask InitGetScrollView()
		{
			FishingQteView.<InitGetScrollView>d__31 <InitGetScrollView>d__;
			<InitGetScrollView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitGetScrollView>d__.<>4__this = this;
			<InitGetScrollView>d__.<>1__state = -1;
			<InitGetScrollView>d__.<>t__builder.Start<FishingQteView.<InitGetScrollView>d__31>(ref <InitGetScrollView>d__);
			return <InitGetScrollView>d__.<>t__builder.Task;
		}

		// Token: 0x06044A78 RID: 281208 RVA: 0x011D837C File Offset: 0x011D657C
		private UniTask InitRing()
		{
			FishingQteView.<InitRing>d__32 <InitRing>d__;
			<InitRing>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitRing>d__.<>4__this = this;
			<InitRing>d__.<>1__state = -1;
			<InitRing>d__.<>t__builder.Start<FishingQteView.<InitRing>d__32>(ref <InitRing>d__);
			return <InitRing>d__.<>t__builder.Task;
		}

		// Token: 0x06044A79 RID: 281209 RVA: 0x011D83C0 File Offset: 0x011D65C0
		private UniTask InitProgressItem()
		{
			FishingQteView.<InitProgressItem>d__33 <InitProgressItem>d__;
			<InitProgressItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitProgressItem>d__.<>4__this = this;
			<InitProgressItem>d__.<>1__state = -1;
			<InitProgressItem>d__.<>t__builder.Start<FishingQteView.<InitProgressItem>d__33>(ref <InitProgressItem>d__);
			return <InitProgressItem>d__.<>t__builder.Task;
		}

		// Token: 0x06044A7A RID: 281210 RVA: 0x011D8404 File Offset: 0x011D6604
		private UniTask InitFullTipItem()
		{
			FishingQteView.<InitFullTipItem>d__34 <InitFullTipItem>d__;
			<InitFullTipItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitFullTipItem>d__.<>4__this = this;
			<InitFullTipItem>d__.<>1__state = -1;
			<InitFullTipItem>d__.<>t__builder.Start<FishingQteView.<InitFullTipItem>d__34>(ref <InitFullTipItem>d__);
			return <InitFullTipItem>d__.<>t__builder.Task;
		}

		// Token: 0x06044A7B RID: 281211 RVA: 0x011D8447 File Offset: 0x011D6647
		[NullableContext(1)]
		private FishingRoundItem CreateFishIcon()
		{
			return new FishingRoundItem();
		}

		// Token: 0x06044A7C RID: 281212 RVA: 0x011D844E File Offset: 0x011D664E
		private void OnFishingQteAreaChange(int areaRelativeIndex)
		{
			this.RingItem.OnArrowStayAreaUpdate(areaRelativeIndex);
		}

		// Token: 0x06044A7D RID: 281213 RVA: 0x011D845C File Offset: 0x011D665C
		private void OnGameStageUpdate(EFishingQteStage currentGameStage)
		{
			switch (currentGameStage)
			{
			case EFishingQteStage.OnGoing:
			case EFishingQteStage.End:
			case EFishingQteStage.Success:
				break;
			case EFishingQteStage.Pause:
				this.ButtonItem.SetPause(true);
				return;
			case EFishingQteStage.AnimEnd:
			{
				List<DockyardItemBlockOriginalData> tempGetDataList = ModelBase<FishingQteModel>.Instance.GetTempGetDataList();
				ControllerBase<FishingQteController>.Instance.OpenFishingSuccessView(tempGetDataList, delegate(bool success)
				{
					if (success)
					{
						ModelBase<FishingQteModel>.Instance.GameInfo.SetGameStage(EFishingQteStage.Success);
						base.CloseMe(null);
					}
				});
				return;
			}
			case EFishingQteStage.Destroy:
				this.OnExit();
				break;
			default:
				return;
			}
		}

		// Token: 0x06044A7E RID: 281214 RVA: 0x011D84C0 File Offset: 0x011D66C0
		protected void OnExit()
		{
			base.CloseMe(null);
		}

		// Token: 0x06044A7F RID: 281215 RVA: 0x011D84C9 File Offset: 0x011D66C9
		private void OnClickCabin()
		{
			if (this.GameInfo.GetGameStage() == EFishingQteStage.OnGoing)
			{
				this.GameInfo.SetGameStage(EFishingQteStage.Pause);
			}
			ControllerBase<FishingController>.Instance.OpenDockyardWareHouseView(true);
		}

		// Token: 0x06044A80 RID: 281216 RVA: 0x011D84F0 File Offset: 0x011D66F0
		private void OnClickBack()
		{
			if (this.GameInfo.GetGameStage() == EFishingQteStage.OnGoing)
			{
				this.GameInfo.SetGameStage(EFishingQteStage.Pause);
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.FishingQtePauseView, null, null);
		}

		// Token: 0x06044A81 RID: 281217 RVA: 0x011D8520 File Offset: 0x011D6720
		private void OnClickFishButton()
		{
			if (this.GameInfo.IsGamePause() && !this.GameInfo.IsGameEnd())
			{
				this.SetGameGoing();
				return;
			}
			FishingQteRingInfo ringInfo = this.GameInfo.GetRingInfo();
			int currentArrowStayCellIndex = ringInfo.CurrentArrowStayCellIndex;
			ContinuousRingArea continuousRingArea = ringInfo.CheckInArea(ringInfo.GetPerfectAreas(), currentArrowStayCellIndex);
			if (continuousRingArea != null)
			{
				this.OnAreaClick(EFishingAreaType.PerfectArea, continuousRingArea);
				return;
			}
			ContinuousRingArea continuousRingArea2 = ringInfo.CheckInArea(ringInfo.GetQteAreas(), currentArrowStayCellIndex);
			if (continuousRingArea2 != null)
			{
				this.OnAreaClick(EFishingAreaType.QteArea, continuousRingArea2);
				return;
			}
			this.OnAreaClick(EFishingAreaType.BlankArea, null);
		}

		// Token: 0x06044A82 RID: 281218 RVA: 0x011D859D File Offset: 0x011D679D
		private void SetGameStart()
		{
			this.FullTipItem.SetTxtInfo("Fishing_QTE_Start", Array.Empty<object>());
			this.FullTipItem.PlayTipSequence(new Action(this.<SetGameStart>g__startAnimFlow|42_0), "Start", true);
		}

		// Token: 0x06044A83 RID: 281219 RVA: 0x011D85D1 File Offset: 0x011D67D1
		private void SetGameGoing()
		{
			this.ButtonItem.SetPause(false);
			this.FullTipItem.SetTxtInfo("Fishing_QTE_Start", Array.Empty<object>());
			this.FullTipItem.PlayTipSequence(new Action(this.<SetGameGoing>g__startAnimFlow|43_0), "Start", true);
		}

		// Token: 0x06044A84 RID: 281220 RVA: 0x011D8611 File Offset: 0x011D6811
		private void SetGameEnd(int fishCount)
		{
			Singleton<UiLayer>.Instance.SetShowMaskLayer("FishingQteAnimEnd.Start", true);
			this.TipsTxt.ShowTip(EFishingTipsType.GetFish, fishCount.ToString(), new Action(this.<SetGameEnd>g__animFlow1|44_1));
		}

		// Token: 0x06044A85 RID: 281221 RVA: 0x011D8644 File Offset: 0x011D6844
		private void OnAreaClick(EFishingAreaType areaType, ContinuousRingArea area)
		{
			this.ButtonItem.SetForbiddenStart((float)this.GameConfig.HitColdTime);
			this.RingItem.OnAreaClick(areaType, area);
			switch (areaType)
			{
			case EFishingAreaType.BlankArea:
				this.PlayAnim("QteFail");
				ModelBase<FishingQteModel>.Instance.OnMissOn();
				Singleton<EventSystem>.Instance.Emit<bool>(EEventName.FishingQteBtnHitValidArea, false);
				return;
			case EFishingAreaType.QteArea:
			{
				this.ProgressItem.StartAnimProgress();
				this.PlayAnim("QteSuccess");
				ModelBase<FishingQteModel>.Instance.OnQteOn();
				FishingQteRingInfo ringInfo = this.GameInfo.GetRingInfo();
				if (!ringInfo.IsWholeRing)
				{
					ringInfo.EnterNextValidArea();
				}
				this.RingItem.SpawnContinuousArea(area.ContinuousIndex, EFishingAreaType.QteArea);
				Singleton<EventSystem>.Instance.Emit<bool>(EEventName.FishingQteBtnHitValidArea, true);
				return;
			}
			case EFishingAreaType.PerfectArea:
			{
				this.ProgressItem.StartAnimProgress();
				this.PlayAnim("PerfectQte");
				ModelBase<FishingQteModel>.Instance.OnPerfectOn();
				FishingQteRingInfo ringInfo2 = this.GameInfo.GetRingInfo();
				if (!ringInfo2.IsWholeRing)
				{
					ringInfo2.EnterNextValidArea();
				}
				this.RingItem.SpawnContinuousArea(area.ContinuousIndex, EFishingAreaType.PerfectArea);
				Singleton<EventSystem>.Instance.Emit<bool>(EEventName.FishingQteBtnHitValidArea, true);
				return;
			}
			default:
				return;
			}
		}

		// Token: 0x06044A86 RID: 281222 RVA: 0x011D876C File Offset: 0x011D696C
		[NullableContext(1)]
		private void PlayAnim(string sequenceName)
		{
			if (this.LevelSequencePlayer.GetCurrentSequence() == sequenceName)
			{
				this.LevelSequencePlayer.ReplaySequenceByKey(sequenceName);
				return;
			}
			this.LevelSequencePlayer.StopPlayingSequence(false, true);
			this.LevelSequencePlayer.PlayLevelSequenceByName(sequenceName, false, null, false);
		}

		// Token: 0x06044A87 RID: 281223 RVA: 0x011D87C0 File Offset: 0x011D69C0
		private void RefreshFishingPointCount()
		{
			int currentRound = this.GameInfo.CurrentRound;
			int index = this.GameInfo.MaxRound - currentRound;
			FishingRoundItem layoutItemByIndex = this.FishIconLayout.GetLayoutItemByIndex(index);
			if (layoutItemByIndex == null)
			{
				return;
			}
			layoutItemByIndex.ShowIcon((int)ModelBase<FishingQteModel>.Instance.CurrentFishingIconType);
		}

		// Token: 0x06044A8B RID: 281227 RVA: 0x011D8890 File Offset: 0x011D6A90
		[CompilerGenerated]
		private void <SetGameStart>g__startAnimFlow|42_0()
		{
			this.GameInfo.SetGameStage(EFishingQteStage.OnGoing);
		}

		// Token: 0x06044A8C RID: 281228 RVA: 0x011D889E File Offset: 0x011D6A9E
		[CompilerGenerated]
		private void <SetGameGoing>g__startAnimFlow|43_0()
		{
			this.GameInfo.SetGameStage(EFishingQteStage.OnGoing);
		}

		// Token: 0x06044A8D RID: 281229 RVA: 0x011D88AC File Offset: 0x011D6AAC
		[CompilerGenerated]
		private void <SetGameEnd>g__animFlow2|44_0()
		{
			this.GameInfo.SetGameStage(EFishingQteStage.AnimEnd);
			Singleton<UiLayer>.Instance.SetShowMaskLayer("FishingQteAnimEnd.Start", false);
		}

		// Token: 0x06044A8E RID: 281230 RVA: 0x011D88CA File Offset: 0x011D6ACA
		[CompilerGenerated]
		private void <SetGameEnd>g__animFlow1|44_1()
		{
			this.FullTipItem.SetTxtInfo("Fishing_QTE_Finish", Array.Empty<object>());
			this.FullTipItem.PlayTipSequence(new Action(this.<SetGameEnd>g__animFlow2|44_0), "Start", true);
		}

		// Token: 0x0402637B RID: 156539
		[Nullable(1)]
		private const string ANIM_FISHING_SUCCESS = "FishSuccess";

		// Token: 0x0402637C RID: 156540
		[Nullable(1)]
		private const string ANIM_QTE_SUCCESS = "QteSuccess";

		// Token: 0x0402637D RID: 156541
		[Nullable(1)]
		private const string ANIM_QTE_PERFECT = "PerfectQte";

		// Token: 0x0402637E RID: 156542
		[Nullable(1)]
		private const string ANIM_QTE_FAIL = "QteFail";

		// Token: 0x0402637F RID: 156543
		[Nullable(1)]
		protected FishingQteGameInfo GameInfo;

		// Token: 0x04026380 RID: 156544
		[Nullable(1)]
		protected IFishingQteConfig GameConfig;

		// Token: 0x04026381 RID: 156545
		private PopupCaptionItem CaptionItem;

		// Token: 0x04026382 RID: 156546
		private FishingTagItem TagItem;

		// Token: 0x04026383 RID: 156547
		private FishingCabinItem CabinItem;

		// Token: 0x04026384 RID: 156548
		private FishingButtonItem ButtonItem;

		// Token: 0x04026385 RID: 156549
		private FishingQteTipsItem TipsTxt;

		// Token: 0x04026386 RID: 156550
		private FishingGetScrollItem GetScrollItem;

		// Token: 0x04026387 RID: 156551
		private FishingProgressItem ProgressItem;

		// Token: 0x04026388 RID: 156552
		private FishingQteRingItem RingItem;

		// Token: 0x04026389 RID: 156553
		private FishingFullTipItem FullTipItem;

		// Token: 0x0402638A RID: 156554
		[Nullable(1)]
		private GenericLayout<FishingRoundItem, int> FishIconLayout;

		// Token: 0x0402638B RID: 156555
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0402638C RID: 156556
		private Action FinishCallback;

		// Token: 0x0200CB5C RID: 52060
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403E694 RID: 255636
			public const int CaptionItem = 0;

			// Token: 0x0403E695 RID: 255637
			public const int LayoutFishIcon = 1;

			// Token: 0x0403E696 RID: 255638
			public const int FishIcon = 2;

			// Token: 0x0403E697 RID: 255639
			public const int PanelRing = 3;

			// Token: 0x0403E698 RID: 255640
			public const int PanelProgressBar = 4;

			// Token: 0x0403E699 RID: 255641
			public const int BtnFish = 5;

			// Token: 0x0403E69A RID: 255642
			public const int PanelGrid = 6;

			// Token: 0x0403E69B RID: 255643
			public const int TagLeftItem = 7;

			// Token: 0x0403E69C RID: 255644
			public const int PanelTipsLeft = 8;

			// Token: 0x0403E69D RID: 255645
			public const int PanelTipsCenter = 9;

			// Token: 0x0403E69E RID: 255646
			public const int TipsTxt = 10;
		}
	}
}
