using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.KuroSimpleCombat.PB;
using CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Formation;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Battle
{
	// Token: 0x0200663A RID: 26170
	[NullableContext(2)]
	[Nullable(0)]
	public class PinballBattlePauseView : UiViewBase
	{
		// Token: 0x060415D7 RID: 267735 RVA: 0x010C3E06 File Offset: 0x010C2006
		[NullableContext(1)]
		public PinballBattlePauseView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x17009F79 RID: 40825
		// (get) Token: 0x060415D8 RID: 267736 RVA: 0x010C3E0F File Offset: 0x010C200F
		public new IPinballBattlePauseViewParam OpenParam
		{
			get
			{
				return this.OpenParam as IPinballBattlePauseViewParam;
			}
		}

		// Token: 0x060415D9 RID: 267737 RVA: 0x010C3E1C File Offset: 0x010C201C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 10;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.OnClickToggleRoleInfo));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action<EToggleState>(this.OnClickToggleLevelInfo));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060415DA RID: 267738 RVA: 0x010C3FF0 File Offset: 0x010C21F0
		protected override UniTask OnBeforeStartAsync()
		{
			PinballBattlePauseView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PinballBattlePauseView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060415DB RID: 267739 RVA: 0x010C4034 File Offset: 0x010C2234
		protected override void OnStart()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(1);
			if (extendToggle != null)
			{
				extendToggle.SetToggleState(EToggleState.ETT_Checked, true, false, false);
			}
			UUIExtendToggle extendToggle2 = base.GetExtendToggle(2);
			if (extendToggle2 != null)
			{
				extendToggle2.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			}
			UUIExtendToggle extendToggle3 = base.GetExtendToggle(6);
			if (extendToggle3 != null)
			{
				extendToggle3.SetToggleState(EToggleState.ETT_UnChecked, true, false, false);
			}
			PinballLevelConfig? pinballLevelConfigById = ConfigBase<PinballConfig>.Instance.GetPinballLevelConfigById(this.OpenParam.LevelId);
			bool flag = pinballLevelConfigById != null && pinballLevelConfigById.Value.TrailRoleLength > 0;
			UUIItem item = base.GetItem(9);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(!flag);
		}

		// Token: 0x060415DC RID: 267740 RVA: 0x010C40D4 File Offset: 0x010C22D4
		private void OnClickToggleRoleInfo(EToggleState state)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(2);
			if (extendToggle != null)
			{
				extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			}
			PinballBattleLevelInfoView levelInfoView = this.LevelInfoView;
			if (levelInfoView != null)
			{
				levelInfoView.Hide(null);
			}
			PinballBattleSubModel pinballBattleSubModel = ControllerBase<KuroSimpleCombatController>.Instance.CurSubModel as PinballBattleSubModel;
			List<int> list = new List<int>();
			if (((pinballBattleSubModel != null) ? pinballBattleSubModel.FormationData : null) != null)
			{
				foreach (PinballFormationRolePb pinballFormationRolePb in pinballBattleSubModel.FormationData)
				{
					list.Add(pinballFormationRolePb.RoleId);
				}
			}
			this.RoleInfoView.OpenParam = new PinballBattleRoleInfoViewParam
			{
				RoleList = list
			};
			PinballBattleRoleInfoView roleInfoView = this.RoleInfoView;
			if (roleInfoView != null)
			{
				roleInfoView.Show(null);
			}
			base.PlayOrReplaySequence("Switch", false, null);
			PopupCaptionItem captionItem = this.CaptionItem;
			if (captionItem == null)
			{
				return;
			}
			captionItem.SetTitleLocalText("Pinaball_inside_CharacterInformation");
		}

		// Token: 0x060415DD RID: 267741 RVA: 0x010C41D0 File Offset: 0x010C23D0
		private void OnClickToggleLevelInfo(EToggleState state)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(1);
			if (extendToggle != null)
			{
				extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			}
			PinballBattleRoleInfoView roleInfoView = this.RoleInfoView;
			if (roleInfoView != null)
			{
				roleInfoView.Hide(null);
			}
			PinballLevelConfig? pinballLevelConfigById = ConfigBase<PinballConfig>.Instance.GetPinballLevelConfigById(this.OpenParam.LevelId);
			if (pinballLevelConfigById == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Pinball;
				ELogAuthor author = ELogAuthor.CB;
				string message = "找不到关卡配置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("LevelId", this.OpenParam.LevelId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			PinballBattleSubModel pinballBattleSubModel = ControllerBase<KuroSimpleCombatController>.Instance.CurSubModel as PinballBattleSubModel;
			this.LevelInfoView.OpenParam = new PinballBattleLevelInfoViewParam
			{
				LevelId = this.OpenParam.LevelId,
				LevelType = (EPinballLevelShowType)pinballLevelConfigById.Value.Type,
				Score = (int)pinballBattleSubModel.Score,
				StarInfo = pinballBattleSubModel.StarInfo
			};
			PinballBattleLevelInfoView levelInfoView = this.LevelInfoView;
			if (levelInfoView != null)
			{
				levelInfoView.Show(null);
			}
			base.PlayOrReplaySequence("Switch", false, null);
			PopupCaptionItem captionItem = this.CaptionItem;
			if (captionItem == null)
			{
				return;
			}
			captionItem.SetTitleLocalText("Pinaball_inside_LevelInformation");
		}

		// Token: 0x060415DE RID: 267742 RVA: 0x010C42FC File Offset: 0x010C24FC
		private void OnClickExitButton()
		{
			PinballLevelConfig? pinballLevelConfig;
			EConfirmBoxConfigId configId;
			if (((ConfigBase<PinballConfig>.Instance.GetPinballLevelConfigById(this.OpenParam.LevelId) != null) ? new int?(pinballLevelConfig.GetValueOrDefault().Type) : null).GetValueOrDefault() == 2)
			{
				configId = EConfirmBoxConfigId.PinballBattleRestartCowConfirm;
			}
			else
			{
				configId = EConfirmBoxConfigId.PinballBattleRestartConfirm;
			}
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(configId);
			confirmBoxDataNew.FunctionMap[2] = new Action(this.LeaveBattle);
			ControllerBase<PinballController>.Instance.OpenPinballSmallConfirmBoxView(confirmBoxDataNew);
		}

		// Token: 0x060415DF RID: 267743 RVA: 0x010C438C File Offset: 0x010C258C
		private void LeaveBattle()
		{
			(ControllerBase<KuroSimpleCombatController>.Instance.CurSubController as PinballBattleSubController).RequestQuit();
			base.CloseMe(null);
		}

		// Token: 0x060415E0 RID: 267744 RVA: 0x010C43A9 File Offset: 0x010C25A9
		private void OnClickContinueButton()
		{
			base.CloseMe(null);
		}

		// Token: 0x060415E1 RID: 267745 RVA: 0x010C43B4 File Offset: 0x010C25B4
		private void OnClickRestartButton()
		{
			PinballBattleSubController pinballBattleSubController = ControllerBase<KuroSimpleCombatController>.Instance.CurSubController as PinballBattleSubController;
			UUIExtendToggle extendToggle = base.GetExtendToggle(6);
			if (extendToggle != null && extendToggle.GetToggleState() == EToggleState.ETT_Checked)
			{
				PinballFormationViewData param = new PinballFormationViewData
				{
					LevelId = this.OpenParam.LevelId,
					IsRestart = new bool?(true),
					IfReturnToPinballMainView = new bool?(true)
				};
				Singleton<UiManager>.Instance.OpenView(EUiViewName.PinballFormationView, param, null);
				pinballBattleSubController.ClearGame(true);
			}
			else
			{
				pinballBattleSubController.Restart(null).Forget();
			}
			base.CloseMe(null);
		}

		// Token: 0x040248E4 RID: 149732
		private PopupCaptionItem CaptionItem;

		// Token: 0x040248E5 RID: 149733
		private PinballBattleRoleInfoView RoleInfoView;

		// Token: 0x040248E6 RID: 149734
		private PinballBattleLevelInfoView LevelInfoView;

		// Token: 0x040248E7 RID: 149735
		private ButtonItem ExitButton;

		// Token: 0x040248E8 RID: 149736
		private ButtonItem ContinueButton;

		// Token: 0x040248E9 RID: 149737
		private ButtonItem RestartButton;

		// Token: 0x0200C65E RID: 50782
		[NullableContext(0)]
		private enum EComponent
		{
			// Token: 0x0403D110 RID: 250128
			Caption,
			// Token: 0x0403D111 RID: 250129
			ToggleRoleInfo,
			// Token: 0x0403D112 RID: 250130
			ToggleLevelInfo,
			// Token: 0x0403D113 RID: 250131
			BtnExit,
			// Token: 0x0403D114 RID: 250132
			BtnContinue,
			// Token: 0x0403D115 RID: 250133
			BtnRestart,
			// Token: 0x0403D116 RID: 250134
			ToggleFormation,
			// Token: 0x0403D117 RID: 250135
			PnlRoleInfo,
			// Token: 0x0403D118 RID: 250136
			PnlLevelInfo,
			// Token: 0x0403D119 RID: 250137
			FormationItem
		}
	}
}
