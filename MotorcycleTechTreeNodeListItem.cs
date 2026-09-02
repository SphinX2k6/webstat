using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200229C RID: 8860
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class MotorcycleTechTreeNodeListItem : GridProxyAbstract<IMotorTechNodeListData>
{
	// Token: 0x06010BF5 RID: 68597 RVA: 0x00496DFC File Offset: 0x00494FFC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem))
		};
	}

	// Token: 0x06010BF6 RID: 68598 RVA: 0x00496E84 File Offset: 0x00495084
	protected override UniTask OnBeforeStartAsync()
	{
		MotorcycleTechTreeNodeListItem.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<MotorcycleTechTreeNodeListItem.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06010BF7 RID: 68599 RVA: 0x00496EC7 File Offset: 0x004950C7
	public override void Refresh(IMotorTechNodeListData data, bool isSelected, int gridIndex)
	{
		this.RefreshTopOrBottomAsync(data);
	}

	// Token: 0x06010BF8 RID: 68600 RVA: 0x00496ED4 File Offset: 0x004950D4
	private UniTask RefreshTopOrBottomAsync(IMotorTechNodeListData data)
	{
		MotorcycleTechTreeNodeListItem.<RefreshTopOrBottomAsync>d__8 <RefreshTopOrBottomAsync>d__;
		<RefreshTopOrBottomAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshTopOrBottomAsync>d__.<>4__this = this;
		<RefreshTopOrBottomAsync>d__.data = data;
		<RefreshTopOrBottomAsync>d__.<>1__state = -1;
		<RefreshTopOrBottomAsync>d__.<>t__builder.Start<MotorcycleTechTreeNodeListItem.<RefreshTopOrBottomAsync>d__8>(ref <RefreshTopOrBottomAsync>d__);
		return <RefreshTopOrBottomAsync>d__.<>t__builder.Task;
	}

	// Token: 0x04008418 RID: 33816
	private readonly List<MotorcycleTechTreeNodeItem> TopNodeItemList = new List<MotorcycleTechTreeNodeItem>();

	// Token: 0x04008419 RID: 33817
	[Nullable(2)]
	private MotorcycleTechTreeNodeItem MiddleNodeItem;

	// Token: 0x0400841A RID: 33818
	private readonly List<MotorcycleTechTreeNodeItem> BottomNodeItemList = new List<MotorcycleTechTreeNodeItem>();

	// Token: 0x0400841B RID: 33819
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<MotorcycleTechTreeNodeItem> OnAfterRefreshOneNode;

	// Token: 0x0200856F RID: 34159
	[NullableContext(0)]
	private class EMotorTreeNodeListItemComponent
	{
		// Token: 0x0402D274 RID: 184948
		public const int NodeItem = 0;

		// Token: 0x0402D275 RID: 184949
		public const int TopLineItem = 1;

		// Token: 0x0402D276 RID: 184950
		public const int BottomLineItem = 2;

		// Token: 0x0402D277 RID: 184951
		public const int TopRoot = 3;

		// Token: 0x0402D278 RID: 184952
		public const int BottomRoot = 4;

		// Token: 0x0402D279 RID: 184953
		public const int LeftLineItem = 5;
	}
}
