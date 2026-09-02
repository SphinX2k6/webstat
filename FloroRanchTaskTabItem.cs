using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001C6E RID: 7278
public class FloroRanchTaskTabItem : GridProxyAbstract<FloroRanchTaskTab>
{
	// Token: 0x0600D469 RID: 54377 RVA: 0x0038AF50 File Offset: 0x00389150
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.OnClickToggle));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D46A RID: 54378 RVA: 0x0038B018 File Offset: 0x00389218
	public override void Refresh(FloroRanchTaskTab floroRanchTaskTab, bool isSelected, int gridIndex)
	{
		this.FloroRanchTaskTabType = (EFloroRanchTaskTabType)floroRanchTaskTab.Id;
		string tabName = floroRanchTaskTab.TabName;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), tabName, Array.Empty<object>());
		this.RefreshRedDot();
	}

	// Token: 0x0600D46B RID: 54379 RVA: 0x0038B058 File Offset: 0x00389258
	public void RefreshRedDot()
	{
		bool uiactive = ModelBase<FloroRanchModel>.Instance.GetActivityData(EFloroRanchActivityDataType.Normal, true).IsTaskHasRedDotByTab(this.FloroRanchTaskTabType);
		UUIItem item = base.GetItem(2);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(uiactive);
	}

	// Token: 0x0600D46C RID: 54380 RVA: 0x0038B090 File Offset: 0x00389290
	public void SetToggleState(bool state)
	{
		EToggleState state2 = state ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		base.GetExtendToggle(1).SetToggleState(state2, false, false, false);
	}

	// Token: 0x0600D46D RID: 54381 RVA: 0x0038B0B6 File Offset: 0x003892B6
	public override void OnSelected(bool fireEvent)
	{
		this.SetToggleState(true);
	}

	// Token: 0x0600D46E RID: 54382 RVA: 0x0038B0BF File Offset: 0x003892BF
	public override void OnDeselected(bool fireEvent)
	{
		this.SetToggleState(false);
	}

	// Token: 0x0600D46F RID: 54383 RVA: 0x0038B0C8 File Offset: 0x003892C8
	private void OnClickToggle(EToggleState toggleState)
	{
		if (this.OnToggleCallBack != null)
		{
			this.OnToggleCallBack(base.GridIndex, this.FloroRanchTaskTabType);
		}
	}

	// Token: 0x0400650F RID: 25871
	private EFloroRanchTaskTabType FloroRanchTaskTabType = EFloroRanchTaskTabType.Dungeon;

	// Token: 0x04006510 RID: 25872
	[Nullable(2)]
	public Action<int, EFloroRanchTaskTabType> OnToggleCallBack;

	// Token: 0x02007F97 RID: 32663
	private class EComponents
	{
		// Token: 0x0402B706 RID: 177926
		public const int TextTabName = 0;

		// Token: 0x0402B707 RID: 177927
		public const int ToggleRoot = 1;

		// Token: 0x0402B708 RID: 177928
		public const int ItemRedDot = 2;
	}
}
