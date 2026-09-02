using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Core.Extension;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.ServerStorage;
using CSharpScript.Game.ServerStorage.Container;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002480 RID: 9344
[NullableContext(1)]
[Nullable(0)]
public class PhantomManagerConfigEditPopItem : UiViewBase
{
	// Token: 0x06012223 RID: 74275 RVA: 0x004FBCEB File Offset: 0x004F9EEB
	public PhantomManagerConfigEditPopItem(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06012224 RID: 74276 RVA: 0x004FBD18 File Offset: 0x004F9F18
	protected unsafe override void OnRegisterComponent()
	{
		int num = 12;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 4;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickedEditClose));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(11, new Action(this.OnClickedSave));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(9, new Action(this.OnClickedReset));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(10, new Action(this.OnClickedRecommend));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06012225 RID: 74277 RVA: 0x004FBF78 File Offset: 0x004FA178
	protected override UniTask OnBeforeStartAsync()
	{
		PhantomManagerConfigEditPopItem.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomManagerConfigEditPopItem.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012226 RID: 74278 RVA: 0x004FBFBC File Offset: 0x004FA1BC
	protected override void OnStart()
	{
		this.LeftInfoItem.Refresh(new PhantomManagerFetterInfo
		{
			FetterId = this.CurrentFetterId,
			Count = this.FetterCount
		}, false, 0);
		this.ScrollSetting.RefreshByData(this.CurData, null, true);
		this.RefreshState();
	}

	// Token: 0x06012227 RID: 74279 RVA: 0x004FC00C File Offset: 0x004FA20C
	protected void RefreshState()
	{
		PhantomFetterGroup fetterGroupById = ConfigBase<PhantomBattleConfig>.Instance.GetFetterGroupById(this.CurrentFetterId);
		base.SetTextureByPath(fetterGroupById.FetterElementPath, base.GetTexture(5), null, null);
		string configTextByKey = Singleton<PublicUtil>.Instance.GetConfigTextByKey(fetterGroupById.FetterGroupName);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), "PhantomProject_PlanName", new <>z__ReadOnlySingleElementList<object>(configTextByKey));
		bool fetterConfigIsOpen = this.ConfigData.GetFetterConfigIsOpen(this.CurrentFetterId);
		UUITexture texture = base.GetTexture(3);
		if (texture != null)
		{
			texture.SetUIActive(!fetterConfigIsOpen);
		}
		UUIItem item = base.GetItem(4);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(fetterConfigIsOpen);
	}

	// Token: 0x06012228 RID: 74280 RVA: 0x004FC0B0 File Offset: 0x004FA2B0
	private void OnCloseMask(bool needApply)
	{
		this.ConfigData.DoCacheDataUpdate(needApply);
		IPhantomManagerEditPopInfo phantomManagerEditPopInfo = this.OpenParam as IPhantomManagerEditPopInfo;
		if (phantomManagerEditPopInfo != null)
		{
			Action closeCb = phantomManagerEditPopInfo.CloseCb;
			if (closeCb != null)
			{
				closeCb();
			}
		}
		base.CloseMe(null);
	}

	// Token: 0x06012229 RID: 74281 RVA: 0x004FC0E8 File Offset: 0x004FA2E8
	private void ResetSinglePlan()
	{
		this.ConfigData.ResetFetterConfig(this.CurrentFetterId);
		foreach (PhantomManagerConfigNewSettingItem phantomManagerConfigNewSettingItem in this.ScrollSetting.GetScrollItemList())
		{
			phantomManagerConfigNewSettingItem.RefreshState(true, true);
		}
		ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("PhantomProject_OnePlanClean_Des_2", Array.Empty<object>());
	}

	// Token: 0x0601222A RID: 74282 RVA: 0x004FC164 File Offset: 0x004FA364
	private void OnClickedEditClose()
	{
		if (!this.ConfigData.CheckDirty())
		{
			this.OnCloseMask(false);
			return;
		}
		if (this.ConfigData.ConfigViewEditCloseSelect == EPhantomManagerEditCloseState.Left)
		{
			this.OnCloseMask(false);
			return;
		}
		if (this.ConfigData.ConfigViewEditCloseSelect == EPhantomManagerEditCloseState.Right)
		{
			this.OnClickedSave();
			return;
		}
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.PhantomConfigSaveCloseEditConfirm);
		confirmBoxDataNew.HasToggle = true;
		confirmBoxDataNew.ToggleText = Singleton<PublicUtil>.Instance.GetConfigTextByKey("PhantomProject_CommonText");
		confirmBoxDataNew.IsEscViewTriggerCallBack = false;
		confirmBoxDataNew.SetToggleFunction(delegate(bool value)
		{
			this.ConfirmBoxLoginTmpMap[EConfirmBoxConfigId.PhantomConfigSaveCloseEditConfirm] = value;
		});
		confirmBoxDataNew.FunctionMap[1] = delegate()
		{
			this.OnCloseMask(false);
			bool? valueOrNull = this.ConfirmBoxLoginTmpMap.GetValueOrNull(EConfirmBoxConfigId.PhantomConfigSaveCloseEditConfirm);
			if (valueOrNull != null && valueOrNull.Value)
			{
				this.ConfigData.ConfirmBoxLoginSet.Add(EConfirmBoxConfigId.PhantomConfigSaveCloseEditConfirm);
				this.ConfigData.ConfigViewEditCloseSelect = EPhantomManagerEditCloseState.Left;
			}
		};
		confirmBoxDataNew.FunctionMap[2] = delegate()
		{
			this.OnClickedSave();
			bool? valueOrNull = this.ConfirmBoxLoginTmpMap.GetValueOrNull(EConfirmBoxConfigId.PhantomConfigSaveCloseEditConfirm);
			if (valueOrNull != null && valueOrNull.Value)
			{
				this.ConfigData.ConfirmBoxLoginSet.Add(EConfirmBoxConfigId.PhantomConfigSaveCloseEditConfirm);
				this.ConfigData.ConfigViewEditCloseSelect = EPhantomManagerEditCloseState.Right;
			}
		};
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x0601222B RID: 74283 RVA: 0x004FC230 File Offset: 0x004FA430
	private void OnClickedSave()
	{
		ServerStorageBoolean serverStorageBoolean = ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.PhantomBattleConfigApplyPlanWhenSaved) as ServerStorageBoolean;
		bool needOpen = ((serverStorageBoolean != null) ? serverStorageBoolean.Get() : null).GetValueOrDefault();
		this.ConfigData.GetFetterConfigIsOpen(this.CurrentFetterId);
		PhantomBattleController instance = ControllerBase<PhantomBattleController>.Instance;
		bool isReset = false;
		HashSet<int> openIdSet;
		if (!needOpen)
		{
			openIdSet = new HashSet<int>();
		}
		else
		{
			(openIdSet = new HashSet<int>()).Add(this.CurrentFetterId);
		}
		instance.RequestPhBaPlanSaveUsePlan(isReset, openIdSet).ContinueWith(delegate(bool value)
		{
			if (value)
			{
				this.ConfigData.DoCacheDataUpdate(true);
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId(needOpen ? "PhantomProject_OnePlanPreparatory_Des_4" : "PhantomProject_OnePlanPreparatory_Des_3", Array.Empty<object>());
				this.ConfigData.DoLogReport(new List<int>
				{
					this.CurrentFetterId
				}, false);
				Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnPhantomConfigManagerDataUpdate, false);
			}
			this.CloseMe(null);
			IPhantomManagerEditPopInfo phantomManagerEditPopInfo = this.OpenParam as IPhantomManagerEditPopInfo;
			if (phantomManagerEditPopInfo == null)
			{
				return;
			}
			Action closeCb = phantomManagerEditPopInfo.CloseCb;
			if (closeCb == null)
			{
				return;
			}
			closeCb();
		}).Forget();
	}

	// Token: 0x0601222C RID: 74284 RVA: 0x004FC2D4 File Offset: 0x004FA4D4
	private void OnClickedReset()
	{
		EConfirmBoxConfigId confirmId = EConfirmBoxConfigId.PhantomConfigApplyClearPlanConfirm;
		if (this.ConfigData.ConfirmBoxLoginSet.Contains(confirmId))
		{
			this.ResetSinglePlan();
			return;
		}
		this.ConfirmBoxLoginTmpMap[confirmId] = false;
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(confirmId);
		confirmBoxDataNew.HasToggle = true;
		confirmBoxDataNew.ToggleText = Singleton<PublicUtil>.Instance.GetConfigTextByKey("PhantomProject_CommonText");
		confirmBoxDataNew.SetToggleFunction(delegate(bool value)
		{
			this.ConfirmBoxLoginTmpMap[confirmId] = value;
		});
		confirmBoxDataNew.FunctionMap[2] = delegate()
		{
			this.ResetSinglePlan();
			if (this.ConfirmBoxLoginTmpMap.GetValueOrNull(confirmId).Value)
			{
				this.ConfigData.ConfirmBoxLoginSet.Add(confirmId);
			}
		};
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x0601222D RID: 74285 RVA: 0x004FC388 File Offset: 0x004FA588
	private void OnClickedRecommend()
	{
		if (!this.ConfigData.CheckEditFetterConfigRecommendDirty(this.CurrentFetterId))
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("PhantomProject_UsePreparatoryPlan_Des_1", Array.Empty<object>());
			return;
		}
		this.ConfigData.SetFetterConfigRecommend(this.CurrentFetterId);
		foreach (PhantomManagerConfigNewSettingItem phantomManagerConfigNewSettingItem in this.ScrollSetting.GetScrollItemList())
		{
			phantomManagerConfigNewSettingItem.RefreshState(true, true);
		}
		ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("PhantomProject_OnePlanPreparatory_Des_2", Array.Empty<object>());
	}

	// Token: 0x0601222E RID: 74286 RVA: 0x004FC430 File Offset: 0x004FA630
	private PhantomManagerConfigNewSettingItem CreateSettingTitleItem()
	{
		return new PhantomManagerConfigNewSettingItem();
	}

	// Token: 0x04008D85 RID: 36229
	private readonly Dictionary<EConfirmBoxConfigId, bool> ConfirmBoxLoginTmpMap = new Dictionary<EConfirmBoxConfigId, bool>();

	// Token: 0x04008D86 RID: 36230
	private PhantomManagerConfigData ConfigData = new PhantomManagerConfigData();

	// Token: 0x04008D87 RID: 36231
	private readonly List<IPhantomManagerConfigNewSettingInfo> CurData = new List<IPhantomManagerConfigNewSettingInfo>();

	// Token: 0x04008D88 RID: 36232
	private int CurrentFetterId;

	// Token: 0x04008D89 RID: 36233
	private int FetterCount;

	// Token: 0x04008D8A RID: 36234
	[Nullable(2)]
	private PhantomConfigEditToggle PhantomConfigEditToggle;

	// Token: 0x04008D8B RID: 36235
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<PhantomManagerConfigNewSettingItem, IPhantomManagerConfigNewSettingInfo> ScrollSetting;

	// Token: 0x04008D8C RID: 36236
	[Nullable(2)]
	private PhantomManagerConfigNewFetterItem LeftInfoItem;

	// Token: 0x02008794 RID: 34708
	[NullableContext(0)]
	private enum EDefine
	{
		// Token: 0x0402DD5C RID: 187740
		ToggleItem,
		// Token: 0x0402DD5D RID: 187741
		BtnBack,
		// Token: 0x0402DD5E RID: 187742
		ItemEchoSetPlan,
		// Token: 0x0402DD5F RID: 187743
		TexTitleBg,
		// Token: 0x0402DD60 RID: 187744
		PanelActivation,
		// Token: 0x0402DD61 RID: 187745
		TexEchoIcon,
		// Token: 0x0402DD62 RID: 187746
		TxtPlanName,
		// Token: 0x0402DD63 RID: 187747
		ScrollSetting,
		// Token: 0x0402DD64 RID: 187748
		ItemInfo,
		// Token: 0x0402DD65 RID: 187749
		BtnReset,
		// Token: 0x0402DD66 RID: 187750
		BtnRecommend,
		// Token: 0x0402DD67 RID: 187751
		BtnSave
	}
}
