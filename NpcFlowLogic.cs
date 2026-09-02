using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.Module.Plot;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x020031B3 RID: 12723
[NullableContext(1)]
[Nullable(0)]
public class NpcFlowLogic : CharacterFlowLogic
{
	// Token: 0x0601A641 RID: 108097 RVA: 0x007C855D File Offset: 0x007C675D
	public NpcFlowLogic(BaseActorComponent actorComp, BubbleComponent bubbleData) : base(actorComp, bubbleData)
	{
	}

	// Token: 0x170023DC RID: 9180
	// (get) Token: 0x0601A642 RID: 108098 RVA: 0x007C857D File Offset: 0x007C677D
	public NpcRedDotFlowLogic RedDotLogic
	{
		get
		{
			if (this.RedDotInternal == null)
			{
				this.RedDotInternal = new NpcRedDotFlowLogic();
			}
			return this.RedDotInternal;
		}
	}

	// Token: 0x0601A643 RID: 108099 RVA: 0x007C8598 File Offset: 0x007C6798
	protected override void ResetFlowState()
	{
		base.ResetFlowState();
		this.RedDotLogic.ManualControlRedDotActive(false, false);
	}

	// Token: 0x0601A644 RID: 108100 RVA: 0x007C85B0 File Offset: 0x007C67B0
	protected override void PlayTalk(int id)
	{
		if (id < this.CurrentTalkItems.Count && this.DynamicFlowData != null && this.DynamicFlowData.RedDot != null)
		{
			this.RedDotLogic.ManualControlRedDotActive(true, this.DynamicFlowData.RedDot.Value);
		}
		base.PlayTalk(id);
	}

