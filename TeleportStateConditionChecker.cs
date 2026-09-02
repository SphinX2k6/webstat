using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map;

// Token: 0x02002A7B RID: 10875
public class TeleportStateConditionChecker : ISkipConditionChecker
{
	// Token: 0x06015C6C RID: 89196 RVA: 0x0060A8E7 File Offset: 0x00608AE7
	[NullableContext(1)]
	public ISkipCondition<ESkipConditionType> Parse(int[] @params)
	{
		return new TeleportStateConditionImpl
		{
			ConditionType = ESkipConditionType.TeleportState,
			MarkId = @params[0],
			CheckTeleportState = (ETeleportState)@params[1]
		};
	}

	// Token: 0x06015C6D RID: 89197 RVA: 0x0060A908 File Offset: 0x00608B08
	[NullableContext(1)]
	public bool Check(int[] @params)
	{
		TeleportStateConditionImpl teleportStateConditionImpl = this.Parse(@params) as TeleportStateConditionImpl;
		if (teleportStateConditionImpl == null)
		{
			return false;
		}
		int markId = teleportStateConditionImpl.MarkId;
		bool checkTeleportState = teleportStateConditionImpl.CheckTeleportState != ETeleportState.Inactive;
		bool flag = ModelBase<MapModel>.Instance.CheckTeleportUnlocked(markId);
		if (!checkTeleportState)
		{
			return !flag;
		}
		return flag;
	}
}
