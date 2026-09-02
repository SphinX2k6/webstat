using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x0200180F RID: 6159
[Nullable(new byte[]
{
	0,
	1
})]
public class AttributeSelectGrid : GridProxyAbstract<IRefineAttrItemData>
{
	// Token: 0x0600AF4D RID: 44877 RVA: 0x002EB8B8 File Offset: 0x002E9AB8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.OnClickToggle))
		};
	}

	// Token: 0x0600AF4E RID: 44878 RVA: 0x002EB94C File Offset: 0x002E9B4C
	protected override void OnStart()
	{
		base.GetItem(3).SetUIActive(false);
		base.GetExtendToggle(1).CanExecuteChange.Unbind();
		base.GetExtendToggle(1).SetToggleState(EToggleState.ETT_UnDetermined, false, false, false);
		base.GetExtendToggle(1).CanExecuteChange.Bind(new Func<bool>(this.CanExecuteChange));
	}

	// Token: 0x0600AF4F RID: 44879 RVA: 0x002EB9A8 File Offset: 0x002E9BA8
	[NullableContext(1)]
	public override void Refresh(IRefineAttrItemData data, bool bSelected, int gridIndex)
	{
		this.AttrData = data;
		PropertyIndex? propertyIndexInfo = ConfigBase<PropertyIndexConfig>.Instance.GetPropertyIndexInfo(data.PropIndexId);
		base.GetText(0).ShowTextNew(propertyIndexInfo.Value.Name);
		UUITexture texture = base.GetTexture(2);
		base.SetTextureShowUntilLoaded(propertyIndexInfo.Value.Icon, texture, null);
		UUIItem uuiitem = texture;
		bool bUseChangeColor = true;
		FColor? fcolor = new FColor?(texture.changeColor);
		uuiitem.SetChangeColor(bUseChangeColor, fcolor);
		base.GetItem(3).SetUIActive(data.IsRecommend);
		EToggleState state = bSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		base.GetExtendToggle(1).SetToggleState(state, false, false, false);
	}

	// Token: 0x0600AF50 RID: 44880 RVA: 0x002EBA48 File Offset: 0x002E9C48
	private void OnClickToggle(EToggleState toggleState)
	{
		Action<IRefineAttrItemData, int> onClickToggleCallBack = this.OnClickToggleCallBack;
		if (onClickToggleCallBack == null)
		{
			return;
		}
		onClickToggleCallBack(this.AttrData, base.GridIndex);
	}

	// Token: 0x0600AF51 RID: 44881 RVA: 0x002EBA66 File Offset: 0x002E9C66
	private bool CanExecuteChange()
	{
		return this.AttrData != null && !this.AttrData.IsDisable;
	}

	// Token: 0x0600AF52 RID: 44882 RVA: 0x002EBA80 File Offset: 0x002E9C80
	public override void OnSelected(bool fireEvent)
	{
		base.GetExtendToggle(1).SetToggleState(EToggleState.ETT_Checked, false, false, false);
	}

	// Token: 0x0600AF53 RID: 44883 RVA: 0x002EBA93 File Offset: 0x002E9C93
	public override void OnDeselected(bool fireEvent)
	{
		base.GetExtendToggle(1).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x0600AF54 RID: 44884 RVA: 0x002EBAA6 File Offset: 0x002E9CA6
	protected override void OnBeforeDestroy()
	{
		base.GetExtendToggle(1).CanExecuteChange.Unbind();
	}

	// Token: 0x0400531E RID: 21278
	[Nullable(2)]
	private IRefineAttrItemData AttrData;

	// Token: 0x0400531F RID: 21279
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<IRefineAttrItemData, int> OnClickToggleCallBack;

	// Token: 0x02007B8F RID: 31631
	private enum EItemComponent
	{
		// Token: 0x0402A3B8 RID: 172984
		Name,
		// Token: 0x0402A3B9 RID: 172985
		Toggle,
		// Token: 0x0402A3BA RID: 172986
		Icon,
		// Token: 0x0402A3BB RID: 172987
		Suggest
	}
}
