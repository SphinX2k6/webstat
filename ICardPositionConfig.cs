using System;

// Token: 0x0200110F RID: 4367
public interface ICardPositionConfig
{
	// Token: 0x17000926 RID: 2342
	// (get) Token: 0x06007175 RID: 29045
	// (set) Token: 0x06007176 RID: 29046
	float PositionRate { get; set; }

	// Token: 0x17000927 RID: 2343
	// (get) Token: 0x06007177 RID: 29047
	// (set) Token: 0x06007178 RID: 29048
	float Spacing { get; set; }

	// Token: 0x17000928 RID: 2344
	// (get) Token: 0x06007179 RID: 29049
	// (set) Token: 0x0600717A RID: 29050
	float? UpOffset { get; set; }

	// Token: 0x17000929 RID: 2345
	// (get) Token: 0x0600717B RID: 29051
	// (set) Token: 0x0600717C RID: 29052
	float? Size { get; set; }

	// Token: 0x1700092A RID: 2346
	// (get) Token: 0x0600717D RID: 29053
	// (set) Token: 0x0600717E RID: 29054
	float? Alpha { get; set; }
}
