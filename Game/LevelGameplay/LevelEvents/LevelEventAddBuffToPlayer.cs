using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006B64 RID: 27492
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelEventAddBuffToPlayer : LevelEventAddBuffClientPrePerformance
	{
		// Token: 0x06043E7E RID: 278142 RVA: 0x0118FD19 File Offset: 0x0118DF19
		public LevelEventAddBuffToPlayer(int id) : base(id)
		{
		}

		// Token: 0x06043E7F RID: 278143 RVA: 0x0118FD24 File Offset: 0x0118DF24
		[return: Nullable(2)]
		protected override EntityHandle GetTargetEntity(TriggerContext context)
		{
			if (ModelBase<GameModeModel>.Instance.IsMulti && !ModelBase<CreatureModel>.Instance.IsMyWorld())
			{
				return null;
			}
			ETeamGroupType? currentGroupType = ModelBase<SceneTeamModel>.Instance.CurrentGroupType;
			if (currentGroupType != null)
			{
				switch (currentGroupType.GetValueOrDefault())
				{
				case ETeamGroupType.Battle:
					return ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
				case ETeamGroupType.Phantom:
					return ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
				case ETeamGroupType.Plot:
				case ETeamGroupType.Performance:
				{
					global::Log instance = Singleton<global::Log>.Instance;
					ELogModule module = ELogModule.LevelEvent;
					ELogAuthor author = ELogAuthor.XDW;
					string message = "[" + base.GetDebugName() + "] 剧情、玩法演出编队类型角色触发了实体的TriggerComponent，不合理";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("context", context);
					instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					break;
				}
				}
			}
			return null;
		}

		// Token: 0x06043E80 RID: 278144 RVA: 0x0118FDCF File Offset: 0x0118DFCF
		protected override List<long> GetBuffIds(ActionParams inParams)
		{
			return (inParams as AddBuffToPlayer).BuffIds;
		}
	}
}
