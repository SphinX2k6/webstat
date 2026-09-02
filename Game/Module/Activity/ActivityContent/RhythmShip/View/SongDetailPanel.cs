using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip.View
{
	// Token: 0x020064F4 RID: 25844
	public class SongDetailPanel : UiPanelBase
	{
		// Token: 0x06040B5D RID: 265053 RVA: 0x01097E38 File Offset: 0x01096038
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUITexture)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIText)),
				new ValueTuple<int, Type>(6, typeof(UUIHorizontalLayout)),
				new ValueTuple<int, Type>(7, typeof(UUIItem))
			};
		}

		// Token: 0x06040B5E RID: 265054 RVA: 0x01097F00 File Offset: 0x01096100
		protected override void OnStart()
		{
			this.StarLayout = new GenericLayout<RhythmShipPauseStarItem, bool>(base.GetHorizontalLayout(6), () => new RhythmShipPauseStarItem(), null, false, true);
		}

		// Token: 0x06040B5F RID: 265055 RVA: 0x01097F38 File Offset: 0x01096138
		public void RefreshPanel()
		{
			RhythmShipLevel? rhythmShipLevelById = ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipLevelById(ModelBase<RhythmShipModel>.Instance.RhythmShipLevelId);
			if (rhythmShipLevelById == null)
			{
				return;
			}
			base.SetTextureByPath(rhythmShipLevelById.Value.DesTexture, base.GetTexture(0), null, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), rhythmShipLevelById.Value.Name, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), rhythmShipLevelById.Value.DesName, Array.Empty<object>());
			base.GetText(5).SetText(ModelBase<RhythmShipModel>.Instance.GetCurrentPauseTime() + "/" + rhythmShipLevelById.Value.TimeText, true);
			RhythmSubLevel? rhythmShipSubLevelById = ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipSubLevelById(ModelBase<RhythmShipModel>.Instance.RhythmShipSubLevelId);
			if (rhythmShipSubLevelById == null)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), RhythmShipDefine.rhythmShipDifficultyText[rhythmShipSubLevelById.Value.Difficulty], Array.Empty<object>());
			IEnumerable<RhythmSubLevel> enumerable = ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipSubLevelByLevelId(ModelBase<RhythmShipModel>.Instance.RhythmShipLevelId) ?? new List<RhythmSubLevel>();
			int num = 0;
			foreach (RhythmSubLevel rhythmSubLevel in enumerable)
			{
				if (rhythmSubLevel.Id == ModelBase<RhythmShipModel>.Instance.RhythmShipSubLevelId)
				{
					num = rhythmSubLevel.StarLevel;
					break;
				}
			}
			List<bool> list = new List<bool>();
			for (int i = 1; i <= 9; i++)
			{
				if (i <= num)
				{
					list.Add(true);
				}
				else
				{
					list.Add(false);
				}
			}
			GenericLayout<RhythmShipPauseStarItem, bool> starLayout = this.StarLayout;
			if (starLayout == null)
			{
				return;
			}
			starLayout.RefreshByData(list, null, false);
		}

		// Token: 0x04024458 RID: 148568
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<RhythmShipPauseStarItem, bool> StarLayout;
	}
}
