using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip.View
{
	// Token: 0x020064F3 RID: 25843
	[NullableContext(2)]
	[Nullable(0)]
	public class RhythmShipPauseView : UiViewBase
	{
		// Token: 0x06040B55 RID: 265045 RVA: 0x01097B88 File Offset: 0x01095D88
		[NullableContext(1)]
		public RhythmShipPauseView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06040B56 RID: 265046 RVA: 0x01097B98 File Offset: 0x01095D98
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(1, new Action(this.OnClickExitBtn)),
				new ValueTuple<int, Delegate>(2, new Action(this.OnClickReStartBtn)),
				new ValueTuple<int, Delegate>(5, new Action(this.OnClickSetBtn))
			};
		}

		// Token: 0x06040B57 RID: 265047 RVA: 0x01097C88 File Offset: 0x01095E88
		protected override UniTask OnBeforeStartAsync()
		{
			RhythmShipPauseView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RhythmShipPauseView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040B58 RID: 265048 RVA: 0x01097CCC File Offset: 0x01095ECC
		protected override void OnStart()
		{
			base.GetButton(5).RootUIComp.Get().SetUIActive(false);
			RhythmShipLevel? rhythmShipLevelById = ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipLevelById(ModelBase<RhythmShipModel>.Instance.RhythmShipLevelId);
			if (rhythmShipLevelById == null)
			{
				return;
			}
			this.PlanetType = (ERhythmShipPlanetType)ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipPlanetById(rhythmShipLevelById.Value.Planet).Value.Type;
			SongDetailPanel songPanel = this.SongPanel;
			if (songPanel != null)
			{
				songPanel.RefreshPanel();
			}
			RoleDetailPanel rolePanel = this.RolePanel;
			if (rolePanel == null)
			{
				return;
			}
			rolePanel.RefreshPanel();
		}

		// Token: 0x06040B59 RID: 265049 RVA: 0x01097D64 File Offset: 0x01095F64
		private void OnClickExitBtn()
		{
			ControllerBase<RhythmGameController>.Instance.OnStopRhythmGame(true);
			int rhythmShipLevelId = ModelBase<RhythmShipModel>.Instance.RhythmShipLevelId;
			RhythmShipLevel? rhythmShipLevel;
			int? planetId = (ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipLevelById(rhythmShipLevelId) != null) ? new int?(rhythmShipLevel.GetValueOrDefault().Planet) : null;
			RhythmShipChoseLevelViewData param = new RhythmShipChoseLevelViewData
			{
				OpenShowType = this.PlanetType,
				PlanetId = planetId,
				LevelId = new int?(rhythmShipLevelId),
				SubLevelId = new int?(ModelBase<RhythmShipModel>.Instance.RhythmShipSubLevelId)
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RhythmShipChoseLevelView, param, null);
		}

		// Token: 0x06040B5A RID: 265050 RVA: 0x01097E09 File Offset: 0x01096009
		private void OnClickReStartBtn()
		{
			ControllerBase<InstanceDungeonEntranceController>.Instance.RestartInstanceDungeon().Forget<bool>();
		}

		// Token: 0x06040B5B RID: 265051 RVA: 0x01097E1A File Offset: 0x0109601A
		private void OnClickSetBtn()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RhythmShipSetView, null, null);
		}

		// Token: 0x04024454 RID: 148564
		private PopupCaptionItem CaptionItem;

		// Token: 0x04024455 RID: 148565
		private SongDetailPanel SongPanel;

		// Token: 0x04024456 RID: 148566
		private RoleDetailPanel RolePanel;

		// Token: 0x04024457 RID: 148567
		private ERhythmShipPlanetType PlanetType = ERhythmShipPlanetType.Normal;
	}
}
