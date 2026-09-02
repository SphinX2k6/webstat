using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DB3 RID: 19891
	public class EntityPosSyncComponent : TrapMapComponentBase
	{
		// Token: 0x0603385F RID: 211039 RVA: 0x00CE3528 File Offset: 0x00CE1728
		[NullableContext(1)]
		public EntityPosSyncComponent(TrapMapEntity parent) : base(parent)
		{
		}

		// Token: 0x17008818 RID: 34840
		// (get) Token: 0x06033860 RID: 211040 RVA: 0x00CE3531 File Offset: 0x00CE1731
		public override ETrapDefenseMapComponent ComponentType
		{
			get
			{
				return ETrapDefenseMapComponent.EntityPosSyncComponent;
			}
		}
	}
}
