using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.Character.Common.Component
{
	// Token: 0x0200490C RID: 18700
	public class PhysicsState
	{
		// Token: 0x06030DF4 RID: 200180 RVA: 0x00C1BAA6 File Offset: 0x00C19CA6
		public void InitBaseState(bool active)
		{
			this.Active = active;
			this.QuitCache = false;
		}

		// Token: 0x06030DF5 RID: 200181 RVA: 0x00C1BAB6 File Offset: 0x00C19CB6
		public void ClearAnimState()
		{
			this.QuitCache = false;
		}

		// Token: 0x06030DF6 RID: 200182 RVA: 0x00C1BABF File Offset: 0x00C19CBF
		public void SetNewState(bool active)
		{
			if (this.Active && !active)
			{
				this.QuitCache = true;
			}
			this.Active = active;
		}

		// Token: 0x06030DF7 RID: 200183 RVA: 0x00C1BADA File Offset: 0x00C19CDA
		[NullableContext(1)]
		public void StateInherit(PhysicsState preState)
		{
			this.Active = preState.Active;
			this.QuitCache = preState.QuitCache;
		}

		// Token: 0x0401C17B RID: 115067
		public bool Active;

		// Token: 0x0401C17C RID: 115068
		public bool QuitCache;
	}
}
