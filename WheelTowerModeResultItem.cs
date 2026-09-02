using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200164A RID: 5706
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class WheelTowerModeResultItem : GridProxyAbstract<NewTowerLevelRecordPb>
{
	// Token: 0x0600A04F RID: 41039 RVA: 0x0029F020 File Offset: 0x0029D220
	protected unsafe override void OnRegisterComponent()
	{
		int num = 12;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIVerticalLayout));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600A050 RID: 41040 RVA: 0x0029F1D7 File Offset: 0x0029D3D7
	protected override void OnStart()
	{
		this.TeamLayout = new GenericLayout<WheelTowerResultTeamItem, NewTowerTeamRecordPb>(base.GetVerticalLayout(11), () => new WheelTowerResultTeamItem(), null, true, true);
	}

	// Token: 0x0600A051 RID: 41041 RVA: 0x0029F210 File Offset: 0x0029D410
	public override UniTask RefreshAsync(NewTowerLevelRecordPb data, bool isSelected, int gridIndex)
	{
		WheelTowerModeResultItem.<RefreshAsync>d__3 <RefreshAsync>d__;
		<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshAsync>d__.<>4__this = this;
		<RefreshAsync>d__.data = data;
		<RefreshAsync>d__.<>1__state = -1;
		<RefreshAsync>d__.<>t__builder.Start<WheelTowerModeResultItem.<RefreshAsync>d__3>(ref <RefreshAsync>d__);
		return <RefreshAsync>d__.<>t__builder.Task;
	}

	// Token: 0x040049DE RID: 18910
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<WheelTowerResultTeamItem, NewTowerTeamRecordPb> TeamLayout;
}
