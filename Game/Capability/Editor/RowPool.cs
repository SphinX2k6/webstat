using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Capability.Editor
{
	// Token: 0x0200707B RID: 28795
	[NullableContext(1)]
	[Nullable(0)]
	[RequiredMember]
	public class RowPool
	{
		// Token: 0x06045C9B RID: 285851 RVA: 0x012422AD File Offset: 0x012404AD
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public RowPool()
		{
		}

		// Token: 0x040270A4 RID: 159908
		[RequiredMember]
		public UTextBlock Label;

		// Token: 0x040270A5 RID: 159909
		[Nullable(2)]
		public UCanvasPanelSlot LabelSlot;

		// Token: 0x040270A6 RID: 159910
		[RequiredMember]
		public string LabelText;

		// Token: 0x040270A7 RID: 159911
		[RequiredMember]
		public List<UImage> Spans;

		// Token: 0x040270A8 RID: 159912
		[Nullable(new byte[]
		{
			1,
			2
		})]
		[RequiredMember]
		public List<UCanvasPanelSlot> SpanSlots;

		// Token: 0x040270A9 RID: 159913
		[RequiredMember]
		public List<UImage> Events;

		// Token: 0x040270AA RID: 159914
		[Nullable(new byte[]
		{
			1,
			2
		})]
		[RequiredMember]
		public List<UCanvasPanelSlot> EventSlots;

		// Token: 0x040270AB RID: 159915
		[RequiredMember]
		public int UsedSpans;

		// Token: 0x040270AC RID: 159916
		[RequiredMember]
		public int UsedEvents;
	}
}
