using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip.View
{
	// Token: 0x020064FB RID: 25851
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RhythmShipQuickSelectLevelGirdItemTitle : SyncGridProxyAbstract<RhythmShipQuickSelectLevelData>
	{
		// Token: 0x06040B67 RID: 265063 RVA: 0x01098341 File Offset: 0x01096541
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText))
			};
		}

		// Token: 0x06040B68 RID: 265064 RVA: 0x01098364 File Offset: 0x01096564
		public override void Refresh(RhythmShipQuickSelectLevelData data)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), data.TitleText, Array.Empty<object>());
		}
	}
}
