using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Common;

// Token: 0x02001A58 RID: 6744
[NullableContext(1)]
[Nullable(0)]
public class CommonSuccessData
{
	// Token: 0x0600C0BD RID: 49341 RVA: 0x0032D86D File Offset: 0x0032BA6D
	public void SetTitleText(string text)
	{
		this.TitleText = text;
	}

	// Token: 0x0600C0BE RID: 49342 RVA: 0x0032D876 File Offset: 0x0032BA76
	public void SetSubTitleText(string text)
	{
		this.SubTitleText = text;
	}

	// Token: 0x0600C0BF RID: 49343 RVA: 0x0032D87F File Offset: 0x0032BA7F
	public void SetClickText(string text)
	{
		this.ClickText = text;
	}

	// Token: 0x0600C0C0 RID: 49344 RVA: 0x0032D888 File Offset: 0x0032BA88
	public string GetTitleText()
	{
		return this.TitleText;
	}

	// Token: 0x0600C0C1 RID: 49345 RVA: 0x0032D890 File Offset: 0x0032BA90
	public string GetSubTitleText()
	{
		return this.SubTitleText;
	}

	// Token: 0x0600C0C2 RID: 49346 RVA: 0x0032D898 File Offset: 0x0032BA98
	public string GetClickText()
	{
		return this.ClickText;
	}

	// Token: 0x0600C0C3 RID: 49347 RVA: 0x0032D8A0 File Offset: 0x0032BAA0
	public void SetClickFunction(Action clickFunction)
	{
		this.ClickFunction = clickFunction;
	}

	// Token: 0x0600C0C4 RID: 49348 RVA: 0x0032D8A9 File Offset: 0x0032BAA9
	[NullableContext(2)]
	public Action GetClickFunction()
	{
		return this.ClickFunction;
	}

	// Token: 0x0600C0C5 RID: 49349 RVA: 0x0032D8B4 File Offset: 0x0032BAB4
	public void SetAudioId(string audioId)
	{
		Audio? audioPath = ConfigBase<AudioConfig>.Instance.GetAudioPath(audioId);
		if (audioPath != null)
		{
			this.AudioPath = audioPath.Value.Path;
		}
	}

	// Token: 0x0600C0C6 RID: 49350 RVA: 0x0032D8EB File Offset: 0x0032BAEB
	public string GetAudioPath()
	{
		return this.AudioPath;
	}

	// Token: 0x0600C0C7 RID: 49351 RVA: 0x0032D8F3 File Offset: 0x0032BAF3
	public void SetNeedDelay(bool needDelay)
	{
		this.NeedDelay = needDelay;
	}

	// Token: 0x0600C0C8 RID: 49352 RVA: 0x0032D8FC File Offset: 0x0032BAFC
	public bool GetNeedDelay()
	{
		return this.NeedDelay;
	}

	// Token: 0x04005A5B RID: 23131
	private string TitleText = "";

	// Token: 0x04005A5C RID: 23132
	private string SubTitleText = "";

	// Token: 0x04005A5D RID: 23133
	private string ClickText = "";

	// Token: 0x04005A5E RID: 23134
	[Nullable(2)]
	private Action ClickFunction;

	// Token: 0x04005A5F RID: 23135
	private string AudioPath = "";

	// Token: 0x04005A60 RID: 23136
	private bool NeedDelay = true;
}
