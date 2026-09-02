using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020028F8 RID: 10488
public class CommonAttributeItem : UiPanelBase
{
	// Token: 0x06014D56 RID: 85334 RVA: 0x005C50C7 File Offset: 0x005C32C7
	[NullableContext(1)]
	public CommonAttributeItem(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x06014D57 RID: 85335 RVA: 0x005C50DC File Offset: 0x005C32DC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(4, new Action<EToggleState>(this.ToggleEvent))
		};
	}

	// Token: 0x06014D58 RID: 85336 RVA: 0x005C51C8 File Offset: 0x005C33C8
	protected override void OnStart()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(4);
		extendToggle.RootUIComp.Get().SetUIActive(true);
		base.GetItem(7).SetUIActive(false);
		extendToggle.CanExecuteChange.Unbind();
		extendToggle.CanExecuteChange.Bind(new Func<bool>(this.CanClickLikeToggle));
	}

	// Token: 0x06014D59 RID: 85337 RVA: 0x005C521E File Offset: 0x005C341E
	private bool CanClickLikeToggle()
	{
		return !string.IsNullOrEmpty(this.Data.DetailText);
	}

	// Token: 0x06014D5A RID: 85338 RVA: 0x005C5238 File Offset: 0x005C3438
	[NullableContext(1)]
	public void ShowTemp(ScrollViewDataBase data)
	{
		CommonAttributeData commonAttributeData = (CommonAttributeData)data;
		this.Data = commonAttributeData;
		if (!string.IsNullOrEmpty(commonAttributeData.AttrNameText))
		{
			base.GetText(1).SetText(commonAttributeData.AttrNameText, true);
		}
		if (!string.IsNullOrEmpty(commonAttributeData.AttrIconTexture))
		{
			base.GetTexture(0).SetUIActive(true);
			base.SetTextureByPath(commonAttributeData.AttrIconTexture, base.GetTexture(0), null, null);
		}
		else
		{
			base.GetTexture(0).SetUIActive(false);
		}
		if (!string.IsNullOrEmpty(commonAttributeData.DetailText))
		{
			base.GetItem(6).SetUIActive(true);
			base.GetText(5).SetText(commonAttributeData.DetailText, true);
		}
		else
		{
			base.GetItem(6).SetUIActive(false);
		}
		if (!string.IsNullOrEmpty(commonAttributeData.AttrBaseValue))
		{
			base.GetText(2).SetText(commonAttributeData.AttrBaseValue, true);
		}
		if (!string.IsNullOrEmpty(commonAttributeData.AttrAddValue))
		{
			base.GetText(3).SetText(commonAttributeData.AttrAddValue, true);
			return;
		}
		base.GetText(3).SetText("", true);
	}

	// Token: 0x06014D5B RID: 85339 RVA: 0x005C5348 File Offset: 0x005C3548
	protected void ToggleEvent(EToggleState bState)
	{
		bool uiactive = bState == EToggleState.ETT_Checked;
		base.GetText(5).SetUIActive(uiactive);
		base.GetItem(7).SetUIActive(uiactive);
	}

	// Token: 0x0400A047 RID: 41031
	[Nullable(2)]
	private CommonAttributeData Data;

	// Token: 0x02008C49 RID: 35913
	private enum EAttrListDefine
	{
		// Token: 0x0402F3FB RID: 193531
		AttrIconTexture,
		// Token: 0x0402F3FC RID: 193532
		AttrNameText,
		// Token: 0x0402F3FD RID: 193533
		AttrBaseValue,
		// Token: 0x0402F3FE RID: 193534
		AttrAddValue,
		// Token: 0x0402F3FF RID: 193535
		Toggle,
		// Token: 0x0402F400 RID: 193536
		DetailText,
		// Token: 0x0402F401 RID: 193537
		Arrow,
		// Token: 0x0402F402 RID: 193538
		ExplainContent
	}
}
