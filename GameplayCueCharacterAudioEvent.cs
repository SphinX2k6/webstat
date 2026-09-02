using System;

// Token: 0x02002FA0 RID: 12192
public class GameplayCueCharacterAudioEvent : GameplayCueBase
{
	// Token: 0x06018DCC RID: 101836 RVA: 0x00709E70 File Offset: 0x00708070
	protected override void OnCreate()
	{
		this.IsForbidTeammate = (this.CueConfig.ParametersLength > 0 && this.CueConfig.Parameters(0) == "1");
		if (this.IsForbidTeammate)
		{
			WorldEntity entity = this.EntityHandle.Entity;
			CreatureDataComponent creatureDataComponent = (entity != null) ? entity.GetComponent<CreatureDataComponent>() : null;
			int playerId = ModelBase<CreatureModel>.Instance.GetPlayerId();
			int? num = (creatureDataComponent != null) ? new int?(creatureDataComponent.GetPlayerId()) : null;
			this.DisableByTeammate = !(playerId == num.GetValueOrDefault() & num != null);
		}
		else
		{
			this.DisableByTeammate = false;
		}
		if (this.DisableByTeammate)
		{
			return;
		}
		WorldEntity entity2 = this.EntityHandle.Entity;
		if (entity2 != null && entity2.Active)
		{
			this.PlayAudio(GameplayCueCharacterAudioEvent.EAudioIndex.StartAtActive);
			this.HasStartAtActive = true;
			return;
		}
		this.PlayAudio(GameplayCueCharacterAudioEvent.EAudioIndex.StartAtInactive);
	}

	// Token: 0x06018DCD RID: 101837 RVA: 0x00709F4B File Offset: 0x0070814B
	public override void OnEnable()
	{
		if (this.DisableByTeammate)
		{
			return;
		}
		if (!this.HasStartAtActive)
		{
			this.HasStartAtActive = true;
			if (this.PlayAudio(GameplayCueCharacterAudioEvent.EAudioIndex.EnableAtFirstActive))
			{
				return;
			}
		}
		this.PlayAudio(GameplayCueCharacterAudioEvent.EAudioIndex.Enable);
	}

	// Token: 0x06018DCE RID: 101838 RVA: 0x00709F77 File Offset: 0x00708177
	public override void OnDisable()
	{
		if (this.DisableByTeammate)
		{
			return;
		}
		this.PlayAudio(GameplayCueCharacterAudioEvent.EAudioIndex.Disable);
	}

	// Token: 0x06018DCF RID: 101839 RVA: 0x00709F8A File Offset: 0x0070818A
	protected override void OnDestroy()
	{
		if (this.DisableByTeammate)
		{
			return;
		}
		WorldEntity entity = this.EntityHandle.Entity;
		this.PlayAudio((entity != null && entity.Active) ? GameplayCueCharacterAudioEvent.EAudioIndex.StopAtActive : GameplayCueCharacterAudioEvent.EAudioIndex.StopAtInactive);
	}

	// Token: 0x06018DD0 RID: 101840 RVA: 0x00709FBC File Offset: 0x007081BC
	private bool PlayAudio(GameplayCueCharacterAudioEvent.EAudioIndex index)
	{
		string text = (index < (GameplayCueCharacterAudioEvent.EAudioIndex)this.CueConfig.ParametersLength) ? this.CueConfig.Parameters((int)index) : null;
		if (string.IsNullOrEmpty(text))
		{
			return false;
		}
		WorldEntity entity = this.EntityHandle.Entity;
		CharacterAudioComponent characterAudioComponent = (entity != null) ? entity.GetComponent<CharacterAudioComponent>() : null;
		if (characterAudioComponent == null)
		{
			return false;
		}
		if (this.IsForbidTeammate)
		{
			Singleton<AudioSystem>.Instance.PostEvent(text);
		}
		else
		{
			Singleton<AudioSystem>.Instance.PostEvent(text, characterAudioComponent.GetAkComponent(null), null);
		}
		return true;
	}

	// Token: 0x0400C229 RID: 49705
	private bool HasStartAtActive;

	// Token: 0x0400C22A RID: 49706
	private bool IsForbidTeammate;

	// Token: 0x0400C22B RID: 49707
	private bool DisableByTeammate;

	// Token: 0x0200933C RID: 37692
	private enum EAudioIndex
	{
		// Token: 0x0403103E RID: 200766
		StartAtActive = 1,
		// Token: 0x0403103F RID: 200767
		StartAtInactive,
		// Token: 0x04031040 RID: 200768
		StopAtActive,
		// Token: 0x04031041 RID: 200769
		StopAtInactive,
		// Token: 0x04031042 RID: 200770
		Enable,
		// Token: 0x04031043 RID: 200771
		Disable,
		// Token: 0x04031044 RID: 200772
		EnableAtFirstActive
	}
}
