using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002296 RID: 8854
[NullableContext(1)]
[Nullable(0)]
public class MotorcycleTechTreeComStyleItem2 : UiPanelBase
{
	// Token: 0x06010BD1 RID: 68561 RVA: 0x0049630C File Offset: 0x0049450C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(3, typeof(UUIItem))
		};
	}

	// Token: 0x06010BD2 RID: 68562 RVA: 0x0049637C File Offset: 0x0049457C
	protected override void OnStart()
	{
		this.LeftLayout = new GenericLayout<MotorcycleTechTreeComNodeItem, MotorTechTreeNode>(base.GetVerticalLayout(0), new Func<MotorcycleTechTreeComNodeItem>(this.InitComNodeItem), null, false, true);
		this.RightLayout = new GenericLayout<MotorcycleTechTreeComNodeItem, MotorTechTreeNode>(base.GetVerticalLayout(2), new Func<MotorcycleTechTreeComNodeItem>(this.InitComNodeItem), null, false, true);
	}

	// Token: 0x06010BD3 RID: 68563 RVA: 0x004963CB File Offset: 0x004945CB
	private MotorcycleTechTreeComNodeItem InitComNodeItem()
	{
		return new MotorcycleTechTreeComNodeItem();
	}

	// Token: 0x06010BD4 RID: 68564 RVA: 0x004963D4 File Offset: 0x004945D4
	public void SetNodeClick(Action<MotorTechTreeNode, UUIExtendToggle> nodeClick)
	{
		GenericLayout<MotorcycleTechTreeComNodeItem, MotorTechTreeNode> leftLayout = this.LeftLayout;
		List<MotorcycleTechTreeComNodeItem> list = (leftLayout != null) ? leftLayout.GetLayoutItemList() : null;
		GenericLayout<MotorcycleTechTreeComNodeItem, MotorTechTreeNode> rightLayout = this.RightLayout;
		List<MotorcycleTechTreeComNodeItem> list2 = (rightLayout != null) ? rightLayout.GetLayoutItemList() : null;
		if (list != null)
		{
			for (int i = 0; i < list.Count; i++)
			{
				list[i].OnClickToggleBack = nodeClick;
			}
		}
		if (list2 != null)
		{
			for (int j = 0; j < list2.Count; j++)
			{
				list2[j].OnClickToggleBack = nodeClick;
			}
		}
	}

	// Token: 0x06010BD5 RID: 68565 RVA: 0x0049644C File Offset: 0x0049464C
	[NullableContext(2)]
	public MotorcycleTechTreeComNodeItem GetGuideNodeItem(int index)
	{
		GenericLayout<MotorcycleTechTreeComNodeItem, MotorTechTreeNode> leftLayout = this.LeftLayout;
		List<MotorcycleTechTreeComNodeItem> list = (leftLayout != null) ? leftLayout.GetLayoutItemList() : null;
		if (list != null && index < list.Count)
		{
			return list[index];
		}
		int num = index - ((list != null) ? list.Count : 0);
		GenericLayout<MotorcycleTechTreeComNodeItem, MotorTechTreeNode> rightLayout = this.RightLayout;
		List<MotorcycleTechTreeComNodeItem> list2 = (rightLayout != null) ? rightLayout.GetLayoutItemList() : null;
		if (list2 != null && num >= 0 && num < list2.Count)
		{
			return list2[num];
		}
		return null;
	}

	// Token: 0x06010BD6 RID: 68566 RVA: 0x004964BC File Offset: 0x004946BC
	public UniTask RefreshCommonNodeItemAsync(int[] nodeIds)
	{
		MotorcycleTechTreeComStyleItem2.<RefreshCommonNodeItemAsync>d__11 <RefreshCommonNodeItemAsync>d__;
		<RefreshCommonNodeItemAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshCommonNodeItemAsync>d__.<>4__this = this;
		<RefreshCommonNodeItemAsync>d__.nodeIds = nodeIds;
		<RefreshCommonNodeItemAsync>d__.<>1__state = -1;
		<RefreshCommonNodeItemAsync>d__.<>t__builder.Start<MotorcycleTechTreeComStyleItem2.<RefreshCommonNodeItemAsync>d__11>(ref <RefreshCommonNodeItemAsync>d__);
		return <RefreshCommonNodeItemAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0400840B RID: 33803
	private const int LEFT_NODE_MAX_COUNT = 4;

	// Token: 0x0400840C RID: 33804
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<MotorcycleTechTreeComNodeItem, MotorTechTreeNode> LeftLayout;

	// Token: 0x0400840D RID: 33805
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<MotorcycleTechTreeComNodeItem, MotorTechTreeNode> RightLayout;

	// Token: 0x0400840E RID: 33806
	private List<MotorTechTreeNode> LeftDataList = new List<MotorTechTreeNode>();

	// Token: 0x0400840F RID: 33807
	private List<MotorTechTreeNode> RightDataList = new List<MotorTechTreeNode>();

	// Token: 0x02008566 RID: 34150
	[NullableContext(0)]
	private static class EMotorTreeComStyleItemComponent
	{
		// Token: 0x0402D24B RID: 184907
		public const int LeftLayout = 0;

		// Token: 0x0402D24C RID: 184908
		public const int LeftItem = 1;

		// Token: 0x0402D24D RID: 184909
		public const int RightLayout = 2;

		// Token: 0x0402D24E RID: 184910
		public const int RightItem = 3;
	}
}
