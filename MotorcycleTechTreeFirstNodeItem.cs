using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002297 RID: 8855
public class MotorcycleTechTreeFirstNodeItem : UiPanelBase
{
	// Token: 0x06010BD8 RID: 68568 RVA: 0x00496528 File Offset: 0x00494728
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnTechTreeNodeClick))
		};
	}

	// Token: 0x06010BD9 RID: 68569 RVA: 0x004965D1 File Offset: 0x004947D1
	protected override void OnStart()
	{
		this.LevelLayout = new GenericLayout<MotorcycleTechTreeLevelItem, IMotorTechLevelPoint>(base.GetHorizontalLayout(2), new Func<MotorcycleTechTreeLevelItem>(this.InitLevelItem), null, false, true);
	}

	// Token: 0x06010BDA RID: 68570 RVA: 0x004965F4 File Offset: 0x004947F4
	public UniTask RefreshNodeAsync()
	{
		MotorcycleTechTreeFirstNodeItem.<RefreshNodeAsync>d__6 <RefreshNodeAsync>d__;
		<RefreshNodeAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshNodeAsync>d__.<>4__this = this;
		<RefreshNodeAsync>d__.<>1__state = -1;
		<RefreshNodeAsync>d__.<>t__builder.Start<MotorcycleTechTreeFirstNodeItem.<RefreshNodeAsync>d__6>(ref <RefreshNodeAsync>d__);
		return <RefreshNodeAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06010BDB RID: 68571 RVA: 0x00496638 File Offset: 0x00494838
	[NullableContext(2)]
	public UniTask RefreshNodeAsyncByData(MotorTechTreeNode treeNode)
	{
		MotorcycleTechTreeFirstNodeItem.<RefreshNodeAsyncByData>d__7 <RefreshNodeAsyncByData>d__;
		<RefreshNodeAsyncByData>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshNodeAsyncByData>d__.<>4__this = this;
		<RefreshNodeAsyncByData>d__.treeNode = treeNode;
		<RefreshNodeAsyncByData>d__.<>1__state = -1;
		<RefreshNodeAsyncByData>d__.<>t__builder.Start<MotorcycleTechTreeFirstNodeItem.<RefreshNodeAsyncByData>d__7>(ref <RefreshNodeAsyncByData>d__);
		return <RefreshNodeAsyncByData>d__.<>t__builder.Task;
	}

	// Token: 0x06010BDC RID: 68572 RVA: 0x00496683 File Offset: 0x00494883
	[NullableContext(1)]
	private MotorcycleTechTreeLevelItem InitLevelItem()
	{
		return new MotorcycleTechTreeLevelItem();
	}

	// Token: 0x06010BDD RID: 68573 RVA: 0x0049668A File Offset: 0x0049488A
	public void SelectNode()
	{
		this.OnSelectTechTreeNode();
	}

	// Token: 0x06010BDE RID: 68574 RVA: 0x00496692 File Offset: 0x00494892
	private void OnTechTreeNodeClick(EToggleState toggleState)
	{
		this.OnSelectTechTreeNode();
	}

	// Token: 0x06010BDF RID: 68575 RVA: 0x0049669A File Offset: 0x0049489A
	private void OnSelectTechTreeNode()
	{
		Action<MotorTechTreeNode, UUIExtendToggle> onClickToggleBack = this.OnClickToggleBack;
		if (onClickToggleBack == null)
		{
			return;
		}
		onClickToggleBack(this.Node, base.GetExtendToggle(0));
	}

	// Token: 0x04008410 RID: 33808
	[Nullable(2)]
	public MotorTechTreeNode Node;

	// Token: 0x04008411 RID: 33809
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<MotorcycleTechTreeLevelItem, IMotorTechLevelPoint> LevelLayout;

	// Token: 0x04008412 RID: 33810
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public Action<MotorTechTreeNode, UUIExtendToggle> OnClickToggleBack;

	// Token: 0x02008568 RID: 34152
	private class EMotorTreeFirstItemComponent
	{
		// Token: 0x0402D254 RID: 184916
		public const int TogItem = 0;

		// Token: 0x0402D255 RID: 184917
		public const int TexIcon = 1;

		// Token: 0x0402D256 RID: 184918
		public const int LevelLayout = 2;

		// Token: 0x0402D257 RID: 184919
		public const int LevelItem = 3;

		// Token: 0x0402D258 RID: 184920
		public const int RedDotItem = 4;
	}
}
