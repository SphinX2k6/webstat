using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x02005916 RID: 22806
	[NullableContext(1)]
	[Nullable(0)]
	public class MapRogueOpGridFocus : MapRogueOp
	{
		// Token: 0x17009418 RID: 37912
		// (get) Token: 0x06039E3B RID: 237115 RVA: 0x00EA7FE7 File Offset: 0x00EA61E7
		// (set) Token: 0x06039E3C RID: 237116 RVA: 0x00EA7FEF File Offset: 0x00EA61EF
		public override int StepSize { get; set; } = 1;

		// Token: 0x06039E3D RID: 237117 RVA: 0x00EA7FF8 File Offset: 0x00EA61F8
		public MapRogueOpGridFocus()
		{
			this.ExecuteInMapView = true;
			this.ExecuteAfterMapViewShow = true;
		}

		// Token: 0x06039E3E RID: 237118 RVA: 0x00EA8044 File Offset: 0x00EA6244
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(26, 2);
			defaultInterpolatedStringHandler.AppendLiteral("[GridFocus] IncId:");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.IncId);
			defaultInterpolatedStringHandler.AppendLiteral(" GridId:");
			LightBlockByLocationOp lightBlockByLocationOp = this.Data.LightBlockByLocationOp;
			defaultInterpolatedStringHandler.AppendFormatted<int?>((lightBlockByLocationOp != null) ? new int?(lightBlockByLocationOp.GridIndex) : null);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x06039E3F RID: 237119 RVA: 0x00EA80B2 File Offset: 0x00EA62B2
		protected override void OnStartExecute(MapRogueGameInfo gameInfo)
		{
			base.Execute(gameInfo, null);
		}

		// Token: 0x06039E40 RID: 237120 RVA: 0x00EA80BC File Offset: 0x00EA62BC
		protected override void OnExecute(MapRogueGameInfo gameInfo)
		{
			LightBlockByLocationOp lightBlockByLocationOp = this.Data.LightBlockByLocationOp;
			if (lightBlockByLocationOp == null)
			{
				return;
			}
			gameInfo.SetInteractAvailable(EMapForbiddenTag.FocusLock, false);
			this.GridFocusFlow(gameInfo, lightBlockByLocationOp.GridIndex, lightBlockByLocationOp.FocusTime, lightBlockByLocationOp.Grids, lightBlockByLocationOp.BackToPlayer).ContinueWith(delegate()
			{
				gameInfo.SetInteractAvailable(EMapForbiddenTag.FocusLock, true);
				this.Execute(gameInfo, null);
			});
		}

		// Token: 0x06039E41 RID: 237121 RVA: 0x00EA8130 File Offset: 0x00EA6330
		private UniTask GridFocusFlow(MapRogueGameInfo gameInfo, int gridIndex, int focusTime, IList<int> unlockGrids, bool backToPlayer)
		{
			MapRogueOpGridFocus.<GridFocusFlow>d__9 <GridFocusFlow>d__;
			<GridFocusFlow>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<GridFocusFlow>d__.<>4__this = this;
			<GridFocusFlow>d__.gameInfo = gameInfo;
			<GridFocusFlow>d__.gridIndex = gridIndex;
			<GridFocusFlow>d__.focusTime = focusTime;
			<GridFocusFlow>d__.unlockGrids = unlockGrids;
			<GridFocusFlow>d__.backToPlayer = backToPlayer;
			<GridFocusFlow>d__.<>1__state = -1;
			<GridFocusFlow>d__.<>t__builder.Start<MapRogueOpGridFocus.<GridFocusFlow>d__9>(ref <GridFocusFlow>d__);
			return <GridFocusFlow>d__.<>t__builder.Task;
		}

		// Token: 0x06039E42 RID: 237122 RVA: 0x00EA819D File Offset: 0x00EA639D
		protected override void OnFinish(MapRogueGameInfo gameInfo)
		{
		}

		// Token: 0x04020CC0 RID: 134336
		private readonly float FocusTweenTime = (float)ConfigBase<MapRogueConfig>.Instance.GetGlobalParamConfig().Value.FocusTime;
	}
}
