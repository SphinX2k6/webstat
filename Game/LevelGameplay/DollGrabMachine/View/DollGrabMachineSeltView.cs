using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.DollGrabMachine.View
{
	// Token: 0x02006F0E RID: 28430
	[NullableContext(2)]
	[Nullable(0)]
	public class DollGrabMachineSeltView : UiViewBase
	{
		// Token: 0x06044DE8 RID: 282088 RVA: 0x011EBD76 File Offset: 0x011E9F76
		[NullableContext(1)]
		public DollGrabMachineSeltView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06044DE9 RID: 282089 RVA: 0x011EBD80 File Offset: 0x011E9F80
		protected unsafe override void OnRegisterComponent()
		{
			int num = 15;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnLeftButtonClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnRightButtonClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06044DEA RID: 282090 RVA: 0x011EC000 File Offset: 0x011EA200
		protected override UniTask OnBeforeStartAsync()
		{
			DollGrabMachineSeltView.<OnBeforeStartAsync>d__16 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<DollGrabMachineSeltView.<OnBeforeStartAsync>d__16>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06044DEB RID: 282091 RVA: 0x011EC043 File Offset: 0x011EA243
		protected override void OnBeforeShow()
		{
			if (!ControllerBase<DollGrabMachineController>.Instance.IsEndlessMode)
			{
				this.RefreshNormalMode();
			}
			else
			{
				this.RefreshEndlessMode();
			}
			this.CloseByButton = false;
		}

		// Token: 0x06044DEC RID: 282092 RVA: 0x011EC066 File Offset: 0x011EA266
		protected override void OnBeforeHide()
		{
			if (!this.CloseByButton)
			{
				ControllerBase<DollGrabMachineController>.Instance.RestartDollGrabMachine();
			}
		}

		// Token: 0x06044DED RID: 282093 RVA: 0x011EC07C File Offset: 0x011EA27C
		private void RefreshNormalMode()
		{
			UUIItem pnlEndlessModel = this.PnlEndlessModel;
			if (pnlEndlessModel != null)
			{
				pnlEndlessModel.SetUIActive(false);
			}
			List<IGrabItemData> currentDropItemList = ControllerBase<DollGrabMachineController>.Instance.CurrentDropItemList;
			if (currentDropItemList == null || currentDropItemList.Count == 0)
			{
				UUIItem pnlEmptyReward = this.PnlEmptyReward;
				if (pnlEmptyReward != null)
				{
					pnlEmptyReward.SetUIActive(true);
				}
				UUIItem pnlComModel = this.PnlComModel;
				if (pnlComModel != null)
				{
					pnlComModel.SetUIActive(false);
				}
				UUIItem pnlReward = this.PnlReward;
				if (pnlReward != null)
				{
					pnlReward.SetUIActive(false);
				}
			}
			else
			{
				UUIItem pnlEmptyReward2 = this.PnlEmptyReward;
				if (pnlEmptyReward2 != null)
				{
					pnlEmptyReward2.SetUIActive(false);
				}
				UUIItem pnlComModel2 = this.PnlComModel;
				if (pnlComModel2 != null)
				{
					pnlComModel2.SetUIActive(true);
				}
				UUIItem pnlReward2 = this.PnlReward;
				if (pnlReward2 != null)
				{
					pnlReward2.SetUIActive(true);
				}
				GenericLayout<DollGrabSmallItemGrid, IGrabItemData> genericLayout = this.GenericLayout;
				if (genericLayout != null)
				{
					genericLayout.RefreshByData(currentDropItemList, null, false);
				}
			}
			int leaveDollCount = ControllerBase<DollGrabMachineController>.Instance.LeaveDollCount;
			if (leaveDollCount != 0)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(this.TxtTips, "PrefabTextItem_3391462024_Text", new <>z__ReadOnlySingleElementList<object>(leaveDollCount));
				return;
			}
			UUIItem btnConfirmR = this.BtnConfirmR;
			if (btnConfirmR == null)
			{
				return;
			}
			btnConfirmR.SetUIActive(false);
		}

		// Token: 0x06044DEE RID: 282094 RVA: 0x011EC174 File Offset: 0x011EA374
		private void RefreshEndlessMode()
		{
			UUIItem pnlEndlessModel = this.PnlEndlessModel;
			if (pnlEndlessModel != null)
			{
				pnlEndlessModel.SetUIActive(true);
			}
			UUIItem pnlEmptyReward = this.PnlEmptyReward;
			if (pnlEmptyReward != null)
			{
				pnlEmptyReward.SetUIActive(false);
			}
			UUIItem pnlComModel = this.PnlComModel;
			if (pnlComModel != null)
			{
				pnlComModel.SetUIActive(false);
			}
			UUIText txtTips = this.TxtTips;
			if (txtTips != null)
			{
				txtTips.SetUIActive(false);
			}
			IDollGrabInfiniteRewardData endlessRewardData = ControllerBase<DollGrabMachineController>.Instance.EndlessRewardData;
			if (endlessRewardData == null)
			{
				return;
			}
			UUIText txtGetValue = this.TxtGetValue;
			if (txtGetValue != null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
				defaultInterpolatedStringHandler.AppendFormatted<int>(endlessRewardData.CurrentScore);
				txtGetValue.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			}
			UUIText txtTotalValue = this.TxtTotalValue;
			if (txtTotalValue != null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
				defaultInterpolatedStringHandler.AppendFormatted<int>(endlessRewardData.CurrentAccumulatedScore);
				txtTotalValue.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			}
			UUISprite sprCheck = this.SprCheck;
			if (sprCheck != null)
			{
				sprCheck.SetUIActive(endlessRewardData.IsFinalReward);
			}
			UUIText txtDescri = this.TxtDescri02;
			if (txtDescri != null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
				defaultInterpolatedStringHandler.AppendFormatted<int>(endlessRewardData.TargetAccumulatedScore);
				txtDescri.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(this.TxtDescri02, "KClaw_Infinite_Requirement", new <>z__ReadOnlySingleElementList<object>((endlessRewardData != null) ? endlessRewardData.TargetAccumulatedScore : "0"));
			if (endlessRewardData.IsFirstGetReward)
			{
				UUIItem pnlRewardScroll = this.PnlRewardScroll;
				if (pnlRewardScroll != null)
				{
					pnlRewardScroll.SetUIActive(true);
				}
				List<IGrabItemData> list = new List<IGrabItemData>();
				Dictionary<int, int> dropPackagePreview = ConfigBase<RewardConfig>.Instance.GetDropPackagePreview(endlessRewardData.DropId);
				if (dropPackagePreview != null && dropPackagePreview.Count > 0)
				{
					foreach (KeyValuePair<int, int> keyValuePair in dropPackagePreview)
					{
						list.Add(new GrabItemData
						{
							ItemId = keyValuePair.Key,
							Count = keyValuePair.Value
						});
					}
				}
				GenericLayout<DollGrabSmallItemGrid, IGrabItemData> genericLayout = this.GenericLayout;
				if (genericLayout == null)
				{
					return;
				}
				genericLayout.RefreshByData(list, null, false);
				return;
			}
			else
			{
				UUIItem pnlRewardScroll2 = this.PnlRewardScroll;
				if (pnlRewardScroll2 == null)
				{
					return;
				}
				pnlRewardScroll2.SetUIActive(false);
				return;
			}
		}

		// Token: 0x06044DEF RID: 282095 RVA: 0x011EC374 File Offset: 0x011EA574
		[NullableContext(1)]
		private DollGrabSmallItemGrid CreateDollGrabSmallItem()
		{
			DollGrabSmallItemGrid dollGrabSmallItemGrid = new DollGrabSmallItemGrid();
			dollGrabSmallItemGrid.BindOnExtendToggleRelease(new Action<MediumItemGridExtendCallback>(this.OnExtendToggleRelease));
			dollGrabSmallItemGrid.BindOnCanExecuteChange((object _, bool _, EToggleState _) => false);
			return dollGrabSmallItemGrid;
		}

		// Token: 0x06044DF0 RID: 282096 RVA: 0x011EC3B4 File Offset: 0x011EA5B4
		[NullableContext(1)]
		private void OnExtendToggleRelease(MediumItemGridExtendCallback callbackParameter)
		{
			if (!callbackParameter.MediumItemGrid.IsHover)
			{
				return;
			}
			IGrabItemData grabItemData = callbackParameter.Data as IGrabItemData;
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(grabItemData.ItemId, true, null);
		}

		// Token: 0x06044DF1 RID: 282097 RVA: 0x011EC3ED File Offset: 0x011EA5ED
		private void OnLeftButtonClick()
		{
			this.CloseByButton = true;
			ControllerBase<DollGrabMachineController>.Instance.ExitDollGrabMachine();
		}

		// Token: 0x06044DF2 RID: 282098 RVA: 0x011EC400 File Offset: 0x011EA600
		private void OnRightButtonClick()
		{
			this.CloseByButton = true;
			if (ControllerBase<DollGrabMachineController>.Instance.IsEndlessMode)
			{
				IDollGrabInfiniteRewardData endlessRewardData = ControllerBase<DollGrabMachineController>.Instance.EndlessRewardData;
				if (endlessRewardData != null && endlessRewardData.IsFinalReward)
				{
					IDollGrabInfiniteRewardData endlessRewardData2 = ControllerBase<DollGrabMachineController>.Instance.EndlessRewardData;
					ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.DollGrabMachineEndlessRestartConfirm);
					confirmBoxDataNew.SetTextArgs(new string[]
					{
						((endlessRewardData2 != null) ? endlessRewardData2.CurrentAccumulatedScore.ToString() : null) ?? "0",
						((endlessRewardData2 != null) ? endlessRewardData2.TargetAccumulatedScore.ToString() : null) ?? "0"
					});
					confirmBoxDataNew.FunctionMap[2] = delegate()
					{
						base.CloseMe(null);
						ControllerBase<DollGrabMachineController>.Instance.RestartDollGrabMachine();
					};
					ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
					return;
				}
			}
			ControllerBase<DollGrabMachineController>.Instance.RestartDollGrabMachine();
		}

		// Token: 0x04026612 RID: 157202
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<DollGrabSmallItemGrid, IGrabItemData> GenericLayout;

		// Token: 0x04026613 RID: 157203
		private UUIItem PnlEmptyReward;

		// Token: 0x04026614 RID: 157204
		private UUIItem PnlEndlessModel;

		// Token: 0x04026615 RID: 157205
		private UUIItem PnlComModel;

		// Token: 0x04026616 RID: 157206
		private DollGrabMachineEndSuccessfulItem PnlEndSuccessful;

		// Token: 0x04026617 RID: 157207
		private UUIItem PnlRewardScroll;

		// Token: 0x04026618 RID: 157208
		private UUIItem BtnConfirmR;

		// Token: 0x04026619 RID: 157209
		private UUIText TxtGetValue;

		// Token: 0x0402661A RID: 157210
		private UUIText TxtTotalValue;

		// Token: 0x0402661B RID: 157211
		private UUISprite SprCheck;

		// Token: 0x0402661C RID: 157212
		private UUIText TxtDescri02;

		// Token: 0x0402661D RID: 157213
		private UUIText TxtTips;

		// Token: 0x0402661E RID: 157214
		private UUIItem PnlReward;

		// Token: 0x0402661F RID: 157215
		private bool CloseByButton;
	}
}
