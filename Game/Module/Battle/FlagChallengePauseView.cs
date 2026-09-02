using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.FlagChallenge;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Battle
{
	// Token: 0x02005F1F RID: 24351
	[NullableContext(1)]
	[Nullable(0)]
	public class FlagChallengePauseView : UiViewBase
	{
		// Token: 0x0603D29E RID: 250526 RVA: 0x00F8AB99 File Offset: 0x00F88D99
		public FlagChallengePauseView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603D29F RID: 250527 RVA: 0x00F8ABA4 File Offset: 0x00F88DA4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 10;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickClose));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603D2A0 RID: 250528 RVA: 0x00F8AD54 File Offset: 0x00F88F54
		protected override UniTask OnBeforeStartAsync()
		{
			FlagChallengePauseView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<FlagChallengePauseView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603D2A1 RID: 250529 RVA: 0x00F8AD98 File Offset: 0x00F88F98
		protected override void OnStart()
		{
			base.GetButton(1).RootUIComp.Get().SetUIActive(false);
			this.Layout = new GenericLayout<FlagChallengePauseInfoItem, FlagChallengePauseInfo>(base.GetHorizontalLayout(2), new Func<FlagChallengePauseInfoItem>(this.CreateItem), base.GetItem(3).GetOwner() as AUIBaseActor, false, true);
			FlagChallengeBattleModel instance = ModelBase<FlagChallengeBattleModel>.Instance;
			List<FlagChallengePauseInfo> list = new List<FlagChallengePauseInfo>();
			int levelId = instance.LevelId;
			FlagChallengeLevel? levelConfig = ConfigBase<FlagChallengeConfig>.Instance.GetLevelConfig(levelId);
			list.Add(new FlagChallengePauseInfo
			{
				IconPath = "/Game/Aki/UI/UIResources/UiActivity/Atlas/Activity26/TowerDefense/FightResult/SP_ResultDataIcon1.SP_ResultDataIcon1",
				TitleKey = "Morale_32_Pause_CurrentLevel",
				Content = ConfigMultiTextLang.GetLocalTextNew(levelConfig.Value.Name, null),
				ShowLine = true
			});
			int activityId = instance.ActivityId;
			FlagChallengeData flagChallengeData = ModelBase<FlagChallengeModel>.Instance.GetFlagChallengeData(activityId);
			FlagChallengeLevelData levelData = flagChallengeData.GetLevelData(levelId);
			int num = 0;
			int num2 = 0;
			foreach (FlagChallengeStrongholdData flagChallengeStrongholdData in flagChallengeData.GetLevelStrongholdDataList(levelData.Id))
			{
				if (flagChallengeStrongholdData.GetStrongholdType() == EFlagChallengeStrongholdType.Boss)
				{
					num++;
					if (flagChallengeStrongholdData.IsPass)
					{
						num2++;
					}
				}
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(num2);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(num);
			string content = defaultInterpolatedStringHandler.ToStringAndClear();
			list.Add(new FlagChallengePauseInfo
			{
				IconPath = "/Game/Aki/UI/UIResources/UiActivity/Atlas/Activity26/TowerDefense/FightResult/SP_ResultDataIcon2.SP_ResultDataIcon2",
				TitleKey = "Morale_32_Pause_CurrenBossProgress",
				Content = content,
				ShowLine = false
			});
			this.Layout.RefreshByData(list, null, false);
		}

		// Token: 0x0603D2A2 RID: 250530 RVA: 0x00F8AF48 File Offset: 0x00F89148
		private void OnClickClose()
		{
			base.CloseMe(null);
		}

		// Token: 0x0603D2A3 RID: 250531 RVA: 0x00F8AF54 File Offset: 0x00F89154
		private void OnClickLevel()
		{
			int activityId = ModelBase<FlagChallengeBattleModel>.Instance.ActivityId;
			int levelId = ModelBase<FlagChallengeBattleModel>.Instance.LevelId;
			int areaId = ModelBase<FlagChallengeBattleModel>.Instance.AreaId;
			FlagChallengeData flagChallengeData = ModelBase<FlagChallengeModel>.Instance.GetFlagChallengeData(activityId);
			int levelRecommendStrongholdId = ModelBase<FlagChallengeModel>.Instance.GetLevelRecommendStrongholdId(activityId, levelId, new int[]
			{
				areaId
			});
			FlagChallengeStrongholdData strongholdData = flagChallengeData.GetStrongholdData(levelRecommendStrongholdId);
			ControllerBase<FlagChallengeController>.Instance.OpenFlagChallengeAreaDetailView(activityId, levelId, strongholdData.StrongholdConfig.AreaId, new int?(levelRecommendStrongholdId));
		}

		// Token: 0x0603D2A4 RID: 250532 RVA: 0x00F8AFD0 File Offset: 0x00F891D0
		private void OnClickBuff()
		{
			ControllerBase<FlagChallengeController>.Instance.OpenFlagChallengeBuffView(ModelBase<FlagChallengeBattleModel>.Instance.ActivityId, null);
		}

		// Token: 0x0603D2A5 RID: 250533 RVA: 0x00F8AFFC File Offset: 0x00F891FC
		private void OnClickSaveAndLeave()
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.FlagChallengeBattleExitConfirm);
			confirmBoxDataNew.FunctionMap.Add(2, delegate
			{
				ControllerBase<FlagChallengeBattleController>.Instance.LeaveFlagChallengeInstance().Forget();
			});
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x0603D2A6 RID: 250534 RVA: 0x00F8B04B File Offset: 0x00F8924B
		private FlagChallengePauseInfoItem CreateItem()
		{
			return new FlagChallengePauseInfoItem();
		}

		// Token: 0x040224C9 RID: 140489
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		protected GenericLayout<FlagChallengePauseInfoItem, FlagChallengePauseInfo> Layout;

		// Token: 0x040224CA RID: 140490
		private FlagChallengePauseButton LevelBtn;

		// Token: 0x040224CB RID: 140491
		private FlagChallengePauseButton BuffBtn;

		// Token: 0x040224CC RID: 140492
		private FlagChallengePauseButton SaveAndLeaveBtn;

		// Token: 0x0200BF27 RID: 48935
		[NullableContext(0)]
		private enum EComponentType
		{
			// Token: 0x0403AD64 RID: 240996
			BackBtn,
			// Token: 0x0403AD65 RID: 240997
			SettingBtn,
			// Token: 0x0403AD66 RID: 240998
			LevelBaseInfoLayout,
			// Token: 0x0403AD67 RID: 240999
			BaseInfo,
			// Token: 0x0403AD68 RID: 241000
			NumTxt,
			// Token: 0x0403AD69 RID: 241001
			BuffDetailBtn,
			// Token: 0x0403AD6A RID: 241002
			LevelBtn,
			// Token: 0x0403AD6B RID: 241003
			BuffBtn,
			// Token: 0x0403AD6C RID: 241004
			SaveAndLeaveBtn,
			// Token: 0x0403AD6D RID: 241005
			PanelStar
		}
	}
}
