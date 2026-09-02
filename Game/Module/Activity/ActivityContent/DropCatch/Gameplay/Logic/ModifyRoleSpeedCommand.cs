using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Logic
{
	// Token: 0x02006928 RID: 26920
	public class ModifyRoleSpeedCommand : IDropCatchCommand
	{
		// Token: 0x06042D47 RID: 273735 RVA: 0x011270CC File Offset: 0x011252CC
		[NullableContext(1)]
		public void Execute(ICommandContext context, [Nullable(2)] object @params)
		{
			IModifyRoleSpeedCommandParams modifyRoleSpeedCommandParams = (IModifyRoleSpeedCommandParams)@params;
			IRoleInstance role = context.GetLogicContext().GetGameplayRoleMgr().GetRole();
			DropCatchGameplayAttribute dropCatchGameplayAttribute = (role != null) ? role.GetSpeedAttr() : null;
			if (dropCatchGameplayAttribute == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.DropCatch, ELogAuthor.CB, "角色速度属性不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			DropCatchGameplayModifierMgr gameplayModifierMgr = context.GetLogicContext().GetGameplayModifierMgr();
			int modifierId = gameplayModifierMgr.AddModifierToAttr(dropCatchGameplayAttribute, modifyRoleSpeedCommandParams.Type, modifyRoleSpeedCommandParams.Value, new float?(modifyRoleSpeedCommandParams.Duration));
			EDropCatchCommandSource? source = modifyRoleSpeedCommandParams.Source;
			EDropCatchCommandSource edropCatchCommandSource = EDropCatchCommandSource.Skill;
			if (source.GetValueOrDefault() == edropCatchCommandSource & source != null)
			{
				gameplayModifierMgr.AddSkillModifier(dropCatchGameplayAttribute, modifierId);
			}
		}
	}
}
