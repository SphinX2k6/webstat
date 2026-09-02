using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DB4 RID: 19892
	public class MarkTransformComponent : TrapMapComponentBase
	{
		// Token: 0x06033861 RID: 211041 RVA: 0x00CE3534 File Offset: 0x00CE1734
		[NullableContext(1)]
		public MarkTransformComponent(TrapMapEntity parent) : base(parent)
		{
		}

		// Token: 0x17008819 RID: 34841
		// (get) Token: 0x06033862 RID: 211042 RVA: 0x00CE353D File Offset: 0x00CE173D
		public override ETrapDefenseMapComponent ComponentType
		{
			get
			{
				return ETrapDefenseMapComponent.MarkTransformComponent;
			}
		}
	}
}
