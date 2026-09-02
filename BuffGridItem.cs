using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200142A RID: 5162
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
internal class BuffGridItem : GridProxyAbstract<BuffGridItemData>
{
	// Token: 0x06008F8F RID: 36751 RVA: 0x0025B0C6 File Offset: 0x002592C6
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
	}

	// Token: 0x06008F90 RID: 36752 RVA: 0x0025B0FF File Offset: 0x002592FF
	protected override void OnStart()
	{
		this.InitItem().Forget();
	}

	// Token: 0x06008F91 RID: 36753 RVA: 0x0025B10C File Offset: 0x0025930C
	private UniTask InitItem()
	{
		BuffGridItem.<InitItem>d__6 <InitItem>d__;
		<InitItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitItem>d__.<>4__this = this;
		<InitItem>d__.<>1__state = -1;
		<InitItem>d__.<>t__builder.Start<BuffGridItem.<InitItem>d__6>(ref <InitItem>d__);
		return <InitItem>d__.<>t__builder.Task;
	}

	// Token: 0x06008F92 RID: 36754 RVA: 0x0025B14F File Offset: 0x0025934F
	[NullableContext(1)]
	public override void Refresh(BuffGridItemData data, bool isSelected, int gridIndex)
	{
		this.WaitRefresh(data, isSelected, gridIndex).Forget();
	}

	// Token: 0x06008F93 RID: 36755 RVA: 0x0025B160 File Offset: 0x00259360
	[NullableContext(1)]
	private UniTask WaitRefresh(BuffGridItemData data, bool isSelected, int gridIndex)
	{
		BuffGridItem.<WaitRefresh>d__8 <WaitRefresh>d__;
		<WaitRefresh>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<WaitRefresh>d__.<>4__this = this;
		<WaitRefresh>d__.data = data;
		<WaitRefresh>d__.isSelected = isSelected;
		<WaitRefresh>d__.gridIndex = gridIndex;
		<WaitRefresh>d__.<>1__state = -1;
		<WaitRefresh>d__.<>t__builder.Start<BuffGridItem.<WaitRefresh>d__8>(ref <WaitRefresh>d__);
		return <WaitRefresh>d__.<>t__builder.Task;
	}

	// Token: 0x0400429A RID: 17050
	private BuffScrollItem GridItem1;

	// Token: 0x0400429B RID: 17051
	private BuffScrollItem GridItem2;

	// Token: 0x0400429C RID: 17052
	private UniTaskCompletionSource _initTcs;
}
