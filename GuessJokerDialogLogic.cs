using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.Plot;
using CSharpScript.Game.Module.Plot.Sequence;
using UnrealEngine;

// Token: 0x020010EB RID: 4331
[NullableContext(1)]
[Nullable(0)]
public class GuessJokerDialogLogic
{
	// Token: 0x060070D3 RID: 28883 RVA: 0x001D7063 File Offset: 0x001D5263
	public void InitData(IGuessJokerDialogData data)
	{
		this.Data = data;
	}

	// Token: 0x060070D4 RID: 28884 RVA: 0x001D706C File Offset: 0x001D526C
	public void PlayDialog(ITalkItemDialog talkData, [Nullable(2)] Action finishCallback = null)
	{
		GuessJokerDialogLogic.<>c__DisplayClass7_0 CS$<>8__locals1 = new GuessJokerDialogLogic.<>c__DisplayClass7_0();
		CS$<>8__locals1.<>4__this = this;
		if (this.Data == null)
		{
			Singleton<global::Log>.Instance.Error(ELogModule.GuessJokerCard, ELogAuthor.LRC, "GuessJokerDialogLogic未初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
			if (finishCallback != null)
			{
				finishCallback();
			}
			return;
		}
		GuessJokerDialogLogic.<>c__DisplayClass7_0 CS$<>8__locals2 = CS$<>8__locals1;
		int num = this.DialogVersion + 1;
		this.DialogVersion = num;
		CS$<>8__locals2.currentVersion = num;
		this.TalkData = talkData;
		this.FinishCallback = finishCallback;
		EGuessJokerPlayerType playerType = this.GetPlayerType();
		string tidTalk = talkData.TidTalk;
		if (this.Data.GetDialogText != null)
		{
			UUIText uuitext = this.Data.GetDialogText(playerType);
			if (uuitext != null)
			{
				uuitext.ShowTextNew(tidTalk);
			}
		}
		CS$<>8__locals1.isStartOrVoiceFinish = false;
		if (this.Data.OnDialogStart != null)
		{
			this.Data.OnDialogStart(playerType, tidTalk, new Action(CS$<>8__locals1.<PlayDialog>g__OnAnimComplete|0));
		}
		else if (this.Data.GetDialogItem != null)
		{
			UUIItem uuiitem = this.Data.GetDialogItem(playerType);
			if (uuiitem != null)
			{
				uuiitem.SetUIActive(true);
				CS$<>8__locals1.isStartOrVoiceFinish = true;
			}
		}
		if (talkData.WhoId.GetValueOrDefault() != 750088 && talkData.WhoId.GetValueOrDefault() != 701052)
		{
			this.PlayMouthAnim(talkData);
		}
		PlotAudio? config = ConfigPlotAudioById.GetConfig(talkData.TidTalk, true);
		if (config == null)
		{
			this.OnDialogEnd();
			return;
		}
		string externalSourcesMediaName = ModelBase<PlotAudioModel>.Instance.GetExternalSourcesMediaName(config.Value);
		this.PlotPlayEventResult = Singleton<AudioSystem>.Instance.PostEvent("play_vo_plot_review_log", null, new PostEventArgs?(new PostEventArgs
		{
			ExternalSourceName = "external_plot_review_log_voice",
			ExternalSourceMediaName = externalSourcesMediaName,
			CallbackMask = new ECallbackMask?(ECallbackMask.EndOfEvent),
			CallbackHandler = delegate(EAkCallbackType callbackType, UAkCallbackInfo callbackInfo)
			{
				if (CS$<>8__locals1.currentVersion != CS$<>8__locals1.<>4__this.DialogVersion)
				{
					return;
				}
				if (callbackType == EAkCallbackType.EndOfEvent)
				{
					if (!CS$<>8__locals1.isStartOrVoiceFinish)
					{
						CS$<>8__locals1.isStartOrVoiceFinish = true;
						return;
					}
					CS$<>8__locals1.<>4__this.OnDialogEnd();
				}
			}
		}));
	}

	// Token: 0x060070D5 RID: 28885 RVA: 0x001D7244 File Offset: 0x001D5444
	private void OnDialogEnd()
	{
		if (this.Data == null || this.TalkData == null)
		{
			Action finishCallback = this.FinishCallback;
			if (finishCallback != null)
			{
				finishCallback();
			}
			this.FinishCallback = null;
			return;
		}
		EGuessJokerPlayerType playerType = this.GetPlayerType();
		if (this.Data.OnDialogEnd != null)
		{
			this.Data.OnDialogEnd(playerType, new Action(this.<OnDialogEnd>g__OnComplete|8_0));
			return;
		}
		if (this.Data.GetDialogItem != null)
		{
			UUIItem uuiitem = this.Data.GetDialogItem(playerType);
			if (uuiitem != null)
			{
				uuiitem.SetUIActive(false);
			}
			this.<OnDialogEnd>g__OnComplete|8_0();
			return;
		}
		this.<OnDialogEnd>g__OnComplete|8_0();
	}

	// Token: 0x060070D6 RID: 28886 RVA: 0x001D72E4 File Offset: 0x001D54E4
	private EGuessJokerPlayerType GetPlayerType()
	{
		if (this.TalkData == null)
		{
			return EGuessJokerPlayerType.Ai;
		}
		if (this.TalkData.WhoId.GetValueOrDefault() != 750088 && this.TalkData.WhoId.GetValueOrDefault() != 701052)
		{
			return EGuessJokerPlayerType.Ai;
		}
		return EGuessJokerPlayerType.Me;
	}

	// Token: 0x060070D7 RID: 28887 RVA: 0x001D7334 File Offset: 0x001D5534
	private void PlayMouthAnim(ITalkItemDialog talkItem)
	{
		GuessJokerDialogLogic.<>c__DisplayClass10_0 CS$<>8__locals1 = new GuessJokerDialogLogic.<>c__DisplayClass10_0();
		CS$<>8__locals1.<>4__this = this;
		if (talkItem.PlayVoice.GetValueOrDefault() && talkItem.TidTalk != null && !string.IsNullOrEmpty(talkItem.TidTalk) && !talkItem.NoMouthAnim.GetValueOrDefault())
		{
			ETalkItemType? type = talkItem.Type;
			ETalkItemType etalkItemType = ETalkItemType.Talk;
			if (type.GetValueOrDefault() == etalkItemType & type != null)
			{
				ITalkItemStyle style = talkItem.Style;
				if (style != null && style.Type == ETalkItemStyle.InnerVoice)
				{
					return;
				}
				CS$<>8__locals1.entityId = ModelBase<GuessJokerGamePlayModel>.Instance.EntityId;
				EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(CS$<>8__locals1.entityId);
				if (((entityByPbDataId != null) ? entityByPbDataId.Entity : null) == null)
				{
					return;
				}
				GuessJokerDialogLogic.<>c__DisplayClass10_0 CS$<>8__locals2 = CS$<>8__locals1;
				CharacterAnimationComponent component = entityByPbDataId.Entity.GetComponent<CharacterAnimationComponent>();
				CS$<>8__locals2.curAnimInst = ((component != null) ? component.MainAnimInstance : null);
				if (CS$<>8__locals1.curAnimInst == null)
				{
					return;
				}
				PlotAudio? config = ConfigPlotAudioById.GetConfig(talkItem.TidTalk, true);
				if (config == null || !config.Value.GenLipSync)
				{
					return;
				}
				if (this.MouthAnimLoadingId != -1)
				{
					Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.MouthAnimLoadingId);
					this.MouthAnimLoadingId = -1;
				}
				string audioMouthAnimName = ModelBase<PlotAudioModel>.Instance.GetAudioMouthAnimName(config.Value);
				this.MouthAnimLoadingId = Singleton<ResourceSystem>.Instance.LoadAsync<UAnimSequence>(audioMouthAnimName, delegate([Nullable(2)] UAnimSequence anim, string path)
				{
					CS$<>8__locals1.<>4__this.MouthAnimLoadingId = -1;
					if (anim == null || !anim.IsValid())
					{
						return;
					}
					CS$<>8__locals1.curAnimInst.StopSlotAnimation(0f, SequenceDefine.ABP_Mouth_Slot_Name);
					UAnimMontage animMontage = CS$<>8__locals1.curAnimInst.PlaySlotAnimationAsDynamicMontage(anim, SequenceDefine.ABP_Mouth_Slot_Name, 0f, 0f, 1f, 1, -1f, 0f, false);
					EntityHandle entityByPbDataId2 = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(CS$<>8__locals1.entityId);
					if (((entityByPbDataId2 != null) ? entityByPbDataId2.Entity : null) != null)
					{
						CommonNpcPerformComponent component2 = entityByPbDataId2.Entity.GetComponent<CommonNpcPerformComponent>();
						NpcFacialExpressionController npcFacialExpressionController = (component2 != null) ? component2.ExpressionController : null;
						if (npcFacialExpressionController == null)
						{
							return;
						}
						npcFacialExpressionController.ChangeFaceForMouthMontage(animMontage);
					}
				}, 100, "js_undefined");
				return;
			}
		}
	}

