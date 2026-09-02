using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001540 RID: 5440
public class ActivityRegressCaptionNameListPanel : UiPanelBase
{
	// Token: 0x060098A4 RID: 39076 RVA: 0x0027FCA0 File Offset: 0x0027DEA0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
	}

	// Token: 0x060098A5 RID: 39077 RVA: 0x0027FCFC File Offset: 0x0027DEFC
	protected override UniTask OnBeforeStartAsync()
	{
		ActivityRegressCaptionNameListPanel.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivityRegressCaptionNameListPanel.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060098A6 RID: 39078 RVA: 0x0027FD3F File Offset: 0x0027DF3F
	protected override void OnAfterShow()
	{
	}

	// Token: 0x060098A7 RID: 39079 RVA: 0x0027FD41 File Offset: 0x0027DF41
	public void RefreshData(EActivityMainSubViewType subViewType)
	{
	}

	// Token: 0x0400469E RID: 18078
	[Nullable(2)]
	private ActivityRecallCaptionPanel CaptionPanel;

	// Token: 0x020078F9 RID: 30969
	private class EActivityRegressCaptionNameListPanelComponents
	{
		// Token: 0x04029946 RID: 170310
		public const int Caption = 0;

		// Token: 0x04029947 RID: 170311
		public const int SvList = 1;

		// Token: 0x04029948 RID: 170312
		public const int List = 2;
	}
}
