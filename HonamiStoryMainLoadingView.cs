using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001F39 RID: 7993
public class HonamiStoryMainLoadingView : LoadingViewBase
{
	// Token: 0x0600EEFD RID: 61181 RVA: 0x004156EC File Offset: 0x004138EC
	[NullableContext(1)]
	public HonamiStoryMainLoadingView(UiViewInfo uiViewInfo) : base(uiViewInfo)
	{
	}

	// Token: 0x0600EEFE RID: 61182 RVA: 0x004156F8 File Offset: 0x004138F8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600EEFF RID: 61183 RVA: 0x00415784 File Offset: 0x00413984
	protected override void OnStart()
	{
		base.OnStart();
		UUIText text = base.GetText(2);
		if (text != null)
		{
			text.SetUIActive(false);
		}
		IHonamiStoryLoadingData curLoadingData = ModelBase<HonamiStoryModel>.Instance.GetCurLoadingData();
		if (curLoadingData == null)
		{
			return;
		}
		IHonamiStoryLoadingData honamiStoryLoadingData = curLoadingData;
		if (honamiStoryLoadingData.LoadingId != null)
		{
			int? loadingId = honamiStoryLoadingData.LoadingId;
			int num = 0;
			if (loadingId.GetValueOrDefault() > num & loadingId != null)
			{
				this.LoadingConfig = ConfigBase<HonamiStoryConfig>.Instance.GetLoadingPerformConfigById(honamiStoryLoadingData.LoadingId.Value);
			}
		}
		this.UpdateHonamiStoryLoading();
	}

	// Token: 0x0600EF00 RID: 61184 RVA: 0x0041580C File Offset: 0x00413A0C
	protected override void UpdateProgressRate(float rate)
	{
	}

	// Token: 0x0600EF01 RID: 61185 RVA: 0x0041580E File Offset: 0x00413A0E
	protected override void UpdateProgressValue(float value)
	{
		this.SetTextProgressValue(0, value, "");
	}

	// Token: 0x0600EF02 RID: 61186 RVA: 0x00415820 File Offset: 0x00413A20
	private void UpdateHonamiStoryLoading()
	{
		if (this.LoadingConfig == null)
		{
			return;
		}
		HonamiStoryLoadingPerform? loadingConfig = this.LoadingConfig;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), loadingConfig.Value.Title, Array.Empty<object>());
		ModelBase<HonamiStoryModel>.Instance.ClearCurLoadingData();
	}

	// Token: 0x0600EF03 RID: 61187 RVA: 0x00415871 File Offset: 0x00413A71
	protected override void OnLevelSequencePlayerBandStateChange(bool state)
	{
		base.PlaySequence("Start", null, false);
	}

	// Token: 0x040072F1 RID: 29425
	private HonamiStoryLoadingPerform? LoadingConfig;

	// Token: 0x020082AF RID: 33455
	private enum EHonamiStoryLoadingComponents
	{
		// Token: 0x0402C51B RID: 181531
		ProgressText,
		// Token: 0x0402C51C RID: 181532
		TitleText,
		// Token: 0x0402C51D RID: 181533
		DescText
	}
}
