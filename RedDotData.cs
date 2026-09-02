using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x020032CA RID: 13002
[NullableContext(1)]
[Nullable(0)]
public class RedDotData : IStaticVariableResetter
{
	// Token: 0x0601B458 RID: 111704 RVA: 0x008309CC File Offset: 0x0082EBCC
	static RedDotData()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(RedDotData.CreateStaticDefaultValue), new Action(RedDotData.ResetStaticDefaultValue));
	}

	// Token: 0x17002534 RID: 9524
	// (get) Token: 0x0601B459 RID: 111705 RVA: 0x008309EB File Offset: 0x0082EBEB
	public bool State
	{
		get
		{
			return RedDotData.StateByGm && this.StateCountInternal > 0;
		}
	}

	// Token: 0x17002535 RID: 9525
	// (get) Token: 0x0601B45A RID: 111706 RVA: 0x008309FF File Offset: 0x0082EBFF
	// (set) Token: 0x0601B45B RID: 111707 RVA: 0x00830A07 File Offset: 0x0082EC07
	public int StateCount
	{
		get
		{
			return this.StateCountInternal;
		}
		set
		{
			this.StateCountInternal = ((value < 0) ? 0 : value);
		}
	}

	// Token: 0x0601B45C RID: 111708 RVA: 0x00830A17 File Offset: 0x0082EC17
	public static void CreateStaticDefaultValue()
	{
		RedDotData.StateByGm = true;
	}

	// Token: 0x0601B45D RID: 111709 RVA: 0x00830A1F File Offset: 0x0082EC1F
	public static void ResetStaticDefaultValue()
	{
		RedDotData.StateByGm = true;
	}

	// Token: 0x0601B45E RID: 111710 RVA: 0x00830A27 File Offset: 0x0082EC27
	public HashSet<UUIItem> GetUiItemSet()
	{
		return this.UiItemSet;
	}

	// Token: 0x0601B45F RID: 111711 RVA: 0x00830A2F File Offset: 0x0082EC2F
	public void ClearUiItem()
	{
		this.UiItemSet.Clear();
	}

	// Token: 0x0601B460 RID: 111712 RVA: 0x00830A3C File Offset: 0x0082EC3C
	public void SetUiItem(UUIItem uiItem)
	{
		this.UiItemSet.Add(uiItem);
	}

	// Token: 0x0601B461 RID: 111713 RVA: 0x00830A4B File Offset: 0x0082EC4B
	public void DeleteUiItem(UUIItem uiItem)
	{
		this.UiItemSet.Remove(uiItem);
	}

	// Token: 0x0601B462 RID: 111714 RVA: 0x00830A5C File Offset: 0x0082EC5C
	public bool TryChangeState(bool toState)
	{
		if (toState == this.State)
		{
			return false;
		}
		int num = toState ? 1 : -1;
		this.StateCount += num;
		this.UpdateRedDotUIActive();
		return true;
	}

	// Token: 0x0601B463 RID: 111715 RVA: 0x00830A91 File Offset: 0x0082EC91
	public void UpdateRedDotUIActive()
	{
		this.SetUIItemActive(this.State);
	}

	// Token: 0x0601B464 RID: 111716 RVA: 0x00830AA0 File Offset: 0x0082ECA0
	public void SetUIItemActive(bool value)
	{
		foreach (UUIItem uuiitem in this.UiItemSet)
		{
			if (uuiitem.IsValid())
			{
				uuiitem.SetUIActive(value);
			}
		}
	}

	// Token: 0x0601B465 RID: 111717 RVA: 0x00830AFC File Offset: 0x0082ECFC
	public bool OnChildrenStateChange(bool toState)
	{
		int num = toState ? 1 : -1;
		bool state = this.State;
		this.StateCount += num;
		if (state == this.State)
		{
			return false;
		}
		this.UpdateRedDotUIActive();
		return true;
	}

	// Token: 0x0400DE35 RID: 56885
	private int StateCountInternal;

	// Token: 0x0400DE36 RID: 56886
	public static bool StateByGm;

	// Token: 0x0400DE37 RID: 56887
	private readonly HashSet<UUIItem> UiItemSet = new HashSet<UUIItem>();
}
