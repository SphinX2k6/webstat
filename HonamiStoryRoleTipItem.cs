using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001F16 RID: 7958
[NullableContext(1)]
[Nullable(0)]
public class HonamiStoryRoleTipItem : UiPanelBase
{
	// Token: 0x0600EDFD RID: 60925 RVA: 0x0040FBE4 File Offset: 0x0040DDE4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(14, typeof(UUIItem)),
			new ValueTuple<int, Type>(15, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(16, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(17, typeof(UUIItem)),
			new ValueTuple<int, Type>(18, typeof(UUIMultiTemplateLayout)),
			new ValueTuple<int, Type>(19, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(11, new Action(this.OnClickedArrowButton)),
			new ValueTuple<int, Delegate>(15, new Action<EToggleState>(this.OnClickedButton))
		};
	}

	// Token: 0x0600EDFE RID: 60926 RVA: 0x0040FDFC File Offset: 0x0040DFFC
	protected override UniTask OnBeforeStartAsync()
	{
		HonamiStoryRoleTipItem.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<HonamiStoryRoleTipItem.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600EDFF RID: 60927 RVA: 0x0040FE40 File Offset: 0x0040E040
	protected override void OnStart()
	{
		TermExplanationRegistryParam param = new TermExplanationRegistryParam
		{
			UiText = base.GetText(1),
			ViewType = ETermExplanationViewType.Center,
			ReportType = ETermExplanationReportType.HonamiStory
		};
		ControllerBase<TermExplanationController>.Instance.RegisterTextHyperlinkByParam(param);
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		bool tipsOpen = ModelBase<HonamiStoryModel>.Instance.GetBackpackLogic().GetTipsOpen();
		UUIExtendToggle extendToggle = base.GetExtendToggle(15);
		if (extendToggle != null)
		{
			extendToggle.RootUIComp.Get().SetUIActive(tipsOpen);
		}
		Singleton<EventSystem>.Instance.Add<bool>(EEventName.OnHonamiStorySkillDescModeChange, new Action<bool>(this.OnSkillDescModeChange));
	}

	// Token: 0x0600EE00 RID: 60928 RVA: 0x0040FED9 File Offset: 0x0040E0D9
	protected override void OnBeforeDestroy()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnHonamiStorySkillDescModeChange, new Action<bool>(this.OnSkillDescModeChange));
	}

	// Token: 0x0600EE01 RID: 60929 RVA: 0x0040FEF7 File Offset: 0x0040E0F7
	private HonamiStoryWeaponSuitInfoItem CreateSuitItem()
	{
		return new HonamiStoryWeaponSuitInfoItem();
	}

	// Token: 0x0600EE02 RID: 60930 RVA: 0x0040FEFE File Offset: 0x0040E0FE
	private HonamiStoryTipsTextItem CreateSkill()
	{
		return new HonamiStoryTipsTextItem();
	}

	// Token: 0x0600EE03 RID: 60931 RVA: 0x0040FF05 File Offset: 0x0040E105
	private HonamiStoryTipsPropertyItem CreateProperty()
	{
		return new HonamiStoryTipsPropertyItem();
	}

	// Token: 0x0600EE04 RID: 60932 RVA: 0x0040FF0C File Offset: 0x0040E10C
	private HonamiStoryWeaponTagItem CreateTagItem()
	{
		return new HonamiStoryWeaponTagItem();
	}

	// Token: 0x0600EE05 RID: 60933 RVA: 0x0040FF14 File Offset: 0x0040E114
	public void Refresh(HonamiStoryRoleEquipData equipData)
	{
		UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(16);
		FVector2D fvector2D = new FVector2D(0f, 0f);
		if (scrollViewWithScrollbar != null)
		{
			scrollViewWithScrollbar.ScrollToTop(ref fvector2D, base.GetItem(0), true);
		}
		this.EquipData = equipData;
		this.RefreshItemTipsOpen();
		this.RefreshWeaponTips();
		this.RefreshPluginTips();
		this.ShowTips(true);
	}

