using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200156A RID: 5482
public class ActivityRegressDoubleDropSubView : ActivityRegressTaskSubViewBase
{
	// Token: 0x060099DA RID: 39386 RVA: 0x00284794 File Offset: 0x00282994
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>();
	}

	// Token: 0x060099DB RID: 39387 RVA: 0x002847E4 File Offset: 0x002829E4
	protected override UniTask OnBeforeStartAsync()
	{
		ActivityRegressDoubleDropSubView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivityRegressDoubleDropSubView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060099DC RID: 39388 RVA: 0x00284827 File Offset: 0x00282A27
	protected override void OnBeforeShow()
	{
		ModelBase<ActivityRegressModel>.Instance.MarkDoubleDropReminderShown();
		ModelBase<ActivityRegressModel>.Instance.ActivityData.MarkDoubleDropFirstRedDotShown();
	}

	// Token: 0x040046FF RID: 18175
	[Nullable(2)]
	private ActivityRegressDoubleDropChallengeItem DoubleDropChallengeItem1;

	// Token: 0x04004700 RID: 18176
	[Nullable(2)]
	private ActivityRegressDoubleDropChallengeItem DoubleDropChallengeItem2;

	// Token: 0x0200792E RID: 31022
	private class EComponents
	{
		// Token: 0x04029A39 RID: 170553
		public const int ChallengeItem1Root = 0;

		// Token: 0x04029A3A RID: 170554
		public const int ChallengeItem2Root = 1;
	}
}
