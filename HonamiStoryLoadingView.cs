using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001F38 RID: 7992
[NullableContext(1)]
[Nullable(0)]
public class HonamiStoryLoadingView : LoadingViewBase
{
	// Token: 0x0600EEF4 RID: 61172 RVA: 0x00415215 File Offset: 0x00413415
	public HonamiStoryLoadingView(UiViewInfo uiViewInfo) : base(uiViewInfo)
	{
	}

	// Token: 0x0600EEF5 RID: 61173 RVA: 0x00415220 File Offset: 0x00413420
	protected unsafe override void OnRegisterComponent()
	{
		int num = 8;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600EEF6 RID: 61174 RVA: 0x00415350 File Offset: 0x00413550
	protected override void OnStart()
	{
		base.OnStart();
		IHonamiStoryLoadingData curLoadingData = ModelBase<HonamiStoryModel>.Instance.GetCurLoadingData();
		if (curLoadingData == null)
		{
			return;
		}
		IHonamiStoryLoadingData honamiStoryLoadingData = curLoadingData;
		if (honamiStoryLoadingData.LoadingId != null)
		{
			int? num = honamiStoryLoadingData.LoadingId;
			int num2 = 0;
			if (num.GetValueOrDefault() > num2 & num != null)
			{
				this.LoadingConfig = ConfigBase<HonamiStoryConfig>.Instance.GetLoadingPerformConfigById(honamiStoryLoadingData.LoadingId.Value);
				goto IL_13B;
			}
		}
		if (honamiStoryLoadingData.Timing != null)
		{
			int? num = honamiStoryLoadingData.Timing;
			int num2 = 0;
			if (num.GetValueOrDefault() > num2 & num != null)
			{
				if (honamiStoryLoadingData.BtId != null)
				{
					num = honamiStoryLoadingData.BtId;
					num2 = 0;
					if (num.GetValueOrDefault() > num2 & num != null)
					{
						this.LoadingConfig = ConfigBase<HonamiStoryConfig>.Instance.GetLoadingPerformConfigByBtAndTime(honamiStoryLoadingData.BtId.Value, honamiStoryLoadingData.Timing.Value);
						goto IL_13B;
					}
				}
				IReadOnlyList<HonamiStoryLoadingPerform> loadingPerformConfigListByTiming = ConfigBase<HonamiStoryConfig>.Instance.GetLoadingPerformConfigListByTiming(honamiStoryLoadingData.Timing.Value);
				int count = loadingPerformConfigListByTiming.Count;
				int index = new Random().Next(0, count);
				this.LoadingConfig = new HonamiStoryLoadingPerform?(loadingPerformConfigListByTiming[index]);
			}
		}
		IL_13B:
		UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
		if (uiViewSequence != null)
		{
			uiViewSequence.AddSequenceStartEvent("Start", new Action<string>(this.OnStartSequenceEvent));
		}
		UiBehaviorLevelSequence uiViewSequence2 = this.UiViewSequence;
		if (uiViewSequence2 != null)
		{
			uiViewSequence2.AddSequenceStartEvent("Close", new Action<string>(this.OnCloseSequenceEvent));
		}
		this.UpdateHonamiStoryLoading();
	}

	// Token: 0x0600EEF7 RID: 61175 RVA: 0x004154E2 File Offset: 0x004136E2
	protected override void UpdateProgressRate(float rate)
	{
	}

	// Token: 0x0600EEF8 RID: 61176 RVA: 0x004154E4 File Offset: 0x004136E4
	protected override void UpdateProgressValue(float value)
	{
		this.SetTextProgressValue(1, value, "");
	}

	// Token: 0x0600EEF9 RID: 61177 RVA: 0x004154F4 File Offset: 0x004136F4
	private void UpdateHonamiStoryLoading()
	{
		if (this.LoadingConfig == null)
		{
			return;
		}
		HonamiStoryLoadingPerform? loadingConfig = this.LoadingConfig;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), loadingConfig.Value.Title, Array.Empty<object>());
		bool flag = !StringUtils.IsBlank(loadingConfig.Value.Tips);
		if (flag)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), loadingConfig.Value.Tips, Array.Empty<object>());
		}
		base.GetText(3).SetUIActive(flag);
		base.GetItem(4).SetUIActive(false);
		base.GetItem(5).SetUIActive(false);
		base.GetItem(6).SetUIActive(false);
		base.GetItem(7).SetUIActive(false);
		switch (loadingConfig.Value.PerformType)
		{
		case 1:
			base.GetItem(4).SetUIActive(true);
			break;
		case 2:
			base.GetItem(5).SetUIActive(true);
			break;
		case 3:
			base.GetItem(7).SetUIActive(true);
			break;
		case 4:
			base.GetItem(6).SetUIActive(true);
			break;
		}
		ModelBase<HonamiStoryModel>.Instance.ClearCurLoadingData();
	}

	// Token: 0x0600EEFA RID: 61178 RVA: 0x0041562A File Offset: 0x0041382A
	protected override void OnLevelSequencePlayerBandStateChange(bool state)
	{
		base.PlaySequence("Start", null, false);
	}

	// Token: 0x0600EEFB RID: 61179 RVA: 0x0041563C File Offset: 0x0041383C
	private void OnStartSequenceEvent(string _)
	{
		if (this.LoadingConfig == null || this.LoadingConfig.Value.StartAudioEvent == "")
		{
			return;
		}
		Singleton<AudioSystem>.Instance.PostEvent(this.LoadingConfig.Value.StartAudioEvent);
	}

	// Token: 0x0600EEFC RID: 61180 RVA: 0x00415694 File Offset: 0x00413894
	private void OnCloseSequenceEvent(string _)
	{
		if (this.LoadingConfig == null || this.LoadingConfig.Value.EndAudioEvent == "")
		{
			return;
		}
		Singleton<AudioSystem>.Instance.PostEvent(this.LoadingConfig.Value.EndAudioEvent);
	}

	// Token: 0x040072F0 RID: 29424
	private HonamiStoryLoadingPerform? LoadingConfig;

	// Token: 0x020082AE RID: 33454
	[NullableContext(0)]
	private enum EHonamiStoryLoadingComponents
	{
		// Token: 0x0402C512 RID: 181522
		BgTexture,
		// Token: 0x0402C513 RID: 181523
		ProgressText,
		// Token: 0x0402C514 RID: 181524
		TitleText,
		// Token: 0x0402C515 RID: 181525
		DescText,
		// Token: 0x0402C516 RID: 181526
		FxBusFirst,
		// Token: 0x0402C517 RID: 181527
		FxBusNormal,
		// Token: 0x0402C518 RID: 181528
		FxBusSuccess,
		// Token: 0x0402C519 RID: 181529
		FxBusFail
	}
}
