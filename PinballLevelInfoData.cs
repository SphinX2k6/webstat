using System;
using System.Runtime.CompilerServices;

// Token: 0x020014A7 RID: 5287
[NullableContext(2)]
[Nullable(0)]
public class PinballLevelInfoData : IPinballLevelInfoData
{
	// Token: 0x17000C47 RID: 3143
	// (get) Token: 0x06009411 RID: 37905 RVA: 0x002702F9 File Offset: 0x0026E4F9
	// (set) Token: 0x06009412 RID: 37906 RVA: 0x00270301 File Offset: 0x0026E501
	public int LevelId { get; set; }

	// Token: 0x17000C48 RID: 3144
	// (get) Token: 0x06009413 RID: 37907 RVA: 0x0027030A File Offset: 0x0026E50A
	// (set) Token: 0x06009414 RID: 37908 RVA: 0x00270312 File Offset: 0x0026E512
	public int RealLevelId { get; set; }

	// Token: 0x17000C49 RID: 3145
	// (get) Token: 0x06009415 RID: 37909 RVA: 0x0027031B File Offset: 0x0026E51B
	// (set) Token: 0x06009416 RID: 37910 RVA: 0x00270323 File Offset: 0x0026E523
	public int[] LevelStarConditionIds { get; set; }

	// Token: 0x17000C4A RID: 3146
	// (get) Token: 0x06009417 RID: 37911 RVA: 0x0027032C File Offset: 0x0026E52C
	// (set) Token: 0x06009418 RID: 37912 RVA: 0x00270334 File Offset: 0x0026E534
	public int? LevelScore { get; set; }

	// Token: 0x17000C4B RID: 3147
	// (get) Token: 0x06009419 RID: 37913 RVA: 0x0027033D File Offset: 0x0026E53D
	// (set) Token: 0x0600941A RID: 37914 RVA: 0x00270345 File Offset: 0x0026E545
	public bool? LevelLock { get; set; }

	// Token: 0x17000C4C RID: 3148
	// (get) Token: 0x0600941B RID: 37915 RVA: 0x0027034E File Offset: 0x0026E54E
	// (set) Token: 0x0600941C RID: 37916 RVA: 0x00270356 File Offset: 0x0026E556
	public string LevelLockTexts { get; set; }

	// Token: 0x17000C4D RID: 3149
	// (get) Token: 0x0600941D RID: 37917 RVA: 0x0027035F File Offset: 0x0026E55F
	// (set) Token: 0x0600941E RID: 37918 RVA: 0x00270367 File Offset: 0x0026E567
	public bool? ShowDesc { get; set; }

	// Token: 0x17000C4E RID: 3150
	// (get) Token: 0x0600941F RID: 37919 RVA: 0x00270370 File Offset: 0x0026E570
	// (set) Token: 0x06009420 RID: 37920 RVA: 0x00270378 File Offset: 0x0026E578
	public bool? ShowStar { get; set; }

	// Token: 0x17000C4F RID: 3151
	// (get) Token: 0x06009421 RID: 37921 RVA: 0x00270381 File Offset: 0x0026E581
	// (set) Token: 0x06009422 RID: 37922 RVA: 0x00270389 File Offset: 0x0026E589
	public bool? ShowScore { get; set; }

	// Token: 0x17000C50 RID: 3152
	// (get) Token: 0x06009423 RID: 37923 RVA: 0x00270392 File Offset: 0x0026E592
	// (set) Token: 0x06009424 RID: 37924 RVA: 0x0027039A File Offset: 0x0026E59A
	public bool? ShowReward { get; set; }

	// Token: 0x17000C51 RID: 3153
	// (get) Token: 0x06009425 RID: 37925 RVA: 0x002703A3 File Offset: 0x0026E5A3
	// (set) Token: 0x06009426 RID: 37926 RVA: 0x002703AB File Offset: 0x0026E5AB
	public int? RewardDropId { get; set; }

	// Token: 0x17000C52 RID: 3154
	// (get) Token: 0x06009427 RID: 37927 RVA: 0x002703B4 File Offset: 0x0026E5B4
	// (set) Token: 0x06009428 RID: 37928 RVA: 0x002703BC File Offset: 0x0026E5BC
	public bool? RewardReceived { get; set; }

	// Token: 0x17000C53 RID: 3155
	// (get) Token: 0x06009429 RID: 37929 RVA: 0x002703C5 File Offset: 0x0026E5C5
	// (set) Token: 0x0600942A RID: 37930 RVA: 0x002703CD File Offset: 0x0026E5CD
	public string RewardClearTitle { get; set; }
}
