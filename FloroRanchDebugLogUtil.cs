using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02001BF9 RID: 7161
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchDebugLogUtil
{
	// Token: 0x0600D074 RID: 53364 RVA: 0x00375D6C File Offset: 0x00373F6C
	public static void LogDayStart()
	{
	}

	// Token: 0x0600D075 RID: 53365 RVA: 0x00375D70 File Offset: 0x00373F70
	public static void LogBuffActionInfo(FloroRanchEntityBase casterEntity, FloroRanchEntityBase targetEntity, FRUnitOperateBuffAction buff)
	{
	}

	// Token: 0x0600D076 RID: 53366 RVA: 0x00375D7D File Offset: 0x00373F7D
	public static void LogEatActionInfo(FloroRanchEntityBase casterEntity, FloroRanchEntityBase targetEntity)
	{
	}

	// Token: 0x0600D077 RID: 53367 RVA: 0x00375D80 File Offset: 0x00373F80
	public static void LogEvolveActionInfo(FloroRanchEntityBase targetEntity, FloroRanchCardDataComponent cardDataComponent)
	{
	}

	// Token: 0x0600D078 RID: 53368 RVA: 0x00375D90 File Offset: 0x00373F90
	public static void LogTagActionInfo(FloroRanchEntityBase casterEntity, FRDebugActionInfo tagAction)
	{
	}

	// Token: 0x0600D079 RID: 53369 RVA: 0x00375DA0 File Offset: 0x00373FA0
	public static void LogFusionStartActionInfo(FloroRanchEntityBase casterEntity, FRMixAction fusionActionData)
	{
	}

	// Token: 0x0600D07A RID: 53370 RVA: 0x00375DB0 File Offset: 0x00373FB0
	public static void LogFusionEndActionInfo(FRMixAction fusionActionData)
	{
	}

	// Token: 0x0600D07B RID: 53371 RVA: 0x00375DC0 File Offset: 0x00373FC0
	public static void LogResourceChangeActionInfo(FloroRanchEntityBase casterEntity, FRUnitResourcesChangeAction changeData)
	{
	}

	// Token: 0x0600D07C RID: 53372 RVA: 0x00375DD0 File Offset: 0x00373FD0
	public static void LogWageSettleActionInfo(FRUnitResourcesChangeAction changeData)
	{
	}

	// Token: 0x0600D07D RID: 53373 RVA: 0x00375DDD File Offset: 0x00373FDD
	private static string GetCurrencyDebugName(FRUnitResourcesChangeType type)
	{
		return "";
	}

	// Token: 0x0600D07E RID: 53374 RVA: 0x00375DE4 File Offset: 0x00373FE4
	public static void LogToyLevelUpActionInfo(FloroRanchEntityBase entity, int lastLevel, int newLevel)
	{
	}

	// Token: 0x0600D07F RID: 53375 RVA: 0x00375DF4 File Offset: 0x00373FF4
	public static void LogStageTributeChangeActionInfo(int newTarget)
	{
	}

	// Token: 0x0600D080 RID: 53376 RVA: 0x00375E04 File Offset: 0x00374004
	public static void LogSelfDefineValueActionInfo(FloroRanchEntityBase entity, int n, int m, int p)
	{
	}

	// Token: 0x0600D081 RID: 53377 RVA: 0x00375E11 File Offset: 0x00374011
	public static void LogSacrificeActionInfo(FloroRanchEntityBase casterEntity)
	{
	}

	// Token: 0x0600D082 RID: 53378 RVA: 0x00375E14 File Offset: 0x00374014
	public static void LogEntityChangeActionInfo(FloroRanchEntityBase casterEntity, FRUnitOperate opType, FloroRanchPlayUnit changeData)
	{
	}

	// Token: 0x0600D083 RID: 53379 RVA: 0x00375E21 File Offset: 0x00374021
	private static string GetEntityChangeTypeDebugName(FRUnitOperate opType)
	{
		return "";
	}

	// Token: 0x0600D084 RID: 53380 RVA: 0x00375E28 File Offset: 0x00374028
	private static void Log(string info)
	{
	}
}
