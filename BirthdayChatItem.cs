using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.PhoneMessage;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002582 RID: 9602
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class BirthdayChatItem : SyncGridProxyAbstract<PhoneMsgChatData>
{
	// Token: 0x06012AB8 RID: 76472 RVA: 0x00525BC0 File Offset: 0x00523DC0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(4, typeof(UUISprite)),
			new ValueTuple<int, Type>(5, typeof(UUITexture)),
			new ValueTuple<int, Type>(6, typeof(UUITextureTransitionComponent)),
			new ValueTuple<int, Type>(7, typeof(UUITextureTransitionComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(3, new Action(this.OnGoToClick))
		};
	}

	// Token: 0x06012AB9 RID: 76473 RVA: 0x00525CAC File Offset: 0x00523EAC
	protected override void OnStart()
	{
		base.GetSprite(4).SetUIActive(false);
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		base.GetButton(3).RootUIComp.Get().SetUIActive(true);
	}

	// Token: 0x06012ABA RID: 76474 RVA: 0x00525CF4 File Offset: 0x00523EF4
	public override void Refresh(PhoneMsgChatData data)
	{
		this.PhoneMsgChatData = data;
		if (ConfigBirthDayByItemId.GetConfig(data.BirthdayCardItemId, true) == null)
		{
			return;
		}
		UiAsyncTask task = new UiAsyncTask("BirthdayChatItem.UpdateBirthdayItemAs", () => this.UpdateBirthdayItemAsync(data), null);
		base.RunAsyncTask(task);
	}

	// Token: 0x06012ABB RID: 76475 RVA: 0x00525D60 File Offset: 0x00523F60
	private UniTask UpdateBirthdayItemAsync(PhoneMsgChatData data)
	{
		BirthdayChatItem.<UpdateBirthdayItemAsync>d__7 <UpdateBirthdayItemAsync>d__;
		<UpdateBirthdayItemAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<UpdateBirthdayItemAsync>d__.<>4__this = this;
		<UpdateBirthdayItemAsync>d__.data = data;
		<UpdateBirthdayItemAsync>d__.<>1__state = -1;
		<UpdateBirthdayItemAsync>d__.<>t__builder.Start<BirthdayChatItem.<UpdateBirthdayItemAsync>d__7>(ref <UpdateBirthdayItemAsync>d__);
		return <UpdateBirthdayItemAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012ABC RID: 76476 RVA: 0x00525DAC File Offset: 0x00523FAC
	[return: Nullable(new byte[]
	{
		0,
		2
	})]
	private UniTask<UTexture> LoadTextureAsyncWithCancel(string path)
	{
		BirthdayChatItem.<LoadTextureAsyncWithCancel>d__8 <LoadTextureAsyncWithCancel>d__;
		<LoadTextureAsyncWithCancel>d__.<>t__builder = AsyncUniTaskMethodBuilder<UTexture>.Create();
		<LoadTextureAsyncWithCancel>d__.<>4__this = this;
		<LoadTextureAsyncWithCancel>d__.path = path;
		<LoadTextureAsyncWithCancel>d__.<>1__state = -1;
		<LoadTextureAsyncWithCancel>d__.<>t__builder.Start<BirthdayChatItem.<LoadTextureAsyncWithCancel>d__8>(ref <LoadTextureAsyncWithCancel>d__);
		return <LoadTextureAsyncWithCancel>d__.<>t__builder.Task;
	}

	// Token: 0x06012ABD RID: 76477 RVA: 0x00525DF8 File Offset: 0x00523FF8
	private void OnGoToClick()
	{
		if (this.PhoneMsgChatData == null)
		{
			return;
		}
		int birthdayCardItemId = this.PhoneMsgChatData.BirthdayCardItemId;
		if (birthdayCardItemId == 0)
		{
			return;
		}
		ControllerBase<BirthdayController>.Instance.UseBirthdayItem(birthdayCardItemId);
		ShortMessage? phoneMsgConfig = ConfigBase<PhoneMsgConfig>.Instance.GetPhoneMsgConfig(this.PhoneMsgChatData.ShortMessageId);
		if (phoneMsgConfig == null)
		{
			return;
		}
		PhoneMsgShortMsgData phoneMsgShortMsgDataByShortMsgId = ModelBase<PhoneMsgModel>.Instance.GetPhoneMsgShortMsgDataByShortMsgId(this.PhoneMsgChatData.ShortMessageId);
		long l_received_time = 0L;
		if (phoneMsgShortMsgDataByShortMsgId != null)
		{
			l_received_time = phoneMsgShortMsgDataByShortMsgId.UnLockTime;
		}
		OnJumpInShortMessageLogEvent onJumpInShortMessageLogEvent = new OnJumpInShortMessageLogEvent();
		onJumpInShortMessageLogEvent.i_id = this.PhoneMsgChatData.ShortMessageId;
		onJumpInShortMessageLogEvent.i_type = (this.PhoneMsgChatData.IsGroupChat ? 1 : 2);
		onJumpInShortMessageLogEvent.i_role_id = phoneMsgConfig.Value.WhichChat;
		onJumpInShortMessageLogEvent.l_received_time = l_received_time;
		onJumpInShortMessageLogEvent.i_trigger_type = 2;
		ControllerBase<LogReportController>.Instance.LogReport(onJumpInShortMessageLogEvent);
	}

	// Token: 0x06012ABE RID: 76478 RVA: 0x00525ED0 File Offset: 0x005240D0
	public UniTask PlayBirthdayAnimationAsync()
	{
		BirthdayChatItem.<PlayBirthdayAnimationAsync>d__10 <PlayBirthdayAnimationAsync>d__;
		<PlayBirthdayAnimationAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayBirthdayAnimationAsync>d__.<>4__this = this;
		<PlayBirthdayAnimationAsync>d__.<>1__state = -1;
		<PlayBirthdayAnimationAsync>d__.<>t__builder.Start<BirthdayChatItem.<PlayBirthdayAnimationAsync>d__10>(ref <PlayBirthdayAnimationAsync>d__);
		return <PlayBirthdayAnimationAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012ABF RID: 76479 RVA: 0x00525F13 File Offset: 0x00524113
	public void StopBirthdayAnimation()
	{
		this.LevelSequencePlayer.StopSequenceByKey("In", false, true);
	}

	// Token: 0x06012AC0 RID: 76480 RVA: 0x00525F28 File Offset: 0x00524128
	protected override void OnBeforeDestroy()
	{
		foreach (KeyValuePair<string, int> keyValuePair in this.TextureLoadResourceIds)
		{
			if (keyValuePair.Value != -1)
			{
				Singleton<ResourceSystem>.Instance.CancelAsyncLoad(keyValuePair.Value);
			}
		}
		this.TextureLoadResourceIds.Clear();
	}

	// Token: 0x040091DC RID: 37340
	[Nullable(2)]
	private PhoneMsgChatData PhoneMsgChatData;

	// Token: 0x040091DD RID: 37341
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x040091DE RID: 37342
	private readonly Dictionary<string, int> TextureLoadResourceIds = new Dictionary<string, int>();

	// Token: 0x0200889D RID: 34973
	[NullableContext(0)]
	private enum EItemBirthdayComponent
	{
		// Token: 0x0402E23A RID: 188986
		TexCake,
		// Token: 0x0402E23B RID: 188987
		TxtDesc,
		// Token: 0x0402E23C RID: 188988
		TxtTitle,
		// Token: 0x0402E23D RID: 188989
		BtnGoTo,
		// Token: 0x0402E23E RID: 188990
		SpriteFinish,
		// Token: 0x0402E23F RID: 188991
		TexBg,
		// Token: 0x0402E240 RID: 188992
		TexTransitionBg,
		// Token: 0x0402E241 RID: 188993
		TexTransitionIcon
	}
}
