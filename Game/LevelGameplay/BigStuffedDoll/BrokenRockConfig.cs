using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.BigStuffedDoll
{
	// Token: 0x02006F53 RID: 28499
	[NullableContext(1)]
	[Nullable(0)]
	public class BrokenRockConfig : IBrokenRockConfig
	{
		// Token: 0x1700A475 RID: 42101
		// (get) Token: 0x06044F8F RID: 282511 RVA: 0x011F4E49 File Offset: 0x011F3049
		// (set) Token: 0x06044F90 RID: 282512 RVA: 0x011F4E51 File Offset: 0x011F3051
		public int Id { get; set; }

		// Token: 0x1700A476 RID: 42102
		// (get) Token: 0x06044F91 RID: 282513 RVA: 0x011F4E5A File Offset: 0x011F305A
		// (set) Token: 0x06044F92 RID: 282514 RVA: 0x011F4E62 File Offset: 0x011F3062
		public int[] Rings { get; set; }

		// Token: 0x1700A477 RID: 42103
		// (get) Token: 0x06044F93 RID: 282515 RVA: 0x011F4E6B File Offset: 0x011F306B
		// (set) Token: 0x06044F94 RID: 282516 RVA: 0x011F4E73 File Offset: 0x011F3073
		public int ScoreMax { get; set; }

		// Token: 0x1700A478 RID: 42104
		// (get) Token: 0x06044F95 RID: 282517 RVA: 0x011F4E7C File Offset: 0x011F307C
		// (set) Token: 0x06044F96 RID: 282518 RVA: 0x011F4E84 File Offset: 0x011F3084
		public int ScoreUp { get; set; }

		// Token: 0x1700A479 RID: 42105
		// (get) Token: 0x06044F97 RID: 282519 RVA: 0x011F4E8D File Offset: 0x011F308D
		// (set) Token: 0x06044F98 RID: 282520 RVA: 0x011F4E95 File Offset: 0x011F3095
		public int ScoreDown { get; set; }

		// Token: 0x1700A47A RID: 42106
		// (get) Token: 0x06044F99 RID: 282521 RVA: 0x011F4E9E File Offset: 0x011F309E
		// (set) Token: 0x06044F9A RID: 282522 RVA: 0x011F4EA6 File Offset: 0x011F30A6
		public int GlobalTime { get; set; }

		// Token: 0x1700A47B RID: 42107
		// (get) Token: 0x06044F9B RID: 282523 RVA: 0x011F4EAF File Offset: 0x011F30AF
		// (set) Token: 0x06044F9C RID: 282524 RVA: 0x011F4EB7 File Offset: 0x011F30B7
		public int NormalSkill { get; set; }

		// Token: 0x1700A47C RID: 42108
		// (get) Token: 0x06044F9D RID: 282525 RVA: 0x011F4EC0 File Offset: 0x011F30C0
		// (set) Token: 0x06044F9E RID: 282526 RVA: 0x011F4EC8 File Offset: 0x011F30C8
		public int FinishSkill { get; set; }

		// Token: 0x1700A47D RID: 42109
		// (get) Token: 0x06044F9F RID: 282527 RVA: 0x011F4ED1 File Offset: 0x011F30D1
		// (set) Token: 0x06044FA0 RID: 282528 RVA: 0x011F4ED9 File Offset: 0x011F30D9
		public string EntityUid { get; set; }
	}
}
