using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200135B RID: 4955
[NullableContext(2)]
[Nullable(0)]
public class ActivitySubViewRoleGrowing : ActivitySubViewBase
{
	// Token: 0x060087B9 RID: 34745 RVA: 0x0023C9A0 File Offset: 0x0023ABA0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x060087BA RID: 34746 RVA: 0x0023C9E8 File Offset: 0x0023ABE8
	protected override void OnSetData()
	{
		this.ActivityData = (ActivityLongShanData)this.ActivityBaseData;
	}

	// Token: 0x060087BB RID: 34747 RVA: 0x0023C9FC File Offset: 0x0023ABFC
	protected override UniTask OnBeforeStartAsync()
	{
		ActivitySubViewRoleGrowing.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivitySubViewRoleGrowing.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060087BC RID: 34748 RVA: 0x0023CA3F File Offset: 0x0023AC3F
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.LongShanUpdate, new Action(this.OnDataUpdate));
	}

	// Token: 0x060087BD RID: 34749 RVA: 0x0023CA5D File Offset: 0x0023AC5D
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.LongShanUpdate, new Action(this.OnDataUpdate));
	}

	// Token: 0x060087BE RID: 34750 RVA: 0x0023CA7B File Offset: 0x0023AC7B
	protected override void OnStart()
	{
	}

	// Token: 0x060087BF RID: 34751 RVA: 0x0023CA7D File Offset: 0x0023AC7D
	protected override void OnBeforeShow()
	{
		ActivitySubViewGeneralInfo commonInfoPanel = this.CommonInfoPanel;
		if (commonInfoPanel != null)
		{
			commonInfoPanel.SetBtnText("LongShanStage_Join01", Array.Empty<object>());
		}
		this.RefreshRedDot();
	}

	// Token: 0x060087C0 RID: 34752 RVA: 0x0023CAA0 File Offset: 0x0023ACA0
	private void OnClickDetail(ActivityBaseData data)
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.RoleGrowingMainView, this.ActivityData, null);
	}

	// Token: 0x060087C1 RID: 34753 RVA: 0x0023CAB8 File Offset: 0x0023ACB8
	protected override void OnRefreshView()
	{
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshActivityTab, this.ActivityData.Id);
		ActivitySubViewGeneralInfo commonInfoPanel = this.CommonInfoPanel;
		if (commonInfoPanel != null)
		{
			commonInfoPanel.RefreshView();
		}
		this.OnDataUpdate();
	}

	// Token: 0x060087C2 RID: 34754 RVA: 0x0023CAEC File Offset: 0x0023ACEC
	private void OnDataUpdate()
	{
		this.RefreshRedDot();
	}

	// Token: 0x060087C3 RID: 34755 RVA: 0x0023CAF4 File Offset: 0x0023ACF4
	private void RefreshRedDot()
	{
		bool functionRedDotVisible = this.ActivityData.CheckAnyStageRed();
		ActivitySubViewGeneralInfo commonInfoPanel = this.CommonInfoPanel;
		if (commonInfoPanel == null)
		{
			return;
		}
		commonInfoPanel.SetFunctionRedDotVisible(functionRedDotVisible);
	}

	// Token: 0x04003FE4 RID: 16356
	protected ActivityLongShanData ActivityData;

	// Token: 0x04003FE5 RID: 16357
	protected ActivitySubViewGeneralInfo CommonInfoPanel;

	// Token: 0x02007702 RID: 30466
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x04028FC7 RID: 167879
		public const int CommonActionInfo = 0;
	}
}
