using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020011A1 RID: 4513
[NullableContext(1)]
[Nullable(0)]
public class ArtemisActivityCertificationView : UiViewBase
{
	// Token: 0x060076AF RID: 30383 RVA: 0x001F11A5 File Offset: 0x001EF3A5
	public ArtemisActivityCertificationView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060076B0 RID: 30384 RVA: 0x001F11B0 File Offset: 0x001EF3B0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIArtText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.StartVerification))
		};
	}

	// Token: 0x060076B1 RID: 30385 RVA: 0x001F129C File Offset: 0x001EF49C
	protected override void OnStart()
	{
		AUIBaseActor rootActor = this.RootActor;
		if (rootActor != null)
		{
			rootActor.OnSequencePlayEvent.Bind(new Action<string, string>(this.OnPlaySequenceEvent));
		}
		UUIText text = base.GetText(6);
		if (text != null)
		{
			text.ShowTextNew("Activity_ArtemisChatFixTips_1");
		}
		UUIText text2 = base.GetText(5);
		if (text2 != null)
		{
			text2.ShowTextNew("Activity_ArtemisChatFixTips_2");
		}
		UUIText text3 = base.GetText(7);
		if (text3 != null)
		{
			text3.ShowTextNew("Activity_ArtemisChatFixTips_3");
		}
		UUIArtText artText = base.GetArtText(2);
		if (artText == null)
		{
			return;
		}
		artText.SetText("100");
	}

	// Token: 0x060076B2 RID: 30386 RVA: 0x001F1326 File Offset: 0x001EF526
	protected override void OnAddEventListener()
	{
		UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
		if (uiViewSequence == null)
		{
			return;
		}
		uiViewSequence.AddSequenceFinishEvent("Fix_Done_02", new Action<string>(this.OnFixDone2End), false);
	}

	// Token: 0x060076B3 RID: 30387 RVA: 0x001F134A File Offset: 0x001EF54A
	protected override void OnRemoveEventListener()
	{
		this.UiViewSequence.RemoveSequenceFinishEvent("Fix_Done_02", new Action<string>(this.OnFixDone2End));
	}

	// Token: 0x060076B4 RID: 30388 RVA: 0x001F1368 File Offset: 0x001EF568
	private void OnPlaySequenceEvent(string sequenceName, string eventName)
	{
		if (eventName == "Sequence_Bottom_In")
		{
			this.IsCanClickFingerprintBtn = true;
		}
	}

	// Token: 0x060076B5 RID: 30389 RVA: 0x001F1380 File Offset: 0x001EF580
	protected override void OnBeforeShow()
	{
		ArtemisActivityCertificationViewParams artemisActivityCertificationViewParams = this.OpenParam as ArtemisActivityCertificationViewParams;
		this.IsPlayFixedDone = (artemisActivityCertificationViewParams != null && artemisActivityCertificationViewParams.IsPlayFixedDone);
		this.FinishCallback = ((artemisActivityCertificationViewParams != null) ? artemisActivityCertificationViewParams.Callback : null);
		this.IsCanClickFingerprintBtn = false;
		if (this.IsPlayFixedDone)
		{
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence == null)
			{
				return;
			}
			uiViewSequence.PlaySequence("Fix_Done_02", true, null);
			return;
		}
		else
		{
			UiBehaviorLevelSequence uiViewSequence2 = this.UiViewSequence;
			if (uiViewSequence2 == null)
			{
				return;
			}
			uiViewSequence2.PlaySequence("Wanring", true, null);
			return;
		}
	}

	// Token: 0x060076B6 RID: 30390 RVA: 0x001F140B File Offset: 0x001EF60B
	private void StartVerification()
	{
		if (!this.IsCanClickFingerprintBtn)
		{
			return;
		}
		Action finishCallback = this.FinishCallback;
		if (finishCallback == null)
		{
			return;
		}
		finishCallback();
	}

	// Token: 0x060076B7 RID: 30391 RVA: 0x001F1426 File Offset: 0x001EF626
	private void OnFixDone2End(string _)
	{
		Action finishCallback = this.FinishCallback;
		if (finishCallback != null)
		{
			finishCallback();
		}
		base.CloseMe(null);
	}

	// Token: 0x0400396D RID: 14701
	private bool IsPlayFixedDone;

	// Token: 0x0400396E RID: 14702
	private bool IsCanClickFingerprintBtn;

	// Token: 0x0400396F RID: 14703
	[Nullable(2)]
	private Action FinishCallback;

	// Token: 0x020074FB RID: 29947
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x04028632 RID: 165426
		public const int FingerprintBtn = 0;

		// Token: 0x04028633 RID: 165427
		public const int CircularProgressBar = 1;

		// Token: 0x04028634 RID: 165428
		public const int ProgressText = 2;

		// Token: 0x04028635 RID: 165429
		public const int PnlFixProgress = 3;

		// Token: 0x04028636 RID: 165430
		public const int PnlPopupTip = 4;

		// Token: 0x04028637 RID: 165431
		public const int ClickTipsText = 5;

		// Token: 0x04028638 RID: 165432
		public const int WarningTipsText = 6;

		// Token: 0x04028639 RID: 165433
		public const int FixedTipsText = 7;
	}
}
