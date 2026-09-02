using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using AkiClient.Game.Aki.Render.RuntimeBP.Battle;
using CSharpScript.Game.Render;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BF6 RID: 27638
	public class LevelEventSetWuYinQuState : LevelEventBase
	{
		// Token: 0x0604410D RID: 278797 RVA: 0x011AB954 File Offset: 0x011A9B54
		public LevelEventSetWuYinQuState(int id) : base(id)
		{
		}

		// Token: 0x0604410E RID: 278798 RVA: 0x011AB960 File Offset: 0x011A9B60
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			SetWuYinQuState setWuYinQuState = inParams as SetWuYinQuState;
			if (setWuYinQuState == null)
			{
				return;
			}
			ControllerBase<RenderModuleController>.Instance.SetBattleState(setWuYinQuState.WuYinQuName, (AkiClient.Game.Aki.Render.RuntimeBP.Battle.EWuYinQuState)setWuYinQuState.State, false);
		}
	}
}
