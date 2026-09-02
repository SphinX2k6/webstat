using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.ExtraEffect
{
	// Token: 0x0200498B RID: 18827
	[NullableContext(1)]
	[Nullable(0)]
	public class AbnormalDark : BuffEffect
	{
		// Token: 0x06031305 RID: 201477 RVA: 0x00C3F28F File Offset: 0x00C3D48F
		public AbnormalDark(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
		{
		}

		// Token: 0x06031306 RID: 201478 RVA: 0x00C3F29E File Offset: 0x00C3D49E
		[return: Nullable(2)]
		public override object OnExecute(params object[] args)
		{
			return null;
		}

		// Token: 0x06031307 RID: 201479 RVA: 0x00C3F2A1 File Offset: 0x00C3D4A1
		public override void OnPeriodCallback()
		{
		}
	}
}
