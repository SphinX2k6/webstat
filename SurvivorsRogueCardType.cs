using System;
using System.Runtime.CompilerServices;

// Token: 0x02002B9D RID: 11165
[NullableContext(1)]
[Nullable(0)]
public class SurvivorsRogueCardType : ISurvivorsRogueCardType
{
	// Token: 0x17001D37 RID: 7479
	// (get) Token: 0x060163D6 RID: 91094 RVA: 0x006298BC File Offset: 0x00627ABC
	// (set) Token: 0x060163D7 RID: 91095 RVA: 0x006298C4 File Offset: 0x00627AC4
	public ISurvivorsRogueItemCard Normal { get; set; }

	// Token: 0x17001D38 RID: 7480
	// (get) Token: 0x060163D8 RID: 91096 RVA: 0x006298CD File Offset: 0x00627ACD
	// (set) Token: 0x060163D9 RID: 91097 RVA: 0x006298D5 File Offset: 0x00627AD5
	public ISurvivorsRogueWeaponCard Weapon { get; set; }

	// Token: 0x17001D39 RID: 7481
	// (get) Token: 0x060163DA RID: 91098 RVA: 0x006298DE File Offset: 0x00627ADE
	// (set) Token: 0x060163DB RID: 91099 RVA: 0x006298E6 File Offset: 0x00627AE6
	public ISurvivorsRogueCharacterCard Character { get; set; }
}
