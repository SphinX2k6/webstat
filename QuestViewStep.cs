using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.BattleUi.Views;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002672 RID: 9842
public class QuestViewStep : StepBaseItem
{
	// Token: 0x06013656 RID: 79446 RVA: 0x005685AF File Offset: 0x005667AF
	public QuestViewStep(EMissionItemView viewId, int stepId) : base(viewId, stepId)
	{
	}

	// Token: 0x06013657 RID: 79447 RVA: 0x005685C4 File Offset: 0x005667C4
	protected override void OnRegisterComponent()
	{
		base.OnRegisterComponent();
		this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(2, typeof(UUIItem)));
		this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(3, typeof(UUIItem)));
		this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(4, typeof(UUIItem)));
	}

	// Token: 0x06013658 RID: 79448 RVA: 0x00568628 File Offset: 0x00566828
	protected override UniTask OnBeforeStartAsync()
	{
		QuestViewStep.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<QuestViewStep.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06013659 RID: 79449 RVA: 0x0056866B File Offset: 0x0056686B
	protected override void OnBeforeDestroy()
	{
	}

	// Token: 0x0601365A RID: 79450 RVA: 0x00568670 File Offset: 0x00566870
	[NullableContext(2)]
	public UniTask Update(BehaviorTreeViewShowData showData)
	{
		QuestViewStep.<Update>d__6 <Update>d__;
		<Update>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Update>d__.<>4__this = this;
		<Update>d__.showData = showData;
		<Update>d__.<>1__state = -1;
		<Update>d__.<>t__builder.Start<QuestViewStep.<Update>d__6>(ref <Update>d__);
		return <Update>d__.<>t__builder.Task;
	}

	// Token: 0x0601365B RID: 79451 RVA: 0x005686BC File Offset: 0x005668BC
	[return: TupleElementNames(new string[]
	{
		"Count",
		"LastActiveStep"
	})]
	[return: Nullable(new byte[]
	{
		0,
		0,
		2
	})]
	private UniTask<ValueTuple<int, QuestViewChildStep>> UpdateChildSteps()
	{
		QuestViewStep.<UpdateChildSteps>d__7 <UpdateChildSteps>d__;
		<UpdateChildSteps>d__.<>t__builder = AsyncUniTaskMethodBuilder<ValueTuple<int, QuestViewChildStep>>.Create();
		<UpdateChildSteps>d__.<>4__this = this;
		<UpdateChildSteps>d__.<>1__state = -1;
		<UpdateChildSteps>d__.<>t__builder.Start<QuestViewStep.<UpdateChildSteps>d__7>(ref <UpdateChildSteps>d__);
		return <UpdateChildSteps>d__.<>t__builder.Task;
	}

	// Token: 0x04009755 RID: 38741
	[Nullable(1)]
	private readonly List<QuestViewChildStep> ChildSteps = new List<QuestViewChildStep>();

	// Token: 0x02008A0D RID: 35341
	private static class EChildComponent
	{
		// Token: 0x0402E902 RID: 190722
		public const int ChildStep = 2;

		// Token: 0x0402E903 RID: 190723
		public const int HorizontalNode = 3;

		// Token: 0x0402E904 RID: 190724
		public const int PanelLine = 4;
	}
}
