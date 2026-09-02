using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200297A RID: 10618
public class SdkTipsPopUpView : UiTickViewBase
{
	// Token: 0x06015195 RID: 86421 RVA: 0x005D6875 File Offset: 0x005D4A75
	[NullableContext(1)]
	public SdkTipsPopUpView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06015196 RID: 86422 RVA: 0x005D6880 File Offset: 0x005D4A80
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
	}

	// Token: 0x06015197 RID: 86423 RVA: 0x005D68DC File Offset: 0x005D4ADC
	protected override void OnStart()
	{
		SdkPopUpViewData sdkPopUpViewData = this.OpenParam as SdkPopUpViewData;
		this.Data = sdkPopUpViewData;
		if (sdkPopUpViewData != null && sdkPopUpViewData.ViewType == ESdkPopUpViewType.Login)
		{
			if (this.UiViewSequence != null)
			{
				this.UiViewSequence.AddSequenceFinishEvent("Start", delegate(string _)
				{
					TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
					{
						this.IsCanClose = true;
					}, 2000f, null, null, true, 1f);
				}, false);
			}
		}
		else if (this.UiViewSequence != null)
		{
			this.UiViewSequence.AddSequenceFinishEvent("Start", delegate(string _)
			{
				if (this.UiViewSequence != null)
				{
					this.UiViewSequence.PlaySequence("Loop", false, null);
				}
			}, false);
		}
		if (sdkPopUpViewData != null)
		{
			UUIItem item = base.GetItem(2);
			if (item != null)
			{
				item.SetUIActive(sdkPopUpViewData.ViewType == ESdkPopUpViewType.Login);
			}
			UUIItem item2 = base.GetItem(0);
			if (item2 != null)
			{
				item2.SetUIActive(sdkPopUpViewData.ViewType == ESdkPopUpViewType.Creating);
			}
			this.RefreshText(sdkPopUpViewData);
		}
	}

	// Token: 0x06015198 RID: 86424 RVA: 0x005D69AB File Offset: 0x005D4BAB
	protected override void OnBeforeShow()
	{
		SdkPopUpViewData data = this.Data;
		if (data != null && data.NeedMask)
		{
			Singleton<UiLayer>.Instance.SetShowMaskLayer("SdkLoading", true);
		}
	}

	// Token: 0x06015199 RID: 86425 RVA: 0x005D69D1 File Offset: 0x005D4BD1
	protected override void OnBeforeHide()
	{
		SdkPopUpViewData data = this.Data;
		if (data != null && data.NeedMask)
		{
			Singleton<UiLayer>.Instance.SetShowMaskLayer("SdkLoading", false);
		}
	}

	// Token: 0x0601519A RID: 86426 RVA: 0x005D69F8 File Offset: 0x005D4BF8
	protected override void OnTick(float delta)
	{
		if (this.IsCanClose && base.IsShow)
		{
			this.IsCanClose = false;
			base.CloseMe(null);
		}
		SdkPopUpViewData data = this.Data;
		if (((data != null) ? new ESdkPopUpViewType?(data.ViewType) : null) == ESdkPopUpViewType.Creating)
		{
			this.CurrentRunningTime += delta / 1000f;
			if (this.CurrentRunningTime >= 10f)
			{
				base.CloseMe(null);
			}
		}
	}

	// Token: 0x0601519B RID: 86427 RVA: 0x005D6A8C File Offset: 0x005D4C8C
	[NullableContext(1)]
	private void RefreshText(SdkPopUpViewData data)
	{
		UUIText text = base.GetText(1);
		if (text == null)
		{
			return;
		}
		text.SetText(data.Text, true);
	}

	// Token: 0x0400A277 RID: 41591
	private const int AUTOCLOSETIME = 10;

	// Token: 0x0400A278 RID: 41592
	private const int LOGINCLOSETIME = 2000;

	// Token: 0x0400A279 RID: 41593
	private bool IsCanClose;

	// Token: 0x0400A27A RID: 41594
	[Nullable(2)]
	private SdkPopUpViewData Data;

	// Token: 0x0400A27B RID: 41595
	private float CurrentRunningTime;

	// Token: 0x02008C85 RID: 35973
	private enum EComponents
	{
		// Token: 0x0402F4F2 RID: 193778
		CircleImg,
		// Token: 0x0402F4F3 RID: 193779
		TipsText,
		// Token: 0x0402F4F4 RID: 193780
		PlayStationItem
	}
}
