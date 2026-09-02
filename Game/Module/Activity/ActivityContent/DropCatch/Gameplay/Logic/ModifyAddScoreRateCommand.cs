using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Logic
{
	// Token: 0x0200692A RID: 26922
	public class ModifyAddScoreRateCommand : IDropCatchCommand
	{
		// Token: 0x06042D4B RID: 273739 RVA: 0x0112730C File Offset: 0x0112550C
		[NullableContext(1)]
		public void Execute(ICommandContext context, [Nullable(2)] object @params)
		{
			IModifyAddScoreRateCommandParams modifyAddScoreRateCommandParams = (IModifyAddScoreRateCommandParams)@params;
			DropCatchGameplayAttribute addScoreRateAttr = context.GetLogicContext().GetAddScoreRateAttr();
			DropCatchGameplayModifierMgr gameplayModifierMgr = context.GetLogicContext().GetGameplayModifierMgr();
			int modifierId = gameplayModifierMgr.AddModifierToAttr(addScoreRateAttr, modifyAddScoreRateCommandParams.Type, modifyAddScoreRateCommandParams.Value, modifyAddScoreRateCommandParams.Duration);
			EDropCatchCommandSource? source = modifyAddScoreRateCommandParams.Source;
			EDropCatchCommandSource edropCatchCommandSource = EDropCatchCommandSource.Skill;
			if (source.GetValueOrDefault() == edropCatchCommandSource & source != null)
			{
				gameplayModifierMgr.AddSkillModifier(addScoreRateAttr, modifierId);
			}
		}
	}
}
