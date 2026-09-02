using System;
using System.Runtime.CompilerServices;

// Token: 0x02000022 RID: 34
[RequiredMember]
public class AkMarkerCbLabelSoundTrackEffect : AkMarkerCbLabel
{
	// Token: 0x0600009A RID: 154 RVA: 0x00005865 File Offset: 0x00003A65
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public AkMarkerCbLabelSoundTrackEffect()
	{
	}

	// Token: 0x0400006E RID: 110
	[Nullable(1)]
	[RequiredMember]
	public string Action;

	// Token: 0x0400006F RID: 111
	public int? Length;

	// Token: 0x04000070 RID: 112
	public double? MaxDistance;
}
