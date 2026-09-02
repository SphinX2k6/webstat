using System;
using UnrealEngine;

// Token: 0x02002F99 RID: 12185
public class GameplayCueAudioEvent : GameplayCueBase
{
	// Token: 0x06018D95 RID: 101781 RVA: 0x007097B4 File Offset: 0x007079B4
	protected override void OnCreate()
	{
		WorldEntity entity = this.EntityHandle.Entity;
		CharacterAudioComponent characterAudioComponent = (entity != null) ? entity.GetComponent<CharacterAudioComponent>() : null;
		if (characterAudioComponent == null || this.CueConfig.ParametersLength == 0)
		{
			return;
		}
		this.EventHandle = Singleton<AudioSystem>.Instance.PostEvent(this.CueConfig.Parameters(0), characterAudioComponent.GetAkComponent(null), null);
	}

	// Token: 0x06018D96 RID: 101782 RVA: 0x00709820 File Offset: 0x00707A20
	protected override void OnDestroy()
	{
		if (this.EventHandle != 0)
		{
			Singleton<AudioSystem>.Instance.ExecuteAction(this.EventHandle, EAudioActionType.Stop, null);
		}
	}

	// Token: 0x0400C20F RID: 49679
	private int EventHandle;
}
