using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200164E RID: 5710
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class WheelTowerResultTeamItem : GridProxyAbstract<NewTowerTeamRecordPb>
{
	// Token: 0x0600A056 RID: 41046 RVA: 0x0029F43C File Offset: 0x0029D63C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600A057 RID: 41047 RVA: 0x0029F54A File Offset: 0x0029D74A
	protected override void OnStart()
	{
		this.RoleLayout = new GenericLayout<WheelTowerResultRoleItem, int>(base.GetHorizontalLayout(1), () => new WheelTowerResultRoleItem(), null, false, true);
	}

	// Token: 0x0600A058 RID: 41048 RVA: 0x0029F580 File Offset: 0x0029D780
	public override UniTask RefreshAsync(NewTowerTeamRecordPb data, bool isSelected, int gridIndex)
	{
		WheelTowerResultTeamItem.<RefreshAsync>d__3 <RefreshAsync>d__;
		<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshAsync>d__.<>4__this = this;
		<RefreshAsync>d__.data = data;
		<RefreshAsync>d__.gridIndex = gridIndex;
		<RefreshAsync>d__.<>1__state = -1;
		<RefreshAsync>d__.<>t__builder.Start<WheelTowerResultTeamItem.<RefreshAsync>d__3>(ref <RefreshAsync>d__);
		return <RefreshAsync>d__.<>t__builder.Task;
	}

	// Token: 0x040049EF RID: 18927
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<WheelTowerResultRoleItem, int> RoleLayout;
}
