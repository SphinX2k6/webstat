using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FD1 RID: 24529
	[NullableContext(2)]
	[Nullable(0)]
	public class BattleSkillItemDynamicEffect
	{
		// Token: 0x0603DB8D RID: 252813 RVA: 0x00FB93C5 File Offset: 0x00FB75C5
		public BattleSkillItemDynamicEffect(UUINiagara UiEffect)
		{
		}

		// Token: 0x0603DB8E RID: 252814 RVA: 0x00FB93EB File Offset: 0x00FB75EB
		public void CancelLoadDynamicEffectNiagara()
		{
			if (this.LoadDynamicEffectNiagaraHandleId == null)
			{
				return;
			}
			Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.LoadDynamicEffectNiagaraHandleId.Value);
			this.LoadDynamicEffectNiagaraHandleId = null;
			this.LoadDynamicEffectPath = null;
		}

		// Token: 0x0603DB8F RID: 252815 RVA: 0x00FB9424 File Offset: 0x00FB7624
		public void RefreshDynamicEffect(SkillButtonEffect? effectConfig)
		{
			this.EffectConfig = effectConfig;
			string text = null;
			if (effectConfig != null)
			{
				SkillButtonEffect value = effectConfig.Value;
				text = this.GetDynamicEffectPath(value);
			}
			this.RefreshDynamicEffectScale(effectConfig);
			if (this.CurrentDynamicEffectPath == text)
			{
				if (this.LoadDynamicEffectPath == null)
				{
					this.RefreshDynamicEffectColor(effectConfig, true);
				}
				return;
			}
			this.CancelLoadDynamicEffectNiagara();
			this.CurrentDynamicEffectPath = text;
			if (this.CurrentDynamicEffectPath == null)
			{
				this.SetDynamicEffectVisible(false);
				return;
			}
			this.LoadDynamicEffectPath = this.CurrentDynamicEffectPath;
			this.LoadDynamicEffectNiagaraHandleId = new int?(Singleton<ResourceSystem>.Instance.LoadAsync<UNiagaraSystem>(this.LoadDynamicEffectPath, delegate([Nullable(2)] UNiagaraSystem effectObject, string _)
			{
				this.LoadDynamicEffectPath = null;
				if (effectObject == null || !effectObject.IsValid())
				{
					return;
				}
				UUINiagara uuiniagara = this.<UiEffect>P;
				if (uuiniagara == null)
				{
					return;
				}
				uuiniagara.SetNiagaraSystem(effectObject);
				this.RefreshDynamicEffectColor(this.EffectConfig, false);
				this.SetDynamicEffectVisible(true);
			}, 100, "js_undefined"));
		}

		// Token: 0x0603DB90 RID: 252816 RVA: 0x00FB94D4 File Offset: 0x00FB76D4
		private void RefreshDynamicEffectColor(SkillButtonEffect? optEffectConfig, bool bReset = false)
		{
			if (optEffectConfig == null)
			{
				return;
			}
			SkillButtonEffect value = optEffectConfig.Value;
			if (value.ElementId == this.DynamicEffectElementId && value.Color == this.DynamicEffectColor)
			{
				return;
			}
			FLinearColor? flinearColor = null;
			this.DynamicEffectColor = value.Color;
			if (!string.IsNullOrEmpty(this.DynamicEffectColor))
			{
				this.DynamicEffectElementId = 0;
				FColor fcolor = FColor.FromHex(this.DynamicEffectColor);
				flinearColor = new FLinearColor?(new FLinearColor(ref fcolor));
			}
			else
			{
				this.DynamicEffectElementId = value.ElementId;
				if (this.DynamicEffectElementId > 0)
				{
					FColor fcolor = FColor.FromHex(ConfigBase<ElementInfoConfig>.Instance.GetElementInfo(this.DynamicEffectElementId).Value.SkillEffectColor);
					flinearColor = new FLinearColor?(new FLinearColor(ref fcolor));
				}
			}
			UUINiagara uuiniagara = this.<UiEffect>P;
			if (flinearColor != null)
			{
				uuiniagara.SetNiagaraVarLinearColor("Color", flinearColor.Value);
				return;
			}
			uuiniagara.ResetOverrideParameters();
			if (bReset && uuiniagara.NiagaraComponent != null)
			{
				uuiniagara.NiagaraComponent.ResetOverrideParametersAndActivate(true, "");
			}
		}

		// Token: 0x0603DB91 RID: 252817 RVA: 0x00FB95F0 File Offset: 0x00FB77F0
		protected void RefreshDynamicEffectScale(SkillButtonEffect? effectConfig)
		{
			float num = (effectConfig != null) ? effectConfig.GetValueOrDefault().Scale : 1f;
			if (this.DynamicEffectScale == num)
			{
				return;
			}
			this.DynamicEffectScale = num;
			UUINiagara uuiniagara = this.<UiEffect>P;
			if (uuiniagara == null)
			{
				return;
			}
			uuiniagara.SetUIItemScale(new FVector(num));
		}

		// Token: 0x0603DB92 RID: 252818 RVA: 0x00FB9644 File Offset: 0x00FB7844
		public void SetDynamicEffectVisible(bool visible)
		{
			UUINiagara uuiniagara = this.<UiEffect>P;
			if (uuiniagara == null)
			{
				return;
			}
			if (!visible)
			{
				if (uuiniagara.bIsUIActive)
				{
					uuiniagara.SetUIActive(false);
				}
				return;
			}
			if (!uuiniagara.bIsUIActive)
			{
				uuiniagara.SetUIActive(true);
				uuiniagara.ActivateSystem(true);
				return;
			}
			uuiniagara.ActivateSystem(true);
		}

		// Token: 0x0603DB93 RID: 252819 RVA: 0x00FB9690 File Offset: 0x00FB7890
		protected string GetDynamicEffectPath(in SkillButtonEffect effectConfig)
		{
			SkillButtonEffect skillButtonEffect = effectConfig;
			string niagaraPath = skillButtonEffect.NiagaraPath;
			if (string.IsNullOrEmpty(niagaraPath))
			{
				return null;
			}
			return niagaraPath;
		}

		// Token: 0x0603DB94 RID: 252820 RVA: 0x00FB96B7 File Offset: 0x00FB78B7
		public void Reset()
		{
			this.CancelLoadDynamicEffectNiagara();
			if (this.DynamicEffectElementId != 0 || this.DynamicEffectColor != null)
			{
				UUINiagara uuiniagara = this.<UiEffect>P;
				if (uuiniagara != null)
				{
					uuiniagara.ResetOverrideParameters();
				}
				this.DynamicEffectElementId = 0;
				this.DynamicEffectColor = null;
			}
		}

		// Token: 0x04022A13 RID: 141843
		[CompilerGenerated]
		private UUINiagara <UiEffect>P = UiEffect;

		// Token: 0x04022A14 RID: 141844
		private int? LoadDynamicEffectNiagaraHandleId = new int?(0);

		// Token: 0x04022A15 RID: 141845
		private string CurrentDynamicEffectPath;

		// Token: 0x04022A16 RID: 141846
		private int DynamicEffectElementId;

		// Token: 0x04022A17 RID: 141847
		private string DynamicEffectColor;

		// Token: 0x04022A18 RID: 141848
		private string LoadDynamicEffectPath;

		// Token: 0x04022A19 RID: 141849
		private float DynamicEffectScale = 1f;

		// Token: 0x04022A1A RID: 141850
		private SkillButtonEffect? EffectConfig;
	}
}
