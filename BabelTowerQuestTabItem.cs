using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001238 RID: 4664
public class BabelTowerQuestTabItem : GridProxyAbstract<int>
{
	// Token: 0x06007C38 RID: 31800 RVA: 0x0020A754 File Offset: 0x00208954
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06007C39 RID: 31801 RVA: 0x0020A81B File Offset: 0x00208A1B
	protected override void OnStart()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.BabelTowerRefreshQuestState, new Action(this.BabelTowerRefreshQuestState));
	}

	// Token: 0x06007C3A RID: 31802 RVA: 0x0020A839 File Offset: 0x00208A39
	protected override void OnBeforeDestroy()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.BabelTowerRefreshQuestState, new Action(this.BabelTowerRefreshQuestState));
	}

	// Token: 0x06007C3B RID: 31803 RVA: 0x0020A858 File Offset: 0x00208A58
	public override void Refresh(int data, bool isSelected, int gridIndex)
	{
		this.TabIndex = data;
		int num = 4 + data;
		BabelTowerData babelTowerData = ControllerBase<BabelTowerController>.Instance.GetBabelTowerData();
		base.GetItem(2).SetUIActive(babelTowerData.GetQuestTabRedDot(this.TabIndex));
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "BabelTowerTaskType_" + num.ToString(), Array.Empty<object>());
	}

	// Token: 0x06007C3C RID: 31804 RVA: 0x0020A8BA File Offset: 0x00208ABA
	private void OnClickToggle(EToggleState state)
	{
		Action<UUIExtendToggle, int> onClickToggleCallBack = this.OnClickToggleCallBack;
		if (onClickToggleCallBack == null)
		{
			return;
		}
		onClickToggleCallBack(base.GetExtendToggle(0), this.TabIndex);
	}

	// Token: 0x06007C3D RID: 31805 RVA: 0x0020A8D9 File Offset: 0x00208AD9
	public void SelectToggle()
	{
		base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_Checked, false, false, false);
		Action<UUIExtendToggle, int> onClickToggleCallBack = this.OnClickToggleCallBack;
		if (onClickToggleCallBack == null)
		{
			return;
		}
		onClickToggleCallBack(base.GetExtendToggle(0), this.TabIndex);
	}

	// Token: 0x06007C3E RID: 31806 RVA: 0x0020A90C File Offset: 0x00208B0C
	private void BabelTowerRefreshQuestState()
	{
		BabelTowerData babelTowerData = ControllerBase<BabelTowerController>.Instance.GetBabelTowerData();
		base.GetItem(2).SetUIActive(babelTowerData.GetQuestTabRedDot(this.TabIndex));
	}

	// Token: 0x04003B66 RID: 15206
	private int TabIndex;

	// Token: 0x04003B67 RID: 15207
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<UUIExtendToggle, int> OnClickToggleCallBack;

	// Token: 0x020075A0 RID: 30112
	private class EComponentDefine
	{
		// Token: 0x0402895B RID: 166235
		public const int Toggle = 0;

		// Token: 0x0402895C RID: 166236
		public const int TitleText = 1;

		// Token: 0x0402895D RID: 166237
		public const int RedDotItem = 2;
	}
}
