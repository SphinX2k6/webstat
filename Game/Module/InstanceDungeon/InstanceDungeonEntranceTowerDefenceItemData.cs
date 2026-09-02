using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.InstanceDungeon
{
	// Token: 0x02005BBC RID: 23484
	[NullableContext(1)]
	[Nullable(0)]
	[RequiredMember]
	public class InstanceDungeonEntranceTowerDefenceItemData
	{
		// Token: 0x17009778 RID: 38776
		// (get) Token: 0x0603B706 RID: 243462 RVA: 0x00F10AF3 File Offset: 0x00F0ECF3
		// (set) Token: 0x0603B707 RID: 243463 RVA: 0x00F10AFB File Offset: 0x00F0ECFB
		[RequiredMember]
		public List<TItem> Data { get; set; }

		// Token: 0x0603B708 RID: 243464 RVA: 0x00F10B04 File Offset: 0x00F0ED04
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public InstanceDungeonEntranceTowerDefenceItemData()
		{
		}
	}
}
