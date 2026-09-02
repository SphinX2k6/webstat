using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020029EC RID: 10732
public class ShipTowerWelcomeView : UiTickViewBase
{
	// Token: 0x17001BEC RID: 7148
	// (get) Token: 0x06015682 RID: 87682 RVA: 0x005EE5C5 File Offset: 0x005EC7C5
	[Nullable(2)]
	public new ShipTowerWelcomeViewParams OpenParam
	{
		[NullableContext(2)]
		get
		{
			return this.OpenParam as ShipTowerWelcomeViewParams;
		}
	}

	// Token: 0x06015683 RID: 87683 RVA: 0x005EE5D2 File Offset: 0x005EC7D2
	[NullableContext(1)]
	public ShipTowerWelcomeView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06015684 RID: 87684 RVA: 0x005EE5DB File Offset: 0x005EC7DB
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText))
		};
	}

	// Token: 0x06015685 RID: 87685 RVA: 0x005EE5FE File Offset: 0x005EC7FE
	protected override void OnStart()
	{
		UUIText text = base.GetText(0);
		if (text != null)
		{
			text.SetUIActive(false);
		}
		UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
		if (uiViewSequence == null)
		{
			return;
		}
		uiViewSequence.AddSequenceFinishEvent("Start", delegate(string _)
		{
			ShipTowerWelcomeViewParams openParam = this.OpenParam;
			if (openParam == null)
			{
				return;
			}
			CustomPromise<bool> promise = openParam.Promise;
			if (promise == null)
			{
				return;
			}
			promise.SetResult(true);
		}, false);
	}

	// Token: 0x02008D64 RID: 36196
	private static class EChildType
	{
		// Token: 0x0402F8B9 RID: 194745
		public const int TxtProgress = 0;
	}
}
