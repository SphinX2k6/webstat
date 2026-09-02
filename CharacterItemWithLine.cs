using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020013B9 RID: 5049
[Nullable(new byte[]
{
	0,
	1
})]
public class CharacterItemWithLine : GridProxyAbstract<CharacterData>
{
	// Token: 0x06008B62 RID: 35682 RVA: 0x0024B5C4 File Offset: 0x002497C4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
	}

	// Token: 0x06008B63 RID: 35683 RVA: 0x0024B600 File Offset: 0x00249800
	protected override UniTask OnBeforeStartAsync()
	{
		CharacterItemWithLine.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<CharacterItemWithLine.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06008B64 RID: 35684 RVA: 0x0024B643 File Offset: 0x00249843
	[NullableContext(1)]
	public override void Refresh(CharacterData data, bool isSelected, int gridIndex)
	{
		this.CharacterItem.Refresh(data, isSelected, gridIndex);
		UUIItem item = base.GetItem(1);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(gridIndex != 0);
	}

	// Token: 0x04004118 RID: 16664
	[Nullable(2)]
	protected CharacterItem CharacterItem;

	// Token: 0x02007781 RID: 30593
	private static class EComponentDefine
	{
		// Token: 0x04029244 RID: 168516
		public const int CharacterItem = 0;

		// Token: 0x04029245 RID: 168517
		public const int LineItem = 1;
	}
}
