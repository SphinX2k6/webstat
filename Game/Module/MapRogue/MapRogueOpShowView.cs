using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x0200591B RID: 22811
	[NullableContext(1)]
	[Nullable(0)]
	public class MapRogueOpShowView : MapRogueOp
	{
		// Token: 0x1700941D RID: 37917
		// (get) Token: 0x06039E6F RID: 237167 RVA: 0x00EA8CEE File Offset: 0x00EA6EEE
		// (set) Token: 0x06039E70 RID: 237168 RVA: 0x00EA8CF6 File Offset: 0x00EA6EF6
		public override int StepSize { get; set; } = 1;

		// Token: 0x06039E71 RID: 237169 RVA: 0x00EA8D00 File Offset: 0x00EA6F00
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(32, 3);
			defaultInterpolatedStringHandler.AppendLiteral("[ShowView] IncId:");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.IncId);
			defaultInterpolatedStringHandler.AppendLiteral(" Step:");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.CurrentStep);
			defaultInterpolatedStringHandler.AppendLiteral(" SubType:");
			ShowViewOp showViewOp = this.Data.ShowViewOp;
			defaultInterpolatedStringHandler.AppendFormatted<ShowViewType?>((showViewOp != null) ? new ShowViewType?(showViewOp.ShowViewType) : null);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x06039E72 RID: 237170 RVA: 0x00EA8D87 File Offset: 0x00EA6F87
		protected override void OnUpdate(MapRogueGameInfo gameInfo)
		{
			if (this.Data.ShowViewOp.ShowViewType == ShowViewType.InstResult)
			{
				this.ExecuteInMapView = false;
			}
		}

		// Token: 0x06039E73 RID: 237171 RVA: 0x00EA8DA4 File Offset: 0x00EA6FA4
		protected override void OnStartExecute(MapRogueGameInfo gameInfo)
		{
			ShowViewOp showViewOp = this.Data.ShowViewOp;
			if (showViewOp == null)
			{
				return;
			}
			switch (showViewOp.ShowViewType)
			{
			case ShowViewType.GridTake:
				Singleton<UiManager>.Instance.OpenView(EUiViewName.MapRogueGridTakeView, this.IncId, null);
				return;
			case ShowViewType.RogueResAddRole:
			case ShowViewType.PhantomEntryUnlock:
			case ShowViewType.RoleBuffUnlock:
				break;
			case ShowViewType.InstResult:
				Singleton<UiManager>.Instance.OpenView(EUiViewName.RogueBattleSettleView, this.Data.ShowViewOp.InstResultView, null);
				return;
			case ShowViewType.RoleBond:
				Singleton<UiManager>.Instance.OpenView(EUiViewName.RogueBattleRoleStarUpView, this.IncId, null);
				return;
			case ShowViewType.AddToken:
				Singleton<UiManager>.Instance.OpenView(EUiViewName.RogueBattleTokenSelectResultView, this.IncId, null);
				break;
			default:
				return;
			}
		}

		// Token: 0x06039E74 RID: 237172 RVA: 0x00EA8E61 File Offset: 0x00EA7061
		protected override void OnExecute(MapRogueGameInfo gameInfo)
		{
			if (this.AutoFinish)
			{
				base.Execute(gameInfo, null);
			}
		}

		// Token: 0x06039E75 RID: 237173 RVA: 0x00EA8E73 File Offset: 0x00EA7073
		protected override void OnFinish(MapRogueGameInfo gameInfo)
		{
		}

		// Token: 0x06039E76 RID: 237174 RVA: 0x00EA8E78 File Offset: 0x00EA7078
		protected override bool OnBeforeStartExecuteCheck(MapRogueGameInfo gameInfo)
		{
			ShowViewOp showViewOp = this.Data.ShowViewOp;
			return showViewOp != null && (showViewOp.ShowViewType != ShowViewType.RoleBond || !Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.RogueBattleRoleBuffSelectView));
		}

		// Token: 0x04020CDF RID: 134367
		public bool AutoFinish = true;
	}
}
