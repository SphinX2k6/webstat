using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001AED RID: 6893
[NullableContext(2)]
[Nullable(0)]
public class DangoAbyssLevelUpView : UiViewBase
{
	// Token: 0x0600C665 RID: 50789 RVA: 0x00346C83 File Offset: 0x00344E83
	[NullableContext(1)]
	public DangoAbyssLevelUpView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600C666 RID: 50790 RVA: 0x00346C8C File Offset: 0x00344E8C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnClickClose))
		};
	}

	// Token: 0x0600C667 RID: 50791 RVA: 0x00346DD2 File Offset: 0x00344FD2
	public override bool GetLoopAudioEventSwitch()
	{
		return !ModelBase<DangoAbyssModel>.Instance.CheckIfInSmallWorldInstance();
	}

	// Token: 0x0600C668 RID: 50792 RVA: 0x00346DE4 File Offset: 0x00344FE4
	protected override UniTask OnBeforeStartAsync()
	{
		DangoAbyssLevelUpView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<DangoAbyssLevelUpView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600C669 RID: 50793 RVA: 0x00346E27 File Offset: 0x00345027
	protected override void OnStart()
	{
		this.DangoId = (int)this.OpenParam;
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnAbyssPluginDangoSelect, 0);
	}

	// Token: 0x0600C66A RID: 50794 RVA: 0x00346E4B File Offset: 0x0034504B
	[NullableContext(1)]
	private AbyssDangoRoleData GetCurrentDangoData()
	{
		return ModelBase<DangoAbyssModel>.Instance.GetDangoAbyssRoleData(this.DangoId);
	}

	// Token: 0x0600C66B RID: 50795 RVA: 0x00346E5D File Offset: 0x0034505D
	protected override void OnBeforeShow()
	{
		this.RefreshView();
	}

	// Token: 0x0600C66C RID: 50796 RVA: 0x00346E68 File Offset: 0x00345068
	private void RefreshView()
	{
		AbyssDangoRoleData currentDangoData = this.GetCurrentDangoData();
		this.RefreshCostItem(currentDangoData);
		this.RefreshMaxLevel(currentDangoData);
		this.RefreshLevelPreviewText(currentDangoData);
		this.RefreshNameText(currentDangoData);
		this.RefreshLevelUpItem(currentDangoData);
		this.RefreshAttribute(currentDangoData);
	}

	// Token: 0x0600C66D RID: 50797 RVA: 0x00346EA8 File Offset: 0x003450A8
	private void RefreshCostItem(AbyssDangoRoleData data)
	{
		if (data == null)
		{
			return;
		}
		bool ifCanLevelUp = data.GetIfCanLevelUp();
		this.CostItem.SetActive(ifCanLevelUp);
		if (ifCanLevelUp)
		{
			this.CostItem.RefreshCost(data.GetCurrentLevelUpConsume().ToList<ICostData>());
		}
	}

	// Token: 0x0600C66E RID: 50798 RVA: 0x00346EE8 File Offset: 0x003450E8
	private void RefreshMaxLevel(AbyssDangoRoleData data)
	{
		if (data == null)
		{
			base.GetItem(10).SetActive(false, false);
			return;
		}
		bool ifLock = data.GetIfLock();
		bool ifMaxLevel = data.GetIfMaxLevel();
		base.GetItem(10).SetActive(!ifLock && ifMaxLevel, false);
	}

	// Token: 0x0600C66F RID: 50799 RVA: 0x00346F2C File Offset: 0x0034512C
	private void RefreshLevelUpItem(AbyssDangoRoleData data)
	{
		if (data == null)
		{
			ButtonItem levelUpItem = this.LevelUpItem;
			if (levelUpItem == null)
			{
				return;
			}
			levelUpItem.SetActive(false);
			return;
		}
		else
		{
			bool ifCanLevelUp = data.GetIfCanLevelUp();
			ButtonItem levelUpItem2 = this.LevelUpItem;
			if (levelUpItem2 != null)
			{
				levelUpItem2.SetActive(ifCanLevelUp);
			}
			bool dangoLevelUpRedDotById = ModelBase<DangoAbyssModel>.Instance.GetDangoLevelUpRedDotById(data.GetId(), new bool?(false));
			ButtonItem levelUpItem3 = this.LevelUpItem;
			if (levelUpItem3 == null)
			{
				return;
			}
			levelUpItem3.SetRedDotVisible(dangoLevelUpRedDotById);
			return;
		}
	}

	// Token: 0x0600C670 RID: 50800 RVA: 0x00346F90 File Offset: 0x00345190
	private void RefreshLevelPreviewText(AbyssDangoRoleData data)
	{
		base.GetText(4).SetText(StringUtils.Format("Lv.{0}", new string[]
		{
			data.GetLevel().ToString()
		}), true);
		if (data.GetIfMaxLevel())
		{
			base.GetItem(5).SetUIActive(false);
			base.GetText(6).SetText("", true);
			return;
		}
		base.GetItem(5).SetUIActive(true);
		base.GetText(6).SetText(StringUtils.Format("Lv.{0}", new string[]
		{
			(data.GetLevel() + 1).ToString()
		}), true);
	}

	// Token: 0x0600C671 RID: 50801 RVA: 0x00347030 File Offset: 0x00345230
	private void RefreshAttribute(AbyssDangoRoleData data)
	{
		int newLevel = data.GetLevel() + 1;
		if (data.GetIfMaxLevel())
		{
			newLevel = data.GetLevel();
		}
		IAttributeInfo[] levelUpViewAttributeInfo = data.GetLevelUpViewAttributeInfo(newLevel, new bool?(data.GetIfMaxLevel()));
		this.Layout.RefreshByData(levelUpViewAttributeInfo.ToList<IAttributeInfo>(), null, false);
	}

	// Token: 0x0600C672 RID: 50802 RVA: 0x0034707B File Offset: 0x0034527B
	private void RefreshNameText(AbyssDangoRoleData data)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), data.GetName(), Array.Empty<object>());
	}

	// Token: 0x0600C673 RID: 50803 RVA: 0x00347099 File Offset: 0x00345299
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnAbyssRoleInfoUpdate, new Action(this.OnAbyssRoleInfoUpdate));
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnAbyssDangoLevelUp, new Action<int, int>(this.OnAbyssDangoLevelUp));
	}

	// Token: 0x0600C674 RID: 50804 RVA: 0x003470D3 File Offset: 0x003452D3
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnAbyssRoleInfoUpdate, new Action(this.OnAbyssRoleInfoUpdate));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnAbyssDangoLevelUp, new Action<int, int>(this.OnAbyssDangoLevelUp));
	}

	// Token: 0x0600C675 RID: 50805 RVA: 0x0034710D File Offset: 0x0034530D
	private void OnAbyssRoleInfoUpdate()
	{
		this.RefreshView();
	}

	// Token: 0x0600C676 RID: 50806 RVA: 0x00347118 File Offset: 0x00345318
	private void OnAbyssDangoLevelUp(int dangoId, int level)
	{
		if (this.DangoId != dangoId)
		{
			return;
		}
		ILevelUpSuccessAttributeData levelUpViewData = this.GetCurrentDangoData().GetLevelUpViewData(level);
		levelUpViewData.ClickFunction = new Action(this.OnClickCloseSuccess);
		ControllerBase<RoleLevelUpSuccessController>.Instance.OpenSuccessAttributeView(levelUpViewData, null);
	}

	// Token: 0x0600C677 RID: 50807 RVA: 0x0034715A File Offset: 0x0034535A
	[NullableContext(1)]
	private CommonLevelUpAttributeItem InitItem()
	{
		return new CommonLevelUpAttributeItem();
	}

	// Token: 0x0600C678 RID: 50808 RVA: 0x00347164 File Offset: 0x00345364
	private void OnConfirmBtnClick(int _)
	{
		AbyssDangoRoleData currentDangoData = this.GetCurrentDangoData();
		if (!currentDangoData.GetIfCanLevelUp())
		{
			return;
		}
		if (!currentDangoData.GetIfLevelUpEnough())
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("GenericPrompt_LevelUpMaterialShort_TipsText", Array.Empty<object>());
			return;
		}
		ControllerBase<DangoAbyssActivityController>.Instance.RequestAbyssDangoLevelUp(currentDangoData.GetId(), currentDangoData.GetLevel() + 1);
	}

	// Token: 0x0600C679 RID: 50809 RVA: 0x003471B6 File Offset: 0x003453B6
	private void OnClickClose()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600C67A RID: 50810 RVA: 0x003471BF File Offset: 0x003453BF
	private void OnClickCloseSuccess()
	{
		if (this.GetCurrentDangoData().GetIfMaxLevel())
		{
			base.CloseMe(null);
		}
	}

	// Token: 0x04005F0F RID: 24335
	private int DangoId;

	// Token: 0x04005F10 RID: 24336
	private CommonCurrencyItemListComponent CurrencyList;

	// Token: 0x04005F11 RID: 24337
	private CostItem CostItem;

	// Token: 0x04005F12 RID: 24338
	private ButtonItem LevelUpItem;

	// Token: 0x04005F13 RID: 24339
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<CommonLevelUpAttributeItem, IAttributeInfo> Layout;

	// Token: 0x02007DBE RID: 32190
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402AD3D RID: 175421
		BtnClose,
		// Token: 0x0402AD3E RID: 175422
		PanelCost,
		// Token: 0x0402AD3F RID: 175423
		ItemCost,
		// Token: 0x0402AD40 RID: 175424
		NameText,
		// Token: 0x0402AD41 RID: 175425
		CurrentLevelText,
		// Token: 0x0402AD42 RID: 175426
		SpriteArrow,
		// Token: 0x0402AD43 RID: 175427
		NextLevelText,
		// Token: 0x0402AD44 RID: 175428
		AttributeLayout,
		// Token: 0x0402AD45 RID: 175429
		AttributeItem,
		// Token: 0x0402AD46 RID: 175430
		CostItem,
		// Token: 0x0402AD47 RID: 175431
		MaxLevelItem,
		// Token: 0x0402AD48 RID: 175432
		ConfirmBtnItem
	}
}
