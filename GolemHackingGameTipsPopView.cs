using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020010C0 RID: 4288
public class GolemHackingGameTipsPopView : UiViewBase
{
	// Token: 0x06006F9B RID: 28571 RVA: 0x001D0A8F File Offset: 0x001CEC8F
	[NullableContext(1)]
	public GolemHackingGameTipsPopView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x06006F9C RID: 28572 RVA: 0x001D0AA4 File Offset: 0x001CECA4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
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
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickedClose));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06006F9D RID: 28573 RVA: 0x001D0B8C File Offset: 0x001CED8C
	protected override UniTask OnBeforeStartAsync()
	{
		GolemHackingGameTipsPopView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<GolemHackingGameTipsPopView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06006F9E RID: 28574 RVA: 0x001D0BD0 File Offset: 0x001CEDD0
	protected override void OnAfterShow()
	{
		int num = 2000 + this.GridList.Count * 250;
		for (int i = 0; i < this.GridList.Count; i++)
		{
			this.GridList[i].PlayAnim(i);
		}
		this.TimerHandle = TimerSystem.Instance.Forever(delegate(float _)
		{
			for (int j = 0; j < this.GridList.Count; j++)
			{
				this.GridList[j].PlayAnim(j);
			}
		}, (float)num, 1f, null, null, true);
	}

	// Token: 0x06006F9F RID: 28575 RVA: 0x001D0C43 File Offset: 0x001CEE43
	private void OnClickedClose()
	{
		if (this.TimerHandle != null)
		{
			if (this.TimerHandle.Valid())
			{
				TimerSystem.Instance.Remove(this.TimerHandle);
			}
			this.TimerHandle = null;
		}
		base.CloseMe(null);
	}

	// Token: 0x0400359F RID: 13727
	private const int INTERVAL_TIME = 250;

	// Token: 0x040035A0 RID: 13728
	[Nullable(1)]
	protected List<GolemHackingTipsPopGrid> GridList = new List<GolemHackingTipsPopGrid>();

	// Token: 0x040035A1 RID: 13729
	[Nullable(2)]
	protected TimerHandle TimerHandle;

	// Token: 0x0200744E RID: 29774
	private enum EDefine
	{
		// Token: 0x04028351 RID: 164689
		BtnMask,
		// Token: 0x04028352 RID: 164690
		TxtTipsDesc,
		// Token: 0x04028353 RID: 164691
		PanelCodeTips,
		// Token: 0x04028354 RID: 164692
		PanelHelpTipsItem
	}
}
