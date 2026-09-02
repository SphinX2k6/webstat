using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020013BA RID: 5050
[Nullable(new byte[]
{
	0,
	1
})]
public class CharacterItemWithoutProgress : GridProxyAbstract<CharacterData>
{
	// Token: 0x06008B66 RID: 35686 RVA: 0x0024B670 File Offset: 0x00249870
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIText))
		};
	}

	// Token: 0x06008B67 RID: 35687 RVA: 0x0024B6AC File Offset: 0x002498AC
	protected override UniTask OnBeforeStartAsync()
	{
		CharacterItemWithoutProgress.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<CharacterItemWithoutProgress.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06008B68 RID: 35688 RVA: 0x0024B6F0 File Offset: 0x002498F0
	[NullableContext(1)]
	public override void Refresh(CharacterData data, bool isSelected, int gridIndex)
	{
		this.NameItem.Refresh(data, false, 0);
		base.GetText(1).SetText(data.CurrentValue.ToString(), true);
	}

	// Token: 0x04004119 RID: 16665
	[Nullable(2)]
	protected CharacterNameItem NameItem;

	// Token: 0x02007783 RID: 30595
	private static class EComponentDefine
	{
		// Token: 0x0402924A RID: 168522
		public const int NameItem = 0;

		// Token: 0x0402924B RID: 168523
		public const int Value = 1;
	}
}
