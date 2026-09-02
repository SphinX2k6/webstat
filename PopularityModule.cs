using System;
using System.Collections.Generic;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200140B RID: 5131
public class PopularityModule : UiPanelBase
{
	// Token: 0x06008E30 RID: 36400 RVA: 0x00255A88 File Offset: 0x00253C88
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUISprite))
		};
	}

	// Token: 0x06008E31 RID: 36401 RVA: 0x00255AE2 File Offset: 0x00253CE2
	protected override void OnBeforeShow()
	{
		this.RefreshPopularity();
	}

	// Token: 0x06008E32 RID: 36402 RVA: 0x00255AEC File Offset: 0x00253CEC
	public void RefreshPopularity()
	{
		Popularity currentPopularityConfig = ModelBase<MoonChasingBusinessModel>.Instance.GetCurrentPopularityConfig();
		int popularityValue = ModelBase<MoonChasingModel>.Instance.GetPopularityValue();
		UUIText text = base.GetText(1);
		if (text != null)
		{
			text.SetText("<color=#ffd52b>" + popularityValue.ToString() + "</color>/" + currentPopularityConfig.PopularityValue.ToString(), true);
		}
		base.GetSprite(2).SetFillAmount((float)(popularityValue / currentPopularityConfig.PopularityValue));
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), currentPopularityConfig.PopularityRating, Array.Empty<object>());
	}

	// Token: 0x020077FD RID: 30717
	private static class EComponentDefine
	{
		// Token: 0x04029478 RID: 169080
		public const int RatingText = 0;

		// Token: 0x04029479 RID: 169081
		public const int ValueText = 1;

		// Token: 0x0402947A RID: 169082
		public const int Progress = 2;
	}
}
