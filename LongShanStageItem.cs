using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001357 RID: 4951
public class LongShanStageItem : UiPanelBase
{
	// Token: 0x06008793 RID: 34707 RVA: 0x0023BA18 File Offset: 0x00239C18
	protected unsafe override void OnRegisterComponent()
	{
		int num = 9;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickStageDetailInternal));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06008794 RID: 34708 RVA: 0x0023BBA6 File Offset: 0x00239DA6
	[NullableContext(1)]
	public LongShanStageItem(ActivityLongShanData activityData, int id)
	{
		this.ActivityData = activityData;
		this.StageId = id;
	}

	// Token: 0x06008795 RID: 34709 RVA: 0x0023BBBC File Offset: 0x00239DBC
	protected override void OnStart()
	{
		this.RefreshState();
	}

	// Token: 0x06008796 RID: 34710 RVA: 0x0023BBC4 File Offset: 0x00239DC4
	public void RefreshState()
	{
		LongShanStage value = ConfigLongShanStageById.GetConfig(this.StageId, true).Value;
		LongShanStageInfo stageInfoById = this.ActivityData.GetStageInfoById(this.StageId);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), value.Title, Array.Empty<object>());
		bool flag = stageInfoById == null;
		base.GetItem(5).SetUIActive(flag);
		base.GetItem(8).SetUIActive(!flag);
		int progress = this.ActivityData.GetProgress(this.StageId);
		base.GetItem(4).SetUIActive(progress == 100);
		if (stageInfoById == null)
		{
			string conditionGroupHintText = LevelGeneralCommons.GetConditionGroupHintText(value.OpenConditionId);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), conditionGroupHintText, Array.Empty<object>());
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "LongShanStage_ProgressPercentage02", new <>z__ReadOnlySingleElementList<object>(progress));
		base.GetItem(7).SetUIActive(this.ActivityData.CheckStageRed(this.StageId));
	}

	// Token: 0x06008797 RID: 34711 RVA: 0x0023BCBF File Offset: 0x00239EBF
	private void OnClickStageDetailInternal()
	{
		Action<int> onClickStageDetail = this.OnClickStageDetail;
		if (onClickStageDetail == null)
		{
			return;
		}
		onClickStageDetail(this.StageId);
	}

	// Token: 0x06008798 RID: 34712 RVA: 0x0023BCD7 File Offset: 0x00239ED7
	public void SetButtonInteractive(bool value)
	{
		UUIButtonComponent button = base.GetButton(0);
		if (button == null)
		{
			return;
		}
		button.SetSelfInteractive(value);
	}

	// Token: 0x06008799 RID: 34713 RVA: 0x0023BCEB File Offset: 0x00239EEB
	[NullableContext(1)]
	public UUIItem GetLongShanButton()
	{
		return base.GetButton(0).RootUIComp;
	}

	// Token: 0x04003FD7 RID: 16343
	private int StageId;

	// Token: 0x04003FD8 RID: 16344
	[Nullable(2)]
	private ActivityLongShanData ActivityData;

	// Token: 0x04003FD9 RID: 16345
	[Nullable(2)]
	public Action<int> OnClickStageDetail;

	// Token: 0x020076FD RID: 30461
	private class EComponents
	{
		// Token: 0x04028FA4 RID: 167844
		public const int BtnInfo = 0;

		// Token: 0x04028FA5 RID: 167845
		public const int ItemState = 1;

		// Token: 0x04028FA6 RID: 167846
		public const int TxtName = 2;

		// Token: 0x04028FA7 RID: 167847
		public const int TxtProgress = 3;

		// Token: 0x04028FA8 RID: 167848
		public const int LabelFinish = 4;

		// Token: 0x04028FA9 RID: 167849
		public const int LockItem = 5;

		// Token: 0x04028FAA RID: 167850
		public const int TxtLockTip = 6;

		// Token: 0x04028FAB RID: 167851
		public const int RedDot = 7;

		// Token: 0x04028FAC RID: 167852
		public const int MaskItem = 8;
	}
}
