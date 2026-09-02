using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.ResManager;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001603 RID: 5635
[NullableContext(2)]
[Nullable(0)]
public class ActivityFunctionalTypeA : UiPanelBase
{
	// Token: 0x17000D68 RID: 3432
	// (get) Token: 0x06009EF6 RID: 40694 RVA: 0x00299148 File Offset: 0x00297348
	// (set) Token: 0x06009EF7 RID: 40695 RVA: 0x00299150 File Offset: 0x00297350
	public ActivityButtonItem FunctionButton { get; private set; }

	// Token: 0x17000D69 RID: 3433
	// (get) Token: 0x06009EF8 RID: 40696 RVA: 0x00299159 File Offset: 0x00297359
	// (set) Token: 0x06009EF9 RID: 40697 RVA: 0x00299161 File Offset: 0x00297361
	public ButtonSpriteItem CircleButton { get; private set; }

	// Token: 0x17000D6A RID: 3434
	// (get) Token: 0x06009EFA RID: 40698 RVA: 0x0029916A File Offset: 0x0029736A
	// (set) Token: 0x06009EFB RID: 40699 RVA: 0x00299172 File Offset: 0x00297372
	public FunctionalPanelConditionLock PanelLock { get; private set; }

	// Token: 0x17000D6B RID: 3435
	// (get) Token: 0x06009EFC RID: 40700 RVA: 0x0029917B File Offset: 0x0029737B
	// (set) Token: 0x06009EFD RID: 40701 RVA: 0x00299183 File Offset: 0x00297383
	public FunctionalPanelConditionActivate PanelActivate { get; private set; }

	// Token: 0x17000D6C RID: 3436
	// (get) Token: 0x06009EFE RID: 40702 RVA: 0x0029918C File Offset: 0x0029738C
	// (set) Token: 0x06009EFF RID: 40703 RVA: 0x00299194 File Offset: 0x00297394
	protected ActivityBaseData Data { get; set; }

	// Token: 0x06009F00 RID: 40704 RVA: 0x0029919D File Offset: 0x0029739D
	public ActivityFunctionalTypeA(ActivityBaseData data)
	{
		this.Data = data;
	}

