using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Core.Extension;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Interaction;
using CSharpScript.Game.Module.Plot.Flow;
using CSharpScript.Game.Module.Plot.Sequence;
using CSharpScript.Game.Module.Teleport;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Plot.FlowActions
{
	// Token: 0x02005439 RID: 21561
	[NullableContext(2)]
	[Nullable(0)]
	public class FlowActionSetPlotMode : FlowActionBase
	{
		// Token: 0x06036FA9 RID: 225193 RVA: 0x00DF4C60 File Offset: 0x00DF2E60
		protected unsafe override void OnExecute()
		{
			this.DelayBlendInDialogueCamera = this.Context.HasAdjustCamera;
			SetPlotMode setPlotMode = this.ActionInfo.Params as SetPlotMode;
			if (this.Context != null)
			{
				this.Context.TalkHistory.Clear();
			}
			ModelBase<PlotModel>.Instance.PlotConfig.SetMode(setPlotMode, false);
			ModelBase<PlotModel>.Instance.ApplyPlotConfig(this.DelayBlendInDialogueCamera);
			this.NeedFade = setPlotMode.FastFadeIn;
			this.Context.IsWaitRenderData = (!setPlotMode.NoUiEnterAnimation.GetValueOrDefault() && !this.Context.SeamlessPlot);
			ModelBase<SequenceModel>.Instance.SkipUiWaiting = this.Context.SeamlessPlot;
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Plot;
			ELogAuthor author = ELogAuthor.FZX;
			string message = "SetPlotMode";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Level", setPlotMode.Mode);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ChangeRole", setPlotMode.IsSwitchMainRole);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("DisableAutoFadeOut", setPlotMode.DisableAutoFadeOut);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			UiParam uiParam = this.Context.UiParam;
			if (uiParam != null && uiParam.ViewName != null && !Singleton<UiManager>.Instance.IsViewShow(this.Context.UiParam.ViewName.Value))
			{
				global::Log instance2 = Singleton<global::Log>.Instance;
				ELogModule module2 = ELogModule.Plot;
				ELogAuthor author2 = ELogAuthor.FZX;
				string message2 = "剧情界面所依赖的界面未打开，本段剧情跳过";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ViewName", this.Context.UiParam.ViewName);
				instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				this.Context.IsBackground = true;
				base.FinishExecute(true, true);
				return;
			}
			FlowContext context = this.Context;
			if (context != null && context.SeamlessPlot && (setPlotMode.Mode == EPlotLevel.LevelA.ToEnumString() || setPlotMode.Mode == EPlotLevel.LevelB.ToEnumString()))
			{
				Singleton<PlotSequenceInertiaKeeper>.Instance.Start("FlowActionSetPlotMode.OnExecute");
			}
			FlowContext context2 = this.Context;
			this.CacheNeedPreloadUiSequenceData = ((context2 != null) ? context2.NeedPreloadUiSequenceData : null);
			Singleton<EventSystem>.Instance.Emit(EEventName.OnExecuteAfterSetPlotMode);
			UniTask.WhenAll(new List<UniTask>
			{
				this.WaitInteractTurnAndChangeRoleAsync(),
				this.CheckPosSafe(),
				this.LoadTypeAsync(),
				this.HandleViewAsync(setPlotMode)
			}).Finally(delegate()
			{
				base.FinishExecute(true, true);
			}).Forget();
		}

		// Token: 0x06036FAA RID: 225194 RVA: 0x00DF4EF4 File Offset: 0x00DF30F4
		[NullableContext(1)]
		private UniTask HandleViewAsync(SetPlotMode inSetPlotMode)
		{
			FlowActionSetPlotMode.<HandleViewAsync>d__11 <HandleViewAsync>d__;
			<HandleViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<HandleViewAsync>d__.<>4__this = this;
			<HandleViewAsync>d__.inSetPlotMode = inSetPlotMode;
			<HandleViewAsync>d__.<>1__state = -1;
			<HandleViewAsync>d__.<>t__builder.Start<FlowActionSetPlotMode.<HandleViewAsync>d__11>(ref <HandleViewAsync>d__);
			return <HandleViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036FAB RID: 225195 RVA: 0x00DF4F40 File Offset: 0x00DF3140
		private UniTask LoadTypeAsync()
		{
			FlowActionSetPlotMode.<LoadTypeAsync>d__12 <LoadTypeAsync>d__;
			<LoadTypeAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadTypeAsync>d__.<>1__state = -1;
			<LoadTypeAsync>d__.<>t__builder.Start<FlowActionSetPlotMode.<LoadTypeAsync>d__12>(ref <LoadTypeAsync>d__);
			return <LoadTypeAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036FAC RID: 225196 RVA: 0x00DF4F7C File Offset: 0x00DF317C
		private UniTask WaitInteractTurnAndChangeRoleAsync()
		{
			FlowActionSetPlotMode.<WaitInteractTurnAndChangeRoleAsync>d__13 <WaitInteractTurnAndChangeRoleAsync>d__;
			<WaitInteractTurnAndChangeRoleAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<WaitInteractTurnAndChangeRoleAsync>d__.<>4__this = this;
			<WaitInteractTurnAndChangeRoleAsync>d__.<>1__state = -1;
			<WaitInteractTurnAndChangeRoleAsync>d__.<>t__builder.Start<FlowActionSetPlotMode.<WaitInteractTurnAndChangeRoleAsync>d__13>(ref <WaitInteractTurnAndChangeRoleAsync>d__);
			return <WaitInteractTurnAndChangeRoleAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036FAD RID: 225197 RVA: 0x00DF4FC0 File Offset: 0x00DF31C0
		private UniTask OpenViewAsync()
		{
			FlowActionSetPlotMode.<OpenViewAsync>d__14 <OpenViewAsync>d__;
			<OpenViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OpenViewAsync>d__.<>4__this = this;
			<OpenViewAsync>d__.<>1__state = -1;
			<OpenViewAsync>d__.<>t__builder.Start<FlowActionSetPlotMode.<OpenViewAsync>d__14>(ref <OpenViewAsync>d__);
			return <OpenViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036FAE RID: 225198 RVA: 0x00DF5004 File Offset: 0x00DF3204
		private UniTask PreloadSequenceUiAsync()
		{
			FlowActionSetPlotMode.<PreloadSequenceUiAsync>d__15 <PreloadSequenceUiAsync>d__;
			<PreloadSequenceUiAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PreloadSequenceUiAsync>d__.<>4__this = this;
			<PreloadSequenceUiAsync>d__.<>1__state = -1;
			<PreloadSequenceUiAsync>d__.<>t__builder.Start<FlowActionSetPlotMode.<PreloadSequenceUiAsync>d__15>(ref <PreloadSequenceUiAsync>d__);
			return <PreloadSequenceUiAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036FAF RID: 225199 RVA: 0x00DF5048 File Offset: 0x00DF3248
		private UniTask WaitFadeIn()
		{
			FlowActionSetPlotMode.<WaitFadeIn>d__16 <WaitFadeIn>d__;
			<WaitFadeIn>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<WaitFadeIn>d__.<>4__this = this;
			<WaitFadeIn>d__.<>1__state = -1;
			<WaitFadeIn>d__.<>t__builder.Start<FlowActionSetPlotMode.<WaitFadeIn>d__16>(ref <WaitFadeIn>d__);
			return <WaitFadeIn>d__.<>t__builder.Task;
		}

		// Token: 0x06036FB0 RID: 225200 RVA: 0x00DF508C File Offset: 0x00DF328C
		private UniTask WaitInteractTurnPromise()
		{
			FlowActionSetPlotMode.<WaitInteractTurnPromise>d__17 <WaitInteractTurnPromise>d__;
			<WaitInteractTurnPromise>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<WaitInteractTurnPromise>d__.<>4__this = this;
			<WaitInteractTurnPromise>d__.<>1__state = -1;
			<WaitInteractTurnPromise>d__.<>t__builder.Start<FlowActionSetPlotMode.<WaitInteractTurnPromise>d__17>(ref <WaitInteractTurnPromise>d__);
			return <WaitInteractTurnPromise>d__.<>t__builder.Task;
		}

		// Token: 0x06036FB1 RID: 225201 RVA: 0x00DF50D0 File Offset: 0x00DF32D0
		private void OnCheckTurn(float deltaTime)
		{
			if (ModelBase<InteractionModel>.Instance.IsInteractionTurning && this.WaitTurnTime < 3000f)
			{
				this.WaitTurnTime += deltaTime;
				return;
			}
			ControllerBase<PlotController>.Instance.RemoveTick(this.WaitTurnTicker);
			this.WaitTurnTime = 0f;
			this.WaitTurnTicker = -1;
			this.WaitTurnPromise.SetResult();
			this.WaitTurnPromise = null;
		}

		// Token: 0x06036FB2 RID: 225202 RVA: 0x00DF513C File Offset: 0x00DF333C
		private UniTask CheckPosSafe()
		{
			FlowActionSetPlotMode.<CheckPosSafe>d__19 <CheckPosSafe>d__;
			<CheckPosSafe>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CheckPosSafe>d__.<>4__this = this;
			<CheckPosSafe>d__.<>1__state = -1;
			<CheckPosSafe>d__.<>t__builder.Start<FlowActionSetPlotMode.<CheckPosSafe>d__19>(ref <CheckPosSafe>d__);
			return <CheckPosSafe>d__.<>t__builder.Task;
		}

		// Token: 0x06036FB3 RID: 225203 RVA: 0x00DF5180 File Offset: 0x00DF3380
		private void OnTeleportComplete(TeleportContext context = null)
		{
			Singleton<global::Log>.Instance.Info(ELogModule.Plot, ELogAuthor.FZX, "剧情前保底传送 -结束", default(ReadOnlySpan<ValueTuple<string, object>>));
			CustomPromise teleportPromise = this.TeleportPromise;
			this.TeleportPromise = null;
			teleportPromise.SetResult();
		}

		// Token: 0x06036FB4 RID: 225204 RVA: 0x00DF51BC File Offset: 0x00DF33BC
		protected override void OnInterruptExecute()
		{
			if (Singleton<EventSystem>.Instance.Has<TeleportContext>(EEventName.TeleportComplete, new Action<TeleportContext>(this.OnTeleportComplete)))
			{
				Singleton<EventSystem>.Instance.Remove<TeleportContext>(EEventName.TeleportComplete, new Action<TeleportContext>(this.OnTeleportComplete));
				this.OnTeleportComplete(null);
			}
		}

		// Token: 0x06036FB5 RID: 225205 RVA: 0x00DF520C File Offset: 0x00DF340C
		protected override void OnBackgroundExecute()
		{
			SetPlotMode setPlotMode = this.ActionInfo.Params as SetPlotMode;
			ModelBase<PlotModel>.Instance.PlotConfig.SetMode(setPlotMode, false);
			ModelBase<PlotModel>.Instance.ApplyPlotConfig(this.DelayBlendInDialogueCamera);
			ModelBase<PlotModel>.Instance.IsFadeIn = (setPlotMode.FastFadeIn != null);
			base.FinishExecute(true, true);
		}

		// Token: 0x0401FA07 RID: 129543
		private const float GUARANTEED_WAIT_TIME = 3000f;

		// Token: 0x0401FA08 RID: 129544
		private const float DEFAULT_FADE_DURATION = 0.5f;

		// Token: 0x0401FA09 RID: 129545
		private const float SAFE_DISTANCE_SQAURED = 3000f;

		// Token: 0x0401FA0A RID: 129546
		private bool DelayBlendInDialogueCamera;

		// Token: 0x0401FA0B RID: 129547
		private CustomPromise WaitTurnPromise;

		// Token: 0x0401FA0C RID: 129548
		private int WaitTurnTicker = -1;

		// Token: 0x0401FA0D RID: 129549
		private float WaitTurnTime;

		// Token: 0x0401FA0E RID: 129550
		private FadeInScreen NeedFade;

		// Token: 0x0401FA0F RID: 129551
		private CustomPromise TeleportPromise;

		// Token: 0x0401FA10 RID: 129552
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<string> CacheNeedPreloadUiSequenceData;
	}
}
