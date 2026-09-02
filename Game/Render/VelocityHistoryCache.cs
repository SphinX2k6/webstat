using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Render
{
	// Token: 0x02004788 RID: 18312
	[NullableContext(1)]
	[Nullable(0)]
	public class VelocityHistoryCache
	{
		// Token: 0x0602F82B RID: 194603 RVA: 0x00B4EB68 File Offset: 0x00B4CD68
		public void Initialize(int size)
		{
			this.VelocityHistory.Clear();
			for (int i = 0; i < size; i++)
			{
				this.VelocityHistory.Add(Vector.Create(0.0, 0.0, 0.0));
			}
		}

		// Token: 0x0602F82C RID: 194604 RVA: 0x00B4EBB8 File Offset: 0x00B4CDB8
		public void AddVelocity(Vector velocity)
		{
			this.VelocityHistory[this.VelocityHistoryArrayPtr].Set(velocity.X, velocity.Y, velocity.Z);
			this.VelocityHistoryArrayPtr = (this.VelocityHistoryArrayPtr + 1) % this.VelocityHistory.Count;
		}

		// Token: 0x0602F82D RID: 194605 RVA: 0x00B4EC08 File Offset: 0x00B4CE08
		public double GetMaxVelocityDirection(Vector direction)
		{
			double num = 0.0;
			foreach (Vector vector in this.VelocityHistory)
			{
				num = Math.Max(num, vector.DotProduct(direction));
			}
			return num;
		}

		// Token: 0x0602F82E RID: 194606 RVA: 0x00B4EC70 File Offset: 0x00B4CE70
		public double GetMaxVelocity()
		{
			double num = 0.0;
			foreach (Vector vector in this.VelocityHistory)
			{
				num = Math.Max(num, vector.Size());
			}
			return num;
		}

		// Token: 0x0401B2A0 RID: 111264
		protected List<Vector> VelocityHistory = new List<Vector>();

		// Token: 0x0401B2A1 RID: 111265
		protected int VelocityHistoryArrayPtr;
	}
}
