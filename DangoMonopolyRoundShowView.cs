using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001305 RID: 4869
public class DangoMonopolyRoundShowView : DangoMonopolyViewBase
{
	// Token: 0x17000B29 RID: 2857
	// (get) Token: 0x06008462 RID: 33890 RVA: 0x0022F06E File Offset: 0x0022D26E
	[Nullable(2)]
	public new DangoMonopolyRoundShowViewParams OpenParam
	{
		[NullableContext(2)]
		get
		{
			return this.OpenParam as DangoMonopolyRoundShowViewParams;
		}
	}

	// Token: 0x06008463 RID: 33891 RVA: 0x0022F07B File Offset: 0x0022D27B
	[NullableContext(1)]
	public DangoMonopolyRoundShowView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06008464 RID: 33892 RVA: 0x0022F084 File Offset: 0x0022D284
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText))
		};
	}

	// Token: 0x06008465 RID: 33893 RVA: 0x0022F0A7 File Offset: 0x0022D2A7
	private void InitDataParam()
	{
	}

	// Token: 0x06008466 RID: 33894 RVA: 0x0022F0AC File Offset: 0x0022D2AC
	protected override UniTask OnBeforeStartAsync()
	{
		DangoMonopolyRoundShowView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<DangoMonopolyRoundShowView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06008467 RID: 33895 RVA: 0x0022F0F0 File Offset: 0x0022D2F0
	protected override void OnStart()
	{
		UUIText text = base.GetText(0);
		DangoMonopolyRoundShowViewParams openParam = this.OpenParam;
		text.SetText(((openParam != null) ? openParam.TipsText : null) ?? "", true);
		TimerSystem.GameplayTimeInstance.Delay(new TTimerAction(this.ShowTimeCallback), this.OpenParam.ShowTime, null, null, true, 1f);
	}

	// Token: 0x06008468 RID: 33896 RVA: 0x0022F14F File Offset: 0x0022D34F
	protected override void OnAfterPlayStartSequence()
	{
		this.AwaitOpenAfterClose().Forget();
	}

	// Token: 0x06008469 RID: 33897 RVA: 0x0022F15C File Offset: 0x0022D35C
	private UniTask AwaitOpenAfterClose()
	{
		DangoMonopolyRoundShowView.<AwaitOpenAfterClose>d__9 <AwaitOpenAfterClose>d__;
		<AwaitOpenAfterClose>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<AwaitOpenAfterClose>d__.<>4__this = this;
		<AwaitOpenAfterClose>d__.<>1__state = -1;
		<AwaitOpenAfterClose>d__.<>t__builder.Start<DangoMonopolyRoundShowView.<AwaitOpenAfterClose>d__9>(ref <AwaitOpenAfterClose>d__);
		return <AwaitOpenAfterClose>d__.<>t__builder.Task;
	}

	// Token: 0x0600846A RID: 33898 RVA: 0x0022F19F File Offset: 0x0022D39F
	private void ShowTimeCallback(float _)
	{
		if (base.IsDestroyOrDestroying)
		{
			return;
		}
		base.CloseMe(null);
	}

	// Token: 0x0600846B RID: 33899 RVA: 0x0022F1B4 File Offset: 0x0022D3B4
	protected override void OnBeforeDestroy()
	{
		DangoMonopolyRoundShowViewParams openParam = this.OpenParam;
		int boardId = (openParam != null) ? openParam.BoardId : 0;
		DangoMonopolyRoundShowViewParams openParam2 = this.OpenParam;
		CustomPromise promise = (openParam2 != null) ? openParam2.Promise : null;
		Singleton<UiManager>.Instance.OpenView(EUiViewName.DangoMonopolyRoundBuffShowView, new DangoMonopolyRoundBuffShowViewParam
		{
			BoardId = boardId,
			Promise = promise
		}, null);
	}

	// Token: 0x020076AD RID: 30381
	private enum EChildType
	{
		// Token: 0x04028E2A RID: 167466
		TxtDesc
	}
}
