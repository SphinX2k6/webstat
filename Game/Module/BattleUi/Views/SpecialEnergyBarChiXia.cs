using System;
using Aki.Protocol;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060B2 RID: 24754
	public class SpecialEnergyBarChiXia : SpecialEnergyBarPointGraduate
	{
		// Token: 0x0603E805 RID: 256005 RVA: 0x00FFA46B File Offset: 0x00FF866B
		protected override void OnInitData()
		{
			base.OnInitData();
			this.NeedInitSlot = false;
			this.NeedInitNumItem = true;
		}

		// Token: 0x0603E806 RID: 256006 RVA: 0x00FFA481 File Offset: 0x00FF8681
		protected override void AddEvents()
		{
			base.AddEvents();
			base.ListenForTagAddOrRemoveChanged(GameplayTagDefine.EGameplayTagId["角色.R2T1MaxiaofangMd10011.技能标识.移动射击技能持续"], new BaseTagComponent.TTagSwitchedCallback(this.OnTagChange));
		}

		// Token: 0x0603E807 RID: 256007 RVA: 0x00FFA4AC File Offset: 0x00FF86AC
		private void OnTagChange(int tagId, bool tagExist)
		{
			if (!tagExist)
			{
				this.GraduateItemList[0].SetUIActive(false);
				return;
			}
			float num = this.AttributeComponent.GetCurrentValue((EAttributeType)this.Config.AttributeId) - 30f;
			float currentValue = this.AttributeComponent.GetCurrentValue((EAttributeType)this.Config.MaxAttributeId);
			float num2 = 0f;
			if (currentValue > 0f)
			{
				num2 = num / currentValue;
			}
			if (num2 >= 0f)
			{
				base.SetGraduateItemOffset(0, num2);
				this.GraduateItemList[0].SetUIActive(true);
				return;
			}
			this.GraduateItemList[0].SetUIActive(false);
		}

		// Token: 0x0603E808 RID: 256008 RVA: 0x00FFA54A File Offset: 0x00FF874A
		protected override void OnStart()
		{
			base.OnStart();
			this.GraduateItemList[0].SetUIActive(false);
		}

		// Token: 0x0603E809 RID: 256009 RVA: 0x00FFA564 File Offset: 0x00FF8764
		protected override void RefreshBarPercent(bool isStart = false)
		{
			float curPercent = this.PercentMachine.GetCurPercent();
			this.PointItem.UpdatePercent(curPercent, true, 0);
			SpecialEnergyBarKeyItem keyItem = this.KeyItem;
			if (keyItem != null)
			{
				keyItem.RefreshKeyEnable(curPercent >= this.Config.DisableKeyOnPercent, isStart);
			}
			int num = (int)this.AttributeComponent.GetCurrentValue((EAttributeType)this.Config.AttributeId);
			SpecialEnergyBarNumItem numItem = this.NumItem;
			if (numItem == null)
			{
				return;
			}
			numItem.SetNum(num);
		}

		// Token: 0x0402308A RID: 143498
		private const int GRADUATE_ENERGY_NUM = 30;
	}
}
