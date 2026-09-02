using System;
using System.Runtime.CompilerServices;

// Token: 0x02003260 RID: 12896
[NullableContext(2)]
public interface IBuffRecord
{
	// Token: 0x170024B3 RID: 9395
	// (get) Token: 0x0601AEBF RID: 110271
	// (set) Token: 0x0601AEC0 RID: 110272
	long BuffId { get; set; }

	// Token: 0x170024B4 RID: 9396
	// (get) Token: 0x0601AEC1 RID: 110273
	// (set) Token: 0x0601AEC2 RID: 110274
	float TimeStamp { get; set; }

	// Token: 0x170024B5 RID: 9397
	// (get) Token: 0x0601AEC3 RID: 110275
	// (set) Token: 0x0601AEC4 RID: 110276
	int AreaId { get; set; }

	// Token: 0x170024B6 RID: 9398
	// (get) Token: 0x0601AEC5 RID: 110277
	// (set) Token: 0x0601AEC6 RID: 110278
	Vector Location { get; set; }

	// Token: 0x170024B7 RID: 9399
	// (get) Token: 0x0601AEC7 RID: 110279
	// (set) Token: 0x0601AEC8 RID: 110280
	float Damage { get; set; }
}
