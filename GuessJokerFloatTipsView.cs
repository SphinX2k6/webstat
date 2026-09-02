using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001120 RID: 4384
public class GuessJokerFloatTipsView : UiViewBase
{
	// Token: 0x0600723C RID: 29244 RVA: 0x001DD214 File Offset: 0x001DB414
	[NullableContext(1)]
	public GuessJokerFloatTipsView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600723D RID: 29245 RVA: 0x001DD21D File Offset: 0x001DB41D
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText))
		};
	}

	// Token: 0x0600723E RID: 29246 RVA: 0x001DD240 File Offset: 0x001DB440
	protected override void OnStart()
	{
		this.Data = (this.OpenParam as IGuessJokerTipsData);
		if (this.Data == null)
		{
			return;
		}
		if (this.Data.TextParam != null)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), this.Data.TextId, this.Data.TextParam);
		}
		else
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), this.Data.TextId, Array.Empty<object>());
		}
		UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
		if (uiViewSequence == null)
		{
			return;
		}
		uiViewSequence.AddSequenceFinishEvent("Start", delegate(string _)
		{
			TimerSystem.Instance.Delay(delegate(float _)
			{
				base.CloseMe(null);
			}, (float)GuessJokerUtils.GetJokerParamConfig(EGuessJokerParamKey.GuessJokerFloatTipTime.ToString()), null, null, true, 1f);
		}, false);
	}

	// Token: 0x04003723 RID: 14115
	[Nullable(2)]
	protected IGuessJokerTipsData Data;
}
