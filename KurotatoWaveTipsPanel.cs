using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001D27 RID: 7463
[NullableContext(1)]
[Nullable(0)]
public class KurotatoWaveTipsPanel : UiPanelBase
{
	// Token: 0x0600DB9A RID: 56218 RVA: 0x003B0240 File Offset: 0x003AE440
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUITexture))
		};
	}

	// Token: 0x0600DB9B RID: 56219 RVA: 0x003B029A File Offset: 0x003AE49A
	protected override void OnStart()
	{
		this.TextTips = base.GetText(0);
		this.SeqPlayer = new LevelSequencePlayer(base.GetRootItem());
		this.SeqPlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceClose), false);
	}

	// Token: 0x0600DB9C RID: 56220 RVA: 0x003B02D2 File Offset: 0x003AE4D2
	public void SetFinishCb(Action cb)
	{
		this.FinishCb = cb;
	}

	// Token: 0x0600DB9D RID: 56221 RVA: 0x003B02DC File Offset: 0x003AE4DC
	public void PlaySuccess(string tipsTextKey)
	{
		base.SetUiActive(true);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(this.TextTips, tipsTextKey, Array.Empty<object>());
		this.SeqPlayer.PlayOrReplaySequenceByName("StartSuccess", false, null);
	}

	// Token: 0x0600DB9E RID: 56222 RVA: 0x003B0320 File Offset: 0x003AE520
	public void PlayFail(string tipsTextKey)
	{
		base.SetUiActive(true);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(this.TextTips, tipsTextKey, Array.Empty<object>());
		this.SeqPlayer.PlayOrReplaySequenceByName("StartFail", false, null);
	}

	// Token: 0x0600DB9F RID: 56223 RVA: 0x003B0364 File Offset: 0x003AE564
	private void OnSequenceClose(string sequenceName)
	{
		if (sequenceName == "StartSuccess" || sequenceName == "StartFail")
		{
			Action finishCb = this.FinishCb;
			if (finishCb == null)
			{
				return;
			}
			finishCb();
		}
	}

	// Token: 0x040068FA RID: 26874
	private UUIText TextTips;

	// Token: 0x040068FB RID: 26875
	private LevelSequencePlayer SeqPlayer;

	// Token: 0x040068FC RID: 26876
	[Nullable(2)]
	private Action FinishCb;

	// Token: 0x020080A8 RID: 32936
	[NullableContext(0)]
	private static class EComponentDefine
	{
		// Token: 0x0402BC1C RID: 179228
		public const int TextTips = 0;

		// Token: 0x0402BC1D RID: 179229
		public const int TextureWin = 1;

		// Token: 0x0402BC1E RID: 179230
		public const int TextureFailure = 2;
	}
}
