using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001419 RID: 5145
[NullableContext(1)]
[Nullable(0)]
public class MoonChasingTaskView : UiViewBase
{
	// Token: 0x06008E9D RID: 36509 RVA: 0x00257468 File Offset: 0x00255668
	public MoonChasingTaskView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x06008E9E RID: 36510 RVA: 0x00257474 File Offset: 0x00255674
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(3, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(2, new Action<EToggleState>(this.OnBranchLine)),
			new ValueTuple<int, Delegate>(3, new Action<EToggleState>(this.OnMainLine))
		};
	}

	// Token: 0x06008E9F RID: 36511 RVA: 0x00257564 File Offset: 0x00255764
	private UniTask InitPopularity()
	{
		MoonChasingTaskView.<InitPopularity>d__8 <InitPopularity>d__;
		<InitPopularity>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitPopularity>d__.<>4__this = this;
		<InitPopularity>d__.<>1__state = -1;
		<InitPopularity>d__.<>t__builder.Start<MoonChasingTaskView.<InitPopularity>d__8>(ref <InitPopularity>d__);
		return <InitPopularity>d__.<>t__builder.Task;
	}

	// Token: 0x06008EA0 RID: 36512 RVA: 0x002575A8 File Offset: 0x002557A8
	private UniTask InitCaptionItem()
	{
		MoonChasingTaskView.<InitCaptionItem>d__9 <InitCaptionItem>d__;
		<InitCaptionItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitCaptionItem>d__.<>4__this = this;
		<InitCaptionItem>d__.<>1__state = -1;
		<InitCaptionItem>d__.<>t__builder.Start<MoonChasingTaskView.<InitCaptionItem>d__9>(ref <InitCaptionItem>d__);
		return <InitCaptionItem>d__.<>t__builder.Task;
	}

	// Token: 0x06008EA1 RID: 36513 RVA: 0x002575EB File Offset: 0x002557EB
	private void InitToggle()
	{
		base.GetExtendToggle(3).CanExecuteChange.Bind(new Func<bool>(this.MainLineCanChange));
		base.GetExtendToggle(2).CanExecuteChange.Bind(new Func<bool>(this.BranchLineCanChange));
	}

	// Token: 0x06008EA2 RID: 36514 RVA: 0x00257628 File Offset: 0x00255828
	protected override UniTask OnBeforeStartAsync()
	{
		MoonChasingTaskView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<MoonChasingTaskView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06008EA3 RID: 36515 RVA: 0x0025766C File Offset: 0x0025586C
	protected override void OnStart()
	{
		this.TaskViewData = (MoonChasingTaskViewData)this.OpenParam;
		if (this.TaskViewData == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.MoonChasing, ELogAuthor.BB, "MoonChasingTaskView Invalid OpenParam", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.InitToggle();
		this.AnimationController = (UUIInturnAnimController)base.GetItem(1).GetOwner().GetComponentByClass(UUIInturnAnimController.StaticClass());
		if (this.TaskViewData.TaskType == EMoonChasingTaskType.MainLine)
		{
			base.GetExtendToggle(3).SetToggleStateForce(EToggleState.ETT_Checked, true, false, false);
			return;
		}
		base.GetExtendToggle(2).SetToggleStateForce(EToggleState.ETT_Checked, true, false, false);
	}

	// Token: 0x06008EA4 RID: 36516 RVA: 0x0025770D File Offset: 0x0025590D
	protected override void OnBeforeShow()
	{
		ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.MoonChasingMainlineTab, base.GetItem(5), null, 0);
		ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.MoonChasingBranchTab, base.GetItem(6), null, 0);
		ControllerBase<ActivityMoonChasingController>.Instance.CheckIsActivityClose();
	}

	// Token: 0x06008EA5 RID: 36517 RVA: 0x00257749 File Offset: 0x00255949
	protected override void OnBeforeHide()
	{
		ControllerBase<RedDotController>.Instance.UnBindRedDot(ERedDotName.MoonChasingMainlineTab);
		ControllerBase<RedDotController>.Instance.UnBindRedDot(ERedDotName.MoonChasingBranchTab);
	}

	// Token: 0x06008EA6 RID: 36518 RVA: 0x0025776C File Offset: 0x0025596C
	private UniTask CreateAndShowMainLine(int taskId, bool isLastTask)
	{
		MoonChasingTaskView.<CreateAndShowMainLine>d__15 <CreateAndShowMainLine>d__;
		<CreateAndShowMainLine>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateAndShowMainLine>d__.<>4__this = this;
		<CreateAndShowMainLine>d__.taskId = taskId;
		<CreateAndShowMainLine>d__.isLastTask = isLastTask;
		<CreateAndShowMainLine>d__.<>1__state = -1;
		<CreateAndShowMainLine>d__.<>t__builder.Start<MoonChasingTaskView.<CreateAndShowMainLine>d__15>(ref <CreateAndShowMainLine>d__);
		return <CreateAndShowMainLine>d__.<>t__builder.Task;
	}

	// Token: 0x06008EA7 RID: 36519 RVA: 0x002577C0 File Offset: 0x002559C0
	private UniTask CreateAndShowBranchLine(int taskId)
	{
		MoonChasingTaskView.<CreateAndShowBranchLine>d__16 <CreateAndShowBranchLine>d__;
		<CreateAndShowBranchLine>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateAndShowBranchLine>d__.<>4__this = this;
		<CreateAndShowBranchLine>d__.taskId = taskId;
		<CreateAndShowBranchLine>d__.<>1__state = -1;
		<CreateAndShowBranchLine>d__.<>t__builder.Start<MoonChasingTaskView.<CreateAndShowBranchLine>d__16>(ref <CreateAndShowBranchLine>d__);
		return <CreateAndShowBranchLine>d__.<>t__builder.Task;
	}

	// Token: 0x06008EA8 RID: 36520 RVA: 0x0025780C File Offset: 0x00255A0C
	private void SwitchHierarchyIndex(int index)
	{
		UUIItem uuiitem = base.GetExtendToggle(3).RootUIComp.Get();
		UUIItem uuiitem2 = base.GetExtendToggle(2).RootUIComp.Get();
		int hierarchyIndex = uuiitem.GetHierarchyIndex();
		int hierarchyIndex2 = uuiitem2.GetHierarchyIndex();
		if ((hierarchyIndex > hierarchyIndex2 && index == 0) || (hierarchyIndex < hierarchyIndex2 && index == 1))
		{
			return;
		}
		uuiitem.SetHierarchyIndex(hierarchyIndex2);
		uuiitem2.SetHierarchyIndex(hierarchyIndex);
	}

	// Token: 0x06008EA9 RID: 36521 RVA: 0x00257874 File Offset: 0x00255A74
	private void OnBranchLine(EToggleState state)
	{
		this.TaskViewData.TaskType = EMoonChasingTaskType.BranchLine;
		if (this.MainLine != null)
		{
			this.MainLine.SetActive(false);
		}
		base.GetExtendToggle(3).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		this.CreateAndShowBranchLine(this.TaskViewData.TargetTaskId).ContinueWith(delegate()
		{
			UUIInturnAnimController animationController = this.AnimationController;
			if (animationController == null)
			{
				return;
			}
			animationController.Play("", -1, false);
		});
		this.SwitchHierarchyIndex(1);
	}

	// Token: 0x06008EAA RID: 36522 RVA: 0x002578DC File Offset: 0x00255ADC
	private void OnMainLine(EToggleState state)
	{
		this.TaskViewData.TaskType = EMoonChasingTaskType.MainLine;
		if (this.BranchLine != null)
		{
			this.BranchLine.SetActive(false);
		}
		base.GetExtendToggle(2).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		this.CreateAndShowMainLine(this.TaskViewData.TargetTaskId, this.TaskViewData.IsLastTask).ContinueWith(delegate()
		{
			UUIInturnAnimController animationController = this.AnimationController;
			if (animationController == null)
			{
				return;
			}
			animationController.Play("", -1, false);
		});
		this.SwitchHierarchyIndex(0);
	}

	// Token: 0x06008EAB RID: 36523 RVA: 0x0025794F File Offset: 0x00255B4F
	private bool MainLineCanChange()
	{
		return this.TaskViewData.TaskType == EMoonChasingTaskType.BranchLine;
	}

	// Token: 0x06008EAC RID: 36524 RVA: 0x0025795F File Offset: 0x00255B5F
	private bool BranchLineCanChange()
	{
		return this.TaskViewData.TaskType != EMoonChasingTaskType.BranchLine;
	}

	// Token: 0x06008EAD RID: 36525 RVA: 0x00257972 File Offset: 0x00255B72
	private void OnClose()
	{
		base.CloseMe(null);
	}

	// Token: 0x06008EAE RID: 36526 RVA: 0x0025797C File Offset: 0x00255B7C
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (configParams.Length < 1)
		{
			return null;
		}
		string a = configParams[0];
		if (a == "Main")
		{
			if (this.MainLine == null)
			{
				return null;
			}
			return this.MainLine.GetGuideUiItemAndUiItemForShowEx(configParams);
		}
		else
		{
			if (!(a == "Branch"))
			{
				return null;
			}
			if (this.BranchLine == null)
			{
				return null;
			}
			return this.BranchLine.GetGuideUiItemAndUiItemForShowEx(configParams);
		}
	}

	// Token: 0x0400426B RID: 17003
	private PopularityModule Popularity;

	// Token: 0x0400426C RID: 17004
	private PopupCaptionItem CaptionItem;

	// Token: 0x0400426D RID: 17005
	private TaskBranchLineModule BranchLine;

	// Token: 0x0400426E RID: 17006
	private TaskMainLineModule MainLine;

	// Token: 0x0400426F RID: 17007
	private UUIInturnAnimController AnimationController;

	// Token: 0x04004270 RID: 17008
	private MoonChasingTaskViewData TaskViewData;

	// Token: 0x0200780D RID: 30733
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x040294B4 RID: 169140
		public const int CaptionItem = 0;

		// Token: 0x040294B5 RID: 169141
		public const int ContentItem = 1;

		// Token: 0x040294B6 RID: 169142
		public const int BranchLineToggle = 2;

		// Token: 0x040294B7 RID: 169143
		public const int MainLineToggle = 3;

		// Token: 0x040294B8 RID: 169144
		public const int PopularityItem = 4;

		// Token: 0x040294B9 RID: 169145
		public const int MainlineRedDotItem = 5;

		// Token: 0x040294BA RID: 169146
		public const int BranchRedDotItem = 6;
	}
}
