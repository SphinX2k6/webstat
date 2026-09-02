using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x0200343A RID: 13370
[NullableContext(2)]
[Nullable(0)]
public class UiBehaviorAudio : IUiBehavior
{
	// Token: 0x0601C05E RID: 114782 RVA: 0x0085ADAC File Offset: 0x00858FAC
	[NullableContext(1)]
	public UiBehaviorAudio(UiViewBase owner)
	{
		this.Owner = owner;
		if (this.Owner == null || this.Owner.ViewInfo == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Audio, ELogAuthor.WDX, "BehaviorAudio 缺少UiViewInfo", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.Info = this.Owner.ViewInfo;
		this.LoopAudioEvent = this.Owner.GetLoopAudioEvent();
	}

	// Token: 0x0601C05F RID: 114783 RVA: 0x0085AE1A File Offset: 0x0085901A
	public UniTask OnUiCreateAsync()
	{
		return UniTask.CompletedTask;
	}

	// Token: 0x0601C060 RID: 114784 RVA: 0x0085AE24 File Offset: 0x00859024
	public void OnAfterUiStart()
	{
		this.AudioFilter = ConfigBase<UiViewConfig>.Instance.GetUiShowConfig(this.Info.Name).Value.AudioFilter;
		if (!string.IsNullOrEmpty(this.AudioFilter) && this.HandleFilter == 0)
		{
			this.HandleFilter = Singleton<AudioFilterController>.Instance.PushUiFilterState(this.AudioFilter, this.Info.Name);
		}
		if (this.EffectComponent == null)
		{
			this.EffectComponent = this.Owner.GetUiAudioComponent();
		}
		if (!string.IsNullOrEmpty(this.Info.OpenAudioEvent))
		{
			Singleton<AudioSystem>.Instance.PostEvent(this.Info.OpenAudioEvent);
		}
	}

	// Token: 0x0601C061 RID: 114785 RVA: 0x0085AED8 File Offset: 0x008590D8
	public void OnAfterUiShow()
	{
		if (this.EffectComponent != null && this.EffectComponent.bAudioCoverEnable)
		{
			this.CreateAudioStateData();
			Singleton<UiAudioModel>.Instance.AddAudioStateData(this.StateData);
			Singleton<UiAudioModel>.Instance.SetRtpcLevelOpening(this.StateData.Level);
			Singleton<UiAudioModel>.Instance.CalculateRtpcValueAndApply();
		}
		if (!string.IsNullOrEmpty(this.LoopAudioEvent) && this.Owner.GetLoopAudioEventSwitch())
		{
			Singleton<UiAudioModel>.Instance.SetLoopAudioEventShow(this.Owner.GetViewId(), this.Owner.GetRootActor(), this.LoopAudioEvent);
			return;
		}
		if (this.Info.KeepLoopEvent)
		{
			Singleton<UiAudioModel>.Instance.KeepLoopAudioEventShow(this.Owner.GetViewId(), this.Owner.GetRootActor());
		}
	}

	// Token: 0x0601C062 RID: 114786 RVA: 0x0085AFA0 File Offset: 0x008591A0
	public void OnBeforeUiHide()
	{
		if (this.EffectComponent != null && this.EffectComponent.bAudioCoverEnable)
		{
			Singleton<UiAudioModel>.Instance.SetRtpcLevelClosing(this.StateData.Level);
			Singleton<UiAudioModel>.Instance.RemoveAudioStateData(this.StateData);
			Singleton<UiAudioModel>.Instance.CalculateRtpcValueAndApply();
		}
		if (!string.IsNullOrEmpty(this.LoopAudioEvent) && this.Owner.GetLoopAudioEventSwitch())
		{
			Singleton<UiAudioModel>.Instance.SetLoopAudioEventHide(this.Owner.GetViewId(), this.Owner.GetRootActor(), this.LoopAudioEvent);
			return;
		}
		if (this.Info.KeepLoopEvent)
		{
			Singleton<UiAudioModel>.Instance.KeepLoopAudioEventHide(this.Owner.GetViewId(), this.Owner.GetRootActor());
		}
	}

	// Token: 0x0601C063 RID: 114787 RVA: 0x0085B060 File Offset: 0x00859260
	public void OnBeforeDestroy()
	{
		this.EffectComponent = null;
		if (!string.IsNullOrEmpty(this.LoopAudioEvent) && this.Owner.GetLoopAudioEventSwitch())
		{
			Singleton<UiAudioModel>.Instance.SetLoopAudioEventDestroy(this.Owner.GetViewId(), this.Owner.GetRootActor(), this.LoopAudioEvent);
		}
		else if (this.Info.KeepLoopEvent)
		{
			Singleton<UiAudioModel>.Instance.KeepLoopAudioEventDestroy(this.Owner.GetViewId(), this.Owner.GetRootActor());
		}
		if (!string.IsNullOrEmpty(this.Info.CloseAudioEvent))
		{
			Singleton<AudioSystem>.Instance.PostEvent(this.Info.CloseAudioEvent);
		}
		if (!string.IsNullOrEmpty(this.AudioFilter) && this.HandleFilter != 0)
		{
			Singleton<AudioFilterController>.Instance.RemoveUiFilterState(this.HandleFilter, this.Info.Name);
			this.HandleFilter = 0;
		}
	}

	// Token: 0x0601C064 RID: 114788 RVA: 0x0085B147 File Offset: 0x00859347
	private void CreateAudioStateData()
	{
		this.StateData = new AudioStateData();
		this.StateData.Level = this.EffectComponent.AudioUiCover;
		this.StateData.Alpha = this.EffectComponent.AudioUiAlpha;
	}

	// Token: 0x0400E26C RID: 57964
	private int HandleFilter;

	// Token: 0x0400E26D RID: 57965
	private UUIViewAudioEffectComponent EffectComponent;

	// Token: 0x0400E26E RID: 57966
	private AudioStateData StateData;

	// Token: 0x0400E26F RID: 57967
	private UiViewBase Owner;

	// Token: 0x0400E270 RID: 57968
	private UiViewInfo Info;

	// Token: 0x0400E271 RID: 57969
	[Nullable(1)]
	protected string AudioFilter;

	// Token: 0x0400E272 RID: 57970
	[Nullable(1)]
	protected string LoopAudioEvent;
}
