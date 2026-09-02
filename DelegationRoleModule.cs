using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020013CA RID: 5066
[NullableContext(1)]
[Nullable(0)]
public class DelegationRoleModule : UiPanelBase
{
	// Token: 0x06008BEB RID: 35819 RVA: 0x0024D2BC File Offset: 0x0024B4BC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
	}

	// Token: 0x06008BEC RID: 35820 RVA: 0x0024D318 File Offset: 0x0024B518
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	private UniTask<DelegationRoleModuleRoleItem> CreateMediumItemGrid(UUIItem item)
	{
		DelegationRoleModule.<CreateMediumItemGrid>d__4 <CreateMediumItemGrid>d__;
		<CreateMediumItemGrid>d__.<>t__builder = AsyncUniTaskMethodBuilder<DelegationRoleModuleRoleItem>.Create();
		<CreateMediumItemGrid>d__.<>4__this = this;
		<CreateMediumItemGrid>d__.item = item;
		<CreateMediumItemGrid>d__.<>1__state = -1;
		<CreateMediumItemGrid>d__.<>t__builder.Start<DelegationRoleModule.<CreateMediumItemGrid>d__4>(ref <CreateMediumItemGrid>d__);
		return <CreateMediumItemGrid>d__.<>t__builder.Task;
	}

	// Token: 0x06008BED RID: 35821 RVA: 0x0024D364 File Offset: 0x0024B564
	protected override UniTask OnBeforeStartAsync()
	{
		DelegationRoleModule.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<DelegationRoleModule.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06008BEE RID: 35822 RVA: 0x0024D3A7 File Offset: 0x0024B5A7
	private void OnClick()
	{
		Action onClickEvent = this.OnClickEvent;
		if (onClickEvent == null)
		{
			return;
		}
		onClickEvent();
	}

	// Token: 0x06008BEF RID: 35823 RVA: 0x0024D3BC File Offset: 0x0024B5BC
	public void Refresh(HashSet<int> roleIdSet)
	{
		List<int> list = new List<int>(roleIdSet);
		for (int i = 0; i < this.RoleItemList.Count; i++)
		{
			DelegationRoleModuleRoleItem delegationRoleModuleRoleItem = this.RoleItemList[i];
			int? roleId = (i < list.Count) ? new int?(list[i]) : null;
			delegationRoleModuleRoleItem.Refresh(roleId);
		}
	}

	// Token: 0x06008BF0 RID: 35824 RVA: 0x0024D419 File Offset: 0x0024B619
	[NullableContext(2)]
	public void SetClickEvent(Action onClickEvent)
	{
		this.OnClickEvent = onClickEvent;
	}

	// Token: 0x0400413A RID: 16698
	protected List<DelegationRoleModuleRoleItem> RoleItemList = new List<DelegationRoleModuleRoleItem>();

	// Token: 0x0400413B RID: 16699
	[Nullable(2)]
	protected Action OnClickEvent;

	// Token: 0x0200779F RID: 30623
	[NullableContext(0)]
	private static class EComponentDefine
	{
		// Token: 0x040292CE RID: 168654
		public const int FirstRole = 0;

		// Token: 0x040292CF RID: 168655
		public const int SecondRole = 1;

		// Token: 0x040292D0 RID: 168656
		public const int ThirdRole = 2;
	}
}
