using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002974 RID: 10612
public class SdkEnterTipsView : UiTickViewBase
{
	// Token: 0x06015165 RID: 86373 RVA: 0x005D5959 File Offset: 0x005D3B59
	[NullableContext(1)]
	public SdkEnterTipsView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06015166 RID: 86374 RVA: 0x005D5962 File Offset: 0x005D3B62
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(0, typeof(UUIText))
		};
	}

	// Token: 0x06015167 RID: 86375 RVA: 0x005D599C File Offset: 0x005D3B9C
	protected override void OnStart()
	{
		this.Data = (this.OpenParam as SdkEnterTipsViewData);
		if (this.UiViewSequence != null)
		{
			this.UiViewSequence.AddSequenceFinishEvent("Start", delegate(string _)
			{
				this.IsCanClose = true;
			}, false);
		}
		this.RefreshText(this.Data);
	}

	// Token: 0x06015168 RID: 86376 RVA: 0x005D59EB File Offset: 0x005D3BEB
	protected override void OnBeforeShow()
	{
		SdkEnterTipsViewData data = this.Data;
		if (data != null && data.NeedMask)
		{
			Singleton<UiLayer>.Instance.SetShowMaskLayer("SdkLoading", true);
		}
	}

	// Token: 0x06015169 RID: 86377 RVA: 0x005D5A11 File Offset: 0x005D3C11
	protected override void OnBeforeHide()
	{
		SdkEnterTipsViewData data = this.Data;
		if (data != null && data.NeedMask)
		{
			Singleton<UiLayer>.Instance.SetShowMaskLayer("SdkLoading", false);
		}
	}

	// Token: 0x0601516A RID: 86378 RVA: 0x005D5A37 File Offset: 0x005D3C37
	protected override void OnTick(float delta)
	{
		if (this.IsCanClose && base.IsShow)
		{
			this.IsCanClose = false;
			base.CloseMe(null);
		}
	}

	// Token: 0x0601516B RID: 86379 RVA: 0x005D5A57 File Offset: 0x005D3C57
	[NullableContext(2)]
	private void RefreshText(SdkEnterTipsViewData data)
	{
		if (data != null)
		{
			UUIText text = base.GetText(0);
			if (text == null)
			{
				return;
			}
			text.SetText(data.Text, true);
		}
	}

	// Token: 0x0400A26C RID: 41580
	private bool IsCanClose;

	// Token: 0x0400A26D RID: 41581
	[Nullable(2)]
	private SdkEnterTipsViewData Data;

	// Token: 0x02008C7C RID: 35964
	private enum EComponents
	{
		// Token: 0x0402F4C7 RID: 193735
		TipsText,
		// Token: 0x0402F4C8 RID: 193736
		CircleImg
	}
}
