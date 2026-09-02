using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200254B RID: 9547
[NullableContext(1)]
[Nullable(0)]
public class VisionTabComponent : UiPanelBase
{
	// Token: 0x06012944 RID: 76100 RVA: 0x0051E3B7 File Offset: 0x0051C5B7
	public VisionTabComponent(UUIItem actor)
	{
		base.CreateThenShowByActor(actor.GetOwner(), null);
	}

	// Token: 0x06012945 RID: 76101 RVA: 0x0051E3CC File Offset: 0x0051C5CC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIExtendToggle))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleOne)),
			new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.OnToggleTwo))
		};
	}

	// Token: 0x06012946 RID: 76102 RVA: 0x0051E44B File Offset: 0x0051C64B
	private void OnToggleOne(EToggleState toggleState)
	{
		Action onClickToggleOne = this.OnClickToggleOne;
		if (onClickToggleOne == null)
		{
			return;
		}
		onClickToggleOne();
	}

	// Token: 0x06012947 RID: 76103 RVA: 0x0051E45D File Offset: 0x0051C65D
	private void OnToggleTwo(EToggleState toggleState)
	{
		Action onClickToggleTwo = this.OnClickToggleTwo;
		if (onClickToggleTwo == null)
		{
			return;
		}
		onClickToggleTwo();
	}

	// Token: 0x06012948 RID: 76104 RVA: 0x0051E46F File Offset: 0x0051C66F
	public void SetToggleOneButtonClick(Action call)
	{
		this.OnClickToggleOne = call;
	}

	// Token: 0x06012949 RID: 76105 RVA: 0x0051E478 File Offset: 0x0051C678
	public void SetToggleTwoButtonClick(Action call)
	{
		this.OnClickToggleTwo = call;
	}

	// Token: 0x040090C2 RID: 37058
	[Nullable(2)]
	private Action OnClickToggleOne;

	// Token: 0x040090C3 RID: 37059
	[Nullable(2)]
	private Action OnClickToggleTwo;

	// Token: 0x02008873 RID: 34931
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402E172 RID: 188786
		ToggleOne,
		// Token: 0x0402E173 RID: 188787
		ToggleTwo
	}
}
