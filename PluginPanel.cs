using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Dango;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001AF1 RID: 6897
[NullableContext(1)]
[Nullable(0)]
internal class PluginPanel : UiPanelBase
{
	// Token: 0x0600C6A0 RID: 50848 RVA: 0x00347EE8 File Offset: 0x003460E8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem))
		};
	}

	// Token: 0x0600C6A1 RID: 50849 RVA: 0x00347FC8 File Offset: 0x003461C8
	protected override UniTask OnBeforeStartAsync()
	{
		PluginPanel.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<PluginPanel.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600C6A2 RID: 50850 RVA: 0x0034800C File Offset: 0x0034620C
	public void Refresh()
	{
		int dangoId = this.ViewModel.GetDangoId();
		AbyssDangoRoleData dangoAbyssRoleData = ModelBase<DangoAbyssModel>.Instance.GetDangoAbyssRoleData(dangoId);
		if (dangoAbyssRoleData == null)
		{
			return;
		}
		this.RefreshPlugin(dangoAbyssRoleData);
	}

	// Token: 0x0600C6A3 RID: 50851 RVA: 0x0034803C File Offset: 0x0034623C
	private void RefreshPlugin(AbyssDangoRoleData data)
	{
		foreach (KeyValuePair<int, DangoAbyssPluginItem> keyValuePair in this.PluginMap)
		{
			int key = keyValuePair.Key;
			DangoAbyssPluginItem value = keyValuePair.Value;
			AbyssDangoRoleSlotData pluginSlotData = data.GetPluginSlotData(key);
			value.Refresh(pluginSlotData);
		}
	}

	// Token: 0x04005F2A RID: 24362
	private readonly Dictionary<int, DangoAbyssPluginItem> PluginMap = new Dictionary<int, DangoAbyssPluginItem>();

	// Token: 0x04005F2B RID: 24363
	[Nullable(2)]
	public PluginEquipViewModel ViewModel;
}
