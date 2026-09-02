using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.MovieMode
{
	// Token: 0x020056E8 RID: 22248
	[RequiredMember]
	public class MovieModeAspectOffset : IMovieModeAspectOffset
	{
		// Token: 0x170090F8 RID: 37112
		// (get) Token: 0x06038A00 RID: 231936 RVA: 0x00E578F2 File Offset: 0x00E55AF2
		// (set) Token: 0x06038A01 RID: 231937 RVA: 0x00E578FA File Offset: 0x00E55AFA
		[RequiredMember]
		public bool IsFadeIn { get; set; }

		// Token: 0x170090F9 RID: 37113
		// (get) Token: 0x06038A02 RID: 231938 RVA: 0x00E57903 File Offset: 0x00E55B03
		// (set) Token: 0x06038A03 RID: 231939 RVA: 0x00E5790B File Offset: 0x00E55B0B
		[RequiredMember]
		public bool IsWidthBlend { get; set; }

		// Token: 0x170090FA RID: 37114
		// (get) Token: 0x06038A04 RID: 231940 RVA: 0x00E57914 File Offset: 0x00E55B14
		// (set) Token: 0x06038A05 RID: 231941 RVA: 0x00E5791C File Offset: 0x00E55B1C
		[RequiredMember]
		public float Offset { get; set; }

		// Token: 0x170090FB RID: 37115
		// (get) Token: 0x06038A06 RID: 231942 RVA: 0x00E57925 File Offset: 0x00E55B25
		// (set) Token: 0x06038A07 RID: 231943 RVA: 0x00E5792D File Offset: 0x00E55B2D
		[RequiredMember]
		public float Progress { get; set; }

		// Token: 0x06038A08 RID: 231944 RVA: 0x00E57936 File Offset: 0x00E55B36
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public MovieModeAspectOffset()
		{
		}
	}
}
