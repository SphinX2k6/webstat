using System;
using System.Runtime.CompilerServices;

// Token: 0x02002B9C RID: 11164
[NullableContext(1)]
public interface ISurvivorsRogueCardType
{
	// Token: 0x17001D34 RID: 7476
	// (get) Token: 0x060163D3 RID: 91091
	ISurvivorsRogueItemCard Normal { get; }

	// Token: 0x17001D35 RID: 7477
	// (get) Token: 0x060163D4 RID: 91092
	ISurvivorsRogueWeaponCard Weapon { get; }

	// Token: 0x17001D36 RID: 7478
	// (get) Token: 0x060163D5 RID: 91093
	ISurvivorsRogueCharacterCard Character { get; }
}
