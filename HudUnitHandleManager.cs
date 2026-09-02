using System;
using System.Collections.Generic;

// Token: 0x02001F89 RID: 8073
public class HudUnitHandleManager
{
	// Token: 0x0600F1DA RID: 61914 RVA: 0x00420C18 File Offset: 0x0041EE18
	public static void Init()
	{
		Singleton<HudUnitManager>.Instance.HudUnitHandleClassArray = new Type[]
		{
			typeof(LockCursorHandle),
			typeof(StrengthHandle),
			typeof(AimHandle),
			typeof(MonsterCursorHandle),
			typeof(ManipulateCursorHandle),
			typeof(ManipulateAimHandle),
			typeof(LockExecutionHandle),
			typeof(CameraAimHandle),
			typeof(LockPredictedHandle),
			typeof(RoleSideEnergyHandle),
			typeof(SlowTimeHandle)
		};
		Singleton<HudUnitManager>.Instance.HudUnitHandleClassMap = new Dictionary<EHudUnitType, Type>
		{
			{
				EHudUnitType.MigrationStrength,
				typeof(MigrationStrengthHandle)
			},
			{
				EHudUnitType.FollowShootAim,
				typeof(FollowShootAimHandle)
			},
			{
				EHudUnitType.FollowShootAutoAim,
				typeof(FollowShootAutoAimHandle)
			},
			{
				EHudUnitType.FollowShootOnlyAutoAim,
				typeof(FollowShootAutoAimHandle)
			},
			{
				EHudUnitType.FollowShootVisionCar,
				typeof(FollowShootAutoAimHandle)
			},
			{
				EHudUnitType.TreasureCompass,
				typeof(TreasureCompassHandle)
			},
			{
				EHudUnitType.FlyRaceStrength,
				typeof(FlyRaceStrengthHandle)
			},
			{
				EHudUnitType.LuPaAim,
				typeof(LuPaAimHandle)
			},
			{
				EHudUnitType.WeeklyRogue,
				typeof(WeeklyRogueHandle)
			},
			{
				EHudUnitType.TDFollowShootAim,
				typeof(TDFollowShootAimHandle)
			},
			{
				EHudUnitType.AiMiSiHud,
				typeof(AiMiSiHudHandle)
			},
			{
				EHudUnitType.FollowShootAutoAimNoRing,
				typeof(FollowShootAutoAimHandle)
			},
			{
				EHudUnitType.RoverlikeMonsterCursor,
				typeof(RoverlikeMonsterCursorHandle)
			}
		};
	}
}
