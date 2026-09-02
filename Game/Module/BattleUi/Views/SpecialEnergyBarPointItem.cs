using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006101 RID: 24833
	[NullableContext(1)]
	[Nullable(0)]
	public class SpecialEnergyBarPointItem : UiPanelBase
	{
		// Token: 0x0603EBCD RID: 256973 RVA: 0x0100FE32 File Offset: 0x0100E032
		public void InitPrefabInfo(int pointNum, float pointWidth, bool leftToRight = true)
		{
			this.TotalPointNum = pointNum;
			this.PointWidth = pointWidth;
			this.LeftToRight = leftToRight;
		}

		// Token: 0x0603EBCE RID: 256974 RVA: 0x0100FE4C File Offset: 0x0100E04C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUINiagara));
			this.ComponentRegisterInfos = list;
			for (int i = 0; i < 3; i++)
			{
				this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(i + 3, typeof(UUINiagara)));
			}
		}

		// Token: 0x0603EBCF RID: 256975 RVA: 0x0100FF00 File Offset: 0x0100E100
		protected override void OnStart()
		{
			for (int i = 0; i < 3; i++)
			{
				SpecialEnergyBarPointEffectInfo specialEnergyBarPointEffectInfo = new SpecialEnergyBarPointEffectInfo();
				specialEnergyBarPointEffectInfo.Effect = base.GetUiNiagara(i + 3);
				specialEnergyBarPointEffectInfo.Effect.SetUIActive(false);
				this.PointEffectInfoList.Add(specialEnergyBarPointEffectInfo);
			}
		}

		// Token: 0x0603EBD0 RID: 256976 RVA: 0x0100FF48 File Offset: 0x0100E148
		public void SetFullEffectColor(in FLinearColor color, bool isMorph = false)
		{
			base.GetUiNiagara(1).SetNiagaraVarLinearColor("Color", color);
			base.GetUiNiagara(2).SetNiagaraVarLinearColor("Color", color);
			foreach (SpecialEnergyBarPointEffectInfo specialEnergyBarPointEffectInfo in this.PointEffectInfoList)
			{
				specialEnergyBarPointEffectInfo.Effect.SetNiagaraVarLinearColor("Color", color);
			}
			base.GetUiNiagara(1).SetNiagaraVarFloat("Default", !isMorph);
			base.GetUiNiagara(1).SetNiagaraVarFloat("Shift", isMorph > false);
		}

		// Token: 0x0603EBD1 RID: 256977 RVA: 0x01010004 File Offset: 0x0100E204
		public void SetEffectBasePercent(float value)
		{
			this.SetEffectBasePercents(value, new float?(value), 0, null);
		}

		// Token: 0x0603EBD2 RID: 256978 RVA: 0x01010028 File Offset: 0x0100E228
		public void SetEffectBasePercents(float fullEffectPercent, float? fullBgEffectPercent = null, int fullEffectPointNum = 0, int? fullBgEffectPointNum = null)
		{
			this.FullEffectBasePercent = fullEffectPercent;
			this.FullBgEffectBasePercent = fullBgEffectPercent.GetValueOrDefault(fullEffectPercent);
			this.FullEffectPointNum = fullEffectPointNum;
			this.FullBgEffectPointNum = fullBgEffectPointNum.GetValueOrDefault(fullEffectPointNum);
			base.GetUiNiagara(1).SetNiagaraVarFloat("Dissolve", this.FullEffectBasePercent);
			base.GetUiNiagara(2).SetNiagaraVarFloat("Dissolve", this.FullBgEffectBasePercent);
		}

		// Token: 0x0603EBD3 RID: 256979 RVA: 0x01010090 File Offset: 0x0100E290
		public void UpdatePercent(float percent, bool playPointEffect = true, int pointEffectOffsetNum = 0)
		{
			int num = this.TotalPointNum - pointEffectOffsetNum;
			int num2 = (int)Math.Ceiling((double)(percent * (float)num));
			int num3 = (this.FullEffectPointNum > 0) ? this.FullEffectPointNum : this.TotalPointNum;
			int num4 = (this.FullBgEffectPointNum > 0) ? this.FullBgEffectPointNum : this.TotalPointNum;
			int num5 = (int)Math.Ceiling((double)(percent * (float)num3));
			int num6 = (int)Math.Ceiling((double)(percent * (float)num4));
			float num7 = this.FullEffectBasePercent * (float)num5 / (float)num3;
			float num8 = this.FullBgEffectBasePercent * (float)num6 / (float)num4;
			base.GetUiNiagara(1).SetNiagaraVarFloat("Dissolve", num7);
			base.GetUiNiagara(2).SetNiagaraVarFloat("Dissolve", num8);
			base.GetUiNiagara(1).SetUIActive(num7 > 0f);
			base.GetUiNiagara(2).SetUIActive(num8 > 0f);
			if (playPointEffect && this.CurNum > num2)
			{
				double finishTime = 500.0 + Singleton<Time>.Instance.Now;
				for (int i = Math.Min(num2 + 3, this.CurNum) - 1; i >= num2; i--)
				{
					int num9 = i + pointEffectOffsetNum;
					if (!this.LeftToRight)
					{
						num9 = this.TotalPointNum - num9 - 1;
					}
					float anchorOffsetX = this.PointWidth * (float)(num9 - (this.TotalPointNum - 1) / 2);
					SpecialEnergyBarPointEffectInfo nextPointEffect = this.GetNextPointEffect();
					UUINiagara effect = nextPointEffect.Effect;
					effect.SetAnchorOffsetX(anchorOffsetX);
					if (!nextPointEffect.IsPlaying)
					{
						effect.SetUIActive(true);
					}
					effect.ActivateSystem(true);
					nextPointEffect.IsPlaying = true;
					nextPointEffect.FinishTime = finishTime;
				}
				this.IsAnyEffectPlaying = true;
			}
			this.CurNum = num2;
		}

		// Token: 0x0603EBD4 RID: 256980 RVA: 0x0101022E File Offset: 0x0100E42E
		public void UpdatePercentWithVisible(float percent, bool visible, bool changeVisible, bool isStart)
		{
			if (changeVisible || isStart)
			{
				this.RootItem.SetUIActive(visible);
			}
			if (visible)
			{
				this.UpdatePercent(percent, !changeVisible && !isStart, 0);
			}
		}

		// Token: 0x0603EBD5 RID: 256981 RVA: 0x01010258 File Offset: 0x0100E458
		public void UpdateLeftRightPercent(float leftPercent, float rightPercent)
		{
			int num = (int)Math.Ceiling((double)(leftPercent * (float)this.TotalPointNum));
			int num2 = (int)Math.Ceiling((double)(rightPercent * (float)this.TotalPointNum));
			if (this.LeftNum == num && this.RightNum == num2)
			{
				return;
			}
			this.LeftNum = num;
			this.RightNum = num2;
			float anchorOffsetX = this.PointWidth * (float)num;
			base.GetItem(0).SetAnchorOffsetX(anchorOffsetX);
			float value = (float)(num2 - num) / (float)this.TotalPointNum;
			base.GetUiNiagara(1).SetNiagaraVarFloat("Dissolve", value);
			base.GetUiNiagara(2).SetNiagaraVarFloat("Dissolve", value);
		}

		// Token: 0x0603EBD6 RID: 256982 RVA: 0x010102F0 File Offset: 0x0100E4F0
		private SpecialEnergyBarPointEffectInfo GetNextPointEffect()
		{
			SpecialEnergyBarPointEffectInfo result = this.PointEffectInfoList[this.NextPointEffectIndex];
			this.NextPointEffectIndex++;
			if (this.NextPointEffectIndex >= 3)
			{
				this.NextPointEffectIndex = 0;
			}
			return result;
		}

		// Token: 0x0603EBD7 RID: 256983 RVA: 0x01010324 File Offset: 0x0100E524
		public void Tick(float delta)
		{
			if (!this.IsAnyEffectPlaying)
			{
				return;
			}
			this.IsAnyEffectPlaying = false;
			foreach (SpecialEnergyBarPointEffectInfo specialEnergyBarPointEffectInfo in this.PointEffectInfoList)
			{
				if (specialEnergyBarPointEffectInfo.IsPlaying)
				{
					if (specialEnergyBarPointEffectInfo.FinishTime <= Singleton<Time>.Instance.Now)
					{
						specialEnergyBarPointEffectInfo.Effect.SetUIActive(false);
						specialEnergyBarPointEffectInfo.IsPlaying = false;
					}
					else
					{
						this.IsAnyEffectPlaying = true;
					}
				}
			}
		}

		// Token: 0x0603EBD8 RID: 256984 RVA: 0x010103B8 File Offset: 0x0100E5B8
		public void ReplaceFullEffect(UNiagaraSystem niagara)
		{
			UUINiagara uiNiagara = base.GetUiNiagara(1);
			if (this.DefaultFullEffectNiagara == null)
			{
				this.DefaultFullEffectNiagara = uiNiagara.NiagaraSystemReference;
			}
			uiNiagara.SetNiagaraSystem(niagara);
		}

		// Token: 0x0603EBD9 RID: 256985 RVA: 0x010103E8 File Offset: 0x0100E5E8
		public void ResetFullEffect()
		{
			if (this.DefaultFullEffectNiagara != null)
			{
				base.GetUiNiagara(1).SetNiagaraSystem(this.DefaultFullEffectNiagara);
				this.DefaultFullEffectNiagara = null;
			}
		}

		// Token: 0x0603EBDA RID: 256986 RVA: 0x0101040B File Offset: 0x0100E60B
		protected override void OnBeforeDestroy()
		{
			this.ResetFullEffect();
		}

		// Token: 0x040232F4 RID: 144116
		private const int POINT_EFFECT_NUM = 3;

		// Token: 0x040232F5 RID: 144117
		private const double EFFECT_DURATION = 500.0;

		// Token: 0x040232F6 RID: 144118
		private int TotalPointNum = 1;

		// Token: 0x040232F7 RID: 144119
		private float PointWidth;

		// Token: 0x040232F8 RID: 144120
		private bool LeftToRight = true;

		// Token: 0x040232F9 RID: 144121
		private int CurNum;

		// Token: 0x040232FA RID: 144122
		private int LeftNum;

		// Token: 0x040232FB RID: 144123
		private int RightNum;

		// Token: 0x040232FC RID: 144124
		private readonly List<SpecialEnergyBarPointEffectInfo> PointEffectInfoList = new List<SpecialEnergyBarPointEffectInfo>();

		// Token: 0x040232FD RID: 144125
		private int NextPointEffectIndex;

		// Token: 0x040232FE RID: 144126
		private bool IsAnyEffectPlaying;

		// Token: 0x040232FF RID: 144127
		private float FullEffectBasePercent = 1f;

		// Token: 0x04023300 RID: 144128
		private float FullBgEffectBasePercent = 1f;

		// Token: 0x04023301 RID: 144129
		private int FullEffectPointNum;

		// Token: 0x04023302 RID: 144130
		private int FullBgEffectPointNum;

		// Token: 0x04023303 RID: 144131
		[Nullable(2)]
		private UNiagaraSystem DefaultFullEffectNiagara;

		// Token: 0x0200C28B RID: 49803
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403BF9D RID: 245661
			EffectMaskItem,
			// Token: 0x0403BF9E RID: 245662
			FullEffect,
			// Token: 0x0403BF9F RID: 245663
			FullBgEffect,
			// Token: 0x0403BFA0 RID: 245664
			PointEffect1
		}
	}
}