	// Token: 0x0600EE06 RID: 60934 RVA: 0x0040FF70 File Offset: 0x0040E170
	public void RefreshItemTipsOpen()
	{
		if (!base.IsUiActiveInHierarchy())
		{
			return;
		}
		bool tipsOpen = ModelBase<HonamiStoryModel>.Instance.GetBackpackLogic().GetTipsOpen();
		UUIExtendToggle extendToggle = base.GetExtendToggle(15);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.RootUIComp.Get().SetUIActive(tipsOpen);
	}

	// Token: 0x0600EE07 RID: 60935 RVA: 0x0040FFB8 File Offset: 0x0040E1B8
	private void RefreshWeaponTips()
	{
		if (this.EquipData == null)
		{
			return;
		}
		int weaponId = this.EquipData.GetWeaponId();
		bool flag = weaponId != 0;
		if (flag)
		{
			HonamiStoryWeaponData weaponData = ModelBase<HonamiStoryModel>.Instance.GetWeaponData(weaponId);
			bool skillDescMode = ModelBase<HonamiStoryModel>.Instance.GetSkillDescMode();
			string textStringId = skillDescMode ? weaponData.DescSimple : weaponData.Desc;
			List<string> list = skillDescMode ? weaponData.DescSimpleArgs : weaponData.DescArgs;
			if (list != null && list.Count > 0)
			{
				object[] array = new object[list.Count];
				for (int i = 0; i < list.Count; i++)
				{
					array[i] = list[i];
				}
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textStringId, array);
			}
			else
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textStringId, Array.Empty<object>());
			}
			List<int> suitId = weaponData.SuitId;
			List<IHonamiStoryWeaponSuitData> list2 = new List<IHonamiStoryWeaponSuitData>();
			foreach (int suitId2 in suitId)
			{
				list2.Add(new HonamiStoryWeaponSuitData
				{
					SuitId = suitId2,
					EquipData = this.EquipData
				});
			}
			GenericLayout<HonamiStoryWeaponSuitInfoItem, IHonamiStoryWeaponSuitData> suitVerticalLayout = this.SuitVerticalLayout;
			if (suitVerticalLayout != null)
			{
				suitVerticalLayout.RefreshByData(list2, null, false);
			}
			GenericLayout<HonamiStoryWeaponTagItem, int> tagLayout = this.TagLayout;
			if (tagLayout != null)
			{
				tagLayout.RefreshByData(weaponData.PluginTags, null, false);
			}
		}
		UUIItem item = base.GetItem(0);
		if (item != null)
		{
			item.SetUIActive(flag);
		}
		UUIItem item2 = base.GetItem(2);
		if (item2 != null)
		{
			item2.SetUIActive(flag);
		}
		UUIItem item3 = base.GetItem(12);
		if (item3 != null)
		{
			item3.SetUIActive(!flag);
		}
		UUIItem item4 = base.GetItem(17);
		if (item4 == null)
		{
			return;
		}
		item4.SetUIActive(flag);
	}

	// Token: 0x0600EE08 RID: 60936 RVA: 0x00410174 File Offset: 0x0040E374
	private void RefreshPluginTips()
	{
		List<HonamiStoryEquipItemData> list = (this.EquipData != null) ? this.EquipData.GetPluginList() : new List<HonamiStoryEquipItemData>();
		bool flag = false;
		if (list != null && list.Count > 0)
		{
			using (List<HonamiStoryEquipItemData>.Enumerator enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current != null)
					{
						flag = true;
						break;
					}
				}
			}
		}
		if (flag)
		{
			Dictionary<int, IHonamiStoryTipsBuffInfo> dictionary = new Dictionary<int, IHonamiStoryTipsBuffInfo>();
			Dictionary<int, IHonamiStoryTipsPropertyData> dictionary2 = new Dictionary<int, IHonamiStoryTipsPropertyData>();
			Dictionary<int, int> dictionary3 = new Dictionary<int, int>();
			foreach (HonamiStoryEquipItemData honamiStoryEquipItemData in list)
			{
				if (honamiStoryEquipItemData != null)
				{
					foreach (IHonamiStoryTipsBuffInfo honamiStoryTipsBuffInfo in honamiStoryEquipItemData.GetBuffTempIdList(false))
					{
						if (honamiStoryTipsBuffInfo.RoleId == null || HonamiStoryUtil.CheckRolePowerValid(honamiStoryTipsBuffInfo.RoleId.Value, this.EquipData.GetParentRoleId()))
						{
							dictionary[honamiStoryTipsBuffInfo.BuffId] = honamiStoryTipsBuffInfo;
						}
					}
					foreach (int num in honamiStoryEquipItemData.GetMainPropList())
					{
						HonamiStoryProp? honamiStoryProp = ConfigBase<HonamiStoryConfig>.Instance.GetHonamiStoryProp(num);
						if (honamiStoryProp != null)
						{
							int propId = honamiStoryProp.Value.PropId;
							if (!dictionary3.ContainsKey(propId))
							{
								dictionary3[propId] = num;
							}
							int num2 = dictionary3[propId];
							if (!dictionary2.ContainsKey(num2))
							{
								dictionary2[num2] = new HonamiStoryTipsPropertyData
								{
									PropId = num2,
									PropertyNumber = new int?(honamiStoryProp.Value.StandardProperty)
								};
							}
							else
							{
								IHonamiStoryTipsPropertyData honamiStoryTipsPropertyData2;
								IHonamiStoryTipsPropertyData honamiStoryTipsPropertyData = honamiStoryTipsPropertyData2 = dictionary2[num2];
								int? propertyNumber = honamiStoryTipsPropertyData2.PropertyNumber;
								int value = propertyNumber.GetValueOrDefault();
								if (propertyNumber == null)
								{
									value = 0;
									honamiStoryTipsPropertyData2.PropertyNumber = new int?(value);
								}
								honamiStoryTipsPropertyData.PropertyNumber = new int?(honamiStoryTipsPropertyData.PropertyNumber.Value + honamiStoryProp.Value.StandardProperty);
							}
						}
					}
				}
			}
			List<IHonamiStoryTipsBuffInfo> data = new List<IHonamiStoryTipsBuffInfo>(dictionary.Values);
			GenericLayout<HonamiStoryTipsTextItem, IHonamiStoryTipsBuffInfo> skillLayout = this.SkillLayout;
			if (skillLayout != null)
			{
				skillLayout.RefreshByData(data, null, false);
			}
			GenericLayout<HonamiStoryTipsPropertyItem, IHonamiStoryTipsPropertyData> propertyLayout = this.PropertyLayout;
			if (propertyLayout != null)
			{
				propertyLayout.RefreshByData(new List<IHonamiStoryTipsPropertyData>(dictionary2.Values), null, false);
			}
		}
		UUIItem item = base.GetItem(5);
		if (item != null)
		{
			item.SetUIActive(flag);
		}
		UUIItem item2 = base.GetItem(8);
		if (item2 != null)
		{
			item2.SetUIActive(flag);
		}
		UUIItem item3 = base.GetItem(13);
		if (item3 == null)
		{
			return;
		}
		item3.SetUIActive(!flag);
	}

	// Token: 0x0600EE09 RID: 60937 RVA: 0x00410484 File Offset: 0x0040E684
	public void RegisterCloseCallback(Action callback)
	{
		this.CloseCallback = callback;
	}

	// Token: 0x0600EE0A RID: 60938 RVA: 0x00410490 File Offset: 0x0040E690
	public void ShowTips(bool isShow)
	{
		this.SetActive(isShow);
		if (this.LevelSequencePlayer.IsPlayingSequence("In"))
		{
			this.LevelSequencePlayer.StopSequenceByKey("In", false, false);
		}
		if (!isShow)
		{
			return;
		}
		this.LevelSequencePlayer.PlayOrReplaySequenceByName("In", false, null);
	}

	// Token: 0x0600EE0B RID: 60939 RVA: 0x004104E8 File Offset: 0x0040E6E8
	private void OnClickedButton(EToggleState toggleState)
	{
		HonamiStoryBackpackLogicController backpackLogic = ModelBase<HonamiStoryModel>.Instance.GetBackpackLogic();
		if (backpackLogic != null)
		{
			backpackLogic.CloseTips();
		}
		UUIExtendToggle extendToggle = base.GetExtendToggle(15);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.RootUIComp.Get().SetUIActive(false);
	}

	// Token: 0x0600EE0C RID: 60940 RVA: 0x0041052A File Offset: 0x0040E72A
	private void OnClickedArrowButton()
	{
		Action closeCallback = this.CloseCallback;
		if (closeCallback != null)
		{
			closeCallback();
		}
		this.ShowTips(false);
	}

	// Token: 0x0600EE0D RID: 60941 RVA: 0x00410544 File Offset: 0x0040E744
	private void OnSkillDescModeChange(bool _)
	{
		this.RefreshWeaponTips();
		this.RefreshPluginTips();
	}

	// Token: 0x0600EE0E RID: 60942 RVA: 0x00410554 File Offset: 0x0040E754
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
		if (!(configParams[0] == "SuitDesc"))
		{
			return null;
		}
		int index = int.Parse(configParams[1]);
		UUIItem itemByIndex = this.SuitVerticalLayout.GetItemByIndex(index);
		UUIItem item = base.GetItem(2);
		UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(16);
		if (scrollViewWithScrollbar != null)
		{
			scrollViewWithScrollbar.StopMovement();
		}
		UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar2 = base.GetScrollViewWithScrollbar(16);
		if (scrollViewWithScrollbar2 != null)
		{
			scrollViewWithScrollbar2.ScrollTo(item, true);
		}
		if (itemByIndex == null)
		{
			return null;
		}
		return new UUIItem[]
		{
			itemByIndex,
			itemByIndex
		};
	}

	// Token: 0x04007249 RID: 29257
	[Nullable(2)]
	private HonamiStoryRoleEquipData EquipData;

	// Token: 0x0400724A RID: 29258
	private GenericLayout<HonamiStoryWeaponSuitInfoItem, IHonamiStoryWeaponSuitData> SuitVerticalLayout;

	// Token: 0x0400724B RID: 29259
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	protected GenericLayout<HonamiStoryTipsTextItem, IHonamiStoryTipsBuffInfo> SkillLayout;

	// Token: 0x0400724C RID: 29260
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	protected GenericLayout<HonamiStoryTipsPropertyItem, IHonamiStoryTipsPropertyData> PropertyLayout;

	// Token: 0x0400724D RID: 29261
	private GenericLayout<HonamiStoryWeaponTagItem, int> TagLayout;

	// Token: 0x0400724E RID: 29262
	[Nullable(2)]
	protected LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x0400724F RID: 29263
	[Nullable(2)]
	private Action CloseCallback;

	// Token: 0x02008283 RID: 33411
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402C43E RID: 181310
		WeaponInfoPanel,
		// Token: 0x0402C43F RID: 181311
		WeaponInfoText,
		// Token: 0x0402C440 RID: 181312
		SuitInfoPanel,
		// Token: 0x0402C441 RID: 181313
		SuitActiveVerticalLayout,
		// Token: 0x0402C442 RID: 181314
		SuitActiveItem,
		// Token: 0x0402C443 RID: 181315
		SkillInfoPanel,
		// Token: 0x0402C444 RID: 181316
		SkillVerticalLayout,
		// Token: 0x0402C445 RID: 181317
		SkillItem,
		// Token: 0x0402C446 RID: 181318
		PropertyInfoPanel,
		// Token: 0x0402C447 RID: 181319
		PropertyInfoVerticalLayout,
		// Token: 0x0402C448 RID: 181320
		PropertyInfoItem,
		// Token: 0x0402C449 RID: 181321
		ArrowButton,
		// Token: 0x0402C44A RID: 181322
		WeaponEmptyPanel,
		// Token: 0x0402C44B RID: 181323
		ItemEmptyPanel,
		// Token: 0x0402C44C RID: 181324
		PanelSelf,
		// Token: 0x0402C44D RID: 181325
		ToggleClose,
		// Token: 0x0402C44E RID: 181326
		ScrollView,
		// Token: 0x0402C44F RID: 181327
		TagPanel,
		// Token: 0x0402C450 RID: 181328
		TagLayout,
		// Token: 0x0402C451 RID: 181329
		TagItem
	}
}
