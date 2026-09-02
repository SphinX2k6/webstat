using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip.View
{
	// Token: 0x02006500 RID: 25856
	[NullableContext(1)]
	[Nullable(0)]
	public class RhythmShipQuickSelectLevelView : UiViewBase
	{
		// Token: 0x06040B72 RID: 265074 RVA: 0x010983BC File Offset: 0x010965BC
		public RhythmShipQuickSelectLevelView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06040B73 RID: 265075 RVA: 0x010983D7 File Offset: 0x010965D7
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIMultiTemplateScrollViewComponent))
			};
		}

		// Token: 0x06040B74 RID: 265076 RVA: 0x01098410 File Offset: 0x01096610
		protected override UniTask OnBeforeStartAsync()
		{
			RhythmShipQuickSelectLevelView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RhythmShipQuickSelectLevelView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040B75 RID: 265077 RVA: 0x01098453 File Offset: 0x01096653
		protected override void OnStart()
		{
			IRhythmShipQuickSelectLevelViewData rhythmShipQuickSelectLevelViewData = this.OpenParam as IRhythmShipQuickSelectLevelViewData;
			this.CurrentShowType = ((rhythmShipQuickSelectLevelViewData != null) ? rhythmShipQuickSelectLevelViewData.OpenShowType : ERhythmShipPlanetType.Normal);
		}

		// Token: 0x06040B76 RID: 265078 RVA: 0x01098474 File Offset: 0x01096674
		private void InitScrollViewData()
		{
			foreach (int num in ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipPlanetIdListByType((int)this.CurrentShowType, ModelBase<RhythmShipModel>.Instance.ActivityId))
			{
				RhythmShipQuickSelectLevelData rhythmShipQuickSelectLevelData = new RhythmShipQuickSelectLevelData();
				RhythmShipPlanet? rhythmShipPlanet;
				string titleText = ((ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipPlanetById(num) != null) ? rhythmShipPlanet.GetValueOrDefault().Name : null) ?? "";
				rhythmShipQuickSelectLevelData.TitleText = titleText;
				RhythmShipQuickSelectLevelGirdItemTitleData item = new RhythmShipQuickSelectLevelGirdItemTitleData(rhythmShipQuickSelectLevelData);
				this.ScrollDataList.Add(item);
				List<int> rhythmShipLevelIdListByPlanet = ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipLevelIdListByPlanet(num);
				if (rhythmShipLevelIdListByPlanet != null)
				{
					foreach (int levelConfig in rhythmShipLevelIdListByPlanet)
					{
						RhythmShipQuickSelectLevelGirdItemTitleData.RhythmShipQuickSelectLevelGirdItemLevelData rhythmShipQuickSelectLevelGirdItemLevelData = new RhythmShipQuickSelectLevelGirdItemTitleData.RhythmShipQuickSelectLevelGirdItemLevelData(new RhythmShipQuickSelectLevelData
						{
							LevelConfig = levelConfig
						});
						rhythmShipQuickSelectLevelGirdItemLevelData.OnClickButtonCallBack = new Action<int>(this.OnClickLevelItemClick);
						this.ScrollDataList.Add(rhythmShipQuickSelectLevelGirdItemLevelData);
					}
				}
			}
		}

		// Token: 0x06040B77 RID: 265079 RVA: 0x010985AC File Offset: 0x010967AC
		private void OnClickLevelItemClick(int levelId)
		{
			if (!ModelBase<RhythmShipModel>.Instance.GetLevelIsUnlock(levelId))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId(ModelBase<RhythmShipModel>.Instance.GetLevelLockTips(levelId) ?? "RhythmShipLevelLockTips", Array.Empty<object>());
				return;
			}
			RhythmShipLevel? rhythmShipLevelById = ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipLevelById(levelId);
			if (rhythmShipLevelById == null)
			{
				return;
			}
			RhythmShipPlanet? rhythmShipPlanetById = ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipPlanetById(rhythmShipLevelById.Value.Planet);
			if (rhythmShipPlanetById == null)
			{
				return;
			}
			Singleton<EventSystem>.Instance.Emit<int, int, int>(EEventName.OnRhythmShipJumpLevel, rhythmShipPlanetById.Value.Type, rhythmShipPlanetById.Value.Id, levelId);
			base.CloseMe(null);
		}

		// Token: 0x0402446E RID: 148590
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x0402446F RID: 148591
		[Nullable(2)]
		private MultiTemplateScrollView PlanetMultiTemplateScrollView;

		// Token: 0x04024470 RID: 148592
		private readonly List<IMultiTemplateGridData> ScrollDataList = new List<IMultiTemplateGridData>();

		// Token: 0x04024471 RID: 148593
		private ERhythmShipPlanetType CurrentShowType = ERhythmShipPlanetType.Normal;
	}
}
