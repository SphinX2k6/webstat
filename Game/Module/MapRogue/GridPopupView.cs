using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x02005998 RID: 22936
	[NullableContext(1)]
	[Nullable(0)]
	public class GridPopupView : UiPanelBase
	{
		// Token: 0x0603A118 RID: 237848 RVA: 0x00EB2457 File Offset: 0x00EB0657
		public GridPopupView(GridPopupViewModelBase vm)
		{
			this.Vm = vm;
		}

		// Token: 0x0603A119 RID: 237849 RVA: 0x00EB2474 File Offset: 0x00EB0674
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUISprite)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(4, new Action(this.OnClickedBtnDetail)),
				new ValueTuple<int, Delegate>(8, new Action(this.OnClickedMask))
			};
		}

		// Token: 0x0603A11A RID: 237850 RVA: 0x00EB2590 File Offset: 0x00EB0790
		protected override UniTask OnBeforeStartAsync()
		{
			GridPopupView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<GridPopupView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603A11B RID: 237851 RVA: 0x00EB25D3 File Offset: 0x00EB07D3
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.RogueMapEventDetailOpenOrClose, true);
		}

		// Token: 0x0603A11C RID: 237852 RVA: 0x00EB25F7 File Offset: 0x00EB07F7
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.RogueMapEventDetailOpenOrClose, false);
		}

		// Token: 0x0603A11D RID: 237853 RVA: 0x00EB260C File Offset: 0x00EB080C
		protected override void OnBeforeShow()
		{
			this.Refresh();
			base.GetButton(8).RootUIComp.Get().SetUIActive(true);
		}

		// Token: 0x0603A11E RID: 237854 RVA: 0x00EB263C File Offset: 0x00EB083C
		protected override UniTask OnShowAsyncImplementImplement()
		{
			GridPopupView.<OnShowAsyncImplementImplement>d__12 <OnShowAsyncImplementImplement>d__;
			<OnShowAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnShowAsyncImplementImplement>d__.<>4__this = this;
			<OnShowAsyncImplementImplement>d__.<>1__state = -1;
			<OnShowAsyncImplementImplement>d__.<>t__builder.Start<GridPopupView.<OnShowAsyncImplementImplement>d__12>(ref <OnShowAsyncImplementImplement>d__);
			return <OnShowAsyncImplementImplement>d__.<>t__builder.Task;
		}

		// Token: 0x0603A11F RID: 237855 RVA: 0x00EB2680 File Offset: 0x00EB0880
		protected override UniTask OnHideAsyncImplementImplement()
		{
			GridPopupView.<OnHideAsyncImplementImplement>d__13 <OnHideAsyncImplementImplement>d__;
			<OnHideAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnHideAsyncImplementImplement>d__.<>4__this = this;
			<OnHideAsyncImplementImplement>d__.<>1__state = -1;
			<OnHideAsyncImplementImplement>d__.<>t__builder.Start<GridPopupView.<OnHideAsyncImplementImplement>d__13>(ref <OnHideAsyncImplementImplement>d__);
			return <OnHideAsyncImplementImplement>d__.<>t__builder.Task;
		}

		// Token: 0x0603A120 RID: 237856 RVA: 0x00EB26C3 File Offset: 0x00EB08C3
		public void Refresh()
		{
			this.OnRefreshCommon();
			this.OnRefreshComponent();
		}

		// Token: 0x0603A121 RID: 237857 RVA: 0x00EB26D4 File Offset: 0x00EB08D4
		protected void OnRefreshCommon()
		{
			UUISprite sprite = base.GetSprite(1);
			UUIText text = base.GetText(2);
			UUIText text2 = base.GetText(3);
			UUIButtonComponent button = base.GetButton(4);
			RogueResGridEvent? gridEventConfigById = ConfigBase<MapRogueConfig>.Instance.GetGridEventConfigById(this.Vm.GridData.GridEventId);
			if (gridEventConfigById == null)
			{
				return;
			}
			if (!StringUtils.IsEmpty(gridEventConfigById.Value.Icon))
			{
				this.SetSpriteByPath(gridEventConfigById.Value.Icon, sprite, false, null, null);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, gridEventConfigById.Value.Title, Array.Empty<object>());
			this.Description.SetDescriptionByTextId(gridEventConfigById.Value.Desc, Array.Empty<string>());
			string subTxtInfo = this.Vm.GetSubTxtInfo();
			if (subTxtInfo != null)
			{
				text2.SetText(subTxtInfo, true);
			}
			text2.SetUIActive(!StringUtils.IsEmpty(subTxtInfo));
			button.RootUIComp.Get().SetUIActive(this.Vm.HasBtnDetail);
			bool flag = this.Vm.EventAvailable();
			this.ConditionBar.SetUiActive(!flag);
			if (!flag)
			{
				this.ConditionBar.SetButtonVisible(false);
				EMovePathType moveState = this.Vm.GameInfo.MoveState;
				if (moveState == EMovePathType.CannotAchieve)
				{
					this.ConditionBar.SetTextByTextId("RogueRes_Block_UnableMove", Array.Empty<string>());
					return;
				}
				if (moveState == EMovePathType.EventInterrupt)
				{
					this.ConditionBar.SetTextByTextId("RogueRes_Block_UnableMove_Event", Array.Empty<string>());
					return;
				}
				CondInfo conditionInfo = this.Vm.GridData.ConditionInfo;
				if (conditionInfo == null)
				{
					return;
				}
				PopupComponentConditionBar conditionBar = this.ConditionBar;
				string condText = gridEventConfigById.Value.CondText;
				string[] array = new string[2];
				int num = 0;
				int num2 = conditionInfo.Current;
				array[num] = num2.ToString();
				array[1] = conditionInfo.Target.ToString();
				conditionBar.SetTextByTextId(condText, array);
			}
		}

		// Token: 0x0603A122 RID: 237858 RVA: 0x00EB28C2 File Offset: 0x00EB0AC2
		private void OnClickedBtnDetail()
		{
			this.Vm.GetBtnDetailFunc();
		}

		// Token: 0x0603A123 RID: 237859 RVA: 0x00EB28CF File Offset: 0x00EB0ACF
		private void OnClickedClose()
		{
			this.Vm.OnClickedClose();
		}

		// Token: 0x0603A124 RID: 237860 RVA: 0x00EB28DC File Offset: 0x00EB0ADC
		private void OnClickedMask()
		{
			if (this.Vm.IsEnd)
			{
				return;
			}
			if (this.Vm.EventAvailable())
			{
				MapRogueGameInfo gameInfo = this.Vm.GameInfo;
				TsCharacterController characterController = Global.CharacterController;
				ULGUICanvasScaler canvasScaler = Singleton<UiLayer>.Instance.UiRootItem.GetCanvasScaler();
				this.TempVector2D.Reset();
				if (characterController != null)
				{
					Vector2D inputPosition = characterController.GetInputPosition(0);
					if (inputPosition != null)
					{
						this.TempVector2D.AdditionEqual(inputPosition);
						ULGUICanvasScaler ulguicanvasScaler = canvasScaler;
						FVector2D fvector2D = this.TempVector2D.ToUeVector2D(false);
						FVector2D fvector2D2 = ulguicanvasScaler.ConvertPositionFromViewportToLGUICanvas(fvector2D);
						if (gameInfo.IsPosInGridRange((int)fvector2D2.X, (int)fvector2D2.Y, gameInfo.CurSelectedIndex))
						{
							this.Vm.MoveButtonFunction(0);
							return;
						}
					}
				}
			}
			this.Vm.OnClickedClose();
		}

		// Token: 0x0603A125 RID: 237861 RVA: 0x00EB299D File Offset: 0x00EB0B9D
		protected void OnRefreshComponent()
		{
			this.Vm.RefreshTop();
			this.Vm.RefreshBottom();
			this.Vm.RefreshFunctional();
		}

		// Token: 0x0603A126 RID: 237862 RVA: 0x00EB29C0 File Offset: 0x00EB0BC0
		public UUIItem GetPanelTop()
		{
			return base.GetItem(5);
		}

		// Token: 0x0603A127 RID: 237863 RVA: 0x00EB29C9 File Offset: 0x00EB0BC9
		public UUIItem GetPanelBottom()
		{
			return base.GetItem(6);
		}

		// Token: 0x0603A128 RID: 237864 RVA: 0x00EB29D2 File Offset: 0x00EB0BD2
		public UUIItem GetPanelFunctional()
		{
			return base.GetItem(7);
		}

		// Token: 0x0603A129 RID: 237865 RVA: 0x00EB29DC File Offset: 0x00EB0BDC
		[NullableContext(2)]
		private UniTask InitComponentDescription(UUIItem parentItem = null)
		{
			GridPopupView.<InitComponentDescription>d__23 <InitComponentDescription>d__;
			<InitComponentDescription>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitComponentDescription>d__.<>4__this = this;
			<InitComponentDescription>d__.parentItem = parentItem;
			<InitComponentDescription>d__.<>1__state = -1;
			<InitComponentDescription>d__.<>t__builder.Start<GridPopupView.<InitComponentDescription>d__23>(ref <InitComponentDescription>d__);
			return <InitComponentDescription>d__.<>t__builder.Task;
		}

		// Token: 0x0603A12A RID: 237866 RVA: 0x00EB2A28 File Offset: 0x00EB0C28
		[NullableContext(2)]
		private UniTask InitConditionBar(UUIItem parentItem = null)
		{
			GridPopupView.<InitConditionBar>d__24 <InitConditionBar>d__;
			<InitConditionBar>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitConditionBar>d__.<>4__this = this;
			<InitConditionBar>d__.parentItem = parentItem;
			<InitConditionBar>d__.<>1__state = -1;
			<InitConditionBar>d__.<>t__builder.Start<GridPopupView.<InitConditionBar>d__24>(ref <InitConditionBar>d__);
			return <InitConditionBar>d__.<>t__builder.Task;
		}

		// Token: 0x0603A12B RID: 237867 RVA: 0x00EB2A74 File Offset: 0x00EB0C74
		[NullableContext(2)]
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public UniTask<PopupComponentFunctionButton> InitComponentButton(UUIItem parentItem = null)
		{
			GridPopupView.<InitComponentButton>d__25 <InitComponentButton>d__;
			<InitComponentButton>d__.<>t__builder = AsyncUniTaskMethodBuilder<PopupComponentFunctionButton>.Create();
			<InitComponentButton>d__.<>4__this = this;
			<InitComponentButton>d__.parentItem = parentItem;
			<InitComponentButton>d__.<>1__state = -1;
			<InitComponentButton>d__.<>t__builder.Start<GridPopupView.<InitComponentButton>d__25>(ref <InitComponentButton>d__);
			return <InitComponentButton>d__.<>t__builder.Task;
		}

		// Token: 0x0603A12C RID: 237868 RVA: 0x00EB2AC0 File Offset: 0x00EB0CC0
		[NullableContext(2)]
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public UniTask<PopupComponentRecommendTip> InitRecommendTip(UUIItem parentItem = null)
		{
			GridPopupView.<InitRecommendTip>d__26 <InitRecommendTip>d__;
			<InitRecommendTip>d__.<>t__builder = AsyncUniTaskMethodBuilder<PopupComponentRecommendTip>.Create();
			<InitRecommendTip>d__.<>4__this = this;
			<InitRecommendTip>d__.parentItem = parentItem;
			<InitRecommendTip>d__.<>1__state = -1;
			<InitRecommendTip>d__.<>t__builder.Start<GridPopupView.<InitRecommendTip>d__26>(ref <InitRecommendTip>d__);
			return <InitRecommendTip>d__.<>t__builder.Task;
		}

		// Token: 0x0603A12D RID: 237869 RVA: 0x00EB2B0C File Offset: 0x00EB0D0C
		[NullableContext(2)]
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public UniTask<PopupComponentInfoList> InitInfoList(UUIItem parentItem = null)
		{
			GridPopupView.<InitInfoList>d__27 <InitInfoList>d__;
			<InitInfoList>d__.<>t__builder = AsyncUniTaskMethodBuilder<PopupComponentInfoList>.Create();
			<InitInfoList>d__.<>4__this = this;
			<InitInfoList>d__.parentItem = parentItem;
			<InitInfoList>d__.<>1__state = -1;
			<InitInfoList>d__.<>t__builder.Start<GridPopupView.<InitInfoList>d__27>(ref <InitInfoList>d__);
			return <InitInfoList>d__.<>t__builder.Task;
		}

		// Token: 0x0603A12E RID: 237870 RVA: 0x00EB2B58 File Offset: 0x00EB0D58
		[NullableContext(2)]
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public UniTask<PopupComponentEventCost> InitEventCost(UUIItem parentItem = null)
		{
			GridPopupView.<InitEventCost>d__28 <InitEventCost>d__;
			<InitEventCost>d__.<>t__builder = AsyncUniTaskMethodBuilder<PopupComponentEventCost>.Create();
			<InitEventCost>d__.<>4__this = this;
			<InitEventCost>d__.parentItem = parentItem;
			<InitEventCost>d__.<>1__state = -1;
			<InitEventCost>d__.<>t__builder.Start<GridPopupView.<InitEventCost>d__28>(ref <InitEventCost>d__);
			return <InitEventCost>d__.<>t__builder.Task;
		}

		// Token: 0x0603A12F RID: 237871 RVA: 0x00EB2BA4 File Offset: 0x00EB0DA4
		[NullableContext(2)]
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public UniTask<PopupComponentRewardList> InitRewardList(UUIItem parentItem = null)
		{
			GridPopupView.<InitRewardList>d__29 <InitRewardList>d__;
			<InitRewardList>d__.<>t__builder = AsyncUniTaskMethodBuilder<PopupComponentRewardList>.Create();
			<InitRewardList>d__.<>4__this = this;
			<InitRewardList>d__.parentItem = parentItem;
			<InitRewardList>d__.<>1__state = -1;
			<InitRewardList>d__.<>t__builder.Start<GridPopupView.<InitRewardList>d__29>(ref <InitRewardList>d__);
			return <InitRewardList>d__.<>t__builder.Task;
		}

		// Token: 0x0603A130 RID: 237872 RVA: 0x00EB2BEF File Offset: 0x00EB0DEF
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams.Length == 0)
			{
				return null;
			}
			return this.Vm.GetGuideUiItemAndUiItemForShowEx(configParams);
		}

		// Token: 0x04020F0D RID: 134925
		[Nullable(2)]
		protected LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x04020F0E RID: 134926
		[Nullable(2)]
		protected PopupTypeRightItem UiBgItem;

		// Token: 0x04020F0F RID: 134927
		protected PopupComponentDescription Description;

		// Token: 0x04020F10 RID: 134928
		public PopupComponentConditionBar ConditionBar;

		// Token: 0x04020F11 RID: 134929
		private readonly Vector2D TempVector2D = Vector2D.Create();

		// Token: 0x04020F12 RID: 134930
		protected GridPopupViewModelBase Vm;
	}
}
