using System;
using UnrealEngine;

// Token: 0x02003071 RID: 12401
public class CharacterSwimUtils
{
	// Token: 0x0400CA10 RID: 51728
	private const int MAX_BYTE = 255;

	// Token: 0x0400CA11 RID: 51729
	private const int EIGHTY = 80;

	// Token: 0x0400CA12 RID: 51730
	public static readonly FVector AfterTransformLocationOffset = new FVector(80f, 0f, 0f);

	// Token: 0x0400CA13 RID: 51731
	public static readonly FLinearColor DebugColor1 = new FLinearColor(255f, 255f, 0f, 1f);

	// Token: 0x0400CA14 RID: 51732
	public static readonly FLinearColor DebugColor2 = new FLinearColor(0f, 255f, 0f, 1f);

	// Token: 0x0400CA15 RID: 51733
	public static readonly FLinearColor DebugColor3 = new FLinearColor(255f, 0f, 0f, 1f);

	// Token: 0x0400CA16 RID: 51734
	public static readonly FLinearColor DebugColor4 = new FLinearColor(0f, 255f, 255f, 1f);
}
