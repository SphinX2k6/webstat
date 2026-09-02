using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006102 RID: 24834
	[NullableContext(1)]
	[Nullable(0)]
	public class SpecialEnergyBarSlot : SpecialEnergyBarBase
	{
		// Token: 0x0603EBDC RID: 256988 RVA: 0x0101044C File Offset: 0x0100E64C
		protected override void OnRegisterComponent()
		{
			this.SlotNum = this.Config.SlotNum;
			if (this.SlotNum == 0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Battle;
				ELogAuthor author = ELogAuthor.CFT;
				string message = "槽型的能量条，分段数量不能为0";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", this.Config.Id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			for (int i = 0; i <= this.SlotNum + 1; i++)
			{
				this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(i, typeof(UUIItem)));
			}
		}

		// Token: 0x0603EBDD RID: 256989 RVA: 0x010104D8 File Offset: 0x0100E6D8
		protected override UniTask OnBeforeStartAsync()
		{
			SpecialEnergyBarSlot.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SpecialEnergyBarSlot.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603EBDE RID: 256990 RVA: 0x0101051C File Offset: 0x0100E71C
		protected virtual UniTask InitSlotItem(UUIItem slotItem)
		{
			SpecialEnergyBarSlot.<InitSlotItem>d__9 <InitSlotItem>d__;
			<InitSlotItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitSlotItem>d__.<>4__this = this;
			<InitSlotItem>d__.slotItem = slotItem;
			<InitSlotItem>d__.<>1__state = -1;
			<InitSlotItem>d__.<>t__builder.Start<SpecialEnergyBarSlot.<InitSlotItem>d__9>(ref <InitSlotItem>d__);
			return <InitSlotItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603EBDF RID: 256991 RVA: 0x01010568 File Offset: 0x0100E768
		protected override void OnStart()
		{
			if (this.Config == null)
			{
				return;
			}
			float effectBasePercent = (this.ForceEffectBasePercent > 0f) ? this.ForceEffectBasePercent : SpecialEnergyBarSlot.effectBasePercents[this.SlotNum - 1];
			foreach (SpecialEnergyBarSlotItem specialEnergyBarSlotItem in this.SlotItemList)
			{
				specialEnergyBarSlotItem.SetEffectBasePercent(effectBasePercent);
			}
			if (!this.OverrideColor && !string.IsNullOrEmpty(this.Config.EffectColor))
			{
				FColor fcolor = FColor.FromHex(this.Config.EffectColor);
				FLinearColor flinearColor = new FLinearColor(ref fcolor);
				FColor fcolor2 = fcolor;
				if (!string.IsNullOrEmpty(this.Config.PointColor))
				{
					fcolor2 = FColor.FromHex(this.Config.PointColor);
				}
				foreach (SpecialEnergyBarSlotItem specialEnergyBarSlotItem2 in this.SlotItemList)
				{
					specialEnergyBarSlotItem2.SetBarColor(fcolor);
					specialEnergyBarSlotItem2.SetPointColor(fcolor2);
					specialEnergyBarSlotItem2.SetFullEffectColor(flinearColor, this.IsMorph);
				}
			}
			bool uiactive = true;
			if (this.ForceHideBottomLine)
			{
				uiactive = false;
			}
			else if (this.IsMorph)
			{
				SpecialEnergyBarInfo config = this.Config;
				if (!string.IsNullOrEmpty((config != null) ? config.IconPath : null))
				{
					uiactive = false;
				}
			}
			UUIItem item = base.GetItem(this.SlotNum + 1);
			if (item != null)
			{
				item.SetUIActive(uiactive);
			}
			this.RefreshBarPercent(true);
		}

		// Token: 0x0603EBE0 RID: 256992 RVA: 0x010106F0 File Offset: 0x0100E8F0
		protected virtual void RefreshBarPercent(bool isStart = false)
		{
			float curPercent = this.PercentMachine.GetCurPercent();
			bool keyEnable = this.GetKeyEnable();
			for (int i = 0; i < this.SlotItemList.Count; i++)
			{
				this.SlotItemList[i].UpdatePercent(curPercent * (float)this.SlotNum - (float)i, keyEnable, false);
			}
			SpecialEnergyBarKeyItem keyItem = this.KeyItem;
			if (keyItem == null)
			{
				return;
			}
			keyItem.RefreshKeyEnable(keyEnable, isStart);
		}

		// Token: 0x0603EBE1 RID: 256993 RVA: 0x01010757 File Offset: 0x0100E957
		protected override void OnBarPercentChanged()
		{
			this.RefreshBarPercent(false);
		}

		// Token: 0x0603EBE2 RID: 256994 RVA: 0x01010760 File Offset: 0x0100E960
		protected override void OnKeyEnableChanged()
		{
			this.RefreshBarPercent(false);
		}

		// Token: 0x0603EBE3 RID: 256995 RVA: 0x0101076C File Offset: 0x0100E96C
		public override void Tick(float delta)
		{
			base.Tick(delta);
			foreach (SpecialEnergyBarSlotItem specialEnergyBarSlotItem in this.SlotItemList)
			{
				specialEnergyBarSlotItem.Tick(delta);
			}
		}

		// Token: 0x0603EBE4 RID: 256996 RVA: 0x010107C4 File Offset: 0x0100E9C4
		public override void ReplaceFullEffect(UNiagaraSystem niagara)
		{
			foreach (SpecialEnergyBarSlotItem specialEnergyBarSlotItem in this.SlotItemList)
			{
				specialEnergyBarSlotItem.ReplaceFullEffect(niagara);
			}
		}

		// Token: 0x0603EBE5 RID: 256997 RVA: 0x01010818 File Offset: 0x0100EA18
		public override void RevertFullEffect()
		{
			foreach (SpecialEnergyBarSlotItem specialEnergyBarSlotItem in this.SlotItemList)
			{
				specialEnergyBarSlotItem.RevertFullEffect();
			}
		}

		// Token: 0x0603EBE6 RID: 256998 RVA: 0x01010868 File Offset: 0x0100EA68
		public void UpdateFullEffectOffsetBySlotWidth()
		{
			foreach (SpecialEnergyBarSlotItem specialEnergyBarSlotItem in this.SlotItemList)
			{
				specialEnergyBarSlotItem.SetFullEffectOffsetX(specialEnergyBarSlotItem.GetRootItem().Width / 2f);
			}
		}

		// Token: 0x0603EBE7 RID: 256999 RVA: 0x010108CC File Offset: 0x0100EACC
		public void SetCustomEffectBasePercent(float effectBasePercent)
		{
			foreach (SpecialEnergyBarSlotItem specialEnergyBarSlotItem in this.SlotItemList)
			{
				specialEnergyBarSlotItem.SetEffectBasePercent(effectBasePercent);
			}
		}

		// Token: 0x0603EBE8 RID: 257000 RVA: 0x01010920 File Offset: 0x0100EB20
		public void SetFullEffectVisible(int index, bool visible)
		{
			SpecialEnergyBarSlotItem valueOrDefault = this.SlotItemList.GetValueOrDefault(index);
			if (valueOrDefault == null)
			{
				return;
			}
			valueOrDefault.SetFullEffectVisible(visible);
		}

		// Token: 0x0603EBE9 RID: 257001 RVA: 0x0101093C File Offset: 0x0100EB3C
		public void SetUseEffectMode(EUseEffectMode mode)
		{
			foreach (SpecialEnergyBarSlotItem specialEnergyBarSlotItem in this.SlotItemList)
			{
				specialEnergyBarSlotItem.SetUseEffectMode(mode);
			}
		}

		// Token: 0x04023304 RID: 144132
		[StaticVariableRuleIgnore]
		private static readonly float[] effectBasePercents = new float[]
		{
			1f,
			0.4878049f,
			0.31707317f,
			0.2195122f,
			0.17073171f,
			0.14634146f
		};

		// Token: 0x04023305 RID: 144133
		protected int SlotNum;

		// Token: 0x04023306 RID: 144134
		protected readonly List<SpecialEnergyBarSlotItem> SlotItemList = new List<SpecialEnergyBarSlotItem>();

		// Token: 0x04023307 RID: 144135
		public bool IsMorph;

		// Token: 0x04023308 RID: 144136
		public bool ForceHideBottomLine;

		// Token: 0x04023309 RID: 144137
		public float ForceEffectBasePercent = -1f;

		// Token: 0x0402330A RID: 144138
		public bool OverrideColor;
	}
}
