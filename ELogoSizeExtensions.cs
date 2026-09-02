using System;
using System.Runtime.CompilerServices;

// Token: 0x02000EE2 RID: 3810
public static class ELogoSizeExtensions
{
	// Token: 0x06005E04 RID: 24068 RVA: 0x0017838C File Offset: 0x0017658C
	[NullableContext(1)]
	public static string ToValue(this ELogoSize size)
	{
		string result;
		switch (size)
		{
		case ELogoSize.Small:
			result = "36";
			break;
		case ELogoSize.Medium:
			result = "40";
			break;
		case ELogoSize.Large:
			result = "52";
			break;
		default:
			result = "36";
			break;
		}
		return result;
	}
}
