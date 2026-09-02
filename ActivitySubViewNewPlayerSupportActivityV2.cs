using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001465 RID: 5221
[NullableContext(1)]
[Nullable(0)]
public class ActivitySubViewNewPlayerSupportActivityV2 : ActivitySubViewBase
{
	// Token: 0x060091C8 RID: 37320 RVA: 0x002672F7 File Offset: 0x002654F7
	protected override void OnSetData()
	{
		this.ActivityData = (this.ActivityBaseData as ActivityNewPlayerSupportActivityV2Data);
	}

	// Token: 0x060091C9 RID: 37321 RVA: 0x0026730C File Offset: 0x0026550C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 14;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 5;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickRole));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickAdventureView));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickShopEntrance));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnClickGachaEntrance));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickTrial));
		this.BtnBindInfo = list2;
	}

	// Token: 0x060091CA RID: 37322 RVA: 0x002675D0 File Offset: 0x002657D0
	protected override void OnStart()
	{
		this.RemainTimeText = (ConfigMultiTextLang.GetLocalTextNew("ActivityRemainingTime", null) ?? string.Empty);
		UUIText text = base.GetText(0);
		if (text != null)
		{
			ActivityNewPlayerSupportActivityV2Data activityData = this.ActivityData;
			text.SetText(((activityData != null) ? activityData.GetTitle() : null) ?? string.Empty, true);
		}
		UUIItem item = base.GetItem(13);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		this.RefreshViewState();
	}

	// Token: 0x060091CB RID: 37323 RVA: 0x0026763F File Offset: 0x0026583F
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshRedDot));
		Singleton<EventSystem>.Instance.Add<EFunctionType, bool>(EEventName.OnFunctionOpenUpdate, new Action<EFunctionType, bool>(this.OnFunctionOpenChanged));
	}

	// Token: 0x060091CC RID: 37324 RVA: 0x00267679 File Offset: 0x00265879
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshRedDot));
		Singleton<EventSystem>.Instance.Remove<EFunctionType, bool>(EEventName.OnFunctionOpenUpdate, new Action<EFunctionType, bool>(this.OnFunctionOpenChanged));
	}

	// Token: 0x060091CD RID: 37325 RVA: 0x002676B3 File Offset: 0x002658B3
	protected override void OnTimer(float gap)
	{
		this.RefreshRemainTime();
	}

	// Token: 0x060091CE RID: 37326 RVA: 0x002676BB File Offset: 0x002658BB
	protected override void OnRefreshView()
	{
		this.RefreshViewState();
	}

	// Token: 0x060091CF RID: 37327 RVA: 0x002676C3 File Offset: 0x002658C3
	private void RefreshViewState()
	{
		this.RefreshRemainTime();
		this.RefreshTrialRoleDisplay();
		this.RefreshGachaEntrance2Visual();
		this.RefreshRoleEntranceCompositeVisual();
		this.RefreshEntranceRedDot();
	}

	// Token: 0x060091D0 RID: 37328 RVA: 0x002676E4 File Offset: 0x002658E4
	private void RefreshRemainTime()
	{
		if (this.ActivityData == null)
		{
			return;
		}
		UUIText text = base.GetText(1);
		if (text == null)
		{
			return;
		}
		long displayRemainEndTime = this.ActivityData.GetDisplayRemainEndTime();
		if (displayRemainEndTime <= 0L || !this.ActivityData.CheckIfInShowTime())
		{
			text.SetUIActive(false);
			return;
		}
		string remainTimeText = ModelBase<ActivityModel>.Instance.GetRemainTimeText(displayRemainEndTime, this.RemainTimeText);
		text.SetUIActive(true);
		text.SetText(remainTimeText ?? string.Empty, true);
	}

	// Token: 0x060091D1 RID: 37329 RVA: 0x00267758 File Offset: 0x00265958
	private void OnRefreshRedDot(int activityId)
	{
		ActivityNewPlayerSupportActivityV2Data activityData = this.ActivityData;
		int? num = (activityData != null) ? new int?(activityData.Id) : null;
		if (!(activityId == num.GetValueOrDefault() & num != null))
		{
			return;
		}
		this.RefreshViewState();
	}

	// Token: 0x060091D2 RID: 37330 RVA: 0x002677A0 File Offset: 0x002659A0
	private void OnFunctionOpenChanged(EFunctionType functionType, bool isOpen)
	{
		if (functionType == EFunctionType.DailyActivity)
		{
			this.RefreshViewState();
		}
	}

	// Token: 0x060091D3 RID: 37331 RVA: 0x002677B0 File Offset: 0x002659B0
	private void OnClickRole()
	{
		ActivityNewPlayerSupportActivityV2Controller.ReportEntranceClick(ENewPlayerSupportEntrance.Liveness);
		if (!ActivitySubViewNewPlayerSupportActivityV2.IsExperienceBonusLivenessEntranceUnlocked())
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("NewPlayer_Experience_002", Array.Empty<object>());
			return;
		}
		ActivityNewPlayerSupportActivityV2Data activityData = this.ActivityData;
		if (activityData != null)
		{
			activityData.MarkLivenessEntranceClicked();
		}
		AdventureGuideViewOpenData param = new AdventureGuideViewOpenData
		{
			OpenTabViewName = new EUiTabViewName?(EUiTabViewName.DailyActivityTabView),
			SkipAdventureManualRequest = true
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.AdventureGuideView, param, null);
	}

	// Token: 0x060091D4 RID: 37332 RVA: 0x0026781E File Offset: 0x00265A1E
	private void OnClickAdventureView()
	{
		ActivityNewPlayerSupportActivityV2Controller.ReportEntranceClick(ENewPlayerSupportEntrance.GiftPack);
		ActivityNewPlayerSupportActivityV2Data activityData = this.ActivityData;
		if (activityData != null)
		{
			activityData.MarkGiftPackEntranceClicked();
		}
		ActivityNewPlayerSupportActivityV2Controller controller = this.GetController();
		if (controller == null)
		{
			return;
		}
		controller.OpenAdventureV2View();
	}

	// Token: 0x060091D5 RID: 37333 RVA: 0x00267847 File Offset: 0x00265A47
	private void OnClickShopEntrance()
	{
		ActivityNewPlayerSupportActivityV2Controller.ReportEntranceClick(ENewPlayerSupportEntrance.WeekCard);
		ActivityNewPlayerSupportActivityV2Data activityData = this.ActivityData;
		if (activityData != null)
		{
			activityData.MarkWeekCardEntranceClicked();
		}
		PayShopController instance = ControllerBase<PayShopController>.Instance;
		Func<PayShopJumpParam> tabResolver;
		if ((tabResolver = ActivitySubViewNewPlayerSupportActivityV2.<>O.<0>__ResolveWeekCardShopJumpParam) == null)
		{
			tabResolver = (ActivitySubViewNewPlayerSupportActivityV2.<>O.<0>__ResolveWeekCardShopJumpParam = new Func<PayShopJumpParam>(ActivityNewPlayerSupportActivityV2Controller.ResolveWeekCardShopJumpParam));
		}
		instance.OpenPayShopViewWithTabResolver(tabResolver);
	}

	// Token: 0x060091D6 RID: 37334 RVA: 0x00267888 File Offset: 0x00265A88
	private void OnClickGachaEntrance()
	{
		ActivityNewPlayerSupportActivityV2Controller.ReportEntranceClick(ENewPlayerSupportEntrance.Gacha);
		ActivityNewPlayerSupportActivityV2Data activityData = this.ActivityData;
		if (activityData != null)
		{
			activityData.MarkGachaEntranceClicked();
		}
		ActivityNewPlayerSupportActivityV2Data activityData2 = this.ActivityData;
		int? num = (activityData2 != null) ? activityData2.GetGachaOpenTabIdOrDefault() : null;
		ControllerBase<GachaController>.Instance.OpenGachaView(num.GetValueOrDefault());
	}

	// Token: 0x060091D7 RID: 37335 RVA: 0x002678D8 File Offset: 0x00265AD8
	private void OnClickTrial()
	{
		ActivityNewPlayerSupportActivityV2Controller controller = this.GetController();
		if (controller == null)
		{
			return;
		}
		controller.OpenTrialRoleView(null);
	}

	// Token: 0x060091D8 RID: 37336 RVA: 0x002678FE File Offset: 0x00265AFE
	[NullableContext(2)]
	private ActivityNewPlayerSupportActivityV2Controller GetController()
	{
		if (this.ActivityData == null || this.ActivityData.Type == ActivityType.Parkour)
		{
			return null;
		}
		return ActivityManager.GetActivityController(this.ActivityData.Type) as ActivityNewPlayerSupportActivityV2Controller;
	}

	// Token: 0x060091D9 RID: 37337 RVA: 0x0026792C File Offset: 0x00265B2C
	private void RefreshTrialRoleDisplay()
	{
		ActivityNewPlayerSupportActivityV2Data activityData = this.ActivityData;
		int? num;
		if (activityData == null)
		{
			num = null;
		}
		else
		{
			TrialRoleGroupData curUseTrialRoleData = activityData.CurUseTrialRoleData;
			num = ((curUseTrialRoleData != null) ? new int?(curUseTrialRoleData.RealRoleId) : null);
		}
		int? num2 = num;
		int valueOrDefault = num2.GetValueOrDefault();
		bool flag = valueOrDefault > 0;
		bool isRover = flag && ModelBase<RoleModel>.Instance.IsMainRole(valueOrDefault);
		RoleInfo? roleConfig = flag ? ConfigBase<RoleConfig>.Instance.GetRoleConfig(valueOrDefault) : null;
		ActivityNewPlayerSupportActivityV2Data activityData2 = this.ActivityData;
		ValueTuple<string, string>? valueTuple = (activityData2 != null) ? activityData2.GetCurrentTrialRoleDisplayResourceIds() : null;
		this.RefreshRoleRelatedPanels(flag);
		string text;
		if ((text = this.ResolveTexturePath((valueTuple != null) ? valueTuple.GetValueOrDefault().Item2 : null)) == null)
		{
			text = (((roleConfig != null) ? roleConfig.GetValueOrDefault().Card : null) ?? string.Empty);
		}
		string bgPath = text;
		string text2;
		if (!flag)
		{
			text2 = this.GetSilhouetteTexturePathByGender();
		}
		else if ((text2 = this.ResolveTexturePath((valueTuple != null) ? valueTuple.GetValueOrDefault().Item1 : null)) == null)
		{
			text2 = (((roleConfig != null) ? roleConfig.GetValueOrDefault().FormationRoleCard : null) ?? string.Empty);
		}
		string rolePath = text2;
		this.RefreshBgTexture(flag, isRover, bgPath);
		this.RefreshRoleTexture(flag, rolePath);
		this.RefreshTrialButtonText(flag, roleConfig);
	}

	// Token: 0x060091DA RID: 37338 RVA: 0x00267A88 File Offset: 0x00265C88
	private void RefreshTrialButtonText(bool hasRole, RoleInfo? roleConfig)
	{
		UUIText text = base.GetText(12);
		if (text == null)
		{
			return;
		}
		text.SetGameRichText(true);
		text.SetRichText(true);
		if (hasRole && roleConfig != null)
		{
			string text2 = ConfigMultiTextLang.GetLocalTextNew(roleConfig.Value.Name, null) ?? string.Empty;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "NewPlayer_Trial_002", new string[]
			{
				text2
			});
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "NewPlayer_Trial_001", Array.Empty<object>());
	}

	// Token: 0x060091DB RID: 37339 RVA: 0x00267B0B File Offset: 0x00265D0B
	private void RefreshRoleRelatedPanels(bool hasRole)
	{
		UUIItem item = base.GetItem(7);
		if (item != null)
		{
			item.SetUIActive(hasRole);
		}
		UUIItem item2 = base.GetItem(8);
		if (item2 != null)
		{
			item2.SetUIActive(hasRole);
		}
		UUIItem item3 = base.GetItem(11);
		if (item3 == null)
		{
			return;
		}
		item3.SetUIActive(!hasRole);
	}

	// Token: 0x060091DC RID: 37340 RVA: 0x00267B4C File Offset: 0x00265D4C
	private void RefreshBgTexture(bool hasRole, bool isRover, string bgPath)
	{
		UUITexture texture = base.GetTexture(9);
		if (texture == null)
		{
			return;
		}
		bool flag = hasRole && !isRover && !string.IsNullOrEmpty(bgPath);
		texture.SetUIActive(flag);
		if (flag)
		{
			base.SetTextureByPath(bgPath, texture, null, null);
		}
	}

	// Token: 0x060091DD RID: 37341 RVA: 0x00267B98 File Offset: 0x00265D98
	private void RefreshRoleTexture(bool hasRole, string rolePath)
	{
		UUITexture texture = base.GetTexture(10);
		if (texture == null)
		{
			return;
		}
		bool flag = !string.IsNullOrEmpty(rolePath);
		texture.SetUIActive(flag);
		if (flag)
		{
			base.SetTextureByPath(rolePath, texture, null, null);
		}
	}

	// Token: 0x060091DE RID: 37342 RVA: 0x00267BD8 File Offset: 0x00265DD8
	private string GetSilhouetteTexturePathByGender()
	{
		string resourceIdOrPath = (ModelBase<PlayerInfoModel>.Instance.GetPlayerGender() == EPlayerGender.Male) ? "T_PrivilegeRoleRoverMale" : "T_PrivilegeRoleRoverFemale";
		return this.ResolveTexturePath(resourceIdOrPath) ?? string.Empty;
	}

	// Token: 0x060091DF RID: 37343 RVA: 0x00267C10 File Offset: 0x00265E10
	[NullableContext(2)]
	private string ResolveTexturePath(string resourceIdOrPath)
	{
		if (string.IsNullOrWhiteSpace(resourceIdOrPath))
		{
			return null;
		}
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceIdOrPath.Trim());
		if (!string.IsNullOrWhiteSpace(resourcePath))
		{
			return resourcePath;
		}
		return null;
	}

	// Token: 0x060091E0 RID: 37344 RVA: 0x00267C44 File Offset: 0x00265E44
	private void RefreshEntranceRedDot()
	{
		UUIItem item = base.GetItem(13);
		if (item != null)
		{
			ActivityNewPlayerSupportActivityV2Data activityData = this.ActivityData;
			item.SetUIActive(activityData != null && activityData.GetTrialRoleEntranceRedDotState());
		}
		int componentType = 2;
		ActivityNewPlayerSupportActivityV2Data activityData2 = this.ActivityData;
		this.SetEntranceButtonRedDotVisible(componentType, activityData2 != null && activityData2.GetLivenessEntranceRedDotState());
		int componentType2 = 3;
		ActivityNewPlayerSupportActivityV2Data activityData3 = this.ActivityData;
		this.SetEntranceButtonRedDotVisible(componentType2, activityData3 != null && activityData3.GetGiftPackEntranceRedDotState());
		int componentType3 = 4;
		ActivityNewPlayerSupportActivityV2Data activityData4 = this.ActivityData;
		this.SetEntranceButtonRedDotVisible(componentType3, activityData4 != null && activityData4.GetWeekCardEntranceRedDotState());
		int componentType4 = 5;
		ActivityNewPlayerSupportActivityV2Data activityData5 = this.ActivityData;
		this.SetEntranceButtonRedDotVisible(componentType4, activityData5 != null && activityData5.GetGachaEntranceRedDotState());
	}

	// Token: 0x060091E1 RID: 37345 RVA: 0x00267CDC File Offset: 0x00265EDC
	private void RefreshGachaEntrance2Visual()
	{
		UUIItem uuiitem = this.TryGetNestedUiItem(5, 1);
		UUIItem uuiitem2 = this.TryGetNestedUiItem(5, 2);
		if (uuiitem != null)
		{
			uuiitem.SetUIActive(true);
		}
		if (uuiitem2 != null)
		{
			uuiitem2.SetUIActive(false);
		}
	}

	// Token: 0x060091E2 RID: 37346 RVA: 0x00267D10 File Offset: 0x00265F10
	private void RefreshRoleEntranceCompositeVisual()
	{
		bool flag = ActivitySubViewNewPlayerSupportActivityV2.IsExperienceBonusLivenessEntranceUnlocked();
		UUIItem uuiitem = this.TryGetNestedUiItem(2, 1);
		UUIItem uuiitem2 = this.TryGetNestedUiItem(2, 2);
		UUIText uuitext = this.TryGetNestedText(2, 3);
		if (uuiitem != null || uuiitem2 != null)
		{
			if (uuiitem != null)
			{
				uuiitem.SetUIActive(flag);
			}
			if (uuiitem2 != null)
			{
				uuiitem2.SetUIActive(!flag);
			}
		}
		if (uuitext != null)
		{
			if (flag)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(uuitext, "NewPlayer_Experience_004", Array.Empty<object>());
			}
			else
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(uuitext, "NewPlayer_Experience_003", Array.Empty<object>());
			}
		}
		this.ApplyExperienceBonusRoleButtonLockExtension(!flag);
	}

	// Token: 0x060091E3 RID: 37347 RVA: 0x00267D97 File Offset: 0x00265F97
	private static bool IsExperienceBonusLivenessEntranceUnlocked()
	{
		return ModelBase<FunctionModel>.Instance.IsOpen(10023005);
	}

	// Token: 0x060091E4 RID: 37348 RVA: 0x00267DA8 File Offset: 0x00265FA8
	private void ApplyExperienceBonusRoleButtonLockExtension(bool showLockVisual)
	{
		UUIButtonComponent button = base.GetButton(2);
		if (button == null)
		{
			return;
		}
		button.SetSelfInteractive(true);
		button.SetEnable(true);
		ActivitySubViewNewPlayerSupportActivityV2.InvokeOptionalButtonMethod(button, "SetLivenessLock", showLockVisual);
		ActivitySubViewNewPlayerSupportActivityV2.InvokeOptionalButtonMethod(button, "RefreshLivenessLock", showLockVisual);
		ActivitySubViewNewPlayerSupportActivityV2.InvokeOptionalButtonMethod(button, "SetShowLock", showLockVisual);
	}

	// Token: 0x060091E5 RID: 37349 RVA: 0x00267DF4 File Offset: 0x00265FF4
	private static void InvokeOptionalButtonMethod(UUIButtonComponent button, string methodName, bool arg)
	{
		MethodInfo method = button.GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public);
		ParameterInfo[] array = (method != null) ? method.GetParameters() : null;
		if (array != null && array.Length == 1 && array[0].ParameterType == typeof(bool))
		{
			method.Invoke(button, new object[]
			{
				arg
			});
		}
	}

	// Token: 0x060091E6 RID: 37350 RVA: 0x00267E58 File Offset: 0x00266058
	[NullableContext(2)]
	private ULGUIComponentsRegistry GetNestedRegistryForButton(int buttonType)
	{
		UUIButtonComponent button = base.GetButton(buttonType);
		AUIBaseActor auibaseActor = ((button != null) ? button.GetOwner() : null) as AUIBaseActor;
		if (auibaseActor == null || !auibaseActor.IsValid())
		{
			return null;
		}
		ULGUIComponentsRegistry ulguicomponentsRegistry = Singleton<LguiUtil>.Instance.GetComponentsRegistry(auibaseActor);
		if (ulguicomponentsRegistry == null || !ulguicomponentsRegistry.IsValid())
		{
			AUIBaseActor auibaseActor2 = Singleton<LguiUtil>.Instance.GetChildActorByHierarchyIndex(auibaseActor, 0);
			ulguicomponentsRegistry = ((auibaseActor2 != null) ? Singleton<LguiUtil>.Instance.GetComponentsRegistry(auibaseActor2) : null);
			if (ulguicomponentsRegistry == null || !ulguicomponentsRegistry.IsValid())
			{
				auibaseActor2 = ((auibaseActor2 != null) ? Singleton<LguiUtil>.Instance.GetChildActorByHierarchyIndex(auibaseActor2, 0) : null);
				ulguicomponentsRegistry = ((auibaseActor2 != null) ? Singleton<LguiUtil>.Instance.GetComponentsRegistry(auibaseActor2) : null);
			}
		}
		if (ulguicomponentsRegistry == null || !ulguicomponentsRegistry.IsValid())
		{
			return null;
		}
		return ulguicomponentsRegistry;
	}

	// Token: 0x060091E7 RID: 37351 RVA: 0x00267F04 File Offset: 0x00266104
	[NullableContext(2)]
	private UUIItem TryGetNestedUiItem(int buttonType, int index)
	{
		ULGUIComponentsRegistry nestedRegistryForButton = this.GetNestedRegistryForButton(buttonType);
		if (nestedRegistryForButton == null || index >= nestedRegistryForButton.Components.Num())
		{
			return null;
		}
		AActor aactor = nestedRegistryForButton.Components.Get(index);
		return ((aactor != null) ? aactor.GetComponentByClass(UUIItem.StaticClass()) : null) as UUIItem;
	}

	// Token: 0x060091E8 RID: 37352 RVA: 0x00267F54 File Offset: 0x00266154
	[NullableContext(2)]
	private UUIText TryGetNestedText(int buttonType, int index)
	{
		ULGUIComponentsRegistry nestedRegistryForButton = this.GetNestedRegistryForButton(buttonType);
		if (nestedRegistryForButton == null || index >= nestedRegistryForButton.Components.Num())
		{
			return null;
		}
		AActor aactor = nestedRegistryForButton.Components.Get(index);
		return ((aactor != null) ? aactor.GetComponentByClass(UUIText.StaticClass()) : null) as UUIText;
	}

	// Token: 0x060091E9 RID: 37353 RVA: 0x00267FA4 File Offset: 0x002661A4
	private void SetEntranceButtonRedDotVisible(int componentType, bool visible)
	{
		UUIItem uuiitem = this.TryGetNestedUiItem(componentType, 4);
		if (uuiitem != null)
		{
			uuiitem.SetUIActive(visible);
			return;
		}
		UUIButtonComponent button = base.GetButton(componentType);
		MethodInfo methodInfo = (button != null) ? button.GetType().GetMethod("SetRedDotVisible", new Type[]
		{
			typeof(bool)
		}) : null;
		if (methodInfo == null)
		{
			return;
		}
		methodInfo.Invoke(button, new object[]
		{
			visible
		});
	}

	// Token: 0x060091EA RID: 37354 RVA: 0x00268014 File Offset: 0x00266214
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (!(configParams[0] == "TrialRoleBtn"))
		{
			return null;
		}
		UUIButtonComponent button = base.GetButton(6);
		UUIItem uuiitem = (button != null) ? button.RootUIComp.Get() : null;
		if (uuiitem == null)
		{
			return null;
		}
		return new UUIItem[]
		{
			uuiitem,
			uuiitem
		};
	}

	// Token: 0x040043A2 RID: 17314
	private const string NewPlayerSupportV2MaleSilhouetteResourceId = "T_PrivilegeRoleRoverMale";

	// Token: 0x040043A3 RID: 17315
	private const string NewPlayerSupportV2FemaleSilhouetteResourceId = "T_PrivilegeRoleRoverFemale";

	// Token: 0x040043A4 RID: 17316
	[Nullable(2)]
	private ActivityNewPlayerSupportActivityV2Data ActivityData;

	// Token: 0x040043A5 RID: 17317
	private string RemainTimeText = string.Empty;

	// Token: 0x02007865 RID: 30821
	[NullableContext(0)]
	private class EComponentType
	{
		// Token: 0x04029684 RID: 169604
		public const int TxtTitle = 0;

		// Token: 0x04029685 RID: 169605
		public const int TxtRestTime = 1;

		// Token: 0x04029686 RID: 169606
		public const int BtnRole = 2;

		// Token: 0x04029687 RID: 169607
		public const int BtnGift = 3;

		// Token: 0x04029688 RID: 169608
		public const int BtnLuckDraw = 4;

		// Token: 0x04029689 RID: 169609
		public const int BtnEntrance2 = 5;

		// Token: 0x0402968A RID: 169610
		public const int BtnTrial = 6;

		// Token: 0x0402968B RID: 169611
		public const int TrialRoleStarLayout = 7;

		// Token: 0x0402968C RID: 169612
		public const int Star = 8;

		// Token: 0x0402968D RID: 169613
		public const int TexBg = 9;

		// Token: 0x0402968E RID: 169614
		public const int TexRole = 10;

		// Token: 0x0402968F RID: 169615
		public const int RoverDecoration = 11;

		// Token: 0x04029690 RID: 169616
		public const int TxtBtnTrialName = 12;

		// Token: 0x04029691 RID: 169617
		public const int TrialBtnRedDot = 13;
	}

	// Token: 0x02007866 RID: 30822
	[NullableContext(0)]
	private static class ECompositeEntranceNested
	{
		// Token: 0x04029692 RID: 169618
		public const int PnlIconNor = 1;

		// Token: 0x04029693 RID: 169619
		public const int IconLock = 2;

		// Token: 0x04029694 RID: 169620
		public const int TxtDescription = 3;

		// Token: 0x04029695 RID: 169621
		public const int RedDot = 4;
	}

	// Token: 0x02007867 RID: 30823
	[CompilerGenerated]
	private static class <>O
	{
		// Token: 0x04029696 RID: 169622
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public static Func<PayShopJumpParam> <0>__ResolveWeekCardShopJumpParam;
	}
}
