using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200135C RID: 4956
public class RoleGrowingMainView : UiViewBase
{
	// Token: 0x060087C5 RID: 34757 RVA: 0x0023CB26 File Offset: 0x0023AD26
	[NullableContext(1)]
	public RoleGrowingMainView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x060087C6 RID: 34758 RVA: 0x0023CB3C File Offset: 0x0023AD3C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x060087C7 RID: 34759 RVA: 0x0023CC08 File Offset: 0x0023AE08
	protected override UniTask OnBeforeStartAsync()
	{
		RoleGrowingMainView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RoleGrowingMainView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060087C8 RID: 34760 RVA: 0x0023CC4C File Offset: 0x0023AE4C
	protected override void OnBeforeShow()
	{
		ControllerBase<ActivityController>.Instance.CheckIsActivityClose(null, new int?(this.ActivityBaseData.Id));
		this.OnDataUpdate();
	}

	// Token: 0x060087C9 RID: 34761 RVA: 0x0023CC82 File Offset: 0x0023AE82
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.LongShanUpdate, new Action(this.OnDataUpdate));
	}

	// Token: 0x060087CA RID: 34762 RVA: 0x0023CCA0 File Offset: 0x0023AEA0
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.LongShanUpdate, new Action(this.OnDataUpdate));
	}

	// Token: 0x060087CB RID: 34763 RVA: 0x0023CCC0 File Offset: 0x0023AEC0
	private void OnDataUpdate()
	{
		foreach (RoleGrowingStageItem roleGrowingStageItem in this.StageItems)
		{
			roleGrowingStageItem.Refresh(this.ActivityBaseData);
		}
	}

	// Token: 0x060087CC RID: 34764 RVA: 0x0023CD18 File Offset: 0x0023AF18
	private void OnClickStageDetail(int stageId)
	{
		if (this.ActivityBaseData.GetStageInfoById(stageId) != null)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RoleGrowingTaskView, new object[]
			{
				this.ActivityBaseData,
				stageId
			}, null);
			return;
		}
		ControllerBase<ActivityLongShanController>.Instance.ShowUnlockTip(stageId);
	}

	// Token: 0x04003FE6 RID: 16358
	[Nullable(2)]
	protected ActivityLongShanData ActivityBaseData;

	// Token: 0x04003FE7 RID: 16359
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x04003FE8 RID: 16360
	[Nullable(1)]
	private readonly List<RoleGrowingStageItem> StageItems = new List<RoleGrowingStageItem>();

	// Token: 0x02007704 RID: 30468
	private class EComponents
	{
		// Token: 0x04028FCC RID: 167884
		public const int Caption = 0;

		// Token: 0x04028FCD RID: 167885
		public const int Stage1 = 1;

		// Token: 0x04028FCE RID: 167886
		public const int Stage2 = 2;

		// Token: 0x04028FCF RID: 167887
		public const int Stage3 = 3;

		// Token: 0x04028FD0 RID: 167888
		public const int Stage4 = 4;
	}
}
