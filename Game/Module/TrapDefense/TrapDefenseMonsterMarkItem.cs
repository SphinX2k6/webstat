using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DB8 RID: 19896
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseMonsterMarkItem : TrapDefenseMarkItem
	{
		// Token: 0x06033887 RID: 211079 RVA: 0x00CE373C File Offset: 0x00CE193C
		[NullableContext(2)]
		public TrapDefenseMonsterMarkItem(int markId, object extraParam = null) : base(markId, extraParam)
		{
			if (extraParam is ETrapDefenseEnemyType)
			{
				ETrapDefenseEnemyType enemyTypeInner = (ETrapDefenseEnemyType)extraParam;
				this.EnemyTypeInner = enemyTypeInner;
				return;
			}
			this.EnemyTypeInner = ETrapDefenseEnemyType.Phantom;
		}

		// Token: 0x17008826 RID: 34854
		// (get) Token: 0x06033888 RID: 211080 RVA: 0x00CE3776 File Offset: 0x00CE1976
		public override TrapDefenseDefine.ETrapDefenseMarkType MarkType
		{
			get
			{
				return TrapDefenseDefine.ETrapDefenseMarkType.Phantom;
			}
		}

		// Token: 0x17008827 RID: 34855
		// (get) Token: 0x06033889 RID: 211081 RVA: 0x00CE3779 File Offset: 0x00CE1979
		public override Vector WorldPosition
		{
			get
			{
				return this.WorldPositionVector;
			}
		}

		// Token: 0x17008828 RID: 34856
		// (get) Token: 0x0603388A RID: 211082 RVA: 0x00CE3781 File Offset: 0x00CE1981
		// (set) Token: 0x0603388B RID: 211083 RVA: 0x00CE3789 File Offset: 0x00CE1989
		public ETrapDefenseEnemyType EnemyType
		{
			get
			{
				return this.EnemyTypeInner;
			}
			set
			{
				this.EnemyTypeInner = value;
			}
		}

		// Token: 0x0603388C RID: 211084 RVA: 0x00CE3792 File Offset: 0x00CE1992
		protected override void OnInitialize()
		{
			this.EnableCachePosition = false;
		}

		// Token: 0x0603388D RID: 211085 RVA: 0x00CE379B File Offset: 0x00CE199B
		public void SetWorldPosition(float x, float y, float z)
		{
			this.WorldPositionVector.Set((double)x, (double)y, (double)z);
		}

		// Token: 0x0401DD65 RID: 122213
		private ETrapDefenseEnemyType EnemyTypeInner = ETrapDefenseEnemyType.Phantom;
	}
}
