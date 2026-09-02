using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002AD9 RID: 10969
[NullableContext(1)]
[Nullable(0)]
public class SurvivorsRogueCardBase : UiPanelBase
{
	// Token: 0x06015EC9 RID: 89801 RVA: 0x0061711C File Offset: 0x0061531C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(7, typeof(UUIText)),
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIText)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUISprite)),
			new ValueTuple<int, Type>(14, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(6, new Action<EToggleState>(this.OnClickLock))
		};
	}

	// Token: 0x06015ECA RID: 89802 RVA: 0x006172A8 File Offset: 0x006154A8
	protected override void OnStart()
	{
		base.GetText(10).SetUIActive(false);
		TermExplanationRegistryParam param = new TermExplanationRegistryParam
		{
			UiText = base.GetText(8),
			ViewType = ETermExplanationViewType.Center,
			ReportType = ETermExplanationReportType.SurvivorsRogue
		};
		ControllerBase<TermExplanationController>.Instance.RegisterTextHyperlinkByParam(param);
		this.AddEvents();
	}

	// Token: 0x06015ECB RID: 89803 RVA: 0x006172F7 File Offset: 0x006154F7
	protected override void OnBeforeDestroy()
	{
		this.RemoveEvents();
	}

	// Token: 0x06015ECC RID: 89804 RVA: 0x00617300 File Offset: 0x00615500
	public UniTask Apply(SurvivorsRogueItemCard data)
	{
		SurvivorsRogueCardBase.<Apply>d__12 <Apply>d__;
		<Apply>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Apply>d__.<>4__this = this;
		<Apply>d__.data = data;
		<Apply>d__.<>1__state = -1;
		<Apply>d__.<>t__builder.Start<SurvivorsRogueCardBase.<Apply>d__12>(ref <Apply>d__);
		return <Apply>d__.<>t__builder.Task;
	}

	// Token: 0x06015ECD RID: 89805 RVA: 0x0061734C File Offset: 0x0061554C
	public UniTask Apply(SurvivorsRogueCharacterCard data)
	{
		SurvivorsRogueCardBase.<Apply>d__13 <Apply>d__;
		<Apply>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Apply>d__.<>4__this = this;
		<Apply>d__.data = data;
		<Apply>d__.<>1__state = -1;
		<Apply>d__.<>t__builder.Start<SurvivorsRogueCardBase.<Apply>d__13>(ref <Apply>d__);
		return <Apply>d__.<>t__builder.Task;
	}

	// Token: 0x06015ECE RID: 89806 RVA: 0x00617398 File Offset: 0x00615598
	public UniTask Apply(SurvivorsRogueWeaponCard data)
	{
		SurvivorsRogueCardBase.<Apply>d__14 <Apply>d__;
		<Apply>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Apply>d__.<>4__this = this;
		<Apply>d__.data = data;
		<Apply>d__.<>1__state = -1;
		<Apply>d__.<>t__builder.Start<SurvivorsRogueCardBase.<Apply>d__14>(ref <Apply>d__);
		return <Apply>d__.<>t__builder.Task;
	}

	// Token: 0x06015ECF RID: 89807 RVA: 0x006173E4 File Offset: 0x006155E4
	private UniTask ApplyInternal(SurvivorsRogueCardBaseData data)
	{
		SurvivorsRogueCardBase.<ApplyInternal>d__15 <ApplyInternal>d__;
		<ApplyInternal>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ApplyInternal>d__.<>4__this = this;
		<ApplyInternal>d__.data = data;
		<ApplyInternal>d__.<>1__state = -1;
		<ApplyInternal>d__.<>t__builder.Start<SurvivorsRogueCardBase.<ApplyInternal>d__15>(ref <ApplyInternal>d__);
		return <ApplyInternal>d__.<>t__builder.Task;
	}

	// Token: 0x06015ED0 RID: 89808 RVA: 0x00617430 File Offset: 0x00615630
	protected virtual UniTask ApplyCardTypeItem(ISurvivorsRogueItemCard data)
	{
		SurvivorsRogueCardBase.<ApplyCardTypeItem>d__16 <ApplyCardTypeItem>d__;
		<ApplyCardTypeItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ApplyCardTypeItem>d__.<>4__this = this;
		<ApplyCardTypeItem>d__.data = data;
		<ApplyCardTypeItem>d__.<>1__state = -1;
		<ApplyCardTypeItem>d__.<>t__builder.Start<SurvivorsRogueCardBase.<ApplyCardTypeItem>d__16>(ref <ApplyCardTypeItem>d__);
		return <ApplyCardTypeItem>d__.<>t__builder.Task;
	}

	// Token: 0x06015ED1 RID: 89809 RVA: 0x0061747C File Offset: 0x0061567C
	protected virtual UniTask ApplyCardTypeCharacter(ISurvivorsRogueCharacterCard data)
	{
		SurvivorsRogueCardBase.<ApplyCardTypeCharacter>d__17 <ApplyCardTypeCharacter>d__;
		<ApplyCardTypeCharacter>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ApplyCardTypeCharacter>d__.<>4__this = this;
		<ApplyCardTypeCharacter>d__.data = data;
		<ApplyCardTypeCharacter>d__.<>1__state = -1;
		<ApplyCardTypeCharacter>d__.<>t__builder.Start<SurvivorsRogueCardBase.<ApplyCardTypeCharacter>d__17>(ref <ApplyCardTypeCharacter>d__);
		return <ApplyCardTypeCharacter>d__.<>t__builder.Task;
	}

	// Token: 0x06015ED2 RID: 89810 RVA: 0x006174C8 File Offset: 0x006156C8
	protected virtual UniTask ApplyCardTypeWeapon(ISurvivorsRogueWeaponCard data)
	{
		SurvivorsRogueCardBase.<ApplyCardTypeWeapon>d__18 <ApplyCardTypeWeapon>d__;
		<ApplyCardTypeWeapon>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ApplyCardTypeWeapon>d__.<>4__this = this;
		<ApplyCardTypeWeapon>d__.data = data;
		<ApplyCardTypeWeapon>d__.<>1__state = -1;
		<ApplyCardTypeWeapon>d__.<>t__builder.Start<SurvivorsRogueCardBase.<ApplyCardTypeWeapon>d__18>(ref <ApplyCardTypeWeapon>d__);
		return <ApplyCardTypeWeapon>d__.<>t__builder.Task;
	}

	// Token: 0x06015ED3 RID: 89811 RVA: 0x00617514 File Offset: 0x00615714
	[return: Nullable(new byte[]
	{
		0,
		2
	})]
	protected UniTask<SurvivorsRogueCardComponent> RefreshComponent(Type gridClass, bool bNewIfNull, [Nullable(new byte[]
	{
		1,
		2
	})] params object[] args)
	{
		SurvivorsRogueCardBase.<RefreshComponent>d__19 <RefreshComponent>d__;
		<RefreshComponent>d__.<>t__builder = AsyncUniTaskMethodBuilder<SurvivorsRogueCardComponent>.Create();
		<RefreshComponent>d__.<>4__this = this;
		<RefreshComponent>d__.gridClass = gridClass;
		<RefreshComponent>d__.bNewIfNull = bNewIfNull;
		<RefreshComponent>d__.args = args;
		<RefreshComponent>d__.<>1__state = -1;
		<RefreshComponent>d__.<>t__builder.Start<SurvivorsRogueCardBase.<RefreshComponent>d__19>(ref <RefreshComponent>d__);
		return <RefreshComponent>d__.<>t__builder.Task;
	}

	// Token: 0x06015ED4 RID: 89812 RVA: 0x00617570 File Offset: 0x00615770
	[return: Nullable(2)]
	private SurvivorsRogueCardComponent GetCardComponent(Type ctor)
	{
		SurvivorsRogueCardComponent result;
		if (!this.ComponentMap.TryGetValue(ctor, out result))
		{
			return null;
		}
		return result;
	}

	// Token: 0x06015ED5 RID: 89813 RVA: 0x00617590 File Offset: 0x00615790
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	private UniTask<SurvivorsRogueCardComponent> CreateCardComponent(Type componentClass)
	{
		SurvivorsRogueCardBase.<CreateCardComponent>d__21 <CreateCardComponent>d__;
		<CreateCardComponent>d__.<>t__builder = AsyncUniTaskMethodBuilder<SurvivorsRogueCardComponent>.Create();
		<CreateCardComponent>d__.<>4__this = this;
		<CreateCardComponent>d__.componentClass = componentClass;
		<CreateCardComponent>d__.<>1__state = -1;
		<CreateCardComponent>d__.<>t__builder.Start<SurvivorsRogueCardBase.<CreateCardComponent>d__21>(ref <CreateCardComponent>d__);
		return <CreateCardComponent>d__.<>t__builder.Task;
	}

	// Token: 0x06015ED6 RID: 89814 RVA: 0x006175DB File Offset: 0x006157DB
	private void ClearComponentList()
	{
		this.CenterComponentList.Clear();
		this.BottomComponentList.Clear();
	}

	// Token: 0x06015ED7 RID: 89815 RVA: 0x006175F4 File Offset: 0x006157F4
	private void AddToComponentList(SurvivorsRogueCardComponent component)
	{
		ECardMountPos layoutLevel = component.GetLayoutLevel();
		if (layoutLevel == ECardMountPos.Center)
		{
			this.CenterComponentList.Add(component);
			return;
		}
		if (layoutLevel != ECardMountPos.Bottom)
		{
			return;
		}
		this.BottomComponentList.Add(component);
	}

	// Token: 0x06015ED8 RID: 89816 RVA: 0x0061762C File Offset: 0x0061582C
	protected void RefreshComponentHierarchyIndex()
	{
		for (int i = 0; i < this.BottomComponentList.Count; i++)
		{
			SurvivorsRogueCardComponent survivorsRogueCardComponent = this.BottomComponentList[i];
			if (survivorsRogueCardComponent != null)
			{
				UUIItem originalItem = survivorsRogueCardComponent.GetOriginalItem();
				if (originalItem != null)
				{
					originalItem.SetHierarchyIndex(i);
				}
			}
		}
		for (int j = 0; j < this.CenterComponentList.Count; j++)
		{
			SurvivorsRogueCardComponent survivorsRogueCardComponent2 = this.CenterComponentList[j];
			if (survivorsRogueCardComponent2 != null)
			{
				UUIItem originalItem2 = survivorsRogueCardComponent2.GetOriginalItem();
				if (originalItem2 != null)
				{
					originalItem2.SetHierarchyIndex(j);
				}
			}
		}
	}

	// Token: 0x06015ED9 RID: 89817 RVA: 0x006176AB File Offset: 0x006158AB
	private void OnComponentVisibleChanged(SurvivorsRogueCardComponent component, bool bVisible)
	{
		if (bVisible)
		{
			this.VisibleComponents.Add(component);
			return;
		}
		this.VisibleComponents.Remove(component);
	}

	// Token: 0x06015EDA RID: 89818 RVA: 0x006176CB File Offset: 0x006158CB
	private void ClearVisibleComponent()
	{
		this.VisibleComponents.Clear();
	}

	// Token: 0x06015EDB RID: 89819 RVA: 0x006176D8 File Offset: 0x006158D8
	protected void RefreshComponentVisible()
	{
		foreach (SurvivorsRogueCardComponent survivorsRogueCardComponent in this.ComponentMap.Values)
		{
			if (!this.VisibleComponents.Contains(survivorsRogueCardComponent))
			{
				survivorsRogueCardComponent.SetActive(false);
			}
		}
	}

	// Token: 0x06015EDC RID: 89820 RVA: 0x00617740 File Offset: 0x00615940
	protected void ApplyBase(ISurvivorsRogueCardBase data)
	{
		this.RefreshBaseDesc(data);
		this.RefreshBaseQuality(data);
		this.RefreshBaseFunc(data);
		this.RefreshLock(data);
		this.RefreshBaseIcon(data);
	}

	// Token: 0x06015EDD RID: 89821 RVA: 0x00617768 File Offset: 0x00615968
	private void RefreshBaseDesc(ISurvivorsRogueCardBase data)
	{
		UUIText text = base.GetText(7);
		if (data.TitleId != null)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, data.TitleId, Array.Empty<object>());
		}
		else if (data.TitleText != null)
		{
			text.SetText(data.TitleText, true);
		}
		UUIText text2 = base.GetText(8);
		string[] args = data.DescParams ?? Array.Empty<string>();
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, data.DescId, args);
		UUIText text3 = base.GetText(5);
		string text4 = data.TagId;
		if (text4 == null)
		{
			string text5;
			switch (data.Type)
			{
			case ESurvivorsRogueItemType.Normal:
				text5 = "SurvivorsCard_Prop";
				break;
			case ESurvivorsRogueItemType.Weapon:
				text5 = "SurvivorsCard_WeaponUpgrade";
				break;
			case ESurvivorsRogueItemType.Character:
				text5 = "SurvivorsCard_RoleUpgrade";
				break;
			default:
				text5 = "SurvivorsCard_Prop";
				break;
			}
			text4 = text5;
		}
		string textStringId = text4;
		string[] args2 = data.TagParams ?? Array.Empty<string>();
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text3, textStringId, args2);
		base.GetItem(4).SetUIActive(data.TagVisible.GetValueOrDefault(true));
	}

	// Token: 0x06015EDE RID: 89822 RVA: 0x00617874 File Offset: 0x00615A74
	private void RefreshBaseQuality(ISurvivorsRogueCardBase data)
	{
		UUITexture texture = base.GetTexture(1);
		SurvivorsQuality? qualityConfig = ConfigBase<SurvivorsRogueConfig>.Instance.GetQualityConfig(data.QualityId);
		base.SetTextureByPath((qualityConfig != null) ? qualityConfig.GetValueOrDefault().CardBasePath : null, texture, null, null);
		if (data.IsLevelUp.GetValueOrDefault())
		{
			this.SetSpriteByPath(qualityConfig.Value.LvUpTagPath, base.GetSprite(13), false, null, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(14), "SurvivorsCardLvUp", Array.Empty<object>());
		}
		base.GetItem(12).SetUIActive(data.IsLevelUp.GetValueOrDefault());
	}

	// Token: 0x06015EDF RID: 89823 RVA: 0x00617938 File Offset: 0x00615B38
	private void RefreshBaseFunc(ISurvivorsRogueCardBase data)
	{
		base.GetItem(11).SetUIActive(data.IsLevelUp.GetValueOrDefault());
		this.SetToggleInteractive(data.UseToggle.GetValueOrDefault());
		base.GetText(8).SetBubbleUpToParent(data.UseToggle.GetValueOrDefault());
	}

	// Token: 0x06015EE0 RID: 89824 RVA: 0x0061798E File Offset: 0x00615B8E
	private void RefreshBaseIcon(ISurvivorsRogueCardBase data)
	{
		base.GetTexture(2).SetUIActive(false);
	}

	// Token: 0x06015EE1 RID: 89825 RVA: 0x006179A0 File Offset: 0x00615BA0
	private void RefreshLock(ISurvivorsRogueCardBase data)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(6);
		bool valueOrDefault = data.NeedLock.GetValueOrDefault();
		bool valueOrDefault2 = data.LockState.GetValueOrDefault();
		extendToggle.RootUIComp.Get().SetUIActive(valueOrDefault);
		extendToggle.SetToggleStateForce(valueOrDefault2 ? EToggleState.ETT_UnChecked : EToggleState.ETT_Checked, false, false, false);
	}

	// Token: 0x06015EE2 RID: 89826 RVA: 0x006179F5 File Offset: 0x00615BF5
	public void SetDebugText(string debugTxt)
	{
		base.GetText(10).SetUIActive(false);
	}

	// Token: 0x06015EE3 RID: 89827 RVA: 0x00617A05 File Offset: 0x00615C05
	private void OnClickLock(EToggleState toggleState)
	{
		if (this.Data != null && this.LockFunction != null)
		{
			this.LockFunction(this.Data, toggleState == EToggleState.ETT_UnChecked);
		}
	}

	// Token: 0x06015EE4 RID: 89828 RVA: 0x00617A2C File Offset: 0x00615C2C
	public void SetLock(bool bLock)
	{
		base.GetExtendToggle(6).SetToggleStateForce(bLock ? EToggleState.ETT_UnChecked : EToggleState.ETT_Checked, false, false, false);
	}

	// Token: 0x06015EE5 RID: 89829 RVA: 0x00617A44 File Offset: 0x00615C44
	public void BindLockFunction(Action<ISurvivorsRogueCardBase, bool> lockFunction)
	{
		this.LockFunction = lockFunction;
	}

	// Token: 0x06015EE6 RID: 89830 RVA: 0x00617A50 File Offset: 0x00615C50
	private UniTask RefreshCharacterType(ISurvivorsRogueCharacterCard data)
	{
		return this.RefreshComponent(typeof(SurvivorsRogueCardComponentRoleItem), data.Id > 0, new object[]
		{
			data.Id,
			data.PropertyId
		}).AsUniTask();
	}

	// Token: 0x06015EE7 RID: 89831 RVA: 0x00617AA0 File Offset: 0x00615CA0
	private UniTask RefreshWeaponType(ISurvivorsRogueWeaponCard data)
	{
		return this.RefreshComponent(typeof(SurvivorsRogueCardComponentWeaponItem), data.Id > 0, new object[]
		{
			data.Id,
			data.QualityId,
			data.PropertyId
		}).AsUniTask();
	}

	// Token: 0x06015EE8 RID: 89832 RVA: 0x00617B00 File Offset: 0x00615D00
	private UniTask RefreshLvDesc(int? lv, ESurvivorsRogueItemType type)
	{
		return this.RefreshComponent(typeof(SurvivorsRogueCardComponentLvDesc), lv != null && lv.Value > 0, new object[]
		{
			lv,
			type
		}).AsUniTask();
	}

	// Token: 0x06015EE9 RID: 89833 RVA: 0x00617B54 File Offset: 0x00615D54
	private UniTask RefreshEvolveBind(int weaponId, bool bShow)
	{
		return this.RefreshComponent(typeof(SurvivorsRogueCardComponentEvolveBond), bShow, new object[]
		{
			bShow ? weaponId : null
		}).AsUniTask();
	}

	// Token: 0x06015EEA RID: 89834 RVA: 0x00617B90 File Offset: 0x00615D90
	public UniTask RefreshCost(int? cost, bool bCreate, bool costCheckEnough)
	{
		return this.RefreshComponent(typeof(SurvivorsRogueCardCostItem), bCreate, new object[]
		{
			cost,
			costCheckEnough
		}).AsUniTask();
	}

	// Token: 0x06015EEB RID: 89835 RVA: 0x00617BCE File Offset: 0x00615DCE
	[NullableContext(2)]
	public UUIItem GetTextureIconItem()
	{
		return base.GetTexture(2);
	}

	// Token: 0x06015EEC RID: 89836 RVA: 0x00617BD7 File Offset: 0x00615DD7
	[NullableContext(2)]
	protected UUIExtendToggle GetCardToggle()
	{
		return base.GetExtendToggle(0);
	}

	// Token: 0x06015EED RID: 89837 RVA: 0x00617BE0 File Offset: 0x00615DE0
	protected void AddEvents()
	{
		UUIExtendToggle cardToggle = this.GetCardToggle();
		cardToggle.OnStateChange.Add(new Action<EToggleState>(this.ExtendToggleStateChanged));
		cardToggle.CanExecuteChange.Bind(new Func<bool>(this.CanExecuteChange));
		cardToggle.OnHover.Add(new Action(this.ExtendToggleOnHover));
		cardToggle.OnUnHover.Add(new Action(this.ExtendToggleOnUnHover));
	}

	// Token: 0x06015EEE RID: 89838 RVA: 0x00617C4E File Offset: 0x00615E4E
	protected void RemoveEvents()
	{
		UUIExtendToggle cardToggle = this.GetCardToggle();
		cardToggle.OnStateChange.Remove(new Action<EToggleState>(this.ExtendToggleStateChanged));
		cardToggle.CanExecuteChange.Unbind();
		cardToggle.OnHover.Clear();
		cardToggle.OnUnHover.Clear();
	}

	// Token: 0x06015EEF RID: 89839 RVA: 0x00617C8D File Offset: 0x00615E8D
	private void ExtendToggleStateChanged(EToggleState state)
	{
		this.OnExtendToggleStateChanged(state);
		if (this.OnStateChangedCallback != null && this.Data != null)
		{
			this.OnStateChangedCallback(this.Data, state);
		}
	}

	// Token: 0x06015EF0 RID: 89840 RVA: 0x00617CB8 File Offset: 0x00615EB8
	protected virtual void OnExtendToggleStateChanged(EToggleState state)
	{
	}

	// Token: 0x06015EF1 RID: 89841 RVA: 0x00617CBA File Offset: 0x00615EBA
	private bool CanExecuteChange()
	{
		if (this.OnCanExecuteChangeCallback != null && this.Data != null)
		{
			return this.OnCanExecuteChangeCallback(this.Data, this.GetCardToggle().GetToggleState());
		}
		return this.OnCanExecuteChange();
	}

	// Token: 0x06015EF2 RID: 89842 RVA: 0x00617CEF File Offset: 0x00615EEF
	protected virtual bool OnCanExecuteChange()
	{
		return true;
	}

	// Token: 0x06015EF3 RID: 89843 RVA: 0x00617CF2 File Offset: 0x00615EF2
	private void ExtendToggleOnHover()
	{
		if (this.OnHoverCallback != null && this.Data != null)
		{
			this.OnHoverCallback(this.Data, this.GetCardToggle().GetToggleState());
		}
	}

	// Token: 0x06015EF4 RID: 89844 RVA: 0x00617D20 File Offset: 0x00615F20
	private void ExtendToggleOnUnHover()
	{
		if (this.OnUnHoverCallback != null && this.Data != null)
		{
			this.OnUnHoverCallback(this.Data, this.GetCardToggle().GetToggleState());
		}
	}

	// Token: 0x06015EF5 RID: 89845 RVA: 0x00617D4E File Offset: 0x00615F4E
	public void BindOnStateChangeCallback(Action<ISurvivorsRogueCardBase, EToggleState> onStateChangeCallback)
	{
		this.OnStateChangedCallback = onStateChangeCallback;
	}

	// Token: 0x06015EF6 RID: 89846 RVA: 0x00617D57 File Offset: 0x00615F57
	public void UnBindOnStateChangeCallback()
	{
		this.OnStateChangedCallback = null;
	}

	// Token: 0x06015EF7 RID: 89847 RVA: 0x00617D60 File Offset: 0x00615F60
	public void BindOnCanExecuteChangeCallback(Func<ISurvivorsRogueCardBase, EToggleState, bool> onCanExecuteChangeCallback)
	{
		this.OnCanExecuteChangeCallback = onCanExecuteChangeCallback;
	}

	// Token: 0x06015EF8 RID: 89848 RVA: 0x00617D69 File Offset: 0x00615F69
	public void BindOnHoverCallback(Action<ISurvivorsRogueCardBase, EToggleState> onHoverCallback)
	{
		this.OnHoverCallback = onHoverCallback;
	}

	// Token: 0x06015EF9 RID: 89849 RVA: 0x00617D72 File Offset: 0x00615F72
	public void BindOnUnHoverCallback(Action<ISurvivorsRogueCardBase, EToggleState> onUnHoverCallback)
	{
		this.OnUnHoverCallback = onUnHoverCallback;
	}

	// Token: 0x06015EFA RID: 89850 RVA: 0x00617D7C File Offset: 0x00615F7C
	public void SetSelected(bool bSelected, bool bFireEvent = false, bool bForce = false)
	{
		UUIExtendToggle cardToggle = this.GetCardToggle();
		EToggleState state = bSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		if (bForce)
		{
			cardToggle.SetToggleStateForce(state, bFireEvent, false, false);
			return;
		}
		cardToggle.SetToggleState(state, bFireEvent, false, false);
	}

	// Token: 0x06015EFB RID: 89851 RVA: 0x00617DB1 File Offset: 0x00615FB1
	public void SetToggleInteractive(bool bInteractive)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetSelfInteractive(bInteractive);
	}

	// Token: 0x06015EFC RID: 89852 RVA: 0x00617DC8 File Offset: 0x00615FC8
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (configParams == null || configParams.Length == 0)
		{
			return null;
		}
		SurvivorsRogueCardComponent survivorsRogueCardComponent;
		if (!(configParams[0] == "WeaponEvolve") || !this.ComponentMap.TryGetValue(typeof(SurvivorsRogueCardComponentEvolveBond), out survivorsRogueCardComponent))
		{
			return null;
		}
		UUIItem guideUiItem = survivorsRogueCardComponent.GetGuideUiItem("0");
		if (guideUiItem == null)
		{
			return null;
		}
		return new UUIItem[]
		{
			guideUiItem,
			guideUiItem
		};
	}

	// Token: 0x06015EFD RID: 89853 RVA: 0x00617E28 File Offset: 0x00616028
	public bool HasBondInfo()
	{
		ISurvivorsRogueWeaponCard survivorsRogueWeaponCard = this.Data as ISurvivorsRogueWeaponCard;
		return ((survivorsRogueWeaponCard != null) ? survivorsRogueWeaponCard.WeaponBondInfo : null).GetValueOrDefault();
	}

	// Token: 0x0400A889 RID: 43145
	[Nullable(2)]
	protected ISurvivorsRogueCardBase Data;

	// Token: 0x0400A88A RID: 43146
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Func<ISurvivorsRogueCardBase, EToggleState, bool> OnCanExecuteChangeCallback;

	// Token: 0x0400A88B RID: 43147
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<ISurvivorsRogueCardBase, EToggleState> OnStateChangedCallback;

	// Token: 0x0400A88C RID: 43148
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<ISurvivorsRogueCardBase, EToggleState> OnHoverCallback;

	// Token: 0x0400A88D RID: 43149
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<ISurvivorsRogueCardBase, EToggleState> OnUnHoverCallback;

	// Token: 0x0400A88E RID: 43150
	private readonly HashSet<SurvivorsRogueCardComponent> VisibleComponents = new HashSet<SurvivorsRogueCardComponent>();

	// Token: 0x0400A88F RID: 43151
	private readonly Dictionary<Type, SurvivorsRogueCardComponent> ComponentMap = new Dictionary<Type, SurvivorsRogueCardComponent>();

	// Token: 0x0400A890 RID: 43152
	private readonly List<SurvivorsRogueCardComponent> CenterComponentList = new List<SurvivorsRogueCardComponent>();

	// Token: 0x0400A891 RID: 43153
	private readonly List<SurvivorsRogueCardComponent> BottomComponentList = new List<SurvivorsRogueCardComponent>();

	// Token: 0x0400A892 RID: 43154
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected Action<ISurvivorsRogueCardBase, bool> LockFunction;
}
