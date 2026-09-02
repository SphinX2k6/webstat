using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using CSharpScript.Core.Common;

namespace CSharpScript.Game.LevelGamePlay.BigStuffedDoll
{
	// Token: 0x02006F55 RID: 28501
	[NullableContext(1)]
	[Nullable(0)]
	public class BrokenRockRingConfig : IBrokenRockRingConfig
	{
		// Token: 0x1700A48B RID: 42123
		// (get) Token: 0x06044FBC RID: 282556 RVA: 0x011F4EEA File Offset: 0x011F30EA
		// (set) Token: 0x06044FBD RID: 282557 RVA: 0x011F4EF2 File Offset: 0x011F30F2
		public int Id { get; set; }

		// Token: 0x1700A48C RID: 42124
		// (get) Token: 0x06044FBE RID: 282558 RVA: 0x011F4EFB File Offset: 0x011F30FB
		// (set) Token: 0x06044FBF RID: 282559 RVA: 0x011F4F03 File Offset: 0x011F3103
		public List<List<int>> InvalidBox { get; set; }

		// Token: 0x1700A48D RID: 42125
		// (get) Token: 0x06044FC0 RID: 282560 RVA: 0x011F4F0C File Offset: 0x011F310C
		// (set) Token: 0x06044FC1 RID: 282561 RVA: 0x011F4F14 File Offset: 0x011F3114
		public int[] RandomBox { get; set; }

		// Token: 0x1700A48E RID: 42126
		// (get) Token: 0x06044FC2 RID: 282562 RVA: 0x011F4F1D File Offset: 0x011F311D
		// (set) Token: 0x06044FC3 RID: 282563 RVA: 0x011F4F25 File Offset: 0x011F3125
		public int PerfectBox { get; set; }

		// Token: 0x1700A48F RID: 42127
		// (get) Token: 0x06044FC4 RID: 282564 RVA: 0x011F4F2E File Offset: 0x011F312E
		// (set) Token: 0x06044FC5 RID: 282565 RVA: 0x011F4F36 File Offset: 0x011F3136
		[JsonConverter(typeof(IntMapStringConverter))]
		public Dictionary<int, int> BonusRate { get; set; }

		// Token: 0x1700A490 RID: 42128
		// (get) Token: 0x06044FC6 RID: 282566 RVA: 0x011F4F3F File Offset: 0x011F313F
		// (set) Token: 0x06044FC7 RID: 282567 RVA: 0x011F4F47 File Offset: 0x011F3147
		public int GoodScore { get; set; }

		// Token: 0x1700A491 RID: 42129
		// (get) Token: 0x06044FC8 RID: 282568 RVA: 0x011F4F50 File Offset: 0x011F3150
		// (set) Token: 0x06044FC9 RID: 282569 RVA: 0x011F4F58 File Offset: 0x011F3158
		public int PerfectScore { get; set; }

		// Token: 0x1700A492 RID: 42130
		// (get) Token: 0x06044FCA RID: 282570 RVA: 0x011F4F61 File Offset: 0x011F3161
		// (set) Token: 0x06044FCB RID: 282571 RVA: 0x011F4F69 File Offset: 0x011F3169
		public int BonusScore { get; set; }

		// Token: 0x1700A493 RID: 42131
		// (get) Token: 0x06044FCC RID: 282572 RVA: 0x011F4F72 File Offset: 0x011F3172
		// (set) Token: 0x06044FCD RID: 282573 RVA: 0x011F4F7A File Offset: 0x011F317A
		[JsonConverter(typeof(IntMapStringConverter))]
		public Dictionary<int, int> Speed { get; set; }

		// Token: 0x1700A494 RID: 42132
		// (get) Token: 0x06044FCE RID: 282574 RVA: 0x011F4F83 File Offset: 0x011F3183
		// (set) Token: 0x06044FCF RID: 282575 RVA: 0x011F4F8B File Offset: 0x011F318B
		public int ColdTime { get; set; }

		// Token: 0x1700A495 RID: 42133
		// (get) Token: 0x06044FD0 RID: 282576 RVA: 0x011F4F94 File Offset: 0x011F3194
		// (set) Token: 0x06044FD1 RID: 282577 RVA: 0x011F4F9C File Offset: 0x011F319C
		public int MultiBoxGroup { get; set; }

		// Token: 0x1700A496 RID: 42134
		// (get) Token: 0x06044FD2 RID: 282578 RVA: 0x011F4FA5 File Offset: 0x011F31A5
		// (set) Token: 0x06044FD3 RID: 282579 RVA: 0x011F4FAD File Offset: 0x011F31AD
		public int[] Offset { get; set; }

		// Token: 0x1700A497 RID: 42135
		// (get) Token: 0x06044FD4 RID: 282580 RVA: 0x011F4FB6 File Offset: 0x011F31B6
		// (set) Token: 0x06044FD5 RID: 282581 RVA: 0x011F4FBE File Offset: 0x011F31BE
		public bool IsAnticlockwise { get; set; }
	}
}
