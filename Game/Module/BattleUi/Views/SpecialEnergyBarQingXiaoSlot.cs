using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060DC RID: 24796
	[NullableContext(1)]
	[Nullable(0)]
	public class SpecialEnergyBarQingXiaoSlot : SpecialEnergyBarSlot
	{
		// Token: 0x0603EA12 RID: 256530 RVA: 0x01007984 File Offset: 0x01005B84
		protected override void OnInitData()
		{
			base.OnInitData();
			this.QinPercentMachine.Init(this.GetQinTargetAttributePercent());
			this.JianPercentMachine.Init(this.GetJianTargetAttributePercent());
		}

		// Token: 0x0603EA13 RID: 256531 RVA: 0x010079B0 File Offset: 0x01005BB0
		protected float GetAttributePercent(EAttributeType attrId, EAttributeType maxAttrId)
		{
			float currentValue = this.AttributeComponent.GetCurrentValue(attrId);
			float currentValue2 = this.AttributeComponent.GetCurrentValue(maxAttrId);
			float result = 0f;
			if (currentValue2 > 0f)
			{
				result = currentValue / currentValue2;
			}
			return result;
		}

		// Token: 0x0603EA14 RID: 256532 RVA: 0x010079EA File Offset: 0x01005BEA
		protected float GetQinTargetAttributePercent()
		{
			return this.GetAttributePercent(SpecialEnergyBarQingXiaoSlot.QIN_ATTR_ID, SpecialEnergyBarQingXiaoSlot.MAX_QIN_ATTR_ID);
		}

		// Token: 0x0603EA15 RID: 256533 RVA: 0x010079FC File Offset: 0x01005BFC
		protected float GetJianTargetAttributePercent()
		{
			return this.GetAttributePercent(SpecialEnergyBarQingXiaoSlot.JIAN_ATTR_ID, SpecialEnergyBarQingXiaoSlot.MAX_JIAN_ATTR_ID);
		}

		// Token: 0x0603EA16 RID: 256534 RVA: 0x01007A10 File Offset: 0x01005C10
		protected override void OnStart()
		{
			this.OverrideColor = true;
			base.OnStart();
			this.SetItemStyle(SpecialEnergyBarQingXiaoSlot.QIN_SLOT_INDEX, this.Config.EffectColor, this.Config.PointColorList[SpecialEnergyBarQingXiaoSlot.QIN_SLOT_INDEX]);
			this.SetItemStyle(SpecialEnergyBarQingXiaoSlot.JIAN_SLOT_INDEX, this.Config.OtherEffectColorList[SpecialEnergyBarQingXiaoSlot.JIAN_SLOT_INDEX - 1], this.Config.PointColorList[SpecialEnergyBarQingXiaoSlot.JIAN_SLOT_INDEX]);
		}

		// Token: 0x0603EA17 RID: 256535 RVA: 0x01007A84 File Offset: 0x01005C84
		private void SetItemStyle(int index, string barColor, string pointColor)
		{
			this.SlotItemList[index].SetFullEffectPercent(1f);
			SpecialEnergyBarSlotItem specialEnergyBarSlotItem = this.SlotItemList[index];
			FColor fcolor = FColor.FromHex(barColor);
			specialEnergyBarSlotItem.SetBarColor(fcolor);
			SpecialEnergyBarSlotItem specialEnergyBarSlotItem2 = this.SlotItemList[index];
			fcolor = FColor.FromHex(pointColor);
			specialEnergyBarSlotItem2.SetPointColor(fcolor);
		}

		// Token: 0x0603EA18 RID: 256536 RVA: 0x01007ADC File Offset: 0x01005CDC
		protected override void AddEvents()
		{
			base.AddEvents();
			base.ListenForAttributeChanged(SpecialEnergyBarQingXiaoSlot.QIN_ATTR_ID, new Action<EAttributeType, float, float>(this.OnQinPercentChange));
			base.ListenForAttributeChanged(SpecialEnergyBarQingXiaoSlot.MAX_QIN_ATTR_ID, new Action<EAttributeType, float, float>(this.OnQinPercentChange));
			base.ListenForAttributeChanged(SpecialEnergyBarQingXiaoSlot.JIAN_ATTR_ID, new Action<EAttributeType, float, float>(this.OnJianPercentChange));
			base.ListenForAttributeChanged(SpecialEnergyBarQingXiaoSlot.MAX_JIAN_ATTR_ID, new Action<EAttributeType, float, float>(this.OnJianPercentChange));
		}

		// Token: 0x0603EA19 RID: 256537 RVA: 0x01007B4B File Offset: 0x01005D4B
		private void OnQinPercentChange(EAttributeType attributeId, float newValue, float oldValue)
		{
			this.QinPercentMachine.SetTargetPercent(this.GetQinTargetAttributePercent());
			this.RefreshQinBarPercent(false);
		}

		// Token: 0x0603EA1A RID: 256538 RVA: 0x01007B65 File Offset: 0x01005D65
		private void OnJianPercentChange(EAttributeType attributeId, float newValue, float oldValue)
		{
			this.JianPercentMachine.SetTargetPercent(this.GetJianTargetAttributePercent());
			this.RefreshJianBarPercent(false);
		}

		// Token: 0x0603EA1B RID: 256539 RVA: 0x01007B80 File Offset: 0x01005D80
		protected void RefreshQinBarPercent(bool isStart = false)
		{
			float curPercent = this.QinPercentMachine.GetCurPercent();
			this.SlotItemList[SpecialEnergyBarQingXiaoSlot.QIN_SLOT_INDEX].UpdatePercent(curPercent, true, false);
			Action<int, float> percentCallback = this.PercentCallback;
			if (percentCallback == null)
			{
				return;
			}
			percentCallback(SpecialEnergyBarQingXiaoSlot.QIN_SLOT_INDEX, curPercent);
		}

		// Token: 0x0603EA1C RID: 256540 RVA: 0x01007BC8 File Offset: 0x01005DC8
		protected void RefreshJianBarPercent(bool isStart = false)
		{
			float curPercent = this.JianPercentMachine.GetCurPercent();
			this.SlotItemList[SpecialEnergyBarQingXiaoSlot.JIAN_SLOT_INDEX].UpdatePercent(curPercent, true, false);
			Action<int, float> percentCallback = this.PercentCallback;
			if (percentCallback == null)
			{
				return;
			}
			percentCallback(SpecialEnergyBarQingXiaoSlot.JIAN_SLOT_INDEX, curPercent);
		}

		// Token: 0x0603EA1D RID: 256541 RVA: 0x01007C10 File Offset: 0x01005E10
		protected override void RefreshBarPercent(bool isStart = false)
		{
			bool keyEnable = this.GetKeyEnable();
			SpecialEnergyBarKeyItem keyItem = this.KeyItem;
			if (keyItem != null)
			{
				keyItem.RefreshKeyEnable(keyEnable, isStart);
			}
			this.RefreshQinBarPercent(isStart);
			this.RefreshJianBarPercent(isStart);
		}

		// Token: 0x0603EA1E RID: 256542 RVA: 0x01007C45 File Offset: 0x01005E45
		public void SetKeyEnable(bool enable)
		{
			if (this.IsKeyEnable == enable)
			{
				return;
			}
			this.IsKeyEnable = enable;
			this.RefreshBarPercent(false);
			SpecialEnergyBarKeyItem keyItem = this.KeyItem;
			if (keyItem == null)
			{
				return;
			}
			keyItem.RefreshKeyEnable(enable, false);
		}

		// Token: 0x0603EA1F RID: 256543 RVA: 0x01007C71 File Offset: 0x01005E71
		protected override bool GetKeyEnable()
		{
			return this.IsKeyEnable;
		}

		// Token: 0x0603EA20 RID: 256544 RVA: 0x01007C79 File Offset: 0x01005E79
		public override void Tick(float delta)
		{
			base.Tick(delta);
			if (this.QinPercentMachine.Update(delta))
			{
				this.RefreshQinBarPercent(false);
			}
			if (this.JianPercentMachine.Update(delta))
			{
				this.RefreshJianBarPercent(false);
			}
		}

		// Token: 0x040231FA RID: 143866
		private static readonly EAttributeType QIN_ATTR_ID = EAttributeType.SpecialEnergy1;

		// Token: 0x040231FB RID: 143867
		private static readonly EAttributeType MAX_QIN_ATTR_ID = EAttributeType.SpecialEnergy1Max;

		// Token: 0x040231FC RID: 143868
		private static readonly EAttributeType JIAN_ATTR_ID = EAttributeType.SpecialEnergy2;

		// Token: 0x040231FD RID: 143869
		private static readonly EAttributeType MAX_JIAN_ATTR_ID = EAttributeType.SpecialEnergy2Max;

		// Token: 0x040231FE RID: 143870
		private static readonly int QIN_SLOT_INDEX = 0;

		// Token: 0x040231FF RID: 143871
		private static readonly int JIAN_SLOT_INDEX = 1;

		// Token: 0x04023200 RID: 143872
		protected SpecialEnergyBarPercentMachine QinPercentMachine = new SpecialEnergyBarPercentMachine();

		// Token: 0x04023201 RID: 143873
		protected SpecialEnergyBarPercentMachine JianPercentMachine = new SpecialEnergyBarPercentMachine();

		// Token: 0x04023202 RID: 143874
		private bool IsKeyEnable;

		// Token: 0x04023203 RID: 143875
		[Nullable(2)]
		public Action<int, float> PercentCallback;
	}
}
