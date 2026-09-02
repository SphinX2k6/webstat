using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020028D3 RID: 10451
public class RoleSkillTrickInputItem : UiPanelBase
{
	// Token: 0x06014C40 RID: 85056 RVA: 0x005C170C File Offset: 0x005BF90C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06014C41 RID: 85057 RVA: 0x005C1775 File Offset: 0x005BF975
	protected override void OnStart()
	{
		this.Layout = new GenericLayout<RoleSkillInputItem, IRoleSkillInputParam>(base.GetVerticalLayout(0), new Func<RoleSkillInputItem>(this.InitRoleSkillInputItem), base.GetItem(1).GetOwner() as AUIBaseActor, false, true);
	}

	// Token: 0x06014C42 RID: 85058 RVA: 0x005C17A8 File Offset: 0x005BF9A8
	[NullableContext(1)]
	private RoleSkillInputItem InitRoleSkillInputItem()
	{
		return new RoleSkillInputItem();
	}

	// Token: 0x06014C43 RID: 85059 RVA: 0x005C17B0 File Offset: 0x005BF9B0
	[NullableContext(1)]
	public UniTask RefreshAsync(List<IRoleSkillInputParam> param)
	{
		RoleSkillTrickInputItem.<RefreshAsync>d__5 <RefreshAsync>d__;
		<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshAsync>d__.<>4__this = this;
		<RefreshAsync>d__.param = param;
		<RefreshAsync>d__.<>1__state = -1;
		<RefreshAsync>d__.<>t__builder.Start<RoleSkillTrickInputItem.<RefreshAsync>d__5>(ref <RefreshAsync>d__);
		return <RefreshAsync>d__.<>t__builder.Task;
	}

	// Token: 0x04009FF0 RID: 40944
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<RoleSkillInputItem, IRoleSkillInputParam> Layout;

	// Token: 0x02008C2C RID: 35884
	private enum ESkillInputComponent
	{
		// Token: 0x0402F386 RID: 193414
		Layout,
		// Token: 0x0402F387 RID: 193415
		InputItem
	}
}
