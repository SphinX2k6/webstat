using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.WheelTower;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020016D3 RID: 5843
[NullableContext(2)]
[Nullable(0)]
public class WheelTowerModeSelectView : UiTickViewBase
{
	// Token: 0x0600A22C RID: 41516 RVA: 0x002AB8FF File Offset: 0x002A9AFF
	[NullableContext(1)]
	public WheelTowerModeSelectView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600A22D RID: 41517 RVA: 0x002AB908 File Offset: 0x002A9B08
	protected unsafe override void OnRegisterComponent()
	{
		int num = 26;
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
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(18, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(19, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(20, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(21, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(22, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(23, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(24, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(25, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(12, new Action(this.OnRewardClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(15, new Action(this.OnBattleClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600A22E RID: 41518 RVA: 0x002ABD00 File Offset: 0x002A9F00
	protected override UniTask OnBeforeStartAsync()
	{
		WheelTowerModeSelectView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<WheelTowerModeSelectView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600A22F RID: 41519 RVA: 0x002ABD44 File Offset: 0x002A9F44
	protected override void OnStart()
	{
		PopupCaptionItem caption = this.Caption;
		if (caption != null)
		{
			caption.SetCloseCallBack(new Action(this.OnCloseClick));
		}
		WheelTowerModeSelectView.ModeToggleItem normalToggleItem = this.NormalToggleItem;
		if (normalToggleItem != null)
		{
			normalToggleItem.SetToggleClickCallback(delegate
			{
				this.SetEndlessMode(false);
				this.RefreshView(false);
			});
		}
		WheelTowerModeSelectView.ModeToggleItem endlessToggleItem = this.EndlessToggleItem;
		if (endlessToggleItem != null)
		{
			endlessToggleItem.SetToggleClickCallback(delegate
			{
				this.SetEndlessMode(true);
				this.RefreshView(false);
			});
		}
		this.ScoreItem = new WheelTowerScoreItem(this, base.GetItem(10));
		this.SeqPlayer = new LevelSequencePlayer(this.RootItem);
		this.InitBgActive();
		this.SelectDefaultMode();
		this.AddHomeBtnExtraCallback();
	}

	// Token: 0x0600A230 RID: 41520 RVA: 0x002ABDDF File Offset: 0x002A9FDF
	protected override void OnBeforeDestroy()
	{
		LevelSequencePlayer seqPlayer = this.SeqPlayer;
		if (seqPlayer == null)
		{
			return;
		}
		seqPlayer.Clear();
	}

	// Token: 0x0600A231 RID: 41521 RVA: 0x002ABDF4 File Offset: 0x002A9FF4
	protected override void OnTick(float delta)
	{
		ValueTuple<bool, string, long> timeVisibleAndRemainTime = ModelBase<ActivityModel>.Instance.GetTimeVisibleAndRemainTime(ModelBase<WheelTowerModel>.Instance.ActivityData, null);
		bool item = timeVisibleAndRemainTime.Item1;
		string item2 = timeVisibleAndRemainTime.Item2;
		UUIText text = base.GetText(16);
		if (text != null)
		{
			text.SetUIActive(item);
		}
		if (item && text != null)
		{
			text.SetText(item2, true);
		}
	}

	// Token: 0x0600A232 RID: 41522 RVA: 0x002ABE44 File Offset: 0x002AA044
	protected override void OnBeforeShow()
	{
		this.OnTick(0f);
		this.OnRedDotRefresh(0);
	}

	// Token: 0x0600A233 RID: 41523 RVA: 0x002ABE58 File Offset: 0x002AA058
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRedDotRefresh));
	}

	// Token: 0x0600A234 RID: 41524 RVA: 0x002ABE76 File Offset: 0x002AA076
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRedDotRefresh));
	}

	// Token: 0x0600A235 RID: 41525 RVA: 0x002ABE94 File Offset: 0x002AA094
	protected override UniTask OnBeforeShowAsyncImplementImplement()
	{
		WheelTowerModeSelectView.<OnBeforeShowAsyncImplementImplement>d__16 <OnBeforeShowAsyncImplementImplement>d__;
		<OnBeforeShowAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeShowAsyncImplementImplement>d__.<>4__this = this;
		<OnBeforeShowAsyncImplementImplement>d__.<>1__state = -1;
		<OnBeforeShowAsyncImplementImplement>d__.<>t__builder.Start<WheelTowerModeSelectView.<OnBeforeShowAsyncImplementImplement>d__16>(ref <OnBeforeShowAsyncImplementImplement>d__);
		return <OnBeforeShowAsyncImplementImplement>d__.<>t__builder.Task;
	}

	// Token: 0x0600A236 RID: 41526 RVA: 0x002ABED8 File Offset: 0x002AA0D8
	private void SelectDefaultMode()
	{
		WheelTowerModel instance = ModelBase<WheelTowerModel>.Instance;
		this.RefreshToggle();
		bool flag = instance.EndlessMode;
		if (!instance.ActivityData.IsLevelUnlocked(flag))
		{
			flag = false;
		}
		this.SetEndlessMode(flag);
		WheelTowerModeSelectView.ModeToggleItem normalToggleItem = this.NormalToggleItem;
		if (normalToggleItem != null)
		{
			normalToggleItem.SetToggleStateForce(!flag);
		}
		WheelTowerModeSelectView.ModeToggleItem endlessToggleItem = this.EndlessToggleItem;
		if (endlessToggleItem == null)
		{
			return;
		}
		endlessToggleItem.SetToggleStateForce(flag);
	}

	// Token: 0x0600A237 RID: 41527 RVA: 0x002ABF33 File Offset: 0x002AA133
	private void SetEndlessMode(bool endless)
	{
		ModelBase<WheelTowerModel>.Instance.SetEndlessMode(endless);
	}

	// Token: 0x0600A238 RID: 41528 RVA: 0x002ABF40 File Offset: 0x002AA140
	private void InitBgActive()
	{
		UUIItem item = base.GetItem(1);
		if (item != null)
		{
			item.SetUIActive(true);
		}
		UUIItem item2 = base.GetItem(2);
		if (item2 != null)
		{
			item2.SetUIActive(true);
		}
		UUIItem item3 = base.GetItem(23);
		if (item3 != null)
		{
			item3.SetUIActive(true);
		}
		UUIItem item4 = base.GetItem(24);
		if (item4 == null)
		{
			return;
		}
		item4.SetUIActive(true);
	}

	// Token: 0x0600A239 RID: 41529 RVA: 0x002ABF9C File Offset: 0x002AA19C
	private void RefreshView(bool skipSwitchAnim = false)
	{
		bool endlessMode = ModelBase<WheelTowerModel>.Instance.EndlessMode;
		string sequenceName = endlessMode ? "SwitchB_W" : "SwitchW_B";
		LevelSequencePlayer seqPlayer = this.SeqPlayer;
		if (seqPlayer != null)
		{
			seqPlayer.PlayOrReplaySequenceByName(sequenceName, false, null);
		}
		if (skipSwitchAnim)
		{
			LevelSequencePlayer seqPlayer2 = this.SeqPlayer;
			if (seqPlayer2 != null)
			{
				seqPlayer2.EndSequenceLastFrame(sequenceName);
			}
		}
		this.RefreshToggle();
		WheelTowerModeSelectView.ModeToggleItem normalToggleItem = this.NormalToggleItem;
		if (normalToggleItem != null)
		{
			normalToggleItem.SetToggleStateForce(!endlessMode);
		}
		WheelTowerModeSelectView.ModeToggleItem endlessToggleItem = this.EndlessToggleItem;
		if (endlessToggleItem != null)
		{
			endlessToggleItem.SetToggleStateForce(endlessMode);
		}
		WheelTowerModel instance = ModelBase<WheelTowerModel>.Instance;
		int num = instance.GetMaxChallengeRound(null) + 1;
		UUIText text = base.GetText(9);
		if (text != null)
		{
			text.SetText(num.ToString(), true);
		}
		int totalScore = instance.GetTotalScore();
		UUIText text2 = base.GetText(11);
		if (text2 != null)
		{
			text2.SetText(totalScore.ToString(), true);
		}
		EScoreLevel totalScoreLevel = instance.GetTotalScoreLevel(totalScore, null, null);
		WheelTowerScoreItem scoreItem = this.ScoreItem;
		if (scoreItem != null)
		{
			scoreItem.Refresh(totalScoreLevel);
		}
		MonsterInfoPreview nextMonsterInfoPreview = instance.GetCurrentLevelRecord(null).NextMonsterInfoPreview;
		if (nextMonsterInfoPreview != null)
		{
			NewTowerWave? waveConfigById = ConfigBase<WheelTowerConfig>.Instance.GetWaveConfigById(nextMonsterInfoPreview.WaveConfigId);
			if (waveConfigById != null)
			{
				base.SetTextureShowUntilLoaded(waveConfigById.Value.SmallIcon, base.GetTexture(6), null);
			}
		}
		int currentRewardProgress = instance.ActivityData.GetCurrentRewardProgress(EFilterMode.All);
		int totalRewardProgress = instance.ActivityData.GetTotalRewardProgress(EFilterMode.All);
		UUIText text3 = base.GetText(13);
		if (text3 != null)
		{
			text3.SetText(currentRewardProgress.ToString(), true);
		}
		UUIText text4 = base.GetText(14);
		if (text4 == null)
		{
			return;
		}
		text4.SetText(totalRewardProgress.ToString(), true);
	}

	// Token: 0x0600A23A RID: 41530 RVA: 0x002AC14D File Offset: 0x002AA34D
	private void RefreshToggle()
	{
		WheelTowerModeSelectView.ModeToggleItem normalToggleItem = this.NormalToggleItem;
		if (normalToggleItem != null)
		{
			normalToggleItem.Refresh(false);
		}
		WheelTowerModeSelectView.ModeToggleItem endlessToggleItem = this.EndlessToggleItem;
		if (endlessToggleItem == null)
		{
			return;
		}
		endlessToggleItem.Refresh(true);
	}

	// Token: 0x0600A23B RID: 41531 RVA: 0x002AC174 File Offset: 0x002AA374
	private UniTask RefreshBossBgImage()
	{
		WheelTowerModeSelectView.<RefreshBossBgImage>d__22 <RefreshBossBgImage>d__;
		<RefreshBossBgImage>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshBossBgImage>d__.<>4__this = this;
		<RefreshBossBgImage>d__.<>1__state = -1;
		<RefreshBossBgImage>d__.<>t__builder.Start<WheelTowerModeSelectView.<RefreshBossBgImage>d__22>(ref <RefreshBossBgImage>d__);
		return <RefreshBossBgImage>d__.<>t__builder.Task;
	}

	// Token: 0x0600A23C RID: 41532 RVA: 0x002AC1B7 File Offset: 0x002AA3B7
	private void OnRewardClick()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.WheelTowerRewardView, null, delegate(bool success, int viewId)
		{
			if (success)
			{
				base.AddChildViewById(viewId);
			}
		});
	}

	// Token: 0x0600A23D RID: 41533 RVA: 0x002AC1D5 File Offset: 0x002AA3D5
	private void OnBattleClick()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.WheelTowerRoundSelectView, null, null);
	}

	// Token: 0x0600A23E RID: 41534 RVA: 0x002AC1E8 File Offset: 0x002AA3E8
	private void OnCloseClick()
	{
		if (ControllerBase<GameModeController>.Instance.IsInInstance())
		{
			ControllerBase<InstanceDungeonController>.Instance.OnClickInstanceDungeonExitButton(null, null, true);
			return;
		}
		base.CloseMe(null);
	}

	// Token: 0x0600A23F RID: 41535 RVA: 0x002AC20B File Offset: 0x002AA40B
	private void AddHomeBtnExtraCallback()
	{
		UiBehaviourHomeBtn uiBehaviourHomeBtn = this.UiBehaviourHomeBtn;
		if (uiBehaviourHomeBtn == null)
		{
			return;
		}
		uiBehaviourHomeBtn.AddExtraAsyncCallback(delegate
		{
			WheelTowerModeSelectView.<>c.<<AddHomeBtnExtraCallback>b__26_0>d <<AddHomeBtnExtraCallback>b__26_0>d;
			<<AddHomeBtnExtraCallback>b__26_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<AddHomeBtnExtraCallback>b__26_0>d.<>1__state = -1;
			<<AddHomeBtnExtraCallback>b__26_0>d.<>t__builder.Start<WheelTowerModeSelectView.<>c.<<AddHomeBtnExtraCallback>b__26_0>d>(ref <<AddHomeBtnExtraCallback>b__26_0>d);
			return <<AddHomeBtnExtraCallback>b__26_0>d.<>t__builder.Task;
		});
	}

	// Token: 0x0600A240 RID: 41536 RVA: 0x002AC23C File Offset: 0x002AA43C
	private void OnRedDotRefresh(int _)
	{
		this.RefreshView(true);
		UUIItem item = base.GetItem(25);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(ModelBase<WheelTowerModel>.Instance.ActivityData.ShouldShowRewardRedDot());
	}

	// Token: 0x04004C83 RID: 19587
	[Nullable(1)]
	private const string IconPlay = "/Game/Aki/UI/UIResources/UiActivity/Atlas/ActivityMowingTower/MowingTower30/Main/SP_IconPlay.SP_IconPlay";

	// Token: 0x04004C84 RID: 19588
	[Nullable(1)]
	private const string IconLock = "/Game/Aki/UI/UIResources/UiActivity/Atlas/ActivityMowingTower/MowingTower30/Main/SP_IconLock.SP_IconLock";

	// Token: 0x04004C85 RID: 19589
	private PopupCaptionItem Caption;

	// Token: 0x04004C86 RID: 19590
	private WheelTowerModeSelectView.ModeToggleItem NormalToggleItem;

	// Token: 0x04004C87 RID: 19591
	private WheelTowerModeSelectView.ModeToggleItem EndlessToggleItem;

	// Token: 0x04004C88 RID: 19592
	private WheelTowerScoreItem ScoreItem;

	// Token: 0x04004C89 RID: 19593
	private LevelSequencePlayer SeqPlayer;

	// Token: 0x02007A25 RID: 31269
	[NullableContext(1)]
	[Nullable(0)]
	private class ModeToggleItem : UiPanelBase
	{
		// Token: 0x0604788A RID: 293002 RVA: 0x01310C8A File Offset: 0x0130EE8A
		public ModeToggleItem(string iconPlay, string iconLock)
		{
			this.IconPlay = iconPlay;
			this.IconLock = iconLock;
		}

		// Token: 0x0604788B RID: 293003 RVA: 0x01310CA0 File Offset: 0x0130EEA0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIExtendToggleSpriteTransition));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0604788C RID: 293004 RVA: 0x01310DAC File Offset: 0x0130EFAC
		protected override void OnStart()
		{
			UUIExtendToggle toggle = base.GetExtendToggle(0);
			toggle.CanExecuteChange.Bind(() => toggle.ToggleState != EToggleState.ETT_Checked);
			this.SetToggleStateForce(false);
		}

		// Token: 0x0604788D RID: 293005 RVA: 0x01310DF0 File Offset: 0x0130EFF0
		public void Refresh(bool endless)
		{
			WheelTowerModel instance = ModelBase<WheelTowerModel>.Instance;
			bool flag = instance.ActivityData.IsLevelUnlocked(endless);
			bool flag2 = instance.IsLevelCompleted(endless);
			base.SetExtendToggleSpriteTransitionByPath(flag ? this.IconPlay : this.IconLock, base.GetUiExtendToggleSpriteTransition(1), null).Forget();
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle != null)
			{
				extendToggle.SetSelfInteractive(flag);
			}
			UUIItem item = base.GetItem(3);
			if (item != null)
			{
				item.SetUIActive(flag2);
			}
			UUIExtendToggleSpriteTransition uiExtendToggleSpriteTransition = base.GetUiExtendToggleSpriteTransition(1);
			if (uiExtendToggleSpriteTransition != null)
			{
				uiExtendToggleSpriteTransition.RootUIComp.Get().SetUIActive(!flag2);
			}
			if (endless)
			{
				UUIText text = base.GetText(2);
				if (text != null)
				{
					text.ShowTextNew(flag ? "PrefabTextItem_2898489298_Text" : "WheelTower_EndlessCondition");
				}
			}
			UUIItem item2 = base.GetItem(4);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(instance.ActivityData.HasLevelRedDot(endless));
		}

		// Token: 0x0604788E RID: 293006 RVA: 0x01310ECF File Offset: 0x0130F0CF
		public void SetToggleClickCallback(Action callback)
		{
			this.ToggleClickCallback = callback;
		}

		// Token: 0x0604788F RID: 293007 RVA: 0x01310ED8 File Offset: 0x0130F0D8
		public void SetToggleStateForce(bool isSelect)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleStateForce(isSelect ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x06047890 RID: 293008 RVA: 0x01310EF5 File Offset: 0x0130F0F5
		private void OnToggleClick(EToggleState state)
		{
			if (state == EToggleState.ETT_Checked)
			{
				Action toggleClickCallback = this.ToggleClickCallback;
				if (toggleClickCallback == null)
				{
					return;
				}
				toggleClickCallback();
			}
		}

		// Token: 0x04029E69 RID: 171625
		private readonly string IconPlay;

		// Token: 0x04029E6A RID: 171626
		private readonly string IconLock;

		// Token: 0x04029E6B RID: 171627
		[Nullable(2)]
		private Action ToggleClickCallback;
	}
}
