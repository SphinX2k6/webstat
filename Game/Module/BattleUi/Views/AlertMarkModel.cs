using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005F93 RID: 24467
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class AlertMarkModel : ModelBase<AlertMarkModel>
	{
		// Token: 0x0603D6CF RID: 251599 RVA: 0x00FA0C13 File Offset: 0x00F9EE13
		public void AddPendingMarkInfo(int id, AActor trackActor, EAlertnessType type, float showDist)
		{
			this.PendingMarkInfos[id] = new ValueTuple<AActor, EAlertnessType, float>(trackActor, type, showDist);
		}

		// Token: 0x04022847 RID: 141383
		public bool AlertMarkInit;

		// Token: 0x04022848 RID: 141384
		[TupleElementNames(new string[]
		{
			"trackActor",
			"type",
			"showDist"
		})]
		[Nullable(new byte[]
		{
			1,
			0,
			1
		})]
		public readonly Dictionary<int, ValueTuple<AActor, EAlertnessType, float>> PendingMarkInfos = new Dictionary<int, ValueTuple<AActor, EAlertnessType, float>>();
	}
}
