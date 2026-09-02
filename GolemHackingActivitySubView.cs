using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020010BF RID: 4287
public class GolemHackingActivitySubView : ActivitySubViewBase
{
	// Token: 0x06006F96 RID: 28566 RVA: 0x001D08A0 File Offset: 0x001CEAA0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIArtText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06006F97 RID: 28567 RVA: 0x001D094C File Offset: 0x001CEB4C
	protected override UniTask OnBeforeStartAsync()
	{
		GolemHackingActivitySubView.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<GolemHackingActivitySubView.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06006F98 RID: 28568 RVA: 0x001D0990 File Offset: 0x001CEB90
	protected override void OnRefreshView()
	{
		GolemHackingActivityData activityData = ControllerBase<GolemHackingController>.Instance.GetActivityData();
		this.CommonInfoPanel.SetFunctionRedDotVisible(activityData.RedPointShowState);
		ValueTuple<int, int> groupProgressState = activityData.GetGroupProgressState();
		int item = groupProgressState.Item1;
		int item2 = groupProgressState.Item2;
		UUIArtText artText = base.GetArtText(1);
		if (artText != null)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
			defaultInterpolatedStringHandler.AppendFormatted<int>(item);
			artText.SetText(defaultInterpolatedStringHandler.ToStringAndClear());
		}
		UUIText text = base.GetText(2);
		if (text != null)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
			defaultInterpolatedStringHandler.AppendFormatted<int>(item2);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}
		UUITexture texture = base.GetTexture(3);
		if (texture != null)
		{
			texture.SetFillAmount((float)item / (float)item2);
		}
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.ActivityBaseData.Id);
	}

	// Token: 0x06006F99 RID: 28569 RVA: 0x001D0A53 File Offset: 0x001CEC53
	[NullableContext(2)]
	private void OnClickedConfirm(ActivityBaseData _)
	{
		if (ModelBase<GameModeModel>.Instance.IsMulti)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("IntrusionProtocolActivity_CoopBlockTips", Array.Empty<object>());
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.GolemHackingLevelMainView, null, null);
	}

	// Token: 0x0400359E RID: 13726
	[Nullable(1)]
	protected ActivitySubViewGeneralInfo CommonInfoPanel;

	// Token: 0x0200744C RID: 29772
	private enum EDefine
	{
		// Token: 0x04028348 RID: 164680
		CommonActivityInfoItem,
		// Token: 0x04028349 RID: 164681
		ArtTxtCur,
		// Token: 0x0402834A RID: 164682
		TxtTarget,
		// Token: 0x0402834B RID: 164683
		TexFill
	}
}
