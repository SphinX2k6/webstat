using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002B10 RID: 11024
[NullableContext(2)]
[Nullable(0)]
public class SurvivorsTabMainView : UiViewBase
{
	// Token: 0x06016060 RID: 90208 RVA: 0x0061C432 File Offset: 0x0061A632
	[NullableContext(1)]
	public SurvivorsTabMainView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06016061 RID: 90209 RVA: 0x0061C450 File Offset: 0x0061A650
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(7, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(6, new Action(this.GoRight)),
			new ValueTuple<int, Delegate>(7, new Action(this.GoLeft))
		};
	}

	// Token: 0x06016062 RID: 90210 RVA: 0x0061C554 File Offset: 0x0061A754
	protected override UniTask OnBeforeStartAsync()
	{
		SurvivorsTabMainView.<OnBeforeStartAsync>d__16 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<SurvivorsTabMainView.<OnBeforeStartAsync>d__16>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06016063 RID: 90211 RVA: 0x0061C597 File Offset: 0x0061A797
	protected override void OnStart()
	{
		this.RefreshCaption();
		this.RefreshTabs();
		this.RefreshDefaultSelectedTab();
	}

	// Token: 0x06016064 RID: 90212 RVA: 0x0061C5AC File Offset: 0x0061A7AC
	protected override void OnBeforeDestroy()
	{
		if (this.LevelSequencePlayerList != null)
		{
			foreach (LevelSequencePlayer levelSequencePlayer in this.LevelSequencePlayerList)
			{
				levelSequencePlayer.Clear();
			}
		}
		this.LevelSequencePlayerList = null;
	}

	// Token: 0x06016065 RID: 90213 RVA: 0x0061C60C File Offset: 0x0061A80C
	private void RefreshDefaultSelectedTab()
	{
		SurvivorsTabMainViewData survivorsTabMainViewData = this.OpenParam as SurvivorsTabMainViewData;
		if (survivorsTabMainViewData == null)
		{
			SurvivorsTabMainTabItem roleTab = this.RoleTab;
			if (roleTab == null)
			{
				return;
			}
			roleTab.SetForceSwitch(EToggleState.ETT_Checked, true);
			return;
		}
		else
		{
			ETabType? skipTabType = survivorsTabMainViewData.SkipTabType;
			if (skipTabType != null)
			{
				ETabType valueOrDefault = skipTabType.GetValueOrDefault();
				if (valueOrDefault != ETabType.Weapon)
				{
					if (valueOrDefault == ETabType.Item)
					{
						SurvivorsTabMainTabItem itemTab = this.ItemTab;
						if (itemTab == null)
						{
							return;
						}
						itemTab.SetForceSwitch(EToggleState.ETT_Checked, true);
						return;
					}
				}
				else
				{
					int? num = null;
					if (survivorsTabMainViewData.SkipWeaponId != null)
					{
						int num2 = 0;
						for (;;)
						{
							int num3 = num2;
							List<ISurvivorsWeaponGridData> cachedWeaponGridDataList = this.CachedWeaponGridDataList;
							int? num4 = (cachedWeaponGridDataList != null) ? new int?(cachedWeaponGridDataList.Count) : null;
							if (!(num3 < num4.GetValueOrDefault() & num4 != null))
							{
								goto IL_105;
							}
							SurvivorsWeaponGainData weaponData = this.CachedWeaponGridDataList[num2].WeaponData;
							num4 = ((weaponData != null) ? new int?(weaponData.ConfigId) : null);
							int value = survivorsTabMainViewData.SkipWeaponId.Value;
							if (num4.GetValueOrDefault() == value & num4 != null)
							{
								break;
							}
							num2++;
						}
						num = new int?(num2);
					}
					IL_105:
					if (num == null || num.GetValueOrDefault() == -1)
					{
						num = survivorsTabMainViewData.SkipTabIndex;
					}
					TabComponent<SurvivorsTabMainTabItem> weaponTabComponent = this.WeaponTabComponent;
					if (weaponTabComponent == null)
					{
						return;
					}
					SurvivorsTabMainTabItem tabItemByIndex = weaponTabComponent.GetTabItemByIndex(num.GetValueOrDefault());
					if (tabItemByIndex == null)
					{
						return;
					}
					tabItemByIndex.SetForceSwitch(EToggleState.ETT_Checked, true);
					return;
				}
			}
			SurvivorsTabMainTabItem roleTab2 = this.RoleTab;
			if (roleTab2 == null)
			{
				return;
			}
			roleTab2.SetForceSwitch(EToggleState.ETT_Checked, true);
			return;
		}
	}

	// Token: 0x06016066 RID: 90214 RVA: 0x0061C784 File Offset: 0x0061A984
	private UniTask CreatePages()
	{
		SurvivorsTabMainView.<CreatePages>d__20 <CreatePages>d__;
		<CreatePages>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreatePages>d__.<>4__this = this;
		<CreatePages>d__.<>1__state = -1;
		<CreatePages>d__.<>t__builder.Start<SurvivorsTabMainView.<CreatePages>d__20>(ref <CreatePages>d__);
		return <CreatePages>d__.<>t__builder.Task;
	}

	// Token: 0x06016067 RID: 90215 RVA: 0x0061C7C8 File Offset: 0x0061A9C8
	private UniTask CreateTabs()
	{
		SurvivorsTabMainView.<CreateTabs>d__21 <CreateTabs>d__;
		<CreateTabs>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateTabs>d__.<>4__this = this;
		<CreateTabs>d__.<>1__state = -1;
		<CreateTabs>d__.<>t__builder.Start<SurvivorsTabMainView.<CreateTabs>d__21>(ref <CreateTabs>d__);
		return <CreateTabs>d__.<>t__builder.Task;
	}

	// Token: 0x06016068 RID: 90216 RVA: 0x0061C80C File Offset: 0x0061AA0C
	public void RefreshTabs()
	{
		Dictionary<int, SurvivorsTabMainTabItem> tabItemMap = this.WeaponTabComponent.GetTabItemMap();
		if (this.CachedWeaponGridDataList != null)
		{
			for (int i = 0; i < this.CachedWeaponGridDataList.Count; i++)
			{
				ISurvivorsWeaponGridData survivorsWeaponGridData = this.CachedWeaponGridDataList[i];
				SurvivorsTabMainTabItem survivorsTabMainTabItem = tabItemMap.ContainsKey(i) ? tabItemMap[i] : null;
				if (survivorsWeaponGridData.IsDisable)
				{
					if (survivorsTabMainTabItem != null)
					{
						survivorsTabMainTabItem.RefreshTabState(ETabState.None);
					}
				}
				else if (survivorsWeaponGridData.IsLock)
				{
					if (survivorsTabMainTabItem != null)
					{
						survivorsTabMainTabItem.RefreshTabState(ETabState.Lock);
					}
					if (survivorsTabMainTabItem != null)
					{
						survivorsTabMainTabItem.RefreshUnlockWave(survivorsWeaponGridData.UnlockBatch.GetValueOrDefault());
					}
				}
				else
				{
					SurvivorsWeapon? survivorsWeapon = ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsWeapon(survivorsWeaponGridData.WeaponData.ConfigId);
					if (survivorsTabMainTabItem != null)
					{
						survivorsTabMainTabItem.RefreshInfo(survivorsWeapon.Value.Icon, survivorsWeaponGridData.WeaponData.Data.Level);
					}
					if (survivorsTabMainTabItem != null)
					{
						survivorsTabMainTabItem.RefreshTabState(ETabState.Normal);
					}
				}
			}
		}
		SurvivorsTabMainTabItem roleTab = this.RoleTab;
		if (roleTab != null)
		{
			roleTab.SetTextById("SurvivorCharacterAttributeInterface_Name");
		}
		SurvivorsTabMainTabItem roleTab2 = this.RoleTab;
		if (roleTab2 != null)
		{
			roleTab2.RefreshTabState(ETabState.Normal);
		}
		SurvivorsTabMainTabItem itemTab = this.ItemTab;
		if (itemTab != null)
		{
			itemTab.SetTextById("Text_Prop_Text");
		}
		SurvivorsTabMainTabItem itemTab2 = this.ItemTab;
		if (itemTab2 == null)
		{
			return;
		}
		itemTab2.RefreshTabState(ETabState.Normal);
	}

	// Token: 0x06016069 RID: 90217 RVA: 0x0061C946 File Offset: 0x0061AB46
	[NullableContext(1)]
	private SurvivorsTabMainTabItem CreateWeaponCommonTab([Nullable(2)] UUIItem item, int? index)
	{
		return new SurvivorsTabMainTabItem();
	}

	// Token: 0x0601606A RID: 90218 RVA: 0x0061C950 File Offset: 0x0061AB50
	private void RefreshCaption()
	{
		PopupCaptionItem captionComp = this.CaptionComp;
		if (captionComp != null)
		{
			captionComp.SetCloseCallBack(new Action(this.OnClickClose));
		}
		PopupCaptionItem captionComp2 = this.CaptionComp;
		if (captionComp2 != null)
		{
			captionComp2.SetHelpCallBack(delegate
			{
				ControllerBase<SurvivorsRogueController>.Instance.OpenRogueHelp();
			});
		}
		SurvivorsActivityData activityData = ModelBase<SurvivorsRogueModel>.Instance.ActivityData;
		Activity? activity = (activityData != null) ? activityData.LocalConfig : null;
		if (activity != null)
		{
			PopupCaptionItem captionComp3 = this.CaptionComp;
			if (captionComp3 == null)
			{
				return;
			}
			captionComp3.SetTitleLocalText(activity.Value.Title);
		}
	}

	// Token: 0x0601606B RID: 90219 RVA: 0x0061C9F4 File Offset: 0x0061ABF4
	private void RefreshSelectedPage(int index)
	{
		if (index == this.CurrentShowPageIndex)
		{
			return;
		}
		int currentShowPageIndex = this.CurrentShowPageIndex;
		if (currentShowPageIndex >= 0)
		{
			this.PageList[currentShowPageIndex].SetUiActive(false);
		}
		this.CurrentShowPageIndex = index;
		this.PageList[index].SetUiActive(true);
		List<LevelSequencePlayer> levelSequencePlayerList = this.LevelSequencePlayerList;
		LevelSequencePlayer levelSequencePlayer = (levelSequencePlayerList != null) ? levelSequencePlayerList[index] : null;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.StopCurrentSequence(false, false);
		}
		if (levelSequencePlayer == null)
		{
			return;
		}
		levelSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
	}

	// Token: 0x0601606C RID: 90220 RVA: 0x0061CA7C File Offset: 0x0061AC7C
	private void RefreshSelectedTab(ETabType type)
	{
		if (this.CurrentSelectTab != null)
		{
			ETabType? currentSelectTab = this.CurrentSelectTab;
			if (!(currentSelectTab.GetValueOrDefault() == type & currentSelectTab != null))
			{
				currentSelectTab = this.CurrentSelectTab;
				if (currentSelectTab != null)
				{
					switch (currentSelectTab.GetValueOrDefault())
					{
					case ETabType.Role:
					{
						SurvivorsTabMainTabItem roleTab = this.RoleTab;
						if (roleTab != null)
						{
							roleTab.SetForceSwitch(EToggleState.ETT_UnChecked, false);
						}
						break;
					}
					case ETabType.Weapon:
					{
						TabComponent<SurvivorsTabMainTabItem> weaponTabComponent = this.WeaponTabComponent;
						if (weaponTabComponent != null)
						{
							weaponTabComponent.ResetSelectIndex();
						}
						break;
					}
					case ETabType.Item:
					{
						SurvivorsTabMainTabItem itemTab = this.ItemTab;
						if (itemTab != null)
						{
							itemTab.SetForceSwitch(EToggleState.ETT_UnChecked, false);
						}
						break;
					}
					}
				}
			}
		}
		this.CurrentSelectTab = new ETabType?(type);
	}

	// Token: 0x0601606D RID: 90221 RVA: 0x0061CB29 File Offset: 0x0061AD29
	private void GoLeft()
	{
		this.OnClickChangeBtn(-1);
	}

	// Token: 0x0601606E RID: 90222 RVA: 0x0061CB32 File Offset: 0x0061AD32
	private void GoRight()
	{
		this.OnClickChangeBtn(1);
	}

	// Token: 0x0601606F RID: 90223 RVA: 0x0061CB3C File Offset: 0x0061AD3C
	private void OnClickChangeBtn(int step)
	{
		ETabType? currentSelectTab = this.CurrentSelectTab;
		ETabType? etabType = currentSelectTab;
		ETabType etabType2 = ETabType.Role;
		if (etabType.GetValueOrDefault() == etabType2 & etabType != null)
		{
			this.HandleRoleSwitch(step);
			return;
		}
		if (currentSelectTab.GetValueOrDefault() == ETabType.Item)
		{
			this.HandleItemSwitch(step);
			return;
		}
		this.HandleWeaponSwitch(step);
	}

	// Token: 0x06016070 RID: 90224 RVA: 0x0061CB8C File Offset: 0x0061AD8C
	private void HandleRoleSwitch(int step)
	{
		if (step != -1)
		{
			if (step == 1)
			{
				if (this.GetLastUnlockWeaponTabIndex() == -1)
				{
					SurvivorsTabMainTabItem itemTab = this.ItemTab;
					if (itemTab == null)
					{
						return;
					}
					itemTab.SetForceSwitch(EToggleState.ETT_Checked, true);
					return;
				}
				else
				{
					TabComponent<SurvivorsTabMainTabItem> weaponTabComponent = this.WeaponTabComponent;
					if (weaponTabComponent == null)
					{
						return;
					}
					weaponTabComponent.SelectToggleByIndex(0, false, true);
				}
			}
			return;
		}
		SurvivorsTabMainTabItem itemTab2 = this.ItemTab;
		if (itemTab2 == null)
		{
			return;
		}
		itemTab2.SetForceSwitch(EToggleState.ETT_Checked, true);
	}

	// Token: 0x06016071 RID: 90225 RVA: 0x0061CBE4 File Offset: 0x0061ADE4
	private void HandleItemSwitch(int step)
	{
		if (step != 1)
		{
			if (step == -1)
			{
				int lastUnlockWeaponTabIndex = this.GetLastUnlockWeaponTabIndex();
				if (lastUnlockWeaponTabIndex == -1)
				{
					SurvivorsTabMainTabItem roleTab = this.RoleTab;
					if (roleTab == null)
					{
						return;
					}
					roleTab.SetForceSwitch(EToggleState.ETT_Checked, true);
					return;
				}
				else
				{
					TabComponent<SurvivorsTabMainTabItem> weaponTabComponent = this.WeaponTabComponent;
					if (weaponTabComponent == null)
					{
						return;
					}
					weaponTabComponent.SelectToggleByIndex(lastUnlockWeaponTabIndex, false, true);
				}
			}
			return;
		}
		SurvivorsTabMainTabItem roleTab2 = this.RoleTab;
		if (roleTab2 == null)
		{
			return;
		}
		roleTab2.SetForceSwitch(EToggleState.ETT_Checked, true);
	}

	// Token: 0x06016072 RID: 90226 RVA: 0x0061CC40 File Offset: 0x0061AE40
	private void HandleWeaponSwitch(int step)
	{
		int selectedIndex = this.WeaponTabComponent.GetSelectedIndex();
		int lastUnlockWeaponTabIndex = this.GetLastUnlockWeaponTabIndex();
		if (selectedIndex == 0 && step == -1)
		{
			TabComponent<SurvivorsTabMainTabItem> weaponTabComponent = this.WeaponTabComponent;
			if (weaponTabComponent != null)
			{
				weaponTabComponent.ResetSelectIndex();
			}
			SurvivorsTabMainTabItem roleTab = this.RoleTab;
			if (roleTab == null)
			{
				return;
			}
			roleTab.SetForceSwitch(EToggleState.ETT_Checked, true);
			return;
		}
		else if (selectedIndex >= lastUnlockWeaponTabIndex && step == 1)
		{
			TabComponent<SurvivorsTabMainTabItem> weaponTabComponent2 = this.WeaponTabComponent;
			if (weaponTabComponent2 != null)
			{
				weaponTabComponent2.ResetSelectIndex();
			}
			SurvivorsTabMainTabItem itemTab = this.ItemTab;
			if (itemTab == null)
			{
				return;
			}
			itemTab.SetForceSwitch(EToggleState.ETT_Checked, true);
			return;
		}
		else
		{
			TabComponent<SurvivorsTabMainTabItem> weaponTabComponent3 = this.WeaponTabComponent;
			if (weaponTabComponent3 == null)
			{
				return;
			}
			weaponTabComponent3.SelectToggleByIndex(selectedIndex + step, false, true);
			return;
		}
	}

	// Token: 0x06016073 RID: 90227 RVA: 0x0061CCCC File Offset: 0x0061AECC
	private int GetLastUnlockWeaponTabIndex()
	{
		int result = -1;
		if (this.CachedWeaponGridDataList != null)
		{
			for (int i = 0; i < this.CachedWeaponGridDataList.Count; i++)
			{
				ISurvivorsWeaponGridData survivorsWeaponGridData = this.CachedWeaponGridDataList[i];
				if (!survivorsWeaponGridData.IsLock && !survivorsWeaponGridData.IsDisable)
				{
					result = i;
				}
			}
		}
		return result;
	}

	// Token: 0x06016074 RID: 90228 RVA: 0x0061CD19 File Offset: 0x0061AF19
	private void OnClickRoleTab(int gridIndex)
	{
		this.RefreshSelectedTab(ETabType.Role);
		this.RefreshSelectedPage(0);
	}

	// Token: 0x06016075 RID: 90229 RVA: 0x0061CD29 File Offset: 0x0061AF29
	private void OnClickItemTab(int gridIndex)
	{
		this.RefreshSelectedTab(ETabType.Item);
		this.RefreshSelectedPage(2);
	}

	// Token: 0x06016076 RID: 90230 RVA: 0x0061CD39 File Offset: 0x0061AF39
	private void OnClickWeaponTab(int index)
	{
		this.RefreshSelectedTab(ETabType.Weapon);
		this.RefreshSelectedPage(1);
		SurvivorsWeaponDetailTabView weaponPage = this.WeaponPage;
		if (weaponPage == null)
		{
			return;
		}
		weaponPage.RefreshByData(this.CachedWeaponGridDataList[index].WeaponData);
	}

	// Token: 0x06016077 RID: 90231 RVA: 0x0061CD6A File Offset: 0x0061AF6A
	private void OnClickClose()
	{
		base.CloseMe(null);
	}

	// Token: 0x06016078 RID: 90232 RVA: 0x0061CD74 File Offset: 0x0061AF74
	[NullableContext(1)]
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (configParams.Length <= 1)
		{
			return null;
		}
		string a = configParams[0];
		string name = configParams[1];
		if (a == "WeaponPage")
		{
			SurvivorsWeaponDetailTabView weaponPage = this.WeaponPage;
			UUIItem uuiitem = (weaponPage != null) ? weaponPage.GetGuideUiItem(name) : null;
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
		else if (a == "RolePage")
		{
			SurvivorsRoleDetailTabView rolePage = this.RolePage;
			UUIItem uuiitem2 = (rolePage != null) ? rolePage.GetGuideUiItem(name) : null;
			if (uuiitem2 == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				uuiitem2,
				uuiitem2
			};
		}
		else
		{
			if (!(a == "ItemPage"))
			{
				return null;
			}
			SurvivorsItemDetailTabView itemPage = this.ItemPage;
			UUIItem uuiitem3 = (itemPage != null) ? itemPage.GetGuideUiItem(name) : null;
			if (uuiitem3 == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				uuiitem3,
				uuiitem3
			};
		}
	}

	// Token: 0x0400A938 RID: 43320
	private const int TAB_STEP_LEFT = -1;

	// Token: 0x0400A939 RID: 43321
	private const int TAB_STEP_RIGHT = 1;

	// Token: 0x0400A93A RID: 43322
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<ISurvivorsWeaponGridData> CachedWeaponGridDataList;

	// Token: 0x0400A93B RID: 43323
	[Nullable(1)]
	private readonly List<UiPanelBase> PageList = new List<UiPanelBase>();

	// Token: 0x0400A93C RID: 43324
	private int CurrentShowPageIndex = -1;

	// Token: 0x0400A93D RID: 43325
	private PopupCaptionItem CaptionComp;

	// Token: 0x0400A93E RID: 43326
	private SurvivorsRoleDetailTabView RolePage;

	// Token: 0x0400A93F RID: 43327
	private SurvivorsWeaponDetailTabView WeaponPage;

	// Token: 0x0400A940 RID: 43328
	private SurvivorsItemDetailTabView ItemPage;

	// Token: 0x0400A941 RID: 43329
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<LevelSequencePlayer> LevelSequencePlayerList;

	// Token: 0x0400A942 RID: 43330
	private ETabType? CurrentSelectTab;

	// Token: 0x0400A943 RID: 43331
	private SurvivorsTabMainTabItem RoleTab;

	// Token: 0x0400A944 RID: 43332
	private SurvivorsTabMainTabItem ItemTab;

	// Token: 0x0400A945 RID: 43333
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TabComponent<SurvivorsTabMainTabItem> WeaponTabComponent;
}
