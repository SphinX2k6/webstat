using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060C0 RID: 24768
	public class SpecialEnergyBarJingRanSlot : SpecialEnergyBarSlot
	{
		// Token: 0x0603E8D4 RID: 256212 RVA: 0x00FFF643 File Offset: 0x00FFD843
		public void MarkStateChange()
		{
			this.IsWaitingStateChange = false;
		}

		// Token: 0x0603E8D5 RID: 256213 RVA: 0x00FFF64C File Offset: 0x00FFD84C
		public void SetStrengthState(bool isStrength)
		{
			if (this.IsInStrengthState == isStrength)
			{
				return;
			}
			this.IsInStrengthState = isStrength;
			this.IsWaitingStateChange = false;
			base.SetUseEffectMode(this.IsInStrengthState ? EUseEffectMode.EnergyDecreaseSegment : EUseEffectMode.Default);
		}

		// Token: 0x0603E8D6 RID: 256214 RVA: 0x00FFF678 File Offset: 0x00FFD878
		[NullableContext(1)]
		protected override UniTask InitSlotItem(UUIItem slotItem)
		{
			SpecialEnergyBarJingRanSlot.<InitSlotItem>d__17 <InitSlotItem>d__;
			<InitSlotItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitSlotItem>d__.<>4__this = this;
			<InitSlotItem>d__.slotItem = slotItem;
			<InitSlotItem>d__.<>1__state = -1;
			<InitSlotItem>d__.<>t__builder.Start<SpecialEnergyBarJingRanSlot.<InitSlotItem>d__17>(ref <InitSlotItem>d__);
			return <InitSlotItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603E8D7 RID: 256215 RVA: 0x00FFF6C4 File Offset: 0x00FFD8C4
		protected override void OnStart()
		{
			this.OverrideColor = true;
			for (int i = 0; i < this.SlotItemList.Count; i++)
			{
				this.SetItemStyle(i, this.Config.EffectColor, this.Config.PointColor);
			}
			base.OnStart();
		}

		// Token: 0x0603E8D8 RID: 256216 RVA: 0x00FFF714 File Offset: 0x00FFD914
		[NullableContext(1)]
		private void SetItemStyle(int index, string barColor, string pointColor)
		{
			SpecialEnergyBarSlotItem specialEnergyBarSlotItem = this.SlotItemList[index];
			FColor fcolor = FColor.FromHex(barColor);
			specialEnergyBarSlotItem.SetBarColor(fcolor);
			SpecialEnergyBarSlotItem specialEnergyBarSlotItem2 = this.SlotItemList[index];
			fcolor = FColor.FromHex(pointColor);
			specialEnergyBarSlotItem2.SetPointColor(fcolor);
		}

		// Token: 0x0603E8D9 RID: 256217 RVA: 0x00FFF758 File Offset: 0x00FFD958
		protected override void OnInitData()
		{
			base.OnInitData();
			this.CurrentPercent = base.GetTargetAttributePercent();
			this.CurrentPercent = base.GetTargetAttributePercent();
			SpecialEnergyBarInfo config = this.Config;
			this.FadeOutTime = ((config != null) ? config.ExtraFloatParams[0] : SpecialEnergyBarJingRanSlot.DEFAULT_FADE_OUT_TIME);
			SpecialEnergyBarInfo config2 = this.Config;
			this.ConsumeTime = ((config2 != null) ? config2.ExtraFloatParams[1] : SpecialEnergyBarJingRanSlot.DEFAULT_CONSUME_TIME);
		}

		// Token: 0x0603E8DA RID: 256218 RVA: 0x00FFF7C7 File Offset: 0x00FFD9C7
		protected override void OnAttributeChanged()
		{
			this.CurrentPercent = base.GetTargetAttributePercent();
			this.OnBarPercentChanged();
		}

		// Token: 0x0603E8DB RID: 256219 RVA: 0x00FFF7DB File Offset: 0x00FFD9DB
		protected override void OnMaxAttributeChanged()
		{
			this.CurrentPercent = base.GetTargetAttributePercent();
			this.OnBarPercentChanged();
		}

		// Token: 0x0603E8DC RID: 256220 RVA: 0x00FFF7F0 File Offset: 0x00FFD9F0
		private float CalcConsumeEnergyLength(int slotIndex)
		{
			float currentPercent = this.CurrentPercent;
			float num = (float)slotIndex / (float)this.SlotNum;
			float num2 = (float)(slotIndex + 1) / (float)this.SlotNum;
			if (this.BarPercent < num2)
			{
				num2 = this.BarPercent;
			}
			if (currentPercent > num)
			{
				num = currentPercent;
			}
			return (num2 - num) * (float)this.SlotNum;
		}

		// Token: 0x0603E8DD RID: 256221 RVA: 0x00FFF840 File Offset: 0x00FFDA40
		private void SetAllItemAlpha(float alpha)
		{
			for (int i = 0; i < this.SlotItemList.Count; i++)
			{
				SpecialEnergyBarJingRanSlot.SpecialEnergyBarJingRanSlotItem specialEnergyBarJingRanSlotItem = this.SlotItemList[i] as SpecialEnergyBarJingRanSlot.SpecialEnergyBarJingRanSlotItem;
				if (specialEnergyBarJingRanSlotItem != null)
				{
					specialEnergyBarJingRanSlotItem.SetFullEffectAlpha(alpha);
				}
				if (specialEnergyBarJingRanSlotItem != null)
				{
					specialEnergyBarJingRanSlotItem.SetConsumeEffectAlpha(alpha);
				}
			}
		}

		// Token: 0x0603E8DE RID: 256222 RVA: 0x00FFF890 File Offset: 0x00FFDA90
		public override void Tick(float delta)
		{
			base.Tick(delta);
			if (!this.IsPlayingConsumeAnim())
			{
				return;
			}
			float delta2 = delta / (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
			this.UpdateConsume(delta2);
			this.UpdateFadeOut(delta2);
			this.UpdateWaitingTime(delta2);
			if (!this.IsPlayingConsumeAnim())
			{
				this.RefreshBarPercent(false);
			}
		}

		// Token: 0x0603E8DF RID: 256223 RVA: 0x00FFF8E0 File Offset: 0x00FFDAE0
		protected override void RefreshBarPercent(bool isStart = false)
		{
			if (this.IsPlayingConsumeAnim() && this.IsInStrengthState)
			{
				return;
			}
			float currentPercent = this.CurrentPercent;
			float barPercent = this.BarPercent;
			bool isInStrengthState = this.IsInStrengthState;
			if (barPercent <= currentPercent)
			{
				this.SetConsumeEffectActive(false);
				this.SetAllItemAlpha(1f);
			}
			else if (isInStrengthState)
			{
				this.SetConsumeEffectActive(true);
				this.RemainingFadeOutTime = this.FadeOutTime;
				this.RemainingConsumeTime = this.ConsumeTime;
				this.WaitingTime = 0f;
				this.IsWaitingStateChange = true;
			}
			bool keyEnable = this.GetKeyEnable();
			for (int i = 0; i < this.SlotItemList.Count; i++)
			{
				SpecialEnergyBarJingRanSlot.SpecialEnergyBarJingRanSlotItem specialEnergyBarJingRanSlotItem = this.SlotItemList[i] as SpecialEnergyBarJingRanSlot.SpecialEnergyBarJingRanSlotItem;
				float num = currentPercent * (float)this.SlotNum - (float)i;
				specialEnergyBarJingRanSlotItem.EnableFullEffect(keyEnable || this.IsPlayingConsumeAnim());
				if (keyEnable || this.IsPlayingConsumeAnim())
				{
					specialEnergyBarJingRanSlotItem.UpdatePercentWithFullEffect(num, num * SpecialEnergyBarJingRanSlot.BaseBgEffectLength, isStart);
					specialEnergyBarJingRanSlotItem.UpdateTextEffectPercent(num);
				}
				else
				{
					specialEnergyBarJingRanSlotItem.UpdatePercentWithFullEffectEnable(num, false, false);
				}
				specialEnergyBarJingRanSlotItem.SetConsumeEffectOffsetX(num);
				float percent = this.CalcConsumeEnergyLength(i);
				specialEnergyBarJingRanSlotItem.UpdateConsumePercent(percent);
				if (isInStrengthState)
				{
					specialEnergyBarJingRanSlotItem.UpdateUseEffectByMode(num, isStart);
				}
			}
			SpecialEnergyBarKeyItem keyItem = this.KeyItem;
			if (keyItem != null)
			{
				keyItem.RefreshKeyEnable(keyEnable, isStart);
			}
			this.BarPercent = currentPercent;
		}

		// Token: 0x0603E8E0 RID: 256224 RVA: 0x00FFFA2C File Offset: 0x00FFDC2C
		private void UpdateConsume(float delta)
		{
			if (this.RemainingConsumeTime <= 0f)
			{
				return;
			}
			this.RemainingConsumeTime -= delta;
			float consumeEffectAlpha = Singleton<MathUtils>.Instance.Clamp(this.RemainingConsumeTime / this.ConsumeTime, 0f, 1f);
			for (int i = 0; i < this.SlotItemList.Count; i++)
			{
				(this.SlotItemList[i] as SpecialEnergyBarJingRanSlot.SpecialEnergyBarJingRanSlotItem).SetConsumeEffectAlpha(consumeEffectAlpha);
			}
		}

		// Token: 0x0603E8E1 RID: 256225 RVA: 0x00FFFAA4 File Offset: 0x00FFDCA4
		private void UpdateFadeOut(float delta)
		{
			if (this.RemainingFadeOutTime <= 0f)
			{
				return;
			}
			this.RemainingFadeOutTime -= delta;
			float fullEffectAlpha = Singleton<MathUtils>.Instance.Clamp(this.RemainingFadeOutTime / this.FadeOutTime, 0f, 1f);
			for (int i = 0; i < this.SlotItemList.Count; i++)
			{
				(this.SlotItemList[i] as SpecialEnergyBarJingRanSlot.SpecialEnergyBarJingRanSlotItem).SetFullEffectAlpha(fullEffectAlpha);
			}
		}

		// Token: 0x0603E8E2 RID: 256226 RVA: 0x00FFFB1C File Offset: 0x00FFDD1C
		private void UpdateWaitingTime(float delta)
		{
			if (!this.IsWaitingStateChange)
			{
				return;
			}
			this.WaitingTime += delta;
			if ((double)this.WaitingTime >= (double)this.FadeOutTime + 0.15)
			{
				this.IsWaitingStateChange = false;
			}
		}

		// Token: 0x0603E8E3 RID: 256227 RVA: 0x00FFFB56 File Offset: 0x00FFDD56
		protected override bool GetKeyEnable()
		{
			return this.IsKeyEnable;
		}

		// Token: 0x0603E8E4 RID: 256228 RVA: 0x00FFFB60 File Offset: 0x00FFDD60
		private void SetConsumeEffectActive(bool active)
		{
			if (this.IsConsumeEffectActive == active)
			{
				return;
			}
			for (int i = 0; i < this.SlotItemList.Count; i++)
			{
				SpecialEnergyBarJingRanSlot.SpecialEnergyBarJingRanSlotItem specialEnergyBarJingRanSlotItem = this.SlotItemList[i] as SpecialEnergyBarJingRanSlot.SpecialEnergyBarJingRanSlotItem;
				if (specialEnergyBarJingRanSlotItem != null)
				{
					specialEnergyBarJingRanSlotItem.SetConsumeEffectActive(active);
				}
			}
			this.IsConsumeEffectActive = active;
		}

		// Token: 0x0603E8E5 RID: 256229 RVA: 0x00FFFBB1 File Offset: 0x00FFDDB1
		public void SetKeyEnable(bool enable)
		{
			this.IsKeyEnable = enable;
			SpecialEnergyBarKeyItem keyItem = this.KeyItem;
			if (keyItem != null)
			{
				keyItem.RefreshKeyEnable(enable, true);
			}
			this.RefreshBarPercent(false);
		}

		// Token: 0x0603E8E6 RID: 256230 RVA: 0x00FFFBD4 File Offset: 0x00FFDDD4
		public bool IsPlayingConsumeAnim()
		{
			return this.RemainingFadeOutTime > 0f || this.RemainingConsumeTime > 0f || this.IsWaitingStateChange;
		}

		// Token: 0x0402310F RID: 143631
		private bool IsKeyEnable;

		// Token: 0x04023110 RID: 143632
		private float CurrentPercent;

		// Token: 0x04023111 RID: 143633
		private float BarPercent;

		// Token: 0x04023112 RID: 143634
		private float FadeOutTime;

		// Token: 0x04023113 RID: 143635
		private float ConsumeTime;

		// Token: 0x04023114 RID: 143636
		private float RemainingFadeOutTime;

		// Token: 0x04023115 RID: 143637
		private float RemainingConsumeTime;

		// Token: 0x04023116 RID: 143638
		private static readonly float BaseBgEffectLength = 0.4f;

		// Token: 0x04023117 RID: 143639
		private bool IsConsumeEffectActive;

		// Token: 0x04023118 RID: 143640
		private float WaitingTime;

		// Token: 0x04023119 RID: 143641
		private bool IsInStrengthState;

		// Token: 0x0402311A RID: 143642
		private bool IsWaitingStateChange;

		// Token: 0x0402311B RID: 143643
		private static readonly float DEFAULT_FADE_OUT_TIME = 1.2f;

		// Token: 0x0402311C RID: 143644
		private static readonly float DEFAULT_CONSUME_TIME = 0.5f;

		// Token: 0x0200C1F5 RID: 49653
		private class SpecialEnergyBarJingRanSlotItem : SpecialEnergyBarSlotItem
		{
			// Token: 0x0604E5B6 RID: 320950 RVA: 0x015B7FFC File Offset: 0x015B61FC
			protected override void OnStart()
			{
				base.OnStart();
				base.GetUiNiagara(9).SetUIActive(false);
				base.GetUiNiagara(3).SetUIActive(true);
				base.GetUiNiagara(4).SetUIActive(true);
				base.GetUiNiagara(10).SetUIActive(true);
				this.InitConsumeEffectOffsetX = base.GetUiNiagara(9).GetAnchorOffsetX();
			}

			// Token: 0x0604E5B7 RID: 320951 RVA: 0x015B8058 File Offset: 0x015B6258
			protected override void OnRegisterComponent()
			{
				base.OnRegisterComponent();
				this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(9, typeof(UUINiagara)));
				this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(10, typeof(UUINiagara)));
			}

			// Token: 0x0604E5B8 RID: 320952 RVA: 0x015B8098 File Offset: 0x015B6298
			public void UpdateConsumePercent(float percent)
			{
				base.GetUiNiagara(9).SetNiagaraVarFloat("Dissolve", percent);
			}

			// Token: 0x0604E5B9 RID: 320953 RVA: 0x015B80AD File Offset: 0x015B62AD
			public void UpdateTextEffectPercent(float percent)
			{
				base.GetUiNiagara(10).SetNiagaraVarFloat("Dissolve", percent);
			}

			// Token: 0x0604E5BA RID: 320954 RVA: 0x015B80C2 File Offset: 0x015B62C2
			public void SetConsumeEffectActive(bool active)
			{
				if (this.IsConsumeEffectActive == active)
				{
					return;
				}
				base.GetUiNiagara(9).SetUIActive(active);
				this.SetConsumeEffectAlpha(active > false);
				this.IsConsumeEffectActive = active;
			}

			// Token: 0x0604E5BB RID: 320955 RVA: 0x015B80F0 File Offset: 0x015B62F0
			public void SetConsumeEffectOffsetX(float percent)
			{
				float num = percent;
				if (num < 0f)
				{
					num = 0f;
				}
				if (num > 1f)
				{
					num = 1f;
				}
				UUINiagara uiNiagara = base.GetUiNiagara(9);
				float width = base.GetRootItem().Width;
				if (uiNiagara == null)
				{
					return;
				}
				uiNiagara.SetAnchorOffsetX(this.InitConsumeEffectOffsetX + width * num);
			}

			// Token: 0x0604E5BC RID: 320956 RVA: 0x015B8144 File Offset: 0x015B6344
			public void EnableFullEffect(bool enable)
			{
				bool? isFullEffectEnable = this.IsFullEffectEnable;
				if (isFullEffectEnable.GetValueOrDefault() == enable & isFullEffectEnable != null)
				{
					return;
				}
				this.IsFullEffectEnable = new bool?(enable);
				base.GetUiNiagara(3).SetUIActive(enable);
				base.GetUiNiagara(4).SetUIActive(enable);
				base.GetUiNiagara(10).SetUIActive(enable);
				this.SetFullEffectAlpha(enable > false);
				base.GetSprite(0).SetUIActive(!enable);
				base.GetSprite(7).SetUIActive(true);
				base.GetSprite(8).SetUIActive(!enable);
				base.GetSprite(1).SetUIActive(!enable);
				this.State = 3;
			}

			// Token: 0x0604E5BD RID: 320957 RVA: 0x015B81F2 File Offset: 0x015B63F2
			public void SetFullEffectAlpha(float alpha)
			{
				base.GetUiNiagara(3).SetAlpha(alpha);
				base.GetUiNiagara(4).SetAlpha(alpha);
				base.GetUiNiagara(10).SetAlpha(alpha);
			}

			// Token: 0x0604E5BE RID: 320958 RVA: 0x015B821C File Offset: 0x015B641C
			public void SetConsumeEffectAlpha(float alpha)
			{
				base.GetUiNiagara(9).SetAlpha(alpha);
			}

			// Token: 0x0403BBEA RID: 244714
			private float InitConsumeEffectOffsetX;

			// Token: 0x0403BBEB RID: 244715
			private bool IsConsumeEffectActive;

			// Token: 0x0403BBEC RID: 244716
			private bool? IsFullEffectEnable;

			// Token: 0x0200CF63 RID: 53091
			private enum ESlotItemChildType
			{
				// Token: 0x0403FE12 RID: 261650
				BgSprite,
				// Token: 0x0403FE13 RID: 261651
				BarSprite,
				// Token: 0x0403FE14 RID: 261652
				PointBgSprite = 7,
				// Token: 0x0403FE15 RID: 261653
				PointFgSprite,
				// Token: 0x0403FE16 RID: 261654
				FullEffect = 3,
				// Token: 0x0403FE17 RID: 261655
				FullBgEffect,
				// Token: 0x0403FE18 RID: 261656
				ConsumeEffect = 9,
				// Token: 0x0403FE19 RID: 261657
				TextEffect
			}
		}
	}
}
