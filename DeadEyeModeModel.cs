using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x02001B24 RID: 6948
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class DeadEyeModeModel : ModelBase<DeadEyeModeModel>
{
	// Token: 0x17001008 RID: 4104
	// (get) Token: 0x0600C81B RID: 51227 RVA: 0x0034F91B File Offset: 0x0034DB1B
	public EDeadEyeModeType Type
	{
		get
		{
			return this.InnerType;
		}
	}

	// Token: 0x17001009 RID: 4105
	// (get) Token: 0x0600C81C RID: 51228 RVA: 0x0034F923 File Offset: 0x0034DB23
	public EDeadEyeModeStage CurDeadEyeModeStage
	{
		get
		{
			return this.DeadEyeModeStage;
		}
	}

	// Token: 0x1700100A RID: 4106
	// (get) Token: 0x0600C81D RID: 51229 RVA: 0x0034F92B File Offset: 0x0034DB2B
	public bool IsInDeadEyeMode
	{
		get
		{
			return this.CurDeadEyeModeStage == EDeadEyeModeStage.JumpCamp || this.CurDeadEyeModeStage == EDeadEyeModeStage.AimInput;
		}
	}

	// Token: 0x1700100B RID: 4107
	// (get) Token: 0x0600C81E RID: 51230 RVA: 0x0034F941 File Offset: 0x0034DB41
	public int MaxEnergy
	{
		get
		{
			return this.InnerMaxEnergy;
		}
	}

	// Token: 0x1700100C RID: 4108
	// (get) Token: 0x0600C81F RID: 51231 RVA: 0x0034F949 File Offset: 0x0034DB49
	public int BulletConsumption
	{
		get
		{
			return this.EnergyConfig.BulletConsumption;
		}
	}

	// Token: 0x1700100D RID: 4109
	// (get) Token: 0x0600C820 RID: 51232 RVA: 0x0034F956 File Offset: 0x0034DB56
	public int TimeConsumption
	{
		get
		{
			return this.EnergyConfig.TimeConsumption;
		}
	}

	// Token: 0x1700100E RID: 4110
	// (get) Token: 0x0600C821 RID: 51233 RVA: 0x0034F963 File Offset: 0x0034DB63
	public int SubCameraTag
	{
		get
		{
			return this.InnerSubCameraTag;
		}
	}

	// Token: 0x1700100F RID: 4111
	// (get) Token: 0x0600C822 RID: 51234 RVA: 0x0034F96B File Offset: 0x0034DB6B
	public float TimeScale
	{
		get
		{
			return this.InnerTimeScale;
		}
	}

	// Token: 0x0600C823 RID: 51235 RVA: 0x0034F973 File Offset: 0x0034DB73
	protected override bool OnLeaveLevel()
	{
		this.HighlightDataLockedAsset = null;
		return true;
	}

	// Token: 0x0600C824 RID: 51236 RVA: 0x0034F980 File Offset: 0x0034DB80
	[NullableContext(2)]
	public void StartDeadEyeMode(EDeadEyeModeType type, [Nullable(1)] IDeadeyeEnergyConfig energyConfig, int maxEnergy, float lookAtTransitionTime, long triggerEntityCreatureDataId, float timeScale, int? subCameraTag = null, IDeadEyeEffectConfig effectConfig = null, string finishSendSelfEvent = null)
	{
		this.InnerType = type;
		this.EnergyConfig = energyConfig;
		this.InnerTimeScale = timeScale;
		this.InnerSubCameraTag = subCameraTag.GetValueOrDefault();
		this.InnerMaxEnergy = maxEnergy;
		this.CurrentEnergy = (float)this.MaxEnergy;
		this.TimeScaleTransitionTime = lookAtTransitionTime;
		this.TriggerEntityCreatureDataId = triggerEntityCreatureDataId;
		this.FilterEffectPath = ((effectConfig != null) ? effectConfig.FilterEffect : null);
		this.TargerNotLockDaPath = ((effectConfig != null) ? effectConfig.TargetIdleMaterialDa : null);
		this.TargerLockedDaPath = ((effectConfig != null) ? effectConfig.TargetLockedMaterialDa : null);
		this.FinishEvent = finishSendSelfEvent;
		this.LerpElapsedTime = 0f;
		this.ViewStartSequenceFinish = false;
		this.RevertMaterialComponentsMaps.Clear();
		this.CharRenderingComponents.Clear();
	}

	// Token: 0x0600C825 RID: 51237 RVA: 0x0034FA40 File Offset: 0x0034DC40
	public void EnterNextStage()
	{
		this.DeadEyeModeStage++;
		Singleton<EventSystem>.Instance.Emit(EEventName.OnDeadEyeModeStageChange);
	}

	// Token: 0x0600C826 RID: 51238 RVA: 0x0034FA60 File Offset: 0x0034DC60
	public void EndDeadEyeMode()
	{
		this.DeadEyeModeStage = EDeadEyeModeStage.None;
		this.EntityFocusOnList.Clear();
		this.EntityLockedList.Clear();
		this.TargetLocationList.Clear();
	}

	// Token: 0x0600C827 RID: 51239 RVA: 0x0034FA8A File Offset: 0x0034DC8A
	public void AddFocusEntity(EntityHandle entityHandle)
	{
		this.EntityFocusOnList.Add(entityHandle);
	}

	// Token: 0x0600C828 RID: 51240 RVA: 0x0034FA98 File Offset: 0x0034DC98
	public List<EntityHandle> GetFocusEntities()
	{
		return this.EntityFocusOnList;
	}

	// Token: 0x0600C829 RID: 51241 RVA: 0x0034FAA0 File Offset: 0x0034DCA0
	public void AddTargetLocation(Vector location)
	{
		this.TargetLocationList.Add(location);
	}

	// Token: 0x0600C82A RID: 51242 RVA: 0x0034FAAE File Offset: 0x0034DCAE
	public List<Vector> GetTargetLocations()
	{
		return this.TargetLocationList;
	}

	// Token: 0x0600C82B RID: 51243 RVA: 0x0034FAB6 File Offset: 0x0034DCB6
	public bool CheckEnergyEnoughLockTarget()
	{
		return this.CurrentEnergy >= (float)this.BulletConsumption;
	}

	// Token: 0x0600C82C RID: 51244 RVA: 0x0034FACA File Offset: 0x0034DCCA
	public void RecordLockedTarget(EntityHandle targetEntity)
	{
		this.EntityLockedList.Add(targetEntity);
	}

	// Token: 0x0600C82D RID: 51245 RVA: 0x0034FAD8 File Offset: 0x0034DCD8
	public List<EntityHandle> GetLockedEntities()
	{
		return this.EntityLockedList;
	}

	// Token: 0x04006001 RID: 24577
	private EDeadEyeModeType InnerType;

	// Token: 0x04006002 RID: 24578
	[Nullable(2)]
	private IDeadeyeEnergyConfig EnergyConfig;

	// Token: 0x04006003 RID: 24579
	private readonly List<EntityHandle> EntityFocusOnList = new List<EntityHandle>();

	// Token: 0x04006004 RID: 24580
	private readonly List<Vector> TargetLocationList = new List<Vector>();

	// Token: 0x04006005 RID: 24581
	private readonly List<EntityHandle> EntityLockedList = new List<EntityHandle>();

	// Token: 0x04006006 RID: 24582
	public readonly Dictionary<UStaticMeshComponent, Dictionary<int, UMaterialInterface>> RevertMaterialComponentsMaps = new Dictionary<UStaticMeshComponent, Dictionary<int, UMaterialInterface>>();

	// Token: 0x04006007 RID: 24583
	public readonly Dictionary<CharRenderingComponent, int> CharRenderingComponents = new Dictionary<CharRenderingComponent, int>();

	// Token: 0x04006008 RID: 24584
	private EDeadEyeModeStage DeadEyeModeStage;

	// Token: 0x04006009 RID: 24585
	private float InnerTimeScale = 0.02f;

	// Token: 0x0400600A RID: 24586
	private int InnerMaxEnergy;

	// Token: 0x0400600B RID: 24587
	private int InnerSubCameraTag;

	// Token: 0x0400600C RID: 24588
	public float CurrentEnergy;

	// Token: 0x0400600D RID: 24589
	public float TimeScaleTransitionTime;

	// Token: 0x0400600E RID: 24590
	public long TriggerEntityCreatureDataId;

	// Token: 0x0400600F RID: 24591
	[Nullable(2)]
	public string FilterEffectPath;

	// Token: 0x04006010 RID: 24592
	[Nullable(2)]
	public string TargerNotLockDaPath;

	// Token: 0x04006011 RID: 24593
	[Nullable(2)]
	public string TargerLockedDaPath;

	// Token: 0x04006012 RID: 24594
	[Nullable(2)]
	public string FinishEvent;

	// Token: 0x04006013 RID: 24595
	public bool HideFollowShooterWhenFinish = true;

	// Token: 0x04006014 RID: 24596
	public float LerpElapsedTime;

	// Token: 0x04006015 RID: 24597
	public bool ViewStartSequenceFinish;

	// Token: 0x04006016 RID: 24598
	[Nullable(2)]
	public UPrimaryDataAsset DeadEyeFollowShooterConfig;

	// Token: 0x04006017 RID: 24599
	[Nullable(2)]
	public PD_CharacterControllerData_C HighlightDataLockedAsset;

	// Token: 0x04006018 RID: 24600
	[Nullable(2)]
	public PD_CharacterControllerData_C HighlightDataNotLockAsset;
}
