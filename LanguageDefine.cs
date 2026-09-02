using System;
using System.Runtime.CompilerServices;

// Token: 0x02000041 RID: 65
[NullableContext(1)]
[Nullable(0)]
public class LanguageDefine
{
	// Token: 0x1700000F RID: 15
	// (get) Token: 0x06000103 RID: 259 RVA: 0x000076CE File Offset: 0x000058CE
	public int LanguageType { get; }

	// Token: 0x17000010 RID: 16
	// (get) Token: 0x06000104 RID: 260 RVA: 0x000076D6 File Offset: 0x000058D6
	public string LanguageCode { get; }

	// Token: 0x17000011 RID: 17
	// (get) Token: 0x06000105 RID: 261 RVA: 0x000076DE File Offset: 0x000058DE
	public string AudioCode { get; }

	// Token: 0x06000106 RID: 262 RVA: 0x000076E6 File Offset: 0x000058E6
	public LanguageDefine(int languageType, string languageCode, string audioCode)
	{
		this.LanguageType = languageType;
		this.LanguageCode = languageCode;
		this.AudioCode = audioCode;
	}
}
