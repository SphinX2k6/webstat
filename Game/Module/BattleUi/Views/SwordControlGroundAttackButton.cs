using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.Input.Enum;
using CSharpScript.Core.Common;
using CSharpScript.Game.Input;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006116 RID: 24854
	[NullableContext(2)]
	[Nullable(0)]
	public class SwordControlGroundAttackButton : UiPanelBase
	{
		// Token: 0x17009AD7 RID: 39639
		// (get) Token: 0x0603EC7D RID: 257149 RVA: 0x01013909 File Offset: 0x01011B09
		private static CSharpScript.Game.Input.EInputAction AttackAction
		{
			get
			{
				return CSharpScript.Game.Input.EInputAction.攻击;
			}
		}

		// Token: 0x17009AD8 RID: 39640
		// (get) Token: 0x0603EC7E RID: 257150 RVA: 0x01013910 File Offset: 0x01011B10
		[Nullable(1)]
		private static string AttackActionName
		{
			[NullableContext(1)]
			get
			{
				return SwordControlGroundAttackButton.AttackAction.Name;
			}
		}

		// Token: 0x0603EC7F RID: 257151 RVA: 0x0101391C File Offset: 0x01011B1C
		public SwordControlGroundAttackButton()
		{
			base.SkipDestroyActor = true;
		}

		// Token: 0x0603EC80 RID: 257152 RVA: 0x0101392C File Offset: 0x01011B2C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 13;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUINiagara));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603EC81 RID: 257153 RVA: 0x01013B08 File Offset: 0x01011D08
		protected override void OnStart()
		{
			this.SkillButton = base.GetButton(5);
			this.ClickEffect = new BattleUiNiagaraItem(base.GetUiNiagara(10));
			this.SkillNameText = base.GetText(11);
			UUIText skillNameText = this.SkillNameText;
			if (skillNameText != null)
			{
				skillNameText.SetUIActive(false);
			}
			UUINiagara uiNiagara = base.GetUiNiagara(6);
			if (uiNiagara != null)
			{
				uiNiagara.SetNiagaraUIActive(false, false);
			}
			UUINiagara uiNiagara2 = base.GetUiNiagara(7);
			if (uiNiagara2 != null)
			{
				uiNiagara2.SetNiagaraUIActive(false, true);
			}
			UUINiagara uiNiagara3 = base.GetUiNiagara(12);
			if (uiNiagara3 != null)
			{
				uiNiagara3.SetNiagaraUIActive(false, true);
			}
			this.BindButtonEvent();
			this.BindInputAction();
			this.SetInteractive(this.IsInteractive, true);
		}

		// Token: 0x0603EC82 RID: 257154 RVA: 0x01013BAB File Offset: 0x01011DAB
		protected override void OnBeforeDestroy()
		{
			this.ReleaseAttackInput();
			this.UnBindInputAction();
			this.UnBindButtonEvent();
			BattleUiNiagaraItem clickEffect = this.ClickEffect;
			if (clickEffect != null)
			{
				clickEffect.Stop();
			}
			this.ClickEffect = null;
			this.SkillButton = null;
			this.SkillNameText = null;
		}

		// Token: 0x0603EC83 RID: 257155 RVA: 0x01013BE5 File Offset: 0x01011DE5
		public void SetInteractive(bool interactive, bool force = false)
		{
			if (this.IsInteractive == interactive && !force)
			{
				return;
			}
			this.IsInteractive = interactive;
			UUIButtonComponent skillButton = this.SkillButton;
			if (skillButton != null)
			{
				skillButton.SetSelfInteractive(interactive);
			}
			if (!interactive)
			{
				this.ReleaseAttackInput();
			}
		}

		// Token: 0x0603EC84 RID: 257156 RVA: 0x01013C18 File Offset: 0x01011E18
		private void BindButtonEvent()
		{
			UUIButtonComponent skillButton = this.SkillButton;
			if (skillButton != null)
			{
				skillButton.OnPointDownCallBack.Bind(new Action(this.OnPressButton));
			}
			UUIButtonComponent skillButton2 = this.SkillButton;
			if (skillButton2 != null)
			{
				skillButton2.OnPointUpCallBack.Bind(new Action(this.OnReleaseButton));
			}
			UUIButtonComponent skillButton3 = this.SkillButton;
			if (skillButton3 == null)
			{
				return;
			}
			skillButton3.OnPointCancelCallBack.Bind(new Action(this.OnReleaseButton));
		}

		// Token: 0x0603EC85 RID: 257157 RVA: 0x01013C8C File Offset: 0x01011E8C
		private void UnBindButtonEvent()
		{
			UUIButtonComponent skillButton = this.SkillButton;
			if (skillButton != null)
			{
				skillButton.OnPointDownCallBack.Unbind();
			}
			UUIButtonComponent skillButton2 = this.SkillButton;
			if (skillButton2 != null)
			{
				skillButton2.OnPointUpCallBack.Unbind();
			}
			UUIButtonComponent skillButton3 = this.SkillButton;
			if (skillButton3 == null)
			{
				return;
			}
			skillButton3.OnPointCancelCallBack.Unbind();
		}

		// Token: 0x0603EC86 RID: 257158 RVA: 0x01013CDA File Offset: 0x01011EDA
		private void BindInputAction()
		{
			if (this.HasBindInputAction || Singleton<Info>.Instance.OperationType == EOperationType.Pad)
			{
				return;
			}
			ControllerBase<InputDistributeController>.Instance.BindAction(SwordControlGroundAttackButton.AttackActionName, new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
			this.HasBindInputAction = true;
		}

		// Token: 0x0603EC87 RID: 257159 RVA: 0x01013D14 File Offset: 0x01011F14
		private void UnBindInputAction()
		{
			if (!this.HasBindInputAction)
			{
				return;
			}
			ControllerBase<InputDistributeController>.Instance.UnBindAction(SwordControlGroundAttackButton.AttackActionName, new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
			this.HasBindInputAction = false;
		}

		// Token: 0x0603EC88 RID: 257160 RVA: 0x01013D41 File Offset: 0x01011F41
		[NullableContext(1)]
		private void OnInputAction(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification inputIdentification)
		{
			if (this.HasPressedAttackInput || actionName != SwordControlGroundAttackButton.AttackActionName || actionType != InputDistributeDefine.EActionType.Press)
			{
				return;
			}
			if (!this.CanPlayClickEffect())
			{
				return;
			}
			BattleUiNiagaraItem clickEffect = this.ClickEffect;
			if (clickEffect == null)
			{
				return;
			}
			clickEffect.Play();
		}

		// Token: 0x0603EC89 RID: 257161 RVA: 0x01013D78 File Offset: 0x01011F78
		private void OnPressButton()
		{
			if (!this.CanPlayClickEffect() || this.HasPressedAttackInput)
			{
				return;
			}
			BattleUiNiagaraItem clickEffect = this.ClickEffect;
			if (clickEffect != null)
			{
				clickEffect.Play();
			}
			this.HasPressedAttackInput = true;
			if (!ControllerBase<InputDistributeController>.Instance.InputAction(SwordControlGroundAttackButton.AttackActionName, true) && Singleton<Info>.Instance.OperationType != EOperationType.Pad)
			{
				ControllerBase<InputController>.Instance.InputAction(SwordControlGroundAttackButton.AttackAction, EInputState.Press);
			}
		}

		// Token: 0x0603EC8A RID: 257162 RVA: 0x01013DDD File Offset: 0x01011FDD
		private void OnReleaseButton()
		{
			this.ReleaseAttackInput();
		}

		// Token: 0x0603EC8B RID: 257163 RVA: 0x01013DE5 File Offset: 0x01011FE5
		private bool CanPlayClickEffect()
		{
			if (this.IsInteractive && base.IsUiActiveInHierarchy())
			{
				BattleInputModel instance = ModelBase<BattleInputModel>.Instance;
				return instance == null || instance.GetInputEnable(SwordControlGroundAttackButton.AttackAction);
			}
			return false;
		}

		// Token: 0x0603EC8C RID: 257164 RVA: 0x01013E10 File Offset: 0x01012010
		private void ReleaseAttackInput()
		{
			if (!this.HasPressedAttackInput)
			{
				return;
			}
			this.HasPressedAttackInput = false;
			if (!ControllerBase<InputDistributeController>.Instance.InputAction(SwordControlGroundAttackButton.AttackActionName, false) && Singleton<Info>.Instance.OperationType != EOperationType.Pad)
			{
				ControllerBase<InputController>.Instance.InputAction(SwordControlGroundAttackButton.AttackAction, EInputState.Release);
			}
		}

		// Token: 0x0603EC8D RID: 257165 RVA: 0x01013E5C File Offset: 0x0101205C
		public void SetSkillNameText(string textStringId)
		{
			if (string.IsNullOrEmpty(textStringId))
			{
				UUIText skillNameText = this.SkillNameText;
				if (skillNameText == null)
				{
					return;
				}
				skillNameText.SetUIActive(false);
				return;
			}
			else
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(this.SkillNameText, textStringId, Array.Empty<object>());
				UUIText skillNameText2 = this.SkillNameText;
				if (skillNameText2 == null)
				{
					return;
				}
				skillNameText2.SetUIActive(true);
				return;
			}
		}

		// Token: 0x0402336E RID: 144238
		private UUIButtonComponent SkillButton;

		// Token: 0x0402336F RID: 144239
		private BattleUiNiagaraItem ClickEffect;

		// Token: 0x04023370 RID: 144240
		private UUIText SkillNameText;

		// Token: 0x04023371 RID: 144241
		private bool IsInteractive;

		// Token: 0x04023372 RID: 144242
		private bool HasBindInputAction;

		// Token: 0x04023373 RID: 144243
		private bool HasPressedAttackInput;

		// Token: 0x0200C29F RID: 49823
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403C004 RID: 245764
			CoolDownItem,
			// Token: 0x0403C005 RID: 245765
			CoolDownBarSprite,
			// Token: 0x0403C006 RID: 245766
			CoolDownText,
			// Token: 0x0403C007 RID: 245767
			SkillSprite,
			// Token: 0x0403C008 RID: 245768
			SkillTexture,
			// Token: 0x0403C009 RID: 245769
			SkillButton,
			// Token: 0x0403C00A RID: 245770
			CdCompletedNiagara,
			// Token: 0x0403C00B RID: 245771
			DynamicEffectNiagara,
			// Token: 0x0403C00C RID: 245772
			ExtraContainer,
			// Token: 0x0403C00D RID: 245773
			ExploreSkillEquip,
			// Token: 0x0403C00E RID: 245774
			ClickEffectNiagara,
			// Token: 0x0403C00F RID: 245775
			SkillNameText,
			// Token: 0x0403C010 RID: 245776
			LinkExplosionNiagara
		}
	}
}
