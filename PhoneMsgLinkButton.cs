using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.PhoneMessage;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200257D RID: 9597
public class PhoneMsgLinkButton : UiPanelBase
{
	// Token: 0x06012AA0 RID: 76448 RVA: 0x0052551C File Offset: 0x0052371C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnBtnPhoneCardClick))
		};
	}

	// Token: 0x06012AA1 RID: 76449 RVA: 0x00525599 File Offset: 0x00523799
	[NullableContext(1)]
	public void RefreshContent(string textKey, int infoId, PhoneMsgChatData data)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textKey, Array.Empty<object>());
		this.InfoId = infoId;
		this.Data = data;
	}

	// Token: 0x06012AA2 RID: 76450 RVA: 0x005255C0 File Offset: 0x005237C0
	private void OnBtnPhoneCardClick()
	{
		ControllerBase<InfoDisplayController>.Instance.OpenInfoDisplay(this.InfoId, null, null, false, null);
		PhoneMsgShortMsgData phoneMsgShortMsgDataByShortMsgId = ModelBase<PhoneMsgModel>.Instance.GetPhoneMsgShortMsgDataByShortMsgId(this.Data.ShortMessageId);
		ShortMessage? phoneMsgConfig = ConfigBase<PhoneMsgConfig>.Instance.GetPhoneMsgConfig(this.Data.ShortMessageId);
		if (phoneMsgShortMsgDataByShortMsgId == null || phoneMsgConfig == null)
		{
			return;
		}
		OnClickShortMessageLogEvent onClickShortMessageLogEvent = new OnClickShortMessageLogEvent();
		onClickShortMessageLogEvent.i_id = this.Data.ShortMessageId;
		onClickShortMessageLogEvent.i_type = (this.Data.IsGroupChat ? 1 : 2);
		onClickShortMessageLogEvent.i_role_id = phoneMsgConfig.Value.WhichChat;
		onClickShortMessageLogEvent.l_received_time = phoneMsgShortMsgDataByShortMsgId.UnLockTime;
		onClickShortMessageLogEvent.i_config_id = this.InfoId;
		ControllerBase<LogReportController>.Instance.LogReport(onClickShortMessageLogEvent);
	}

	// Token: 0x040091D5 RID: 37333
	[Nullable(2)]
	protected PhoneMsgChatData Data;

	// Token: 0x040091D6 RID: 37334
	private int InfoId;
}
