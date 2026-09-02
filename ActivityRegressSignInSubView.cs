using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200154E RID: 5454
public class ActivityRegressSignInSubView : ActivityRegressMainSubViewBase
{
	// Token: 0x06009912 RID: 39186 RVA: 0x00281740 File Offset: 0x0027F940
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
	}

	// Token: 0x06009913 RID: 39187 RVA: 0x0028179C File Offset: 0x0027F99C
	protected override UniTask OnBeforeStartAsync()
	{
		ActivityRegressSignInSubView.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivityRegressSignInSubView.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009914 RID: 39188 RVA: 0x002817DF File Offset: 0x0027F9DF
	protected override void OnAfterShow()
	{
		ModelBase<ActivityRegressModel>.Instance.SetSignFirstShowTime();
	}

	// Token: 0x06009915 RID: 39189 RVA: 0x002817EC File Offset: 0x0027F9EC
	protected override void OnUpdate(int subTabIndex)
	{
		this.ActivityRecallSignPanel.RefreshView();
		ERegressGrade grade = ModelBase<ActivityRegressModel>.Instance.Grade;
		base.GetItem(1).SetUIActive(grade == ERegressGrade.Normal);
		base.GetItem(2).SetUIActive(grade == ERegressGrade.Hyper);
	}

	// Token: 0x040046C1 RID: 18113
	[Nullable(2)]
	private ActivityRegressSignPanel ActivityRecallSignPanel;

	// Token: 0x0200790D RID: 30989
	private class EComponents
	{
		// Token: 0x0402999B RID: 170395
		public const int SubPanel = 0;

		// Token: 0x0402999C RID: 170396
		public const int NormalBubble = 1;

		// Token: 0x0402999D RID: 170397
		public const int HyperBubble = 2;
	}
}
