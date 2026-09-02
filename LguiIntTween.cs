using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002CD5 RID: 11477
public class LguiIntTween : LguiTweenBase<int>
{
	// Token: 0x06017209 RID: 94729 RVA: 0x00668D9B File Offset: 0x00666F9B
	public LguiIntTween()
	{
		this.Delegate = global::DelegateUtils.ToManualReleaseDelegate<FLTweenIntSetterDynamic>(new Action<int>(base.PlayFillAmount));
	}

	// Token: 0x0601720A RID: 94730 RVA: 0x00668DBA File Offset: 0x00666FBA
	[NullableContext(2)]
	protected override ULTweener CreateTween(int start, int end, float time)
	{
		return ULTweenBPLibrary.IntTo(GlobalData.World, this.Delegate, start, end, time, 0f, LTweenEase.OutCubic);
	}

	// Token: 0x0601720B RID: 94731 RVA: 0x00668DD5 File Offset: 0x00666FD5
	protected override void OnDestroy()
	{
		global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<int>(base.PlayFillAmount));
	}

	// Token: 0x0400B1F6 RID: 45558
	[Nullable(1)]
	protected FLTweenIntSetterDynamic Delegate;
}
