using System;
using System.Runtime.Serialization;
using CSharpScript.Core.Common;

namespace CSharpScript.Game.Module.PhoneMessage
{
	// Token: 0x02005450 RID: 21584
	[EnumExtensions]
	public enum EAttachmentType
	{
		// Token: 0x0401FA3F RID: 129599
		[EnumMember(Value = "Image")]
		Image,
		// Token: 0x0401FA40 RID: 129600
		[EnumMember(Value = "Spine")]
		Spine,
		// Token: 0x0401FA41 RID: 129601
		[EnumMember(Value = "Mp4")]
		Mp4
	}
}
