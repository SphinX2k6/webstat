using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200256C RID: 9580
[NullableContext(2)]
[Nullable(0)]
public class PhoneMsgPanelViewSmall : UiViewBase
{
	// Token: 0x06012A1B RID: 76315 RVA: 0x00522B53 File Offset: 0x00520D53
	[NullableContext(1)]
	public PhoneMsgPanelViewSmall(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06012A1C RID: 76316 RVA: 0x00522B5C File Offset: 0x00520D5C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action(this.OnClickCloseBtn))
		};
	}

	// Token: 0x06012A1D RID: 76317 RVA: 0x00522BF0 File Offset: 0x00520DF0
	protected override UniTask OnBeforeStartAsync()
	{
		PhoneMsgPanelViewSmall.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<PhoneMsgPanelViewSmall.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012A1E RID: 76318 RVA: 0x00522C34 File Offset: 0x00520E34
	private UniTask LoadChatDataAsync()
	{
		PhoneMsgPanelViewSmall.<LoadChatDataAsync>d__8 <LoadChatDataAsync>d__;
		<LoadChatDataAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<LoadChatDataAsync>d__.<>4__this = this;
		<LoadChatDataAsync>d__.<>1__state = -1;
		<LoadChatDataAsync>d__.<>t__builder.Start<PhoneMsgPanelViewSmall.<LoadChatDataAsync>d__8>(ref <LoadChatDataAsync>d__);
		return <LoadChatDataAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012A1F RID: 76319 RVA: 0x00522C77 File Offset: 0x00520E77
	protected override void OnStart()
	{
	}

	// Token: 0x06012A20 RID: 76320 RVA: 0x00522C79 File Offset: 0x00520E79
	protected override void OnBeforeShow()
	{
		Singleton<GameSettingsDeviceRender>.Instance.TemporaryDisableFrameGeneration("PhoneMsgPanelViewSmall");
	}

	// Token: 0x06012A21 RID: 76321 RVA: 0x00522C8A File Offset: 0x00520E8A
	protected override void OnAfterHide()
	{
		Singleton<GameSettingsDeviceRender>.Instance.CancelTemporaryDisableFrameGeneration("PhoneMsgPanelViewSmall");
	}

	// Token: 0x06012A22 RID: 76322 RVA: 0x00522C9C File Offset: 0x00520E9C
	[NullableContext(1)]
	private void PlayLevelSequenceByName(string sequenceName)
	{
		LevelSequencePlayer seqPlayer = this.SeqPlayer;
		if (seqPlayer != null)
		{
			seqPlayer.StopSequenceByKey(sequenceName, false, false);
		}
		LevelSequencePlayer seqPlayer2 = this.SeqPlayer;
		if (seqPlayer2 == null)
		{
			return;
		}
		seqPlayer2.PlayLevelSequenceByName(sequenceName, false, null, false);
	}

	// Token: 0x06012A23 RID: 76323 RVA: 0x00522CD9 File Offset: 0x00520ED9
	protected override void OnBeforeDestroy()
	{
		LevelSequencePlayer seqPlayer = this.SeqPlayer;
		if (seqPlayer != null)
		{
			seqPlayer.Clear();
		}
		this.SeqPlayer = null;
	}

	// Token: 0x06012A24 RID: 76324 RVA: 0x00522CF3 File Offset: 0x00520EF3
	private void OnClickCloseBtn()
	{
		base.CloseMe(null);
	}

	// Token: 0x04009192 RID: 37266
	private PhoneMsgPanelViewData MsgData;

	// Token: 0x04009193 RID: 37267
	private PhoneSystemChatPanel ChatPanel;

	// Token: 0x04009194 RID: 37268
	private PhoneMsgTipViewA PopTipViewA;

	// Token: 0x04009195 RID: 37269
	private LevelSequencePlayer SeqPlayer;

	// Token: 0x02008888 RID: 34952
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402E1D8 RID: 188888
		BtnMask,
		// Token: 0x0402E1D9 RID: 188889
		BtnClose,
		// Token: 0x0402E1DA RID: 188890
		PanelPhoneSystemChatPanel,
		// Token: 0x0402E1DB RID: 188891
		ItemPopA
	}
}
