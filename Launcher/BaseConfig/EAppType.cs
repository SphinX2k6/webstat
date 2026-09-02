using System;
using CSharpScript.Core.Common;

namespace CSharpScript.Launcher.BaseConfig
{
	// Token: 0x0200468B RID: 18059
	[EnumExtensions]
	public enum EAppType
	{
		// Token: 0x0401ACC9 RID: 109769
		[EnumStringMember("Development")]
		DEVELOPMENT,
		// Token: 0x0401ACCA RID: 109770
		[EnumStringMember("Prerelease")]
		PREREKEASE,
		// Token: 0x0401ACCB RID: 109771
		[EnumStringMember("Product")]
		PRODUCT
	}
}
