using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001A59 RID: 6745
public class CommonSuccessView : UiViewBase
{
	// Token: 0x0600C0CA RID: 49354 RVA: 0x0032D93F File Offset: 0x0032BB3F
	[NullableContext(1)]
	public CommonSuccessView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600C0CB RID: 49355 RVA: 0x0032D948 File Offset: 0x0032BB48
	protected override void OnBeforeCreate()
	{
		this.Data = ((this.OpenParam as CommonSuccessData) ?? new CommonSuccessData());
		this.SetAudio();
	}

	// Token: 0x0600C0CC RID: 49356 RVA: 0x0032D96C File Offset: 0x0032BB6C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(3, new Action(this.CloseClick))
		};
	}

	// Token: 0x0600C0CD RID: 49357 RVA: 0x0032DA15 File Offset: 0x0032BC15
	private void CloseClick()
	{
		if (this.Data.GetNeedDelay())
		{
			return;
		}
		this.CloseView();
	}

	// Token: 0x0600C0CE RID: 49358 RVA: 0x0032DA2B File Offset: 0x0032BC2B
	protected override void OnAfterPlayStartSequence()
	{
		this.UiViewSequence.PlaySequencePurely("Xunhuan", false, false);
		this.DelayClose();
	}

	// Token: 0x0600C0CF RID: 49359 RVA: 0x0032DA45 File Offset: 0x0032BC45
	protected override void OnAfterShow()
	{
		this.SetTitleText();
		this.SetSubTitleText();
		this.SetClickText();
	}

	// Token: 0x0600C0D0 RID: 49360 RVA: 0x0032DA5C File Offset: 0x0032BC5C
	private void SetAudio()
	{
		string audioPath = this.Data.GetAudioPath();
		if (!string.IsNullOrEmpty(audioPath))
		{
			base.SetAudioEvent(audioPath);
		}
	}

	// Token: 0x0600C0D1 RID: 49361 RVA: 0x0032DA84 File Offset: 0x0032BC84
	private void SetTitleText()
	{
		string titleText = this.Data.GetTitleText();
		if (!string.IsNullOrEmpty(titleText))
		{
			UUIText text = base.GetText(0);
			Singleton<LguiUtil>.Instance.SetLocalText(text, titleText, Array.Empty<object>());
		}
	}

	// Token: 0x0600C0D2 RID: 49362 RVA: 0x0032DAC0 File Offset: 0x0032BCC0
	private void SetSubTitleText()
	{
		string subTitleText = this.Data.GetSubTitleText();
		UUIText text = base.GetText(1);
		if (!string.IsNullOrEmpty(subTitleText))
		{
			text.SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalText(text, subTitleText, Array.Empty<object>());
			return;
		}
		text.SetUIActive(false);
	}

	// Token: 0x0600C0D3 RID: 49363 RVA: 0x0032DB0C File Offset: 0x0032BD0C
	private void SetClickText()
	{
		string clickText = this.Data.GetClickText();
		if (!string.IsNullOrEmpty(clickText))
		{
			base.GetItem(4).SetUIActive(true);
			UUIText text = base.GetText(2);
			Singleton<LguiUtil>.Instance.SetLocalText(text, clickText, Array.Empty<object>());
		}
	}

	// Token: 0x0600C0D4 RID: 49364 RVA: 0x0032DB53 File Offset: 0x0032BD53
	private void DelayClose()
	{
		if (this.Data.GetNeedDelay())
		{
			this.TimerId = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				this.CloseView();
			}, (float)CommonSuccessView.DelayTime, null, null, true, 1f);
		}
	}

	// Token: 0x0600C0D5 RID: 49365 RVA: 0x0032DB8C File Offset: 0x0032BD8C
	private void CloseView()
	{
		Action clickFunction = this.Data.GetClickFunction();
		if (clickFunction != null)
		{
			clickFunction();
		}
		this.TimerId = null;
		base.CloseMe(null);
	}

	// Token: 0x0600C0D6 RID: 49366 RVA: 0x0032DBBC File Offset: 0x0032BDBC
	protected override void OnBeforeDestroy()
	{
		if (this.TimerId != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.TimerId);
			this.TimerId = null;
		}
	}

	// Token: 0x04005A61 RID: 23137
	[Nullable(2)]
	private CommonSuccessData Data;

	// Token: 0x04005A62 RID: 23138
	private static readonly int DelayTime = 1500;

	// Token: 0x04005A63 RID: 23139
	[Nullable(2)]
	protected TimerHandle TimerId;

	// Token: 0x02007D0C RID: 32012
	private enum ECommonSuccessViewDefine
	{
		// Token: 0x0402AA3A RID: 174650
		TitleText,
		// Token: 0x0402AA3B RID: 174651
		SubTitleText,
		// Token: 0x0402AA3C RID: 174652
		ClickText,
		// Token: 0x0402AA3D RID: 174653
		CloseButton,
		// Token: 0x0402AA3E RID: 174654
		ClickItem
	}
}
