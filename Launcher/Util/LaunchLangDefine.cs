using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.Util
{
	// Token: 0x020044A3 RID: 17571
	[NullableContext(1)]
	[Nullable(0)]
	public class LaunchLangDefine
	{
		// Token: 0x0602E544 RID: 189764 RVA: 0x00AE03CA File Offset: 0x00ADE5CA
		public LaunchLangDefine(int languageType, string languageCode, string audioCode)
		{
			this.LanguageType = languageType;
			this.LanguageCode = languageCode;
			this.AudioCode = audioCode;
		}

		// Token: 0x0401A501 RID: 107777
		public readonly int LanguageType;

		// Token: 0x0401A502 RID: 107778
		public readonly string LanguageCode;

		// Token: 0x0401A503 RID: 107779
		public readonly string AudioCode;
	}
}
