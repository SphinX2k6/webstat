using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001FE3 RID: 8163
public class InfluenceAreaSelectView : UiViewBase
{
	// Token: 0x0600F653 RID: 63059 RVA: 0x00436ED8 File Offset: 0x004350D8
	[NullableContext(1)]
	public InfluenceAreaSelectView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600F654 RID: 63060 RVA: 0x00436EE4 File Offset: 0x004350E4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIGridLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIInteractionGroup));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.CloseClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.ConfirmClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600F655 RID: 63061 RVA: 0x00437052 File Offset: 0x00435252
	private void CloseClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600F656 RID: 63062 RVA: 0x0043705B File Offset: 0x0043525B
	private void ConfirmClick()
	{
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshInfluencePanel, this.CurrentSelectedAreaId);
		base.CloseMe(null);
	}

	// Token: 0x0600F657 RID: 63063 RVA: 0x0043707C File Offset: 0x0043527C
	protected override void OnStart()
	{
		this.CountryLayout = new GenericLayoutNew<AreaButtonItem>(base.GetGridLayout(1), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<AreaButtonItem>(this.InitItem), null);
		List<Country> countryList = ConfigBase<InfluenceConfig>.Instance.GetCountryList();
		this.CountryLayout.RebuildLayoutByDataNew<Country>(countryList, null);
		this.SpecialItem = new AreaButtonItem(base.GetItem(2));
		this.SpecialItem.UpdateItem(9999);
		this.SpecialItem.SetToggleFunction(new TAreaToggleFunction(this.ToggleFunction));
		this.SpecialItem.SetCanExecuteChange(new TAreaCanExecuteChange(this.CanExecuteChange));
	}

	// Token: 0x0600F658 RID: 63064 RVA: 0x00437118 File Offset: 0x00435318
	[NullableContext(1)]
	private ILayoutItem<AreaButtonItem> InitItem(object country, UUIItem uiItem, int _)
	{
		AreaButtonItem areaButtonItem = new AreaButtonItem(uiItem);
		areaButtonItem.UpdateItem(((Country)country).Id);
		areaButtonItem.SetToggleFunction(new TAreaToggleFunction(this.ToggleFunction));
		areaButtonItem.SetCanExecuteChange(new TAreaCanExecuteChange(this.CanExecuteChange));
		return new LayoutItem<AreaButtonItem>
		{
			Key = ((Country)country).Id,
			Value = areaButtonItem
		};
	}

	// Token: 0x0600F659 RID: 63065 RVA: 0x0043718C File Offset: 0x0043538C
	private void ToggleFunction(int areaId)
	{
		if (this.CurrentSelectedAreaId != 0)
		{
			this.GetAreaButtonItem(this.CurrentSelectedAreaId).SetToggleState(EToggleState.ETT_UnChecked, false);
		}
		this.CurrentSelectedAreaId = areaId;
		UUIText text = base.GetText(3);
		UUIText text2 = base.GetText(4);
		bool flag = ModelBase<InfluenceReputationModel>.Instance.IsCountryUnLock(areaId);
		UUIInteractionGroup interactionGroup = base.GetInteractionGroup(6);
		if (flag)
		{
			Country value = ConfigBase<InfluenceConfig>.Instance.GetCountryConfig(areaId).Value;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, value.Title, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, value.Desc, Array.Empty<object>());
			interactionGroup.SetInteractable(true);
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalText(text, "AreaLockTitle", Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalText(text2, "AreaLockContent", Array.Empty<object>());
		interactionGroup.SetInteractable(false);
	}

	// Token: 0x0600F65A RID: 63066 RVA: 0x0043725C File Offset: 0x0043545C
	private bool CanExecuteChange(int areaId)
	{
		return this.CurrentSelectedAreaId != areaId;
	}

	// Token: 0x0600F65B RID: 63067 RVA: 0x0043726C File Offset: 0x0043546C
	[NullableContext(2)]
	private AreaButtonItem GetAreaButtonItem(int areaId)
	{
		AreaButtonItem layoutItemByKey = this.CountryLayout.GetLayoutItemByKey(areaId);
		if (layoutItemByKey != null)
		{
			return layoutItemByKey;
		}
		return this.SpecialItem;
	}

	// Token: 0x0600F65C RID: 63068 RVA: 0x00437298 File Offset: 0x00435498
	protected override void OnAfterShow()
	{
		int areaId = (int)this.OpenParam;
		this.GetAreaButtonItem(areaId).SetToggleState(EToggleState.ETT_Checked, true);
	}

	// Token: 0x0600F65D RID: 63069 RVA: 0x004372BF File Offset: 0x004354BF
	protected override void OnBeforeDestroy()
	{
		this.CountryLayout.ClearChildren();
		this.CountryLayout = null;
		this.SpecialItem.Destroy(null);
		this.SpecialItem = null;
	}

	// Token: 0x04007711 RID: 30481
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayoutNew<AreaButtonItem> CountryLayout;

	// Token: 0x04007712 RID: 30482
	[Nullable(2)]
	private AreaButtonItem SpecialItem;

	// Token: 0x04007713 RID: 30483
	private int CurrentSelectedAreaId;

	// Token: 0x02008363 RID: 33635
	private enum EInfluenceAreaSelectView
	{
		// Token: 0x0402C8FC RID: 182524
		CloseButton,
		// Token: 0x0402C8FD RID: 182525
		CountryArea,
		// Token: 0x0402C8FE RID: 182526
		SpecialArea,
		// Token: 0x0402C8FF RID: 182527
		Title,
		// Token: 0x0402C900 RID: 182528
		Content,
		// Token: 0x0402C901 RID: 182529
		ConfirmButton,
		// Token: 0x0402C902 RID: 182530
		InteractionGroup
	}
}
