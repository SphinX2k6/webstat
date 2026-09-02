using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02001D82 RID: 7554
[NullableContext(1)]
[Nullable(0)]
public class SurvivorsRogueCountDownTipsPanel : SurvivorsRogueTipsPanelBase
{
	// Token: 0x0600DE48 RID: 56904 RVA: 0x003BC860 File Offset: 0x003BAA60
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIArtText)),
			new ValueTuple<int, Type>(3, typeof(UUIArtText)),
			new ValueTuple<int, Type>(4, typeof(UUIItem))
		};
	}

	// Token: 0x0600DE49 RID: 56905 RVA: 0x003BC8E8 File Offset: 0x003BAAE8
	protected override void OnStart()
	{
		base.OnStart();
		this.TitleText = base.GetText(1);
		this.TitleText.SetUIActive(false);
		this.CountDownText = base.GetArtText(2);
		this.ParentPanel = base.GetItem(4);
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("TextData_NumB1");
		Singleton<ResourceSystem>.Instance.LoadAsync<ULGUIArtTextData>(resourcePath, delegate([Nullable(2)] ULGUIArtTextData artTextData, string pathArg)
		{
			if (artTextData == null || !artTextData.IsValid())
			{
				Singleton<Log>.Instance.Error(ELogModule.UiImageSetting, ELogAuthor.CK, "SurvivorsRogueCountDownTipsPanel找不到artTextData: TextData_NumB1", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.CountDownText.SetArtTextData(artTextData);
		}, ResourceSystem.EResourceLoadPriority.Default, this.MemoryTag);
	}

	// Token: 0x0600DE4A RID: 56906 RVA: 0x003BC95E File Offset: 0x003BAB5E
	protected override void OnBeforeShow()
	{
		base.OnBeforeShow();
		this.TickEnabled = true;
	}

	// Token: 0x0600DE4B RID: 56907 RVA: 0x003BC96D File Offset: 0x003BAB6D
	protected override void OnBeforeHide()
	{
		base.OnBeforeHide();
		this.TickEnabled = false;
	}

	// Token: 0x0600DE4C RID: 56908 RVA: 0x003BC97C File Offset: 0x003BAB7C
	public override void ShowTips()
	{
		base.Show(null);
		this.SequencePlayer.StopPlayingSequence(false, true);
		this.SequencePlayer.PlayLevelSequenceByName("Start01", false, null, false);
	}

	// Token: 0x0600DE4D RID: 56909 RVA: 0x003BC9B8 File Offset: 0x003BABB8
	public void InitCountDown(float remainTime, bool endlessWave)
	{
		this.RemainTime = remainTime;
		this.ElapsedTime = 0f;
		this.NeedTick = true;
		this.EndlessWave = endlessWave;
		this.ParentPanel.SetAnchorOffsetY((float)(endlessWave ? -30 : -100));
		this.TitleText.SetText("", true);
	}

	// Token: 0x0600DE4E RID: 56910 RVA: 0x003BCA0B File Offset: 0x003BAC0B
	public void OnTick(float delta)
	{
		if (!this.TickEnabled || !this.NeedTick)
		{
			return;
		}
		if (this.EndlessWave)
		{
			this.TickEndlessWave(delta);
			return;
		}
		this.TickNormalWave(delta);
	}

	// Token: 0x0600DE4F RID: 56911 RVA: 0x003BCA38 File Offset: 0x003BAC38
	private void TickEndlessWave(float delta)
	{
		this.ElapsedTime += delta * (float)Singleton<TimeUtil>.Instance.Millisecond;
		float elapsedTime = this.ElapsedTime;
		int num = (int)Math.Floor((double)elapsedTime / Singleton<TimeUtil>.Instance.Minute);
		string text = (num < 10) ? ("0" + num.ToString()) : num.ToString();
		int num2 = (int)Math.Floor((double)elapsedTime % Singleton<TimeUtil>.Instance.Minute);
		string text2 = (num2 < 10) ? ("0" + num2.ToString()) : num2.ToString();
		int num3 = (int)Math.Floor(((double)elapsedTime - Math.Floor((double)elapsedTime)) * 100.0);
		string text3 = (num3 < 10) ? ("0" + num3.ToString()) : num3.ToString();
		this.CountDownText.SetText(string.Concat(new string[]
		{
			text,
			":",
			text2,
			":",
			text3
		}));
	}

	// Token: 0x0600DE50 RID: 56912 RVA: 0x003BCB44 File Offset: 0x003BAD44
	private void TickNormalWave(float delta)
	{
		if (this.RemainTime <= 0f)
		{
			this.CountDownText.SetText("0s");
			this.NeedTick = false;
			return;
		}
		this.CountDownText.SetText(((int)this.RemainTime).ToString() + "s");
		this.RemainTime -= delta * (float)Singleton<TimeUtil>.Instance.Millisecond;
	}

	// Token: 0x04006ACC RID: 27340
	private const int ONE_HUNDRED = 100;

	// Token: 0x04006ACD RID: 27341
	private const int ELAPSED_ANCHOR_OFFSET_Y = -30;

	// Token: 0x04006ACE RID: 27342
	private const int COUNT_DOWN_ANCHOR_OFFSET_Y = -100;

	// Token: 0x04006ACF RID: 27343
	private float RemainTime;

	// Token: 0x04006AD0 RID: 27344
	private float ElapsedTime;

	// Token: 0x04006AD1 RID: 27345
	private UUIText TitleText;

	// Token: 0x04006AD2 RID: 27346
	private UUIArtText CountDownText;

	// Token: 0x04006AD3 RID: 27347
	private UUIItem ParentPanel;

	// Token: 0x04006AD4 RID: 27348
	private bool NeedTick;

	// Token: 0x04006AD5 RID: 27349
	private bool TickEnabled;

	// Token: 0x04006AD6 RID: 27350
	private bool EndlessWave;

	// Token: 0x0200810A RID: 33034
	[NullableContext(0)]
	private static class EComponentDefine
	{
		// Token: 0x0402BDF1 RID: 179697
		public const int BgTexture = 0;

		// Token: 0x0402BDF2 RID: 179698
		public const int TipsText = 1;

		// Token: 0x0402BDF3 RID: 179699
		public const int CountDownText = 2;

		// Token: 0x0402BDF4 RID: 179700
		public const int ChangeText = 3;

		// Token: 0x0402BDF5 RID: 179701
		public const int ParentPanel = 4;
	}
}
