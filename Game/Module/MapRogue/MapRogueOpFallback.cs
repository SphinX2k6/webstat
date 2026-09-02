using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x02005912 RID: 22802
	[NullableContext(1)]
	[Nullable(0)]
	public class MapRogueOpFallback : MapRogueOp
	{
		// Token: 0x1700940E RID: 37902
		// (get) Token: 0x06039E14 RID: 237076 RVA: 0x00EA77EB File Offset: 0x00EA59EB
		// (set) Token: 0x06039E15 RID: 237077 RVA: 0x00EA77F3 File Offset: 0x00EA59F3
		public override int StepSize { get; set; } = 1;

		// Token: 0x06039E16 RID: 237078 RVA: 0x00EA77FC File Offset: 0x00EA59FC
		public MapRogueOpFallback()
		{
			this.ExecuteInMapView = false;
		}

		// Token: 0x06039E17 RID: 237079 RVA: 0x00EA781C File Offset: 0x00EA5A1C
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(23, 2);
			defaultInterpolatedStringHandler.AppendLiteral("[Fallback] IncId:");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.IncId);
			defaultInterpolatedStringHandler.AppendLiteral(" Step:");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.CurrentStep);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x06039E18 RID: 237080 RVA: 0x00EA786C File Offset: 0x00EA5A6C
		protected override void OnUpdate(MapRogueGameInfo gameInfo)
		{
		}

		// Token: 0x06039E19 RID: 237081 RVA: 0x00EA786E File Offset: 0x00EA5A6E
		protected override void OnStartExecute(MapRogueGameInfo gameInfo)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RogueBattleFallbackView, this.IncId, null);
		}

		// Token: 0x06039E1A RID: 237082 RVA: 0x00EA788B File Offset: 0x00EA5A8B
		protected override void OnExecute(MapRogueGameInfo gameInfo)
		{
			if (this.AutoFinish)
			{
				base.Execute(gameInfo, null);
			}
		}

		// Token: 0x06039E1B RID: 237083 RVA: 0x00EA789D File Offset: 0x00EA5A9D
		protected override void OnFinish(MapRogueGameInfo gameInfo)
		{
		}

		// Token: 0x06039E1C RID: 237084 RVA: 0x00EA789F File Offset: 0x00EA5A9F
		protected override void OnDelete(MapRogueGameInfo gameInfo)
		{
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.RogueBattleFallbackView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.RogueBattleFallbackView, null);
			}
		}

		// Token: 0x04020CB5 RID: 134325
		public bool AutoFinish = true;
	}
}