	// Token: 0x0601A645 RID: 108101 RVA: 0x007C8610 File Offset: 0x007C6810
	protected unsafe override bool HandleTalkAction([Nullable(2)] Entity entity, ITalkItem config)
	{
		if (entity == null)
		{
			return false;
		}
		this.PlayAkEvent((config != null) ? config.TalkAkEvent : null);
		this.IsAudioLoading = false;
		if (config.Montage != null)
		{
			NpcFlowComponent component = entity.GetComponent<NpcFlowComponent>();
			if (component != null)
			{
				component.TryPlayMontage(config.Montage.ActionMontage.Path);
			}
		}
		PlotAudio? plotAudio = config.PlayVoice.GetValueOrDefault() ? ConfigPlotAudioById.GetConfig(config.TidTalk, true) : null;
		if (plotAudio != null)
		{
			this.HandleNormalAudio(plotAudio.Value, config, entity);
			return true;
		}
		if (config.UniversalTone != null)
		{
			int universalToneId = config.UniversalTone.UniversalToneId;
			int? num;
			if (config.UniversalTone.TimberId == null)
			{
				NpcFlowComponent component2 = entity.GetComponent<NpcFlowComponent>();
				num = ((component2 != null) ? component2.GetTimberId() : null);
			}
			else
			{
				num = config.UniversalTone.TimberId;
			}
			int? num2 = num;
			if (num2 != null)
			{
				Interjection? config2 = ConfigInterjectionByTimberIdAndUniversalToneId.GetConfig(num2.Value, universalToneId, true);
				if (config2 != null)
				{
					this.HandleInterjection(config2.Value, config, entity);
					return true;
				}
			}
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Plot;
			ELogAuthor author = ELogAuthor.FZX;
			string message = "通用语气配置无法获取，策划检查配置捏";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("entity", entity.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("timberId", num2);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("universalToneId", universalToneId);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		}
		string flowText = base.GetFlowText(config.TidTalk);
		this.WaitSecondsRemain = (double)base.GetWaitSeconds(config, 0f);
		double num3 = this.WaitSecondsRemain + 0.05000000074505806;
		this.IsWaitForDialogueUi = true;
		entity.GetComponent<PawnHeadInfoComponent>().SetDialogueText(flowText, (float)num3, this.RedDotLogic.GetRedDotActive()).ContinueWith(delegate()
		{
			this.IsWaitForDialogueUi = false;
		});
		return true;
	}

	// Token: 0x0601A646 RID: 108102 RVA: 0x007C881C File Offset: 0x007C6A1C
	private void HandleNormalAudio(PlotAudio audioConfig, ITalkItem config, Entity entity)
	{
		this.IsAudioLoading = true;
		this.WaitSecondsRemain = 1.0;
		ExternalSourceSetting? config2 = ConfigExternalSourceSettingById.GetConfig(audioConfig.ExternalSourceSetting, true);
		string externalSourcesMediaName = ModelBase<PlotAudioModel>.Instance.GetExternalSourcesMediaName(audioConfig);
		this.AudioDelegate.Init(new Action<float, Entity, ITalkItem>(this.CallBackDuration), entity, config, (audioConfig.TailTime < 0) ? ModelBase<PlotModel>.Instance.PlotGlobalConfig.BubbleAudioEndDelay : ((float)audioConfig.TailTime));
		this.AudioDelegate.Enable();
		AudioController instance = Singleton<AudioController>.Instance;
		string bubbleEvent = config2.Value.BubbleEvent;
		BaseActorComponent actorComp = this.ActorComp;
		instance.PostEventByExternalSources(bubbleEvent, (actorComp != null) ? actorComp.Owner : null, externalSourcesMediaName, config2.Value.BubbleSrc, this.PlayEventResult, null, new int?(8), this.AudioDelegate.AudioDelegateField);
	}

	// Token: 0x0601A647 RID: 108103 RVA: 0x007C88F4 File Offset: 0x007C6AF4
	private void HandleInterjection(Interjection audioConfig, ITalkItem config, Entity entity)
	{
		this.IsAudioLoading = true;
		this.WaitSecondsRemain = 1.0;
		this.AudioDelegate.Init(new Action<float, Entity, ITalkItem>(this.CallBackDuration), entity, config, 0f);
		this.AudioDelegate.Enable();
		AudioController instance = Singleton<AudioController>.Instance;
		string akEvent = audioConfig.AkEvent;
		BaseActorComponent actorComp = this.ActorComp;
		instance.PostEvent(akEvent, (actorComp != null) ? actorComp.Owner : null, this.PlayEventResult, new int?(8), this.AudioDelegate.AudioDelegateField, null, true, "");
	}

	// Token: 0x0601A648 RID: 108104 RVA: 0x007C898C File Offset: 0x007C6B8C
	[NullableContext(2)]
	private void PlayAkEvent(IPostAkEventType config)
	{
		if (config == null)
		{
			return;
		}
		if (config.Type == EPostAkEvent.Global)
		{
			string akEvent = (config as IPostAkEventGlobal).AkEvent;
			Singleton<AudioController>.Instance.PostEvent(akEvent, null, null, null, null, null, true, "");
			return;
		}
		if (config.Type == EPostAkEvent.Target)
		{
			string akEvent2 = (config as IPostAkEventTargeted).AkEvent;
			int entityId = (config as IPostAkEventTargeted).EntityId;
			EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(entityId);
			if (entityByPbDataId == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Event;
				ELogAuthor author = ELogAuthor.FZX;
				string message = "实体不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("entityId", entityId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			BaseActorComponent component = entityByPbDataId.Entity.GetComponent<BaseActorComponent>();
			AActor aactor = (component != null) ? component.Owner : null;
			if (aactor == null || !aactor.IsValid())
			{
				global::Log instance2 = Singleton<global::Log>.Instance;
				ELogModule module2 = ELogModule.Event;
				ELogAuthor author2 = ELogAuthor.FZX;
				string message2 = "未能获取到该实体对应的有效Actor";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("entityId", entityId);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return;
			}
			Singleton<AudioController>.Instance.PostEvent(akEvent2, aactor, null, null, null, null, true, "");
		}
	}

	// Token: 0x0601A649 RID: 108105 RVA: 0x007C8AC0 File Offset: 0x007C6CC0
	private void CallBackDuration(float duration, Entity entity, ITalkItem config)
	{
		this.IsAudioLoading = false;
		this.WaitSecondsRemain = ((duration > 0f) ? Singleton<TimeUtil>.Instance.SetTimeSecond((double)duration) : 3.0);
		string flowText = base.GetFlowText(config.TidTalk);
		if (StringUtils.IsEmpty(flowText))
		{
			return;
		}
		double num2;
		if (config.WaitTime != null)
		{
			float? waitTime = config.WaitTime;
			float num = 0f;
			if (waitTime.GetValueOrDefault() > num & waitTime != null)
			{
				num2 = (double)(config.WaitTime.Value + 0.05f);
				goto IL_9A;
			}
		}
		num2 = this.WaitSecondsRemain + 0.05000000074505806;
		IL_9A:
		double num3 = num2;
		PawnHeadInfoComponent component = entity.GetComponent<PawnHeadInfoComponent>();
		this.IsWaitForDialogueUi = true;
		component.SetDialogueText(flowText, (float)num3, false).ContinueWith(delegate()
		{
			this.IsWaitForDialogueUi = false;
		});
	}

	// Token: 0x0601A64A RID: 108106 RVA: 0x007C8B90 File Offset: 0x007C6D90
	public override void Tick(float deltaSeconds)
	{
		if (!this.EnableUpdate)
		{
			return;
		}
		if (this.IsWaitForDialogueUi)
		{
			return;
		}
		this.WaitSecondsRemain -= (double)deltaSeconds;
		if (this.WaitSecondsRemain <= 0.0)
		{
			if (this.IsAudioLoading)
			{
				Singleton<global::Log>.Instance.Warn(ELogModule.Level, ELogAuthor.FZX, "冒泡音频加载超时", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.IsAudioLoading = false;
				this.ClearAudio();
				this.AudioDelegate.ManualExec(0f);
				return;
			}
			if (base.IsExecuteFlowEnd)
			{
				if (!this.IsPause)
				{
					base.StartFlow();
					return;
				}
				this.EnableUpdate = false;
				return;
			}
			else
			{
				this.PlayTalk(this.CurrentTalkId + 1);
			}
		}
	}

	// Token: 0x0601A64B RID: 108107 RVA: 0x007C8C40 File Offset: 0x007C6E40
	public void ClearAudio()
	{
		this.IsAudioLoading = false;
		if (this.AudioDelegate != null)
		{
			this.AudioDelegate.Disable();
		}
		if (this.PlayEventResult != null)
		{
			Singleton<AudioController>.Instance.StopEvent(this.PlayEventResult, true, new int?(Singleton<TimeUtil>.Instance.InverseMillisecond));
		}
	}

	// Token: 0x0400D4F6 RID: 54518
	private const int DEFAULT_WAIT_TIME = 3;

	// Token: 0x0400D4F7 RID: 54519
	private const int LOAD_AUDIO_TIME = 1;

	// Token: 0x0400D4F8 RID: 54520
	private const int PLAY_FLAG = 8;

	// Token: 0x0400D4F9 RID: 54521
	private const int BREAK_TIME = 1;

	// Token: 0x0400D4FA RID: 54522
	private readonly PlayResult PlayEventResult = new PlayResult();

	// Token: 0x0400D4FB RID: 54523
	private readonly AudioDelegate AudioDelegate = new AudioDelegate();

	// Token: 0x0400D4FC RID: 54524
	private bool IsAudioLoading;

	// Token: 0x0400D4FD RID: 54525
	[Nullable(2)]
	private NpcRedDotFlowLogic RedDotInternal;
}
