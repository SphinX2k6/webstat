using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.CommonH5
{
	// Token: 0x020069B5 RID: 27061
	[NullableContext(2)]
	[Nullable(0)]
	public class CommonH5SubView : ActivitySubViewBase
	{
		// Token: 0x06043197 RID: 274839 RVA: 0x0113BBBC File Offset: 0x01139DBC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06043198 RID: 274840 RVA: 0x0113BC28 File Offset: 0x01139E28
		protected override UniTask OnBeforeStartAsync()
		{
			CommonH5SubView.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<CommonH5SubView.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06043199 RID: 274841 RVA: 0x0113BC6C File Offset: 0x01139E6C
		protected override void OnBeforeShow()
		{
			this.RefreshRedDot();
			this.CommonInfoPanel.SetBtnText("Activity_Exploration_Go", Array.Empty<object>());
			this.UiSequencePlayer.PlaySequenceAsync("Start", new CustomPromise<bool>(), false, false, null).Forget();
		}

		// Token: 0x0604319A RID: 274842 RVA: 0x0113BCB9 File Offset: 0x01139EB9
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.RefreshCommonH5ActivityRedDot, new Action(this.OnDataUpdate));
		}

		// Token: 0x0604319B RID: 274843 RVA: 0x0113BCD7 File Offset: 0x01139ED7
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RefreshCommonH5ActivityRedDot, new Action(this.OnDataUpdate));
		}

		// Token: 0x0604319C RID: 274844 RVA: 0x0113BCF5 File Offset: 0x01139EF5
		private void OnDataUpdate()
		{
			this.RefreshRedDot();
		}

		// Token: 0x0604319D RID: 274845 RVA: 0x0113BD00 File Offset: 0x01139F00
		private void RefreshRedDot()
		{
			bool redPointShowState = (this.ActivityBaseData as CommonH5Data).RedPointShowState;
			this.CommonInfoPanel.SetFunctionRedDotVisible(redPointShowState);
		}

		// Token: 0x0604319E RID: 274846 RVA: 0x0113BD2C File Offset: 0x01139F2C
		private void ClickCommonInfo(ActivityBaseData _)
		{
			CommonH5Data activityData = this.ActivityBaseData as CommonH5Data;
			ControllerBase<CommonH5Controller>.Instance.HandleOnEnterClick(activityData);
		}

		// Token: 0x0604319F RID: 274847 RVA: 0x0113BD50 File Offset: 0x01139F50
		private bool ShowReceivedCallBack(TItem _)
		{
			return (this.ActivityBaseData as CommonH5Data).GetRewardClaimState();
		}

		// Token: 0x0402564D RID: 153165
		protected ActivitySubViewGeneralInfo CommonInfoPanel;

		// Token: 0x0402564E RID: 153166
		private UiSequencePlayer UiSequencePlayer;
	}
}
