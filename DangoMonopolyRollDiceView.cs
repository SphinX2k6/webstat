using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Interaction;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020012FC RID: 4860
[NullableContext(1)]
[Nullable(0)]
public class DangoMonopolyRollDiceView : DangoMonopolyViewBase
{
	// Token: 0x17000B19 RID: 2841
	// (get) Token: 0x06008417 RID: 33815 RVA: 0x0022E49B File Offset: 0x0022C69B
	[Nullable(2)]
	public new DangoMonopolyRollDiceViewParam OpenParam
	{
		[NullableContext(2)]
		get
		{
			return this.OpenParam as DangoMonopolyRollDiceViewParam;
		}
	}

	// Token: 0x06008418 RID: 33816 RVA: 0x0022E4A8 File Offset: 0x0022C6A8
	public DangoMonopolyRollDiceView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06008419 RID: 33817 RVA: 0x0022E4BC File Offset: 0x0022C6BC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUITexture)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnClickBtnSpeed)),
			new ValueTuple<int, Delegate>(2, new Action(this.OnClickBtnEmpty))
		};
	}

	// Token: 0x0600841A RID: 33818 RVA: 0x0022E5A9 File Offset: 0x0022C7A9
	private void InitDataParam()
	{
	}

	// Token: 0x0600841B RID: 33819 RVA: 0x0022E5AC File Offset: 0x0022C7AC
	protected override UniTask OnBeforeStartAsync()
	{
		DangoMonopolyRollDiceView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<DangoMonopolyRollDiceView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600841C RID: 33820 RVA: 0x0022E5EF File Offset: 0x0022C7EF
	protected override void OnStart()
	{
		this.ActivityData.UpdateBoardGridUiInfoShow(false).Forget();
	}

	// Token: 0x0600841D RID: 33821 RVA: 0x0022E602 File Offset: 0x0022C802
	protected override void OnAddEventListener()
	{
	}

	// Token: 0x0600841E RID: 33822 RVA: 0x0022E604 File Offset: 0x0022C804
	protected override void OnRemoveEventListener()
	{
	}

	// Token: 0x0600841F RID: 33823 RVA: 0x0022E606 File Offset: 0x0022C806
	protected override void OnBeforeShow()
	{
		this.UpdateData().Forget();
	}

	// Token: 0x06008420 RID: 33824 RVA: 0x0022E614 File Offset: 0x0022C814
	protected override void OnBeforeDestroy()
	{
		this.ActivityData.UpdateBoardGridUiInfoShow(true).Forget();
		Singleton<EventSystem>.Instance.Emit(EEventName.DangoMonopolyMoveStart);
		Singleton<EventSystem>.Instance.Emit<bool>(EEventName.DangoMonopolyMoveStepStartOrEnd, true);
		DangoMonopolyDiceBuffPanel diceBuffPanel = this.DiceBuffPanel;
		if (diceBuffPanel == null)
		{
			return;
		}
		diceBuffPanel.Destroy(null);
	}

	// Token: 0x06008421 RID: 33825 RVA: 0x0022E664 File Offset: 0x0022C864
	private void OnClickBtnSpeed()
	{
		this.ActivityData.SetActivitySpeed(null);
		this.UpdateSpeed();
	}

	// Token: 0x06008422 RID: 33826 RVA: 0x0022E68B File Offset: 0x0022C88B
	private void OnClickBtnEmpty()
	{
		if (this.IsRollDiceFinish)
		{
			base.CloseMe(null);
		}
	}

	// Token: 0x06008423 RID: 33827 RVA: 0x0022E69C File Offset: 0x0022C89C
	public void UpdateSpeed()
	{
		string speedStr = this.ActivityData.GetSpeedStr();
		UUIText text = base.GetText(1);
		if (text == null)
		{
			return;
		}
		text.SetText(speedStr, true);
	}

	// Token: 0x06008424 RID: 33828 RVA: 0x0022E6C8 File Offset: 0x0022C8C8
	public UniTask UpdateData()
	{
		DangoMonopolyRollDiceView.<UpdateData>d__18 <UpdateData>d__;
		<UpdateData>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<UpdateData>d__.<>4__this = this;
		<UpdateData>d__.<>1__state = -1;
		<UpdateData>d__.<>t__builder.Start<DangoMonopolyRollDiceView.<UpdateData>d__18>(ref <UpdateData>d__);
		return <UpdateData>d__.<>t__builder.Task;
	}

	// Token: 0x06008425 RID: 33829 RVA: 0x0022E70C File Offset: 0x0022C90C
	public UniTask PlayRollDice(int diceNum)
	{
		DangoMonopolyRollDiceView.<PlayRollDice>d__19 <PlayRollDice>d__;
		<PlayRollDice>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayRollDice>d__.<>4__this = this;
		<PlayRollDice>d__.diceNum = diceNum;
		<PlayRollDice>d__.<>1__state = -1;
		<PlayRollDice>d__.<>t__builder.Start<DangoMonopolyRollDiceView.<PlayRollDice>d__19>(ref <PlayRollDice>d__);
		return <PlayRollDice>d__.<>t__builder.Task;
	}

	// Token: 0x06008426 RID: 33830 RVA: 0x0022E758 File Offset: 0x0022C958
	public string GetDebugText(string suffix)
	{
		DangoMonopolyRollDiceViewParam openParam = this.OpenParam;
		int value = (openParam != null) ? openParam.DiceResult : 1;
		DangoMonopolyRollDiceViewParam openParam2 = this.OpenParam;
		int valueOrDefault = ((openParam2 != null) ? openParam2.TriggerBuffId : null).GetValueOrDefault();
		DangoMonopolyRollDiceViewParam openParam3 = this.OpenParam;
		int valueOrDefault2 = ((openParam3 != null) ? openParam3.TriggerBuffResult : null).GetValueOrDefault();
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(21, 4);
		defaultInterpolatedStringHandler.AppendLiteral("骰子: ");
		defaultInterpolatedStringHandler.AppendFormatted<int>(value);
		defaultInterpolatedStringHandler.AppendLiteral(", 特性id: ");
		defaultInterpolatedStringHandler.AppendFormatted<int>(valueOrDefault);
		defaultInterpolatedStringHandler.AppendLiteral(", 特性结果: ");
		defaultInterpolatedStringHandler.AppendFormatted<int>(valueOrDefault2);
		defaultInterpolatedStringHandler.AppendLiteral("\n");
		defaultInterpolatedStringHandler.AppendFormatted(suffix);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06008427 RID: 33831 RVA: 0x0022E820 File Offset: 0x0022CA20
	public void DiceAnimStart()
	{
		Singleton<Log>.Instance.Info(ELogModule.DangoMonopoly, ELogAuthor.CX, "RollDice=>掷骰子动画开始", default(ReadOnlySpan<ValueTuple<string, object>>));
		this.SetDiceVisible(true);
	}

	// Token: 0x06008428 RID: 33832 RVA: 0x0022E854 File Offset: 0x0022CA54
	public void DiceAnimEnd()
	{
		Singleton<Log>.Instance.Info(ELogModule.DangoMonopoly, ELogAuthor.CX, "RollDice=>掷骰子动画结束", default(ReadOnlySpan<ValueTuple<string, object>>));
		this.IsRollDiceFinish = true;
		BP_DiceOL_C diceOutlineBp = this.ActivityData.RollDice.DiceOutlineBp;
		if (diceOutlineBp != null)
		{
			diceOutlineBp.SetActorHiddenInGame(true);
		}
		base.CloseMe(null);
	}

	// Token: 0x06008429 RID: 33833 RVA: 0x0022E8AC File Offset: 0x0022CAAC
	public UniTask CheckTriggerBuff()
	{
		DangoMonopolyRollDiceView.<CheckTriggerBuff>d__23 <CheckTriggerBuff>d__;
		<CheckTriggerBuff>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CheckTriggerBuff>d__.<>4__this = this;
		<CheckTriggerBuff>d__.<>1__state = -1;
		<CheckTriggerBuff>d__.<>t__builder.Start<DangoMonopolyRollDiceView.<CheckTriggerBuff>d__23>(ref <CheckTriggerBuff>d__);
		return <CheckTriggerBuff>d__.<>t__builder.Task;
	}

	// Token: 0x0600842A RID: 33834 RVA: 0x0022E8F0 File Offset: 0x0022CAF0
	public UniTask PlayBuffEffect(int buffId)
	{
		DangoMonopolyRollDiceView.<PlayBuffEffect>d__24 <PlayBuffEffect>d__;
		<PlayBuffEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayBuffEffect>d__.<>4__this = this;
		<PlayBuffEffect>d__.buffId = buffId;
		<PlayBuffEffect>d__.<>1__state = -1;
		<PlayBuffEffect>d__.<>t__builder.Start<DangoMonopolyRollDiceView.<PlayBuffEffect>d__24>(ref <PlayBuffEffect>d__);
		return <PlayBuffEffect>d__.<>t__builder.Task;
	}

	// Token: 0x0600842B RID: 33835 RVA: 0x0022E93C File Offset: 0x0022CB3C
	public UniTask AgainPlayRollDice()
	{
		DangoMonopolyRollDiceView.<AgainPlayRollDice>d__25 <AgainPlayRollDice>d__;
		<AgainPlayRollDice>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<AgainPlayRollDice>d__.<>4__this = this;
		<AgainPlayRollDice>d__.<>1__state = -1;
		<AgainPlayRollDice>d__.<>t__builder.Start<DangoMonopolyRollDiceView.<AgainPlayRollDice>d__25>(ref <AgainPlayRollDice>d__);
		return <AgainPlayRollDice>d__.<>t__builder.Task;
	}

	// Token: 0x0600842C RID: 33836 RVA: 0x0022E980 File Offset: 0x0022CB80
	public UniTask MoreStep()
	{
		DangoMonopolyRollDiceView.<MoreStep>d__26 <MoreStep>d__;
		<MoreStep>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<MoreStep>d__.<>4__this = this;
		<MoreStep>d__.<>1__state = -1;
		<MoreStep>d__.<>t__builder.Start<DangoMonopolyRollDiceView.<MoreStep>d__26>(ref <MoreStep>d__);
		return <MoreStep>d__.<>t__builder.Task;
	}

	// Token: 0x0600842D RID: 33837 RVA: 0x0022E9C4 File Offset: 0x0022CBC4
	public UniTask PointDouble()
	{
		DangoMonopolyRollDiceView.<PointDouble>d__27 <PointDouble>d__;
		<PointDouble>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PointDouble>d__.<>4__this = this;
		<PointDouble>d__.<>1__state = -1;
		<PointDouble>d__.<>t__builder.Start<DangoMonopolyRollDiceView.<PointDouble>d__27>(ref <PointDouble>d__);
		return <PointDouble>d__.<>t__builder.Task;
	}

	// Token: 0x0600842E RID: 33838 RVA: 0x0022EA08 File Offset: 0x0022CC08
	public UniTask PointReplace(int? point = null)
	{
		DangoMonopolyRollDiceView.<PointReplace>d__28 <PointReplace>d__;
		<PointReplace>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PointReplace>d__.<>4__this = this;
		<PointReplace>d__.point = point;
		<PointReplace>d__.<>1__state = -1;
		<PointReplace>d__.<>t__builder.Start<DangoMonopolyRollDiceView.<PointReplace>d__28>(ref <PointReplace>d__);
		return <PointReplace>d__.<>t__builder.Task;
	}

	// Token: 0x0600842F RID: 33839 RVA: 0x0022EA53 File Offset: 0x0022CC53
	public void SetDiceVisible(bool visible)
	{
		base.GetItem(3).SetUIActive(visible);
	}

	// Token: 0x06008430 RID: 33840 RVA: 0x0022EA64 File Offset: 0x0022CC64
	public UniTask WaitAutoTime()
	{
		DangoMonopolyRollDiceView.<WaitAutoTime>d__30 <WaitAutoTime>d__;
		<WaitAutoTime>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<WaitAutoTime>d__.<>4__this = this;
		<WaitAutoTime>d__.<>1__state = -1;
		<WaitAutoTime>d__.<>t__builder.Start<DangoMonopolyRollDiceView.<WaitAutoTime>d__30>(ref <WaitAutoTime>d__);
		return <WaitAutoTime>d__.<>t__builder.Task;
	}

	// Token: 0x04003EBB RID: 16059
	public bool IsRollDiceFinish;

	// Token: 0x04003EBC RID: 16060
	public DangoMonopolyDiceBuffPanel DiceBuffPanel;

	// Token: 0x04003EBD RID: 16061
	public readonly float AutoWaitTime = 1000f;

	// Token: 0x0200769B RID: 30363
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x04028DD8 RID: 167384
		BtnSpeed,
		// Token: 0x04028DD9 RID: 167385
		TxtSpeedTitle,
		// Token: 0x04028DDA RID: 167386
		BtnEmpty,
		// Token: 0x04028DDB RID: 167387
		DiceRoot,
		// Token: 0x04028DDC RID: 167388
		TextureDice,
		// Token: 0x04028DDD RID: 167389
		TxtDebug,
		// Token: 0x04028DDE RID: 167390
		ItemBuffPos
	}
}
