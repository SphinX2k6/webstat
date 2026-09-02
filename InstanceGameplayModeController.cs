using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x02002008 RID: 8200
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class InstanceGameplayModeController : ControllerBase<InstanceGameplayModeController>
{
	// Token: 0x0600F7D7 RID: 63447 RVA: 0x0043DF0A File Offset: 0x0043C10A
	protected override bool OnInit()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnWorldDone));
		return true;
	}

	// Token: 0x0600F7D8 RID: 63448 RVA: 0x0043DF29 File Offset: 0x0043C129
	protected override bool OnClear()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnWorldDone));
		return true;
	}

	// Token: 0x0600F7D9 RID: 63449 RVA: 0x0043DF48 File Offset: 0x0043C148
	protected override bool OnChangeMode()
	{
		this.ResetAll();
		return true;
	}

	// Token: 0x0600F7DA RID: 63450 RVA: 0x0043DF51 File Offset: 0x0043C151
	protected override bool OnLeaveLevel()
	{
		this.ResetAll();
		return true;
	}

	// Token: 0x0600F7DB RID: 63451 RVA: 0x0043DF5C File Offset: 0x0043C15C
	private void ResetAll()
	{
		if (ModelBase<InstanceGameplayModeModel>.Instance.DefaultCameraMode == EDefaultCameraMode.FreeCamera)
		{
			this.ExitFreeCameraMode();
		}
		ModelBase<InstanceGameplayModeModel>.Instance.DefaultCameraMode = EDefaultCameraMode.FightCamera;
		if (Singleton<EventSystem>.Instance.Has<CreatureDataComponent, EntityHandle>(EEventName.CreateEntity, new Action<CreatureDataComponent, EntityHandle>(this.OnCreateEntity)))
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.CreateEntity, new Action<CreatureDataComponent, EntityHandle>(this.OnCreateEntity));
		}
		if (Singleton<EventSystem>.Instance.Has<ERemoveEntityType, EntityHandle>(EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity)))
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
		}
	}

	// Token: 0x0600F7DC RID: 63452 RVA: 0x0043DFFC File Offset: 0x0043C1FC
	private void OnWorldDone()
	{
		InstanceDungeon? instanceDungeon;
		int num = (ModelBase<GameModeModel>.Instance.InstanceDungeon != null) ? instanceDungeon.GetValueOrDefault().GameplayMode : 0;
		if (num <= 0)
		{
			return;
		}
		InstanceGameplayMode? gameplayModeConfig = ConfigBase<InstanceDungeonConfig>.Instance.GetGameplayModeConfig(num);
		if (gameplayModeConfig == null)
		{
			return;
		}
		if (gameplayModeConfig.Value.DisableAllPlayerRole)
		{
			this.DisableAllPlayerRole();
		}
		this.UpdateDefaultCameraMode((EDefaultCameraMode)gameplayModeConfig.Value.DefaultCameraMode, gameplayModeConfig.Value.GetCameraParamsArray());
	}

	// Token: 0x0600F7DD RID: 63453 RVA: 0x0043E089 File Offset: 0x0043C289
	private void UpdateDefaultCameraMode(EDefaultCameraMode mode, int[] @params)
	{
		ModelBase<InstanceGameplayModeModel>.Instance.DefaultCameraMode = mode;
		if (mode == EDefaultCameraMode.FightCamera)
		{
			return;
		}
		if (mode == EDefaultCameraMode.FreeCamera)
		{
			this.EnterFreeCameraMode(@params);
		}
	}

	// Token: 0x0600F7DE RID: 63454 RVA: 0x0043E0A8 File Offset: 0x0043C2A8
	private void EnterFreeCameraMode(int[] configIdList)
	{
		ModelBase<CameraModel>.Instance.MainModel.CreateFreeCamera();
		ModelBase<CameraModel>.Instance.MainModel.FreeCamera.LogicComponent.InitConfig(InstanceGameplayModeController.ToFloatArray(configIdList));
		ControllerBase<CameraController>.Instance.EnterCameraMode(ECustomCameraMode.Free, 0f, EViewTargetBlendFunction.VTBlend_Linear, 0f, null, false, "MainCamera", null);
	}

	// Token: 0x0600F7DF RID: 63455 RVA: 0x0043E103 File Offset: 0x0043C303
	private void ExitFreeCameraMode()
	{
		ControllerBase<CameraController>.Instance.ExitCameraMode(ECustomCameraMode.Free, 0f, EViewTargetBlendFunction.VTBlend_Linear, 0f, null, "MainCamera", null);
		ModelBase<CameraModel>.Instance.MainModel.DestroyFreeCamera();
	}

	// Token: 0x0600F7E0 RID: 63456 RVA: 0x0043E134 File Offset: 0x0043C334
	public void DisableAllPlayerRole()
	{
		IReadOnlyList<EntityHandle> allEntities = ModelBase<CreatureModel>.Instance.GetAllEntities();
		if (allEntities != null)
		{
			foreach (EntityHandle entityHandle in allEntities)
			{
				if (entityHandle.Valid && entityHandle.EntityType == 0)
				{
					WorldEntity entity = entityHandle.Entity;
					if (entity != null)
					{
						long creatureDataId = entityHandle.CreatureDataId;
						entity.DisableByKey(EEntityDisableKey.GameplayMode, true);
						ModelBase<InstanceGameplayModeModel>.Instance.DisabledCreatureSet.Add(creatureDataId);
					}
				}
			}
		}
		if (!Singleton<EventSystem>.Instance.Has<CreatureDataComponent, EntityHandle>(EEventName.CreateEntity, new Action<CreatureDataComponent, EntityHandle>(this.OnCreateEntity)))
		{
			Singleton<EventSystem>.Instance.Add<CreatureDataComponent, EntityHandle>(EEventName.CreateEntity, new Action<CreatureDataComponent, EntityHandle>(this.OnCreateEntity));
		}
		if (!Singleton<EventSystem>.Instance.Has<ERemoveEntityType, EntityHandle>(EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity)))
		{
			Singleton<EventSystem>.Instance.Add<ERemoveEntityType, EntityHandle>(EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
		}
	}

	// Token: 0x0600F7E1 RID: 63457 RVA: 0x0043E234 File Offset: 0x0043C434
	private void OnCreateEntity(CreatureDataComponent creatureData, EntityHandle entityHandle)
	{
		if (entityHandle.EntityType == 0)
		{
			WorldEntity entity = entityHandle.Entity;
			if (entity != null && entity.Valid)
			{
				entity.DisableByKey(EEntityDisableKey.GameplayMode, true);
				ModelBase<InstanceGameplayModeModel>.Instance.DisabledCreatureSet.Add(entityHandle.CreatureDataId);
			}
		}
	}

	// Token: 0x0600F7E2 RID: 63458 RVA: 0x0043E279 File Offset: 0x0043C479
	private void OnRemoveEntity(ERemoveEntityType removeType, EntityHandle entityHandle)
	{
		if (entityHandle.EntityType == 0)
		{
			ModelBase<InstanceGameplayModeModel>.Instance.DisabledCreatureSet.Remove(entityHandle.CreatureDataId);
		}
	}

	// Token: 0x0600F7E3 RID: 63459 RVA: 0x0043E29C File Offset: 0x0043C49C
	private static float[] ToFloatArray(int[] intArray)
	{
		float[] array = new float[intArray.Length];
		for (int i = 0; i < intArray.Length; i++)
		{
			array[i] = (float)intArray[i];
		}
		return array;
	}
}
