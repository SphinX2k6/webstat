using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001FE4 RID: 8164
[NullableContext(1)]
[Nullable(0)]
internal class AreaButtonItem : UiPanelBase
{
	// Token: 0x0600F65E RID: 63070 RVA: 0x004372E6 File Offset: 0x004354E6
	public AreaButtonItem(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x0600F65F RID: 63071 RVA: 0x004372FC File Offset: 0x004354FC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.ToggleClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600F660 RID: 63072 RVA: 0x004373E4 File Offset: 0x004355E4
	private void ToggleClick(EToggleState state)
	{
		if (state == EToggleState.ETT_Checked)
		{
			this.ToggleFunction(this.CountryId);
		}
	}

	// Token: 0x0600F661 RID: 63073 RVA: 0x004373FD File Offset: 0x004355FD
	protected override void OnStart()
	{
		base.GetExtendToggle(1).CanExecuteChange.Bind(new Func<bool>(this.CanExecuteChange));
	}

	// Token: 0x0600F662 RID: 63074 RVA: 0x0043741C File Offset: 0x0043561C
	protected override void OnBeforeDestroy()
	{
		base.GetExtendToggle(1).CanExecuteChange.Unbind();
	}

	// Token: 0x0600F663 RID: 63075 RVA: 0x0043742F File Offset: 0x0043562F
	private bool CanExecuteChange()
	{
		return this.CanExecuteChangeFunction == null || this.CanExecuteChangeFunction(this.CountryId);
	}

	// Token: 0x0600F664 RID: 63076 RVA: 0x0043744C File Offset: 0x0043564C
	private void SetRedDot(bool isUnlock)
	{
		bool flag = ModelBase<InfluenceReputationModel>.Instance.HasRedDotInCurrentCountry(this.CountryId);
		base.GetItem(3).SetUIActive(flag && isUnlock);
	}

	// Token: 0x0600F665 RID: 63077 RVA: 0x0043747C File Offset: 0x0043567C
	public void UpdateItem(int countryId)
	{
		this.CountryId = countryId;
		Country? countryConfig = ConfigBase<InfluenceConfig>.Instance.GetCountryConfig(countryId);
		bool flag = ModelBase<InfluenceReputationModel>.Instance.IsCountryUnLock(countryId);
		UUITexture texture = base.GetTexture(0);
		UUIItem item = base.GetItem(2);
		texture.SetUIActive(flag);
		item.SetUIActive(!flag);
		if (flag && countryConfig != null)
		{
			base.SetTextureByPath(countryConfig.Value.Logo, texture, null, null);
		}
		this.SetRedDot(flag);
	}

	// Token: 0x0600F666 RID: 63078 RVA: 0x004374FB File Offset: 0x004356FB
	public void SetToggleFunction(TAreaToggleFunction callback)
	{
		this.ToggleFunction = callback;
	}

	// Token: 0x0600F667 RID: 63079 RVA: 0x00437504 File Offset: 0x00435704
	public void SetCanExecuteChange(TAreaCanExecuteChange callback)
	{
		this.CanExecuteChangeFunction = callback;
	}

	// Token: 0x0600F668 RID: 63080 RVA: 0x0043750D File Offset: 0x0043570D
	public void SetToggleState(EToggleState state, bool bFire)
	{
		base.GetExtendToggle(1).SetToggleStateForce(state, bFire, false, false);
	}

	// Token: 0x04007714 RID: 30484
	[Nullable(2)]
	private TAreaToggleFunction ToggleFunction;

	// Token: 0x04007715 RID: 30485
	[Nullable(2)]
	private TAreaCanExecuteChange CanExecuteChangeFunction;

	// Token: 0x04007716 RID: 30486
	private int CountryId;

	// Token: 0x02008364 RID: 33636
	[NullableContext(0)]
	private enum EAreaButtonItem
	{
		// Token: 0x0402C904 RID: 182532
		Texture,
		// Token: 0x0402C905 RID: 182533
		Toggle,
		// Token: 0x0402C906 RID: 182534
		Lock,
		// Token: 0x0402C907 RID: 182535
		RedDot
	}
}
