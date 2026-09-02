using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020010CA RID: 4298
public class GolemHackingResultPop : UiViewBase
{
	// Token: 0x06006FE2 RID: 28642 RVA: 0x001D2501 File Offset: 0x001D0701
	[NullableContext(1)]
	public GolemHackingResultPop(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x06006FE3 RID: 28643 RVA: 0x001D250C File Offset: 0x001D070C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06006FE4 RID: 28644 RVA: 0x001D2554 File Offset: 0x001D0754
	protected override void OnStart()
	{
		GolemHackingResultInfo golemHackingResultInfo = (GolemHackingResultInfo)this.OpenParam;
		this.CloseCallback = golemHackingResultInfo.CloseCallback;
		this.IsSuccess = golemHackingResultInfo.IsSuccess;
		string startSequenceName = this.IsSuccess ? "Success" : "Fail";
		this.UiViewSequence.StartSequenceName = startSequenceName;
		UUIText text = base.GetText(0);
		if (text == null)
		{
			return;
		}
		text.ShowTextNew(this.IsSuccess ? "IntrusionProtocol_SucceedTips" : "IntrusionProtocol_FailTips");
	}

	// Token: 0x06006FE5 RID: 28645 RVA: 0x001D25CB File Offset: 0x001D07CB
	protected override void OnFinishShow()
	{
		base.CloseMe(delegate(bool _)
		{
			Action closeCallback = this.CloseCallback;
			if (closeCallback == null)
			{
				return;
			}
			closeCallback();
		});
	}

	// Token: 0x040035D7 RID: 13783
	[Nullable(2)]
	protected Action CloseCallback;

	// Token: 0x040035D8 RID: 13784
	protected bool IsSuccess;

	// Token: 0x02007459 RID: 29785
	private enum EDefine
	{
		// Token: 0x04028381 RID: 164737
		Txt
	}
}
