using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Input;
using CSharpScript.Game.InputSetting;
using CSharpScript.Game.Module.SkillButtonUi;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FCD RID: 24525
	[NullableContext(2)]
	[Nullable(0)]
	public class BattleSkillGamepadItem : BattleSkillItem
	{
		// Token: 0x17009A6D RID: 39533
		// (get) Token: 0x0603DAA6 RID: 252582 RVA: 0x00FB5D0F File Offset: 0x00FB3F0F
		public bool IsMainButton
		{
			get
			{
				return this.ButtonAreaType == EGamepadButtonAreaType.Main;
			}
		}

		// Token: 0x17009A6E RID: 39534
		// (get) Token: 0x0603DAA7 RID: 252583 RVA: 0x00FB5D1A File Offset: 0x00FB3F1A
		public bool IsSubButton
		{
			get
			{
				return this.ButtonAreaType == EGamepadButtonAreaType.Sub;
			}
		}

		// Token: 0x17009A6F RID: 39535
		// (get) Token: 0x0603DAA8 RID: 252584 RVA: 0x00FB5D25 File Offset: 0x00FB3F25
		public bool IsLeftButton
		{
			get
			{
				return this.ButtonAreaType == EGamepadButtonAreaType.Left;
			}
		}

		// Token: 0x0603DAA9 RID: 252585 RVA: 0x00FB5D30 File Offset: 0x00FB3F30
		public override void Initialize(object param = null)
		{
			base.Initialize(param);
			if (!(param is int))
			{
				throw new InvalidCastException();
			}
			int num = (int)param;
			if (num < 4)
			{
				this.ButtonAreaType = EGamepadButtonAreaType.Main;
				return;
			}
			if (num < 8)
			{
				this.ButtonAreaType = EGamepadButtonAreaType.Main;
				this.IsSecondButton = true;
				this.CdFixedPoint = 0;
				UUIText coolDownUiText = this.CoolDownUiText;
				if (coolDownUiText != null)
				{
					coolDownUiText.SetUIItemScale(new FVector(1.667f, 1.667f, 1f));
				}
				this.IsHideNumComp = true;
				return;
			}
			if (num < 12)
			{
				this.ButtonAreaType = EGamepadButtonAreaType.Left;
				this.CdFixedPoint = 0;
				UUIText coolDownUiText2 = this.CoolDownUiText;
				if (coolDownUiText2 != null)
				{
					coolDownUiText2.SetUIItemScale(new FVector(1.667f, 1.667f, 1f));
				}
				this.IsHideNumComp = true;
				return;
			}
			this.ButtonAreaType = EGamepadButtonAreaType.Sub;
			this.CdFixedPoint = 1;
		}

		// Token: 0x0603DAAA RID: 252586 RVA: 0x00FB5DFC File Offset: 0x00FB3FFC
		[NullableContext(1)]
		public void SetKeyName(string keyName)
		{
			this.KeyName = keyName;
			if (this.IsMainButton || this.IsLeftButton)
			{
				this.KeyItem.SetActive(false);
				return;
			}
			InputKeyItemData singleInputKeyItemData = new InputKeyItemData
			{
				KeyName = this.KeyName
			};
			this.KeyItem.RefreshByKeyList(singleInputKeyItemData, null);
			this.KeyItem.SetActive(true);
		}

		// Token: 0x0603DAAB RID: 252587 RVA: 0x00FB5E58 File Offset: 0x00FB4058
		public override void Refresh(ISkillButtonData skillButtonData)
		{
			if (skillButtonData == null && this.IsSecondButton)
			{
				this.Deactivate();
				return;
			}
			if (this.IsSecondButton && this.SrcBehaviorButtonData == null && skillButtonData != null && skillButtonData.GetButtonType() == ESkillButtonType.幻象1)
			{
				SkillButtonUiGamepadDataBase gamepadData = this.GamepadData;
				if (gamepadData != null && gamepadData.SwitchInteractData.IsSwitchInteractOpen && this.GamepadData.SwitchInteractData.State == EGamepadSwitchInteractState.Explore)
				{
					this.Deactivate();
					return;
				}
			}
			bool flag = this.SkillButtonData != null || this.BehaviorButtonData != null;
			this.BehaviorButtonData = null;
			if (skillButtonData == null)
			{
				if (flag || !this.IsRefreshOnce)
				{
					this.IsRefreshOnce = true;
					this.RefreshWhenDisable();
				}
				return;
			}
			if (this.SkillButtonData != skillButtonData)
			{
				this.OnCoolDownFinishedCallback = null;
			}
			base.Refresh(skillButtonData);
			if (this.SrcBehaviorButtonData != null)
			{
				this.SwitchInteract(false, null);
			}
		}

		// Token: 0x0603DAAC RID: 252588 RVA: 0x00FB5F28 File Offset: 0x00FB4128
		public void SwitchInteract(bool enable, SkillButtonData skillButtonData = null)
		{
			if (enable)
			{
				this.SrcBehaviorButtonData = this.BehaviorButtonData;
				this.BehaviorButtonData = null;
				this.OnCoolDownFinishedCallback = null;
				base.Refresh(skillButtonData);
			}
			else
			{
				this.SrcBehaviorButtonData = null;
			}
			if (this.SwitchInteractItem != null)
			{
				this.SwitchInteractItem.RefreshEnable(enable);
				return;
			}
			if (enable)
			{
				this.SwitchInteractItem = new BattleSkillSwitchInteractItem();
				this.SwitchInteractItem.Init(base.GetExtraContainer());
				this.SwitchInteractItem.RefreshEnable(true);
			}
		}

		// Token: 0x0603DAAD RID: 252589 RVA: 0x00FB5FA4 File Offset: 0x00FB41A4
		private void RefreshWhenDisable()
		{
			if (this.SrcBehaviorButtonData != null)
			{
				this.SwitchInteract(false, null);
			}
			if (!this.IsMainButton)
			{
				this.Deactivate();
				return;
			}
			this.SkillButtonData = null;
			base.SetSkillIcon(this.GamepadData.NoneIcon);
			this.RefreshSkillName();
			base.ResetSkillCoolDown();
			this.SetTextureHandleId = 0;
			this.OnCoolDownFinishedCallback = null;
			this.KeyActionName = null;
			this.KeyOperationType = null;
			this.PressActionType = EInputAction.None;
			this.RefreshDynamicEffect();
			base.CancelLoadDynamicEffectNiagara();
			base.CancelLoadCdCompletedNiagara();
			BattleSkillUltraItem ultraComponent = this.UltraComponent;
			if (ultraComponent != null)
			{
				ultraComponent.SetComponentActive(false);
			}
			BattleSkillNumItem numComponent = this.NumComponent;
			if (numComponent != null)
			{
				numComponent.SetComponentActive(false);
			}
			BattleSkillDotIndicatorItem dotIndicatorComponent = this.DotIndicatorComponent;
			if (dotIndicatorComponent != null)
			{
				dotIndicatorComponent.SetComponentActive(false);
			}
			BattleSkillSwitchComponent switchComponent = this.SwitchComponent;
			if (switchComponent != null)
			{
				switchComponent.SetComponentActive(false);
			}
			BattleSkillLongPressItem longPressComponent = this.LongPressComponent;
			if (longPressComponent != null)
			{
				longPressComponent.SetComponentActive(false);
			}
			BattleSkillConfigLongPressItem configLongPressComponent = this.ConfigLongPressComponent;
			if (configLongPressComponent != null)
			{
				configLongPressComponent.SetComponentActive(false);
			}
			BattleSkillExtraEffectItem extraEffectComponent = this.ExtraEffectComponent;
			if (extraEffectComponent != null)
			{
				extraEffectComponent.SetComponentActive(false);
			}
			if (!base.IsShowOrShowing)
			{
				base.Show(null);
			}
		}

		// Token: 0x0603DAAE RID: 252590 RVA: 0x00FB60BF File Offset: 0x00FB42BF
		public override void RefreshVisible()
		{
			if (!this.IsMainButton)
			{
				base.RefreshVisible();
				return;
			}
			if (!this.IsVisible())
			{
				this.RefreshWhenDisable();
				return;
			}
			if (!base.IsShowOrShowing)
			{
				base.Show(null);
			}
		}

		// Token: 0x0603DAAF RID: 252591 RVA: 0x00FB60EE File Offset: 0x00FB42EE
		public override void RefreshEnable(bool bForce = false)
		{
			if (this.BehaviorButtonData != null)
			{
				base.SetSkillItemEnable(this.BehaviorButtonData.IsEnable(), bForce);
				return;
			}
			base.RefreshEnable(bForce);
		}

		// Token: 0x0603DAB0 RID: 252592 RVA: 0x00FB6112 File Offset: 0x00FB4312
		public override void RefreshSkillCoolDown()
		{
			if (this.SkillButtonData == null)
			{
				base.FinishSkillCoolDown();
				return;
			}
			base.RefreshSkillCoolDown();
		}

		// Token: 0x0603DAB1 RID: 252593 RVA: 0x00FB612C File Offset: 0x00FB432C
		public void PlaySwitchCd()
		{
			this.HideCdText = true;
			SkillButtonUiGamepadDataBase gamepadData = this.GamepadData;
			float num = (float)((gamepadData != null) ? gamepadData.SwitchInteractData.SwitchTime : 0) * (float)Singleton<TimeUtil>.Instance.Millisecond;
			base.PlaySkillTimeDown((double)num, (double)num, null);
		}

		// Token: 0x0603DAB2 RID: 252594 RVA: 0x00FB6170 File Offset: 0x00FB4370
		[NullableContext(1)]
		public void RefreshByBehaviorButtonData(BehaviorButtonData behaviorButtonData)
		{
			this.SkillButtonData = null;
			this.BehaviorButtonData = behaviorButtonData;
			if (behaviorButtonData.ButtonType == 104)
			{
				SkillButtonUiGamepadDataBase gamepadData = this.GamepadData;
				if (gamepadData != null && gamepadData.SwitchInteractData.IsSwitchInteractOpen && this.GamepadData.SwitchInteractData.State == EGamepadSwitchInteractState.Explore)
				{
					SkillButtonData skillButtonDataByButton = ModelBase<SkillButtonUiModel>.Instance.GetSkillButtonDataByButton(ESkillButtonType.幻象1);
					if (skillButtonDataByButton != null && skillButtonDataByButton.IsVisible())
					{
						skillButtonDataByButton.GetSkillId();
						this.SwitchInteract(true, skillButtonDataByButton);
						return;
					}
				}
			}
			base.ResetSkillCoolDown();
			this.SetTextureHandleId = 0;
			this.OnCoolDownFinishedCallback = null;
			this.PressActionType = EInputAction.None;
			this.RefreshDynamicEffect();
			base.CancelLoadDynamicEffectNiagara();
			base.CancelLoadCdCompletedNiagara();
			BattleSkillUltraItem ultraComponent = this.UltraComponent;
			if (ultraComponent != null)
			{
				ultraComponent.SetComponentActive(false);
			}
			BattleSkillNumItem numComponent = this.NumComponent;
			if (numComponent != null)
			{
				numComponent.SetComponentActive(false);
			}
			BattleSkillDotIndicatorItem dotIndicatorComponent = this.DotIndicatorComponent;
			if (dotIndicatorComponent != null)
			{
				dotIndicatorComponent.SetComponentActive(false);
			}
			BattleSkillSwitchComponent switchComponent = this.SwitchComponent;
			if (switchComponent != null)
			{
				switchComponent.SetComponentActive(false);
			}
			BattleSkillLongPressItem longPressComponent = this.LongPressComponent;
			if (longPressComponent != null)
			{
				longPressComponent.SetComponentActive(false);
			}
			BattleSkillConfigLongPressItem configLongPressComponent = this.ConfigLongPressComponent;
			if (configLongPressComponent != null)
			{
				configLongPressComponent.SetComponentActive(false);
			}
			BattleSkillExtraEffectItem extraEffectComponent = this.ExtraEffectComponent;
			if (extraEffectComponent != null)
			{
				extraEffectComponent.SetComponentActive(false);
			}
			this.RefreshVisible();
			this.RefreshSkillIcon();
			this.RefreshSkillName();
			this.RefreshKey();
			this.RefreshEnable(false);
			if (this.SrcBehaviorButtonData != null)
			{
				this.SwitchInteract(false, null);
			}
		}

		// Token: 0x0603DAB3 RID: 252595 RVA: 0x00FB62C6 File Offset: 0x00FB44C6
		[NullableContext(1)]
		protected override bool CheckSkillIconIsTexture(string skillIconPath)
		{
			return this.SkillButtonData != null && base.CheckSkillIconIsTexture(skillIconPath);
		}

		// Token: 0x0603DAB4 RID: 252596 RVA: 0x00FB62D9 File Offset: 0x00FB44D9
		public override void RefreshSkillIcon()
		{
			if (this.BehaviorButtonData != null)
			{
				base.SetSkillIcon(this.BehaviorButtonData.GetSkillTexturePath());
				return;
			}
			base.RefreshSkillIcon();
		}

		// Token: 0x0603DAB5 RID: 252597 RVA: 0x00FB62FC File Offset: 0x00FB44FC
		public override bool IsVisible()
		{
			if (this.GamepadData.GetIsPressCombineButton() && (this.KeyName == EKey.Gamepad_LeftTrigger || this.KeyName == EKey.Gamepad_RightTrigger))
			{
				return false;
			}
			if (this.BehaviorButtonData != null)
			{
				return this.BehaviorButtonData.IsVisible();
			}
			ISkillButtonData skillButtonData = this.SkillButtonData;
			return (skillButtonData != null && skillButtonData.GetButtonType() == ESkillButtonType.副开火 && this.GamepadData.IsAim()) || base.IsVisible();
		}

		// Token: 0x0603DAB6 RID: 252598 RVA: 0x00FB6387 File Offset: 0x00FB4587
		public override void Deactivate()
		{
			base.Deactivate();
			this.IsRefreshOnce = false;
		}

		// Token: 0x0603DAB7 RID: 252599 RVA: 0x00FB6396 File Offset: 0x00FB4596
		public override void Reset()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.Clear();
			}
			this.LevelSequencePlayer = null;
			base.Reset();
		}

		// Token: 0x0603DAB8 RID: 252600 RVA: 0x00FB63B6 File Offset: 0x00FB45B6
		public override void RefreshKey()
		{
			if (this.IsMainButton || this.IsLeftButton)
			{
				this.KeyItem.SetActive(false);
				return;
			}
			this.SetKeyName(this.KeyName);
			this.KeyItem.SetActive(true);
		}

		// Token: 0x0603DAB9 RID: 252601 RVA: 0x00FB63ED File Offset: 0x00FB45ED
		public override void OnInputAction(bool bForcePlayClickEffect = false)
		{
			if (this.BehaviorButtonData != null)
			{
				if (this.BehaviorButtonData.IsEnable() && this.BehaviorButtonData.IsVisible())
				{
					BattleUiNiagaraItem clickEffect = this.ClickEffect;
					if (clickEffect == null)
					{
						return;
					}
					clickEffect.Play();
				}
				return;
			}
			base.OnInputAction(bForcePlayClickEffect);
		}

		// Token: 0x0603DABA RID: 252602 RVA: 0x00FB642C File Offset: 0x00FB462C
		public void PlayPressCombineButtonSeq()
		{
			this.InitLevelSequencePlayer();
			this.LevelSequencePlayer.StopCurrentSequence(false, false);
			this.LevelSequencePlayer.PlaySequencePurely("ClickLbIn", false, false, null, null, false);
			this.CombinePressTipSprite.SetUIActive(true);
			this.IsPlayPressSeq = true;
			BattleUiNiagaraItem clickEffect = this.ClickEffect;
			if (clickEffect == null)
			{
				return;
			}
			clickEffect.Stop();
		}

		// Token: 0x0603DABB RID: 252603 RVA: 0x00FB648C File Offset: 0x00FB468C
		public void PlayReleaseCombineButtonSeq()
		{
			if (!this.IsPlayPressSeq)
			{
				return;
			}
			this.IsPlayPressSeq = false;
			this.InitLevelSequencePlayer();
			this.LevelSequencePlayer.StopCurrentSequence(false, false);
			this.LevelSequencePlayer.PlaySequencePurely("ClickLbOut", false, false, null, null, false);
			this.CombinePressTipSprite.SetUIActive(false);
			BattleUiNiagaraItem clickEffect = this.ClickEffect;
			if (clickEffect == null)
			{
				return;
			}
			clickEffect.Stop();
		}

		// Token: 0x0603DABC RID: 252604 RVA: 0x00FB64F5 File Offset: 0x00FB46F5
		private void InitLevelSequencePlayer()
		{
			if (this.LevelSequencePlayer != null)
			{
				return;
			}
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		}

		// Token: 0x040229C6 RID: 141766
		public SkillButtonUiGamepadDataBase GamepadData;

		// Token: 0x040229C7 RID: 141767
		public EGamepadButtonAreaType ButtonAreaType;

		// Token: 0x040229C8 RID: 141768
		public bool IsSecondButton;

		// Token: 0x040229C9 RID: 141769
		[Nullable(1)]
		private string KeyName = string.Empty;

		// Token: 0x040229CA RID: 141770
		private bool IsRefreshOnce;

		// Token: 0x040229CB RID: 141771
		public BehaviorButtonData BehaviorButtonData;

		// Token: 0x040229CC RID: 141772
		public BehaviorButtonData SrcBehaviorButtonData;

		// Token: 0x040229CD RID: 141773
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x040229CE RID: 141774
		private bool IsPlayPressSeq;

		// Token: 0x040229CF RID: 141775
		private BattleSkillSwitchInteractItem SwitchInteractItem;
	}
}
