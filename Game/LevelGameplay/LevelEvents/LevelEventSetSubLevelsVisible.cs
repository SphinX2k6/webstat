using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.World.Controller;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BF1 RID: 27633
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelEventSetSubLevelsVisible : LevelEventBase
	{
		// Token: 0x060440FD RID: 278781 RVA: 0x011AB09E File Offset: 0x011A929E
		public LevelEventSetSubLevelsVisible(int id) : base(id)
		{
		}

		// Token: 0x060440FE RID: 278782 RVA: 0x011AB0A8 File Offset: 0x011A92A8
		protected override void ExecuteInGm(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			this.ExecuteNew(inParams, context, null);
		}

		// Token: 0x060440FF RID: 278783 RVA: 0x011AB0C8 File Offset: 0x011A92C8
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			if (inParams == null)
			{
				return;
			}
			ClientPreEnableSubLevels clientPreEnableSubLevels = inParams as ClientPreEnableSubLevels;
			if (clientPreEnableSubLevels == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.YSQ, "执行行为.LevelEventSetSubLevelsVisible 参数不正确", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			ControllerBase<SubLevelController>.Instance.SetSubLevelVisible(new SetSubLevelVisibleParams
			{
				ActionParams = clientPreEnableSubLevels,
				Context = context,
				ActionId = base.Id,
				GroupId = this.GroupId,
				FinishCallback = delegate(bool _)
				{
					base.FinishExecute(true, false, true);
				}
			});
		}
	}
}
