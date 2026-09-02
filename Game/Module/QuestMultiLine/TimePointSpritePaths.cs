using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.QuestMultiLine
{
	// Token: 0x0200531C RID: 21276
	[NullableContext(1)]
	[Nullable(0)]
	public class TimePointSpritePaths : ITimePointSpritePaths
	{
		// Token: 0x17008D1F RID: 36127
		// (get) Token: 0x060364BA RID: 222394 RVA: 0x00DAF5D7 File Offset: 0x00DAD7D7
		// (set) Token: 0x060364BB RID: 222395 RVA: 0x00DAF5DF File Offset: 0x00DAD7DF
		public string Idle { get; set; }

		// Token: 0x17008D20 RID: 36128
		// (get) Token: 0x060364BC RID: 222396 RVA: 0x00DAF5E8 File Offset: 0x00DAD7E8
		// (set) Token: 0x060364BD RID: 222397 RVA: 0x00DAF5F0 File Offset: 0x00DAD7F0
		public string Hover { get; set; }

		// Token: 0x17008D21 RID: 36129
		// (get) Token: 0x060364BE RID: 222398 RVA: 0x00DAF5F9 File Offset: 0x00DAD7F9
		// (set) Token: 0x060364BF RID: 222399 RVA: 0x00DAF601 File Offset: 0x00DAD801
		public string Pressed { get; set; }

		// Token: 0x17008D22 RID: 36130
		// (get) Token: 0x060364C0 RID: 222400 RVA: 0x00DAF60A File Offset: 0x00DAD80A
		// (set) Token: 0x060364C1 RID: 222401 RVA: 0x00DAF612 File Offset: 0x00DAD812
		public string Selected { get; set; }
	}
}
