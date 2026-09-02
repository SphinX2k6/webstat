using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002A02 RID: 10754
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class ShopItemNew : GridProxyAbstract<ShopItemFullInfo>
{
	// Token: 0x06015753 RID: 87891 RVA: 0x005F2C28 File Offset: 0x005F0E28
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(10, typeof(UUISprite)),
			new ValueTuple<int, Type>(11, typeof(UUISprite))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(4, new Action<EToggleState>(this.ButtonClick))
		};
	}

	// Token: 0x06015754 RID: 87892 RVA: 0x005F2D00 File Offset: 0x005F0F00
	public void UpdateItem(ShopItemFullInfo data)
	{
		if (data == null)
		{
			return;
		}
		this.RootItem.SetAsLastHierarchy();
		this.ItemInfo = data;
		base.SetItemQualityIcon(base.GetSprite(0), this.ItemInfo.ItemId, null, CommonDefine.EQualityIconType.BackgroundSprite, null);
		base.SetItemIcon(base.GetTexture(1), this.ItemInfo.ItemId, null, null);
		ItemConfig itemInfo = this.ItemInfo.ItemInfo;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), itemInfo.Name, Array.Empty<object>());
		base.GetSprite(10).SetUIActive(this.ItemInfo.IsSoldOut());
		base.GetSprite(11).SetUIActive(this.ItemInfo.IsLocked);
	}

	// Token: 0x06015755 RID: 87893 RVA: 0x005F2DC0 File Offset: 0x005F0FC0
	private void ButtonClick(EToggleState toggleState)
	{
		ModelBase<ShopModel>.Instance.OpenItemInfo = this.ItemInfo;
		Singleton<EventSystem>.Instance.Emit(EEventName.OpenItemInfo);
	}

	// Token: 0x06015756 RID: 87894 RVA: 0x005F2DE2 File Offset: 0x005F0FE2
	public override void OnSelected(bool fireEvent)
	{
		if (fireEvent)
		{
			this.ButtonClick(EToggleState.ETT_Checked);
		}
	}

	// Token: 0x06015757 RID: 87895 RVA: 0x005F2DEE File Offset: 0x005F0FEE
	public override void Refresh(ShopItemFullInfo data, bool isSelected, int gridIndex)
	{
		this.UpdateItem(data);
	}

	// Token: 0x0400A527 RID: 42279
	[Nullable(2)]
	public ShopItemFullInfo ItemInfo;

	// Token: 0x02008D7E RID: 36222
	[NullableContext(0)]
	private enum EShopItemNewDefine
	{
		// Token: 0x0402F947 RID: 194887
		QualitySprite,
		// Token: 0x0402F948 RID: 194888
		TextureIcon,
		// Token: 0x0402F949 RID: 194889
		TxtName,
		// Token: 0x0402F94A RID: 194890
		PanelName,
		// Token: 0x0402F94B RID: 194891
		Toggle,
		// Token: 0x0402F94C RID: 194892
		SoldOutSprite = 10,
		// Token: 0x0402F94D RID: 194893
		LockSprite
	}
}
