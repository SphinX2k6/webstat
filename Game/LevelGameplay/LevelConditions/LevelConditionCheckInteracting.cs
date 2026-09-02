using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Interaction;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D1A RID: 27930
	public class LevelConditionCheckInteracting : LevelConditionBase
	{
		// Token: 0x06044469 RID: 279657 RVA: 0x011BC850 File Offset: 0x011BAA50
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			bool flag = (ModelBase<InteractionModel>.Instance.CurrentInteractEntityId ?? 0) == 0;
			return !flag || ModelBase<InteractionModel>.Instance.InteractingEntity != null || (TsInteractionUtils.IsInteractHintViewOpened() && ModelBase<InputDistributeModel>.Instance.IsActionInPress("通用交互"));
		}
	}
}
