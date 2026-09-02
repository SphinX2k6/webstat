using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200199B RID: 6555
[NullableContext(1)]
[Nullable(0)]
public class TipsBaseSubComponent : UiPanelBase
{
	// Token: 0x0600BC3E RID: 48190 RVA: 0x0031F755 File Offset: 0x0031D955
	public TipsBaseSubComponent(UUIItem rootUiItem)
	{
	}

	// Token: 0x0600BC3F RID: 48191 RVA: 0x0031F768 File Offset: 0x0031D968
	protected override void OnBeforeShowImplement()
	{
		foreach (Action action in this.OperationMap.Values)
		{
			action();
		}
		this.OperationMap.Clear();
	}

	// Token: 0x0600BC40 RID: 48192 RVA: 0x0031F7C8 File Offset: 0x0031D9C8
	protected override void OnBeforeDestroy()
	{
		this.OperationMap.Clear();
	}

	// Token: 0x0600BC41 RID: 48193 RVA: 0x0031F7D5 File Offset: 0x0031D9D5
	public virtual void Refresh(ItemTipsData data)
	{
	}

	// Token: 0x0600BC42 RID: 48194 RVA: 0x0031F7D8 File Offset: 0x0031D9D8
	public void SetVisible(bool isShow)
	{
		Action action = delegate()
		{
			this.SetActive(isShow);
		};
		if (base.InAsyncLoading())
		{
			this.OperationMap["SetVisible"] = action;
			return;
		}
		action();
	}

	// Token: 0x0600BC43 RID: 48195 RVA: 0x0031F824 File Offset: 0x0031DA24
	public virtual void SetLockButtonShow(bool isShow)
	{
	}

	// Token: 0x0600BC44 RID: 48196 RVA: 0x0031F826 File Offset: 0x0031DA26
	public virtual void SetPanelNumVisible(bool isShow)
	{
	}

	// Token: 0x0400591E RID: 22814
	protected readonly Dictionary<string, Action> OperationMap = new Dictionary<string, Action>();
}
