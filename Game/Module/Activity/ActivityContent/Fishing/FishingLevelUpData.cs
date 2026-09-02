using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x02006836 RID: 26678
	public class FishingLevelUpData
	{
		// Token: 0x0604282F RID: 272431 RVA: 0x01112704 File Offset: 0x01110904
		public FishingLevelUpData(int lastExp, int currentExp)
		{
			this.InitExpMaxList();
			this.AddExp = currentExp - lastExp;
			this.LastLevel = this.GetLevelByExp(lastExp);
			this.CurrentLevel = this.GetLevelByExp(currentExp);
			this.LastExp = lastExp - this.ExpMaxList[this.LastLevel - 1];
		}

		// Token: 0x06042830 RID: 272432 RVA: 0x01112768 File Offset: 0x01110968
		private void InitExpMaxList()
		{
			FishingConfig instance = ConfigBase<FishingConfig>.Instance;
			IReadOnlyList<FishingReputation> readOnlyList = (instance != null) ? instance.GetAllFishingReputation() : null;
			if (readOnlyList != null)
			{
				foreach (FishingReputation fishingReputation in readOnlyList)
				{
					this.ExpMaxList.Add(fishingReputation.Exp);
				}
			}
		}

		// Token: 0x06042831 RID: 272433 RVA: 0x011127D0 File Offset: 0x011109D0
		private int GetLevelByExp(int exp)
		{
			int result = 0;
			int i = 0;
			int count = this.ExpMaxList.Count;
			while (i < count)
			{
				int num = this.ExpMaxList[i];
				if (exp < num)
				{
					return result;
				}
				result = i + 1;
				i++;
			}
			return result;
		}

		// Token: 0x06042832 RID: 272434 RVA: 0x01112810 File Offset: 0x01110A10
		public int GetMaxExpByLevel(int level)
		{
			if (level >= this.ExpMaxList.Count)
			{
				return this.ExpMaxList[this.ExpMaxList.Count - 1] - this.ExpMaxList[this.ExpMaxList.Count - 2];
			}
			if (level <= 0)
			{
				return 0;
			}
			return this.ExpMaxList[level] - this.ExpMaxList[level - 1];
		}

		// Token: 0x06042833 RID: 272435 RVA: 0x0111287E File Offset: 0x01110A7E
		public bool IsLevelUp()
		{
			return this.CurrentLevel > this.LastLevel;
		}

		// Token: 0x06042834 RID: 272436 RVA: 0x0111288E File Offset: 0x01110A8E
		public bool IsCurrentLevelMax()
		{
			return this.CurrentLevel == this.ExpMaxList.Count;
		}

		// Token: 0x04025043 RID: 151619
		public readonly int AddExp;

		// Token: 0x04025044 RID: 151620
		public readonly int LastExp;

		// Token: 0x04025045 RID: 151621
		public readonly int LastLevel;

		// Token: 0x04025046 RID: 151622
		public int CurrentLevel;

		// Token: 0x04025047 RID: 151623
		[Nullable(1)]
		private readonly List<int> ExpMaxList = new List<int>();
	}
}
