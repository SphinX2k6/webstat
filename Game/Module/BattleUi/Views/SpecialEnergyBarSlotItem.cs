using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006104 RID: 24836
	public class SpecialEnergyBarSlotItem : UiPanelBase
	{
		// Token: 0x0603EBEC RID: 257004 RVA: 0x010109C8 File Offset: 0x0100EBC8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603EBED RID: 257005 RVA: 0x01010B1C File Offset: 0x0100ED1C
		protected override void OnStart()
		{
			base.GetSprite(0).SetUIActive(true);
			base.GetSprite(1).SetUIActive(true);
			base.GetSprite(7).SetUIActive(true);
			base.GetSprite(8).SetUIActive(true);
			base.GetUiNiagara(3).SetUIActive(false);
			base.GetUiNiagara(4).SetUIActive(false);
			base.GetUiNiagara(5).SetUIActive(false);
			base.GetUiNiagara(6).SetUIActive(false);
			this.InitUseEffectOffsetX = base.GetUiNiagara(6).GetAnchorOffsetX();
			UUISprite sprite = base.GetSprite(7);
			base.GetSprite(8).SetStretchLeft(sprite.GetStretchLeft());
			this.InitStretchRight = sprite.GetStretchRight();
			this.InitWidth = sprite.Width;
			this.InitTileX = sprite.tileX;
		}

		// Token: 0x0603EBEE RID: 257006 RVA: 0x01010BE1 File Offset: 0x0100EDE1
		public void SetBarColor(in FColor color)
		{
			base.GetSprite(1).SetColor(color);
		}

		// Token: 0x0603EBEF RID: 257007 RVA: 0x01010BF5 File Offset: 0x0100EDF5
		public void SetPointBgColor(in FColor color)
		{
			base.GetSprite(7).SetColor(color);
		}

		// Token: 0x0603EBF0 RID: 257008 RVA: 0x01010C09 File Offset: 0x0100EE09
		public void SetPointColor(in FColor color)
		{
			base.GetSprite(8).SetColor(color);
		}

		// Token: 0x0603EBF1 RID: 257009 RVA: 0x01010C20 File Offset: 0x0100EE20
		public void SetFullEffectColor(in FLinearColor color, bool isMorph = false)
		{
			base.GetUiNiagara(3).SetNiagaraVarLinearColor("Color", color);
			base.GetUiNiagara(4).SetNiagaraVarLinearColor("Color", color);
			base.GetUiNiagara(6).SetNiagaraVarLinearColor("Color", color);
			base.GetUiNiagara(3).SetNiagaraVarFloat("Default", !isMorph);
			base.GetUiNiagara(3).SetNiagaraVarFloat("Shift", isMorph > false);
		}

		// Token: 0x0603EBF2 RID: 257010 RVA: 0x01010C9E File Offset: 0x0100EE9E
		public void SetBgAndUseEffectColor(in FLinearColor color)
		{
			base.GetUiNiagara(4).SetNiagaraVarLinearColor("Color", color);
			base.GetUiNiagara(6).SetNiagaraVarLinearColor("Color", color);
		}

		// Token: 0x0603EBF3 RID: 257011 RVA: 0x01010CCE File Offset: 0x0100EECE
		public void SetChangeEffectColor(in FLinearColor color)
		{
			base.GetUiNiagara(5).SetNiagaraVarLinearColor("Color", color);
		}

		// Token: 0x0603EBF4 RID: 257012 RVA: 0x01010CE8 File Offset: 0x0100EEE8
		public void SetEffectBasePercent(float value)
		{
			this.EffectBasePercent = value;
			base.GetUiNiagara(3).SetNiagaraVarFloat("Dissolve", this.EffectBasePercent);
			base.GetUiNiagara(4).SetNiagaraVarFloat("Dissolve", this.EffectBasePercent);
			base.GetUiNiagara(5).SetNiagaraVarFloat("Dissolve", this.EffectBasePercent);
			base.GetUiNiagara(6).SetNiagaraVarFloat("Dissolve", this.EffectBasePercent);
		}

		// Token: 0x0603EBF5 RID: 257013 RVA: 0x01010D58 File Offset: 0x0100EF58
		public void SetFullEffectPercent(float value)
		{
			base.GetUiNiagara(3).SetNiagaraVarFloat("Dissolve", value);
		}

		// Token: 0x0603EBF6 RID: 257014 RVA: 0x01010D6C File Offset: 0x0100EF6C
		public void SetUseEffectMode(EUseEffectMode mode)
		{
			if (this.UseEffectMode == mode)
			{
				return;
			}
			this.UseEffectMode = mode;
		}

		// Token: 0x0603EBF7 RID: 257015 RVA: 0x01010D80 File Offset: 0x0100EF80
		public void UpdatePercent(float percent, bool fullEffectEnable, bool ignoreUseEffect = false)
		{
			int num = 0;
			if ((double)percent <= 1E-08)
			{
				num = -1;
			}
			else if ((double)percent >= 0.99999999 && fullEffectEnable)
			{
				num = 1;
			}
			if (this.State != num)
			{
				if (num == -1)
				{
					base.GetSprite(0).SetUIActive(true);
					base.GetSprite(7).SetUIActive(true);
					base.GetSprite(8).SetUIActive(false);
					base.GetSprite(1).SetUIActive(false);
					base.GetUiNiagara(3).SetUIActive(false);
					base.GetUiNiagara(4).SetUIActive(false);
					base.GetUiNiagara(5).SetUIActive(false);
					if (this.State == 1 && !ignoreUseEffect)
					{
						this.PlayUseEffect(false);
					}
				}
				else if (num == 1)
				{
					base.GetSprite(0).SetUIActive(false);
					base.GetSprite(7).SetUIActive(false);
					base.GetSprite(8).SetUIActive(false);
					base.GetSprite(1).SetUIActive(false);
					base.GetUiNiagara(3).SetUIActive(true);
					base.GetUiNiagara(4).SetUIActive(true);
					base.GetUiNiagara(6).SetUIActive(false);
					this.PlayChangeEffect();
				}
				else
				{
					base.GetSprite(0).SetUIActive(true);
					base.GetSprite(7).SetUIActive(true);
					base.GetSprite(8).SetUIActive(true);
					base.GetSprite(1).SetUIActive(true);
					base.GetUiNiagara(3).SetUIActive(false);
					base.GetUiNiagara(4).SetUIActive(false);
					base.GetUiNiagara(5).SetUIActive(false);
					if (this.State == 1 && !ignoreUseEffect)
					{
						this.PlayUseEffect(false);
					}
				}
				this.State = num;
			}
			if (num == 0)
			{
				base.GetSprite(1).SetFillAmount(percent);
				this.SetPointPercent(percent);
			}
		}

		// Token: 0x0603EBF8 RID: 257016 RVA: 0x01010F34 File Offset: 0x0100F134
		public void UpdatePercentWithVisible(float percent, bool visible, bool changeVisible, bool isStart, float lastPercent)
		{
			if (visible)
			{
				base.GetSprite(1).SetFillAmount(percent);
				this.SetPointPercent(percent);
			}
			if (isStart)
			{
				base.GetSprite(0).SetUIActive(visible);
				base.GetSprite(1).SetUIActive(visible);
				base.GetSprite(7).SetUIActive(visible);
				base.GetSprite(8).SetUIActive(visible);
				base.GetUiNiagara(5).SetUIActive(false);
				base.GetUiNiagara(6).SetUIActive(false);
				return;
			}
			if (changeVisible)
			{
				base.GetSprite(0).SetUIActive(visible);
				base.GetSprite(1).SetUIActive(visible);
				base.GetSprite(7).SetUIActive(visible);
				base.GetSprite(8).SetUIActive(visible);
				if (visible)
				{
					base.GetUiNiagara(5).SetUIActive(false);
				}
				else
				{
					base.GetUiNiagara(5).SetNiagaraVarFloat("Dissolve", percent * this.EffectBasePercent);
					this.PlayChangeEffect();
				}
				if (visible && percent == 0f)
				{
					base.GetUiNiagara(6).SetNiagaraVarFloat("Dissolve", lastPercent * this.EffectBasePercent);
					this.PlayUseEffect(false);
					return;
				}
				base.GetUiNiagara(6).SetUIActive(false);
			}
		}

		// Token: 0x0603EBF9 RID: 257017 RVA: 0x01011050 File Offset: 0x0100F250
		public void UpdatePercentWithFullEffect(float fullEffectPercent, float fullBgEffectPercent, bool isStart)
		{
			if (isStart)
			{
				base.GetSprite(1).SetUIActive(false);
				base.GetSprite(8).SetUIActive(false);
				base.GetUiNiagara(5).SetUIActive(false);
				base.GetUiNiagara(6).SetUIActive(false);
				base.GetUiNiagara(3).SetUIActive(true);
				base.GetUiNiagara(4).SetUIActive(true);
			}
			base.GetUiNiagara(3).SetNiagaraVarFloat("Dissolve", fullEffectPercent);
			base.GetUiNiagara(4).SetNiagaraVarFloat("Dissolve", fullBgEffectPercent);
			base.GetUiNiagara(3).SetUIActive(fullEffectPercent > 0f);
			base.GetUiNiagara(4).SetUIActive(fullBgEffectPercent > 0f);
			this.UpdateUseEffectByMode(fullEffectPercent, isStart);
		}

		// Token: 0x0603EBFA RID: 257018 RVA: 0x01011104 File Offset: 0x0100F304
		public void UpdatePercentWithFullEffectEnable(float percent, bool fullEffectEnable, bool ignoreUseEffect = false)
		{
			int num = 0;
			if ((double)percent <= 1E-08)
			{
				num = -1;
			}
			else if (fullEffectEnable)
			{
				if ((double)percent < 0.99999999)
				{
					num = 1;
				}
				else
				{
					num = 2;
				}
			}
			if (this.State != num)
			{
				if (num == -1)
				{
					base.GetSprite(0).SetUIActive(true);
					base.GetSprite(7).SetUIActive(true);
					base.GetSprite(8).SetUIActive(false);
					base.GetSprite(1).SetUIActive(false);
					base.GetUiNiagara(3).SetUIActive(false);
					base.GetUiNiagara(4).SetUIActive(false);
					base.GetUiNiagara(5).SetUIActive(false);
					if (this.State == 1 && !ignoreUseEffect)
					{
						this.PlayUseEffect(false);
					}
				}
				else if (num == 1)
				{
					base.GetSprite(0).SetUIActive(false);
					base.GetSprite(7).SetUIActive(true);
					base.GetSprite(8).SetUIActive(false);
					base.GetSprite(1).SetUIActive(false);
					base.GetUiNiagara(3).SetUIActive(true);
					base.GetUiNiagara(4).SetUIActive(true);
					base.GetUiNiagara(6).SetUIActive(false);
					this.PlayChangeEffect();
				}
				else if (num == 2)
				{
					base.GetSprite(0).SetUIActive(false);
					base.GetSprite(7).SetUIActive(false);
					base.GetSprite(8).SetUIActive(false);
					base.GetSprite(1).SetUIActive(false);
					base.GetUiNiagara(3).SetUIActive(true);
					base.GetUiNiagara(4).SetUIActive(true);
					base.GetUiNiagara(6).SetUIActive(false);
					this.PlayChangeEffect();
				}
				else
				{
					base.GetSprite(0).SetUIActive(true);
					base.GetSprite(7).SetUIActive(true);
					base.GetSprite(8).SetUIActive(true);
					base.GetSprite(1).SetUIActive(true);
					base.GetUiNiagara(3).SetUIActive(false);
					base.GetUiNiagara(4).SetUIActive(false);
					base.GetUiNiagara(5).SetUIActive(false);
					if (this.State == 1 && !ignoreUseEffect)
					{
						this.PlayUseEffect(false);
					}
				}
				this.State = num;
			}
			if (num == 0)
			{
				base.GetSprite(1).SetFillAmount(percent);
				this.SetPointPercent(percent);
				return;
			}
			if (num == 1 || num == 2)
			{
				base.GetUiNiagara(3).SetNiagaraVarFloat("Dissolve", percent);
				base.GetUiNiagara(4).SetNiagaraVarFloat("Dissolve", percent);
			}
		}

		// Token: 0x0603EBFB RID: 257019 RVA: 0x01011350 File Offset: 0x0100F550
		private void SetPointPercent(float percent)
		{
			float num = Math.Max(0f, Math.Min(1f, percent));
			UUISprite sprite = base.GetSprite(8);
			sprite.SetStretchRight(this.InitStretchRight + this.InitWidth * (1f - num));
			sprite.SetTileX(this.InitTileX * num);
		}

		// Token: 0x0603EBFC RID: 257020 RVA: 0x010113A2 File Offset: 0x0100F5A2
		public void SetBarPercent(float percent)
		{
			base.GetSprite(1).SetUIActive(true);
			base.GetSprite(1).SetFillAmount(percent);
		}

		// Token: 0x0603EBFD RID: 257021 RVA: 0x010113BE File Offset: 0x0100F5BE
		public void PlayUseEffectWithPercent(float percent)
		{
			base.GetUiNiagara(6).SetNiagaraVarFloat("Dissolve", percent * this.EffectBasePercent);
			this.PlayUseEffect(false);
		}

		// Token: 0x0603EBFE RID: 257022 RVA: 0x010113E0 File Offset: 0x0100F5E0
		public void UpdateUseEffectByMode(float percent, bool isStart = false)
		{
			float num = Math.Max(0f, Math.Min(1f, percent));
			if (this.LastUseEffectPercent < 0f || isStart)
			{
				this.LastUseEffectPercent = num;
				return;
			}
			float lastUseEffectPercent = this.LastUseEffectPercent;
			this.LastUseEffectPercent = num;
			EUseEffectMode useEffectMode = this.UseEffectMode;
			if (useEffectMode != EUseEffectMode.Default && useEffectMode == EUseEffectMode.EnergyDecreaseSegment)
			{
				this.PlayUseEffectSegment(num, lastUseEffectPercent);
			}
		}

		// Token: 0x0603EBFF RID: 257023 RVA: 0x01011440 File Offset: 0x0100F640
		private void PlayUseEffectSegment(float startPercent, float endPercent)
		{
			float num = Math.Max(0f, Math.Min(1f, startPercent));
			float num2 = Math.Max(0f, Math.Min(1f, endPercent)) - num;
			if ((double)num2 <= 1E-08)
			{
				return;
			}
			base.GetUiNiagara(6).SetNiagaraVarFloat("Dissolve", num2 * this.EffectBasePercent);
			this.SetUseEffectOffsetXByPercent(num);
			this.PlayUseEffect(true);
		}

		// Token: 0x0603EC00 RID: 257024 RVA: 0x010114B0 File Offset: 0x0100F6B0
		private void PlayChangeEffect()
		{
			base.GetUiNiagara(5).SetUIActive(true);
			this.IsAnyEffectPlaying = true;
			this.ChangeEffectFinishTime = 500.0 + Singleton<Time>.Instance.Now;
		}

		// Token: 0x0603EC01 RID: 257025 RVA: 0x010114E0 File Offset: 0x0100F6E0
		public void PlayChangeEffectWithPercent(float percent)
		{
			base.GetUiNiagara(5).SetNiagaraVarFloat("Dissolve", percent);
			this.PlayChangeEffect();
		}

		// Token: 0x0603EC02 RID: 257026 RVA: 0x010114FC File Offset: 0x0100F6FC
		public void SetChangeEffectOffsetX(float offsetX)
		{
			UUINiagara uiNiagara = base.GetUiNiagara(5);
			if (!this.IsChangeEffectOffsetModify)
			{
				this.IsChangeEffectOffsetModify = true;
				this.DefaultChangeEffectOffsetX = uiNiagara.GetAnchorOffsetX();
			}
			uiNiagara.SetAnchorOffsetX(offsetX);
		}

		// Token: 0x0603EC03 RID: 257027 RVA: 0x01011534 File Offset: 0x0100F734
		private void PlayUseEffect(bool restart = false)
		{
			UUINiagara uiNiagara = base.GetUiNiagara(6);
			if (restart)
			{
				uiNiagara.SetUIActive(false);
			}
			uiNiagara.SetUIActive(true);
			this.IsAnyEffectPlaying = true;
			this.UseEffectFinishTime = 500.0 + Singleton<Time>.Instance.Now;
		}

		// Token: 0x0603EC04 RID: 257028 RVA: 0x0101157C File Offset: 0x0100F77C
		private void SetUseEffectOffsetXByPercent(float percent)
		{
			UUIItem uiNiagara = base.GetUiNiagara(6);
			UUIItem item = base.GetItem(2);
			float num = (item != null) ? item.Width : base.GetRootItem().Width;
			uiNiagara.SetAnchorOffsetX(this.InitUseEffectOffsetX + num * percent);
		}

		// Token: 0x0603EC05 RID: 257029 RVA: 0x010115C0 File Offset: 0x0100F7C0
		public void Tick(float delta)
		{
			if (!this.IsAnyEffectPlaying)
			{
				return;
			}
			this.IsAnyEffectPlaying = false;
			if (this.ChangeEffectFinishTime > 0.0)
			{
				if (this.ChangeEffectFinishTime <= Singleton<Time>.Instance.Now)
				{
					base.GetUiNiagara(5).SetUIActive(false);
					this.ChangeEffectFinishTime = 0.0;
				}
				else
				{
					this.IsAnyEffectPlaying = true;
				}
			}
			if (this.UseEffectFinishTime > 0.0)
			{
				if (this.UseEffectFinishTime <= Singleton<Time>.Instance.Now)
				{
					base.GetUiNiagara(6).SetUIActive(false);
					this.UseEffectFinishTime = 0.0;
					return;
				}
				this.IsAnyEffectPlaying = true;
			}
		}

		// Token: 0x0603EC06 RID: 257030 RVA: 0x0101166C File Offset: 0x0100F86C
		[NullableContext(1)]
		public void ReplaceFullEffect(UNiagaraSystem niagara)
		{
			UUINiagara uiNiagara = base.GetUiNiagara(3);
			if (this.DefaultFullEffectNiagara == null)
			{
				this.DefaultFullEffectNiagara = uiNiagara.NiagaraSystemReference;
			}
			uiNiagara.SetNiagaraSystem(niagara);
		}

		// Token: 0x0603EC07 RID: 257031 RVA: 0x0101169C File Offset: 0x0100F89C
		public void RevertFullEffect()
		{
			if (this.DefaultFullEffectNiagara != null)
			{
				base.GetUiNiagara(3).SetNiagaraSystem(this.DefaultFullEffectNiagara);
				this.DefaultFullEffectNiagara = null;
			}
		}

		// Token: 0x0603EC08 RID: 257032 RVA: 0x010116C0 File Offset: 0x0100F8C0
		public void SetFullEffectOffsetX(float offsetX)
		{
			UUINiagara uiNiagara = base.GetUiNiagara(3);
			if (!this.IsFullEffectOffsetModify)
			{
				this.IsFullEffectOffsetModify = true;
				this.DefaultFullEffectOffsetX = uiNiagara.GetAnchorOffsetX();
			}
			uiNiagara.SetAnchorOffsetX(offsetX);
		}

		// Token: 0x0603EC09 RID: 257033 RVA: 0x010116F7 File Offset: 0x0100F8F7
		public void SetFullEffectVisible(bool visible)
		{
			base.GetUiNiagara(3).SetUIActive(visible);
		}

		// Token: 0x0603EC0A RID: 257034 RVA: 0x01011708 File Offset: 0x0100F908
		protected override void OnBeforeDestroy()
		{
			if (this.DefaultFullEffectNiagara != null)
			{
				base.GetUiNiagara(3).SetNiagaraSystem(this.DefaultFullEffectNiagara);
				this.DefaultFullEffectNiagara = null;
			}
			if (this.IsFullEffectOffsetModify)
			{
				base.GetUiNiagara(3).SetAnchorOffsetX(this.DefaultFullEffectOffsetX);
				this.IsFullEffectOffsetModify = false;
			}
			if (this.IsChangeEffectOffsetModify)
			{
				base.GetUiNiagara(5).SetAnchorOffsetX(this.DefaultChangeEffectOffsetX);
				this.IsChangeEffectOffsetModify = false;
			}
			base.GetUiNiagara(6).SetAnchorOffsetX(this.InitUseEffectOffsetX);
		}

		// Token: 0x0402330E RID: 144142
		private const double EFFECT_DURATION = 500.0;

		// Token: 0x0402330F RID: 144143
		protected int State;

		// Token: 0x04023310 RID: 144144
		private bool IsAnyEffectPlaying;

		// Token: 0x04023311 RID: 144145
		private double ChangeEffectFinishTime;

		// Token: 0x04023312 RID: 144146
		private double UseEffectFinishTime;

		// Token: 0x04023313 RID: 144147
		private float EffectBasePercent = 1f;

		// Token: 0x04023314 RID: 144148
		private float InitStretchRight;

		// Token: 0x04023315 RID: 144149
		private float InitWidth;

		// Token: 0x04023316 RID: 144150
		private float InitTileX;

		// Token: 0x04023317 RID: 144151
		[Nullable(2)]
		private UNiagaraSystem DefaultFullEffectNiagara;

		// Token: 0x04023318 RID: 144152
		private float DefaultFullEffectOffsetX = -1f;

		// Token: 0x04023319 RID: 144153
		private bool IsFullEffectOffsetModify;

		// Token: 0x0402331A RID: 144154
		private float DefaultChangeEffectOffsetX = -1f;

		// Token: 0x0402331B RID: 144155
		private bool IsChangeEffectOffsetModify;

		// Token: 0x0402331C RID: 144156
		private EUseEffectMode UseEffectMode;

		// Token: 0x0402331D RID: 144157
		private float InitUseEffectOffsetX;

		// Token: 0x0402331E RID: 144158
		private float LastUseEffectPercent = -1f;

		// Token: 0x0200C28E RID: 49806
		private enum EChildType
		{
			// Token: 0x0403BFAC RID: 245676
			BgSprite,
			// Token: 0x0403BFAD RID: 245677
			BarSprite,
			// Token: 0x0403BFAE RID: 245678
			EffectMaskItem,
			// Token: 0x0403BFAF RID: 245679
			FullEffect,
			// Token: 0x0403BFB0 RID: 245680
			FullBgEffect,
			// Token: 0x0403BFB1 RID: 245681
			ChangeEffect,
			// Token: 0x0403BFB2 RID: 245682
			UseEffect,
			// Token: 0x0403BFB3 RID: 245683
			PointBgSprite,
			// Token: 0x0403BFB4 RID: 245684
			PointFgSprite
		}
	}
}
