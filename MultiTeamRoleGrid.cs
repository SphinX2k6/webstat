using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Extension;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x0200278F RID: 10127
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class MultiTeamRoleGrid : GridProxyAbstract<MultiTeamRoleGridContentData>
{
	// Token: 0x06013FD0 RID: 81872 RVA: 0x00591ECC File Offset: 0x005900CC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIGridLayout)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
	}

	// Token: 0x06013FD1 RID: 81873 RVA: 0x00591F26 File Offset: 0x00590126
	protected override void OnStart()
	{
		this.Layout = new GenericLayout<RoleGrid, RoleGridContentData>(base.GetGridLayout(1), new Func<RoleGrid>(this.CreateItem), null, false, true);
		this.Layout.GetUiAnimController().PlayFromIndex = 1;
	}

	// Token: 0x06013FD2 RID: 81874 RVA: 0x00591F5A File Offset: 0x0059015A
	private RoleGrid CreateItem()
	{
		return new RoleGrid();
	}

	// Token: 0x06013FD3 RID: 81875 RVA: 0x00591F64 File Offset: 0x00590164
	public override void Refresh(MultiTeamRoleGridContentData data, bool isSelected, int gridIndex)
	{
		if (data.Data == null)
		{
			return;
		}
		base.GetText(0).ShowTextNew(data.Data.GetTitle());
		List<MultiTeamRoleGridData> showMultiTeamRoleGridDataList = data.Data.GetShowMultiTeamRoleGridDataList();
		List<RoleGridContentData> list = new List<RoleGridContentData>();
		foreach (MultiTeamRoleGridData multiTeamRoleGridData in showMultiTeamRoleGridDataList)
		{
			list.Add(new RoleGridContentData
			{
				Data = multiTeamRoleGridData,
				CurrentSelectedRoleList = data.CurrentSelectedRoleList,
				CurrentTagBranchId = data.CurrentSelectTagMap.GetValueOrNull(multiTeamRoleGridData.GetRole().GetDataId()).GetValueOrDefault(-1),
				OnToggleCallBack = data.OnToggleCallBack,
				CanExecuteChangeCallBack = data.CanExecuteChangeCallBack
			});
		}
		this.Layout.RefreshByData(list, null, data.ShowGridAnimation);
	}

	// Token: 0x04009B9E RID: 39838
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<RoleGrid, RoleGridContentData> Layout;

	// Token: 0x02008B47 RID: 35655
	[NullableContext(0)]
	private enum EComponents
	{
		// Token: 0x0402EF1F RID: 192287
		TitleText,
		// Token: 0x0402EF20 RID: 192288
		Layout,
		// Token: 0x0402EF21 RID: 192289
		GridItem
	}
}
