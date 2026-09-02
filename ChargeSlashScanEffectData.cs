using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Effect.BluePrint.BP_FX_Common;
using UnrealEngine;

// Token: 0x0200324C RID: 12876
[NullableContext(1)]
[Nullable(0)]
public class ChargeSlashScanEffectData : IStaticVariableResetter
{
	// Token: 0x0601ACE7 RID: 109799 RVA: 0x007FDC28 File Offset: 0x007FBE28
	static ChargeSlashScanEffectData()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(ChargeSlashScanEffectData.CreateStaticDefaultValue), new Action(ChargeSlashScanEffectData.ResetStaticDefaultValue));
	}

	// Token: 0x0601ACE8 RID: 109800 RVA: 0x007FDC48 File Offset: 0x007FBE48
	public ChargeSlashScanEffectData(int id, BP_DistortionWave_C actor, FVectorDouble loc)
	{
		this.Id = id;
		this.EffectActor = actor;
		this.CurLoc = new FVectorDouble?(loc);
		this.CurTime = 0f;
		this.CurRadius = 0.0;
	}

	// Token: 0x0601ACE9 RID: 109801 RVA: 0x007FDCA5 File Offset: 0x007FBEA5
	public bool Update(float delta)
	{
		return true;
	}

	// Token: 0x0601ACEA RID: 109802 RVA: 0x007FDCA8 File Offset: 0x007FBEA8
	private static void InitSphereTrace()
	{
		ChargeSlashScanEffectData.SphereTrace = new UTraceSphereElement();
		ChargeSlashScanEffectData.SphereTrace.WorldContextObject = GlobalData.World;
		ChargeSlashScanEffectData.SphereTrace.bIsSingle = false;
		ChargeSlashScanEffectData.SphereTrace.bIgnoreSelf = true;
		ChargeSlashScanEffectData.SphereTrace.AddObjectTypeQuery(KuroObjectTypeQuery.WorldDynamic);
		ChargeSlashScanEffectData.SphereTrace.AddObjectTypeQuery(KuroObjectTypeQuery.Pawn);
		ChargeSlashScanEffectData.SphereTrace.AddObjectTypeQuery(KuroObjectTypeQuery.KuroTrigger);
		ChargeSlashScanEffectData.SphereTrace.AddObjectTypeQuery(KuroObjectTypeQuery.PawnPlayer);
		ChargeSlashScanEffectData.SphereTrace.AddObjectTypeQuery(KuroObjectTypeQuery.PawnMonster);
		if (ChargeSlashScanEffectData.Timer == null)
		{
			TimerSystemInstance instance = TimerSystem.Instance;
			TTimerAction action;
			if ((action = ChargeSlashScanEffectData.<>O.<0>__CheckAndReleaseActor) == null)
			{
				action = (ChargeSlashScanEffectData.<>O.<0>__CheckAndReleaseActor = new TTimerAction(ChargeSlashScanEffectData.CheckAndReleaseActor));
			}
			ChargeSlashScanEffectData.Timer = instance.Forever(action, 5000f, 1f, null, null, true);
		}
	}

	// Token: 0x0601ACEB RID: 109803 RVA: 0x007FDD6D File Offset: 0x007FBF6D
	private static void CheckAndReleaseActor(float delta)
	{
		if (ChargeSlashScanEffectData.UseTrace)
		{
			ChargeSlashScanEffectData.UseTrace = false;
			return;
		}
		if (ChargeSlashScanEffectData.SphereTrace != null)
		{
			ChargeSlashScanEffectData.SphereTrace.Dispose();
			ChargeSlashScanEffectData.SphereTrace = null;
		}
		TimerSystem.Instance.Remove(ChargeSlashScanEffectData.Timer);
		ChargeSlashScanEffectData.Timer = null;
	}

	// Token: 0x0601ACEC RID: 109804 RVA: 0x007FDDAA File Offset: 0x007FBFAA
	public static void CreateStaticDefaultValue()
	{
		ChargeSlashScanEffectData.SphereTrace = null;
		ChargeSlashScanEffectData.UseTrace = false;
		ChargeSlashScanEffectData.Timer = null;
	}

	// Token: 0x0601ACED RID: 109805 RVA: 0x007FDDBE File Offset: 0x007FBFBE
	public static void ResetStaticDefaultValue()
	{
		ChargeSlashScanEffectData.SphereTrace = null;
		ChargeSlashScanEffectData.UseTrace = false;
		ChargeSlashScanEffectData.Timer = null;
	}

	// Token: 0x0400D969 RID: 55657
	private const float SCAN_EFFECT_STOP_TIME = 1.6f;

	// Token: 0x0400D96A RID: 55658
	private const int TIMER_PERIOD = 5000;

	// Token: 0x0400D96B RID: 55659
	public int Id;

	// Token: 0x0400D96C RID: 55660
	[Nullable(2)]
	public BP_DistortionWave_C EffectActor;

	// Token: 0x0400D96D RID: 55661
	private readonly FVectorDouble? CurLoc;

	// Token: 0x0400D96E RID: 55662
	private float CurTime;

	// Token: 0x0400D96F RID: 55663
	private double CurRadius;

	// Token: 0x0400D970 RID: 55664
	private readonly HashSet<AActor> ScannedActor = new HashSet<AActor>();

	// Token: 0x0400D971 RID: 55665
	private readonly HashSet<TsBaseCharacter> TsBaseCharSet = new HashSet<TsBaseCharacter>();

	// Token: 0x0400D972 RID: 55666
	[Nullable(2)]
	private static UTraceSphereElement SphereTrace;

	// Token: 0x0400D973 RID: 55667
	private static bool UseTrace;

	// Token: 0x0400D974 RID: 55668
	[Nullable(2)]
	private static TimerHandle Timer;

	// Token: 0x02009422 RID: 37922
	[CompilerGenerated]
	private static class <>O
	{
		// Token: 0x04031337 RID: 201527
		[Nullable(0)]
		public static TTimerAction <0>__CheckAndReleaseActor;
	}
}
