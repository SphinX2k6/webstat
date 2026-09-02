using System;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardItem.Component
{
	// Token: 0x02005551 RID: 21841
	public class CardLockComponent : CardComponentBase<bool>
	{
		// Token: 0x06037AA4 RID: 228004 RVA: 0x00E1E8BF File Offset: 0x00E1CABF
		public override void Refresh(bool isLocked)
		{
			this.SetActive(isLocked);
		}
	}
}
