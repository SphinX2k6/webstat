using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001EAF RID: 7855
internal class WeaponHandBookLayoutItem : UiPanelBase
{
	// Token: 0x0600E84F RID: 59471 RVA: 0x003ECCB2 File Offset: 0x003EAEB2
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIGridLayout))
		};
	}

	// Token: 0x0600E850 RID: 59472 RVA: 0x003ECCD5 File Offset: 0x003EAED5
	protected override void OnStart()
	{
		this.GridLayout = new GenericLayout<WeaponHandBookWeaponItem, WeaponHandBookDynamicLayoutItemData>(base.GetGridLayout(0), new Func<WeaponHandBookWeaponItem>(this.InitItem), null, false, true);
	}

	// Token: 0x0600E851 RID: 59473 RVA: 0x003ECCF8 File Offset: 0x003EAEF8
	[NullableContext(1)]
	private WeaponHandBookWeaponItem InitItem()
	{
		return new WeaponHandBookWeaponItem
		{
			OnClickCallBack = this.OnClickCallBack
		};
	}

	// Token: 0x0600E852 RID: 59474 RVA: 0x003ECD0B File Offset: 0x003EAF0B
	[NullableContext(1)]
	public void Update(List<WeaponHandBookDynamicLayoutItemData> dataList)
	{
		GenericLayout<WeaponHandBookWeaponItem, WeaponHandBookDynamicLayoutItemData> gridLayout = this.GridLayout;
		if (gridLayout == null)
		{
			return;
		}
		gridLayout.RefreshByData(dataList, delegate
		{
			GenericLayout<WeaponHandBookWeaponItem, WeaponHandBookDynamicLayoutItemData> gridLayout2 = this.GridLayout;
			foreach (WeaponHandBookWeaponItem weaponHandBookWeaponItem in (((gridLayout2 != null) ? gridLayout2.GetLayoutItemList() : null) ?? new List<WeaponHandBookWeaponItem>()))
			{
				if (weaponHandBookWeaponItem.HandBookId == ModelBase<HandBookModel>.Instance.CurrentSelectWeaponHandBookId)
				{
					weaponHandBookWeaponItem.OnSelected(true);
					break;
				}
			}
		}, false);
	}

	// Token: 0x04006FEA RID: 28650
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<UUIExtendToggle, int> OnClickCallBack;

	// Token: 0x04006FEB RID: 28651
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<WeaponHandBookWeaponItem, WeaponHandBookDynamicLayoutItemData> GridLayout;

	// Token: 0x020081F1 RID: 33265
	private class EWeaponHandBookLayoutItemDefine
	{
		// Token: 0x0402C150 RID: 180560
		public const int Layout = 0;

		// Token: 0x0402C151 RID: 180561
		public const int Item = 1;
	}
}
