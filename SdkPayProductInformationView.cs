using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.Platform.PlatformSdk;
using UnrealEngine;

// Token: 0x02002978 RID: 10616
public class SdkPayProductInformationView : UiViewBase
{
	// Token: 0x0601518C RID: 86412 RVA: 0x005D66E3 File Offset: 0x005D48E3
	[NullableContext(1)]
	public SdkPayProductInformationView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0601518D RID: 86413 RVA: 0x005D66EC File Offset: 0x005D48EC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(2, new Action(this.OnClickBackBtn)),
			new ValueTuple<int, Delegate>(3, new Action(this.OnClickConfirmBtn))
		};
	}

	// Token: 0x0601518E RID: 86414 RVA: 0x005D6797 File Offset: 0x005D4997
	protected override void OnStart()
	{
		this.ViewData = (this.OpenParam as SdkPayProductInformationViewData);
	}

	// Token: 0x0601518F RID: 86415 RVA: 0x005D67AA File Offset: 0x005D49AA
	private void OnClickBackBtn()
	{
		base.CloseMe(null);
		Singleton<EventSystem>.Instance.Emit<ESdkDialogResult>(EEventName.SdkPayEnd, ESdkDialogResult.No);
	}

	// Token: 0x06015190 RID: 86416 RVA: 0x005D67C4 File Offset: 0x005D49C4
	private void OnClickConfirmBtn()
	{
		PlatformSdkNew platformSdk = Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk();
		if (platformSdk != null)
		{
			platformSdk.HidePlayStationStoreIcon();
		}
		if (this.ViewData != null)
		{
			this.ViewData.OnClickConfirmBtn(this.ViewData.ProductId);
		}
		base.CloseMe(null);
	}

	// Token: 0x06015191 RID: 86417 RVA: 0x005D6810 File Offset: 0x005D4A10
	protected override void OnBeforeShow()
	{
		this.RefreshTitle();
		this.RefreshContent();
	}

	// Token: 0x06015192 RID: 86418 RVA: 0x005D681E File Offset: 0x005D4A1E
	private void RefreshTitle()
	{
		if (this.ViewData != null)
		{
			UUIText text = base.GetText(0);
			if (text == null)
			{
				return;
			}
			text.SetText(this.ViewData.ProductName, true);
		}
	}

	// Token: 0x06015193 RID: 86419 RVA: 0x005D6845 File Offset: 0x005D4A45
	private void RefreshContent()
	{
		if (this.ViewData != null)
		{
			UUIText text = base.GetText(1);
			if (text == null)
			{
				return;
			}
			text.SetText(this.ViewData.ContentName, true);
		}
	}

	// Token: 0x0400A276 RID: 41590
	[Nullable(2)]
	private SdkPayProductInformationViewData ViewData;

	// Token: 0x02008C84 RID: 35972
	private enum EComponents
	{
		// Token: 0x0402F4ED RID: 193773
		ProductName,
		// Token: 0x0402F4EE RID: 193774
		Content,
		// Token: 0x0402F4EF RID: 193775
		BackBtn,
		// Token: 0x0402F4F0 RID: 193776
		ConfirmBtn
	}
}
