using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002770 RID: 10096
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class RogueBattleBuyRoleGroupItem : GridProxyAbstract<RoleBuyInfoGroupData>
{
	// Token: 0x06013EBC RID: 81596 RVA: 0x0058D410 File Offset: 0x0058B610
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
	}

	// Token: 0x06013EBD RID: 81597 RVA: 0x0058D44C File Offset: 0x0058B64C
	protected override UniTask OnBeforeStartAsync()
	{
		RogueBattleBuyRoleGroupItem.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RogueBattleBuyRoleGroupItem.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06013EBE RID: 81598 RVA: 0x0058D490 File Offset: 0x0058B690
	public override void Refresh(RoleBuyInfoGroupData data, bool isSelected, int gridIndex)
	{
		int num = gridIndex * 2;
		int num2 = gridIndex * 2 + 1;
		RogueBattleBuyRoleItem roleItem = this.RoleItem1;
		RogueResGainData data2 = data.Data1;
		Func<int, bool> isSelectOn = this.IsSelectOn;
		roleItem.Refresh(data2, isSelectOn != null && isSelectOn(num), num);
		RogueBattleBuyRoleItem roleItem2 = this.RoleItem2;
		RogueResGainData data3 = data.Data2;
		Func<int, bool> isSelectOn2 = this.IsSelectOn;
		roleItem2.Refresh(data3, isSelectOn2 != null && isSelectOn2(num2), num2);
	}

	// Token: 0x06013EBF RID: 81599 RVA: 0x0058D4F1 File Offset: 0x0058B6F1
	private RogueBattleBuyRoleItem GetRoleItem(int index)
	{
		if (index % 2 != 0)
		{
			return this.RoleItem2;
		}
		return this.RoleItem1;
	}

	// Token: 0x06013EC0 RID: 81600 RVA: 0x0058D505 File Offset: 0x0058B705
	public void Select(int index)
	{
		this.GetRoleItem(index).OnSelected();
	}

	// Token: 0x06013EC1 RID: 81601 RVA: 0x0058D513 File Offset: 0x0058B713
	public void Deselect(int index)
	{
		this.GetRoleItem(index).OnDeselected();
	}

	// Token: 0x06013EC2 RID: 81602 RVA: 0x0058D521 File Offset: 0x0058B721
	[NullableContext(2)]
	public UUIItem GetRoleUiItem(int index)
	{
		return this.GetRoleItem(index).GetOriginalItem();
	}

	// Token: 0x06013EC3 RID: 81603 RVA: 0x0058D52F File Offset: 0x0058B72F
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (configParams.Length == 0)
		{
			return null;
		}
		if (!(configParams[0] == "FirstRole"))
		{
			return null;
		}
		RogueBattleBuyRoleItem roleItem = this.GetRoleItem(0);
		if (roleItem == null)
		{
			return null;
		}
		return roleItem.GetGuideUiItemAndUiItemForShowEx(configParams);
	}

	// Token: 0x04009AF9 RID: 39673
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<int, RogueResGainData> OnSelectCallback;

	// Token: 0x04009AFA RID: 39674
	[Nullable(2)]
	public Func<int, bool> IsSelectOn;

	// Token: 0x04009AFB RID: 39675
	private RogueBattleBuyRoleItem RoleItem1;

	// Token: 0x04009AFC RID: 39676
	private RogueBattleBuyRoleItem RoleItem2;
}
