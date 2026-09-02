using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Component;
using AkiClient.Game.Aki.Data.Gameplay.PilotThrow;
using UnrealEngine;

// Token: 0x020025EC RID: 9708
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class PilotThrowModel : ModelBase<PilotThrowModel>
{
	// Token: 0x170017CF RID: 6095
	// (get) Token: 0x06013056 RID: 77910 RVA: 0x00545AA0 File Offset: 0x00543CA0
	[Nullable(2)]
	public BP_PilotThrowGameplaySetting_C Setting
	{
		[NullableContext(2)]
		get
		{
			if (this.SettingDataAsset == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.PilotThrow, ELogAuthor.CH, "[PilotThrowModel] SettingDataAsset is undefined", default(ReadOnlySpan<ValueTuple<string, object>>));
				return null;
			}
			return this.SettingDataAsset;
		}
	}

	// Token: 0x170017D0 RID: 6096
	// (get) Token: 0x06013057 RID: 77911 RVA: 0x00545ADC File Offset: 0x00543CDC
	public float AimPointInRangeDist
	{
		get
		{
			BP_PilotThrowGameplaySetting_C setting = this.Setting;
			return (float)(setting.目标点高亮距离 * setting.目标点高亮距离);
		}
	}

	// Token: 0x06013058 RID: 77912 RVA: 0x00545AFE File Offset: 0x00543CFE
	public void InitInteractInfo(int hookPointPbDataId, int titanEntityId, List<IPilotThrowTarget> pilotThrowTargets)
	{
		this.CurrentInteractHookPoint = hookPointPbDataId;
		this.TitanEntityId = titanEntityId;
		this.PilotThrowTargets = pilotThrowTargets;
	}

	// Token: 0x06013059 RID: 77913 RVA: 0x00545B15 File Offset: 0x00543D15
	public int GetCurrentInteractHookPoint()
	{
		return this.CurrentInteractHookPoint;
	}

	// Token: 0x0601305A RID: 77914 RVA: 0x00545B1D File Offset: 0x00543D1D
	public int GetCurrentTitanEntityId()
	{
		return this.TitanEntityId;
	}

	// Token: 0x0601305B RID: 77915 RVA: 0x00545B25 File Offset: 0x00543D25
	public IReadOnlyList<IPilotThrowTarget> GetPilotThrowTargets()
	{
		return this.PilotThrowTargets;
	}

	// Token: 0x0601305C RID: 77916 RVA: 0x00545B30 File Offset: 0x00543D30
	public float GetSwitchAimTargetTime()
	{
		return ConfigCommonParamById.GetFloatConfig("PilotThrowSwitchTargetTime").Value;
	}

	// Token: 0x0601305D RID: 77917 RVA: 0x00545B50 File Offset: 0x00543D50
	public bool IsInProjectileSplineLastPointRange(global::Vector point)
	{
		USplineComponent projectileSpline = ControllerBase<PilotThrowController>.Instance.ProjectileSpline;
		if (projectileSpline == null)
		{
			return false;
		}
		USplineComponent usplineComponent = projectileSpline;
		FVectorDouble fvectorDouble = point.ToUeVector(false);
		global::Vector v = global::Vector.Create(usplineComponent.D_FindLocationClosestToWorldLocation(fvectorDouble, ESplineCoordinateSpace.World));
		return global::Vector.DistSquared(point, v) <= (double)this.AimPointInRangeDist;
	}

	// Token: 0x0601305E RID: 77918 RVA: 0x00545B9C File Offset: 0x00543D9C
	protected override bool OnInit()
	{
		Singleton<ResourceSystem>.Instance.LoadTypeAsync("BP_PilotThrowGameplaySetting_C", delegate
		{
			Singleton<ResourceSystem>.Instance.LoadAsync<BP_PilotThrowGameplaySetting_C>("/Game/Aki/Data/Gameplay/PilotThrow/DA_PilotThrowSetting.DA_PilotThrowSetting", delegate([Nullable(2)] BP_PilotThrowGameplaySetting_C result, string _)
			{
				if (result == null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.PilotThrow;
					ELogAuthor author = ELogAuthor.CH;
					string message = "[PilotThrowModel] Load DA_PilotThrowSetting Failed";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Path", "/Game/Aki/Data/Gameplay/PilotThrow/DA_PilotThrowSetting.DA_PilotThrowSetting");
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return;
				}
				this.SettingDataAsset = result;
			}, 100, "js_undefined");
		}, "js_undefined");
		return true;
	}

	// Token: 0x04009459 RID: 37977
	private int CurrentInteractHookPoint;

	// Token: 0x0400945A RID: 37978
	private int TitanEntityId;

	// Token: 0x0400945B RID: 37979
	private List<IPilotThrowTarget> PilotThrowTargets = new List<IPilotThrowTarget>();

	// Token: 0x0400945C RID: 37980
	[Nullable(2)]
	private BP_PilotThrowGameplaySetting_C SettingDataAsset;

	// Token: 0x0400945D RID: 37981
	[Nullable(2)]
	public global::Vector CurrentInRangePoint;

	// Token: 0x0400945E RID: 37982
	public global::Vector LaunchDirection = global::Vector.Create(0.0, 0.0, 0.0);

	// Token: 0x0400945F RID: 37983
	public float LaunchSpeed;

	// Token: 0x04009460 RID: 37984
	public float LaunchGravity;

	// Token: 0x04009461 RID: 37985
	public bool NeedMotorRide;

	// Token: 0x04009462 RID: 37986
	public bool DisableInterrupt;

	// Token: 0x04009463 RID: 37987
	[Nullable(2)]
	public global::Vector ForceLookDir;

	// Token: 0x04009464 RID: 37988
	public Rotator CameraRot = Rotator.Create(0f, 0f, 0f);

	// Token: 0x04009465 RID: 37989
	public global::Vector CameraLoc = global::Vector.Create(0.0, 0.0, 0.0);

	// Token: 0x04009466 RID: 37990
	public global::Vector ProjectileSplineLastPoint = global::Vector.Create(0.0, 0.0, 0.0);
}