	// Token: 0x060070D8 RID: 28888 RVA: 0x001D7494 File Offset: 0x001D5694
	public void Clear()
	{
		this.DialogVersion++;
		Singleton<AudioSystem>.Instance.ExecuteAction(this.PlotPlayEventResult, EAudioActionType.Stop, new ExecuteActionArgs?(new ExecuteActionArgs
		{
			TransitionDuration = new int?(0)
		}));
		if (this.MouthAnimLoadingId != -1)
		{
			Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.MouthAnimLoadingId);
		}
		EGuessJokerPlayerType playerType = this.GetPlayerType();
		IGuessJokerDialogData data = this.Data;
		if (data != null)
		{
			Action<EGuessJokerPlayerType> onCancelDialogStartAnim = data.OnCancelDialogStartAnim;
			if (onCancelDialogStartAnim != null)
			{
				onCancelDialogStartAnim(playerType);
			}
		}
		this.MouthAnimLoadingId = -1;
		this.PlotPlayEventResult = 0;
		this.TalkData = null;
		Action finishCallback = this.FinishCallback;
		if (finishCallback != null)
		{
			finishCallback();
		}
		this.FinishCallback = null;
	}

	// Token: 0x060070DA RID: 28890 RVA: 0x001D7554 File Offset: 0x001D5754
	[CompilerGenerated]
	private void <OnDialogEnd>g__OnComplete|8_0()
	{
		Action finishCallback = this.FinishCallback;
		if (finishCallback != null)
		{
			finishCallback();
		}
		this.FinishCallback = null;
	}

	// Token: 0x04003642 RID: 13890
	[Nullable(2)]
	private IGuessJokerDialogData Data;

	// Token: 0x04003643 RID: 13891
	[Nullable(2)]
	private ITalkItemDialog TalkData;

	// Token: 0x04003644 RID: 13892
	private int PlotPlayEventResult;

	// Token: 0x04003645 RID: 13893
	private int MouthAnimLoadingId = -1;

	// Token: 0x04003646 RID: 13894
	[Nullable(2)]
	private Action FinishCallback;

	// Token: 0x04003647 RID: 13895
	private int DialogVersion;
}
