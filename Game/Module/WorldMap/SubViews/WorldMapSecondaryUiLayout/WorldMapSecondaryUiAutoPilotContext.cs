using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.AutoPilot;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.Map.View.BaseMap;
using CSharpScript.Game.Module.Teleport;
using CSharpScript.Game.Module.WorldMap.SubViews.AutoPilot;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.WorldMapSecondaryUiLayout
{
	// Token: 0x02004B5F RID: 19295
	[NullableContext(1)]
	[Nullable(0)]
	public class WorldMapSecondaryUiAutoPilotContext
	{
		// Token: 0x1700869D RID: 34461
		// (get) Token: 0x0603266C RID: 206444 RVA: 0x00C9C6F2 File Offset: 0x00C9A8F2
		// (set) Token: 0x0603266D RID: 206445 RVA: 0x00C9C6FA File Offset: 0x00C9A8FA
		public WorldMapSecondaryUiContext LayoutContext { get; private set; }

		// Token: 0x1700869E RID: 34462
		// (get) Token: 0x0603266E RID: 206446 RVA: 0x00C9C703 File Offset: 0x00C9A903
		// (set) Token: 0x0603266F RID: 206447 RVA: 0x00C9C70B File Offset: 0x00C9A90B
		[Nullable(2)]
		public Action<MarkItem> RefreshPanelCallback { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x06032670 RID: 206448 RVA: 0x00C9C714 File Offset: 0x00C9A914
		public WorldMapSecondaryUiAutoPilotContext(WorldMapSecondaryUiContext layoutContext)
		{
			this.LayoutContext = layoutContext;
		}

		// Token: 0x06032671 RID: 206449 RVA: 0x00C9C723 File Offset: 0x00C9A923
		public void SetUiParent(UUIItem uiParent)
		{
			this.UiParent = uiParent;
		}

		// Token: 0x06032672 RID: 206450 RVA: 0x00C9C72C File Offset: 0x00C9A92C
		public void SetDownStateBtnRoot(UUIItem downStateBtnRoot)
		{
			this.DownStateBtnRoot = downStateBtnRoot;
		}

		// Token: 0x06032673 RID: 206451 RVA: 0x00C9C735 File Offset: 0x00C9A935
		public void SetDownStateBtnRootActive(bool isActive)
		{
			UUIItem downStateBtnRoot = this.DownStateBtnRoot;
			if (downStateBtnRoot == null)
			{
				return;
			}
			downStateBtnRoot.SetUIActive(isActive);
		}

		// Token: 0x06032674 RID: 206452 RVA: 0x00C9C748 File Offset: 0x00C9A948
		public void SetAutoPilotNavBtnActive(bool isActive)
		{
			AutoPilotNavBtnView autoPilotNavBtnView = this.AutoPilotNavBtnView;
			if (autoPilotNavBtnView == null)
			{
				return;
			}
			UUIItem originalItem = autoPilotNavBtnView.GetOriginalItem();
			if (originalItem == null)
			{
				return;
			}
			originalItem.SetUIActive(isActive);
		}

		// Token: 0x06032675 RID: 206453 RVA: 0x00C9C765 File Offset: 0x00C9A965
		public void UpdateAutoPilotNavBtn(bool isAutoPilotTracked, bool isInteractive)
		{
			AutoPilotNavBtnView autoPilotNavBtnView = this.AutoPilotNavBtnView;
			if (autoPilotNavBtnView == null)
			{
				return;
			}
			autoPilotNavBtnView.RefreshUi(isAutoPilotTracked, isInteractive);
		}

		// Token: 0x06032676 RID: 206454 RVA: 0x00C9C77C File Offset: 0x00C9A97C
		public void RefreshAutoPilotTrackBtnGroup(bool isAutoPilotTrack)
		{
			AutoPilotTrackBtnGroup autoPilotTrackBtnGroup = this.AutoPilotTrackBtnGroup;
			if (autoPilotTrackBtnGroup != null)
			{
				UUIItem originalItem = autoPilotTrackBtnGroup.GetOriginalItem();
				if (originalItem != null)
				{
					originalItem.SetUIActive(isAutoPilotTrack);
				}
			}
			if (isAutoPilotTrack)
			{
				AutoPilotFindPathResult findPathResult = ModelBase<AutoPilotModel>.Instance.GetFindPathResult();
				this.SetBtnGoQuickEnable(ModelBase<TeleportModel>.Instance.AllowTeleportByUi && (findPathResult == null || !findPathResult.GetIsShowPlayerToTargetLine()));
			}
		}

		// Token: 0x06032677 RID: 206455 RVA: 0x00C9C7D8 File Offset: 0x00C9A9D8
		public void SetBtnGoQuickEnable(bool isEnable)
		{
			AutoPilotTrackBtnGroup autoPilotTrackBtnGroup = this.AutoPilotTrackBtnGroup;
			if (autoPilotTrackBtnGroup == null)
			{
				return;
			}
			autoPilotTrackBtnGroup.SetBtnGoQuickEnable(isEnable);
		}

		// Token: 0x06032678 RID: 206456 RVA: 0x00C9C7EB File Offset: 0x00C9A9EB
		public void SetCloseSecondaryUiFunction(Action func)
		{
			this.CloseSecondaryUiFunction = func;
		}

		// Token: 0x06032679 RID: 206457 RVA: 0x00C9C7F4 File Offset: 0x00C9A9F4
		[NullableContext(2)]
		public void SetMap(BaseMap map)
		{
			this.Map = map;
		}

		// Token: 0x0603267A RID: 206458 RVA: 0x00C9C800 File Offset: 0x00C9AA00
		public UniTask InitAutoPilotUi()
		{
			WorldMapSecondaryUiAutoPilotContext.<InitAutoPilotUi>d__24 <InitAutoPilotUi>d__;
			<InitAutoPilotUi>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitAutoPilotUi>d__.<>4__this = this;
			<InitAutoPilotUi>d__.<>1__state = -1;
			<InitAutoPilotUi>d__.<>t__builder.Start<WorldMapSecondaryUiAutoPilotContext.<InitAutoPilotUi>d__24>(ref <InitAutoPilotUi>d__);
			return <InitAutoPilotUi>d__.<>t__builder.Task;
		}

		// Token: 0x0603267B RID: 206459 RVA: 0x00C9C843 File Offset: 0x00C9AA43
		private void OnAutoPilotNavBtnClick()
		{
			this.OnHandleTrackAutoPilot(true).Forget();
		}

		// Token: 0x0603267C RID: 206460 RVA: 0x00C9C851 File Offset: 0x00C9AA51
		private void OnCancelAutoPilotTrackBtnClick()
		{
			this.OnHandleTrackAutoPilot(false).Forget();
		}

		// Token: 0x0603267D RID: 206461 RVA: 0x00C9C85F File Offset: 0x00C9AA5F
		private void OnQuickGoBtnClick()
		{
			if (ModelBase<AutoPilotModel>.Instance.HideQuickTransferConfirmBox)
			{
				this.HandleQuickGotoAutoPilot();
				return;
			}
			this.ShowAutoPilotQuickGoToTeleportConfirmBox(new Action(this.HandleQuickGotoAutoPilot));
		}

		// Token: 0x0603267E RID: 206462 RVA: 0x00C9C888 File Offset: 0x00C9AA88
		protected UniTask OnHandleTrackAutoPilot(bool isAutoPilotTrack)
		{
			WorldMapSecondaryUiAutoPilotContext.<OnHandleTrackAutoPilot>d__28 <OnHandleTrackAutoPilot>d__;
			<OnHandleTrackAutoPilot>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnHandleTrackAutoPilot>d__.<>4__this = this;
			<OnHandleTrackAutoPilot>d__.isAutoPilotTrack = isAutoPilotTrack;
			<OnHandleTrackAutoPilot>d__.<>1__state = -1;
			<OnHandleTrackAutoPilot>d__.<>t__builder.Start<WorldMapSecondaryUiAutoPilotContext.<OnHandleTrackAutoPilot>d__28>(ref <OnHandleTrackAutoPilot>d__);
			return <OnHandleTrackAutoPilot>d__.<>t__builder.Task;
		}

		// Token: 0x0603267F RID: 206463 RVA: 0x00C9C8D4 File Offset: 0x00C9AAD4
		private UniTask HandleTrackAndUiPerform(MarkItem markItem, bool isAutoPilotTrack)
		{
			WorldMapSecondaryUiAutoPilotContext.<HandleTrackAndUiPerform>d__29 <HandleTrackAndUiPerform>d__;
			<HandleTrackAndUiPerform>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<HandleTrackAndUiPerform>d__.<>4__this = this;
			<HandleTrackAndUiPerform>d__.markItem = markItem;
			<HandleTrackAndUiPerform>d__.isAutoPilotTrack = isAutoPilotTrack;
			<HandleTrackAndUiPerform>d__.<>1__state = -1;
			<HandleTrackAndUiPerform>d__.<>t__builder.Start<WorldMapSecondaryUiAutoPilotContext.<HandleTrackAndUiPerform>d__29>(ref <HandleTrackAndUiPerform>d__);
			return <HandleTrackAndUiPerform>d__.<>t__builder.Task;
		}

		// Token: 0x06032680 RID: 206464 RVA: 0x00C9C928 File Offset: 0x00C9AB28
		private void OnCreateMarkItem(DynamicMarkCreateInfo info)
		{
			if (info.MarkType != EMarkType.Custom)
			{
				return;
			}
			BaseMap map = this.Map;
			MarkItem markItem = (map != null) ? map.GetMarkItem(EMarkType.Custom, info.MarkId.Value) : null;
			if (markItem == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.AutoPilot;
				ELogAuthor author = ELogAuthor.CB;
				string message = "获取不到创建的自定义标记";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("MarkId", info.MarkId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			CustomMarkItem customMarkItem = markItem as CustomMarkItem;
			customMarkItem.IsCreated = true;
			this.HandleTrackAndUiPerform(customMarkItem, true).Forget();
		}

		// Token: 0x06032681 RID: 206465 RVA: 0x00C9C9B8 File Offset: 0x00C9ABB8
		protected void HandleQuickGotoAutoPilot()
		{
			AutoPilotFindPathResult findPathResult = ModelBase<AutoPilotModel>.Instance.GetFindPathResult();
			if (findPathResult == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.AutoPilot, ELogAuthor.CB, "快速前往寻路起点失败，寻路结果为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			WorldEntity worldEntity = (getCurrentEntity != null) ? getCurrentEntity.Entity : null;
			bool flag;
			if (worldEntity == null)
			{
				flag = false;
			}
			else
			{
				CharacterDriveVehicleComponent component = worldEntity.GetComponent<CharacterDriveVehicleComponent>();
				flag = ((component != null) ? new bool?(component.IsDriver) : null).GetValueOrDefault();
			}
			if (flag)
			{
				ControllerBase<TeleportController>.Instance.TeleportPlayerInVehicle(new ITeleportContextParam
				{
					ClientReason = "QuickGotoAutoPilot",
					TargetPosition = findPathResult.StartPoint.ToUeVector(false),
					TargetRotation = findPathResult.GetStartRotator(),
					TeleportMode = new ETeleportMode?(ETeleportMode.Loading)
				}).ContinueWith(delegate(bool _)
				{
					Action closeSecondaryUiFunction = this.CloseSecondaryUiFunction;
					if (closeSecondaryUiFunction == null)
					{
						return;
					}
					closeSecondaryUiFunction();
				}).Forget();
				return;
			}
			ControllerBase<TeleportController>.Instance.TeleportPlayer(new ITeleportContextParam
			{
				ClientReason = "QuickGotoAutoPilot",
				TargetPosition = findPathResult.StartPoint.ToUeVector(false),
				TargetRotation = findPathResult.GetStartRotator(),
				TeleportMode = new ETeleportMode?(ETeleportMode.Loading)
			}).ContinueWith(delegate(bool _)
			{
				Action closeSecondaryUiFunction = this.CloseSecondaryUiFunction;
				if (closeSecondaryUiFunction == null)
				{
					return;
				}
				closeSecondaryUiFunction();
			}).Forget();
		}

		// Token: 0x06032682 RID: 206466 RVA: 0x00C9CAF8 File Offset: 0x00C9ACF8
		private void ShowAutoPilotQuickGoToTeleportConfirmBox(Action callback)
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.AutoPilotQuickGoToTeleportConfirm);
			confirmBoxDataNew.HasToggle = true;
			confirmBoxDataNew.ToggleTextKey = "Text_FastTravelConfirmToggle_text";
			confirmBoxDataNew.SetToggleFunction(delegate(bool isSelectOn)
			{
				ModelBase<AutoPilotModel>.Instance.HideQuickTransferConfirmBox = isSelectOn;
			});
			Action value = delegate()
			{
				ModelBase<AutoPilotModel>.Instance.HideQuickTransferConfirmBox = false;
			};
			confirmBoxDataNew.FunctionMap[1] = value;
			confirmBoxDataNew.FunctionMap[2] = callback;
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x06032683 RID: 206467 RVA: 0x00C9CB8D File Offset: 0x00C9AD8D
		public void UpdateAutoPilotState()
		{
			WorldMapSecondaryUiLayoutHelper.UpdateAutoPilotState(this);
		}

		// Token: 0x06032684 RID: 206468 RVA: 0x00C9CB98 File Offset: 0x00C9AD98
		public bool IsNeedCustomMarkCreate()
		{
			MarkItem markItem = this.LayoutContext.MarkItem;
			return markItem.MarkType == EMarkType.Custom && !(markItem as CustomMarkItem).IsCreated;
		}

		// Token: 0x0401D6B5 RID: 120501
		[Nullable(2)]
		private UUIItem UiParent;

		// Token: 0x0401D6B6 RID: 120502
		[Nullable(2)]
		private UUIItem DownStateBtnRoot;

		// Token: 0x0401D6B7 RID: 120503
		[Nullable(2)]
		private AutoPilotNavBtnView AutoPilotNavBtnView;

		// Token: 0x0401D6B8 RID: 120504
		[Nullable(2)]
		private AutoPilotTrackBtnGroup AutoPilotTrackBtnGroup;

		// Token: 0x0401D6B9 RID: 120505
		[Nullable(2)]
		private Action CloseSecondaryUiFunction;

		// Token: 0x0401D6BA RID: 120506
		[Nullable(2)]
		private BaseMap Map;
	}
}
