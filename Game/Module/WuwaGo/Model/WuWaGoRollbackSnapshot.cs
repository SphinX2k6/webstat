using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.WuwaGo.Model
{
	// Token: 0x02004AD8 RID: 19160
	[NullableContext(1)]
	[Nullable(0)]
	public class WuWaGoRollbackSnapshot
	{
		// Token: 0x06031F5B RID: 204635 RVA: 0x00C82316 File Offset: 0x00C80516
		private WuWaGoRollbackSnapshot(int round, Dictionary<int, IRollbackCapture> captures)
		{
			this.Round = round;
			this.Captures = captures;
		}

		// Token: 0x06031F5C RID: 204636 RVA: 0x00C8232C File Offset: 0x00C8052C
		public static WuWaGoRollbackSnapshot CreateFromCaptures(int round, Dictionary<int, IRollbackCapture> captures)
		{
			return new WuWaGoRollbackSnapshot(round, captures);
		}

		// Token: 0x17008537 RID: 34103
		// (get) Token: 0x06031F5D RID: 204637 RVA: 0x00C82335 File Offset: 0x00C80535
		public int Size
		{
			get
			{
				return this.Captures.Count;
			}
		}

		// Token: 0x06031F5E RID: 204638 RVA: 0x00C82342 File Offset: 0x00C80542
		public IReadOnlyList<IRollbackCapture> GetCaptures()
		{
			return this.Captures.Values.ToList<IRollbackCapture>();
		}

		// Token: 0x06031F5F RID: 204639 RVA: 0x00C82354 File Offset: 0x00C80554
		public void RestoreToGameData(WuWaGoGameData gameData)
		{
			gameData.Round = this.Round;
			foreach (KeyValuePair<int, IRollbackCapture> keyValuePair in this.Captures)
			{
				int num;
				IRollbackCapture rollbackCapture;
				keyValuePair.Deconstruct(out num, out rollbackCapture);
				rollbackCapture.Restore();
			}
		}

		// Token: 0x0401D3C0 RID: 119744
		public readonly int Round;

		// Token: 0x0401D3C1 RID: 119745
		private readonly Dictionary<int, IRollbackCapture> Captures;
	}
}
