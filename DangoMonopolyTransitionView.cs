using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x0200130D RID: 4877
[NullableContext(2)]
[Nullable(0)]
public class DangoMonopolyTransitionView : UiViewBase
{
	// Token: 0x17000B2C RID: 2860
	// (get) Token: 0x060084B0 RID: 33968 RVA: 0x002301AB File Offset: 0x0022E3AB
	public new DangoMonopolyTransitionViewParams OpenParam
	{
		get
		{
			return this.OpenParam as DangoMonopolyTransitionViewParams;
		}
	}

	// Token: 0x060084B1 RID: 33969 RVA: 0x002301B8 File Offset: 0x0022E3B8
	[NullableContext(1)]
	public DangoMonopolyTransitionView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060084B2 RID: 33970 RVA: 0x002301C1 File Offset: 0x0022E3C1
	protected override void OnAfterPlayStartSequence()
	{
		this.OnTransitionCallback().Forget();
	}

	// Token: 0x060084B3 RID: 33971 RVA: 0x002301D0 File Offset: 0x0022E3D0
	public UniTask OnTransitionCallback()
	{
		DangoMonopolyTransitionView.<OnTransitionCallback>d__4 <OnTransitionCallback>d__;
		<OnTransitionCallback>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnTransitionCallback>d__.<>4__this = this;
		<OnTransitionCallback>d__.<>1__state = -1;
		<OnTransitionCallback>d__.<>t__builder.Start<DangoMonopolyTransitionView.<OnTransitionCallback>d__4>(ref <OnTransitionCallback>d__);
		return <OnTransitionCallback>d__.<>t__builder.Task;
	}

	// Token: 0x060084B4 RID: 33972 RVA: 0x00230213 File Offset: 0x0022E413
	protected override void OnBeforeDestroy()
	{
		Singleton<EventSystem>.Instance.Emit(EEventName.DangoMonopolyTransitionClose);
	}
}
