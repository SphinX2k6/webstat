using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.Plot.Sequence;

// Token: 0x0200297F RID: 10623
[NullableContext(1)]
[Nullable(0)]
public class SubtitleInfo
{
	// Token: 0x17001BC3 RID: 7107
	// (get) Token: 0x0601520F RID: 86543 RVA: 0x005D7AD4 File Offset: 0x005D5CD4
	[Nullable(2)]
	public ITalkItem CurrentConfig
	{
		[NullableContext(2)]
		get
		{
			return this.CurSubConfig.Subtitles;
		}
	}

	// Token: 0x17001BC4 RID: 7108
	// (get) Token: 0x06015210 RID: 86544 RVA: 0x005D7AE1 File Offset: 0x005D5CE1
	public float CurrentDelayTime
	{
		get
		{
			return this.CurSubConfig.AudioDelay;
		}
	}

	// Token: 0x17001BC5 RID: 7109
	// (get) Token: 0x06015211 RID: 86545 RVA: 0x005D7AEE File Offset: 0x005D5CEE
	public float CurrentAutoPlayDelayTime
	{
		get
		{
			return this.CurSubConfig.AutoPlayDelay;
		}
	}

	// Token: 0x17001BC6 RID: 7110
	// (get) Token: 0x06015212 RID: 86546 RVA: 0x005D7AFB File Offset: 0x005D5CFB
	public float CurrentAudioTransitionDuration
	{
		get
		{
			return this.CurSubConfig.AudioTransitionDuration;
		}
	}

	// Token: 0x06015213 RID: 86547 RVA: 0x005D7B08 File Offset: 0x005D5D08
	public bool HasSubtitle()
	{
		return this.CurSubConfig.Subtitles != null;
	}

	// Token: 0x06015214 RID: 86548 RVA: 0x005D7B18 File Offset: 0x005D5D18
	public void SetCurrentSubtitle(PlotSubtitleConfig subtitleInfo)
	{
		this.CurSubConfig.CopyFrom(subtitleInfo);
		this.InitSubtitle();
	}

	// Token: 0x06015215 RID: 86549 RVA: 0x005D7B2C File Offset: 0x005D5D2C
	private void InitSubtitle()
	{
		if (!this.HasSubtitle())
		{
			return;
		}
		List<ITalkOption> options = this.CurrentConfig.Options;
		this.HasOption = (((options != null) ? options.Count : 0) > 0 || this.CurrentConfig.Type.GetValueOrDefault() == ETalkItemType.SystemOption);
		this.ShowAllText = false;
		this.ShowOption = false;
		this.EnableSkipTime = Singleton<TimeUtil>.Instance.GetServerTimeStamp() + (double)this.CurSubConfig.GuardTime;
		this.NeedDelay = (this.CurSubConfig.AutoPlayDelay > 0f);
		this.StartFinish = false;
	}

	// Token: 0x06015216 RID: 86550 RVA: 0x005D7BC8 File Offset: 0x005D5DC8
	public void Clear()
	{
		this.CurSubConfig.Clear();
		this.HasOption = false;
		this.ShowAllText = false;
		this.ShowOption = false;
		this.Skip = false;
		this.EnableSkipTime = 0.0;
		this.NeedDelay = false;
		this.StartFinish = false;
	}

	// Token: 0x0400A295 RID: 41621
	private readonly PlotSubtitleConfig CurSubConfig = new PlotSubtitleConfig();

	// Token: 0x0400A296 RID: 41622
	public bool HasOption;

	// Token: 0x0400A297 RID: 41623
	public bool ShowAllText;

	// Token: 0x0400A298 RID: 41624
	public bool ShowOption;

	// Token: 0x0400A299 RID: 41625
	public bool Skip;

	// Token: 0x0400A29A RID: 41626
	public double EnableSkipTime;

	// Token: 0x0400A29B RID: 41627
	public bool NeedDelay;

	// Token: 0x0400A29C RID: 41628
	public bool StartFinish;
}
