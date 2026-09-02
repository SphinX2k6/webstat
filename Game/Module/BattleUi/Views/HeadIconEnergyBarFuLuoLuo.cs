using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200601D RID: 24605
	[NullableContext(1)]
	[Nullable(0)]
	public class HeadIconEnergyBarFuLuoLuo : HeadIconEnergyBarBase
	{
		// Token: 0x0603E017 RID: 253975 RVA: 0x00FD29A0 File Offset: 0x00FD0BA0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
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
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E018 RID: 253976 RVA: 0x00FD2A90 File Offset: 0x00FD0C90
		protected override UniTask OnBeforeStartAsync()
		{
			HeadIconEnergyBarFuLuoLuo.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<HeadIconEnergyBarFuLuoLuo.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603E019 RID: 253977 RVA: 0x00FD2AD3 File Offset: 0x00FD0CD3
		protected override void OnStart()
		{
		}

		// Token: 0x0603E01A RID: 253978 RVA: 0x00FD2AD5 File Offset: 0x00FD0CD5
		public override void Tick(float delta)
		{
		}

		// Token: 0x0603E01B RID: 253979 RVA: 0x00FD2AD7 File Offset: 0x00FD0CD7
		protected override void OnBeforeShow()
		{
			base.OnBeforeShow();
			BaseTagComponent tagComponent = this.TagComponent;
			this.SetBurstState(tagComponent != null && tagComponent.HasTag(HeadIconEnergyBarFuLuoLuo.BurstTag));
			this.RefreshAttribute();
			this.RefreshEnergy();
		}

		// Token: 0x0603E01C RID: 253980 RVA: 0x00FD2B08 File Offset: 0x00FD0D08
		protected override void AddEvents()
		{
			base.AddEvents();
			base.ListenForTagAddOrRemoveChanged(HeadIconEnergyBarFuLuoLuo.BurstTag, new BaseTagComponent.TTagSwitchedCallback(this.OnBurstTagChange));
		}

		// Token: 0x0603E01D RID: 253981 RVA: 0x00FD2B27 File Offset: 0x00FD0D27
		protected override void RemoveEvents()
		{
			base.RemoveEvents();
			base.RemoveListenTagAddOrRemove(HeadIconEnergyBarFuLuoLuo.BurstTag);
		}

		// Token: 0x0603E01E RID: 253982 RVA: 0x00FD2B3A File Offset: 0x00FD0D3A
		private void OnBurstTagChange(int tagId, bool tagExist)
		{
			this.SetBurstState(tagExist);
			this.RefreshEnergy();
		}

		// Token: 0x0603E01F RID: 253983 RVA: 0x00FD2B49 File Offset: 0x00FD0D49
		protected override void OnAttributeChanged()
		{
			this.RefreshAttribute();
			this.RefreshEnergy();
		}

		// Token: 0x0603E020 RID: 253984 RVA: 0x00FD2B58 File Offset: 0x00FD0D58
		private void RefreshAttribute()
		{
			double num = (double)this.AttributeComponent.GetCurrentValue(this.AttributeId);
			if (num == this.AttributeValue)
			{
				return;
			}
			this.AttributeValue = num;
			this.DirtyMark = true;
		}

		// Token: 0x0603E021 RID: 253985 RVA: 0x00FD2B90 File Offset: 0x00FD0D90
		private void SetBurstState(bool state)
		{
			if (this.BurstState == state)
			{
				return;
			}
			this.BurstState = state;
			this.DirtyMark = true;
		}

		// Token: 0x0603E022 RID: 253986 RVA: 0x00FD2BAA File Offset: 0x00FD0DAA
		private void RefreshEnergy()
		{
			if (!this.DirtyMark)
			{
				return;
			}
			this.RefreshAllNoteItemEnergyType();
			this.DirtyMark = false;
		}

		// Token: 0x0603E023 RID: 253987 RVA: 0x00FD2BC4 File Offset: 0x00FD0DC4
		private void RefreshAllNoteItemEnergyType()
		{
			int num = 0;
			for (int i = 0; i < 6; i++)
			{
				int num2 = (6 - i - 1) * 2;
				int num3 = ((int)this.AttributeValue & 3 << num2) >> num2;
				if (this.BurstState || num3 > 0)
				{
					this.SpecialEnergyTypeList[num] = num3;
					num++;
				}
			}
			for (int j = 0; j < this.NoteItemList.Length; j++)
			{
				HeadIconEnergyBarFuLuoLuoNoteItem headIconEnergyBarFuLuoLuoNoteItem = this.NoteItemList[j];
				int energyType = (j < num) ? this.SpecialEnergyTypeList[j] : 0;
				headIconEnergyBarFuLuoLuoNoteItem.SetEnergyType(energyType);
			}
		}

		// Token: 0x04022C50 RID: 142416
		private const int SPECIAL_ENERGY_COUNT = 6;

		// Token: 0x04022C51 RID: 142417
		private static readonly int BurstTag = GameplayTagDefine.EGameplayTagId["角色.R2T1FuluoluoMd10011.状态标识.大招状态"];

		// Token: 0x04022C52 RID: 142418
		private const string NOTE_ITEM_PATH = "/Game/Aki/UI/UIResources/UiFight/Prefabs/EnergyBar/UiItem_BarFuLuoLuoAPoint.UiItem_BarFuLuoLuoAPoint";

		// Token: 0x04022C53 RID: 142419
		private readonly UUIItem[] SlotItemList = new UUIItem[6];

		// Token: 0x04022C54 RID: 142420
		private readonly HeadIconEnergyBarFuLuoLuoNoteItem[] NoteItemList = new HeadIconEnergyBarFuLuoLuoNoteItem[6];

		// Token: 0x04022C55 RID: 142421
		private readonly int[] SpecialEnergyTypeList = new int[6];

		// Token: 0x04022C56 RID: 142422
		private double AttributeValue;

		// Token: 0x04022C57 RID: 142423
		private bool BurstState;

		// Token: 0x04022C58 RID: 142424
		private bool DirtyMark;

		// Token: 0x0200C0C9 RID: 49353
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403B5AE RID: 243118
			SlotItem1,
			// Token: 0x0403B5AF RID: 243119
			SlotItem2,
			// Token: 0x0403B5B0 RID: 243120
			SlotItem3,
			// Token: 0x0403B5B1 RID: 243121
			SlotItem4,
			// Token: 0x0403B5B2 RID: 243122
			SlotItem5,
			// Token: 0x0403B5B3 RID: 243123
			SlotItem6
		}
	}
}
