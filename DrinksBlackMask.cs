using System;
using System.Collections.Generic;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001013 RID: 4115
public class DrinksBlackMask : UiPanelBase
{
	// Token: 0x06006B09 RID: 27401 RVA: 0x001BFA50 File Offset: 0x001BDC50
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText))
		};
	}

	// Token: 0x06006B0A RID: 27402 RVA: 0x001BFA73 File Offset: 0x001BDC73
	protected override void OnStart()
	{
		UUIText text = base.GetText(0);
		if (text == null)
		{
			return;
		}
		text.SetUIActive(false);
	}

	// Token: 0x06006B0B RID: 27403 RVA: 0x001BFA88 File Offset: 0x001BDC88
	public int ShowBackMask(EDrinksPlayStep curStep)
	{
		DrinksStepConfig? stepConfig = ConfigBase<DrinksConfig>.Instance.GetStepConfig(curStep);
		base.SetUiActive(true);
		Singleton<AudioSystem>.Instance.PostEvent(stepConfig.Value.PrevMaskEvent);
		TimerSystem.Instance.Delay(delegate(float _)
		{
			this.HideMask();
		}, (float)stepConfig.Value.PrevMaskEventDelay, null, null, true, 1f);
		return stepConfig.Value.PrevMaskEventDelay / 2;
	}

	// Token: 0x06006B0C RID: 27404 RVA: 0x001BFB02 File Offset: 0x001BDD02
	protected void HideMask()
	{
		base.SetUiActive(false);
	}

	// Token: 0x020073F4 RID: 29684
	private static class EDefine
	{
		// Token: 0x040281C6 RID: 164294
		public const int Txt = 0;
	}
}
