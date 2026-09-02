using System;
using Aki.Config;

// Token: 0x0200231C RID: 8988
public class AlbumUiData : IAlbumUiData
{
	// Token: 0x17001525 RID: 5413
	// (get) Token: 0x06011197 RID: 70039 RVA: 0x004B2E44 File Offset: 0x004B1044
	// (set) Token: 0x06011198 RID: 70040 RVA: 0x004B2E4C File Offset: 0x004B104C
	public int Id { get; set; }

	// Token: 0x17001526 RID: 5414
	// (get) Token: 0x06011199 RID: 70041 RVA: 0x004B2E55 File Offset: 0x004B1055
	// (set) Token: 0x0601119A RID: 70042 RVA: 0x004B2E5D File Offset: 0x004B105D
	public PhonographAlbum Config { get; set; }

	// Token: 0x17001527 RID: 5415
	// (get) Token: 0x0601119B RID: 70043 RVA: 0x004B2E66 File Offset: 0x004B1066
	// (set) Token: 0x0601119C RID: 70044 RVA: 0x004B2E6E File Offset: 0x004B106E
	public int UnlockMusicNum { get; set; }

	// Token: 0x17001528 RID: 5416
	// (get) Token: 0x0601119D RID: 70045 RVA: 0x004B2E77 File Offset: 0x004B1077
	// (set) Token: 0x0601119E RID: 70046 RVA: 0x004B2E7F File Offset: 0x004B107F
	public int AllMusicNum { get; set; }

	// Token: 0x17001529 RID: 5417
	// (get) Token: 0x0601119F RID: 70047 RVA: 0x004B2E88 File Offset: 0x004B1088
	// (set) Token: 0x060111A0 RID: 70048 RVA: 0x004B2E90 File Offset: 0x004B1090
	public bool? IsSelected { get; set; }
}
