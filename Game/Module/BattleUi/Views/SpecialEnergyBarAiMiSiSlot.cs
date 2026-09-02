using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060AB RID: 24747
	[NullableContext(1)]
	[Nullable(0)]
	public class SpecialEnergyBarAiMiSiSlot : SpecialEnergyBarSlot
	{
		// Token: 0x0603E7B7 RID: 255927 RVA: 0x00FF8864 File Offset: 0x00FF6A64
		protected override UniTask OnBeforeStartAsync()
		{
			SpecialEnergyBarAiMiSiSlot.<OnBeforeStartAsync>d__2 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SpecialEnergyBarAiMiSiSlot.<OnBeforeStartAsync>d__2>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603E7B8 RID: 255928 RVA: 0x00FF88A8 File Offset: 0x00FF6AA8
		protected override void OnStart()
		{
			this.ForceEffectBasePercent = 0.29268292f;
			base.OnStart();
			foreach (SpecialEnergyBarSlotItem specialEnergyBarSlotItem in this.SlotItemList)
			{
				specialEnergyBarSlotItem.SetFullEffectPercent(1f);
			}
		}

		// Token: 0x0603E7B9 RID: 255929 RVA: 0x00FF8910 File Offset: 0x00FF6B10
		protected override void OnInitData()
		{
			base.OnInitData();
			if (this.Config != null)
			{
				if (!string.IsNullOrEmpty(this.Config.EffectColor))
				{
					FColor item = FColor.FromHex(this.Config.EffectColor);
					this.ColorList.Add(item);
				}
				string valueOrDefault = this.Config.OtherEffectColorList.GetValueOrDefault(0);
				if (!string.IsNullOrEmpty(valueOrDefault))
				{
					FColor item2 = FColor.FromHex(valueOrDefault);
					this.ColorList.Add(item2);
				}
				if (this.Config.PointColorList.Length >= 2)
				{
					for (int i = 0; i < 2; i++)
					{
						this.PointColorList.Add(FColor.FromHex(this.Config.PointColorList[i]));
					}
				}
			}
		}

		// Token: 0x0603E7BA RID: 255930 RVA: 0x00FF89C4 File Offset: 0x00FF6BC4
		protected override void RefreshBarPercent(bool isStart = false)
		{
			float curPercent = this.PercentMachine.GetCurPercent();
			bool keyEnable = this.GetKeyEnable();
			for (int i = 0; i < this.SlotItemList.Count; i++)
			{
				this.SlotItemList[i].UpdatePercent(curPercent * (float)this.SlotNum - (float)i, true, false);
			}
			SpecialEnergyBarKeyItem keyItem = this.KeyItem;
			if (keyItem == null)
			{
				return;
			}
			keyItem.RefreshKeyEnable(keyEnable, isStart);
		}

		// Token: 0x0603E7BB RID: 255931 RVA: 0x00FF8A2C File Offset: 0x00FF6C2C
		public void SetBarColor(int type)
		{
			foreach (SpecialEnergyBarSlotItem specialEnergyBarSlotItem in this.SlotItemList)
			{
				FColor fcolor = this.ColorList[type];
				specialEnergyBarSlotItem.SetBarColor(fcolor);
				fcolor = this.PointColorList[type];
				specialEnergyBarSlotItem.SetPointColor(fcolor);
			}
			if (type == 0)
			{
				this.RevertFullEffect();
				return;
			}
			this.ReplaceFullEffect(this.NiagaraList[type - 1]);
		}

		// Token: 0x0603E7BC RID: 255932 RVA: 0x00FF8AC0 File Offset: 0x00FF6CC0
		public void SetKeyVisible(bool bVisible)
		{
			UUIItem item = base.GetItem(this.SlotNum);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(bVisible);
		}

		// Token: 0x0402305F RID: 143455
		private readonly List<FColor> ColorList = new List<FColor>();

		// Token: 0x04023060 RID: 143456
		private readonly List<FColor> PointColorList = new List<FColor>();
	}
}
