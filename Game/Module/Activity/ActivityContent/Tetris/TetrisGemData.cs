using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x020062B5 RID: 25269
	[NullableContext(1)]
	[Nullable(0)]
	public class TetrisGemData
	{
		// Token: 0x0603F975 RID: 260469 RVA: 0x0104C33E File Offset: 0x0104A53E
		public void Reset()
		{
			this.CollectedGems.Clear();
			this.SpawnCounts.Clear();
			this.CurrentGemBagInternal = new List<EGemType>();
		}

		// Token: 0x17009C9E RID: 40094
		// (get) Token: 0x0603F976 RID: 260470 RVA: 0x0104C361 File Offset: 0x0104A561
		// (set) Token: 0x0603F977 RID: 260471 RVA: 0x0104C369 File Offset: 0x0104A569
		public List<EGemType> CurrentGemBag
		{
			get
			{
				return this.CurrentGemBagInternal;
			}
			set
			{
				this.CurrentGemBagInternal = value;
			}
		}

		// Token: 0x0603F978 RID: 260472 RVA: 0x0104C372 File Offset: 0x0104A572
		public Dictionary<EGemType, int> GetCurrentGem()
		{
			return this.CollectedGems;
		}

		// Token: 0x0603F979 RID: 260473 RVA: 0x0104C37C File Offset: 0x0104A57C
		public int GetSpawnCount(EGemType type)
		{
			int result;
			if (!this.SpawnCounts.TryGetValue(type, out result))
			{
				return 0;
			}
			return result;
		}

		// Token: 0x0603F97A RID: 260474 RVA: 0x0104C39C File Offset: 0x0104A59C
		public void SetSpawnCount(EGemType type, int count)
		{
			if (this.SpawnCounts.ContainsKey(type))
			{
				this.SpawnCounts[type] = count;
				return;
			}
			this.SpawnCounts.Add(type, count);
		}

		// Token: 0x0603F97B RID: 260475 RVA: 0x0104C3C8 File Offset: 0x0104A5C8
		public void AddGem(EGemType type, int count)
		{
			int num;
			if (!this.CollectedGems.TryGetValue(type, out num))
			{
				num = 0;
			}
			if (this.CollectedGems.ContainsKey(type))
			{
				this.CollectedGems[type] = num + 1;
				return;
			}
			this.CollectedGems.Add(type, num + 1);
		}

		// Token: 0x0603F97C RID: 260476 RVA: 0x0104C414 File Offset: 0x0104A614
		public int GetGem(EGemType type)
		{
			int result;
			if (!this.CollectedGems.TryGetValue(type, out result))
			{
				return 0;
			}
			return result;
		}

		// Token: 0x0603F97D RID: 260477 RVA: 0x0104C434 File Offset: 0x0104A634
		public ITetrisGemSnapshot CreateSnapshot()
		{
			return new TetrisGemSnapshot
			{
				CollectedGems = new Dictionary<EGemType, int>(this.CollectedGems),
				CurrentGemBag = new List<EGemType>(this.CurrentGemBagInternal),
				SpawnCounts = new Dictionary<EGemType, int>(this.SpawnCounts)
			};
		}

		// Token: 0x0603F97E RID: 260478 RVA: 0x0104C470 File Offset: 0x0104A670
		public void RestoreFromSnapshot(ITetrisGemSnapshot snapshot)
		{
			this.CollectedGems.Clear();
			foreach (KeyValuePair<EGemType, int> keyValuePair in snapshot.CollectedGems)
			{
				this.CollectedGems.Add(keyValuePair.Key, keyValuePair.Value);
			}
			this.CurrentGemBagInternal = new List<EGemType>(snapshot.CurrentGemBag);
			this.SpawnCounts.Clear();
			foreach (KeyValuePair<EGemType, int> keyValuePair2 in snapshot.SpawnCounts)
			{
				this.SpawnCounts.Add(keyValuePair2.Key, keyValuePair2.Value);
			}
		}

		// Token: 0x04023B09 RID: 146185
		private readonly Dictionary<EGemType, int> CollectedGems = new Dictionary<EGemType, int>();

		// Token: 0x04023B0A RID: 146186
		private List<EGemType> CurrentGemBagInternal = new List<EGemType>();

		// Token: 0x04023B0B RID: 146187
		private readonly Dictionary<EGemType, int> SpawnCounts = new Dictionary<EGemType, int>();
	}
}
