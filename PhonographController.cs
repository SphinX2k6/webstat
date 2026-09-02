using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002597 RID: 9623
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class PhonographController : UiControllerBase<PhonographController>
{
	// Token: 0x06012BED RID: 76781 RVA: 0x0052BCAD File Offset: 0x00529EAD
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<PhantomMusicNotify>(ENotifyMessageId.PhantomMusicNotify, new Action<PhantomMusicNotify, Net.CallbackStatus>(this.OnPhantomMusicNotify));
	}

	// Token: 0x06012BEE RID: 76782 RVA: 0x0052BCCB File Offset: 0x00529ECB
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PhantomMusicNotify);
	}

	// Token: 0x06012BEF RID: 76783 RVA: 0x0052BCDD File Offset: 0x00529EDD
	protected override bool OnLeaveLevel()
	{
		ModelBase<PhonographModel>.Instance.GlobalMusicId = 0;
		this.StopMusic(true);
		return true;
	}

	// Token: 0x06012BF0 RID: 76784 RVA: 0x0052BCF4 File Offset: 0x00529EF4
	[NullableContext(0)]
	public UniTask<bool> UnlockMusicRequest([Nullable(1)] List<int> itemList)
	{
		PhonographController.<UnlockMusicRequest>d__3 <UnlockMusicRequest>d__;
		<UnlockMusicRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<UnlockMusicRequest>d__.<>4__this = this;
		<UnlockMusicRequest>d__.itemList = itemList;
		<UnlockMusicRequest>d__.<>1__state = -1;
		<UnlockMusicRequest>d__.<>t__builder.Start<PhonographController.<UnlockMusicRequest>d__3>(ref <UnlockMusicRequest>d__);
		return <UnlockMusicRequest>d__.<>t__builder.Task;
	}

	// Token: 0x06012BF1 RID: 76785 RVA: 0x0052BD40 File Offset: 0x00529F40
	public void SendMusicSaveRequest(int musicId)
	{
		PhantomMusicSaveRequest phantomMusicSaveRequest = PhantomMusicSaveRequest.Create();
		phantomMusicSaveRequest.Music = musicId;
		Singleton<Net>.Instance.Call<PhantomMusicSaveResponse>(ERequestMessageId.PhantomMusicSaveRequest, phantomMusicSaveRequest, delegate(PhantomMusicSaveResponse response, Net.CallbackStatus _)
		{
			if (response != null && response.ErrCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrCode, 17095, null, true, true);
			}
		}, 0);
	}

	// Token: 0x06012BF2 RID: 76786 RVA: 0x0052BD8C File Offset: 0x00529F8C
	private void OnPhantomMusicNotify(PhantomMusicNotify message, [Nullable(2)] Net.CallbackStatus status)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Audio;
		ELogAuthor author = ELogAuthor.BB;
		string message2 = "Server Notify Post Audio";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("musicId", message.Music);
		instance.Info(module, author, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		ModelBase<PhonographModel>.Instance.GlobalMusicId = message.Music;
		this.PlayGlobalMusic(message.Music, true);
	}

	// Token: 0x06012BF3 RID: 76787 RVA: 0x0052BDE8 File Offset: 0x00529FE8
	public void OpenView()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.PhonographView, null, null);
	}

	// Token: 0x06012BF4 RID: 76788 RVA: 0x0052BDFC File Offset: 0x00529FFC
	public void SwitchMusicRequest(int musicId, Action callback)
	{
		PhantomMusicSwitchRequest phantomMusicSwitchRequest = PhantomMusicSwitchRequest.Create();
		phantomMusicSwitchRequest.MusicId = musicId;
		Singleton<Net>.Instance.Call<PhantomMusicSwitchResponse>(ERequestMessageId.PhantomMusicSwitchRequest, phantomMusicSwitchRequest, delegate(PhantomMusicSwitchResponse response, Net.CallbackStatus _)
		{
			if (response != null && response.ErrorCode == Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("PhonographSwitchMusicSuccess", Array.Empty<object>());
				ModelBase<PhonographModel>.Instance.RecordMusicId = musicId;
				callback();
			}
		}, 0);
	}

	// Token: 0x06012BF5 RID: 76789 RVA: 0x0052BE4C File Offset: 0x0052A04C
	public int PlayMusic(int musicId, bool isGlobal = false)
	{
		if (musicId != 0 && this.IsMusicAlbumExpired(musicId))
		{
			this.HandleTimeLimitMusicExpired(musicId);
			return 0;
		}
		if (isGlobal)
		{
			return this.PlayGlobalMusic(musicId, false);
		}
		PhonographModel instance = ModelBase<PhonographModel>.Instance;
		AActor aactor = (instance != null) ? instance.EntityActor : null;
		if (aactor != null && aactor.IsValid())
		{
			Singleton<AudioSystem>.Instance.StopAll(aactor);
		}
		PhonographConfig instance2 = ConfigBase<PhonographConfig>.Instance;
		PhonographMusic? phonographMusic = (instance2 != null) ? instance2.GetMusicById(musicId) : null;
		if (phonographMusic == null)
		{
			return 0;
		}
		if (aactor == null || !aactor.IsValid())
		{
			return 0;
		}
		this.StopMusic(false);
		int handleId = 0;
		handleId = Singleton<AudioSystem>.Instance.PostEvent(phonographMusic.Value.MusicEvent, aactor, new PostEventArgs?(new PostEventArgs
		{
			CallbackMask = new ECallbackMask?(ECallbackMask.EndOfEvent),
			CallbackHandler = delegate(EAkCallbackType callbackType, UAkCallbackInfo callbackInfo)
			{
				if (callbackType == (EAkCallbackType)1 && handleId == ModelBase<PhonographModel>.Instance.CurrentMusicHandleId)
				{
					this.OnMusicEnd();
				}
			}
		}));
		ModelBase<PhonographModel>.Instance.CurrentMusicHandleId = handleId;
		ModelBase<PhonographModel>.Instance.GetMusicDuration(musicId).ContinueWith(delegate(float d)
		{
			ModelBase<PhonographModel>.Instance.CurrentPlayMusicTotalTime = (int)d;
			ModelBase<PhonographModel>.Instance.CurrentPlayMusicTime = 0;
			ModelBase<PhonographModel>.Instance.CurrentPlayMusicId = musicId;
		}).Forget();
		return handleId;
	}

	// Token: 0x06012BF6 RID: 76790 RVA: 0x0052BFA4 File Offset: 0x0052A1A4
	public int PlayGlobalMusic(int musicId, bool isForce = false)
	{
		if (musicId == 0)
		{
			this.StopMusic(false);
			return 0;
		}
		if (musicId == ModelBase<PhonographModel>.Instance.GlobalMusicId && !isForce)
		{
			return 0;
		}
		PhonographConfig instance = ConfigBase<PhonographConfig>.Instance;
		PhonographMusic? phonographMusic = (instance != null) ? instance.GetMusicById(musicId) : null;
		if (phonographMusic == null)
		{
			return 0;
		}
		this.StopMusic(false);
		Singleton<AudioSystem>.Instance.SetRtpcValue("phonograph_switch_to_2d", 1f, null);
		int handleId = 0;
		handleId = Singleton<AudioSystem>.Instance.PostEvent(phonographMusic.Value.MusicEvent, null, new PostEventArgs?(new PostEventArgs
		{
			CallbackMask = new ECallbackMask?(ECallbackMask.EndOfEvent),
			CallbackHandler = delegate(EAkCallbackType callbackType, UAkCallbackInfo callbackInfo)
			{
				if (callbackType == (EAkCallbackType)1 && handleId == ModelBase<PhonographModel>.Instance.CurrentMusicHandleId)
				{
					this.OnMusicEnd();
				}
			}
		}));
		ModelBase<PhonographModel>.Instance.CurrentMusicHandleId = handleId;
		ModelBase<PhonographModel>.Instance.GetMusicDuration(musicId).ContinueWith(delegate(float d)
		{
			ModelBase<PhonographModel>.Instance.CurrentPlayMusicTotalTime = (int)d;
			ModelBase<PhonographModel>.Instance.CurrentPlayMusicTime = 0;
			ModelBase<PhonographModel>.Instance.CurrentPlayMusicId = musicId;
		}).Forget();
		return handleId;
	}

	// Token: 0x06012BF7 RID: 76791 RVA: 0x0052C0D0 File Offset: 0x0052A2D0
	private void OnMusicEnd()
	{
		int currentPlayMusicId = ModelBase<PhonographModel>.Instance.CurrentPlayMusicId;
		if (currentPlayMusicId != 0 && this.IsMusicAlbumExpired(currentPlayMusicId))
		{
			this.HandleTimeLimitMusicExpired(currentPlayMusicId);
			return;
		}
		this.ContinuePlayAfterMusicEnd();
	}

	// Token: 0x06012BF8 RID: 76792 RVA: 0x0052C104 File Offset: 0x0052A304
	public bool IsMusicAlbumExpired(int musicId)
	{
		PhonographConfig instance = ConfigBase<PhonographConfig>.Instance;
		PhonographMusic? phonographMusic = (instance != null) ? instance.GetMusicById(musicId) : null;
		if (phonographMusic == null)
		{
			return false;
		}
		PhonographMusic value = phonographMusic.Value;
		for (int i = 0; i < value.AlbumLength; i++)
		{
			if (ModelBase<MotorcycleMusicPlayerModel>.Instance.ShouldFallbackForExpired(value.Album(i)))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06012BF9 RID: 76793 RVA: 0x0052C168 File Offset: 0x0052A368
	private void ContinuePlayAfterMusicEnd()
	{
		if (ModelBase<PhonographModel>.Instance.CurrentPlayMusicId == 0)
		{
			this.StopMusic(true);
			return;
		}
		if (!ModelBase<PhonographModel>.Instance.IsGlobal)
		{
			this.StopMusic(true);
			return;
		}
		this.PlayGlobalMusic(ModelBase<PhonographModel>.Instance.GlobalMusicId, true);
	}

	// Token: 0x06012BFA RID: 76794 RVA: 0x0052C1A4 File Offset: 0x0052A3A4
	private void HandleTimeLimitMusicExpired(int expiredMusicId)
	{
		this.StopMusic(true);
		if (ModelBase<PhonographModel>.Instance.GlobalMusicId == expiredMusicId)
		{
			ModelBase<PhonographModel>.Instance.GlobalMusicId = 0;
			this.SendMusicSaveRequest(0);
		}
		if (ModelBase<PhonographModel>.Instance.RecordMusicId == expiredMusicId)
		{
			ModelBase<PhonographModel>.Instance.RecordMusicId = 0;
		}
		ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("MotorMusic_TimeLimited_tips", Array.Empty<object>());
		if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.PhonographView))
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnPhonographMusicForceRefresh, 1);
		}
	}

	// Token: 0x06012BFB RID: 76795 RVA: 0x0052C228 File Offset: 0x0052A428
	public void StopMusic(bool isEmit = true)
	{
		Singleton<AudioSystem>.Instance.SetRtpcValue("phonograph_switch_to_2d", 0f, null);
		PhonographModel instance = ModelBase<PhonographModel>.Instance;
		AActor aactor = (instance != null) ? instance.EntityActor : null;
		if (aactor != null && aactor.IsValid())
		{
			Singleton<AudioSystem>.Instance.StopAll(aactor);
		}
		if (ModelBase<PhonographModel>.Instance.CurrentMusicHandleId != 0)
		{
			Singleton<AudioSystem>.Instance.ExecuteAction(ModelBase<PhonographModel>.Instance.CurrentMusicHandleId, EAudioActionType.Stop, null);
			ModelBase<PhonographModel>.Instance.CurrentMusicHandleId = 0;
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.OnPhonographPlayStop);
		ModelBase<PhonographModel>.Instance.CurrentPlayMusicId = 0;
		ModelBase<PhonographModel>.Instance.CurrentPlayMusicTime = 0;
		ModelBase<PhonographModel>.Instance.CurrentPlayMusicTotalTime = 0;
		if (isEmit)
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.OnPhonographSwitchMusic);
		}
	}

	// Token: 0x06012BFC RID: 76796 RVA: 0x0052C2F4 File Offset: 0x0052A4F4
	public void PlayMusicByEntityId(int entityId)
	{
		int playIdRecord = ModelBase<PhonographModel>.Instance.GetPlayIdRecord(entityId);
		if (playIdRecord != 0)
		{
			Singleton<AudioSystem>.Instance.ExecuteAction(playIdRecord, EAudioActionType.Stop, null);
		}
		int recordMusicId = ModelBase<PhonographModel>.Instance.GetRecordMusicId(entityId);
		if (recordMusicId == 0)
		{
			return;
		}
		PhonographConfig instance = ConfigBase<PhonographConfig>.Instance;
		PhonographMusic? phonographMusic = (instance != null) ? instance.GetMusicById(recordMusicId) : null;
		if (phonographMusic == null)
		{
			return;
		}
		CreatureModel instance2 = ModelBase<CreatureModel>.Instance;
		EntityHandle entityHandle = (instance2 != null) ? instance2.GetEntityByPbDataId(entityId) : null;
		if (entityHandle == null)
		{
			return;
		}
		WorldEntity entity = entityHandle.Entity;
		BaseActorComponent baseActorComponent = (entity != null) ? entity.GetComponent<BaseActorComponent>() : null;
		if (baseActorComponent == null)
		{
			return;
		}
		int musicId = Singleton<AudioSystem>.Instance.PostEvent(phonographMusic.Value.MusicEvent, baseActorComponent.Owner, null);
		ModelBase<PhonographModel>.Instance.SetPlayIdRecord(entityId, musicId);
	}

	// Token: 0x06012BFD RID: 76797 RVA: 0x0052C3C8 File Offset: 0x0052A5C8
	public void StopMusicByEntityId(int entityId)
	{
		int playIdRecord = ModelBase<PhonographModel>.Instance.GetPlayIdRecord(entityId);
		if (playIdRecord != 0)
		{
			Singleton<AudioSystem>.Instance.ExecuteAction(playIdRecord, EAudioActionType.Stop, null);
			ModelBase<PhonographModel>.Instance.RemovePlayIdRecord(entityId);
		}
	}
}
