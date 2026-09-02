using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020015F4 RID: 5620
[NullableContext(2)]
[Nullable(0)]
public class ActivityTurntableToggleGroupItem : GridProxyAbstract<int>
{
	// Token: 0x06009E6B RID: 40555 RVA: 0x002975D0 File Offset: 0x002957D0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06009E6C RID: 40556 RVA: 0x0029763C File Offset: 0x0029583C
	protected override UniTask OnBeforeStartAsync()
	{
		ActivityTurntableToggleGroupItem.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivityTurntableToggleGroupItem.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009E6D RID: 40557 RVA: 0x0029767F File Offset: 0x0029587F
	protected override void OnStart()
	{
		this.SetToggleDisable(false);
	}

	// Token: 0x06009E6E RID: 40558 RVA: 0x00297688 File Offset: 0x00295888
	public void SetToggleDisable(bool isDisable)
	{
		EToggleState? toggleState = this.GetToggleState();
		this.CurrentToggle = (isDisable ? this.ToggleDisable : this.ToggleNormal);
		if (toggleState != null)
		{
			this.CurrentToggle.SetToggleState(toggleState.Value == EToggleState.ETT_Checked, false);
		}
		UUIItem item = base.GetItem(0);
		if (item != null)
		{
			item.SetUIActive(!isDisable);
		}
		UUIItem item2 = base.GetItem(1);
		if (item2 == null)
		{
			return;
		}
		item2.SetUIActive(isDisable);
	}

	// Token: 0x06009E6F RID: 40559 RVA: 0x002976FA File Offset: 0x002958FA
	public override void Refresh(int roundId, bool isSelected, int gridIndex)
	{
		this.ToggleNormal.Refresh(roundId);
		this.ToggleDisable.Refresh(roundId);
	}

	// Token: 0x06009E70 RID: 40560 RVA: 0x00297714 File Offset: 0x00295914
	public EToggleState? GetToggleState()
	{
		ActivityTurntableToggleItem currentToggle = this.CurrentToggle;
		if (currentToggle == null)
		{
			return null;
		}
		return new EToggleState?(currentToggle.GetToggleState());
	}

	// Token: 0x06009E71 RID: 40561 RVA: 0x0029773F File Offset: 0x0029593F
	public void SetToggleState(bool bSelectOn, bool bFireEvent = false)
	{
		ActivityTurntableToggleItem currentToggle = this.CurrentToggle;
		if (currentToggle == null)
		{
			return;
		}
		currentToggle.SetToggleState(bSelectOn, bFireEvent);
	}

	// Token: 0x040048DE RID: 18654
	private ActivityTurntableToggleItem ToggleNormal;

	// Token: 0x040048DF RID: 18655
	private ActivityTurntableToggleItem ToggleDisable;

	// Token: 0x040048E0 RID: 18656
	private ActivityTurntableToggleItem CurrentToggle;

	// Token: 0x040048E1 RID: 18657
	public Func<int, bool> CanToggleExecuteChange;

	// Token: 0x040048E2 RID: 18658
	public Action<int, bool> ToggleCallBack;

	// Token: 0x020079B4 RID: 31156
	[NullableContext(0)]
	private class EToggleGroupComponents
	{
		// Token: 0x04029CB3 RID: 171187
		public const int ToggleNormal = 0;

		// Token: 0x04029CB4 RID: 171188
		public const int ToggleDisable = 1;
	}
}
