using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Input;
using CSharpScript.Game.LevelGamePlay.Guarantee;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BEC RID: 27628
	public class LevelEventSetPlayerMoveControl : LevelEventBase
	{
		// Token: 0x060440F1 RID: 278769 RVA: 0x011AAD84 File Offset: 0x011A8F84
		public LevelEventSetPlayerMoveControl(int id) : base(id)
		{
		}

		// Token: 0x060440F2 RID: 278770 RVA: 0x011AAD90 File Offset: 0x011A8F90
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			if (inParams == null)
			{
				return;
			}
			SetPlayerMoveControl setPlayerMoveControl = inParams as SetPlayerMoveControl;
			this.AllEnabled = (setPlayerMoveControl.Forward == 1 && setPlayerMoveControl.Back == 1 && setPlayerMoveControl.Left == 1 && setPlayerMoveControl.Right == 1);
			ControllerBase<InputController>.Instance.SetMoveControlEnabled(setPlayerMoveControl.Forward == 1, setPlayerMoveControl.Back == 1, setPlayerMoveControl.Left == 1, setPlayerMoveControl.Right == 1);
		}

		// Token: 0x060440F3 RID: 278771 RVA: 0x011AAE04 File Offset: 0x011A9004
		protected override void OnUpdateGuarantee()
		{
			GuaranteeActionInfo p = new GuaranteeActionInfo
			{
				Name = EGuaranteeAction.EnablePlayerMoveControl
			};
			if (this.AllEnabled)
			{
				Singleton<EventSystem>.Instance.Emit<string, GeneralContext, GuaranteeActionInfo, bool?>(EEventName.RemGuaranteeAction, this.Type, this.BaseContext, p, null);
				return;
			}
			Singleton<EventSystem>.Instance.Emit<string, GeneralContext, GuaranteeActionInfo, bool?>(EEventName.AddGuaranteeAction, this.Type, this.BaseContext, p, null);
		}

		// Token: 0x04026077 RID: 155767
		private bool AllEnabled;
	}
}
