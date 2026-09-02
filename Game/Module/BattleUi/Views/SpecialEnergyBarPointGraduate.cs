using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060FF RID: 24831
	[NullableContext(1)]
	[Nullable(0)]
	public class SpecialEnergyBarPointGraduate : SpecialEnergyBarBase
	{
		// Token: 0x0603EBBF RID: 256959 RVA: 0x0100F9D2 File Offset: 0x0100DBD2
		protected override void OnInitData()
		{
			this.LastPercent = this.PercentMachine.GetCurPercent();
		}

		// Token: 0x0603EBC0 RID: 256960 RVA: 0x0100F9E8 File Offset: 0x0100DBE8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603EBC1 RID: 256961 RVA: 0x0100FAB4 File Offset: 0x0100DCB4
		protected override UniTask OnBeforeStartAsync()
		{
			SpecialEnergyBarPointGraduate.<OnBeforeStartAsync>d__14 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SpecialEnergyBarPointGraduate.<OnBeforeStartAsync>d__14>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603EBC2 RID: 256962 RVA: 0x0100FAF8 File Offset: 0x0100DCF8
		protected UniTask InitSlotItem(UUIItem slotItem)
		{
			SpecialEnergyBarPointGraduate.<InitSlotItem>d__15 <InitSlotItem>d__;
			<InitSlotItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitSlotItem>d__.<>4__this = this;
			<InitSlotItem>d__.slotItem = slotItem;
			<InitSlotItem>d__.<>1__state = -1;
			<InitSlotItem>d__.<>t__builder.Start<SpecialEnergyBarPointGraduate.<InitSlotItem>d__15>(ref <InitSlotItem>d__);
			return <InitSlotItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603EBC3 RID: 256963 RVA: 0x0100FB44 File Offset: 0x0100DD44
		protected UniTask InitPointItem(UUIItem pointItem)
		{
			SpecialEnergyBarPointGraduate.<InitPointItem>d__16 <InitPointItem>d__;
			<InitPointItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitPointItem>d__.<>4__this = this;
			<InitPointItem>d__.pointItem = pointItem;
			<InitPointItem>d__.<>1__state = -1;
			<InitPointItem>d__.<>t__builder.Start<SpecialEnergyBarPointGraduate.<InitPointItem>d__16>(ref <InitPointItem>d__);
			return <InitPointItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603EBC4 RID: 256964 RVA: 0x0100FB90 File Offset: 0x0100DD90
		protected override void OnStart()
		{
			if (this.Config == null)
			{
				return;
			}
			if (this.Config.EffectColor != null)
			{
				FColor fcolor = FColor.FromHex(this.Config.EffectColor);
				FLinearColor flinearColor = new FLinearColor(ref fcolor);
				FColor fcolor2 = fcolor;
				if (this.Config.PointColor != null)
				{
					fcolor2 = FColor.FromHex(this.Config.PointColor);
				}
				SpecialEnergyBarPointItem pointItem = this.PointItem;
				if (pointItem != null)
				{
					pointItem.SetFullEffectColor(flinearColor, false);
				}
				SpecialEnergyBarSlotItem slotItem = this.SlotItem;
				if (slotItem != null)
				{
					slotItem.SetBarColor(fcolor);
				}
				SpecialEnergyBarSlotItem slotItem2 = this.SlotItem;
				if (slotItem2 != null)
				{
					slotItem2.SetPointColor(fcolor2);
				}
				SpecialEnergyBarSlotItem slotItem3 = this.SlotItem;
				if (slotItem3 != null)
				{
					slotItem3.SetFullEffectColor(flinearColor, false);
				}
			}
			UUIItem item = base.GetItem(2);
			this.GraduateItemList.Add(item);
			int num = this.Config.SlotNum - 1;
			if (num > 1)
			{
				AActor owner = item.GetOwner();
				UUIItem parentAsUIItem = item.GetParentAsUIItem();
				for (int i = 1; i < num; i++)
				{
					AActor aactor = Singleton<LguiUtil>.Instance.DuplicateActor(owner, parentAsUIItem);
					this.GraduateItemList.Add(aactor.GetComponentByClass(UUIItem.StaticClass()) as UUIItem);
				}
			}
			else
			{
				item.SetUIActive(num > 0);
			}
			for (int j = 0; j < num; j++)
			{
				this.SetGraduateItemOffset(j, this.Config.ExtraFloatParams[j]);
			}
			base.GetItem(4).SetUIActive(!this.IsMorph);
			this.RefreshBarPercent(true);
		}

		// Token: 0x0603EBC5 RID: 256965 RVA: 0x0100FD08 File Offset: 0x0100DF08
		public void SetGraduateItemOffset(int index, float percent)
		{
			UUIItem valueOrDefault = this.GraduateItemList.GetValueOrDefault(index);
			if (valueOrDefault == null)
			{
				return;
			}
			valueOrDefault.SetAnchorOffsetX(369f * (percent - 0.5f));
		}

		// Token: 0x0603EBC6 RID: 256966 RVA: 0x0100FD30 File Offset: 0x0100DF30
		protected virtual void RefreshBarPercent(bool isStart = false)
		{
			float curPercent = this.PercentMachine.GetCurPercent();
			bool keyEnable = this.GetKeyEnable();
			bool changeVisible = false;
			if (this.IsKeyEnable != keyEnable)
			{
				this.IsKeyEnable = keyEnable;
				changeVisible = true;
			}
			SpecialEnergyBarSlotItem slotItem = this.SlotItem;
			if (slotItem != null)
			{
				slotItem.UpdatePercentWithVisible(curPercent, !keyEnable, changeVisible, isStart, this.LastPercent);
			}
			SpecialEnergyBarPointItem pointItem = this.PointItem;
			if (pointItem != null)
			{
				pointItem.UpdatePercentWithVisible(curPercent, keyEnable, changeVisible, isStart);
			}
			SpecialEnergyBarKeyItem keyItem = this.KeyItem;
			if (keyItem != null)
			{
				keyItem.RefreshKeyEnable(keyEnable, isStart);
			}
			this.LastPercent = curPercent;
		}

		// Token: 0x0603EBC7 RID: 256967 RVA: 0x0100FDB1 File Offset: 0x0100DFB1
		protected override void OnBarPercentChanged()
		{
			this.RefreshBarPercent(false);
		}

		// Token: 0x0603EBC8 RID: 256968 RVA: 0x0100FDBA File Offset: 0x0100DFBA
		protected override void OnKeyEnableChanged()
		{
			this.RefreshBarPercent(false);
		}

		// Token: 0x0603EBC9 RID: 256969 RVA: 0x0100FDC3 File Offset: 0x0100DFC3
		public override void Tick(float delta)
		{
			base.Tick(delta);
			SpecialEnergyBarPointItem pointItem = this.PointItem;
			if (pointItem != null)
			{
				pointItem.Tick(delta);
			}
			SpecialEnergyBarSlotItem slotItem = this.SlotItem;
			if (slotItem == null)
			{
				return;
			}
			slotItem.Tick(delta);
		}

		// Token: 0x0603EBCA RID: 256970 RVA: 0x0100FDEF File Offset: 0x0100DFEF
		public override void ReplaceFullEffect(UNiagaraSystem niagara)
		{
			this.PointItem.ReplaceFullEffect(niagara);
			this.SlotItem.ReplaceFullEffect(niagara);
		}

		// Token: 0x040232E6 RID: 144102
		private const int POINT_NUM = 41;

		// Token: 0x040232E7 RID: 144103
		private const float POINT_WIDTH = 9f;

		// Token: 0x040232E8 RID: 144104
		private const float TOTAL_WIDTH = 369f;

		// Token: 0x040232E9 RID: 144105
		[Nullable(2)]
		protected SpecialEnergyBarSlotItem SlotItem;

		// Token: 0x040232EA RID: 144106
		[Nullable(2)]
		protected SpecialEnergyBarPointItem PointItem;

		// Token: 0x040232EB RID: 144107
		protected List<UUIItem> GraduateItemList = new List<UUIItem>();

		// Token: 0x040232EC RID: 144108
		protected bool IsKeyEnable;

		// Token: 0x040232ED RID: 144109
		protected float LastPercent;

		// Token: 0x040232EE RID: 144110
		protected bool NeedInitSlot = true;

		// Token: 0x040232EF RID: 144111
		protected bool NeedInitPoint = true;

		// Token: 0x040232F0 RID: 144112
		public bool IsMorph;

		// Token: 0x0200C287 RID: 49799
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403BF89 RID: 245641
			SlotItem,
			// Token: 0x0403BF8A RID: 245642
			PointItem,
			// Token: 0x0403BF8B RID: 245643
			GraduateItem,
			// Token: 0x0403BF8C RID: 245644
			KeyContainerItem,
			// Token: 0x0403BF8D RID: 245645
			BottomDescItem
		}
	}
}
