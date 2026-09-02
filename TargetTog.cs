using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001F2D RID: 7981
[NullableContext(1)]
[Nullable(0)]
public class TargetTog : UiPanelBase
{
	// Token: 0x0600EEB7 RID: 61111 RVA: 0x00413DE0 File Offset: 0x00411FE0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnTogClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600EEB8 RID: 61112 RVA: 0x00413EC8 File Offset: 0x004120C8
	protected override void OnStart()
	{
		base.GetExtendToggle(0).CanExecuteChange.Bind(() => this.CanToggleChange == null || this.Target == null || this.CanToggleChange(this.Target.Value));
	}

	// Token: 0x0600EEB9 RID: 61113 RVA: 0x00413EE7 File Offset: 0x004120E7
	public void RefreshTog(ETarget target, bool isUnLock)
	{
		this.Target = new ETarget?(target);
		this.IsUnLock = isUnLock;
		base.GetItem(1).SetUIActive(this.IsUnLock);
		base.GetItem(2).SetUIActive(!this.IsUnLock);
	}

	// Token: 0x0600EEBA RID: 61114 RVA: 0x00413F23 File Offset: 0x00412123
	private void OnTogClick(EToggleState toggleState)
	{
		Action onClickToggleBack = this.OnClickToggleBack;
		if (onClickToggleBack == null)
		{
			return;
		}
		onClickToggleBack();
	}

	// Token: 0x17001236 RID: 4662
	// (get) Token: 0x0600EEBB RID: 61115 RVA: 0x00413F35 File Offset: 0x00412135
	public UUIExtendToggle GetTog
	{
		get
		{
			return base.GetExtendToggle(0);
		}
	}

	// Token: 0x0600EEBC RID: 61116 RVA: 0x00413F3E File Offset: 0x0041213E
	public void SetRedDotShow(bool isShow)
	{
		base.GetItem(3).SetUIActive(isShow);
	}

	// Token: 0x040072C6 RID: 29382
	private bool IsUnLock;

	// Token: 0x040072C7 RID: 29383
	public ETarget? Target;

	// Token: 0x040072C8 RID: 29384
	[Nullable(2)]
	public Action OnClickToggleBack;

	// Token: 0x040072C9 RID: 29385
	[Nullable(2)]
	public Func<ETarget, bool> CanToggleChange;
}
