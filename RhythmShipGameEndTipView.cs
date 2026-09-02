using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200114A RID: 4426
[NullableContext(1)]
[Nullable(0)]
public class RhythmShipGameEndTipView : UiViewBase
{
	// Token: 0x0600749C RID: 29852 RVA: 0x001E91E1 File Offset: 0x001E73E1
	public RhythmShipGameEndTipView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600749D RID: 29853 RVA: 0x001E9218 File Offset: 0x001E7418
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUITexture)),
			new ValueTuple<int, Type>(4, typeof(UUITexture)),
			new ValueTuple<int, Type>(5, typeof(UUIText))
		};
	}

	// Token: 0x0600749E RID: 29854 RVA: 0x001E92B4 File Offset: 0x001E74B4
	protected override void OnBeforeShow()
	{
		RhythmShipGameEndTipViewOpenParam rhythmShipGameEndTipViewOpenParam = this.OpenParam as RhythmShipGameEndTipViewOpenParam;
		if (rhythmShipGameEndTipViewOpenParam == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.RhythmGame, ELogAuthor.CH, "RhythmShipGameEndTipView OpenParam is undefined", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (rhythmShipGameEndTipViewOpenParam.Level < 1)
		{
			Singleton<Log>.Instance.Error(ELogModule.RhythmGame, ELogAuthor.CH, "RhythmShipGameEndTipView Level is less than 1", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(RhythmShipDefine.rhythmShipLevelRatingBgTexture[rhythmShipGameEndTipViewOpenParam.Level]);
		string resourcePath2 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(RhythmShipDefine.rhythmShipLevelRatingSettlementTexture[rhythmShipGameEndTipViewOpenParam.Level]);
		base.SetTextureByPath(resourcePath, base.GetTexture(3), null, null);
		base.SetTextureByPath(resourcePath2, base.GetTexture(4), null, null);
		if (rhythmShipGameEndTipViewOpenParam.IsFp)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), this.FpTextKey, Array.Empty<object>());
		}
		else if (rhythmShipGameEndTipViewOpenParam.IsFc)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), this.FcTextKey, Array.Empty<object>());
		}
		else
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), this.FinishTextKey, Array.Empty<object>());
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), this.AccuracyTextKey, new <>z__ReadOnlySingleElementList<object>(rhythmShipGameEndTipViewOpenParam.Accuracy.ToString()));
	}

	// Token: 0x0600749F RID: 29855 RVA: 0x001E9410 File Offset: 0x001E7610
	protected override void OnAfterPlayStartSequence()
	{
		TimerSystem.Instance.Delay(delegate(float _)
		{
			base.CloseMe(null);
		}, 500f, null, null, true, 1f);
	}

	// Token: 0x060074A0 RID: 29856 RVA: 0x001E9438 File Offset: 0x001E7638
	protected override void OnBeforePlayCloseSequence()
	{
		RhythmShipGameEndTipViewOpenParam rhythmShipGameEndTipViewOpenParam = this.OpenParam as RhythmShipGameEndTipViewOpenParam;
		if (rhythmShipGameEndTipViewOpenParam != null && rhythmShipGameEndTipViewOpenParam.Callback != null)
		{
			rhythmShipGameEndTipViewOpenParam.Callback();
		}
	}

	// Token: 0x060074A1 RID: 29857 RVA: 0x001E9468 File Offset: 0x001E7668
	protected override UniTask OnPlayingStartSequenceAsync()
	{
		RhythmShipGameEndTipView.<OnPlayingStartSequenceAsync>d__10 <OnPlayingStartSequenceAsync>d__;
		<OnPlayingStartSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnPlayingStartSequenceAsync>d__.<>4__this = this;
		<OnPlayingStartSequenceAsync>d__.<>1__state = -1;
		<OnPlayingStartSequenceAsync>d__.<>t__builder.Start<RhythmShipGameEndTipView.<OnPlayingStartSequenceAsync>d__10>(ref <OnPlayingStartSequenceAsync>d__);
		return <OnPlayingStartSequenceAsync>d__.<>t__builder.Task;
	}

	// Token: 0x04003847 RID: 14407
	private readonly string FcTextKey = "RhythmStageClear_02";

	// Token: 0x04003848 RID: 14408
	private readonly string FpTextKey = "RhythmStageClear_03";

	// Token: 0x04003849 RID: 14409
	private readonly string FinishTextKey = "RhythmStageClear_01";

	// Token: 0x0400384A RID: 14410
	private readonly string AccuracyTextKey = "PrefabTextItem_1492520868_Text";

	// Token: 0x020074D4 RID: 29908
	[NullableContext(0)]
	private enum EViewComponent
	{
		// Token: 0x04028548 RID: 165192
		BtnMask,
		// Token: 0x04028549 RID: 165193
		TxtTitle,
		// Token: 0x0402854A RID: 165194
		TxtAchieve,
		// Token: 0x0402854B RID: 165195
		TexLevelBg,
		// Token: 0x0402854C RID: 165196
		TexLevelIcon,
		// Token: 0x0402854D RID: 165197
		TxtLevel
	}
}
