using System;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using CSharpScript.Game;
using CSharpScript.Game.Camera;
using UnrealEngine;

// Token: 0x02001D13 RID: 7443
public class GameBudgetPlotMode : GameBudgetMode
{
	// Token: 0x0600DA95 RID: 55957 RVA: 0x003ABBD7 File Offset: 0x003A9DD7
	public GameBudgetPlotMode() : base("EGameBudgetMode.Plot", EGameBudgetMode.Plot)
	{
	}

	// Token: 0x0600DA96 RID: 55958 RVA: 0x003ABBE8 File Offset: 0x003A9DE8
	public override void OnEnterMode()
	{
		Singleton<GameBudgetInterfaceController>.Instance.SetCenterRole(Global.BaseCharacter);
		SequenceCamera sequenceCamera = ModelBase<CameraModel>.Instance.MainModel.SequenceCamera;
		BP_CineCamera_C bp_CineCamera_C;
		if (sequenceCamera == null)
		{
			bp_CineCamera_C = null;
		}
		else
		{
			SequenceCameraDisplayComponent displayComponent = sequenceCamera.DisplayComponent;
			bp_CineCamera_C = ((displayComponent != null) ? displayComponent.CineCamera : null);
		}
		BP_CineCamera_C bp_CineCamera_C2 = bp_CineCamera_C;
		if (bp_CineCamera_C2 != null)
		{
			Singleton<GameBudgetInterfaceController>.Instance.SequenceCamera = bp_CineCamera_C2;
			UKuroGameBudgetAllocatorCSharpInterface.AddAssistantActor(bp_CineCamera_C2);
		}
	}

	// Token: 0x0600DA97 RID: 55959 RVA: 0x003ABC40 File Offset: 0x003A9E40
	public override void OnExitMode()
	{
		AActor sequenceCamera = Singleton<GameBudgetInterfaceController>.Instance.SequenceCamera;
		if (sequenceCamera != null)
		{
			UKuroGameBudgetAllocatorCSharpInterface.RemoveAssistantActor(sequenceCamera);
			Singleton<GameBudgetInterfaceController>.Instance.SequenceCamera = null;
		}
	}
}
