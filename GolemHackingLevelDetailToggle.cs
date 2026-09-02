using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Core.Common;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020010C6 RID: 4294
public class GolemHackingLevelDetailToggle : UiPanelBase
{
	// Token: 0x06006FC6 RID: 28614 RVA: 0x001D1D01 File Offset: 0x001CFF01
	public GolemHackingLevelDetailToggle(int levelId)
	{
		this.LevelId = levelId;
	}

	// Token: 0x06006FC7 RID: 28615 RVA: 0x001D1D10 File Offset: 0x001CFF10
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06006FC8 RID: 28616 RVA: 0x001D1D9A File Offset: 0x001CFF9A
	protected override void OnStart()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.OnStateChange.Add(new Action<EToggleState>(this.OnToggleStateChange));
	}

	// Token: 0x06006FC9 RID: 28617 RVA: 0x001D1DBE File Offset: 0x001CFFBE
	protected override void OnBeforeDestroy()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle != null)
		{
			extendToggle.CanExecuteChange.Unbind();
		}
		UUIExtendToggle extendToggle2 = base.GetExtendToggle(0);
		if (extendToggle2 == null)
		{
			return;
		}
		extendToggle2.OnStateChange.Clear();
	}

	// Token: 0x06006FCA RID: 28618 RVA: 0x001D1DED File Offset: 0x001CFFED
	public void SetSelected(bool selected)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleState(selected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, true, false, false);
	}

	// Token: 0x06006FCB RID: 28619 RVA: 0x001D1E0C File Offset: 0x001D000C
	public void SetFocusGamepad()
	{
		UUIItem toggle = base.GetExtendToggle(0).RootUIComp.Get();
		if (Singleton<Info>.Instance.IsInGamepad())
		{
			TimerSystem.Instance.Next(delegate(float _)
			{
				ControllerBase<UiNavigationNewController>.Instance.SetNavigationFocusForView(toggle, true, false, false);
			}, null, null);
		}
	}

	// Token: 0x06006FCC RID: 28620 RVA: 0x001D1E60 File Offset: 0x001D0060
	public virtual bool RefreshState(bool needAnim = false)
	{
		GolemHackingActivityData activityData = ControllerBase<GolemHackingController>.Instance.GetActivityData();
		UUIItem item = base.GetItem(2);
		if (item != null)
		{
			item.SetUIActive(activityData.CheckLevelRedDot(this.LevelId));
		}
		bool flag = activityData.GetLevelInfo(this.LevelId).State == GolemCrackState.GolemCrackFinished;
		UUIItem item2 = base.GetItem(1);
		if (item2 != null)
		{
			item2.SetUIActive(flag);
		}
		return flag;
	}

	// Token: 0x06006FCD RID: 28621 RVA: 0x001D1EBF File Offset: 0x001D00BF
	private void OnToggleStateChange(EToggleState state)
	{
		if (state != EToggleState.ETT_Checked)
		{
			return;
		}
		Action<int, bool> onClickedCallback = this.OnClickedCallback;
		if (onClickedCallback == null)
		{
			return;
		}
		onClickedCallback(this.LevelId, this.IsHard);
	}

	// Token: 0x040035CA RID: 13770
	[Nullable(2)]
	public Action<int, bool> OnClickedCallback;

	// Token: 0x040035CB RID: 13771
	protected bool IsHard;

	// Token: 0x040035CC RID: 13772
	public int LevelId;
}
