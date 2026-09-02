using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BAF RID: 27567
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelEventInterludeActions : LevelEventBase
	{
		// Token: 0x06043FE6 RID: 278502 RVA: 0x0119E69E File Offset: 0x0119C89E
		public LevelEventInterludeActions(int id) : base(id)
		{
		}

		// Token: 0x06043FE7 RID: 278503 RVA: 0x0119E6A7 File Offset: 0x0119C8A7
		protected override void ExecuteInGm(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			base.FinishExecute(true, false, true);
		}

		// Token: 0x06043FE8 RID: 278504 RVA: 0x0119E6B2 File Offset: 0x0119C8B2
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			if (inParams == null)
			{
				base.FinishExecute(true, false, true);
				return;
			}
			this.Param = (inParams as InterludeActions);
			this.Context = context;
			if (this.Param.IsFadeIn)
			{
				this.OnStateIn();
				return;
			}
			this.OnStateStay();
		}

		// Token: 0x06043FE9 RID: 278505 RVA: 0x0119E6EE File Offset: 0x0119C8EE
		private void OnStateIn()
		{
		}

		// Token: 0x06043FEA RID: 278506 RVA: 0x0119E6F0 File Offset: 0x0119C8F0
		private void OnStateStay()
		{
			InterludeActions param = this.Param;
			if (((param != null) ? param.InterludeActionList : null) != null && this.Param.InterludeActionList.Count > 0)
			{
				ControllerBase<LevelGeneralController>.Instance.ExecuteActionsNew(this.Param.InterludeActionList, GeneralContext.Copy(this.Context), new Action<ELevelEventState>(this.OnActionsDone));
				return;
			}
			this.OnStateOut();
		}

		// Token: 0x06043FEB RID: 278507 RVA: 0x0119E757 File Offset: 0x0119C957
		private void OnActionsDone(ELevelEventState _)
		{
			this.OnStateOut();
		}

		// Token: 0x06043FEC RID: 278508 RVA: 0x0119E75F File Offset: 0x0119C95F
		private void OnStateOut()
		{
			InterludeActions param = this.Param;
			if (param == null || !param.IsFadeOut)
			{
				base.FinishExecute(true, false, true);
				return;
			}
		}

		// Token: 0x04026029 RID: 155689
		[Nullable(2)]
		private InterludeActions Param;

		// Token: 0x0402602A RID: 155690
		[Nullable(2)]
		private GeneralContext Context;
	}
}
