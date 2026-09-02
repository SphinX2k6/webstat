using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020013BB RID: 5051
[NullableContext(1)]
[Nullable(0)]
public class CharacterListModule<[Nullable(0)] T> : UiPanelBase where T : GridProxyAbstract<CharacterData>
{
	// Token: 0x06008B6A RID: 35690 RVA: 0x0024B72E File Offset: 0x0024992E
	public CharacterListModule(Func<T> func)
	{
		this.InitCharacterItemFunc = func;
	}

	// Token: 0x06008B6B RID: 35691 RVA: 0x0024B73D File Offset: 0x0024993D
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUILayoutBase)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
	}

	// Token: 0x06008B6C RID: 35692 RVA: 0x0024B776 File Offset: 0x00249976
	protected override void OnStart()
	{
		this.Layout = new GenericLayout<T, CharacterData>(base.GetLayoutBase(0), new Func<T>(this.InitCharacterItem), base.GetItem(1).GetOwner() as AUIBaseActor, false, true);
	}

	// Token: 0x06008B6D RID: 35693 RVA: 0x0024B7AC File Offset: 0x002499AC
	public UniTask RefreshByDataAsync(IReadOnlyList<CharacterData> dataList)
	{
		CharacterListModule<T>.<RefreshByDataAsync>d__6 <RefreshByDataAsync>d__;
		<RefreshByDataAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshByDataAsync>d__.<>4__this = this;
		<RefreshByDataAsync>d__.dataList = dataList;
		<RefreshByDataAsync>d__.<>1__state = -1;
		<RefreshByDataAsync>d__.<>t__builder.Start<CharacterListModule<T>.<RefreshByDataAsync>d__6>(ref <RefreshByDataAsync>d__);
		return <RefreshByDataAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06008B6E RID: 35694 RVA: 0x0024B7F7 File Offset: 0x002499F7
	private T InitCharacterItem()
	{
		return this.InitCharacterItemFunc();
	}

	// Token: 0x06008B6F RID: 35695 RVA: 0x0024B804 File Offset: 0x00249A04
	public List<T> GetItemList()
	{
		return this.Layout.GetLayoutItemList();
	}

	// Token: 0x0400411A RID: 16666
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<T, CharacterData> Layout;

	// Token: 0x0400411B RID: 16667
	private readonly Func<T> InitCharacterItemFunc;

	// Token: 0x02007785 RID: 30597
	[NullableContext(0)]
	private static class EComponentDefine
	{
		// Token: 0x04029250 RID: 168528
		public const int CharacterList = 0;

		// Token: 0x04029251 RID: 168529
		public const int CharacterItem = 1;
	}
}
