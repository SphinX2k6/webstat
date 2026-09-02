using System;
using System.Text.Json.Serialization;
using CSharpScript.Core.Common;

namespace CSharpScript.Core.Define.TdConfigExtensions
{
	// Token: 0x02007134 RID: 28980
	[JsonConverter(typeof(EPackageJsonConverter))]
	[EnumExtensions]
	public enum EPackage
	{
		// Token: 0x04027585 RID: 161157
		[EnumStringMember("M")]
		Message,
		// Token: 0x04027586 RID: 161158
		[EnumStringMember("C")]
		Connect,
		// Token: 0x04027587 RID: 161159
		[EnumStringMember("CA")]
		ConnectAck
	}
}
