using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020014F0 RID: 5360
public class ActivityRegressDoubleDropView : ActivityRegressMainSubViewBase
{
	// Token: 0x060095F9 RID: 38393 RVA: 0x002724C5 File Offset: 0x002706C5
	protected override void OnStart()
	{
		base.OnStart();
	}

	// Token: 0x060095FA RID: 38394 RVA: 0x002724CD File Offset: 0x002706CD
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
	}

	// Token: 0x060095FB RID: 38395 RVA: 0x00272508 File Offset: 0x00270708
	protected override UniTask OnBeforeStartAsync()
	{
		ActivityRegressDoubleDropView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivityRegressDoubleDropView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060095FC RID: 38396 RVA: 0x0027254B File Offset: 0x0027074B
	protected override void OnBeforeShow()
	{
		base.OnBeforeShow();
		ModelBase<ActivityRegressModel>.Instance.MarkDoubleDropReminderShown();
		ModelBase<ActivityRegressModel>.Instance.ActivityData.MarkDoubleDropFirstRedDotShown();
	}

	// Token: 0x0400456F RID: 17775
	[Nullable(2)]
	private ActivityRegressDoubleDropChallengeItem DoubleDropChallengeItem1;

	// Token: 0x04004570 RID: 17776
	[Nullable(2)]
	private ActivityRegressDoubleDropChallengeItem DoubleDropChallengeItem2;

	// Token: 0x020078A9 RID: 30889
	private class EComponents
	{
		// Token: 0x040297B2 RID: 169906
		public const int ChallengeItem1Root = 0;

		// Token: 0x040297B3 RID: 169907
		public const int ChallengeItem2Root = 1;
	}
}
