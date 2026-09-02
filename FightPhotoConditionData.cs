using System;
using System.Runtime.CompilerServices;

// Token: 0x020025B1 RID: 9649
[NullableContext(1)]
[Nullable(0)]
public class FightPhotoConditionData
{
	// Token: 0x06012D42 RID: 77122 RVA: 0x005349ED File Offset: 0x00532BED
	public FightPhotoConditionData(string text, EFightPhotoConditionType conditionType)
	{
		this.Text = text;
		this.ConditionType = conditionType;
	}

	// Token: 0x0400932A RID: 37674
	public string Text;

	// Token: 0x0400932B RID: 37675
	public EFightPhotoConditionType ConditionType;
}
