using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x02005926 RID: 22822
	[NullableContext(1)]
	[Nullable(0)]
	public class Node
	{
		// Token: 0x06039EAC RID: 237228 RVA: 0x00EA93A8 File Offset: 0x00EA75A8
		public Node(INodeConstructor aParams)
		{
			this.Id = aParams.GridId;
			this.Position = aParams.Position;
			this.Cost = aParams.Cost;
			this.H = 0;
			this.G = 0;
			this.F = 0;
			this.ParentNode = null;
			this.IsOnClosedList = false;
			this.IsOnOpenList = false;
			this.IsWalkable = aParams.Walkable;
		}

		// Token: 0x06039EAD RID: 237229 RVA: 0x00EA9435 File Offset: 0x00EA7635
		private void CalculateF()
		{
			this.F = this.G + this.H;
		}

		// Token: 0x06039EAE RID: 237230 RVA: 0x00EA944A File Offset: 0x00EA764A
		public void SetG(int gValue)
		{
			this.G = gValue;
			this.CalculateF();
		}

		// Token: 0x06039EAF RID: 237231 RVA: 0x00EA9459 File Offset: 0x00EA7659
		public void SetH(int hValue)
		{
			this.H = hValue;
			this.CalculateF();
		}

		// Token: 0x06039EB0 RID: 237232 RVA: 0x00EA9468 File Offset: 0x00EA7668
		public void SetValueToZero()
		{
			this.F = (this.G = (this.H = 0));
		}

		// Token: 0x04020CF5 RID: 134389
		public int Id;

		// Token: 0x04020CF6 RID: 134390
		public IPos Position = new Pos
		{
			X = 0,
			Y = 0
		};

		// Token: 0x04020CF7 RID: 134391
		public int F;

		// Token: 0x04020CF8 RID: 134392
		public int G;

		// Token: 0x04020CF9 RID: 134393
		public int H;

		// Token: 0x04020CFA RID: 134394
		public int Cost;

		// Token: 0x04020CFB RID: 134395
		[Nullable(2)]
		public Node ParentNode;

		// Token: 0x04020CFC RID: 134396
		public bool IsOnClosedList;

		// Token: 0x04020CFD RID: 134397
		public bool IsOnOpenList;

		// Token: 0x04020CFE RID: 134398
		public bool IsWalkable = true;
	}
}
