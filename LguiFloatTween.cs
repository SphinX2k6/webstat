using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002CD4 RID: 11476
public class LguiFloatTween : LguiTweenBase<float>
{
	// Token: 0x06017206 RID: 94726 RVA: 0x00668D4E File Offset: 0x00666F4E
	public LguiFloatTween()
	{
		this.Delegate = global::DelegateUtils.ToManualReleaseDelegate<FLTweenFloatSetterDynamic>(new Action<float>(base.PlayFillAmount));
	}

	// Token: 0x06017207 RID: 94727 RVA: 0x00668D6D File Offset: 0x00666F6D
	[NullableContext(2)]
	protected override ULTweener CreateTween(float start, float end, float time)
	{
		return ULTweenBPLibrary.FloatTo(GlobalData.World, this.Delegate, start, end, time, 0f, LTweenEase.OutCubic);
	}

	// Token: 0x06017208 RID: 94728 RVA: 0x00668D88 File Offset: 0x00666F88
	protected override void OnDestroy()
	{
		global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<float>(base.PlayFillAmount));
	}

	// Token: 0x0400B1F5 RID: 45557
	[Nullable(1)]
	protected FLTweenFloatSetterDynamic Delegate;
}
