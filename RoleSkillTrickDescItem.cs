using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020028D2 RID: 10450
public class RoleSkillTrickDescItem : UiPanelBase
{
	// Token: 0x06014C3B RID: 85051 RVA: 0x005C1624 File Offset: 0x005BF824
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06014C3C RID: 85052 RVA: 0x005C168D File Offset: 0x005BF88D
	protected override void OnStart()
	{
		this.Layout = new GenericLayout<RoleSkillInputDescItem, string>(base.GetVerticalLayout(0), new Func<RoleSkillInputDescItem>(this.InitRoleSkillInputDescItem), null, false, true);
	}

	// Token: 0x06014C3D RID: 85053 RVA: 0x005C16B0 File Offset: 0x005BF8B0
	[NullableContext(1)]
	private RoleSkillInputDescItem InitRoleSkillInputDescItem()
	{
		return new RoleSkillInputDescItem();
	}

	// Token: 0x06014C3E RID: 85054 RVA: 0x005C16B8 File Offset: 0x005BF8B8
	[NullableContext(1)]
	public UniTask RefreshAsync(List<string> descArray)
	{
		RoleSkillTrickDescItem.<RefreshAsync>d__5 <RefreshAsync>d__;
		<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshAsync>d__.<>4__this = this;
		<RefreshAsync>d__.descArray = descArray;
		<RefreshAsync>d__.<>1__state = -1;
		<RefreshAsync>d__.<>t__builder.Start<RoleSkillTrickDescItem.<RefreshAsync>d__5>(ref <RefreshAsync>d__);
		return <RefreshAsync>d__.<>t__builder.Task;
	}

	// Token: 0x04009FEF RID: 40943
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<RoleSkillInputDescItem, string> Layout;

	// Token: 0x02008C2A RID: 35882
	private enum EComponent
	{
		// Token: 0x0402F37E RID: 193406
		Layout,
		// Token: 0x0402F37F RID: 193407
		DescText
	}
}
