using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200201E RID: 8222
public class SettingGridLayout : UiPanelBase
{
	// Token: 0x0600F9E0 RID: 63968 RVA: 0x004468D9 File Offset: 0x00444AD9
	public SettingGridLayout(int ruleId, InventoryDefine.ESettingGridType gridType)
	{
		this.RuleId = ruleId;
		this.GridType = new InventoryDefine.ESettingGridType?(gridType);
	}

	// Token: 0x0600F9E1 RID: 63969 RVA: 0x004468F4 File Offset: 0x00444AF4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIGridLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600F9E2 RID: 63970 RVA: 0x00446960 File Offset: 0x00444B60
	protected override UniTask OnBeforeStartAsync()
	{
		SettingGridLayout.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<SettingGridLayout.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600F9E3 RID: 63971 RVA: 0x004469A4 File Offset: 0x00444BA4
	[NullableContext(1)]
	public UniTask RefreshAsync(InventoryDefine.IManageConfigSettingGridData[] data)
	{
		SettingGridLayout.<RefreshAsync>d__8 <RefreshAsync>d__;
		<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshAsync>d__.<>4__this = this;
		<RefreshAsync>d__.data = data;
		<RefreshAsync>d__.<>1__state = -1;
		<RefreshAsync>d__.<>t__builder.Start<SettingGridLayout.<RefreshAsync>d__8>(ref <RefreshAsync>d__);
		return <RefreshAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600F9E4 RID: 63972 RVA: 0x004469F0 File Offset: 0x00444BF0
	[NullableContext(1)]
	private SettingGridBase OnCreateGrid()
	{
		SettingGridBase settingGridBase = new SettingGridSmall();
		if (this.GridType.GetValueOrDefault() != InventoryDefine.ESettingGridType.Small)
		{
			settingGridBase = new SettingGridBig();
		}
		settingGridBase.CallbackOnClicked = this.CallbackOnClicked;
		return settingGridBase;
	}

	// Token: 0x04007815 RID: 30741
	private readonly int RuleId;

	// Token: 0x04007816 RID: 30742
	private readonly InventoryDefine.ESettingGridType? GridType;

	// Token: 0x04007817 RID: 30743
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<SettingGridBase, InventoryDefine.IManageConfigSettingGridData> GridLayout;

	// Token: 0x04007818 RID: 30744
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<InventoryDefine.IManageConfigSettingGridData, bool> CallbackOnClicked;

	// Token: 0x020083B9 RID: 33721
	private enum EComponentLayout
	{
		// Token: 0x0402CAA2 RID: 182946
		LayoutRoot,
		// Token: 0x0402CAA3 RID: 182947
		PanelItem
	}
}
