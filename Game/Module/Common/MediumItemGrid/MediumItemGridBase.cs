using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Common.MediumItemGrid
{
	// Token: 0x02005E58 RID: 24152
	[NullableContext(2)]
	[Nullable(0)]
	public abstract class MediumItemGridBase : IMediumItemGridBase
	{
		// Token: 0x17009949 RID: 39241
		// (get) Token: 0x0603CCA5 RID: 248997
		public abstract EMediumItemGridType Type { get; }

		// Token: 0x040221CB RID: 139723
		public object Data;

		// Token: 0x040221CC RID: 139724
		public int? ItemConfigId;

		// Token: 0x040221CD RID: 139725
		public string BottomTextId;

		// Token: 0x040221CE RID: 139726
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public object[] BottomTextParameter;

		// Token: 0x040221CF RID: 139727
		public string BottomText;

		// Token: 0x040221D0 RID: 139728
		public bool? IsOmitBottomText;

		// Token: 0x040221D1 RID: 139729
		public string IconPath;

		// Token: 0x040221D2 RID: 139730
		public int? QualityId;

		// Token: 0x040221D3 RID: 139731
		public string QualityIcon;

		// Token: 0x040221D4 RID: 139732
		public CommonDefine.EQualityIconType? QualityType;

		// Token: 0x040221D5 RID: 139733
		public bool? IsQualityHidden;

		// Token: 0x040221D6 RID: 139734
		public string SpriteIconPath;
	}
}
