using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.InputSetting;
using CSharpScript.Game.Module.AutoPilot;
using CSharpScript.Game.Module.MovieMode;
using CSharpScript.Game.Module.SkillButtonUi;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006081 RID: 24705
	[NullableContext(1)]
	[Nullable(0)]
	public class MotorcycleControlTopPanel : BattleVisibleChildView
	{
		// Token: 0x0603E4EA RID: 255210 RVA: 0x00FE8CA8 File Offset: 0x00FE6EA8
		public UniTask Init(UUIItem parentItem, string resourceId)
		{
			MotorcycleControlTopPanel.<Init>d__22 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.parentItem = parentItem;
			<Init>d__.resourceId = resourceId;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<MotorcycleControlTopPanel.<Init>d__22>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x0603E4EB RID: 255211 RVA: 0x00FE8CFC File Offset: 0x00FE6EFC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 11;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUINiagara));
			this.ComponentRegisterInfos = list;
			this.IsInTouch = Singleton<Info>.Instance.IsInTouch();
			if (!this.IsInTouch)
			{
				this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(11, typeof(UUIItem)));
				this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(12, typeof(UUIItem)));
				this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(13, typeof(UUIItem)));
			}
			num2 = 3;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickMusicTitleButton));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickMusicBtnPrev));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnClickMusicBtnNext));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603E4EC RID: 255212 RVA: 0x00FE8F80 File Offset: 0x00FE7180
		protected override UniTask OnBeforeStartAsync()
		{
			MotorcycleControlTopPanel.<OnBeforeStartAsync>d__24 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MotorcycleControlTopPanel.<OnBeforeStartAsync>d__24>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603E4ED RID: 255213 RVA: 0x00FE8FC4 File Offset: 0x00FE71C4
		private UniTask InitKeyItem(UUIItem item)
		{
			MotorcycleControlTopPanel.<InitKeyItem>d__25 <InitKeyItem>d__;
			<InitKeyItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitKeyItem>d__.<>4__this = this;
			<InitKeyItem>d__.item = item;
			<InitKeyItem>d__.<>1__state = -1;
			<InitKeyItem>d__.<>t__builder.Start<MotorcycleControlTopPanel.<InitKeyItem>d__25>(ref <InitKeyItem>d__);
			return <InitKeyItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603E4EE RID: 255214 RVA: 0x00FE9010 File Offset: 0x00FE7210
		protected override void OnStart()
		{
			this.TweenAnimPlayer.InitTweenAnim(8, base.GetItem(8), false);
			this.TweenAnimPlayer.InitTweenAnim(9, base.GetItem(9), false);
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.MusicTitleText = base.GetText(2);
			this.MusicTitleViewWidth = base.GetItem(1).GetWidth();
			this.MusicTitleScrollSpeed = ConfigCommonParamById.GetFloatConfig("MusicTitleScrollSpeed").Value;
			this.MusicTitleScrollBeginTime = ConfigCommonParamById.GetFloatConfig("MusicTitleScrollBeginTime").Value;
			this.MusicTitleScrollEndTime = ConfigCommonParamById.GetFloatConfig("MusicTitleScrollEndTime").Value;
			this.RefreshMusicTitle();
			this.RefreshMusicPlayState();
			this.RefreshMusicVisible();
			this.RefreshBossStateAreaVisible();
			this.RefreshKeyNodeVisible();
			this.RefreshKeyItems();
			this.SetColorState(ModelBase<BattleUiModel>.Instance.MotorcycleData.HudColorState);
			if (this.IsInTouch)
			{
				this.ApplyTouchUiEditData();
			}
			this.AddEvents();
		}

		// Token: 0x0603E4EF RID: 255215 RVA: 0x00FE910C File Offset: 0x00FE730C
		public void OnShowBattleChildViewPanel()
		{
			this.MusicPlayStateDirty = true;
			this.RefreshMusicTitle();
		}

		// Token: 0x0603E4F0 RID: 255216 RVA: 0x00FE911B File Offset: 0x00FE731B
		public void OnHideBattleChildViewPanel()
		{
		}

		// Token: 0x0603E4F1 RID: 255217 RVA: 0x00FE911D File Offset: 0x00FE731D
		protected override void OnBeforeShow()
		{
			base.OnBeforeShow();
			ModelBase<BattleUiModel>.Instance.UpdateBossStateArea(EBossStateAreaType.MotorcycleControlTop, true);
		}

		// Token: 0x0603E4F2 RID: 255218 RVA: 0x00FE9134 File Offset: 0x00FE7334
		protected override void OnAfterShow()
		{
			string sequenceName = ModelBase<AutoPilotModel>.Instance.GetIsInMovieMode() ? "MovieIn" : "Start";
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.PlayLevelSequenceByName(sequenceName, false, null, false);
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.OnMotorMusicPlayerShow);
			this.ResetAlpha();
		}

		// Token: 0x0603E4F3 RID: 255219 RVA: 0x00FE9190 File Offset: 0x00FE7390
		protected override UniTask OnBeforeHideAsync()
		{
			MotorcycleControlTopPanel.<OnBeforeHideAsync>d__32 <OnBeforeHideAsync>d__;
			<OnBeforeHideAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeHideAsync>d__.<>4__this = this;
			<OnBeforeHideAsync>d__.<>1__state = -1;
			<OnBeforeHideAsync>d__.<>t__builder.Start<MotorcycleControlTopPanel.<OnBeforeHideAsync>d__32>(ref <OnBeforeHideAsync>d__);
			return <OnBeforeHideAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603E4F4 RID: 255220 RVA: 0x00FE91D3 File Offset: 0x00FE73D3
		protected override void OnAutoDestroy()
		{
			base.OnAutoDestroy();
			if (this.StopPromise != null)
			{
				this.StopPromise.SetResult(true);
				this.StopPromise = null;
			}
		}

		// Token: 0x0603E4F5 RID: 255221 RVA: 0x00FE91F6 File Offset: 0x00FE73F6
		protected override void OnBeforeDestroy()
		{
			this.TweenAnimPlayer.Clear(false);
			if (this.LevelSequencePlayer != null)
			{
				this.LevelSequencePlayer.Clear();
				this.LevelSequencePlayer = null;
			}
			this.RemoveEvents();
		}

		// Token: 0x0603E4F6 RID: 255222 RVA: 0x00FE9224 File Offset: 0x00FE7424
		private void AddEvents()
		{
			base.GetExtendToggle(4).OnStateChange.Add(new Action<EToggleState>(this.OnMusicTogPlayStateChanged));
			Singleton<EventSystem>.Instance.Add<EBossStateAreaType, EBossStateAreaType>(EEventName.BattleUiBossStateAreaChanged, new Action<EBossStateAreaType, EBossStateAreaType>(this.OnBattleUiBossStateAreaChanged));
			Singleton<EventSystem>.Instance.Add(EEventName.OnMotorSwitchMusic, new Action(this.OnMotorSwitchMusic));
			Singleton<EventSystem>.Instance.Add(EEventName.OnMotorMusicEnableStateChanged, new Action<bool>(this.OnMotorMusicEnableStateChanged));
			if (!this.IsInTouch)
			{
				Singleton<EventSystem>.Instance.Add<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.OnInputControllerChange));
				Singleton<EventSystem>.Instance.Add<bool>(EEventName.BattleUiPressMotorcycleCombineButtonChanged, new Action<bool>(this.OnInputCombineButton));
				ControllerBase<InputDistributeController>.Instance.BindActions(MotorcycleControlTopPanel.ActionNameList, new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
			}
			else
			{
				Singleton<EventSystem>.Instance.Add<ECommonTouchUiEditGroup>(EEventName.OnTouchUiEditSave, new Action<ECommonTouchUiEditGroup>(this.OnTouchUiEditSave));
			}
			Singleton<EventSystem>.Instance.Add<EMotorcycleHudColorState>(EEventName.BattleUiMotorcycleHudColorStateChanged, new Action<EMotorcycleHudColorState>(this.OnHudColorStateChanged));
		}

		// Token: 0x0603E4F7 RID: 255223 RVA: 0x00FE9338 File Offset: 0x00FE7538
		private void RemoveEvents()
		{
			base.GetExtendToggle(4).OnStateChange.Remove(new Action<EToggleState>(this.OnMusicTogPlayStateChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiBossStateAreaChanged, new Action<EBossStateAreaType, EBossStateAreaType>(this.OnBattleUiBossStateAreaChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnMotorSwitchMusic, new Action(this.OnMotorSwitchMusic));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnMotorMusicEnableStateChanged, new Action<bool>(this.OnMotorMusicEnableStateChanged));
			if (!this.IsInTouch)
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.OnInputControllerChange));
				Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiPressMotorcycleCombineButtonChanged, new Action<bool>(this.OnInputCombineButton));
				ControllerBase<InputDistributeController>.Instance.UnBindActions(MotorcycleControlTopPanel.ActionNameList, new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
			}
			else
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.OnTouchUiEditSave, new Action<ECommonTouchUiEditGroup>(this.OnTouchUiEditSave));
			}
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiMotorcycleHudColorStateChanged, new Action<EMotorcycleHudColorState>(this.OnHudColorStateChanged));
		}

		// Token: 0x0603E4F8 RID: 255224 RVA: 0x00FE944B File Offset: 0x00FE764B
		private void OnClickMusicTitleButton()
		{
			this.ResetAlpha();
			ControllerBase<MotorcycleMusicPlayerController>.Instance.OpenMusicPlayerView();
		}

		// Token: 0x0603E4F9 RID: 255225 RVA: 0x00FE945D File Offset: 0x00FE765D
		private void OnClickMusicBtnPrev()
		{
			this.ResetAlpha();
			ControllerBase<MotorcycleMusicPlayerController>.Instance.QuickPlayMusic(false);
		}

		// Token: 0x0603E4FA RID: 255226 RVA: 0x00FE9470 File Offset: 0x00FE7670
		private void OnClickMusicBtnNext()
		{
			this.ResetAlpha();
			ControllerBase<MotorcycleMusicPlayerController>.Instance.QuickPlayMusic(true);
		}

		// Token: 0x0603E4FB RID: 255227 RVA: 0x00FE9484 File Offset: 0x00FE7684
		private void OnMusicTogPlayStateChanged(EToggleState state)
		{
			this.ResetAlpha();
			if (!ControllerBase<MotorcycleMusicPlayerController>.Instance.CheckIsEnable(false))
			{
				this.RefreshMusicPlayState();
				return;
			}
			bool flag = state == EToggleState.ETT_Checked;
			if (ModelBase<MotorcycleMusicPlayerModel>.Instance.GetCurPlayMusicId() > 0)
			{
				if (!ModelBase<MotorcycleMusicPlayerModel>.Instance.GetIsPause() != flag)
				{
					if (flag)
					{
						ControllerBase<MotorcycleMusicPlayerController>.Instance.ResumeMusic();
					}
					else
					{
						ControllerBase<MotorcycleMusicPlayerController>.Instance.PauseMusic();
					}
				}
			}
			else
			{
				ControllerBase<MotorcycleMusicPlayerController>.Instance.QuickPlayMusic(true);
			}
			this.RefreshMusicPlayEffect(flag);
		}

		// Token: 0x0603E4FC RID: 255228 RVA: 0x00FE94FA File Offset: 0x00FE76FA
		private void OnBattleUiBossStateAreaChanged(EBossStateAreaType lastType, EBossStateAreaType curType)
		{
			this.RefreshBossStateAreaVisible();
		}

		// Token: 0x0603E4FD RID: 255229 RVA: 0x00FE9502 File Offset: 0x00FE7702
		private void OnMotorMusicEnableStateChanged(bool isEnable)
		{
			this.RefreshMusicPlayState();
			this.RefreshMusicVisible();
		}

		// Token: 0x0603E4FE RID: 255230 RVA: 0x00FE9510 File Offset: 0x00FE7710
		private void RefreshMusicVisible()
		{
			base.SetVisible(2, ModelBase<MotorcycleMusicPlayerModel>.Instance.IsEnable);
		}

		// Token: 0x0603E4FF RID: 255231 RVA: 0x00FE9523 File Offset: 0x00FE7723
		private void OnMotorSwitchMusic()
		{
			this.RefreshMusicTitle();
			this.RefreshMusicPlayState();
		}

		// Token: 0x0603E500 RID: 255232 RVA: 0x00FE9531 File Offset: 0x00FE7731
		private void OnInputControllerChange(EInputControllerType last, EInputControllerType now)
		{
			this.RefreshKeyNodeVisible();
		}

		// Token: 0x0603E501 RID: 255233 RVA: 0x00FE9539 File Offset: 0x00FE7739
		private void OnInputCombineButton(bool isPress)
		{
			this.RefreshKeyNodeVisible();
		}

		// Token: 0x0603E502 RID: 255234 RVA: 0x00FE9544 File Offset: 0x00FE7744
		private void OnInputAction(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification inputIdentification)
		{
			if (!ModelBase<BattleUiModel>.Instance.MotorcycleData.IsDriving)
			{
				return;
			}
			if (!ControllerBase<MotorcycleMusicPlayerController>.Instance.CheckIsEnable(false))
			{
				return;
			}
			if (actionType != InputDistributeDefine.EActionType.Press)
			{
				return;
			}
			if (actionName == "载具音乐上一首")
			{
				this.OnClickMusicBtnPrev();
				return;
			}
			if (actionName == "载具音乐下一首")
			{
				this.OnClickMusicBtnNext();
				return;
			}
			if (actionName == "载具音乐播放暂停")
			{
				UUIExtendToggle extendToggle = base.GetExtendToggle(4);
				if (extendToggle.GetToggleState() == EToggleState.ETT_Checked)
				{
					extendToggle.SetToggleState(EToggleState.ETT_UnChecked, true, false, false);
					return;
				}
				extendToggle.SetToggleState(EToggleState.ETT_Checked, true, false, false);
			}
		}

		// Token: 0x0603E503 RID: 255235 RVA: 0x00FE95D4 File Offset: 0x00FE77D4
		private void RefreshKeyNodeVisible()
		{
			if (Singleton<Info>.Instance.IsInGamepad())
			{
				SkillButtonUiGamepadDataBase gamepadDataByType = ModelBase<SkillButtonUiModel>.Instance.GetGamepadDataByType(ESkillButtonGamepadDataType.Motorcycle);
				bool uiactive = gamepadDataByType != null && gamepadDataByType.GetIsPressCombineButton();
				base.GetItem(6).SetUIActive(uiactive);
				return;
			}
			base.GetItem(6).SetUIActive(false);
		}

		// Token: 0x0603E504 RID: 255236 RVA: 0x00FE9620 File Offset: 0x00FE7820
		private void RefreshMusicTitle()
		{
			int curPlayMusicId = ModelBase<MotorcycleMusicPlayerModel>.Instance.GetCurPlayMusicId();
			if (curPlayMusicId > 0)
			{
				PhonographMusic? phonographMusic;
				string key = ((ConfigBase<PhonographConfig>.Instance.GetMusicById(curPlayMusicId) != null) ? phonographMusic.GetValueOrDefault().Title : null) ?? string.Empty;
				UUIText musicTitleText = this.MusicTitleText;
				if (musicTitleText != null)
				{
					musicTitleText.ShowTextNew(key);
				}
			}
			else
			{
				UUIText musicTitleText2 = this.MusicTitleText;
				if (musicTitleText2 != null)
				{
					musicTitleText2.SetText(string.Empty, true);
				}
			}
			this.ResetMusicTitleScroll();
		}

		// Token: 0x0603E505 RID: 255237 RVA: 0x00FE96A0 File Offset: 0x00FE78A0
		private void RefreshMusicPlayState()
		{
			bool flag = false;
			if (ModelBase<MotorcycleMusicPlayerModel>.Instance.GetCurPlayMusicId() > 0)
			{
				flag = (!ModelBase<MotorcycleMusicPlayerModel>.Instance.GetIsPause() && ModelBase<MotorcycleMusicPlayerModel>.Instance.IsEnable);
			}
			base.GetExtendToggle(4).SetToggleState(flag ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
			this.RefreshMusicPlayEffect(flag);
			this.MusicPlayStateDirty = false;
		}

		// Token: 0x0603E506 RID: 255238 RVA: 0x00FE96FC File Offset: 0x00FE78FC
		private void RefreshMusicPlayEffect(bool bPlaying)
		{
			if (this.MusicEffectPlaying == bPlaying)
			{
				return;
			}
			this.MusicEffectPlaying = bPlaying;
			base.GetUiNiagara(10).SetUIActive(bPlaying);
			if (bPlaying)
			{
				LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
				if (levelSequencePlayer == null)
				{
					return;
				}
				levelSequencePlayer.PlaySequencePurely("Loop", false, false, null, null, false);
				return;
			}
			else
			{
				LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
				if (levelSequencePlayer2 == null)
				{
					return;
				}
				levelSequencePlayer2.StopSequenceByKey("Loop", false, false);
				return;
			}
		}

		// Token: 0x0603E507 RID: 255239 RVA: 0x00FE9765 File Offset: 0x00FE7965
		private void ResetMusicTitleScroll()
		{
			this.MusicTitleScrollState = MotorcycleControlTopPanel.EScrollState.Begin;
			UUIText musicTitleText = this.MusicTitleText;
			if (musicTitleText == null)
			{
				return;
			}
			musicTitleText.SetAnchorOffsetX(0f);
		}

		// Token: 0x0603E508 RID: 255240 RVA: 0x00FE9784 File Offset: 0x00FE7984
		private void RefreshBossStateAreaVisible()
		{
			bool bVisible = ModelBase<BattleUiModel>.Instance.GetBossStateAreaType() >= EBossStateAreaType.MotorcycleControlTop;
			base.SetVisible(1, bVisible);
		}

		// Token: 0x0603E509 RID: 255241 RVA: 0x00FE97AC File Offset: 0x00FE79AC
		private void RefreshKeyItems()
		{
			if (this.IsInTouch)
			{
				return;
			}
			for (int i = 0; i < this.KeyItemList.Count; i++)
			{
				InputMultiKeyItem inputMultiKeyItem = this.KeyItemList[i];
				string actionOrAxisName = MotorcycleControlTopPanel.ActionNameList[i];
				InputActionOrAxisKeyItem actionOrAxisKeyItem = new InputActionOrAxisKeyItem
				{
					ActionOrAxisName = actionOrAxisName
				};
				inputMultiKeyItem.RefreshByActionOrAxis(actionOrAxisKeyItem, true);
			}
		}

		// Token: 0x0603E50A RID: 255242 RVA: 0x00FE9800 File Offset: 0x00FE7A00
		public void Tick(float delta)
		{
			if (!base.IsShowOrShowing)
			{
				return;
			}
			if (this.MusicPlayStateDirty)
			{
				this.RefreshMusicPlayState();
			}
			switch (this.MusicTitleScrollState)
			{
			case MotorcycleControlTopPanel.EScrollState.Begin:
				this.MusicTitleScrollTime -= delta;
				if (this.MusicTitleScrollTime <= 0f)
				{
					this.MusicTitleScrollTime = this.MusicTitleScrollEndTime;
					this.MusicTitleTextWidth = this.MusicTitleText.GetWidth();
					if (this.MusicTitleTextWidth > this.MusicTitleViewWidth)
					{
						this.MusicTitleScrollState = MotorcycleControlTopPanel.EScrollState.Scrolling;
						this.MusicTitleTextCurX = 0f;
					}
					else
					{
						this.MusicTitleScrollState = MotorcycleControlTopPanel.EScrollState.NoScroll;
					}
				}
				break;
			case MotorcycleControlTopPanel.EScrollState.Scrolling:
			{
				this.MusicTitleTextCurX -= delta * this.MusicTitleScrollSpeed;
				float num = this.MusicTitleViewWidth - this.MusicTitleTextWidth;
				if (this.MusicTitleTextCurX <= num)
				{
					this.MusicTitleTextCurX = num;
					this.MusicTitleScrollState = MotorcycleControlTopPanel.EScrollState.End;
				}
				this.MusicTitleText.SetAnchorOffsetX(this.MusicTitleTextCurX);
				break;
			}
			case MotorcycleControlTopPanel.EScrollState.End:
				this.MusicTitleScrollTime -= delta;
				if (this.MusicTitleScrollTime <= 0f)
				{
					this.MusicTitleScrollTime = this.MusicTitleScrollBeginTime;
					this.MusicTitleScrollState = MotorcycleControlTopPanel.EScrollState.Begin;
					this.MusicTitleText.SetAnchorOffsetX(0f);
				}
				break;
			}
			this.UpdateAlpha(delta);
		}

		// Token: 0x0603E50B RID: 255243 RVA: 0x00FE9942 File Offset: 0x00FE7B42
		private void OnHudColorStateChanged(EMotorcycleHudColorState state)
		{
			this.SetColorState(state);
		}

		// Token: 0x0603E50C RID: 255244 RVA: 0x00FE994C File Offset: 0x00FE7B4C
		private void SetColorState(EMotorcycleHudColorState state)
		{
			if (state == EMotorcycleHudColorState.Parkour)
			{
				return;
			}
			if (this.ColorState == state)
			{
				return;
			}
			this.ColorState = state;
			if (state == EMotorcycleHudColorState.Nitrogen)
			{
				LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
				if (levelSequencePlayer != null)
				{
					levelSequencePlayer.StopSequenceByKey("TurnBlue", false, false);
				}
				LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
				if (levelSequencePlayer2 == null)
				{
					return;
				}
				levelSequencePlayer2.PlaySequencePurely("TurnGreen", false, false, null, null, false);
				return;
			}
			else
			{
				LevelSequencePlayer levelSequencePlayer3 = this.LevelSequencePlayer;
				if (levelSequencePlayer3 != null)
				{
					levelSequencePlayer3.StopSequenceByKey("TurnGreen", false, false);
				}
				LevelSequencePlayer levelSequencePlayer4 = this.LevelSequencePlayer;
				if (levelSequencePlayer4 == null)
				{
					return;
				}
				levelSequencePlayer4.PlaySequencePurely("TurnBlue", false, false, null, null, false);
				return;
			}
		}

		// Token: 0x0603E50D RID: 255245 RVA: 0x00FE99E8 File Offset: 0x00FE7BE8
		private void UpdateAlpha(float delta)
		{
			if (this.AlphaTimeCountdown < 0f)
			{
				return;
			}
			this.AlphaTimeCountdown -= delta;
			if (this.AlphaTimeCountdown <= 0f)
			{
				this.AlphaTimeCountdown = -1f;
				this.TweenAnimPlayer.StopTweenAnim(9);
				this.TweenAnimPlayer.PlayTweenAnim(8);
			}
		}

		// Token: 0x0603E50E RID: 255246 RVA: 0x00FE9A42 File Offset: 0x00FE7C42
		private void ResetAlpha()
		{
			if (this.AlphaTimeCountdown == -1f)
			{
				this.TweenAnimPlayer.StopTweenAnim(8);
				this.TweenAnimPlayer.PlayTweenAnim(9);
			}
			this.AlphaTimeCountdown = 5000f;
		}

		// Token: 0x0603E50F RID: 255247 RVA: 0x00FE9A75 File Offset: 0x00FE7C75
		private void ApplyTouchUiEditData()
		{
			TouchUiEditApplyHelper.ApplyCommonTouchUiEditData(ECommonTouchUiEditGroup.Motorcycle, this, "UiItem_MotorcycleControlTopEdit");
		}

		// Token: 0x0603E510 RID: 255248 RVA: 0x00FE9A83 File Offset: 0x00FE7C83
		private void OnTouchUiEditSave(ECommonTouchUiEditGroup group)
		{
			if (group != ECommonTouchUiEditGroup.Motorcycle)
			{
				return;
			}
			this.ApplyTouchUiEditData();
		}

		// Token: 0x04022EBC RID: 143036
		[StaticVariableRuleIgnore]
		private static readonly string[] ActionNameList = new string[]
		{
			"载具音乐上一首",
			"载具音乐播放暂停",
			"载具音乐下一首"
		};

		// Token: 0x04022EBD RID: 143037
		private readonly BattleUiTweenAnimPlayer TweenAnimPlayer = new BattleUiTweenAnimPlayer();

		// Token: 0x04022EBE RID: 143038
		[Nullable(2)]
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x04022EBF RID: 143039
		private bool MusicPlayStateDirty;

		// Token: 0x04022EC0 RID: 143040
		[Nullable(2)]
		private UUIText MusicTitleText;

		// Token: 0x04022EC1 RID: 143041
		private float MusicTitleViewWidth;

		// Token: 0x04022EC2 RID: 143042
		private float MusicTitleTextWidth;

		// Token: 0x04022EC3 RID: 143043
		private MotorcycleControlTopPanel.EScrollState MusicTitleScrollState;

		// Token: 0x04022EC4 RID: 143044
		private float MusicTitleScrollTime;

		// Token: 0x04022EC5 RID: 143045
		private float MusicTitleScrollSpeed = 0.1f;

		// Token: 0x04022EC6 RID: 143046
		private float MusicTitleScrollBeginTime = 1000f;

		// Token: 0x04022EC7 RID: 143047
		private float MusicTitleScrollEndTime = 1000f;

		// Token: 0x04022EC8 RID: 143048
		private float MusicTitleTextCurX;

		// Token: 0x04022EC9 RID: 143049
		[Nullable(2)]
		private IUiItemAspectOffsetConfig UiItemOffsetConfig;

		// Token: 0x04022ECA RID: 143050
		private readonly List<InputMultiKeyItem> KeyItemList = new List<InputMultiKeyItem>();

		// Token: 0x04022ECB RID: 143051
		private EMotorcycleHudColorState ColorState;

		// Token: 0x04022ECC RID: 143052
		private float AlphaTimeCountdown = -1f;

		// Token: 0x04022ECD RID: 143053
		private bool IsInTouch;

		// Token: 0x04022ECE RID: 143054
		private bool MusicEffectPlaying;

		// Token: 0x04022ECF RID: 143055
		[Nullable(2)]
		private CustomPromise<bool> StopPromise;

		// Token: 0x0200C164 RID: 49508
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403B8C5 RID: 243909
			MusicTitleButton,
			// Token: 0x0403B8C6 RID: 243910
			MusicTitleNode,
			// Token: 0x0403B8C7 RID: 243911
			MusicTitleText,
			// Token: 0x0403B8C8 RID: 243912
			MusicBtnPrev,
			// Token: 0x0403B8C9 RID: 243913
			MusicTogPlay,
			// Token: 0x0403B8CA RID: 243914
			MusicBtnNext,
			// Token: 0x0403B8CB RID: 243915
			KeyNode,
			// Token: 0x0403B8CC RID: 243916
			RootItem,
			// Token: 0x0403B8CD RID: 243917
			AniAlphaIn,
			// Token: 0x0403B8CE RID: 243918
			AniAlphaOut,
			// Token: 0x0403B8CF RID: 243919
			MusicPlayEffect,
			// Token: 0x0403B8D0 RID: 243920
			KeyItem1,
			// Token: 0x0403B8D1 RID: 243921
			KeyItem2,
			// Token: 0x0403B8D2 RID: 243922
			KeyItem3
		}

		// Token: 0x0200C165 RID: 49509
		[NullableContext(0)]
		private enum EScrollState
		{
			// Token: 0x0403B8D4 RID: 243924
			NoScroll,
			// Token: 0x0403B8D5 RID: 243925
			Begin,
			// Token: 0x0403B8D6 RID: 243926
			Scrolling,
			// Token: 0x0403B8D7 RID: 243927
			End
		}

		// Token: 0x0200C166 RID: 49510
		[NullableContext(0)]
		private enum EVisibleReason
		{
			// Token: 0x0403B8D9 RID: 243929
			BossStateArea = 1,
			// Token: 0x0403B8DA RID: 243930
			MotorMusicEnable
		}
	}
}
