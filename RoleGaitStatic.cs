using System;
using Aki.Config;

// Token: 0x020031E0 RID: 12768
public class RoleGaitStatic : IStaticVariableResetter
{
	// Token: 0x0601A78B RID: 108427 RVA: 0x007D1D1A File Offset: 0x007CFF1A
	static RoleGaitStatic()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(RoleGaitStatic.CreateStaticDefaultValue), new Action(RoleGaitStatic.ResetStaticDefaultValue));
	}

	// Token: 0x0601A78C RID: 108428 RVA: 0x007D1D3C File Offset: 0x007CFF3C
	public static void Init()
	{
		if (!RoleGaitStatic.IsInit)
		{
			RoleGaitStatic.MovementStatusGapValue = ConfigCommonParamById.GetFloatConfig("Move_Status_GapValue_GamePad").Value;
			RoleGaitStatic.MovementStatusGapValueSquare = RoleGaitStatic.MovementStatusGapValue * RoleGaitStatic.MovementStatusGapValue;
			RoleGaitStatic.IsInit = true;
		}
	}

	// Token: 0x0601A78D RID: 108429 RVA: 0x007D1D7D File Offset: 0x007CFF7D
	public static void SetWalkOrRunRateForRocker(float newValue)
	{
		RoleGaitStatic._walkOrRunRate = Math.Min(newValue, 0.99f);
	}

	// Token: 0x0601A78E RID: 108430 RVA: 0x007D1D8F File Offset: 0x007CFF8F
	public static float GetWalkOrRunRate()
	{
		return RoleGaitStatic._walkOrRunRate;
	}

	// Token: 0x0601A78F RID: 108431 RVA: 0x007D1D96 File Offset: 0x007CFF96
	public static void CreateStaticDefaultValue()
	{
		RoleGaitStatic.MovementStatusGapValue = 0f;
		RoleGaitStatic.MovementStatusGapValueSquare = 0f;
		RoleGaitStatic.IsInit = false;
		RoleGaitStatic._walkOrRunRate = 0.3f;
	}

	// Token: 0x0601A790 RID: 108432 RVA: 0x007D1DBC File Offset: 0x007CFFBC
	public static void ResetStaticDefaultValue()
	{
		RoleGaitStatic.MovementStatusGapValue = 0f;
		RoleGaitStatic.MovementStatusGapValueSquare = 0f;
		RoleGaitStatic.IsInit = false;
		RoleGaitStatic._walkOrRunRate = 0.3f;
	}

	// Token: 0x0400D5F6 RID: 54774
	private const float WALK_TO_RUN_RATE = 0.3f;

	// Token: 0x0400D5F7 RID: 54775
	public static float MovementStatusGapValue;

	// Token: 0x0400D5F8 RID: 54776
	public static float MovementStatusGapValueSquare;

	// Token: 0x0400D5F9 RID: 54777
	public static bool IsInit;

	// Token: 0x0400D5FA RID: 54778
	private static float _walkOrRunRate;
}
