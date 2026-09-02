using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E12 RID: 19986
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseBuildingDevelopBottomItem : UiPanelBase
	{
		// Token: 0x06033AF1 RID: 211697 RVA: 0x00CEA646 File Offset: 0x00CE8846
		public TrapDefenseBuildingDevelopBottomItem(bool isInDungeon)
		{
			this.IsInDungeon = isInDungeon;
		}

		// Token: 0x06033AF2 RID: 211698 RVA: 0x00CEA660 File Offset: 0x00CE8860
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickedQuickEquip));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnClickedUnload));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06033AF3 RID: 211699 RVA: 0x00CEA7B0 File Offset: 0x00CE89B0
		protected override UniTask OnBeforeStartAsync()
		{
			TrapDefenseBuildingDevelopBottomItem.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TrapDefenseBuildingDevelopBottomItem.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06033AF4 RID: 211700 RVA: 0x00CEA7F3 File Offset: 0x00CE89F3
		private void OnClickedUnload()
		{
			ModelBase<TrapDefenseModel>.Instance.ViewModelBuildingDevelop.EquipOrgan(this.CurSelectedIndex, this.MenuData);
		}

		// Token: 0x06033AF5 RID: 211701 RVA: 0x00CEA811 File Offset: 0x00CE8A11
		private void OnClickedQuickEquip()
		{
			ModelBase<TrapDefenseModel>.Instance.ViewModelBuildingDevelop.QuickEquipOrgan();
		}

		// Token: 0x06033AF6 RID: 211702 RVA: 0x00CEA824 File Offset: 0x00CE8A24
		private void OnClickedItem(TrapDefenseBuildingSlotData slot)
		{
			TrapDefenseBuildingDevelopItemData slotData = slot.GetSlotData();
			if (slotData != null)
			{
				Singleton<EventSystem>.Instance.Emit<TrapDefenseBuildingDevelopItemData>(EEventName.TrapDefenseBuildingBottomSelectUpdate, slotData);
			}
			this.CurSelectedIndex = slot.GetIndex();
			if (slotData == this.MenuData)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "TowerDefense_Battle_Unload", Array.Empty<object>());
			}
			else
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), this.GetEquipTxt(slotData), Array.Empty<object>());
			}
			this.Layout.DeselectCurrentGridProxy();
			GenericLayout<TrapDefenseBuildingDevelopBottomGrid, TrapDefenseBuildingSlotData> layout = this.Layout;
			if (layout == null)
			{
				return;
			}
			layout.SelectGridProxy(this.CurSelectedIndex, false);
		}

		// Token: 0x06033AF7 RID: 211703 RVA: 0x00CEA8BD File Offset: 0x00CE8ABD
		private bool CanExecuteChange(TrapDefenseBuildingSlotData slot)
		{
			if (!this.HasInit)
			{
				this.HasInit = true;
				return true;
			}
			return this.CurSelectedIndex != slot.GetIndex();
		}

		// Token: 0x06033AF8 RID: 211704 RVA: 0x00CEA8E1 File Offset: 0x00CE8AE1
		private TrapDefenseBuildingDevelopBottomGrid CreateItem()
		{
			return new TrapDefenseBuildingDevelopBottomGrid
			{
				OnClickCb = new Action<TrapDefenseBuildingSlotData>(this.OnClickedItem),
				CanExecuteChangeCb = new Func<TrapDefenseBuildingSlotData, bool>(this.CanExecuteChange)
			};
		}

		// Token: 0x06033AF9 RID: 211705 RVA: 0x00CEA90C File Offset: 0x00CE8B0C
		public TrapDefenseBuildingDevelopItemData CheckCurSlotEmpty()
		{
			return this.DataList[this.CurSelectedIndex].GetSlotData();
		}

		// Token: 0x06033AFA RID: 211706 RVA: 0x00CEA924 File Offset: 0x00CE8B24
		public void SetMenuSelectedData(TrapDefenseBuildingDevelopItemData data)
		{
			this.MenuData = data;
			TrapDefenseBuildingDevelopItemData slotData = this.DataList[this.CurSelectedIndex].GetSlotData();
			if (data == slotData)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "TowerDefense_Battle_Unload", Array.Empty<object>());
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), this.GetEquipTxt(data), Array.Empty<object>());
		}

		// Token: 0x06033AFB RID: 211707 RVA: 0x00CEA98C File Offset: 0x00CE8B8C
		public void UpdateSlot()
		{
			foreach (TrapDefenseBuildingDevelopBottomGrid trapDefenseBuildingDevelopBottomGrid in this.Layout.GetLayoutItemList())
			{
				trapDefenseBuildingDevelopBottomGrid.UpdateData();
			}
		}

		// Token: 0x06033AFC RID: 211708 RVA: 0x00CEA9E4 File Offset: 0x00CE8BE4
		public void UpdateEquipTxt()
		{
			if (this.DataList[this.CurSelectedIndex].GetSlotData() == this.MenuData)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "TowerDefense_Battle_Unload", Array.Empty<object>());
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), this.GetEquipTxt(this.MenuData), Array.Empty<object>());
		}

		// Token: 0x06033AFD RID: 211709 RVA: 0x00CEAA4D File Offset: 0x00CE8C4D
		private string GetEquipTxt(TrapDefenseBuildingDevelopItemData data)
		{
			if (data == null)
			{
				return "TowerDefense_Battle_Equip";
			}
			if (!data.IsBuilding)
			{
				return "TowerDefense_Battle_Equip_Auxiliary";
			}
			return "TowerDefense_Battle_Equip";
		}

		// Token: 0x06033AFE RID: 211710 RVA: 0x00CEAA6C File Offset: 0x00CE8C6C
		public List<CommonDragItemLogic<TrapDefenseBuildingDevelopDragDataItem, TrapDefenseBuildingDevelopItemData>> InitBottomDragLogic()
		{
			List<CommonDragItemLogic<TrapDefenseBuildingDevelopDragDataItem, TrapDefenseBuildingDevelopItemData>> list = new List<CommonDragItemLogic<TrapDefenseBuildingDevelopDragDataItem, TrapDefenseBuildingDevelopItemData>>();
			foreach (TrapDefenseBuildingDevelopBottomGrid trapDefenseBuildingDevelopBottomGrid in this.Layout.GetLayoutItemList())
			{
				TrapDefenseBuildingDevelopBottomInfoItem dataItem = trapDefenseBuildingDevelopBottomGrid.GetDataItem();
				CommonDragItemLogic<TrapDefenseBuildingDevelopDragDataItem, TrapDefenseBuildingDevelopItemData> commonDragItemLogic = new CommonDragItemLogic<TrapDefenseBuildingDevelopDragDataItem, TrapDefenseBuildingDevelopItemData>(dataItem.GetRootItem(), dataItem.GetDragComp(), trapDefenseBuildingDevelopBottomGrid.GridIndex, new Func<TrapDefenseBuildingDevelopDragDataItem>(this.CreateDragDataItem));
				dataItem.SetDragLogic(commonDragItemLogic);
				list.Add(commonDragItemLogic);
			}
			return list;
		}

		// Token: 0x06033AFF RID: 211711 RVA: 0x00CEAB00 File Offset: 0x00CE8D00
		public List<TrapDefenseBuildingDevelopBottomInfoItem> InitBottomDragItem()
		{
			List<TrapDefenseBuildingDevelopBottomInfoItem> list = new List<TrapDefenseBuildingDevelopBottomInfoItem>();
			foreach (TrapDefenseBuildingDevelopBottomGrid trapDefenseBuildingDevelopBottomGrid in this.Layout.GetLayoutItemList())
			{
				list.Add(trapDefenseBuildingDevelopBottomGrid.GetDataItem());
			}
			return list;
		}

		// Token: 0x06033B00 RID: 211712 RVA: 0x00CEAB64 File Offset: 0x00CE8D64
		private TrapDefenseBuildingDevelopDragDataItem CreateDragDataItem()
		{
			return new TrapDefenseBuildingDevelopDragDataItem();
		}

		// Token: 0x0401DEE3 RID: 122595
		protected GenericLayout<TrapDefenseBuildingDevelopBottomGrid, TrapDefenseBuildingSlotData> Layout;

		// Token: 0x0401DEE4 RID: 122596
		protected List<TrapDefenseBuildingSlotData> DataList = new List<TrapDefenseBuildingSlotData>();

		// Token: 0x0401DEE5 RID: 122597
		protected TrapDefenseBuildingDevelopItemData MenuData;

		// Token: 0x0401DEE6 RID: 122598
		protected int CurSelectedIndex;

		// Token: 0x0401DEE7 RID: 122599
		protected bool HasInit;

		// Token: 0x0401DEE8 RID: 122600
		protected bool IsInDungeon;

		// Token: 0x0200AD88 RID: 44424
		[NullableContext(0)]
		private class EDefine
		{
			// Token: 0x04035E45 RID: 220741
			public const int ContentLayout = 0;

			// Token: 0x04035E46 RID: 220742
			public const int PanelItemLayout = 1;

			// Token: 0x04035E47 RID: 220743
			public const int Item = 2;

			// Token: 0x04035E48 RID: 220744
			public const int BtnQuickEquipped = 3;

			// Token: 0x04035E49 RID: 220745
			public const int TxtBtn = 4;

			// Token: 0x04035E4A RID: 220746
			public const int BtnConfirm = 5;
		}
	}
}
