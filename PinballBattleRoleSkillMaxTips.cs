using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001D68 RID: 7528
public class PinballBattleRoleSkillMaxTips : PinballBattleTipsBase
{
	// Token: 0x0600DD95 RID: 56725 RVA: 0x003B957B File Offset: 0x003B777B
	[NullableContext(1)]
	public PinballBattleRoleSkillMaxTips(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600DD96 RID: 56726 RVA: 0x003B9584 File Offset: 0x003B7784
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUILayoutBase));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600DD97 RID: 56727 RVA: 0x003B9610 File Offset: 0x003B7810
	protected override UniTask OnBeforeStartAsync()
	{
		PinballBattleRoleSkillMaxTips.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<PinballBattleRoleSkillMaxTips.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x04006A62 RID: 27234
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<PinballBattleRoleHeadItem, int> Layout;
}
