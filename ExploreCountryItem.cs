using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Area;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001B85 RID: 7045
[NullableContext(1)]
[Nullable(0)]
public class ExploreCountryItem : UiPanelBase
{
	// Token: 0x0600CCB5 RID: 52405 RVA: 0x00367895 File Offset: 0x00365A95
	public void Initialize(UUIItem uiItem)
	{
		base.CreateByActorAsync(uiItem.GetOwner(), null, false);
	}

	// Token: 0x0600CCB6 RID: 52406 RVA: 0x003678A8 File Offset: 0x00365AA8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action<EToggleState>(this.OnExtendToggleStateChanged));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600CCB7 RID: 52407 RVA: 0x003679B1 File Offset: 0x00365BB1
	protected override void OnStart()
	{
		base.GetExtendToggle(3).CanExecuteChange.Bind(new Func<bool>(this.OnCanExecuteChange));
	}

	// Token: 0x0600CCB8 RID: 52408 RVA: 0x003679D0 File Offset: 0x00365BD0
	protected override void OnBeforeDestroy()
	{
		this.OnSelectedCallback = null;
		this.OnCanExecuteChangeCallback = null;
		base.GetExtendToggle(3).CanExecuteChange.Unbind();
	}

	// Token: 0x0600CCB9 RID: 52409 RVA: 0x003679F1 File Offset: 0x00365BF1
	private void OnExtendToggleStateChanged(EToggleState state)
	{
		Action<ExploreCountryItem, ExploreAreaViewData, EToggleState> onSelectedCallback = this.OnSelectedCallback;
		if (onSelectedCallback == null)
		{
			return;
		}
		onSelectedCallback(this, this.Data, state);
	}

	// Token: 0x0600CCBA RID: 52410 RVA: 0x00367A0C File Offset: 0x00365C0C
	public void Refresh(ExploreAreaViewData data)
	{
		this.Data = data;
		int? areaCountryId = ModelBase<AreaModel>.Instance.GetAreaCountryId();
		int countryId = data.CountryId;
		bool uiactive = areaCountryId.GetValueOrDefault() == countryId & areaCountryId != null;
		int selectedCountryId = ModelBase<ExploreProgressModel>.Instance.SelectedCountryId;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), data.NameId, Array.Empty<object>());
		base.GetSprite(1).SetUIActive(data.IsLock);
		base.GetItem(2).SetUIActive(false);
		base.GetSprite(4).SetUIActive(uiactive);
		this.SetSelected(selectedCountryId == data.CountryId);
	}

	// Token: 0x0600CCBB RID: 52411 RVA: 0x00367AA8 File Offset: 0x00365CA8
	public void SetSelected(bool bSelected)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(3);
		if (bSelected)
		{
			extendToggle.SetToggleState(EToggleState.ETT_Checked, false, false, false);
			return;
		}
		extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x0600CCBC RID: 52412 RVA: 0x00367AD7 File Offset: 0x00365CD7
	private bool OnCanExecuteChange()
	{
		Func<bool> onCanExecuteChangeCallback = this.OnCanExecuteChangeCallback;
		return onCanExecuteChangeCallback == null || onCanExecuteChangeCallback();
	}

	// Token: 0x0600CCBD RID: 52413 RVA: 0x00367AEA File Offset: 0x00365CEA
	public void BindCanExecuteChange(Func<bool> onCanExecuteChange)
	{
		base.GetExtendToggle(3).CanExecuteChange.Bind(onCanExecuteChange);
	}

	// Token: 0x0600CCBE RID: 52414 RVA: 0x00367AFE File Offset: 0x00365CFE
	public void BindOnSelected(Action<ExploreCountryItem, ExploreAreaViewData, EToggleState> onSelectedCallback)
	{
		this.OnSelectedCallback = onSelectedCallback;
	}

	// Token: 0x040061DD RID: 25053
	private ExploreAreaViewData Data;

	// Token: 0x040061DE RID: 25054
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private Action<ExploreCountryItem, ExploreAreaViewData, EToggleState> OnSelectedCallback;

	// Token: 0x040061DF RID: 25055
	[Nullable(2)]
	private Func<bool> OnCanExecuteChangeCallback;

	// Token: 0x02007E65 RID: 32357
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402B0E0 RID: 176352
		TitleText,
		// Token: 0x0402B0E1 RID: 176353
		LockSprite,
		// Token: 0x0402B0E2 RID: 176354
		RedDotItem,
		// Token: 0x0402B0E3 RID: 176355
		ExtendToggle,
		// Token: 0x0402B0E4 RID: 176356
		LocationSprite
	}
}
