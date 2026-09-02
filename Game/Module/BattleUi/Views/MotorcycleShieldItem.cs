using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006085 RID: 24709
	[NullableContext(2)]
	[Nullable(0)]
	public class MotorcycleShieldItem : UiPanelBase
	{
		// Token: 0x0603E54C RID: 255308 RVA: 0x00FEB068 File Offset: 0x00FE9268
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUINiagara));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E54D RID: 255309 RVA: 0x00FEB0D4 File Offset: 0x00FE92D4
		protected override void OnStart()
		{
			this.PercentMachine.Duration = 200;
			this.BarSprite = base.GetSprite(0);
			this.BreakEffect = base.GetUiNiagara(1);
			this.BreakEffect.SetUIActive(false);
			this.RefreshBar(true);
			this.AddEvents();
		}

		// Token: 0x0603E54E RID: 255310 RVA: 0x00FEB124 File Offset: 0x00FE9324
		protected override void OnAfterHide()
		{
			base.OnAfterHide();
			this.StopBreakEffect();
		}

		// Token: 0x0603E54F RID: 255311 RVA: 0x00FEB132 File Offset: 0x00FE9332
		protected override void OnBeforeDestroy()
		{
			this.RemoveEvents();
			this.SetExistShield(false);
			this.ExistShieldChanged = null;
		}

		// Token: 0x0603E550 RID: 255312 RVA: 0x00FEB148 File Offset: 0x00FE9348
		private void AddEvents()
		{
			ControllerBase<FormationAttributeController>.Instance.AddValueListener(EFormationAttributeId.MotorcycleShield, new TValueListener(this.OnMotorcycleShieldChanged), null);
			ControllerBase<FormationAttributeController>.Instance.AddMaxListener(EFormationAttributeId.MotorcycleShield, new TValueListener(this.OnMotorcycleShieldChanged), null);
		}

		// Token: 0x0603E551 RID: 255313 RVA: 0x00FEB17C File Offset: 0x00FE937C
		private void RemoveEvents()
		{
			ControllerBase<FormationAttributeController>.Instance.RemoveValueListener(EFormationAttributeId.MotorcycleShield, new TValueListener(this.OnMotorcycleShieldChanged));
			ControllerBase<FormationAttributeController>.Instance.RemoveMaxListener(EFormationAttributeId.MotorcycleShield, new TValueListener(this.OnMotorcycleShieldChanged));
		}

		// Token: 0x0603E552 RID: 255314 RVA: 0x00FEB1AE File Offset: 0x00FE93AE
		private void OnMotorcycleShieldChanged(EFormationAttributeId attributeId, float newValue, float oldValue)
		{
			this.RefreshBar(false);
		}

		// Token: 0x0603E553 RID: 255315 RVA: 0x00FEB1B8 File Offset: 0x00FE93B8
		private void RefreshBar(bool isStart = false)
		{
			float value = ControllerBase<FormationAttributeController>.Instance.GetValue(EFormationAttributeId.MotorcycleShield);
			float max = ControllerBase<FormationAttributeController>.Instance.GetMax(EFormationAttributeId.MotorcycleShield);
			float num = (max > 0f) ? (value / max) : 0f;
			if (isStart)
			{
				this.PercentMachine.Init(num);
				this.SetBarPercent(this.PercentMachine.GetCurPercent());
			}
			else
			{
				if (this.PercentMachine.GetTargetPercent() == 0f && this.PercentMachine.GetCurPercent() != 0f && num > 0f)
				{
					this.PercentMachine.Init(0f);
					this.PlayBreakEffect();
				}
				this.PercentMachine.SetTargetPercent(num);
			}
			this.SetExistShield(num > 0f);
		}

		// Token: 0x0603E554 RID: 255316 RVA: 0x00FEB270 File Offset: 0x00FE9470
		private void SetExistShield(bool existShield)
		{
			if (this.ExistShield != existShield)
			{
				this.ExistShield = existShield;
				Action existShieldChanged = this.ExistShieldChanged;
				if (existShieldChanged == null)
				{
					return;
				}
				existShieldChanged();
			}
		}

		// Token: 0x0603E555 RID: 255317 RVA: 0x00FEB292 File Offset: 0x00FE9492
		private void SetBarPercent(float percent)
		{
			UUISprite barSprite = this.BarSprite;
			if (barSprite == null)
			{
				return;
			}
			barSprite.SetFillAmount(percent);
		}

		// Token: 0x0603E556 RID: 255318 RVA: 0x00FEB2A8 File Offset: 0x00FE94A8
		private void PlayBreakEffect()
		{
			if (this.IsPlayingBreakEffect)
			{
				return;
			}
			this.IsPlayingBreakEffect = true;
			UUINiagara breakEffect = this.BreakEffect;
			if (breakEffect != null)
			{
				breakEffect.SetUIActive(true);
			}
			this.BreakEffectTimer = TimerSystem.Instance.Delay(delegate(float _)
			{
				this.BreakEffectTimer = null;
				this.IsPlayingBreakEffect = false;
				UUINiagara breakEffect2 = this.BreakEffect;
				if (breakEffect2 == null)
				{
					return;
				}
				breakEffect2.SetUIActive(false);
			}, 900f, null, null, true, 1f);
		}

		// Token: 0x0603E557 RID: 255319 RVA: 0x00FEB300 File Offset: 0x00FE9500
		private void StopBreakEffect()
		{
			if (!this.IsPlayingBreakEffect)
			{
				return;
			}
			this.IsPlayingBreakEffect = false;
			if (this.BreakEffectTimer != null)
			{
				TimerSystem.Instance.Remove(this.BreakEffectTimer);
				this.BreakEffectTimer = null;
			}
			UUINiagara breakEffect = this.BreakEffect;
			if (breakEffect == null)
			{
				return;
			}
			breakEffect.SetUIActive(false);
		}

		// Token: 0x0603E558 RID: 255320 RVA: 0x00FEB350 File Offset: 0x00FE9550
		public void Tick(float delta)
		{
			if (this.PercentMachine.Update(delta))
			{
				float curPercent = this.PercentMachine.GetCurPercent();
				this.SetBarPercent(curPercent);
				if (curPercent == 0f)
				{
					this.PlayBreakEffect();
				}
			}
		}

		// Token: 0x04022F04 RID: 143108
		private const int BREAK_ANIM_TIME = 900;

		// Token: 0x04022F05 RID: 143109
		private UUISprite BarSprite;

		// Token: 0x04022F06 RID: 143110
		private UUINiagara BreakEffect;

		// Token: 0x04022F07 RID: 143111
		private bool IsPlayingBreakEffect;

		// Token: 0x04022F08 RID: 143112
		private TimerHandle BreakEffectTimer;

		// Token: 0x04022F09 RID: 143113
		[Nullable(1)]
		private readonly MotorcycleShieldPercentMachine PercentMachine = new MotorcycleShieldPercentMachine();

		// Token: 0x04022F0A RID: 143114
		public bool ExistShield;

		// Token: 0x04022F0B RID: 143115
		public Action ExistShieldChanged;

		// Token: 0x0200C170 RID: 49520
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403B90F RID: 243983
			BarSprite,
			// Token: 0x0403B910 RID: 243984
			BreakEffect
		}
	}
}
