using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002037 RID: 8247
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class SelectItem : GridProxyAbstract<InventoryDefine.ISelectItemData>
{
	// Token: 0x0600FB34 RID: 64308 RVA: 0x0044F6F4 File Offset: 0x0044D8F4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600FB35 RID: 64309 RVA: 0x0044F7C0 File Offset: 0x0044D9C0
	protected override void OnStart()
	{
		base.GetExtendToggle(0).OnStateChange.Add(new Action<EToggleState>(this.OnClickedItem));
	}

	// Token: 0x0600FB36 RID: 64310 RVA: 0x0044F7DF File Offset: 0x0044D9DF
	protected override void OnDestroy()
	{
		base.GetExtendToggle(0).OnStateChange.Clear();
	}

	// Token: 0x0600FB37 RID: 64311 RVA: 0x0044F7F2 File Offset: 0x0044D9F2
	[NullableContext(1)]
	public override void Refresh(InventoryDefine.ISelectItemData data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		this.RefreshName();
		this.RefreshIcon();
		this.RefreshToggleState();
	}

	// Token: 0x0600FB38 RID: 64312 RVA: 0x0044F810 File Offset: 0x0044DA10
	private void RefreshName()
	{
		string name = this.Data.Name;
		base.GetText(4).SetText(name, true);
	}

	// Token: 0x0600FB39 RID: 64313 RVA: 0x0044F838 File Offset: 0x0044DA38
	private void RefreshIcon()
	{
		string iconPath = this.Data.IconPath;
		UUIItem item = base.GetItem(1);
		if (StringUtils.IsBlank(iconPath))
		{
			item.SetUIActive(false);
			return;
		}
		item.SetUIActive(true);
		bool flag = iconPath.Contains("Atlas");
		UUITexture texture = base.GetTexture(2);
		texture.SetUIActive(!flag);
		UUISprite sprite = base.GetSprite(3);
		sprite.SetUIActive(flag);
		FColor? fcolor;
		if (flag)
		{
			this.SetSpriteByPath(iconPath, sprite, false, null, null);
			UUIItem uuiitem = sprite;
			bool needChangeColor = this.Data.NeedChangeColor;
			fcolor = new FColor?(sprite.changeColor);
			uuiitem.SetChangeColor(needChangeColor, fcolor);
			return;
		}
		base.SetTextureByPath(iconPath, texture, null, null);
		UUIItem uuiitem2 = texture;
		bool needChangeColor2 = this.Data.NeedChangeColor;
		fcolor = new FColor?(texture.changeColor);
		uuiitem2.SetChangeColor(needChangeColor2, fcolor);
	}

	// Token: 0x0600FB3A RID: 64314 RVA: 0x0044F910 File Offset: 0x0044DB10
	public void RefreshToggleState()
	{
		if (this.CallbackGetState == null)
		{
			return;
		}
		EToggleState state = this.CallbackGetState(this.Data.Value) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		base.GetExtendToggle(0).SetToggleState(state, false, false, false);
	}

	// Token: 0x0600FB3B RID: 64315 RVA: 0x0044F954 File Offset: 0x0044DB54
	[NullableContext(1)]
	public override object GetKey(InventoryDefine.ISelectItemData data, int displayIndex)
	{
		return this.Data.Value;
	}

	// Token: 0x0600FB3C RID: 64316 RVA: 0x0044F966 File Offset: 0x0044DB66
	private void OnClickedItem(EToggleState state)
	{
		Action<EToggleState, int> callbackClickItem = this.CallbackClickItem;
		if (callbackClickItem == null)
		{
			return;
		}
		callbackClickItem(state, this.Data.Value);
	}

	// Token: 0x040078A7 RID: 30887
	private InventoryDefine.ISelectItemData Data;

	// Token: 0x040078A8 RID: 30888
	public Action<EToggleState, int> CallbackClickItem;

	// Token: 0x040078A9 RID: 30889
	public Func<int, bool> CallbackGetState;

	// Token: 0x020083E2 RID: 33762
	[NullableContext(0)]
	private enum EItemComponent
	{
		// Token: 0x0402CB58 RID: 183128
		Toggle,
		// Token: 0x0402CB59 RID: 183129
		IconRoot,
		// Token: 0x0402CB5A RID: 183130
		Icon,
		// Token: 0x0402CB5B RID: 183131
		Sprite,
		// Token: 0x0402CB5C RID: 183132
		Content
	}
}
