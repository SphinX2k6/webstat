using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FBC RID: 24508
	[NullableContext(2)]
	[Nullable(0)]
	public class BattleFormationChildView : BattleEntityChildView
	{
		// Token: 0x0603D9FA RID: 252410 RVA: 0x00FB2D18 File Offset: 0x00FB0F18
		protected override void OnActivate()
		{
			SceneTeamItem teamItem = ModelBase<SceneTeamModel>.Instance.GetTeamItem((long)base.GetEntityId().Value, new GetTeamItemOptions
			{
				ParamType = ETeamParamType.EntityId
			});
			this.FormationInstance = teamItem;
		}

		// Token: 0x0603D9FB RID: 252411 RVA: 0x00FB2D52 File Offset: 0x00FB0F52
		protected override void OnDeactivate()
		{
			this.FormationInstance = null;
		}

		// Token: 0x0603D9FC RID: 252412 RVA: 0x00FB2D5B File Offset: 0x00FB0F5B
		public SceneTeamItem GetFormationInstance()
		{
			return this.FormationInstance;
		}

		// Token: 0x0603D9FD RID: 252413 RVA: 0x00FB2D63 File Offset: 0x00FB0F63
		public override bool IsValid()
		{
			return base.IsValid() && this.FormationInstance != null;
		}

		// Token: 0x0402296C RID: 141676
		protected SceneTeamItem FormationInstance;
	}
}
