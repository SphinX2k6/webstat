using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Menu;
using CSharpScript.Game.Module.Menu.KeySettingsView;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200208D RID: 8333
public class CommonKeySettingRowsPanel : UiPanelBase
{
	// Token: 0x0600FE46 RID: 65094 RVA: 0x0045BFBB File Offset: 0x0045A1BB
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIDynScrollViewComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
	}

	// Token: 0x0600FE47 RID: 65095 RVA: 0x0045BFF4 File Offset: 0x0045A1F4
	protected override UniTask OnBeforeStartAsync()
	{
		CommonKeySettingRowsPanel.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<CommonKeySettingRowsPanel.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600FE48 RID: 65096 RVA: 0x0045C038 File Offset: 0x0045A238
	[NullableContext(1)]
	public void Refresh(List<KeySettingRowData> dataList, CSharpScript.Game.Module.Menu.EInputControllerType inputControllerType)
	{
		for (int i = 0; i < dataList.Count; i++)
		{
			dataList[i].IsExpandDetail = false;
		}
		KeySettingRowData[] array = new KeySettingRowData[dataList.Count];
		dataList.CopyTo(array, 0);
		DynamicScrollView<CommonKeySettingRowContainerItem, KeySettingRowBaseItem, KeySettingRowData> dynamicScrollView = this.DynamicScrollView;
		if (dynamicScrollView == null)
		{
			return;
		}
		dynamicScrollView.RefreshByData(array, false, false);
	}

	// Token: 0x0600FE49 RID: 65097 RVA: 0x0045C08A File Offset: 0x0045A28A
	public void StopScroll()
	{
		base.GetUIDynScrollViewComponent(0).StopMovement();
	}

	// Token: 0x0600FE4A RID: 65098 RVA: 0x0045C098 File Offset: 0x0045A298
	[NullableContext(1)]
	private CommonKeySettingRowContainerItem OnItemCreate(KeySettingRowData data, UUIItem uiItem, int index)
	{
		return new CommonKeySettingRowContainerItem();
	}

	// Token: 0x040079DC RID: 31196
	[Nullable(2)]
	private KeySettingRowBaseItem KeySettingRowBaseItem;

	// Token: 0x040079DD RID: 31197
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	private DynamicScrollView<CommonKeySettingRowContainerItem, KeySettingRowBaseItem, KeySettingRowData> DynamicScrollView;

	// Token: 0x0200841C RID: 33820
	private static class EChildType
	{
		// Token: 0x0402CC62 RID: 183394
		public const int DynamicScrollView = 0;

		// Token: 0x0402CC63 RID: 183395
		public const int TemplateItem = 1;
	}
}
