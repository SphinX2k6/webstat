using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Effect.BluePrint.BP_FX_Common;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.LevelGamePlay.Common;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem.SpecificScanEffect
{
	// Token: 0x02004829 RID: 18473
	public class SpecificScanEffectData : IStaticVariableResetter
	{
		// Token: 0x06030122 RID: 196898 RVA: 0x00BA6C84 File Offset: 0x00BA4E84
		public SpecificScanEffectData(int id, [Nullable(new byte[]
		{
			0,
			1,
			1
		})] OneOf<BP_DistortionWave_C, BP_Fx_Scanning_2_7_C> actor, FVectorDouble loc, ESpecificScanType? type = 1)
		{
			ESpecificScanType value = type.GetValueOrDefault();
			if (type == null)
			{
				value = ESpecificScanType.ChargeSlash;
				type = new ESpecificScanType?(value);
			}
			this.Id = id;
			this.EffectActor = new OneOf<BP_DistortionWave_C, BP_Fx_Scanning_2_7_C>?(actor);
			this.CurLoc = new FVectorDouble?(loc);
			this.CurTime = 0f;
			this.CurRadius = 0f;
			this.ScanType = type.Value;
		}

		// Token: 0x06030123 RID: 196899 RVA: 0x00BA6D11 File Offset: 0x00BA4F11
		static SpecificScanEffectData()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(SpecificScanEffectData.CreateStaticDefaultValue), new Action(SpecificScanEffectData.ResetStaticDefaultValue));
		}

		// Token: 0x06030124 RID: 196900 RVA: 0x00BA6D30 File Offset: 0x00BA4F30
		public static void CreateStaticDefaultValue()
		{
			SpecificScanEffectData._sphereTrace = null;
			SpecificScanEffectData._useTrace = false;
			SpecificScanEffectData._timer = null;
			SpecificScanEffectData._maxScanDistanceInternal = null;
			SpecificScanEffectData._maxScanInteractionEffectDistanceInternal = null;
		}

		// Token: 0x06030125 RID: 196901 RVA: 0x00BA6D5A File Offset: 0x00BA4F5A
		public static void ResetStaticDefaultValue()
		{
			SpecificScanEffectData._sphereTrace = null;
			SpecificScanEffectData._useTrace = false;
			SpecificScanEffectData._timer = null;
			SpecificScanEffectData._maxScanDistanceInternal = null;
			SpecificScanEffectData._maxScanInteractionEffectDistanceInternal = null;
		}

		// Token: 0x06030126 RID: 196902 RVA: 0x00BA6D84 File Offset: 0x00BA4F84
		public bool Update(float delta)
		{
			this.CurTime += delta * (float)Singleton<TimeUtil>.Instance.Millisecond;
			if (this.CurRadius >= SpecificScanEffectData.GetScanMaxDistance())
			{
				return false;
			}
			double num = UKismetMathLibrary.D_FInterpTo(0.0, (double)SpecificScanEffectData.GetScanMaxDistance(), this.CurTime, 0.625f);
			this.CurRadius = (float)num;
			if (SpecificScanEffectData._sphereTrace == null)
			{
				SpecificScanEffectData.InitSphereTrace();
			}
			SpecificScanEffectData._sphereTrace.Radius = this.CurRadius;
			Singleton<TraceElementCommon>.Instance.SetStartLocation(SpecificScanEffectData._sphereTrace, this.CurLoc);
			Singleton<TraceElementCommon>.Instance.SetEndLocation(SpecificScanEffectData._sphereTrace, this.CurLoc);
			bool flag = Singleton<TraceElementCommon>.Instance.SphereTrace(SpecificScanEffectData._sphereTrace, "ChargeSlashScanEffectData");
			SpecificScanEffectData._useTrace = true;
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			AActor aactor;
			if (baseCharacter == null)
			{
				aactor = null;
			}
			else
			{
				CharacterActorComponent characterActorComponent = baseCharacter.CharacterActorComponent;
				aactor = ((characterActorComponent != null) ? characterActorComponent.Owner : null);
			}
			AActor aactor2 = aactor;
			if (flag)
			{
				TArray<TWeakObjectPtr<AActor>> actors = SpecificScanEffectData._sphereTrace.HitResult.Actors;
				for (int i = 0; i < actors.Num(); i++)
				{
					AActor aactor3 = actors.Get(i).Get();
					if (aactor3 != null && aactor3 != aactor2 && !this.ScannedActor.Contains(aactor3))
					{
						if (ControllerBase<LevelGamePlayController>.Instance.HandleScanResponse(aactor3, (int)this.ScanType))
						{
							this.ScannedActor.Add(aactor3);
						}
						TsBaseCharacter tsBaseCharacter = aactor3 as TsBaseCharacter;
						if (tsBaseCharacter != null && tsBaseCharacter.Camp != ECamp.Player && this.TsBaseCharSet.Add(tsBaseCharacter))
						{
							BaseTagComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseTagComponent>(tsBaseCharacter.EntityId);
							if (component != null && component.Valid)
							{
								component.AddTag(new int?(GameplayTagDefine.EGameplayTagId["角色.BaseRole.技能通用标识.扫描感应中"]));
							}
						}
					}
				}
			}
			return true;
		}

		// Token: 0x06030127 RID: 196903 RVA: 0x00BA6F54 File Offset: 0x00BA5154
		private static void InitSphereTrace()
		{
			SpecificScanEffectData._sphereTrace = new UTraceSphereElement();
			SpecificScanEffectData._sphereTrace.WorldContextObject = GlobalData.World;
			SpecificScanEffectData._sphereTrace.bIsSingle = false;
			SpecificScanEffectData._sphereTrace.bIgnoreSelf = true;
			SpecificScanEffectData._sphereTrace.AddObjectTypeQuery(KuroObjectTypeQuery.WorldDynamic);
			SpecificScanEffectData._sphereTrace.AddObjectTypeQuery(KuroObjectTypeQuery.Pawn);
			SpecificScanEffectData._sphereTrace.AddObjectTypeQuery(KuroObjectTypeQuery.KuroTrigger);
			SpecificScanEffectData._sphereTrace.AddObjectTypeQuery(KuroObjectTypeQuery.PawnPlayer);
			SpecificScanEffectData._sphereTrace.AddObjectTypeQuery(KuroObjectTypeQuery.PawnMonster);
			if (SpecificScanEffectData._timer == null)
			{
				TimerSystemInstance instance = TimerSystem.Instance;
				TTimerAction action;
				if ((action = SpecificScanEffectData.<>O.<0>__CheckAndReleaseActor) == null)
				{
					action = (SpecificScanEffectData.<>O.<0>__CheckAndReleaseActor = new TTimerAction(SpecificScanEffectData.CheckAndReleaseActor));
				}
				SpecificScanEffectData._timer = instance.Forever(action, 5000f, 1f, null, null, true);
			}
		}

		// Token: 0x06030128 RID: 196904 RVA: 0x00BA7019 File Offset: 0x00BA5219
		private static void CheckAndReleaseActor(float delta)
		{
			if (SpecificScanEffectData._useTrace)
			{
				SpecificScanEffectData._useTrace = false;
				return;
			}
			if (SpecificScanEffectData._sphereTrace != null)
			{
				SpecificScanEffectData._sphereTrace.Dispose();
				SpecificScanEffectData._sphereTrace = null;
			}
			TimerSystem.Instance.Remove(SpecificScanEffectData._timer);
			SpecificScanEffectData._timer = null;
		}

		// Token: 0x1700823C RID: 33340
		// (get) Token: 0x06030129 RID: 196905 RVA: 0x00BA7058 File Offset: 0x00BA5258
		public static float MaxScanDistance
		{
			get
			{
				if (SpecificScanEffectData._maxScanDistanceInternal == null)
				{
					SpecificScanEffectData._maxScanDistanceInternal = new float?((float)ConfigBase<LevelGamePlayConfig>.Instance.ScanMaxDistance);
					SpecificScanEffectData._maxScanDistanceInternal *= (float)100;
				}
				return SpecificScanEffectData._maxScanDistanceInternal.Value;
			}
		}

		// Token: 0x1700823D RID: 33341
		// (get) Token: 0x0603012A RID: 196906 RVA: 0x00BA70C4 File Offset: 0x00BA52C4
		public static float MaxScanInteractionEffectDistance
		{
			get
			{
				if (SpecificScanEffectData._maxScanInteractionEffectDistanceInternal == null)
				{
					SpecificScanEffectData._maxScanInteractionEffectDistanceInternal = new float?((float)ConfigBase<LevelGamePlayConfig>.Instance.ScanShowInteractionEffectMaxDistance);
					SpecificScanEffectData._maxScanInteractionEffectDistanceInternal *= (float)100;
				}
				return SpecificScanEffectData._maxScanInteractionEffectDistanceInternal.Value;
			}
		}

		// Token: 0x0603012B RID: 196907 RVA: 0x00BA712D File Offset: 0x00BA532D
		public static float GetScanMaxDistance()
		{
			return Math.Max(SpecificScanEffectData.MaxScanDistance, SpecificScanEffectData.MaxScanInteractionEffectDistance);
		}

		// Token: 0x0401B994 RID: 113044
		private const float SCAN_EFFECT_STOP_TIME = 1.6f;

		// Token: 0x0401B995 RID: 113045
		private const int TIMER_PERIOD = 5000;

		// Token: 0x0401B996 RID: 113046
		public int Id;

		// Token: 0x0401B997 RID: 113047
		[Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		public OneOf<BP_DistortionWave_C, BP_Fx_Scanning_2_7_C>? EffectActor;

		// Token: 0x0401B998 RID: 113048
		private readonly FVectorDouble? CurLoc;

		// Token: 0x0401B999 RID: 113049
		private float CurTime;

		// Token: 0x0401B99A RID: 113050
		private float CurRadius;

		// Token: 0x0401B99B RID: 113051
		private readonly ESpecificScanType ScanType = ESpecificScanType.ChargeSlash;

		// Token: 0x0401B99C RID: 113052
		[Nullable(1)]
		private readonly HashSet<AActor> ScannedActor = new HashSet<AActor>();

		// Token: 0x0401B99D RID: 113053
		[Nullable(1)]
		private readonly HashSet<TsBaseCharacter> TsBaseCharSet = new HashSet<TsBaseCharacter>();

		// Token: 0x0401B99E RID: 113054
		[Nullable(2)]
		private static UTraceSphereElement _sphereTrace;

		// Token: 0x0401B99F RID: 113055
		private static bool _useTrace;

		// Token: 0x0401B9A0 RID: 113056
		[Nullable(2)]
		private static TimerHandle _timer;

		// Token: 0x0401B9A1 RID: 113057
		private static float? _maxScanDistanceInternal;

		// Token: 0x0401B9A2 RID: 113058
		private static float? _maxScanInteractionEffectDistanceInternal;

		// Token: 0x0200A90B RID: 43275
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x04034683 RID: 214659
			public static TTimerAction <0>__CheckAndReleaseActor;
		}
	}
}