	// Token: 0x06009F01 RID: 40705 RVA: 0x002991AC File Offset: 0x002973AC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 8;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
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
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06009F02 RID: 40706 RVA: 0x002992DC File Offset: 0x002974DC
	protected override UniTask OnBeforeStartAsync()
	{
		ActivityFunctionalTypeA.<OnBeforeStartAsync>d__23 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivityFunctionalTypeA.<OnBeforeStartAsync>d__23>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009F03 RID: 40707 RVA: 0x0029931F File Offset: 0x0029751F
	private void ExtraButtonFunction()
	{
		if (this.Data != null)
		{
			ModelBase<ActivityModel>.Instance.SendActivityViewJumpClickLogData(this.Data);
		}
	}

	// Token: 0x06009F04 RID: 40708 RVA: 0x00299339 File Offset: 0x00297539
	[NullableContext(1)]
	public void SetLockTextByTextId(string textId, params string[] args)
	{
		this.PanelLock.SetTextByTextId(textId, args);
	}

	// Token: 0x06009F05 RID: 40709 RVA: 0x00299348 File Offset: 0x00297548
	[NullableContext(1)]
	public void SetLockTextByText(string text)
	{
		this.PanelLock.SetTextByText(text);
	}

	// Token: 0x06009F06 RID: 40710 RVA: 0x00299356 File Offset: 0x00297556
	public void SetLockSpriteVisible(bool bVisible)
	{
		this.PanelLock.SetSpriteVisible(bVisible);
	}

	// Token: 0x06009F07 RID: 40711 RVA: 0x00299364 File Offset: 0x00297564
	public void SetPanelConditionVisible(bool bVisible)
	{
		base.GetItem(0).SetUIActive(bVisible);
	}

	// Token: 0x06009F08 RID: 40712 RVA: 0x00299373 File Offset: 0x00297573
	public void SetLockConditionButtonVisible(bool bVisible)
	{
		this.PanelLock.SetButtonVisible(bVisible);
	}

	// Token: 0x06009F09 RID: 40713 RVA: 0x00299381 File Offset: 0x00297581
	[NullableContext(1)]
	public void SetActivateTextByTextId(string textId, params string[] args)
	{
		this.PanelActivate.SetTextByTextId(textId, args);
	}

	// Token: 0x06009F0A RID: 40714 RVA: 0x00299390 File Offset: 0x00297590
	[NullableContext(1)]
	public void SetActivateTextByText(string text)
	{
		this.PanelActivate.SetTextByText(text);
	}

	// Token: 0x06009F0B RID: 40715 RVA: 0x0029939E File Offset: 0x0029759E
	public void SetActivateSpriteVisible(bool bVisible)
	{
		this.PanelActivate.SetSpriteVisible(bVisible);
	}

	// Token: 0x06009F0C RID: 40716 RVA: 0x002993AC File Offset: 0x002975AC
	public void SetActivatePanelConditionVisible(bool bVisible)
	{
		base.GetItem(2).SetUIActive(bVisible);
	}

	// Token: 0x06009F0D RID: 40717 RVA: 0x002993BB File Offset: 0x002975BB
	public void SetRewardButtonVisible(bool bVisible)
	{
		base.GetItem(4).SetUIActive(bVisible);
	}

	// Token: 0x06009F0E RID: 40718 RVA: 0x002993CA File Offset: 0x002975CA
	[NullableContext(1)]
	public void SetRewardButtonFunction(Action buttonFunction)
	{
		this.CircleButton.SetFunction(buttonFunction);
	}

	// Token: 0x06009F0F RID: 40719 RVA: 0x002993D8 File Offset: 0x002975D8
	public void SetFunctionRedDotVisible(bool bVisible)
	{
		this.FunctionButton.SetRedDotVisible(bVisible);
	}

	// Token: 0x06009F10 RID: 40720 RVA: 0x002993E6 File Offset: 0x002975E6
	[NullableContext(1)]
	public void SetPanelTipByTextId(string textId, params string[] args)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), textId, args);
	}

	// Token: 0x06009F11 RID: 40721 RVA: 0x002993FB File Offset: 0x002975FB
	[NullableContext(1)]
	public void SetPanelTipByText(string text)
	{
		base.GetText(7).SetText(text, true);
	}

	// Token: 0x06009F12 RID: 40722 RVA: 0x0029940B File Offset: 0x0029760B
	public void SetPanelTipVisible(bool bVisible)
	{
		base.GetItem(6).SetUIActive(bVisible);
	}

	// Token: 0x06009F13 RID: 40723 RVA: 0x0029941C File Offset: 0x0029761C
	public void RefreshGeneralPerformance(IActivityFunctionAreaParams parameters = null)
	{
		if (this.Data == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Activity, ELogAuthor.YYZ, "未传递活动数据,请传递数据再刷新", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		bool flag = this.Data.IsUnLock();
		bool flag2 = this.Data.CanPreOpen();
		bool flag3 = this.Data.HasPreOpenCondition();
		if (flag)
		{
			if (parameters != null)
			{
				this.SetGeneralUnlockPerformance(parameters);
			}
			return;
		}
		if (!flag3)
		{
			this.FunctionButton.SetUiActive(false);
			this.SetPerformanceConditionLock(this.Data.ConditionGroupId, this.Data.Id);
			return;
		}
		if (flag2)
		{
			this.SetPanelTipByTextId("ActivityPreOpenTip", Array.Empty<string>());
			this.SetPanelTipVisible(true);
			this.FunctionButton.SetLocalTextNew("ActivityPreOpen", Array.Empty<object>());
			this.FunctionButton.SetFunction(delegate
			{
				IActivityFunctionAreaParams parameters2 = parameters;
				if (((parameters2 != null) ? parameters2.BeforePreOpenCheck : null) != null && !parameters.BeforePreOpenCheck())
				{
					return;
				}
				this.OpenPreOpenRequestConfirmBox();
			});
			this.FunctionButton.SetUiActive(true);
			this.SetPanelConditionVisible(false);
			return;
		}
		this.FunctionButton.SetUiActive(false);
		this.SetPerformanceConditionLock(this.Data.PreOpenConditionGroupId, this.Data.Id);
	}

	// Token: 0x06009F14 RID: 40724 RVA: 0x00299550 File Offset: 0x00297750
	[NullableContext(1)]
	public void SetGeneralUnlockPerformance(IActivityFunctionAreaParams parameters)
	{
		this.SetPanelConditionVisible(false);
		this.SetPanelTipVisible(false);
		if (parameters.UnlockBtnTextId != null)
		{
			if (parameters.UnlockBtnTextArgs != null)
			{
				ActivityButtonItem functionButton = this.FunctionButton;
				string unlockBtnTextId = parameters.UnlockBtnTextId;
				object[] unlockBtnTextArgs = parameters.UnlockBtnTextArgs;
				functionButton.SetLocalTextNew(unlockBtnTextId, unlockBtnTextArgs);
			}
			else
			{
				this.FunctionButton.SetLocalTextNew(parameters.UnlockBtnTextId, Array.Empty<object>());
			}
		}
		if (parameters.UnlockBtnFunction != null)
		{
			this.FunctionButton.SetFunction(parameters.UnlockBtnFunction);
		}
		this.FunctionButton.SetUiActive(true);
	}

	// Token: 0x06009F15 RID: 40725 RVA: 0x002995D1 File Offset: 0x002977D1
	public void SetPerformanceOpenTimeOver()
	{
		this.SetPanelConditionVisible(true);
		this.SetLockTextByTextId("Activity_EndDesc01", Array.Empty<string>());
		this.SetActivatePanelConditionVisible(false);
		this.SetLockConditionButtonVisible(false);
		this.SetRewardButtonVisible(false);
		this.FunctionButton.SetUiActive(false);
	}

	// Token: 0x06009F16 RID: 40726 RVA: 0x0029960C File Offset: 0x0029780C
	public void SetPerformanceConditionLock(int conditionGroupId, int activityId)
	{
		this.SetPanelConditionVisible(true);
		this.SetActivatePanelConditionVisible(false);
		this.SetLockConditionButtonVisible(true);
		string conditionGroupHintText = LevelGeneralCommons.GetConditionGroupHintText(conditionGroupId);
		if (conditionGroupHintText != null)
		{
			this.SetLockTextByTextId(conditionGroupHintText, Array.Empty<string>());
		}
		this.PanelLock.ButtonCallBack = delegate()
		{
			ControllerBase<ActivityController>.Instance.OpenActivityConditionView(activityId);
		};
	}

	// Token: 0x06009F17 RID: 40727 RVA: 0x00299668 File Offset: 0x00297868
	[NullableContext(1)]
	public void SetPerformanceSubPackageLock(string textId, List<int> subPackageIdList)
	{
		this.SetPanelConditionVisible(true);
		this.SetActivatePanelConditionVisible(false);
		this.SetLockConditionButtonVisible(true);
		this.PanelLock.ButtonCallBack = delegate()
		{
			foreach (int id in subPackageIdList)
			{
				DownLoadSubPackage? downLoadSubPackageById = ConfigBase<SubPackageConfig>.Instance.GetDownLoadSubPackageById(id);
				if (downLoadSubPackageById != null)
				{
					foreach (int blockId in downLoadSubPackageById.Value.GetAreaArray())
					{
						if (ControllerBase<ResourceManagerController>.Instance.IsNeedReOpenMap(blockId))
						{
							ModelBase<SubPackageDownLoadModel>.Instance.OpenBlockNeedReLoginConfirm();
							return;
						}
					}
				}
			}
			ModelBase<SubPackageDownLoadModel>.Instance.OpenSubPackageDownLoadConfirmBySubPackageIds(textId, subPackageIdList);
		};
	}

	// Token: 0x06009F18 RID: 40728 RVA: 0x002996B8 File Offset: 0x002978B8
	public void OpenPreOpenRequestConfirmBox()
	{
		if (this.Data == null)
		{
			return;
		}
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.ActivityPreOpen);
		Action value = delegate()
		{
			Action<bool> callback = delegate(bool success)
			{
				if (!success)
				{
					return;
				}
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.ActivityViewRefreshCurrent, this.Data.Id);
			};
			ControllerBase<ActivityController>.Instance.RequestPreOpenActivity(this.Data, callback);
		};
		confirmBoxDataNew.FunctionMap.Add(2, value);
		string preOpenText = this.Data.LocalConfig.Value.PreOpenText;
		if (preOpenText != null)
		{
			confirmBoxDataNew.SetTextArgs(new string[]
			{
				ConfigMultiTextLang.GetLocalTextNew(preOpenText, null)
			});
		}
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x06009F19 RID: 40729 RVA: 0x00299731 File Offset: 0x00297931
	public UUIItem GetFunctionButtonItem()
	{
		return base.GetItem(1);
	}

	// Token: 0x020079CA RID: 31178
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x04029CFA RID: 171258
		public const int PanelCondition = 0;

		// Token: 0x04029CFB RID: 171259
		public const int FunctionButton = 1;

		// Token: 0x04029CFC RID: 171260
		public const int PanelActivate = 2;

		// Token: 0x04029CFD RID: 171261
		public const int FunctionRedDot = 3;

		// Token: 0x04029CFE RID: 171262
		public const int PanelCircle = 4;

		// Token: 0x04029CFF RID: 171263
		public const int ButtonCircle = 5;

		// Token: 0x04029D00 RID: 171264
		public const int PanelTip = 6;

		// Token: 0x04029D01 RID: 171265
		public const int TxtTip = 7;
	}
}
