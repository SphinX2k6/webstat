using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Vehicle.Motorcycle
{
	// Token: 0x020047AA RID: 18346
	public class NearestRoadway : IClear
	{
		// Token: 0x0602F9E7 RID: 195047 RVA: 0x00B5D6FD File Offset: 0x00B5B8FD
		public bool ClearObject()
		{
			this.NearestPos.Reset();
			this.Roadway = null;
			return true;
		}

		// Token: 0x0401B3E7 RID: 111591
		[Nullable(1)]
		public Vector NearestPos = Vector.Create();

		// Token: 0x0401B3E8 RID: 111592
		[Nullable(2)]
		public UKuroRoadway Roadway;
	}
}
