using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip.View
{
	// Token: 0x02006518 RID: 25880
	public class RhythmShipSettlementView : UiViewBase
	{
		// Token: 0x06040BC1 RID: 265153 RVA: 0x01099472 File Offset: 0x01097672
		[NullableContext(1)]
		public RhythmShipSettlementView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06040BC2 RID: 265154 RVA: 0x01099484 File Offset: 0x01097684
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUITexture)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUITexture)),
				new ValueTuple<int, Type>(5, typeof(UUITexture)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIGridLayout)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUIText)),
				new ValueTuple<int, Type>(10, typeof(UUIText)),
				new ValueTuple<int, Type>(11, typeof(UUIText)),
				new ValueTuple<int, Type>(12, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(13, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(12, new Action(this.OnClickRestartBtn)),
				new ValueTuple<int, Delegate>(13, new Action(this.OnClickGoOnGameBtn))
			};
		}

		// Token: 0x06040BC3 RID: 265155 RVA: 0x01099612 File Offset: 0x01097812
		protected override void OnStart()
		{
			this.RhythmItemLayout = new GenericLayout<RhythmShipSettlementItem, ValueTuple<int, int>>(base.GetGridLayout(7), () => new RhythmShipSettlementItem(), null, false, true);
			this.RefreshView();
		}

		// Token: 0x06040BC4 RID: 265156 RVA: 0x01099650 File Offset: 0x01097850
		private void RefreshView()
		{
			IRhythmShipSettlementViewData rhythmShipSettlementViewData = this.OpenParam as IRhythmShipSettlementViewData;
			RhythmSubLevel? rhythmShipSubLevelById = ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipSubLevelById(rhythmShipSettlementViewData.SubLevelId);
			if (rhythmShipSubLevelById == null)
			{
				return;
			}
			this.SubLevelId = rhythmShipSettlementViewData.SubLevelId;
			RhythmShipLevel? rhythmShipLevelById = ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipLevelById(rhythmShipSubLevelById.Value.LevelId);
			if (rhythmShipLevelById == null)
			{
				return;
			}
			this.LevelId = rhythmShipSubLevelById.Value.LevelId;
			this.PlanetId = rhythmShipLevelById.Value.Planet;
			this.PlanetType = (ERhythmShipPlanetType)ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipPlanetById(rhythmShipLevelById.Value.Planet).Value.Type;
			base.SetTextureByPath(rhythmShipLevelById.Value.DesTexture, base.GetTexture(0), null, null);
			RhythmShipRank rank = rhythmShipSettlementViewData.Payload.Rank;
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(RhythmShipDefine.rhythmShipLevelRatingBgTexture[(int)rank]);
			base.SetTextureByPath(resourcePath, base.GetTexture(4), null, null);
			string resourcePath2 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(RhythmShipDefine.rhythmShipLevelRatingSettlementTexture[(int)rank]);
			base.SetTextureByPath(resourcePath2, base.GetTexture(5), null, null);
			base.GetItem(6).SetUIActive(rank >= RhythmShipRank.S);
			base.GetText(1).SetText(rhythmShipSettlementViewData.Payload.Score.ToString(), true);
			base.GetText(9).SetText((rhythmShipSettlementViewData.Payload.Completion / 100).ToString() + "%", true);
			base.GetText(10).SetText(rhythmShipSettlementViewData.Payload.MaxCombo.ToString(), true);
			Dictionary<int, RhythmSubLevelPb> subLevelInfoMapBySubLevelId = ModelBase<RhythmShipModel>.Instance.GetSubLevelInfoMapBySubLevelId(rhythmShipSettlementViewData.SubLevelId);
			RhythmSubLevelPb rhythmSubLevelPb = null;
			if (subLevelInfoMapBySubLevelId != null)
			{
				subLevelInfoMapBySubLevelId.TryGetValue(rhythmShipSettlementViewData.SubLevelId, out rhythmSubLevelPb);
			}
			int? num = (rhythmSubLevelPb != null) ? new int?(rhythmSubLevelPb.BestScore) : null;
			if (num != null && num.Value != 0)
			{
				base.GetText(11).SetText(num.Value.ToString(), true);
			}
			else
			{
				base.GetText(11).SetText("----", true);
			}
			base.GetItem(2).SetUIActive(rhythmShipSettlementViewData.Payload.Score >= num.GetValueOrDefault());
			List<ValueTuple<int, int>> list = new List<ValueTuple<int, int>>();
			foreach (KeyValuePair<ERhythmShipSettlementType, int> keyValuePair in rhythmShipSettlementViewData.SettlementItemMap)
			{
				list.Add(new ValueTuple<int, int>((int)keyValuePair.Key, keyValuePair.Value));
			}
			GenericLayout<RhythmShipSettlementItem, ValueTuple<int, int>> rhythmItemLayout = this.RhythmItemLayout;
			if (rhythmItemLayout == null)
			{
				return;
			}
			rhythmItemLayout.RefreshByData(list, null, false);
		}

		// Token: 0x06040BC5 RID: 265157 RVA: 0x01099954 File Offset: 0x01097B54
		private void OnClickRestartBtn()
		{
			ControllerBase<InstanceDungeonEntranceController>.Instance.RestartInstanceDungeon().Forget<bool>();
		}

		// Token: 0x06040BC6 RID: 265158 RVA: 0x01099968 File Offset: 0x01097B68
		private void OnClickGoOnGameBtn()
		{
			RhythmShipChoseLevelViewData param = new RhythmShipChoseLevelViewData
			{
				OpenShowType = this.PlanetType,
				PlanetId = new int?(this.PlanetId),
				LevelId = new int?(this.LevelId),
				SubLevelId = new int?(this.SubLevelId)
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RhythmShipChoseLevelView, param, null);
			base.CloseMe(null);
		}

		// Token: 0x040244C0 RID: 148672
		[Nullable(new byte[]
		{
			2,
			1,
			0
		})]
		private GenericLayout<RhythmShipSettlementItem, ValueTuple<int, int>> RhythmItemLayout;

		// Token: 0x040244C1 RID: 148673
		private ERhythmShipPlanetType PlanetType = ERhythmShipPlanetType.Normal;

		// Token: 0x040244C2 RID: 148674
		private int PlanetId;

		// Token: 0x040244C3 RID: 148675
		private int LevelId;

		// Token: 0x040244C4 RID: 148676
		private int SubLevelId;
	}
}
