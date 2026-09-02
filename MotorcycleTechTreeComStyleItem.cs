using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002295 RID: 8853
[NullableContext(2)]
[Nullable(0)]
public class MotorcycleTechTreeComStyleItem : UiPanelBase
{
	// Token: 0x06010BCA RID: 68554 RVA: 0x00496178 File Offset: 0x00494378
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
	}

	// Token: 0x06010BCB RID: 68555 RVA: 0x004961D4 File Offset: 0x004943D4
	protected override UniTask OnBeforeStartAsync()
	{
		MotorcycleTechTreeComStyleItem.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<MotorcycleTechTreeComStyleItem.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06010BCC RID: 68556 RVA: 0x00496217 File Offset: 0x00494417
	[NullableContext(1)]
	public void SetNodeClick(Action<MotorTechTreeNode, UUIExtendToggle> nodeClick)
	{
		this.CommonNodeItemFirst.OnClickToggleBack = nodeClick;
		this.CommonNodeItemSecond.OnClickToggleBack = nodeClick;
		this.CommonNodeItemThird.OnClickToggleBack = nodeClick;
	}

	// Token: 0x06010BCD RID: 68557 RVA: 0x00496240 File Offset: 0x00494440
	[NullableContext(1)]
	private UniTask RefreshOneNodeItemAsync(MotorcycleTechTreeComNodeItem item, int nodeId)
	{
		MotorcycleTechTreeComStyleItem.<RefreshOneNodeItemAsync>d__7 <RefreshOneNodeItemAsync>d__;
		<RefreshOneNodeItemAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshOneNodeItemAsync>d__.item = item;
		<RefreshOneNodeItemAsync>d__.nodeId = nodeId;
		<RefreshOneNodeItemAsync>d__.<>1__state = -1;
		<RefreshOneNodeItemAsync>d__.<>t__builder.Start<MotorcycleTechTreeComStyleItem.<RefreshOneNodeItemAsync>d__7>(ref <RefreshOneNodeItemAsync>d__);
		return <RefreshOneNodeItemAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06010BCE RID: 68558 RVA: 0x0049628C File Offset: 0x0049448C
	[NullableContext(1)]
	public UniTask RefreshCommonNodeItemAsync(int[] nodeIds)
	{
		MotorcycleTechTreeComStyleItem.<RefreshCommonNodeItemAsync>d__8 <RefreshCommonNodeItemAsync>d__;
		<RefreshCommonNodeItemAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshCommonNodeItemAsync>d__.<>4__this = this;
		<RefreshCommonNodeItemAsync>d__.nodeIds = nodeIds;
		<RefreshCommonNodeItemAsync>d__.<>1__state = -1;
		<RefreshCommonNodeItemAsync>d__.<>t__builder.Start<MotorcycleTechTreeComStyleItem.<RefreshCommonNodeItemAsync>d__8>(ref <RefreshCommonNodeItemAsync>d__);
		return <RefreshCommonNodeItemAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06010BCF RID: 68559 RVA: 0x004962D7 File Offset: 0x004944D7
	public MotorcycleTechTreeComNodeItem GetGuideNodeItem(int index)
	{
		switch (index)
		{
		case 0:
			return this.CommonNodeItemFirst;
		case 1:
			return this.CommonNodeItemSecond;
		case 2:
			return this.CommonNodeItemThird;
		default:
			return null;
		}
	}

	// Token: 0x04008408 RID: 33800
	private MotorcycleTechTreeComNodeItem CommonNodeItemFirst;

	// Token: 0x04008409 RID: 33801
	private MotorcycleTechTreeComNodeItem CommonNodeItemSecond;

	// Token: 0x0400840A RID: 33802
	private MotorcycleTechTreeComNodeItem CommonNodeItemThird;

	// Token: 0x02008562 RID: 34146
	[NullableContext(0)]
	private static class EMotorTreeComStyleItemComponent
	{
		// Token: 0x0402D23A RID: 184890
		public const int CommonNodeItem1 = 0;

		// Token: 0x0402D23B RID: 184891
		public const int CommonNodeItem2 = 1;

		// Token: 0x0402D23C RID: 184892
		public const int CommonNodeItem3 = 2;
	}
}
