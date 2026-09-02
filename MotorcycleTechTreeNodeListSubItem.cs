using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200229D RID: 8861
[NullableContext(1)]
[Nullable(0)]
public class MotorcycleTechTreeNodeListSubItem : UiPanelBase
{
	// Token: 0x06010BFA RID: 68602 RVA: 0x00496F40 File Offset: 0x00495140
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
	}

	// Token: 0x06010BFB RID: 68603 RVA: 0x00496F9A File Offset: 0x0049519A
	protected override void OnStart()
	{
		this.SubLayout = new GenericLayout<MotorcycleTechTreeNodeItem, MotorTechTreeNode>(base.GetVerticalLayout(0), new Func<MotorcycleTechTreeNodeItem>(this.InitItem), base.GetItem(2).GetOwner() as AUIBaseActor, false, true);
		base.GetItem(1).SetUIActive(false);
	}

	// Token: 0x06010BFC RID: 68604 RVA: 0x00496FDC File Offset: 0x004951DC
	public UniTask RefreshAsync(int[] idList)
	{
		MotorcycleTechTreeNodeListSubItem.<RefreshAsync>d__4 <RefreshAsync>d__;
		<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshAsync>d__.<>4__this = this;
		<RefreshAsync>d__.idList = idList;
		<RefreshAsync>d__.<>1__state = -1;
		<RefreshAsync>d__.<>t__builder.Start<MotorcycleTechTreeNodeListSubItem.<RefreshAsync>d__4>(ref <RefreshAsync>d__);
		return <RefreshAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06010BFD RID: 68605 RVA: 0x00497027 File Offset: 0x00495227
	public List<MotorcycleTechTreeNodeItem> GetSubLayoutItemList()
	{
		return this.SubLayout.GetLayoutItemList();
	}

	// Token: 0x06010BFE RID: 68606 RVA: 0x00497034 File Offset: 0x00495234
	private MotorcycleTechTreeNodeItem InitItem()
	{
		return new MotorcycleTechTreeNodeItem();
	}

	// Token: 0x0400841C RID: 33820
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<MotorcycleTechTreeNodeItem, MotorTechTreeNode> SubLayout;

	// Token: 0x02008572 RID: 34162
	[NullableContext(0)]
	private class EMotorTreeNodeListSubItemComponent
	{
		// Token: 0x0402D285 RID: 184965
		public const int LayoutItem = 0;

		// Token: 0x0402D286 RID: 184966
		public const int LineItem = 1;

		// Token: 0x0402D287 RID: 184967
		public const int SubItem = 2;
	}
}
