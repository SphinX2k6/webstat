using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Cook.View
{
	// Token: 0x02005E0F RID: 24079
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class CookItemView : GridProxyAbstract<ICookItemData>
	{
		// Token: 0x0603C97A RID: 248186 RVA: 0x00F62B64 File Offset: 0x00F60D64
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(6, new Action<EToggleState>(this.OnItemButtonClicked));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603C97B RID: 248187 RVA: 0x00F62CB4 File Offset: 0x00F60EB4
		public override void Refresh(ICookItemData data, bool isSelected, int gridIndex)
		{
			ICookingData cookingData = data as ICookingData;
			if (cookingData != null)
			{
				this.Refresh(cookingData, isSelected, gridIndex);
				return;
			}
			IMachiningData machiningData = data as IMachiningData;
			if (machiningData != null)
			{
				this.Refresh(machiningData, isSelected, gridIndex);
			}
		}

		// Token: 0x0603C97C RID: 248188 RVA: 0x00F62CE8 File Offset: 0x00F60EE8
		public void Refresh(ICookingData data, bool isSelected, int gridIndex)
		{
			this.ItemData = data;
			this.RefreshQuality();
			this.RefreshIcon();
			this.RefreshLock();
			this.RefreshShadow();
			this.RefreshNew();
			this.RefreshName();
			this.Selected(isSelected, false);
		}

		// Token: 0x0603C97D RID: 248189 RVA: 0x00F62D1D File Offset: 0x00F60F1D
		public void Refresh(IMachiningData data, bool isSelected, int gridIndex)
		{
			this.MachiningItemData = data;
			this.RefreshQuality();
			this.RefreshIcon();
			this.RefreshLock();
			this.RefreshShadow();
			this.RefreshNew();
			this.RefreshName();
			this.Selected(isSelected, false);
		}

		// Token: 0x0603C97E RID: 248190 RVA: 0x00F62D54 File Offset: 0x00F60F54
		private void RefreshQuality()
		{
			if (this.ItemData != null)
			{
				if (this.ItemData.MainType == ECookListType.Cooking)
				{
					if (this.ItemData.SubType == ESubCookDataType.CookFood)
					{
						CookFormula cookFormulaById = ConfigBase<CookConfig>.Instance.GetCookFormulaById(this.ItemData.ItemId);
						base.SetItemQualityIcon(base.GetSprite(10), cookFormulaById.FoodItemId, null, CommonDefine.EQualityIconType.BackgroundSprite, null);
						return;
					}
					base.SetItemQualityIcon(base.GetSprite(10), this.ItemData.ItemId, null, CommonDefine.EQualityIconType.BackgroundSprite, null);
					return;
				}
			}
			else if (this.MachiningItemData != null)
			{
				CookProcessed cookProcessedById = ConfigBase<CookConfig>.Instance.GetCookProcessedById(this.MachiningItemData.ItemId);
				base.SetItemQualityIcon(base.GetSprite(10), cookProcessedById.FinalItemId, null, CommonDefine.EQualityIconType.BackgroundSprite, null);
			}
		}

		// Token: 0x0603C97F RID: 248191 RVA: 0x00F62E20 File Offset: 0x00F61020
		private void RefreshIcon()
		{
			if (this.ItemData != null)
			{
				if (this.ItemData.MainType == ECookListType.Cooking)
				{
					if (this.ItemData.SubType == ESubCookDataType.CookFood)
					{
						CookFormula cookFormulaById = ConfigBase<CookConfig>.Instance.GetCookFormulaById(this.ItemData.ItemId);
						base.SetItemIcon(base.GetTexture(11), cookFormulaById.FoodItemId, null, null);
						return;
					}
					base.SetItemIcon(base.GetTexture(11), this.ItemData.ItemId, null, null);
					return;
				}
			}
			else if (this.MachiningItemData != null)
			{
				CookProcessed cookProcessedById = ConfigBase<CookConfig>.Instance.GetCookProcessedById(this.MachiningItemData.ItemId);
				base.SetItemIcon(base.GetTexture(11), cookProcessedById.FinalItemId, null, null);
			}
		}

		// Token: 0x0603C980 RID: 248192 RVA: 0x00F62EEC File Offset: 0x00F610EC
		private void RefreshName()
		{
			if (this.ItemData != null)
			{
				if (this.ItemData.MainType == ECookListType.Cooking)
				{
					CookFormula cookFormulaById = ConfigBase<CookConfig>.Instance.GetCookFormulaById(this.ItemData.ItemId);
					Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(12), cookFormulaById.Name, Array.Empty<object>());
					return;
				}
			}
			else if (this.MachiningItemData != null)
			{
				CookProcessed cookProcessedById = ConfigBase<CookConfig>.Instance.GetCookProcessedById(this.MachiningItemData.ItemId);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(12), cookProcessedById.Name, Array.Empty<object>());
			}
		}

		// Token: 0x0603C981 RID: 248193 RVA: 0x00F62F80 File Offset: 0x00F61180
		private void RefreshLock()
		{
			if (this.MachiningItemData != null)
			{
				base.GetItem(7).SetUIActive(!this.MachiningItemData.IsUnLock);
				return;
			}
			if (this.ItemData != null)
			{
				base.GetItem(7).SetUIActive(!this.ItemData.IsUnLock);
			}
		}

		// Token: 0x0603C982 RID: 248194 RVA: 0x00F62FD4 File Offset: 0x00F611D4
		private void RefreshShadow()
		{
			if (this.MachiningItemData != null)
			{
				bool flag = ControllerBase<CookController>.Instance.CheckCanProcessed(this.MachiningItemData.ItemId) && this.MachiningItemData.IsUnLock;
				base.GetItem(8).SetUIActive(!flag);
				return;
			}
			if (this.ItemData != null)
			{
				if (this.ItemData.SubType == ESubCookDataType.CookMenu)
				{
					base.GetItem(8).SetUIActive(false);
					return;
				}
				bool flag2 = ControllerBase<CookController>.Instance.CheckCanCook(this.ItemData.ItemId);
				base.GetItem(8).SetUIActive(!flag2);
			}
		}

		// Token: 0x0603C983 RID: 248195 RVA: 0x00F63070 File Offset: 0x00F61270
		private void RefreshNew()
		{
			if (this.ItemData != null)
			{
				base.GetItem(9).SetUIActive(this.ItemData.IsNew);
				return;
			}
			if (this.MachiningItemData != null)
			{
				base.GetItem(9).SetUIActive(this.MachiningItemData.IsNew);
			}
		}

		// Token: 0x0603C984 RID: 248196 RVA: 0x00F630BE File Offset: 0x00F612BE
		public void BindOnClickedCallback(Action<ICookingData> onItemButtonClicked)
		{
			this.OnCookingClickedCallback = onItemButtonClicked;
		}

		// Token: 0x0603C985 RID: 248197 RVA: 0x00F630C7 File Offset: 0x00F612C7
		public void BindOnClickedCallback(Action<IMachiningData> onItemButtonClicked)
		{
			this.OnMachiningClickedCallback = onItemButtonClicked;
		}

		// Token: 0x0603C986 RID: 248198 RVA: 0x00F630D0 File Offset: 0x00F612D0
		public override void OnSelected(bool fireEvent)
		{
			this.Selected(true, true);
		}

		// Token: 0x0603C987 RID: 248199 RVA: 0x00F630DA File Offset: 0x00F612DA
		public override void OnDeselected(bool fireEvent)
		{
			this.Selected(false, true);
		}

		// Token: 0x0603C988 RID: 248200 RVA: 0x00F630E4 File Offset: 0x00F612E4
		private void Selected(bool bSelected, bool fire = true)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(6);
			if (bSelected)
			{
				extendToggle.SetToggleState(EToggleState.ETT_Checked, fire, false, false);
				return;
			}
			extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x0603C989 RID: 248201 RVA: 0x00F63114 File Offset: 0x00F61314
		private void OnItemButtonClicked(EToggleState state)
		{
			if (this.ItemData != null && this.OnCookingClickedCallback != null)
			{
				this.OnCookingClickedCallback(this.ItemData);
				this.RefreshNew();
				return;
			}
			if (this.MachiningItemData != null && this.OnMachiningClickedCallback != null)
			{
				this.OnMachiningClickedCallback(this.MachiningItemData);
				this.RefreshNew();
			}
		}

		// Token: 0x040220DE RID: 139486
		[Nullable(2)]
		private ICookingData ItemData;

		// Token: 0x040220DF RID: 139487
		[Nullable(2)]
		private IMachiningData MachiningItemData;

		// Token: 0x040220E0 RID: 139488
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<ICookingData> OnCookingClickedCallback;

		// Token: 0x040220E1 RID: 139489
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<IMachiningData> OnMachiningClickedCallback;

		// Token: 0x0200BE49 RID: 48713
		[NullableContext(0)]
		private enum ECookItemDefine
		{
			// Token: 0x0403A952 RID: 239954
			CookExtendToggle = 6,
			// Token: 0x0403A953 RID: 239955
			LockItem,
			// Token: 0x0403A954 RID: 239956
			ShadowItem,
			// Token: 0x0403A955 RID: 239957
			NewItem,
			// Token: 0x0403A956 RID: 239958
			QualitySprite,
			// Token: 0x0403A957 RID: 239959
			IconTexture,
			// Token: 0x0403A958 RID: 239960
			TxtName,
			// Token: 0x0403A959 RID: 239961
			RedDotItem
		}
	}
}
