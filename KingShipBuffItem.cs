using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002095 RID: 8341
public class KingShipBuffItem : UiPanelBase
{
	// Token: 0x0600FE85 RID: 65157 RVA: 0x0045CDBC File Offset: 0x0045AFBC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnClickButton))
		};
	}

	// Token: 0x0600FE86 RID: 65158 RVA: 0x0045CE65 File Offset: 0x0045B065
	protected override void OnBeforeDestroy()
	{
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.Clear();
		}
		this.LevelSequencePlayer = null;
	}

	// Token: 0x0600FE87 RID: 65159 RVA: 0x0045CE7F File Offset: 0x0045B07F
	protected override void OnStart()
	{
		base.GetItem(2).SetUIActive(false);
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		this.LevelSequencePlayer.BindSequenceCloseEvent(delegate(string name)
		{
			if (name == "Close")
			{
				base.SetUiActive(false);
			}
		}, false);
	}

	// Token: 0x0600FE88 RID: 65160 RVA: 0x0045CEB8 File Offset: 0x0045B0B8
	public void RefreshItem()
	{
		this.Rounds--;
		if (this.Rounds <= 0)
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.StopCurrentSequence(false, false);
			}
			LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
			if (levelSequencePlayer2 == null)
			{
				return;
			}
			levelSequencePlayer2.PlayOrReplaySequenceByName("Close", false, null);
		}
	}

	// Token: 0x0600FE89 RID: 65161 RVA: 0x0045CF10 File Offset: 0x0045B110
	public void ShowBuffItem(int data, int rounds)
	{
		this.BuffId = data;
		this.Rounds = rounds;
		base.SetUiActive(true);
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.StopCurrentSequence(false, false);
		}
		LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
		if (levelSequencePlayer2 != null)
		{
			levelSequencePlayer2.PlayOrReplaySequenceByName("Start", false, null);
		}
		this.SetSpriteByPath(ConfigBase<KingShipConfig>.Instance.GetKingShipBuff(data).Icon, base.GetSprite(1), false, null, null);
	}

	// Token: 0x0600FE8A RID: 65162 RVA: 0x0045CF90 File Offset: 0x0045B190
	private void OnClickButton()
	{
		if (this.BuffId == 0)
		{
			return;
		}
		base.GetItem(2).SetUIActive(true);
		Action<bool> onClickTipsCallBack = this.OnClickTipsCallBack;
		if (onClickTipsCallBack != null)
		{
			onClickTipsCallBack(true);
		}
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.StopCurrentSequence(false, false);
		}
		LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
		if (levelSequencePlayer2 != null)
		{
			levelSequencePlayer2.PlayOrReplaySequenceByName("InfoIn", false, null);
		}
		KingShipBuff kingShipBuff = ConfigBase<KingShipConfig>.Instance.GetKingShipBuff(this.BuffId);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), kingShipBuff.DesText, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), kingShipBuff.NameText, Array.Empty<object>());
	}

	// Token: 0x0600FE8B RID: 65163 RVA: 0x0045D044 File Offset: 0x0045B244
	public void CloseTipsItem()
	{
		base.GetItem(2).SetUIActive(false);
		Action<bool> onClickTipsCallBack = this.OnClickTipsCallBack;
		if (onClickTipsCallBack != null)
		{
			onClickTipsCallBack(false);
		}
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.StopCurrentSequence(false, false);
		}
		LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
		if (levelSequencePlayer2 == null)
		{
			return;
		}
		levelSequencePlayer2.PlayOrReplaySequenceByName("InfoOut", false, null);
	}

	// Token: 0x0600FE8C RID: 65164 RVA: 0x0045D0A2 File Offset: 0x0045B2A2
	public bool GetIsShowingRoundsBuff()
	{
		return this.Rounds > 0;
	}

	// Token: 0x040079FA RID: 31226
	private int BuffId;

	// Token: 0x040079FB RID: 31227
	private int Rounds;

	// Token: 0x040079FC RID: 31228
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x040079FD RID: 31229
	[Nullable(2)]
	public Action<bool> OnClickTipsCallBack;

	// Token: 0x02008422 RID: 33826
	private class EComponentDefine
	{
		// Token: 0x0402CC7E RID: 183422
		public const int Button = 0;

		// Token: 0x0402CC7F RID: 183423
		public const int IconSprite = 1;

		// Token: 0x0402CC80 RID: 183424
		public const int TipsItem = 2;

		// Token: 0x0402CC81 RID: 183425
		public const int TipsTitleText = 3;

		// Token: 0x0402CC82 RID: 183426
		public const int TipsDesText = 4;
	}
}
