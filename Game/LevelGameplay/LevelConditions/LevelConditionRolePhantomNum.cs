using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DE2 RID: 28130
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelConditionRolePhantomNum : LevelConditionBase
	{
		// Token: 0x0604461C RID: 280092 RVA: 0x011C3FDC File Offset: 0x011C21DC
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			if (inConditionInfo.LimitParamsLength == 0)
			{
				return false;
			}
			int num;
			if (!int.TryParse(inConditionInfo.GetLimitParams("RoleId"), out num))
			{
				return false;
			}
			int targetValue;
			if (!int.TryParse(inConditionInfo.GetLimitParams("Value"), out targetValue))
			{
				return false;
			}
			string limitParams = inConditionInfo.GetLimitParams("Op");
			if (limitParams == null)
			{
				return false;
			}
			if (num > 0)
			{
				return this.CheckRolePhantomNum(num, targetValue, limitParams);
			}
			foreach (RoleInstance roleInstance in ModelBase<RoleModel>.Instance.GetRoleList())
			{
				if (this.CheckRolePhantomNum(roleInstance.GetRoleId(), targetValue, limitParams))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0604461D RID: 280093 RVA: 0x011C4079 File Offset: 0x011C2279
		private bool CheckRolePhantomNum(int roleId, int targetValue, string op)
		{
			return ModelBase<RoleModel>.Instance.GetRoleInstanceById(roleId) != null && base.CheckCompareValue(op, (double)ModelBase<PhantomBattleModel>.Instance.GetBattleDataById(roleId).GetEquippedNum(), (double)targetValue);
		}
	}
}
