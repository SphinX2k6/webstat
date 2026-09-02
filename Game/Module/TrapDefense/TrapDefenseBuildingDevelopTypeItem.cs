using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E1B RID: 19995
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class TrapDefenseBuildingDevelopTypeItem : GridProxyAbstract<TrapDefenseBuildingTypeData>
	{
		// Token: 0x06033B3F RID: 211775 RVA: 0x00CEBF30 File Offset: 0x00CEA130
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIGridLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06033B40 RID: 211776 RVA: 0x00CEBFFC File Offset: 0x00CEA1FC
		protected override void OnStart()
		{
			UUIItem item = base.GetItem(4);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			this.Layout = new GenericLayout<TrapDefenseBuildingDevelopTypeGridItem, TrapDefenseBuildingDevelopItemData>(base.GetGridLayout(2), new Func<TrapDefenseBuildingDevelopTypeGridItem>(this.InitGridItem), null, false, true);
		}

		// Token: 0x06033B41 RID: 211777 RVA: 0x00CEC034 File Offset: 0x00CEA234
		private TrapDefenseBuildingDevelopTypeGridItem InitGridItem()
		{
			return new TrapDefenseBuildingDevelopTypeGridItem
			{
				OnItemClickCallback = new Action<TrapDefenseBuildingDevelopItemData>(this.OnClickItem),
				CanExecuteChangeCb = new Func<TrapDefenseBuildingDevelopItemData, bool>(this.CanExecuteChange),
				OnPointDownCb = new Action<TrapDefenseBuildingDevelopTypeGridItem, TrapDefenseBuildingDevelopItemData>(this.OnPointerDown),
				OnPointUpCb = new Action<TrapDefenseBuildingDevelopTypeGridItem, TrapDefenseBuildingDevelopItemData>(this.OnPointerUp)
			};
		}

		// Token: 0x06033B42 RID: 211778 RVA: 0x00CEC08E File Offset: 0x00CEA28E
		public void SetScrollParent(UUIScrollViewWithScrollbarComponent scroll)
		{
			this.ScrollParent = scroll;
		}

		// Token: 0x06033B43 RID: 211779 RVA: 0x00CEC097 File Offset: 0x00CEA297
		public bool GetChildRefreshed()
		{
			return this.IsRefreshed;
		}

		// Token: 0x06033B44 RID: 211780 RVA: 0x00CEC0A0 File Offset: 0x00CEA2A0
		public override void Refresh(TrapDefenseBuildingTypeData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			this.DataList = data.GetDataList();
			if (data.IsInDungeon && data.Type == ETrapDefenseMachineType.Auxiliary)
			{
				this.RefreshAuxiliaryTabName();
			}
			else
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.GetTitleId(), Array.Empty<object>());
			}
			this.IsRefreshed = false;
			this.Layout.RefreshByData(this.DataList, delegate
			{
				this.SetInitSelect();
				this.IsRefreshed = true;
				if (this.ScrollParent != null)
				{
					TimerSystem.Instance.Next(delegate(float _)
					{
						TimerSystem.Instance.Next(delegate(float _)
						{
							FVector2D fvector2D = new FVector2D();
							UUIScrollViewWithScrollbarComponent scrollParent = this.ScrollParent;
							if (scrollParent != null)
							{
								scrollParent.ScrollToTop(ref fvector2D, this.RootItem, false);
							}
							this.ScrollParent = null;
						}, null, null);
					}, null, null);
				}
			}, true);
		}

		// Token: 0x06033B45 RID: 211781 RVA: 0x00CEC11C File Offset: 0x00CEA31C
		private void RefreshAuxiliaryTabName()
		{
			List<TrapDefenseBuildingSlotData> slotData = ModelBase<TrapDefenseModel>.Instance.ViewModelBuildingDevelop.GetSlotData();
			int num = 0;
			foreach (TrapDefenseBuildingSlotData trapDefenseBuildingSlotData in slotData)
			{
				TrapDefenseBuildingDevelopItemData slotData2 = trapDefenseBuildingSlotData.GetSlotData();
				if (slotData2 != null)
				{
					num += ((slotData2 == null || !slotData2.IsBuilding) ? 1 : 0);
				}
			}
			float auxiliaryLimit = ModelBase<TrapDefenseModel>.Instance.BattleData.GetAuxiliaryLimit();
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), this.Data.GetTitleId(), new <>z__ReadOnlyArray<object>(new object[]
			{
				num,
				auxiliaryLimit
			}));
		}

		// Token: 0x06033B46 RID: 211782 RVA: 0x00CEC1D8 File Offset: 0x00CEA3D8
		public void UpdateEquipped()
		{
			if (this.Data.IsInDungeon && this.Data.Type == ETrapDefenseMachineType.Auxiliary)
			{
				this.RefreshAuxiliaryTabName();
			}
			foreach (TrapDefenseBuildingDevelopTypeGridItem trapDefenseBuildingDevelopTypeGridItem in this.Layout.GetLayoutItemList())
			{
				trapDefenseBuildingDevelopTypeGridItem.UpdateState();
			}
		}

		// Token: 0x06033B47 RID: 211783 RVA: 0x00CEC250 File Offset: 0x00CEA450
		public void SetInitSelect()
		{
			if (this.Data.CurSelectedData != null)
			{
				int num = this.DataList.IndexOf(this.Data.CurSelectedData);
				this.Layout.SelectGridProxy(num, false);
				TrapDefenseBuildingDevelopTypeGridItem layoutItemByIndex = this.Layout.GetLayoutItemByIndex(num);
				if (layoutItemByIndex != null)
				{
					layoutItemByIndex.OnForceSelected();
				}
				Singleton<EventSystem>.Instance.Emit<TrapDefenseBuildingDevelopItemData>(EEventName.TrapDefenseBuildingDevelopSelectUpdate, this.Data.CurSelectedData);
				return;
			}
			this.Layout.DeselectCurrentGridProxy();
		}

		// Token: 0x06033B48 RID: 211784 RVA: 0x00CEC2CC File Offset: 0x00CEA4CC
		public void CheckSelectedIsInTypeItem(TrapDefenseBuildingDevelopItemData data)
		{
			this.Layout.DeselectCurrentGridProxy();
			if (this.Data.PlacementType != data.GetPlacementType())
			{
				return;
			}
			int gridIndex = this.DataList.IndexOf(data);
			GenericLayout<TrapDefenseBuildingDevelopTypeGridItem, TrapDefenseBuildingDevelopItemData> layout = this.Layout;
			if (layout == null)
			{
				return;
			}
			layout.SelectGridProxy(gridIndex, false);
		}

		// Token: 0x06033B49 RID: 211785 RVA: 0x00CEC318 File Offset: 0x00CEA518
		public bool CheckBottomItemIsInTypeItem(TrapDefenseBuildingDevelopItemData data)
		{
			this.Layout.DeselectCurrentGridProxy();
			if (this.Data.PlacementType != data.GetPlacementType())
			{
				return false;
			}
			int num = this.DataList.IndexOf(data);
			GenericLayout<TrapDefenseBuildingDevelopTypeGridItem, TrapDefenseBuildingDevelopItemData> layout = this.Layout;
			if (layout != null)
			{
				layout.SelectGridProxy(num, false);
			}
			TrapDefenseBuildingDevelopTypeGridItem layoutItemByIndex = this.Layout.GetLayoutItemByIndex(num);
			if (layoutItemByIndex != null)
			{
				layoutItemByIndex.OnForceSelected();
			}
			return true;
		}

		// Token: 0x06033B4A RID: 211786 RVA: 0x00CEC380 File Offset: 0x00CEA580
		private void OnClickItem(TrapDefenseBuildingDevelopItemData data)
		{
			TrapDefenseBuildingDevelopItemData curSelectedData = this.Data.CurSelectedData;
			Singleton<EventSystem>.Instance.Emit<TrapDefenseBuildingDevelopItemData>(EEventName.TrapDefenseBuildingDevelopSelectUpdate, data);
			if (curSelectedData != null)
			{
				int index = this.DataList.IndexOf(curSelectedData);
				TrapDefenseBuildingDevelopTypeGridItem layoutItemByIndex = this.Layout.GetLayoutItemByIndex(index);
				if (layoutItemByIndex == null)
				{
					return;
				}
				layoutItemByIndex.OnDeselected(false);
			}
		}

		// Token: 0x06033B4B RID: 211787 RVA: 0x00CEC3D1 File Offset: 0x00CEA5D1
		private bool CanExecuteChange(TrapDefenseBuildingDevelopItemData data)
		{
			return data != this.Data.CurSelectedData;
		}

		// Token: 0x06033B4C RID: 211788 RVA: 0x00CEC3E4 File Offset: 0x00CEA5E4
		private void OnPointerDown(TrapDefenseBuildingDevelopTypeGridItem item, TrapDefenseBuildingDevelopItemData data)
		{
			if (this.OnPointerDownCb != null)
			{
				this.OnPointerDownCb(item, data);
			}
		}

		// Token: 0x06033B4D RID: 211789 RVA: 0x00CEC3FB File Offset: 0x00CEA5FB
		private void OnPointerUp(TrapDefenseBuildingDevelopTypeGridItem item, TrapDefenseBuildingDevelopItemData data)
		{
			if (this.OnPointerUpCb != null)
			{
				this.OnPointerUpCb(item, data);
			}
		}

		// Token: 0x06033B4E RID: 211790 RVA: 0x00CEC414 File Offset: 0x00CEA614
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams.Length == 0)
			{
				return null;
			}
			string a = configParams[0];
			if (!(a == "MachineGrid"))
			{
				if (a == "FirstLevelTwoGrid")
				{
					int num = this.DataList.FindIndex((TrapDefenseBuildingDevelopItemData data) => data.GetLevel() == 2);
					if (num >= 0)
					{
						GenericLayout<TrapDefenseBuildingDevelopTypeGridItem, TrapDefenseBuildingDevelopItemData> layout = this.Layout;
						UUIItem uuiitem = (layout != null) ? layout.GetItemByIndex(num) : null;
						if (uuiitem == null)
						{
							return null;
						}
						return new UUIItem[]
						{
							uuiitem,
							uuiitem
						};
					}
				}
				return null;
			}
			if (configParams.Length < 3)
			{
				return null;
			}
			int num2;
			if (!int.TryParse(configParams[2], out num2) || num2 < 0 || num2 >= this.DataList.Count)
			{
				return null;
			}
			UUIItem itemByIndex = this.Layout.GetItemByIndex(num2);
			if (itemByIndex == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				itemByIndex,
				itemByIndex
			};
		}

		// Token: 0x0401DF03 RID: 122627
		private TrapDefenseBuildingTypeData Data;

		// Token: 0x0401DF04 RID: 122628
		private List<TrapDefenseBuildingDevelopItemData> DataList = new List<TrapDefenseBuildingDevelopItemData>();

		// Token: 0x0401DF05 RID: 122629
		private UUIScrollViewWithScrollbarComponent ScrollParent;

		// Token: 0x0401DF06 RID: 122630
		private bool IsRefreshed;

		// Token: 0x0401DF07 RID: 122631
		public Action<TrapDefenseBuildingDevelopTypeGridItem, TrapDefenseBuildingDevelopItemData> OnPointerDownCb;

		// Token: 0x0401DF08 RID: 122632
		public Action<TrapDefenseBuildingDevelopTypeGridItem, TrapDefenseBuildingDevelopItemData> OnPointerUpCb;

		// Token: 0x0401DF09 RID: 122633
		protected GenericLayout<TrapDefenseBuildingDevelopTypeGridItem, TrapDefenseBuildingDevelopItemData> Layout;

		// Token: 0x0200AD95 RID: 44437
		[NullableContext(0)]
		private class EItemType
		{
			// Token: 0x04035E7F RID: 220799
			public const int Icon = 0;

			// Token: 0x04035E80 RID: 220800
			public const int Title = 1;

			// Token: 0x04035E81 RID: 220801
			public const int Layout = 2;

			// Token: 0x04035E82 RID: 220802
			public const int ItemBase = 3;

			// Token: 0x04035E83 RID: 220803
			public const int PanelIcon = 4;
		}
	}
}
