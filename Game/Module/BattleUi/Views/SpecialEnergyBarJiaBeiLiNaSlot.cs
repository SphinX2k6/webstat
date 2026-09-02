using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060BD RID: 24765
	public class SpecialEnergyBarJiaBeiLiNaSlot : SpecialEnergyBarSlot
	{
		// Token: 0x0603E8A9 RID: 256169 RVA: 0x00FFE4AD File Offset: 0x00FFC6AD
		protected override void OnInitData()
		{
			base.OnInitData();
			this.RedPercentMachine.Init(this.GetRedTargetAttributePercent());
		}

		// Token: 0x0603E8AA RID: 256170 RVA: 0x00FFE4C8 File Offset: 0x00FFC6C8
		protected float GetRedTargetAttributePercent()
		{
			float currentValue = this.AttributeComponent.GetCurrentValue(EAttributeType.SpecialEnergy2);
			float currentValue2 = this.AttributeComponent.GetCurrentValue(EAttributeType.SpecialEnergy2Max);
			float result = 0f;
			if (currentValue2 > 0f)
			{
				result = currentValue / currentValue2;
			}
			return result;
		}

		// Token: 0x0603E8AB RID: 256171 RVA: 0x00FFE504 File Offset: 0x00FFC704
		protected override void OnStart()
		{
			this.OverrideColor = true;
			base.OnStart();
			this.SlotItemList[0].SetEffectBasePercent(0.27f);
			this.SlotItemList[0].SetFullEffectPercent(1f);
			this.SlotItemList[1].SetEffectBasePercent(0.7f);
			this.SlotItemList[1].SetFullEffectPercent(1f);
			this.RefreshRedBarPercent(true);
		}

		// Token: 0x0603E8AC RID: 256172 RVA: 0x00FFE57D File Offset: 0x00FFC77D
		protected override void AddEvents()
		{
			base.AddEvents();
			base.ListenForAttributeChanged(EAttributeType.SpecialEnergy2, new Action<EAttributeType, float, float>(this.RedAttributeChanged));
			base.ListenForAttributeChanged(EAttributeType.SpecialEnergy2Max, new Action<EAttributeType, float, float>(this.RedMaxAttributeChanged));
		}

		// Token: 0x0603E8AD RID: 256173 RVA: 0x00FFE5AD File Offset: 0x00FFC7AD
		private void RedAttributeChanged(EAttributeType attributeId, float newValue, float oldValue)
		{
			this.RedPercentMachine.SetTargetPercent(this.GetRedTargetAttributePercent());
			this.RefreshRedBarPercent(false);
		}

		// Token: 0x0603E8AE RID: 256174 RVA: 0x00FFE5C7 File Offset: 0x00FFC7C7
		private void RedMaxAttributeChanged(EAttributeType attributeId, float newValue, float oldValue)
		{
			this.RedPercentMachine.SetTargetPercent(this.GetRedTargetAttributePercent());
			this.RefreshRedBarPercent(false);
		}

		// Token: 0x0603E8AF RID: 256175 RVA: 0x00FFE5E4 File Offset: 0x00FFC7E4
		protected void RefreshRedBarPercent(bool isStart = false)
		{
			float curPercent = this.RedPercentMachine.GetCurPercent();
			bool keyEnable = this.GetKeyEnable();
			this.SlotItemList[0].UpdatePercent(curPercent, keyEnable, false);
			Action<int, float> percentCallback = this.PercentCallback;
			if (percentCallback == null)
			{
				return;
			}
			percentCallback(0, curPercent);
		}

		// Token: 0x0603E8B0 RID: 256176 RVA: 0x00FFE62C File Offset: 0x00FFC82C
		protected override void RefreshBarPercent(bool isStart = false)
		{
			float curPercent = this.PercentMachine.GetCurPercent();
			bool keyEnable = this.GetKeyEnable();
			this.SlotItemList[1].UpdatePercent(curPercent, keyEnable, false);
			Action<int, float> percentCallback = this.PercentCallback;
			if (percentCallback != null)
			{
				percentCallback(1, curPercent);
			}
			SpecialEnergyBarKeyItem keyItem = this.KeyItem;
			if (keyItem != null)
			{
				keyItem.RefreshKeyEnable(keyEnable, isStart);
			}
			if (isStart)
			{
				this.LastKeyEnable = keyEnable;
				return;
			}
			if (this.LastKeyEnable != keyEnable)
			{
				this.LastKeyEnable = keyEnable;
				this.RefreshRedBarPercent(false);
			}
		}

		// Token: 0x0603E8B1 RID: 256177 RVA: 0x00FFE6A8 File Offset: 0x00FFC8A8
		protected override bool GetKeyEnable()
		{
			return this.PercentMachine.GetCurPercent() >= this.Config.DisableKeyOnPercent && (this.Config.KeyEnableTagId == 0 || this.HasKeyEnableTag);
		}

		// Token: 0x0603E8B2 RID: 256178 RVA: 0x00FFE6DC File Offset: 0x00FFC8DC
		public override void Tick(float delta)
		{
			base.Tick(delta);
			if (this.RedPercentMachine.Update(delta))
			{
				this.RefreshRedBarPercent(false);
			}
		}

		// Token: 0x040230F1 RID: 143601
		[Nullable(1)]
		protected SpecialEnergyBarPercentMachine RedPercentMachine = new SpecialEnergyBarPercentMachine();

		// Token: 0x040230F2 RID: 143602
		private bool LastKeyEnable;

		// Token: 0x040230F3 RID: 143603
		[Nullable(2)]
		public Action<int, float> PercentCallback;
	}
}
