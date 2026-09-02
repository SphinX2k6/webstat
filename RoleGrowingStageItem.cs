using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200135E RID: 4958
public class RoleGrowingStageItem : UiPanelBase
{
	// Token: 0x060087DB RID: 34779 RVA: 0x0023D1FF File Offset: 0x0023B3FF
	public RoleGrowingStageItem(int StageId)
	{
		this.StageId = StageId;
	}

	// Token: 0x060087DC RID: 34780 RVA: 0x0023D210 File Offset: 0x0023B410
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
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
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x060087DD RID: 34781 RVA: 0x0023D320 File Offset: 0x0023B520
	protected override void OnStart()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		extendToggle.SetCanClickWhenDisable(true);
		extendToggle.CanExecuteChange.Bind(() => false);
		extendToggle.OnPointUpCallBack.Bind(new Action<EToggleState>(this.OnClickStageDetailInternal));
	}

	// Token: 0x060087DE RID: 34782 RVA: 0x0023D37C File Offset: 0x0023B57C
	[NullableContext(1)]
	public void Refresh(ActivityLongShanData actData)
	{
		object stageInfoById = actData.GetStageInfoById(this.StageId);
		LongShanStage value = ConfigLongShanStageById.GetConfig(this.StageId, true).Value;
		bool flag = stageInfoById == null;
		int progress = actData.GetProgress(this.StageId);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "LongShanStage_ProgressPercentage02", new <>z__ReadOnlySingleElementList<object>(progress.ToString()));
		base.GetItem(1).SetUIActive(progress == 100);
		EToggleState state = flag ? EToggleState.ETT_UnChecked : EToggleState.ETT_UnChecked;
		base.GetExtendToggle(0).SetToggleState(state, false, false, false);
		base.GetItem(5).SetUIActive(flag);
		base.GetItem(6).SetUIActive(!flag);
		if (flag)
		{
			string conditionGroupHintText = LevelGeneralCommons.GetConditionGroupHintText(value.OpenConditionId);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), conditionGroupHintText, Array.Empty<object>());
		}
		else
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), value.Title, Array.Empty<object>());
		}
		base.GetItem(4).SetUIActive(actData.CheckStageRed(this.StageId));
	}

	// Token: 0x060087DF RID: 34783 RVA: 0x0023D485 File Offset: 0x0023B685
	private void OnClickStageDetailInternal(EToggleState toggleState)
	{
		Action<int> onClickStageDetail = this.OnClickStageDetail;
		if (onClickStageDetail == null)
		{
			return;
		}
		onClickStageDetail(this.StageId);
	}

	// Token: 0x04003FEE RID: 16366
	[Nullable(2)]
	public Action<int> OnClickStageDetail;

	// Token: 0x04003FEF RID: 16367
	protected readonly int StageId;

	// Token: 0x02007709 RID: 30473
	private class EComponents
	{
		// Token: 0x04028FE3 RID: 167907
		public const int Toggle = 0;

		// Token: 0x04028FE4 RID: 167908
		public const int FinishItem = 1;

		// Token: 0x04028FE5 RID: 167909
		public const int TxtProgress = 2;

		// Token: 0x04028FE6 RID: 167910
		public const int TxtName = 3;

		// Token: 0x04028FE7 RID: 167911
		public const int RedDot = 4;

		// Token: 0x04028FE8 RID: 167912
		public const int PanelLock = 5;

		// Token: 0x04028FE9 RID: 167913
		public const int PanelUnlock = 6;
	}
}
