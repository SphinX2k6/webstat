using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.MovieMode
{
	// Token: 0x020056EA RID: 22250
	[NullableContext(1)]
	[Nullable(0)]
	[RequiredMember]
	public class UiItemAspectOffsetConfig : IUiItemAspectOffsetConfig
	{
		// Token: 0x17009100 RID: 37120
		// (get) Token: 0x06038A11 RID: 231953 RVA: 0x00E5793E File Offset: 0x00E55B3E
		// (set) Token: 0x06038A12 RID: 231954 RVA: 0x00E57946 File Offset: 0x00E55B46
		[RequiredMember]
		public UUIItem UiItem { get; set; }

		// Token: 0x17009101 RID: 37121
		// (get) Token: 0x06038A13 RID: 231955 RVA: 0x00E5794F File Offset: 0x00E55B4F
		// (set) Token: 0x06038A14 RID: 231956 RVA: 0x00E57957 File Offset: 0x00E55B57
		[RequiredMember]
		public Vector2D OriginalOffset { get; set; }

		// Token: 0x17009102 RID: 37122
		// (get) Token: 0x06038A15 RID: 231957 RVA: 0x00E57960 File Offset: 0x00E55B60
		// (set) Token: 0x06038A16 RID: 231958 RVA: 0x00E57968 File Offset: 0x00E55B68
		[RequiredMember]
		public float OffsetWidthDirection { get; set; }

		// Token: 0x17009103 RID: 37123
		// (get) Token: 0x06038A17 RID: 231959 RVA: 0x00E57971 File Offset: 0x00E55B71
		// (set) Token: 0x06038A18 RID: 231960 RVA: 0x00E57979 File Offset: 0x00E55B79
		[RequiredMember]
		public float OffsetHeightDirection { get; set; }

		// Token: 0x06038A19 RID: 231961 RVA: 0x00E57982 File Offset: 0x00E55B82
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public UiItemAspectOffsetConfig()
		{
		}
	}
}
