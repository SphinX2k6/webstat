using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002A66 RID: 10854
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class RoleSkinOrnamentItem : GridProxyAbstract<RoleSkinData>
{
	// Token: 0x06015C08 RID: 89096 RVA: 0x00609504 File Offset: 0x00607704
	protected unsafe override void OnRegisterComponent()
	{
		int num = 9;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIMultiTemplateLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06015C09 RID: 89097 RVA: 0x00609658 File Offset: 0x00607858
	protected override void OnStart()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OrnamentRedDotRefresh, new Action<int>(this.OnOrnamentRedDotRefresh));
		this.OrnamentLayout = new GenericLayout<RoleOrnamentGridItem, IRoleOrnamentGridData>(base.GetMultiTemplateLayout(6), new Func<RoleOrnamentGridItem>(this.CreateOrnamentItem), base.GetItem(7).GetOwner() as AUIBaseActor, false, true);
	}

	// Token: 0x06015C0A RID: 89098 RVA: 0x006096B2 File Offset: 0x006078B2
	protected override void OnBeforeDestroy()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OrnamentRedDotRefresh, new Action<int>(this.OnOrnamentRedDotRefresh));
	}

	// Token: 0x06015C0B RID: 89099 RVA: 0x006096D0 File Offset: 0x006078D0
	public override void Refresh(RoleSkinData data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		this.UpdateItemDataList();
		this.RefreshView();
		this.RefreshLayout();
	}

	// Token: 0x06015C0C RID: 89100 RVA: 0x006096EC File Offset: 0x006078EC
	private void UpdateItemDataList()
	{
		int itemId = this.Data.GetItemId();
		List<int> skinAllOrnaments = ModelBase<RoleOrnamentModel>.Instance.GetSkinAllOrnaments(itemId, new bool?(true));
		List<IRoleOrnamentGridData> list = new List<IRoleOrnamentGridData>();
		for (int i = 0; i < skinAllOrnaments.Count; i++)
		{
			int ornamentId = skinAllOrnaments[i];
			list.Add(new RoleOrnamentGridData
			{
				SkinId = itemId,
				OrnamentId = ornamentId
			});
		}
		this.ItemDataList = list;
	}

	// Token: 0x06015C0D RID: 89101 RVA: 0x00609758 File Offset: 0x00607958
	public void RefreshView()
	{
		RoleSkinData data = this.Data;
		bool flag = !data.IsLocked();
		bool flag2 = data.IsWear();
		base.GetItem(0).SetUIActive(flag);
		base.GetSprite(1).SetUIActive(flag2);
		base.GetItem(2).SetUIActive(!flag);
		base.SetRoleIcon(data.GetRoleSkinConfig().RoleHeadIconCircle, base.GetTexture(3), data.GetRoleId(), null, null);
		base.GetTexture(4).SetUIActive(!flag2);
		UUIText text = base.GetText(5);
		text.ShowTextNew(data.GetTitleName());
		UUIItem uuiitem = text;
		bool bUseChangeColor = flag2;
		FColor? fcolor = new FColor?(text.changeColor);
		uuiitem.SetChangeColor(bUseChangeColor, fcolor);
		float alpha = flag ? 1f : 0.4f;
		text.SetAlpha(alpha);
		string resourceId = flag2 ? "SP_IconAccessoriesSkinTitleBgHightLight" : "SP_IconAccessoriesSkinTitleBgNor";
		this.SetSpriteByPath(ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId), base.GetSprite(8), false, null, null);
	}

	// Token: 0x06015C0E RID: 89102 RVA: 0x0060985D File Offset: 0x00607A5D
	public void RefreshLayout()
	{
		this.OrnamentLayout.RefreshByData(this.ItemDataList, new Action(this.RefreshGridSelected), false);
	}

	// Token: 0x06015C0F RID: 89103 RVA: 0x00609880 File Offset: 0x00607A80
	public void RefreshGridSelected()
	{
		Func<int> getPreviewSkinIdFunc = this.GetPreviewSkinIdFunc;
		int? num = (getPreviewSkinIdFunc != null) ? new int?(getPreviewSkinIdFunc()) : null;
		int itemId = this.Data.GetItemId();
		if (!(num.GetValueOrDefault() == itemId & num != null))
		{
			this.OrnamentLayout.DeselectCurrentGridProxy();
			return;
		}
		Func<int> getPreviewOrnamentIdFunc = this.GetPreviewOrnamentIdFunc;
		int? num2 = (getPreviewOrnamentIdFunc != null) ? new int?(getPreviewOrnamentIdFunc()) : null;
		int gridIndex = -1;
		if (num2 != null)
		{
			for (int i = 0; i < this.ItemDataList.Count; i++)
			{
				if (this.ItemDataList[i].OrnamentId == num2.Value)
				{
					gridIndex = i;
					break;
				}
			}
		}
		this.OrnamentLayout.SelectGridProxy(gridIndex, true);
	}

	// Token: 0x06015C10 RID: 89104 RVA: 0x0060994B File Offset: 0x00607B4B
	public void RefreshOrnamentItems()
	{
		this.OrnamentLayout.RefreshWithoutDataSync();
	}

	// Token: 0x06015C11 RID: 89105 RVA: 0x00609958 File Offset: 0x00607B58
	public void SetClickOrnamentCallback(Action<int, int> callback)
	{
		this.ClickOrnamentCallback = callback;
	}

	// Token: 0x06015C12 RID: 89106 RVA: 0x00609961 File Offset: 0x00607B61
	public void SetGetPreviewSkinIdFunc(Func<int> func)
	{
		this.GetPreviewSkinIdFunc = func;
	}

	// Token: 0x06015C13 RID: 89107 RVA: 0x0060996A File Offset: 0x00607B6A
	public void SetGetPreviewOrnamentIdFunc(Func<int> func)
	{
		this.GetPreviewOrnamentIdFunc = func;
	}

	// Token: 0x06015C14 RID: 89108 RVA: 0x00609973 File Offset: 0x00607B73
	private RoleOrnamentGridItem CreateOrnamentItem()
	{
		RoleOrnamentGridItem roleOrnamentGridItem = new RoleOrnamentGridItem();
		roleOrnamentGridItem.BindOnExtendToggleStateChanged(new Action<MediumItemGridExtendCallback>(this.OnOrnamentItemClick));
		roleOrnamentGridItem.BindOnCanExecuteChange(new Func<object, bool, EToggleState, bool>(this.OrnamentItemCanExecuteChange));
		return roleOrnamentGridItem;
	}

	// Token: 0x06015C15 RID: 89109 RVA: 0x006099A0 File Offset: 0x00607BA0
	private void OnOrnamentItemClick(MediumItemGridExtendCallback parameters)
	{
		IRoleOrnamentGridData roleOrnamentGridData = parameters.Data as IRoleOrnamentGridData;
		if (roleOrnamentGridData == null)
		{
			return;
		}
		Action<int, int> clickOrnamentCallback = this.ClickOrnamentCallback;
		if (clickOrnamentCallback == null)
		{
			return;
		}
		clickOrnamentCallback(this.Data.GetItemId(), roleOrnamentGridData.OrnamentId);
	}

	// Token: 0x06015C16 RID: 89110 RVA: 0x006099E0 File Offset: 0x00607BE0
	[NullableContext(2)]
	private bool OrnamentItemCanExecuteChange(object parameters, bool _, EToggleState __)
	{
		IRoleOrnamentGridData roleOrnamentGridData = parameters as IRoleOrnamentGridData;
		if (roleOrnamentGridData == null)
		{
			return true;
		}
		Func<int> getPreviewSkinIdFunc = this.GetPreviewSkinIdFunc;
		int? num = (getPreviewSkinIdFunc != null) ? new int?(getPreviewSkinIdFunc()) : null;
		int num2 = roleOrnamentGridData.SkinId;
		if (num.GetValueOrDefault() == num2 & num != null)
		{
			Func<int> getPreviewOrnamentIdFunc = this.GetPreviewOrnamentIdFunc;
			num = ((getPreviewOrnamentIdFunc != null) ? new int?(getPreviewOrnamentIdFunc()) : null);
			num2 = roleOrnamentGridData.OrnamentId;
			return !(num.GetValueOrDefault() == num2 & num != null);
		}
		return true;
	}

	// Token: 0x06015C17 RID: 89111 RVA: 0x00609A74 File Offset: 0x00607C74
	private void OnOrnamentRedDotRefresh(int ornamentId)
	{
		RoleOrnamentGridItem layoutItemByKey = this.OrnamentLayout.GetLayoutItemByKey(ornamentId);
		if (layoutItemByKey == null)
		{
			return;
		}
		layoutItemByKey.RefreshRedDotVisible();
	}

	// Token: 0x0400A6D8 RID: 42712
	private RoleSkinData Data;

	// Token: 0x0400A6D9 RID: 42713
	private List<IRoleOrnamentGridData> ItemDataList;

	// Token: 0x0400A6DA RID: 42714
	private GenericLayout<RoleOrnamentGridItem, IRoleOrnamentGridData> OrnamentLayout;

	// Token: 0x0400A6DB RID: 42715
	[Nullable(2)]
	private Action<int, int> ClickOrnamentCallback;

	// Token: 0x0400A6DC RID: 42716
	[Nullable(2)]
	private Func<int> GetPreviewSkinIdFunc;

	// Token: 0x0400A6DD RID: 42717
	[Nullable(2)]
	private Func<int> GetPreviewOrnamentIdFunc;

	// Token: 0x02008DEC RID: 36332
	[NullableContext(0)]
	private enum EComponentType
	{
		// Token: 0x0402FC0D RID: 195597
		UnlockItem,
		// Token: 0x0402FC0E RID: 195598
		EquipSprite,
		// Token: 0x0402FC0F RID: 195599
		LockItem,
		// Token: 0x0402FC10 RID: 195600
		RoleTexture,
		// Token: 0x0402FC11 RID: 195601
		RoleLockTexture,
		// Token: 0x0402FC12 RID: 195602
		NameText,
		// Token: 0x0402FC13 RID: 195603
		OrnamentLayout,
		// Token: 0x0402FC14 RID: 195604
		OrnamentItem,
		// Token: 0x0402FC15 RID: 195605
		BgSprite
	}
}
