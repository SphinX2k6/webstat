using System;
using System.Runtime.CompilerServices;

// Token: 0x02002F41 RID: 12097
[NullableContext(1)]
[Nullable(0)]
public class BuffOverStackCompensation : BuffEffect
{
	// Token: 0x06018C17 RID: 101399 RVA: 0x006FF3CD File Offset: 0x006FD5CD
	public BuffOverStackCompensation(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
	{
	}

	// Token: 0x06018C18 RID: 101400 RVA: 0x006FF3DC File Offset: 0x006FD5DC
	[return: Nullable(2)]
	public override object OnExecute(params object[] parameters)
	{
		return null;
	}
}
