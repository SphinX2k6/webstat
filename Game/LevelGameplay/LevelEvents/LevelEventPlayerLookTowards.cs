using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BC3 RID: 27587
	public class LevelEventPlayerLookTowards : LevelEventBase
	{
		// Token: 0x06044054 RID: 278612 RVA: 0x011A33B5 File Offset: 0x011A15B5
		public LevelEventPlayerLookTowards(int id) : base(id)
		{
		}

		// Token: 0x06044055 RID: 278613 RVA: 0x011A33C0 File Offset: 0x011A15C0
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			PlayerLookTowards playerLookTowards = inParams as PlayerLookTowards;
			if (playerLookTowards.Target.Type == ECharacterLookAt.Position)
			{
				Vector vector = Vector.Create();
				vector.FromConfigVector((playerLookTowards.Target as ICharacterLookAtPositionData).Pos);
				ModelBase<PerformModel>.Instance.PlayerSightTarget = vector;
			}
			else if (playerLookTowards.Target.Type == ECharacterLookAt.Unlock)
			{
				ModelBase<PerformModel>.Instance.PlayerSightTarget = null;
			}
			else
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.FZX, "PlayerLookTowards配置类型不支持", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			base.FinishExecute(true, false, true);
		}
	}
}
