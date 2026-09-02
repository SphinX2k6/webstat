using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.ExtraEffect
{
	// Token: 0x02004988 RID: 18824
	[NullableContext(1)]
	[Nullable(0)]
	public class AbnormalFire : BuffEffect
	{
		// Token: 0x060312FE RID: 201470 RVA: 0x00C3F263 File Offset: 0x00C3D463
		public AbnormalFire(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
		{
		}

		// Token: 0x060312FF RID: 201471 RVA: 0x00C3F272 File Offset: 0x00C3D472
		[return: Nullable(2)]
		public override object OnExecute(params object[] args)
		{
			return null;
		}

		// Token: 0x06031300 RID: 201472 RVA: 0x00C3F275 File Offset: 0x00C3D475
		public override void OnPeriodCallback()
		{
		}
	}
}
