using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.AutoPilot
{
	// Token: 0x0200614D RID: 24909
	public class AutoPilotStateView : UiPanelBase
	{
		// Token: 0x0603EEE5 RID: 257765 RVA: 0x010217A4 File Offset: 0x0101F9A4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603EEE6 RID: 257766 RVA: 0x0102182E File Offset: 0x0101FA2E
		protected override void OnStart()
		{
			this.SequencePlayer = new UiSequencePlayer(base.GetRootItem());
			this.SetState();
		}

		// Token: 0x0603EEE7 RID: 257767 RVA: 0x01021848 File Offset: 0x0101FA48
		protected override void OnBeforeShow()
		{
			UiSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer == null)
			{
				return;
			}
			sequencePlayer.PlaySequence("Start", false, null);
		}

		// Token: 0x0603EEE8 RID: 257768 RVA: 0x01021874 File Offset: 0x0101FA74
		private void SetState()
		{
			AutoPilotModel instance = ModelBase<AutoPilotModel>.Instance;
			AutoPilotDefine.EAutoPilotState? eautoPilotState = (instance != null) ? new AutoPilotDefine.EAutoPilotState?(instance.GetAutoPilotState()) : null;
			UUIItem item = base.GetItem(0);
			if (item != null)
			{
				item.SetUIActive(eautoPilotState.GetValueOrDefault() == AutoPilotDefine.EAutoPilotState.Dest);
			}
			UUIItem item2 = base.GetItem(1);
			if (item2 != null)
			{
				item2.SetUIActive(eautoPilotState.GetValueOrDefault() == AutoPilotDefine.EAutoPilotState.Loop);
			}
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(2), (eautoPilotState.GetValueOrDefault() == AutoPilotDefine.EAutoPilotState.Dest) ? AutoPilotDefine.EAutoPilotTextId.TextDestState : AutoPilotDefine.EAutoPilotTextId.TextLoopState, Array.Empty<object>());
		}

		// Token: 0x0603EEE9 RID: 257769 RVA: 0x01021904 File Offset: 0x0101FB04
		protected override UniTask OnBeforeHideAsync()
		{
			AutoPilotStateView.<OnBeforeHideAsync>d__6 <OnBeforeHideAsync>d__;
			<OnBeforeHideAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeHideAsync>d__.<>4__this = this;
			<OnBeforeHideAsync>d__.<>1__state = -1;
			<OnBeforeHideAsync>d__.<>t__builder.Start<AutoPilotStateView.<OnBeforeHideAsync>d__6>(ref <OnBeforeHideAsync>d__);
			return <OnBeforeHideAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603EEEA RID: 257770 RVA: 0x01021947 File Offset: 0x0101FB47
		protected override void OnBeforeDestroy()
		{
			UiSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer == null)
			{
				return;
			}
			sequencePlayer.Clear();
		}

		// Token: 0x04023503 RID: 144643
		[Nullable(2)]
		private UiSequencePlayer SequencePlayer;

		// Token: 0x0200C2DB RID: 49883
		private enum EComponents
		{
			// Token: 0x0403C141 RID: 246081
			DestState,
			// Token: 0x0403C142 RID: 246082
			LoopState,
			// Token: 0x0403C143 RID: 246083
			TextState
		}
	}
}
