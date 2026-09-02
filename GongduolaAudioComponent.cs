using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.Audio;
using UnrealEngine;

// Token: 0x0200328A RID: 12938
[NullableContext(1)]
[Nullable(0)]
public class GongduolaAudioComponent : VehicleAudioComponent
{
	// Token: 0x0601B151 RID: 110929 RVA: 0x0081D862 File Offset: 0x0081BA62
	protected override void OnVehicleBeenEntered(VehiclePassengerInfo info, bool byChangeRole)
	{
		ModelBase<GameAudioModel>.Instance.GondolaGetOnAudioEvent(base.Entity);
		if (info.IsNpcPassenger())
		{
			GameAudioModel instance = ModelBase<GameAudioModel>.Instance;
			if (instance != null && instance.CheckRideSharingState())
			{
				GameAudioModel instance2 = ModelBase<GameAudioModel>.Instance;
				if (instance2 == null)
				{
					return;
				}
				instance2.PlayRideSharingPlotAudio(EGondolaVoiceTriggeredType.InviteRole);
			}
		}
	}

	// Token: 0x0601B152 RID: 110930 RVA: 0x0081D8A0 File Offset: 0x0081BAA0
	protected override void OnVehicleBeenLeaved(VehiclePassengerInfo info, bool byChangeRole)
	{
		ModelBase<GameAudioModel>.Instance.GondolaGetOnAudioEvent(base.Entity);
	}

	// Token: 0x0601B153 RID: 110931 RVA: 0x0081D8B4 File Offset: 0x0081BAB4
	public override void UpdateVehicleMoveSound(float speed, AActor owner)
	{
		if (Math.Abs(this.LastSpeed - speed) < 50f && (this.LastSpeed == 0f || speed != 0f))
		{
			return;
		}
		this.LastSpeed = speed;
		Singleton<AudioSystem>.Instance.SetRtpcValue("vehicle_speed", Singleton<MathUtils>.Instance.Clamp(speed / 100f, 0f, 50f), new SetRtpcValueArgs?(new SetRtpcValueArgs
		{
			Actor = owner
		}));
		if (speed == 0f)
		{
			this.StopMoveSound(owner);
			return;
		}
		if (this.MoveSoundEventHandle == 0)
		{
			this.MoveSoundEventHandle = Singleton<AudioSystem>.Instance.PostEvent("play_interactive_gongduola_move", owner, null);
		}
	}

	// Token: 0x0601B154 RID: 110932 RVA: 0x0081D96C File Offset: 0x0081BB6C
	private void StopMoveSound(AActor owner)
	{
		if (this.MoveSoundEventHandle != 0)
		{
			Singleton<AudioSystem>.Instance.ExecuteAction(this.MoveSoundEventHandle, EAudioActionType.Stop, null);
			this.MoveSoundEventHandle = 0;
		}
	}

	// Token: 0x0601B155 RID: 110933 RVA: 0x0081D9A4 File Offset: 0x0081BBA4
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		GongduolaAudioComponent gongduolaAudioComponent = (GongduolaAudioComponent)componentTemplate;
		if (base.CanResetComponentProperty("LastSpeed"))
		{
			this.LastSpeed = gongduolaAudioComponent.LastSpeed;
		}
		if (base.CanResetComponentProperty("MoveSoundEventHandle"))
		{
			this.MoveSoundEventHandle = gongduolaAudioComponent.MoveSoundEventHandle;
		}
		return true;
	}

	// Token: 0x0400DC2A RID: 56362
	private const string VEHICLE_MOVE_EVENT = "play_interactive_gongduola_move";

	// Token: 0x0400DC2B RID: 56363
	private const float MAX_VEHICLE_SPEED_RTPC_PARAM = 50f;

	// Token: 0x0400DC2C RID: 56364
	private const float CHANGE_VEHICLE_SPEED_TOLERENCE = 50f;

	// Token: 0x0400DC2D RID: 56365
	private const float VEHICLE_MOVE_SPEED_MAPPING = 100f;

	// Token: 0x0400DC2E RID: 56366
	private float LastSpeed;

	// Token: 0x0400DC2F RID: 56367
	private int MoveSoundEventHandle;
}
