using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Controller
{
	// Token: 0x020058ED RID: 22765
	[NullableContext(2)]
	[Nullable(0)]
	internal class LineTraceSaver
	{
		// Token: 0x06039C44 RID: 236612 RVA: 0x00EA0BB8 File Offset: 0x00E9EDB8
		protected void InitTrackInfo()
		{
			this.LineTrace = new UTraceLineElement();
			this.LineTrace.WorldContextObject = GlobalData.World;
			this.LineTrace.bIsSingle = true;
			this.LineTrace.bIgnoreSelf = true;
			this.LineTrace.SetTraceTypeQuery(KuroTraceTypeQuery.IkGround);
		}

		// Token: 0x06039C45 RID: 236613 RVA: 0x00EA0C08 File Offset: 0x00E9EE08
		public Vector GetMarkPosition(double x, double y)
		{
			if (this.LineTrace == null)
			{
				this.InitTrackInfo();
			}
			Vector result = null;
			this.LineTrace.SetStartLocation(x * 100.0, y * 100.0, 1000000.0);
			this.LineTrace.SetEndLocation(x * 100.0, y * 100.0, -1000000.0);
			bool flag = Singleton<TraceElementCommon>.Instance.LineTrace(this.LineTrace, "WorldMapView_CreateNewCustomMarkItem");
			UKuroHitResult hitResult = this.LineTrace.HitResult;
			if (flag && hitResult.bBlockingHit)
			{
				float num = hitResult.LocationZ_Array.Get(0);
				num /= 100f;
				result = Vector.Create(x, y, (double)num);
			}
			return result;
		}

		// Token: 0x06039C46 RID: 236614 RVA: 0x00EA0CC4 File Offset: 0x00E9EEC4
		public void OnClear()
		{
			this.LineTrace = null;
		}

		// Token: 0x04020C06 RID: 134150
		private UTraceLineElement LineTrace;
	}
}
