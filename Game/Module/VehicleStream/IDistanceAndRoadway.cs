using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.VehicleStream
{
	// Token: 0x02004C47 RID: 19527
	[NullableContext(2)]
	public interface IDistanceAndRoadway
	{
		// Token: 0x17008761 RID: 34657
		// (get) Token: 0x06032E21 RID: 208417
		// (set) Token: 0x06032E22 RID: 208418
		float Distance { get; set; }

		// Token: 0x17008762 RID: 34658
		// (get) Token: 0x06032E23 RID: 208419
		// (set) Token: 0x06032E24 RID: 208420
		UKuroRoadway Roadway { get; set; }
	}
}
