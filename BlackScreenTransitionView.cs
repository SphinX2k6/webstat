using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using CSharpScript.Game.Utils;
using UnrealEngine;

// Token: 0x020017BF RID: 6079
[NullableContext(1)]
[Nullable(0)]
public class BlackScreenTransitionView : UiPanelBase
{
	// Token: 0x0600AB8B RID: 43915 RVA: 0x002DD8F0 File Offset: 0x002DBAF0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600AB8C RID: 43916 RVA: 0x002DD938 File Offset: 0x002DBB38
	protected override void OnStart()
	{
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnCloseEvent), false);
		this.ViewData.RegisterStateDelegate(BlackScreenViewData.EState.ShowWithOutAnim, new Action(this.ShowWithOutAnimDelegate));
		this.ViewData.RegisterStateDelegate(BlackScreenViewData.EState.Show, new Action(this.ShowDelegate));
		this.ViewData.RegisterStateDelegate(BlackScreenViewData.EState.HideWithOutAnim, new Action(this.HideWithOutAnimDelegate));
		this.ViewData.RegisterStateDelegate(BlackScreenViewData.EState.Hide, new Action(this.HideDelegate));
		base.GetTexture(0).SetAlpha(1f);
		Singleton<LguiUtil>.Instance.SetActorIsPermanent(this.RootActor, true, true);
		this.ViewData.TriggerCurrentStateDelegate();
	}

	// Token: 0x0600AB8D RID: 43917 RVA: 0x002DD9FC File Offset: 0x002DBBFC
	protected override void OnBeforeDestroy()
	{
		Singleton<BlackScreenGlobalData>.Instance.ResetGlobalData();
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer == null)
		{
			return;
		}
		levelSequencePlayer.Clear();
	}

	// Token: 0x0600AB8E RID: 43918 RVA: 0x002DDA18 File Offset: 0x002DBC18
	private void OnCloseEvent(string sequenceName)
	{
		if (sequenceName == this.ShowAnimType)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BlackScreen;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "开始动画结束";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("动画名称", sequenceName);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			Singleton<BlackScreenGlobalData>.Instance.FinishShowPromise();
			return;
		}
		if (sequenceName == this.HideAnimType)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.BlackScreen;
			ELogAuthor author2 = ELogAuthor.XXJ;
			string message2 = "关闭动画结束";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("动画名称", sequenceName);
			instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			Singleton<BlackScreenGlobalData>.Instance.FinishHidePromise();
			base.GetTexture(0).SetAlpha(1f);
			base.SetUiActive(false);
		}
	}

	// Token: 0x0600AB8F RID: 43919 RVA: 0x002DDAC4 File Offset: 0x002DBCC4
	private void ShowWithOutAnimDelegate()
	{
		Singleton<Log>.Instance.Info(ELogModule.BlackScreen, ELogAuthor.XXJ, "开始显示黑屏", default(ReadOnlySpan<ValueTuple<string, object>>));
		base.SetUiActive(true);
		Singleton<BlackScreenGlobalData>.Instance.FinishShowPromise();
	}

	// Token: 0x0600AB90 RID: 43920 RVA: 0x002DDB04 File Offset: 0x002DBD04
	private void ShowDelegate()
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.BlackScreen;
		ELogAuthor author = ELogAuthor.XXJ;
		string message = "开始显示黑屏";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("动画名称", this.ShowAnimType);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		base.SetUiActive(true);
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer == null)
		{
			return;
		}
		levelSequencePlayer.PlayLevelSequenceByName(this.ShowAnimType, false, null, false);
	}

	// Token: 0x0600AB91 RID: 43921 RVA: 0x002DDB68 File Offset: 0x002DBD68
	private void HideWithOutAnimDelegate()
	{
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.StopCurrentSequence(true, true);
		}
		Singleton<Log>.Instance.Info(ELogModule.BlackScreen, ELogAuthor.XXJ, "开始隐藏黑屏", default(ReadOnlySpan<ValueTuple<string, object>>));
		base.GetTexture(0).SetAlpha(1f);
		base.SetUiActive(false);
		Singleton<BlackScreenGlobalData>.Instance.FinishHidePromise();
	}

	// Token: 0x0600AB92 RID: 43922 RVA: 0x002DDBCC File Offset: 0x002DBDCC
	private void HideDelegate()
	{
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.StopCurrentSequence(true, true);
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.BlackScreen;
		ELogAuthor author = ELogAuthor.XXJ;
		string message = "开始隐藏黑屏";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("动画名称", this.HideAnimType);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
		if (levelSequencePlayer2 == null)
		{
			return;
		}
		levelSequencePlayer2.PlayLevelSequenceByName(this.HideAnimType, false, null, false);
	}

	// Token: 0x0600AB93 RID: 43923 RVA: 0x002DDC3C File Offset: 0x002DBE3C
	private void ApplyColor(string colorType)
	{
		FColor color = (colorType == "White") ? ColorUtils.ColorWhile : ColorUtils.ColorBlack;
		base.GetTexture(0).SetColor(color);
	}

	// Token: 0x0600AB94 RID: 43924 RVA: 0x002DDC70 File Offset: 0x002DBE70
	public void ShowTemp(string showAnimType, string colorType)
	{
		Singleton<BlackScreenGlobalData>.Instance.CreateShowPromise();
		string showAnimType2 = this.ShowAnimType;
		this.ShowAnimType = showAnimType;
		this.ApplyColor(colorType);
		bool flag = showAnimType != "None";
		if (!this.ViewData.SwitchState(flag ? BlackScreenViewData.EState.Show : BlackScreenViewData.EState.ShowWithOutAnim))
		{
			this.ShowAnimType = showAnimType2;
		}
	}

	// Token: 0x0600AB95 RID: 43925 RVA: 0x002DDCC4 File Offset: 0x002DBEC4
	public void HideTemp(string hideAnimType)
	{
		Singleton<BlackScreenGlobalData>.Instance.CreateHidePromise();
		string hideAnimType2 = this.HideAnimType;
		this.HideAnimType = hideAnimType;
		bool flag = hideAnimType != "None";
		if (!this.ViewData.SwitchState(flag ? BlackScreenViewData.EState.Hide : BlackScreenViewData.EState.HideWithOutAnim))
		{
			this.HideAnimType = hideAnimType2;
		}
	}

	// Token: 0x04005199 RID: 20889
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x0400519A RID: 20890
	private string ShowAnimType = "None";

	// Token: 0x0400519B RID: 20891
	private string HideAnimType = "None";

	// Token: 0x0400519C RID: 20892
	private readonly BlackScreenViewData ViewData = new BlackScreenViewData();

	// Token: 0x02007B02 RID: 31490
	[NullableContext(0)]
	private static class ECompDefine
	{
		// Token: 0x0402A1F3 RID: 172531
		public const int BlackTexture = 0;
	}
}
