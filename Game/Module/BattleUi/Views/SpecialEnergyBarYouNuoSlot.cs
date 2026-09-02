using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060EE RID: 24814
	[NullableContext(1)]
	[Nullable(0)]
	public class SpecialEnergyBarYouNuoSlot : SpecialEnergyBarSlot
	{
		// Token: 0x0603EB07 RID: 256775 RVA: 0x0100C7AD File Offset: 0x0100A9AD
		protected override void OnInitData()
		{
			this.ConfigList.Add(ModelBase<BattleUiModel>.Instance.SpecialEnergyBarData.GetSpecialEnergyBarInfo(141001));
			this.ConfigList.Add(ModelBase<BattleUiModel>.Instance.SpecialEnergyBarData.GetSpecialEnergyBarInfo(141002));
		}

		// Token: 0x0603EB08 RID: 256776 RVA: 0x0100C7F0 File Offset: 0x0100A9F0
		protected override UniTask InitKeyItem(UUIItem keyItemContainer)
		{
			SpecialEnergyBarYouNuoSlot.<InitKeyItem>d__6 <InitKeyItem>d__;
			<InitKeyItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitKeyItem>d__.<>4__this = this;
			<InitKeyItem>d__.keyItemContainer = keyItemContainer;
			<InitKeyItem>d__.<>1__state = -1;
			<InitKeyItem>d__.<>t__builder.Start<SpecialEnergyBarYouNuoSlot.<InitKeyItem>d__6>(ref <InitKeyItem>d__);
			return <InitKeyItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603EB09 RID: 256777 RVA: 0x0100C83C File Offset: 0x0100AA3C
		protected override void OnStart()
		{
			this.OverrideColor = true;
			base.OnStart();
			SpecialEnergyBarInfo specialEnergyBarInfo = this.ConfigList[1];
			if (!string.IsNullOrEmpty(specialEnergyBarInfo.EffectColor))
			{
				FColor fcolor = FColor.FromHex(specialEnergyBarInfo.EffectColor);
				FLinearColor flinearColor = new FLinearColor(ref fcolor);
				foreach (SpecialEnergyBarSlotItem specialEnergyBarSlotItem in this.SlotItemList)
				{
					specialEnergyBarSlotItem.SetFullEffectColor(flinearColor, this.IsMorph);
				}
			}
			this.AddColor(this.Config);
			this.AddColor(this.ConfigList[0]);
		}

		// Token: 0x0603EB0A RID: 256778 RVA: 0x0100C8F0 File Offset: 0x0100AAF0
		private void AddColor(SpecialEnergyBarInfo config)
		{
			FColor item = FColor.FromHex(config.EffectColor);
			FColor item2 = FColor.FromHex(config.PointColor);
			this.ColorList.Add(item);
			this.PointColorList.Add(item2);
		}

		// Token: 0x0603EB0B RID: 256779 RVA: 0x0100C92D File Offset: 0x0100AB2D
		public void SetFullEffectPercent(float percent)
		{
			if (this.FullEffectPercent == percent)
			{
				return;
			}
			this.FullEffectPercent = percent;
			this.RefreshBarPercent(false);
		}

		// Token: 0x0603EB0C RID: 256780 RVA: 0x0100C948 File Offset: 0x0100AB48
		protected override void RefreshBarPercent(bool isStart = false)
		{
			float curPercent = this.PercentMachine.GetCurPercent();
			bool fullEffectEnable = curPercent >= this.FullEffectPercent;
			for (int i = 0; i < this.SlotItemList.Count; i++)
			{
				SpecialEnergyBarSlotItem specialEnergyBarSlotItem = this.SlotItemList[i];
				float percent = curPercent * (float)this.SlotNum - (float)i;
				specialEnergyBarSlotItem.UpdatePercentWithFullEffectEnable(percent, fullEffectEnable, isStart);
			}
		}

		// Token: 0x0603EB0D RID: 256781 RVA: 0x0100C9A5 File Offset: 0x0100ABA5
		public void SetKeyItemEnable(int type, bool enable, bool isStart = false)
		{
			if (Singleton<Info>.Instance.IsInTouch())
			{
				return;
			}
			this.KeyItemList[type].RefreshKeyEnable(enable, isStart);
		}

		// Token: 0x0603EB0E RID: 256782 RVA: 0x0100C9C8 File Offset: 0x0100ABC8
		public void SetKeyItemType(int type)
		{
			if (Singleton<Info>.Instance.IsInTouch())
			{
				return;
			}
			for (int i = 0; i < this.KeyItemList.Count; i++)
			{
				this.KeyItemList[i].SetUiActive(type == i);
			}
		}

		// Token: 0x0603EB0F RID: 256783 RVA: 0x0100CA10 File Offset: 0x0100AC10
		public void SetBarColor(int type)
		{
			if (type < this.ColorList.Count)
			{
				foreach (SpecialEnergyBarSlotItem specialEnergyBarSlotItem in this.SlotItemList)
				{
					FColor fcolor = this.ColorList[type];
					specialEnergyBarSlotItem.SetBarColor(fcolor);
					fcolor = this.PointColorList[type];
					specialEnergyBarSlotItem.SetPointColor(fcolor);
				}
			}
		}

		// Token: 0x04023288 RID: 144008
		private readonly List<SpecialEnergyBarInfo> ConfigList = new List<SpecialEnergyBarInfo>();

		// Token: 0x04023289 RID: 144009
		private readonly List<SpecialEnergyBarKeyItem> KeyItemList = new List<SpecialEnergyBarKeyItem>();

		// Token: 0x0402328A RID: 144010
		private readonly List<FColor> ColorList = new List<FColor>();

		// Token: 0x0402328B RID: 144011
		private readonly List<FColor> PointColorList = new List<FColor>();

		// Token: 0x0402328C RID: 144012
		private float FullEffectPercent = 1f;
	}
}
