using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Transport
{
	// Token: 0x02004E71 RID: 20081
	[NullableContext(1)]
	public interface ITransportFindPathResult
	{
		// Token: 0x170088CF RID: 35023
		// (get) Token: 0x06033E4D RID: 212557
		// (set) Token: 0x06033E4E RID: 212558
		FVectorDouble RoadStartPoint { get; set; }

		// Token: 0x170088D0 RID: 35024
		// (get) Token: 0x06033E4F RID: 212559
		// (set) Token: 0x06033E50 RID: 212560
		FVectorDouble RoadEndPoint { get; set; }

		// Token: 0x170088D1 RID: 35025
		// (get) Token: 0x06033E51 RID: 212561
		// (set) Token: 0x06033E52 RID: 212562
		TArray<UKuroRoadway> Roadways { get; set; }

		// Token: 0x170088D2 RID: 35026
		// (get) Token: 0x06033E53 RID: 212563
		// (set) Token: 0x06033E54 RID: 212564
		[Nullable(2)]
		UAutopilotRoute AutopilotRoute { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x170088D3 RID: 35027
		// (get) Token: 0x06033E55 RID: 212565
		// (set) Token: 0x06033E56 RID: 212566
		double? RouteLength { get; set; }
	}
}
