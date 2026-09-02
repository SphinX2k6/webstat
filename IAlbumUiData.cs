using System;
using Aki.Config;

// Token: 0x0200231B RID: 8987
public interface IAlbumUiData
{
	// Token: 0x17001520 RID: 5408
	// (get) Token: 0x0601118D RID: 70029
	// (set) Token: 0x0601118E RID: 70030
	int Id { get; set; }

	// Token: 0x17001521 RID: 5409
	// (get) Token: 0x0601118F RID: 70031
	// (set) Token: 0x06011190 RID: 70032
	PhonographAlbum Config { get; set; }

	// Token: 0x17001522 RID: 5410
	// (get) Token: 0x06011191 RID: 70033
	// (set) Token: 0x06011192 RID: 70034
	int UnlockMusicNum { get; set; }

	// Token: 0x17001523 RID: 5411
	// (get) Token: 0x06011193 RID: 70035
	// (set) Token: 0x06011194 RID: 70036
	int AllMusicNum { get; set; }

	// Token: 0x17001524 RID: 5412
	// (get) Token: 0x06011195 RID: 70037
	// (set) Token: 0x06011196 RID: 70038
	bool? IsSelected { get; set; }
}
