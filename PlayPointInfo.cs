using System;
using System.Runtime.CompilerServices;

// Token: 0x02001B70 RID: 7024
[NullableContext(2)]
[Nullable(0)]
public class PlayPointInfo : IPlayPointInfo
{
	// Token: 0x17001054 RID: 4180
	// (get) Token: 0x0600CBF0 RID: 52208 RVA: 0x00366557 File Offset: 0x00364757
	// (set) Token: 0x0600CBF1 RID: 52209 RVA: 0x0036655F File Offset: 0x0036475F
	public int PlayId { get; set; }

	// Token: 0x17001055 RID: 4181
	// (get) Token: 0x0600CBF2 RID: 52210 RVA: 0x00366568 File Offset: 0x00364768
	// (set) Token: 0x0600CBF3 RID: 52211 RVA: 0x00366570 File Offset: 0x00364770
	public int EntityId { get; set; }

	// Token: 0x17001056 RID: 4182
	// (get) Token: 0x0600CBF4 RID: 52212 RVA: 0x00366579 File Offset: 0x00364779
	// (set) Token: 0x0600CBF5 RID: 52213 RVA: 0x00366581 File Offset: 0x00364781
	public EPlayPointState PlayState { get; set; }

	// Token: 0x17001057 RID: 4183
	// (get) Token: 0x0600CBF6 RID: 52214 RVA: 0x0036658A File Offset: 0x0036478A
	// (set) Token: 0x0600CBF7 RID: 52215 RVA: 0x00366592 File Offset: 0x00364792
	public bool? IsClear { get; set; }

	// Token: 0x17001058 RID: 4184
	// (get) Token: 0x0600CBF8 RID: 52216 RVA: 0x0036659B File Offset: 0x0036479B
	// (set) Token: 0x0600CBF9 RID: 52217 RVA: 0x003665A3 File Offset: 0x003647A3
	public string ClearInfo { get; set; }

	// Token: 0x17001059 RID: 4185
	// (get) Token: 0x0600CBFA RID: 52218 RVA: 0x003665AC File Offset: 0x003647AC
	// (set) Token: 0x0600CBFB RID: 52219 RVA: 0x003665B4 File Offset: 0x003647B4
	public bool? LevelPlayMarkUnlock { get; set; }

	// Token: 0x1700105A RID: 4186
	// (get) Token: 0x0600CBFC RID: 52220 RVA: 0x003665BD File Offset: 0x003647BD
	// (set) Token: 0x0600CBFD RID: 52221 RVA: 0x003665C5 File Offset: 0x003647C5
	public bool IsUnlock { get; set; }
}
