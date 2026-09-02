using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Capability
{
	// Token: 0x02007075 RID: 28789
	[NullableContext(2)]
	[Nullable(0)]
	public abstract class CapabilityData
	{
		// Token: 0x06045C59 RID: 285785 RVA: 0x01241653 File Offset: 0x0123F853
		protected CapabilityData(ICapabilityGameObject ownerGameObject = null)
		{
		}

		// Token: 0x06045C5A RID: 285786
		public abstract void OnAdded();

		// Token: 0x06045C5B RID: 285787
		public abstract void OnRemoved();

		// Token: 0x0402708D RID: 159885
		public ICapabilityGameObject OwnerGameObject = ownerGameObject;
	}
}
