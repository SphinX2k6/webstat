using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardItem.Component
{
	// Token: 0x0200554A RID: 21834
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class CardDisabledComponent : CardComponentBase<ICardDisabledComponentData>
	{
		// Token: 0x06037A7B RID: 227963 RVA: 0x00E1E38A File Offset: 0x00E1C58A
		public override void Refresh(ICardDisabledComponentData data)
		{
			this.SetActive(data.Disabled && data.ShowComponent);
		}
	}
}
