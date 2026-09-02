using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002715 RID: 10005
[NullableContext(1)]
[Nullable(0)]
public class RacingBetsButtonItem : UiPanelBase
{
	// Token: 0x06013BC6 RID: 80838 RVA: 0x0057E3BC File Offset: 0x0057C5BC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.ButtonClick))
		};
	}

	// Token: 0x06013BC7 RID: 80839 RVA: 0x0057E423 File Offset: 0x0057C623
	protected override void OnBeforeDestroy()
	{
		this.ButtonFunction = null;
		this.ExtraButtonFunctionSet.Clear();
		this.UnBindGivenUid(this.RedDotUid);
	}

	// Token: 0x06013BC8 RID: 80840 RVA: 0x0057E444 File Offset: 0x0057C644
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		UUIButtonComponent button = base.GetButton(0);
		UUIItem uuiitem = (button != null) ? button.RootUIComp.Get() : null;
		if (uuiitem == null)
		{
			return null;
		}
		return new UUIItem[]
		{
			uuiitem,
			uuiitem
		};
	}

	// Token: 0x06013BC9 RID: 80841 RVA: 0x0057E480 File Offset: 0x0057C680
	private void ButtonClick()
	{
		Action buttonFunction = this.ButtonFunction;
		if (buttonFunction != null)
		{
			buttonFunction();
		}
		foreach (Action action in this.ExtraButtonFunctionSet)
		{
			action();
		}
	}

	// Token: 0x06013BCA RID: 80842 RVA: 0x0057E4E4 File Offset: 0x0057C6E4
	public void SetButtonAllowEventBubbleUp(bool value)
	{
		UUIButtonComponent button = base.GetButton(0);
		if (button != null)
		{
			button.AllowEventBubbleUp = value;
		}
	}

	// Token: 0x06013BCB RID: 80843 RVA: 0x0057E503 File Offset: 0x0057C703
	public void SetEnableClick(bool state)
	{
		UUIButtonComponent button = base.GetButton(0);
		if (button == null)
		{
			return;
		}
		button.SetSelfInteractive(state);
	}

	// Token: 0x06013BCC RID: 80844 RVA: 0x0057E517 File Offset: 0x0057C717
	public void SetFunction(Action buttonFunction)
	{
		this.ButtonFunction = buttonFunction;
	}

	// Token: 0x06013BCD RID: 80845 RVA: 0x0057E520 File Offset: 0x0057C720
	public void SetExtraFunction(Action buttonFunction)
	{
		this.ExtraButtonFunctionSet.Add(buttonFunction);
	}

	// Token: 0x06013BCE RID: 80846 RVA: 0x0057E52F File Offset: 0x0057C72F
	public void DeleteExtraFunction(Action buttonFunction)
	{
		this.ExtraButtonFunctionSet.Remove(buttonFunction);
	}

	// Token: 0x06013BCF RID: 80847 RVA: 0x0057E53E File Offset: 0x0057C73E
	public void SetRedDotVisible(bool bVisible)
	{
		UUIItem item = base.GetItem(1);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(bVisible);
	}

	// Token: 0x06013BD0 RID: 80848 RVA: 0x0057E554 File Offset: 0x0057C754
	public void BindRedDot(ERedDotName redDotName, int uId = 0)
	{
		UUIItem item = base.GetItem(1);
		if (item == null)
		{
			return;
		}
		this.RedDotName = new ERedDotName?(redDotName);
		this.RedDotUid = uId;
		if (this.RedDotName != null)
		{
			ControllerBase<RedDotController>.Instance.BindRedDot(this.RedDotName.Value, item, null, uId);
		}
	}

	// Token: 0x06013BD1 RID: 80849 RVA: 0x0057E5A5 File Offset: 0x0057C7A5
	public void UnBindGivenUid(int uId)
	{
		if (this.RedDotName != null)
		{
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(this.RedDotName.Value, base.GetItem(1), uId);
			this.RedDotName = null;
			this.RedDotUid = 0;
		}
	}

	// Token: 0x06013BD2 RID: 80850 RVA: 0x0057E5E4 File Offset: 0x0057C7E4
	public void UnBindRedDot()
	{
		if (this.RedDotName != null)
		{
			ControllerBase<RedDotController>.Instance.UnBindRedDot(this.RedDotName.Value);
			this.RedDotName = null;
			this.RedDotUid = 0;
		}
	}

	// Token: 0x040099BD RID: 39357
	private ERedDotName? RedDotName;

	// Token: 0x040099BE RID: 39358
	private int RedDotUid;

	// Token: 0x040099BF RID: 39359
	private readonly HashSet<Action> ExtraButtonFunctionSet = new HashSet<Action>();

	// Token: 0x040099C0 RID: 39360
	[Nullable(2)]
	private Action ButtonFunction;

	// Token: 0x02008AB5 RID: 35509
	[NullableContext(0)]
	private enum EButtonItemDefine
	{
		// Token: 0x0402EC57 RID: 191575
		Button,
		// Token: 0x0402EC58 RID: 191576
		RedDot
	}
}
