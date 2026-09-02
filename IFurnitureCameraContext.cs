using System;
using System.Runtime.CompilerServices;

// Token: 0x02001052 RID: 4178
[NullableContext(1)]
public interface IFurnitureCameraContext
{
	// Token: 0x17000896 RID: 2198
	// (get) Token: 0x06006CBC RID: 27836
	Vector Pos { get; }

	// Token: 0x17000897 RID: 2199
	// (get) Token: 0x06006CBD RID: 27837
	Rotator Rot { get; }

	// Token: 0x17000898 RID: 2200
	// (get) Token: 0x06006CBE RID: 27838
	float Fov { get; }
}
