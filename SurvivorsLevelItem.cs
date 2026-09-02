using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002B22 RID: 11042
[NullableContext(2)]
[Nullable(0)]
public class SurvivorsLevelItem : UiPanelBase
{
	// Token: 0x060160C8 RID: 90312 RVA: 0x0061E664 File Offset: 0x0061C864
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnButtonClicked))
		};
	}

	// Token: 0x060160C9 RID: 90313 RVA: 0x0061E6F7 File Offset: 0x0061C8F7
	private void OnButtonClicked()
	{
		Action<int> onButtonClickedCallback = this.OnButtonClickedCallback;
		if (onButtonClickedCallback == null)
		{
			return;
		}
		onButtonClickedCallback(this.LevelId);
	}

	// Token: 0x060160CA RID: 90314 RVA: 0x0061E70F File Offset: 0x0061C90F
	public void SetButtonInteractive(bool bEnable)
	{
		base.GetButton(0).SetSelfInteractive(bEnable);
	}

	// Token: 0x060160CB RID: 90315 RVA: 0x0061E71E File Offset: 0x0061C91E
	public void Refresh(int levelId, bool isEndless)
	{
		this.LevelId = levelId;
		base.GetItem(1).SetUIActive(!isEndless);
		base.GetItem(2).SetUIActive(isEndless);
	}

	// Token: 0x060160CC RID: 90316 RVA: 0x0061E744 File Offset: 0x0061C944
	public UUIItem GetBottomPosItem()
	{
		return base.GetItem(3);
	}

	// Token: 0x0400A99C RID: 43420
	protected int LevelId;

	// Token: 0x0400A99D RID: 43421
	public Action<int> OnButtonClickedCallback;
}
