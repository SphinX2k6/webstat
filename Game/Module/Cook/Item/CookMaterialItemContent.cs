using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Manufacture.Common;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Cook.Item
{
	// Token: 0x02005E2F RID: 24111
	public class CookMaterialItemContent : UiPanelBase
	{
		// Token: 0x0603CAD7 RID: 248535 RVA: 0x00F695CC File Offset: 0x00F677CC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 12;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action<EToggleState>(this.OnClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603CAD8 RID: 248536 RVA: 0x00F697C0 File Offset: 0x00F679C0
		private void OnClick(EToggleState toggleState)
		{
			Action clickDelegate = this.ClickDelegate;
			if (clickDelegate == null)
			{
				return;
			}
			clickDelegate();
		}

		// Token: 0x0603CAD9 RID: 248537 RVA: 0x00F697D2 File Offset: 0x00F679D2
		public void SetSelect()
		{
			base.GetExtendToggle(4).SetToggleState(EToggleState.ETT_Checked, false, false, false);
		}

		// Token: 0x0603CADA RID: 248538 RVA: 0x00F697E5 File Offset: 0x00F679E5
		public void SetDelect()
		{
			base.GetExtendToggle(4).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x0603CADB RID: 248539 RVA: 0x00F697F8 File Offset: 0x00F679F8
		protected override void OnStart()
		{
			base.GetSprite(0).SetUIActive(true);
			base.GetTexture(1).SetUIActive(true);
			base.GetText(2).SetUIActive(true);
			UUIItem uuiitem = base.GetExtendToggle(4).GetOwner().GetComponentByClass(UUITexture.StaticClass()) as UUIItem;
			if (uuiitem != null)
			{
				uuiitem.SetUIActive(true);
			}
			base.GetItem(3).SetUIActive(true);
			base.GetItem(5).SetUIActive(false);
			base.GetItem(6).SetUIActive(false);
			base.GetItem(7).SetUIActive(false);
			base.GetItem(8).SetUIActive(false);
			base.GetText(9).SetUIActive(false);
			base.GetSprite(10).SetUIActive(false);
			base.GetSprite(11).SetUIActive(false);
		}

		// Token: 0x0603CADC RID: 248540 RVA: 0x00F698C3 File Offset: 0x00F67AC3
		[NullableContext(1)]
		public void Update(ISingleItemInfo data)
		{
			this.CookItemData = data;
			this.RefreshHave(1);
			this.RefreshIcon();
			this.RefreshQuality();
		}

		// Token: 0x0603CADD RID: 248541 RVA: 0x00F698DF File Offset: 0x00F67ADF
		public void RefreshNeed(int num = 1)
		{
			this.RefreshHave(num);
		}

		// Token: 0x0603CADE RID: 248542 RVA: 0x00F698E8 File Offset: 0x00F67AE8
		protected void RefreshHave(int times = 1)
		{
			int num = this.CookItemData.Proto_ItemNum * times;
			int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(this.CookItemData.Proto_ItemId, 0);
			string newText;
			if (this.CookItemData.Proto_IsUnlock)
			{
				if (itemCountByConfigId < this.CookItemData.Proto_ItemNum)
				{
					newText = StringUtils.Format("<color=#f55e66>{0}</color>/{1}", new string[]
					{
						itemCountByConfigId.ToString(),
						num.ToString()
					});
				}
				else
				{
					newText = StringUtils.Format("<color=#f7eba6>{0}</color>/{1}", new string[]
					{
						itemCountByConfigId.ToString(),
						num.ToString()
					});
				}
			}
			else
			{
				newText = StringUtils.Format("--/{0}", new string[]
				{
					num.ToString()
				});
			}
			base.GetText(2).SetText(newText, true);
		}

		// Token: 0x0603CADF RID: 248543 RVA: 0x00F699B0 File Offset: 0x00F67BB0
		private void RefreshIcon()
		{
			if (this.CookItemData.Proto_IsUnlock)
			{
				base.GetTexture(1).SetUIActive(true);
				base.SetTextureByPath(ConfigBase<ItemConfig>.Instance.GetConfig(this.CookItemData.Proto_ItemId).Value.Icon, base.GetTexture(1), null, null);
				return;
			}
			base.GetTexture(1).SetUIActive(false);
		}

		// Token: 0x0603CAE0 RID: 248544 RVA: 0x00F69A24 File Offset: 0x00F67C24
		private void RefreshQuality()
		{
			if (this.CookItemData.Proto_IsUnlock)
			{
				base.GetSprite(0).SetUIActive(true);
				base.SetItemQualityIcon(base.GetSprite(0), this.CookItemData.Proto_ItemId, null, global::CommonDefine.EQualityIconType.BackgroundSprite, null);
				return;
			}
			base.GetSprite(0).SetUIActive(false);
		}

		// Token: 0x0603CAE1 RID: 248545 RVA: 0x00F69A7C File Offset: 0x00F67C7C
		protected override void OnBeforeDestroy()
		{
		}

		// Token: 0x04022142 RID: 139586
		[Nullable(2)]
		private ISingleItemInfo CookItemData;

		// Token: 0x04022143 RID: 139587
		[Nullable(2)]
		public Action ClickDelegate;

		// Token: 0x0200BE66 RID: 48742
		private enum ECookMaterialItemComponents
		{
			// Token: 0x0403A9FC RID: 240124
			SprQuality,
			// Token: 0x0403A9FD RID: 240125
			TexIcon,
			// Token: 0x0403A9FE RID: 240126
			TxtNum,
			// Token: 0x0403A9FF RID: 240127
			PnlNum,
			// Token: 0x0403AA00 RID: 240128
			PnlItemBase,
			// Token: 0x0403AA01 RID: 240129
			PnlRedPoint,
			// Token: 0x0403AA02 RID: 240130
			PnlRedPoint1,
			// Token: 0x0403AA03 RID: 240131
			PnlCD,
			// Token: 0x0403AA04 RID: 240132
			BarCd,
			// Token: 0x0403AA05 RID: 240133
			TxtCD,
			// Token: 0x0403AA06 RID: 240134
			SprDark,
			// Token: 0x0403AA07 RID: 240135
			SprLock
		}
	}
}
