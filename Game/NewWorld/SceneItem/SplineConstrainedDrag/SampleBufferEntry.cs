using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem.SplineConstrainedDrag
{
	// Token: 0x02004824 RID: 18468
	[RequiredMember]
	public class SampleBufferEntry
	{
		// Token: 0x17008237 RID: 33335
		// (get) Token: 0x060300EF RID: 196847 RVA: 0x00BA5BA9 File Offset: 0x00BA3DA9
		// (set) Token: 0x060300F0 RID: 196848 RVA: 0x00BA5BB1 File Offset: 0x00BA3DB1
		[RequiredMember]
		public float Distance { get; set; }

		// Token: 0x17008238 RID: 33336
		// (get) Token: 0x060300F1 RID: 196849 RVA: 0x00BA5BBA File Offset: 0x00BA3DBA
		// (set) Token: 0x060300F2 RID: 196850 RVA: 0x00BA5BC2 File Offset: 0x00BA3DC2
		[RequiredMember]
		public FVector2D ScreenPos { get; set; }

		// Token: 0x17008239 RID: 33337
		// (get) Token: 0x060300F3 RID: 196851 RVA: 0x00BA5BCB File Offset: 0x00BA3DCB
		// (set) Token: 0x060300F4 RID: 196852 RVA: 0x00BA5BD3 File Offset: 0x00BA3DD3
		[RequiredMember]
		public bool Valid { get; set; }

		// Token: 0x060300F5 RID: 196853 RVA: 0x00BA5BDC File Offset: 0x00BA3DDC
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public SampleBufferEntry()
		{
		}
	}
}
