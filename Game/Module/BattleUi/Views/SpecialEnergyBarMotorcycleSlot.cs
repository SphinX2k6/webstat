using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060A8 RID: 24744
	public class SpecialEnergyBarMotorcycleSlot : SpecialEnergyBarSlot
	{
		// Token: 0x0603E78A RID: 255882 RVA: 0x00FF7459 File Offset: 0x00FF5659
		[NullableContext(1)]
		public void InitMotorcycleData([Nullable(2)] EntityHandle entityHandle, SpecialEnergyBarInfo config, bool needInitKeyItem = true)
		{
			this.NeedInitKeyItem = needInitKeyItem;
			if (this.Destroyed || entityHandle == null)
			{
				return;
			}
			this.Config = config;
			this.OnInitData();
			this.PercentMachine.Init(0f);
		}

		// Token: 0x0603E78B RID: 255883 RVA: 0x00FF748C File Offset: 0x00FF568C
		protected override void OnStart()
		{
			base.OnStart();
			foreach (SpecialEnergyBarSlotItem specialEnergyBarSlotItem in this.SlotItemList)
			{
				specialEnergyBarSlotItem.SetFullEffectPercent(1f);
			}
		}

		// Token: 0x0603E78C RID: 255884 RVA: 0x00FF74E8 File Offset: 0x00FF56E8
		public void UpdatePercent(float percent, bool keyEnable, bool isStart)
		{
			for (int i = 0; i < this.SlotItemList.Count; i++)
			{
				this.SlotItemList[i].UpdatePercent(percent * (float)this.SlotNum - (float)i, keyEnable, false);
			}
			SpecialEnergyBarKeyItem keyItem = this.KeyItem;
			if (keyItem == null)
			{
				return;
			}
			keyItem.RefreshKeyEnable(keyEnable, isStart);
		}
	}
}
