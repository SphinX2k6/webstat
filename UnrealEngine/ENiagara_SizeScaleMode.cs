using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace UnrealEngine
{
	// Token: 0x0200443E RID: 17470
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Niagara/Enums/ENiagara_SizeScaleMode.ENiagara_SizeScaleMode")]
	public enum ENiagara_SizeScaleMode : byte
	{
		// Token: 0x0401A3BB RID: 107451
		Unset,
		// Token: 0x0401A3BC RID: 107452
		Uniform,
		// Token: 0x0401A3BD RID: 107453
		Random_Uniform,
		// Token: 0x0401A3BE RID: 107454
		Non_Uniform,
		// Token: 0x0401A3BF RID: 107455
		Random_Non_Uniform,
		// Token: 0x0401A3C0 RID: 107456
		ENiagara_MAX
	}
}
