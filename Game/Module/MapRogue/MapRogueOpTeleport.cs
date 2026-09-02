using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x0200591C RID: 22812
	[NullableContext(1)]
	[Nullable(0)]
	public class MapRogueOpTeleport : MapRogueOp
	{
		// Token: 0x1700941E RID: 37918
		// (get) Token: 0x06039E78 RID: 237176 RVA: 0x00EA8EC9 File Offset: 0x00EA70C9
		// (set) Token: 0x06039E79 RID: 237177 RVA: 0x00EA8ED1 File Offset: 0x00EA70D1
		public override int StepSize { get; set; } = 1;

		// Token: 0x06039E7A RID: 237178 RVA: 0x00EA8EDA File Offset: 0x00EA70DA
		public MapRogueOpTeleport()
		{
			this.ExecuteInMapView = true;
			this.ExecuteAfterMapViewShow = true;
		}

		// Token: 0x06039E7B RID: 237179 RVA: 0x00EA8EF8 File Offset: 0x00EA70F8
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(25, 2);
			defaultInterpolatedStringHandler.AppendLiteral("[Teleport] IncId:");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.IncId);
			defaultInterpolatedStringHandler.AppendLiteral(" GridId:");
			MapTeleportByLocationOp mapTeleportByLocationOp = this.Data.MapTeleportByLocationOp;
			defaultInterpolatedStringHandler.AppendFormatted<int?>((mapTeleportByLocationOp != null) ? new int?(mapTeleportByLocationOp.GridIndex) : null);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x06039E7C RID: 237180 RVA: 0x00EA8F66 File Offset: 0x00EA7166
		protected override void OnStartExecute(MapRogueGameInfo gameInfo)
		{
			base.Execute(gameInfo, null);
		}

		// Token: 0x06039E7D RID: 237181 RVA: 0x00EA8F70 File Offset: 0x00EA7170
		protected override void OnExecute(MapRogueGameInfo gameInfo)
		{
			MapTeleportByLocationOp mapTeleportByLocationOp = this.Data.MapTeleportByLocationOp;
			if (mapTeleportByLocationOp == null)
			{
				return;
			}
			List<int> list = new List<int>();
			list.AddRange(mapTeleportByLocationOp.Grids);
			gameInfo.TeleportFlow(mapTeleportByLocationOp.GridIndex, list).ContinueWith(delegate()
			{
				this.Execute(gameInfo, null);
			});
		}

		// Token: 0x06039E7E RID: 237182 RVA: 0x00EA8FD7 File Offset: 0x00EA71D7
		protected override void OnFinish(MapRogueGameInfo gameInfo)
		{
		}
	}
}
