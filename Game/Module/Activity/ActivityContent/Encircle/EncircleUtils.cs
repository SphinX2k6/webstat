using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Encircle
{
	// Token: 0x0200686E RID: 26734
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class EncircleUtils : Singleton<EncircleUtils>
	{
		// Token: 0x06042A0E RID: 272910 RVA: 0x011198F5 File Offset: 0x01117AF5
		public int PlanePosToKey(int x, int y)
		{
			return this.HexPosToKey(this.PlanePosToHexPos(x, y));
		}

		// Token: 0x06042A0F RID: 272911 RVA: 0x01119905 File Offset: 0x01117B05
		public int HexPosToKey(IHexPos pos)
		{
			return pos.PosY * this.Stride + pos.PosX;
		}

		// Token: 0x06042A10 RID: 272912 RVA: 0x0111991B File Offset: 0x01117B1B
		public IHexPos GetPosFromKey(int id)
		{
			return new HexPos
			{
				PosX = id % this.Stride,
				PosY = (int)Math.Floor((double)id / (double)this.Stride)
			};
		}

		// Token: 0x06042A11 RID: 272913 RVA: 0x01119946 File Offset: 0x01117B46
		public IHexPos PlanePosToHexPos(int x, int y)
		{
			return new HexPos
			{
				PosX = x * 2 + (y + 1) % 2,
				PosY = y
			};
		}

		// Token: 0x06042A12 RID: 272914 RVA: 0x01119964 File Offset: 0x01117B64
		[NullableContext(0)]
		[return: TupleElementNames(new string[]
		{
			"PosX",
			"PosY"
		})]
		public ValueTuple<int, int> HexPosToPlanePos([Nullable(1)] IHexPos hexPos)
		{
			int posY = hexPos.PosY;
			return new ValueTuple<int, int>((hexPos.PosX - (posY + 1) % 2) / 2, posY);
		}

		// Token: 0x04025141 RID: 151873
		private readonly int Stride = 100;

		// Token: 0x04025142 RID: 151874
		public IHexPos[] Directions = new IHexPos[]
		{
			new HexPos
			{
				PosX = 2,
				PosY = 0
			},
			new HexPos
			{
				PosX = 1,
				PosY = -1
			},
			new HexPos
			{
				PosX = -1,
				PosY = -1
			},
			new HexPos
			{
				PosX = -2,
				PosY = 0
			},
			new HexPos
			{
				PosX = -1,
				PosY = 1
			},
			new HexPos
			{
				PosX = 1,
				PosY = 1
			}
		};
	}
}
