using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

namespace CSharpScript.Game.Module.MingSu
{
	// Token: 0x02005733 RID: 22323
	[NullableContext(1)]
	[Nullable(0)]
	public class MingSuInstance
	{
		// Token: 0x06038CF7 RID: 232695 RVA: 0x00E64462 File Offset: 0x00E62662
		public MingSuInstance(int id)
		{
			this.DragonPoolId = id;
			this.DragonPoolConfig = ConfigDragonPoolById.GetConfig(this.DragonPoolId, true);
			this.DragonPoolState = 0;
			this.DragonPoolLevel = 0;
			this.HadCoreCount = 0;
		}

		// Token: 0x06038CF8 RID: 232696 RVA: 0x00E64498 File Offset: 0x00E62698
		public virtual void SetDragonPoolLevel(int level)
		{
			this.DragonPoolLevel = level;
		}

		// Token: 0x06038CF9 RID: 232697 RVA: 0x00E644A1 File Offset: 0x00E626A1
		public int GetDragonPoolLevel()
		{
			return this.DragonPoolLevel;
		}

		// Token: 0x06038CFA RID: 232698 RVA: 0x00E644AC File Offset: 0x00E626AC
		public void SetDragonPoolState(int finishedLevel)
		{
			int dragonPoolMaxLevel = this.GetDragonPoolMaxLevel();
			this.DragonPoolState = ((finishedLevel >= dragonPoolMaxLevel) ? 2 : 1);
		}

		// Token: 0x06038CFB RID: 232699 RVA: 0x00E644CE File Offset: 0x00E626CE
		public int GetDragonPoolState()
		{
			return this.DragonPoolState;
		}

		// Token: 0x06038CFC RID: 232700 RVA: 0x00E644D6 File Offset: 0x00E626D6
		public void SetHadCoreCount(int count)
		{
			this.HadCoreCount = count;
		}

		// Token: 0x06038CFD RID: 232701 RVA: 0x00E644DF File Offset: 0x00E626DF
		public int GetHadCoreCount()
		{
			return this.HadCoreCount;
		}

		// Token: 0x06038CFE RID: 232702 RVA: 0x00E644E8 File Offset: 0x00E626E8
		public int GetDragonPoolMaxLevel()
		{
			return this.DragonPoolConfig.Value.GetGoalArray().Length;
		}

		// Token: 0x06038CFF RID: 232703 RVA: 0x00E6450C File Offset: 0x00E6270C
		public int GetNeedCoreCount(int level)
		{
			int[] goalArray = this.DragonPoolConfig.Value.GetGoalArray();
			if (level >= goalArray.Length)
			{
				return 0;
			}
			return goalArray[level];
		}

		// Token: 0x06038D00 RID: 232704 RVA: 0x00E64538 File Offset: 0x00E62738
		public bool IsMaxLevel()
		{
			return this.GetDragonPoolLevel() >= this.GetDragonPoolMaxLevel();
		}

		// Token: 0x06038D01 RID: 232705 RVA: 0x00E6454C File Offset: 0x00E6274C
		public int[] GetGoalList()
		{
			return this.DragonPoolConfig.Value.GetGoalArray();
		}

		// Token: 0x06038D02 RID: 232706 RVA: 0x00E6456C File Offset: 0x00E6276C
		public int GetRewardId(int level)
		{
			return this.DragonPoolConfig.Value.GetDropIdsArray()[level];
		}

		// Token: 0x06038D03 RID: 232707 RVA: 0x00E64590 File Offset: 0x00E62790
		public int GetCoreId()
		{
			return this.DragonPoolConfig.Value.CoreId;
		}

		// Token: 0x06038D04 RID: 232708 RVA: 0x00E645B0 File Offset: 0x00E627B0
		public virtual void SetLevelGainList(int levelGain)
		{
		}

		// Token: 0x06038D05 RID: 232709 RVA: 0x00E645B2 File Offset: 0x00E627B2
		public void SetDropItemList(ItemDict[] items)
		{
			this.DropItemList = items;
		}

		// Token: 0x06038D06 RID: 232710 RVA: 0x00E645BB File Offset: 0x00E627BB
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public ItemDict[] GetDropItemList()
		{
			return this.DropItemList;
		}

		// Token: 0x040205DB RID: 132571
		public readonly int DragonPoolId;

		// Token: 0x040205DC RID: 132572
		protected int DragonPoolState;

		// Token: 0x040205DD RID: 132573
		protected int DragonPoolLevel;

		// Token: 0x040205DE RID: 132574
		protected int HadCoreCount;

		// Token: 0x040205DF RID: 132575
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected ItemDict[] DropItemList;

		// Token: 0x040205E0 RID: 132576
		protected readonly DragonPool? DragonPoolConfig;
	}
}
