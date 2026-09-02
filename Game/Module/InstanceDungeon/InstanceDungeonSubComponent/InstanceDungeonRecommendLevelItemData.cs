using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.TowerDefence;

namespace CSharpScript.Game.Module.InstanceDungeon.InstanceDungeonSubComponent
{
	// Token: 0x02005BF1 RID: 23537
	[NullableContext(1)]
	[Nullable(0)]
	[RequiredMember]
	public class InstanceDungeonRecommendLevelItemData
	{
		// Token: 0x170097AA RID: 38826
		// (get) Token: 0x0603B929 RID: 244009 RVA: 0x00F19E2F File Offset: 0x00F1802F
		// (set) Token: 0x0603B92A RID: 244010 RVA: 0x00F19E37 File Offset: 0x00F18037
		[RequiredMember]
		public TowerDefenseRecommendLevel Level { get; set; }

		// Token: 0x0603B92B RID: 244011 RVA: 0x00F19E40 File Offset: 0x00F18040
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public InstanceDungeonRecommendLevelItemData()
		{
		}
	}
}
