using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Functional;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher;

// Token: 0x0200179B RID: 6043
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class AppLinksController : ControllerBase<AppLinksController>
{
	// Token: 0x0600AAA2 RID: 43682 RVA: 0x002D92B5 File Offset: 0x002D74B5
	protected override bool OnInit()
	{
		this.RegisterDeepValueHandle();
		return base.OnInit();
	}

	// Token: 0x0600AAA3 RID: 43683 RVA: 0x002D92C3 File Offset: 0x002D74C3
	protected override bool OnClear()
	{
		this.UnregisterDeepValueHandle();
		return base.OnClear();
	}

	// Token: 0x0600AAA4 RID: 43684 RVA: 0x002D92D4 File Offset: 0x002D74D4
	private void RegisterDeepValueHandle()
	{
		AppLinks instance = Singleton<AppLinks>.Instance;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
		defaultInterpolatedStringHandler.AppendFormatted<int>(10009);
		instance.SetDeepValueHandle(defaultInterpolatedStringHandler.ToStringAndClear(), new Action<string, string>(this.OpenGachaView));
		AppLinks instance2 = Singleton<AppLinks>.Instance;
		defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
		defaultInterpolatedStringHandler.AppendFormatted<int>(10053);
		instance2.SetDeepValueHandle(defaultInterpolatedStringHandler.ToStringAndClear(), new Action<string, string>(this.OpenActivityView));
	}

	// Token: 0x0600AAA5 RID: 43685 RVA: 0x002D9348 File Offset: 0x002D7548
	private void UnregisterDeepValueHandle()
	{
		AppLinks instance = Singleton<AppLinks>.Instance;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
		defaultInterpolatedStringHandler.AppendFormatted<int>(10009);
		instance.RemoveDeepValueHandle(defaultInterpolatedStringHandler.ToStringAndClear());
		AppLinks instance2 = Singleton<AppLinks>.Instance;
		defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
		defaultInterpolatedStringHandler.AppendFormatted<int>(10053);
		instance2.RemoveDeepValueHandle(defaultInterpolatedStringHandler.ToStringAndClear());
	}

	// Token: 0x0600AAA6 RID: 43686 RVA: 0x002D93A1 File Offset: 0x002D75A1
	private bool CanOpenView()
	{
		return ModelBase<GameModeModel>.Instance.WorldDone && !ModelBase<GameModeModel>.Instance.Loading && Singleton<UiManager>.Instance.IsViewShow(EUiViewName.BattleView);
	}

	// Token: 0x0600AAA7 RID: 43687 RVA: 0x002D93CF File Offset: 0x002D75CF
	private void OpenGachaView(string deepValue, string source)
	{
		if (!this.CanOpenView())
		{
			return;
		}
		ControllerBase<FunctionController>.Instance.OpenFunctionRelateView(EFunctionType.Gacha);
	}

	// Token: 0x0600AAA8 RID: 43688 RVA: 0x002D93E9 File Offset: 0x002D75E9
	private void OpenActivityView(string deepValue, string source)
	{
		if (!this.CanOpenView())
		{
			return;
		}
		ControllerBase<FunctionController>.Instance.OpenFunctionRelateView(EFunctionType.Activity);
	}
}
