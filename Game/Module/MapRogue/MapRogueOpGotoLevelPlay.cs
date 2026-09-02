using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x02005913 RID: 22803
	[NullableContext(1)]
	[Nullable(0)]
	public class MapRogueOpGotoLevelPlay : MapRogueOp
	{
		// Token: 0x1700940F RID: 37903
		// (get) Token: 0x06039E1D RID: 237085 RVA: 0x00EA78C2 File Offset: 0x00EA5AC2
		// (set) Token: 0x06039E1E RID: 237086 RVA: 0x00EA78CA File Offset: 0x00EA5ACA
		public override int StepSize { get; set; } = 1;

		// Token: 0x06039E20 RID: 237088 RVA: 0x00EA78EC File Offset: 0x00EA5AEC
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(24, 2);
			defaultInterpolatedStringHandler.AppendLiteral("[LevelPlay] IncId:");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.IncId);
			defaultInterpolatedStringHandler.AppendLiteral(" Step:");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.CurrentStep);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x06039E21 RID: 237089 RVA: 0x00EA793C File Offset: 0x00EA5B3C
		protected override void OnStartExecute(MapRogueGameInfo gameInfo)
		{
			if (this.Data.RogueGotoLevelPlayOp.CanSkipBattle && gameInfo.IsSkipBattle)
			{
				this.OpExecuteClientId = 2;
				base.ExecuteOp(null);
				return;
			}
			if (this.Data.RogueGotoLevelPlayOp.IsFormation)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.RogueBattleTeamEditView, this.IncId, null);
				return;
			}
			base.Execute(gameInfo, null);
		}

		// Token: 0x06039E22 RID: 237090 RVA: 0x00EA79A8 File Offset: 0x00EA5BA8
		protected override void OnExecute(MapRogueGameInfo gameInfo)
		{
			this.OnRogueSubLevelNotify(this.Data.RogueGotoLevelPlayOp.RogueResSubLevelData, gameInfo);
		}

		// Token: 0x06039E23 RID: 237091 RVA: 0x00EA79C1 File Offset: 0x00EA5BC1
		protected override void OnFinish(MapRogueGameInfo gameInfo)
		{
		}

		// Token: 0x06039E24 RID: 237092 RVA: 0x00EA79C4 File Offset: 0x00EA5BC4
		private void OnRogueSubLevelNotify(RogueResSubLevelData notify, MapRogueGameInfo gameInfo)
		{
			MapRogueOpGotoLevelPlay.<>c__DisplayClass10_0 CS$<>8__locals1 = new MapRogueOpGotoLevelPlay.<>c__DisplayClass10_0();
			CS$<>8__locals1.notify = notify;
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.gameInfo = gameInfo;
			AsyncTask task = new AsyncTask("RogueBattleSubLevelNotify", delegate()
			{
				MapRogueOpGotoLevelPlay.<>c__DisplayClass10_0.<<OnRogueSubLevelNotify>b__0>d <<OnRogueSubLevelNotify>b__0>d;
				<<OnRogueSubLevelNotify>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
				<<OnRogueSubLevelNotify>b__0>d.<>4__this = CS$<>8__locals1;
				<<OnRogueSubLevelNotify>b__0>d.<>1__state = -1;
				<<OnRogueSubLevelNotify>b__0>d.<>t__builder.Start<MapRogueOpGotoLevelPlay.<>c__DisplayClass10_0.<<OnRogueSubLevelNotify>b__0>d>(ref <<OnRogueSubLevelNotify>b__0>d);
				return <<OnRogueSubLevelNotify>b__0>d.<>t__builder.Task;
			}, null, null, null);
			Singleton<TaskSystem>.Instance.AddTask(task);
			Singleton<TaskSystem>.Instance.Run();
		}

		// Token: 0x04020CB7 RID: 134327
		public int SelectIndex = -1;
	}
}
