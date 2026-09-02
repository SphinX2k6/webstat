using System;
using System.Collections.Generic;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip.View
{
	// Token: 0x020064EA RID: 25834
	public class SongLevelDetailPanel : UiPanelBase
	{
		// Token: 0x06040B3A RID: 265018 RVA: 0x010974CC File Offset: 0x010956CC
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUITexture)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIText))
			};
		}

		// Token: 0x06040B3B RID: 265019 RVA: 0x01097554 File Offset: 0x01095754
		public void RefreshPanelByLevelId(int levelId)
		{
			RhythmShipLevel? rhythmShipLevelById = ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipLevelById(levelId);
			if (rhythmShipLevelById == null)
			{
				return;
			}
			base.SetTextureByPath(rhythmShipLevelById.Value.DesTexture, base.GetTexture(0), null, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), rhythmShipLevelById.Value.Name, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), rhythmShipLevelById.Value.DesName, Array.Empty<object>());
			base.GetText(4).SetText(rhythmShipLevelById.Value.TimeText, true);
		}
	}
}
