using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006B88 RID: 27528
	public class LevelEventDrinksRollRoleRequirement : LevelEventBase
	{
		// Token: 0x06043F32 RID: 278322 RVA: 0x0119A0CD File Offset: 0x011982CD
		public LevelEventDrinksRollRoleRequirement(int id) : base(id)
		{
		}

		// Token: 0x06043F33 RID: 278323 RVA: 0x0119A0D8 File Offset: 0x011982D8
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			if (inParams == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.Event, ELogAuthor.CWZ, "LevelEventDrinksRollRoleRequirement 参数配置错误", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			DrinksRollRoleRequirement drinksRollRoleRequirement = inParams as DrinksRollRoleRequirement;
			ControllerBase<DrinksController>.Instance.SelectRoleAndPlaySeq(drinksRollRoleRequirement.RoleId, EDrinksGameplayOpenWay.FromEntityNPC, drinksRollRoleRequirement.RequirementId);
		}
	}
}
