using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.InstanceDungeon.InstanceDungeonSubComponent
{
	// Token: 0x02005BEF RID: 23535
	[NullableContext(1)]
	[Nullable(0)]
	[RequiredMember]
	public class IInstanceDungeonRecommendElementItem
	{
		// Token: 0x170097A9 RID: 38825
		// (get) Token: 0x0603B921 RID: 244001 RVA: 0x00F19D50 File Offset: 0x00F17F50
		// (set) Token: 0x0603B922 RID: 244002 RVA: 0x00F19D58 File Offset: 0x00F17F58
		[RequiredMember]
		public List<int> Element { get; set; }

		// Token: 0x0603B923 RID: 244003 RVA: 0x00F19D61 File Offset: 0x00F17F61
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public IInstanceDungeonRecommendElementItem()
		{
		}
	}
}
