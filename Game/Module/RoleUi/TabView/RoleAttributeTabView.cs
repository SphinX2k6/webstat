using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.Role.Common.Data.Enum;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.RoleUi.TabView
{
	// Token: 0x02005064 RID: 20580
	[NullableContext(2)]
	[Nullable(0)]
	public class RoleAttributeTabView : UiTabViewBase
	{
		// Token: 0x06035013 RID: 217107 RVA: 0x00D4ACCC File Offset: 0x00D48ECC
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUISprite)),
				new ValueTuple<int, Type>(4, typeof(UUIText)),
				new ValueTuple<int, Type>(6, typeof(UUIText)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIText)),
				new ValueTuple<int, Type>(8, typeof(UUIText)),
				new ValueTuple<int, Type>(9, typeof(UUITexture)),
				new ValueTuple<int, Type>(10, typeof(UUIHorizontalLayout)),
				new ValueTuple<int, Type>(11, typeof(UUIText)),
				new ValueTuple<int, Type>(12, typeof(UUIItem)),
				new ValueTuple<int, Type>(13, typeof(UUIItem)),
				new ValueTuple<int, Type>(14, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(15, typeof(UUIItem)),
				new ValueTuple<int, Type>(16, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(17, typeof(UUIHorizontalLayout)),
				new ValueTuple<int, Type>(18, typeof(UUIItem)),
				new ValueTuple<int, Type>(19, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(20, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(21, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(22, typeof(UUIItem)),
				new ValueTuple<int, Type>(23, typeof(UUIItem)),
				new ValueTuple<int, Type>(24, typeof(UUISprite)),
				new ValueTuple<int, Type>(25, typeof(UUIText)),
				new ValueTuple<int, Type>(26, typeof(UUITexture)),
				new ValueTuple<int, Type>(27, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.DetailClick)),
				new ValueTuple<int, Delegate>(14, new Action(this.TeachClick)),
				new ValueTuple<int, Delegate>(16, new Action(this.RoleChangeClick)),
				new ValueTuple<int, Delegate>(19, new Action(this.RoleTagClick)),
				new ValueTuple<int, Delegate>(21, new Action(this.OnRoleSkinClick))
			};
		}

		// Token: 0x06035014 RID: 217108 RVA: 0x00D4AFE6 File Offset: 0x00D491E6
		protected void DetailClick()
		{
			this.UpdateAttrList();
		}

		// Token: 0x06035015 RID: 217109 RVA: 0x00D4AFF0 File Offset: 0x00D491F0
		protected void LevelUpClick(int _)
		{
			RoleViewViewModel viewModel = new RoleViewViewModel(this.RoleInstance.GetRoleId(), false, ERoleViewSource.Normal);
			ControllerBase<RoleController>.Instance.OpenRoleViewByViewModel(EUiViewName.RoleLevelUpView, viewModel);
		}

		// Token: 0x06035016 RID: 217110 RVA: 0x00D4B020 File Offset: 0x00D49220
		protected void BreakthroughClick(int _)
		{
			RoleViewViewModel viewModel = new RoleViewViewModel(this.RoleInstance.GetRoleId(), false, ERoleViewSource.Normal);
			ControllerBase<RoleController>.Instance.OpenRoleViewByViewModel(EUiViewName.RoleBreachView, viewModel);
		}

		// Token: 0x06035017 RID: 217111 RVA: 0x00D4B050 File Offset: 0x00D49250
		protected void RoleChangeClick()
		{
			if (ModelBase<GameModeModel>.Instance.IsMulti)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("InstanceDungeonShieldViewCantOpen", Array.Empty<object>());
				return;
			}
			LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.DirectTrainMakeRoleChange, true);
			UUIItem item = base.GetItem(23);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RoleElementView, this.RoleViewAgent, null);
		}

		// Token: 0x06035018 RID: 217112 RVA: 0x00D4B0B4 File Offset: 0x00D492B4
		protected void RoleTagClick()
		{
			RoleInfo roleConfig = this.RoleInstance.GetRoleConfig();
			int[] roleTagByRoleInfo = ModelBase<RoleModel>.Instance.GetRoleTagByRoleInfo(roleConfig);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RoleTagDetailView, roleTagByRoleInfo, null);
		}

		// Token: 0x06035019 RID: 217113 RVA: 0x00D4B0EC File Offset: 0x00D492EC
		protected void OnRoleSkinClick()
		{
			int curSelectRoleId = this.RoleViewAgent.GetCurSelectRoleId();
			ControllerBase<SkinController>.Instance.SkipToSkinView(curSelectRoleId, EUiTabViewName.RoleSkinTabView, false, -1, null, null, null);
		}

		// Token: 0x0603501A RID: 217114 RVA: 0x00D4B12C File Offset: 0x00D4932C
		protected void TeachClick()
		{
			if (ControllerBase<GameModeController>.Instance.IsInInstance())
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("RoleGuideNotice01", Array.Empty<object>());
				return;
			}
			if (ControllerBase<FormationDataController>.Instance.GlobalIsInFight)
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("RoleGuideNotice06", Array.Empty<object>());
				return;
			}
			if (ModelBase<GameModeModel>.Instance.IsMulti)
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("RoleGuideNotice05", Array.Empty<object>());
				return;
			}
			int roleId = this.RoleViewAgent.GetCurSelectRoleId();
			RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleId);
			string roleName = ConfigBase<RoleConfig>.Instance.GetRoleName(roleConfig.Value.Name);
			int dungeonId = roleConfig.Value.RoleGuide;
			if (dungeonId == 0)
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("RoleGuideNotice02", new object[]
				{
					roleName
				});
				return;
			}
			if (ControllerBase<InstanceDungeonController>.Instance.IsForbidDungeon(dungeonId))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("PhantomFormationEnterInstanceTip", Array.Empty<object>());
				return;
			}
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.RoleTeachTip);
			confirmBoxDataNew.SetTextArgs(new string[]
			{
				roleName
			});
			confirmBoxDataNew.FunctionMap.Add(2, delegate
			{
				int fightFormationId = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(dungeonId).Value.FightFormationId;
				Aki.Config.FightFormation? fightFormation;
				int[] array = (ConfigBase<EditBattleTeamConfig>.Instance.GetFightFormationConfig(fightFormationId) != null) ? fightFormation.GetValueOrDefault().AutoRole() : null;
				if (((array != null) ? array.Length : 0) > 0)
				{
					List<int> list = new List<int>();
					foreach (int id in array)
					{
						list.Add(ConfigBase<RoleConfig>.Instance.GetTrialRoleIdConfigByGroupId(id));
					}
					RoleTeachEnterCtx roleTeachEnterCtx = RoleTeachEnterCtx.Create();
					roleTeachEnterCtx.RoleId = roleId;
					ModelBase<InstanceDungeonModel>.Instance.InstanceEnterContentText.RoleTeachCtx = roleTeachEnterCtx;
					ControllerBase<InstanceDungeonController>.Instance.PrewarTeamFightRequest(dungeonId, list, 0, 0, null, null).Forget<bool>();
					return;
				}
				Singleton<Log>.Instance.Error(ELogModule.Role, ELogAuthor.LZK, "未配置出战人物", default(ReadOnlySpan<ValueTuple<string, object>>));
			});
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x0603501B RID: 217115 RVA: 0x00D4B27C File Offset: 0x00D4947C
		protected override void OnStart()
		{
			this.RoleViewAgent = (this.ExtraParams as RoleViewAgent);
			if (this.RoleViewAgent == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Role;
				ELogAuthor author = ELogAuthor.BB;
				string message = "RoleViewAgent为空";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("界面名称", "RoleAttributeTabView");
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.RoleSystemUiParams = this.RoleViewAgent.GetRoleSystemUiParams();
			this.SceneRoleActor = Singleton<UiSceneManager>.Instance.GetRoleSystemRoleActor();
			this.RoleState = ERoleState.NoRole;
			this.LevelUpButtonItem = new ButtonItem(base.GetItem(1));
			this.BreakthroughButtonItem = new ButtonItem(base.GetItem(15));
			this.LevelUpButtonItem.SetFunction(new Action<int>(this.LevelUpClick));
			this.BreakthroughButtonItem.SetFunction(new Action<int>(this.BreakthroughClick));
			base.SetButtonUiActive(20, false);
			this.InitAttributeItemList();
			this.StarLayout = new GenericLayout<StarItem, IStarItemData>(base.GetHorizontalLayout(10), new Func<StarItem>(this.InitStarItem), null, false, true);
			this.RoleTagLayout = new GenericLayout<RoleTagSmallIconItem, int>(base.GetHorizontalLayout(17), new Func<RoleTagSmallIconItem>(this.InitRoleTagItem), null, false, true);
		}

		// Token: 0x0603501C RID: 217116 RVA: 0x00D4B39C File Offset: 0x00D4959C
		[NullableContext(1)]
		private StarItem InitStarItem()
		{
			return new StarItem();
		}

		// Token: 0x0603501D RID: 217117 RVA: 0x00D4B3A3 File Offset: 0x00D495A3
		[NullableContext(1)]
		private RoleTagSmallIconItem InitRoleTagItem()
		{
			return new RoleTagSmallIconItem();
		}

		// Token: 0x0603501E RID: 217118 RVA: 0x00D4B3AC File Offset: 0x00D495AC
		private void InitAttributeItemList()
		{
			IReadOnlyList<int> intArrayConfig = ConfigCommonParamById.GetIntArrayConfig("RoleAttributeDisplay6");
			UUIItem item = base.GetItem(12);
			UUIItem item2 = base.GetItem(5);
			int count = intArrayConfig.Count;
			for (int i = 0; i < count; i++)
			{
				UUIItem uuiitem;
				if (i == 0)
				{
					uuiitem = item2;
				}
				else
				{
					uuiitem = Singleton<LguiUtil>.Instance.CopyItem(item2, item);
				}
				int id = intArrayConfig[i];
				AttributeItem attributeItem = new AttributeItem();
				attributeItem.CreateThenShowByActor(uuiitem.GetOwner());
				attributeItem.UpdateParam(id, false);
				if (count > 2 && i % 2 == 0)
				{
					attributeItem.SetBgActive(true);
				}
				else
				{
					attributeItem.SetBgActive(false);
				}
				this.AttributeItemList.Add(attributeItem);
			}
		}

		// Token: 0x0603501F RID: 217119 RVA: 0x00D4B458 File Offset: 0x00D49658
		protected override void AddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.RoleInfoUpdate, new Action(this.OnRoleInfoUpdate));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.RoleSystemChangeRole, new Action<int>(this.ChangeRoleEvent));
			Singleton<EventSystem>.Instance.Add<int, int, int>(EEventName.RoleLevelUp, new Action<int, int, int>(this.OnRoleLevelUp));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.ActiveRole, new Action<int>(this.ActiveRoleEvent));
			Singleton<EventSystem>.Instance.Add(EEventName.RoleRefreshName, new Action(this.RefreshNameEvent));
		}

		// Token: 0x06035020 RID: 217120 RVA: 0x00D4B4F4 File Offset: 0x00D496F4
		protected override void RemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RoleInfoUpdate, new Action(this.OnRoleInfoUpdate));
			Singleton<EventSystem>.Instance.Remove(EEventName.RoleSystemChangeRole, new Action<int>(this.ChangeRoleEvent));
			Singleton<EventSystem>.Instance.Remove(EEventName.RoleLevelUp, new Action<int, int, int>(this.OnRoleLevelUp));
			Singleton<EventSystem>.Instance.Remove(EEventName.ActiveRole, new Action<int>(this.ActiveRoleEvent));
			Singleton<EventSystem>.Instance.Remove(EEventName.RoleRefreshName, new Action(this.RefreshNameEvent));
		}

		// Token: 0x06035021 RID: 217121 RVA: 0x00D4B58D File Offset: 0x00D4978D
		private void ChangeRoleEvent(int roleId)
		{
			this.RoleInstance = ModelBase<RoleModel>.Instance.GetRoleDataById(roleId, true);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RoleSkinRedDotRefresh, roleId);
			this.PlayMontageStartWithReLoop();
			this.UpdateRoleInfo();
			this.UpdateTeachBtn();
		}

		// Token: 0x06035022 RID: 217122 RVA: 0x00D4B5C4 File Offset: 0x00D497C4
		private void UpdateTeachBtn()
		{
			this.LevelUpButtonItem.BindRedDot(ERedDotName.RoleAttributeTabLevelUp, this.RoleInstance.GetDataId());
			this.BreakthroughButtonItem.BindRedDot(ERedDotName.RoleAttributeTabBreakUp, this.RoleInstance.GetDataId());
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.RoleSkin, base.GetItem(22), null, this.RoleInstance.GetDataId());
			if (!this.RoleSystemUiParams.TeachBtn)
			{
				base.GetButton(14).GetRootComponent().SetUIActive(false);
				return;
			}
			bool flag = this.RoleInstance.IsTrialRole();
			bool flag2 = ModelBase<FunctionModel>.Instance.IsShow(10043);
			bool flag3 = ModelBase<FunctionModel>.Instance.IsOpen(10043);
			if (flag2 && flag3)
			{
				base.GetButton(14).GetRootComponent().SetUIActive(!flag);
				return;
			}
			base.GetButton(14).GetRootComponent().SetUIActive(false);
		}

		// Token: 0x06035023 RID: 217123 RVA: 0x00D4B69B File Offset: 0x00D4989B
		private void OnRoleInfoUpdate()
		{
			this.UpdateRoleInfo();
		}

		// Token: 0x06035024 RID: 217124 RVA: 0x00D4B6A3 File Offset: 0x00D498A3
		private void OnRoleLevelUp(int i, int i1, int arg3)
		{
			this.UpdateRoleInfo();
		}

		// Token: 0x06035025 RID: 217125 RVA: 0x00D4B6AB File Offset: 0x00D498AB
		private void ActiveRoleEvent(int i)
		{
			this.PlayModelEffect();
		}

		// Token: 0x06035026 RID: 217126 RVA: 0x00D4B6B3 File Offset: 0x00D498B3
		private void RefreshNameEvent()
		{
			this.UpdateRename();
		}

		// Token: 0x06035027 RID: 217127 RVA: 0x00D4B6BB File Offset: 0x00D498BB
		protected void PlayModelEffect()
		{
			UiRoleUtils.PlayRoleLevelUpEffect(this.SceneRoleActor);
		}

		// Token: 0x06035028 RID: 217128 RVA: 0x00D4B6C8 File Offset: 0x00D498C8
		private void UpdateAttrList()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RoleAttributeDetailView, this.RoleInstance.GetShowAttrList(), null);
		}

		// Token: 0x06035029 RID: 217129 RVA: 0x00D4B6E8 File Offset: 0x00D498E8
		private void UpdateRoleLevel()
		{
			this.SetRoleLevelUpState();
			RoleLevelData levelData = this.RoleInstance.GetLevelData();
			if (this.RoleState == ERoleState.MaxLevel || this.RoleState == ERoleState.NoRole)
			{
				base.GetText(2).SetText("", true);
				base.GetItem(27).SetUIActive(true);
			}
			else
			{
				Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(2), "RoleExp", new <>z__ReadOnlyArray<object>(new object[]
				{
					levelData.GetExp(),
					levelData.GetCurrentMaxExp()
				}));
				base.GetItem(27).SetUIActive(false);
			}
			double num = (this.RoleState == ERoleState.MaxLevel || this.RoleState == ERoleState.NoRole) ? 1.0 : levelData.GetExpPercentage();
			base.GetSprite(3).SetFillAmount((float)num);
			UUIText text = base.GetText(6);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "Level_Text_New_Suffix", new <>z__ReadOnlySingleElementList<object>(levelData.GetCurrentMaxLevel()));
		}

		// Token: 0x0603502A RID: 217130 RVA: 0x00D4B7E0 File Offset: 0x00D499E0
		private void UpdateRoleBreakLevel()
		{
			RoleLevelData levelData = this.RoleInstance.GetLevelData();
			int breachLevel = levelData.GetBreachLevel();
			string text = ConfigBase<TextConfig>.Instance.GetTextById("RoleBreakLevel");
			text = ((text != null) ? text.Replace("%s", "[" + breachLevel.ToString() + "]") : null);
			if (text != null)
			{
				base.GetText(4).SetText(text, true);
			}
			int maxBreachLevel = levelData.GetMaxBreachLevel();
			IStarItemData[] array = new IStarItemData[maxBreachLevel];
			for (int i = 0; i < maxBreachLevel; i++)
			{
				StarItemData starItemData = new StarItemData
				{
					StarOnActive = (i < breachLevel),
					StarOffActive = (i >= breachLevel),
					StarNextActive = false,
					StarLoopActive = false,
					PlayLoopSequence = false,
					PlayActivateSequence = false
				};
				array[i] = starItemData;
			}
			this.StarLayout.RefreshByData(new List<IStarItemData>(array), null, false);
			int num = (this.RoleState == ERoleState.NoRole) ? levelData.GetRoleMaxLevel() : levelData.GetLevel();
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), "Level_Text_New", new <>z__ReadOnlySingleElementList<object>(num));
			ElementInfo? elementInfo = this.RoleInstance.GetElementInfo();
			base.SetElementIcon(elementInfo.Value.Icon, base.GetTexture(9), this.RoleInstance.GetRoleConfig().ElementId, new EUiViewName?(EUiViewName.RoleRootView));
			base.SetElementIcon(elementInfo.Value.Icon, base.GetTexture(26), this.RoleInstance.GetRoleConfig().ElementId, new EUiViewName?(EUiViewName.RoleRootView));
			string elementInfoLocalName = ConfigBase<ElementInfoConfig>.Instance.GetElementInfoLocalName(elementInfo.Value.Name);
			base.GetText(8).SetText(elementInfoLocalName, true);
		}

		// Token: 0x0603502B RID: 217131 RVA: 0x00D4B9AC File Offset: 0x00D49BAC
		private void UpdateRoleTag()
		{
			int[] roleTagByRoleInfo = ModelBase<RoleModel>.Instance.GetRoleTagByRoleInfo(this.RoleInstance.GetRoleConfig());
			this.RoleTagLayout.RefreshByData(new List<int>(roleTagByRoleInfo), null, false);
		}

		// Token: 0x0603502C RID: 217132 RVA: 0x00D4B9E2 File Offset: 0x00D49BE2
		private void UpdateRoleInfo()
		{
			this.UpdateRoleLevel();
			this.UpdateButtonState();
			this.UpdateRoleBreakLevel();
			this.UpdateRename();
			this.UpdateAttribute();
			this.UpdateTrial();
			this.UpdateRoleChangeButton();
			this.UpdateRoleTag();
			this.UpdateRoleSkinButton();
		}

		// Token: 0x0603502D RID: 217133 RVA: 0x00D4BA1C File Offset: 0x00D49C1C
		private void UpdateRoleChangeButton()
		{
			int curSelectRoleId = this.RoleViewAgent.GetCurSelectRoleId();
			RoleDataBase curSelectRoleData = this.RoleViewAgent.GetCurSelectRoleData();
			bool flag = ControllerBase<MainRoleController>.Instance.IsMainRole(curSelectRoleId);
			bool flag2 = curSelectRoleData.IsTrialRole();
			int? roleElementTransferFunctionId = ConfigBase<RoleConfig>.Instance.GetRoleElementTransferFunctionId();
			bool flag3 = ModelBase<FunctionModel>.Instance.IsOpen(roleElementTransferFunctionId.Value);
			bool flag4 = ControllerBase<GameModeController>.Instance.IsInInstance();
			bool flag5 = RoleDefine.RoleViewSourceHideRoleChange[this.RoleViewAgent.Source];
			bool flag6 = flag && flag3 && !flag4 && !flag2 && !flag5;
			base.GetButton(16).RootUIComp.Get().SetUIActive(flag6);
			UUIItem item = base.GetItem(23);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(flag6 && !LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.DirectTrainMakeRoleChange, false));
		}

		// Token: 0x0603502E RID: 217134 RVA: 0x00D4BAEC File Offset: 0x00D49CEC
		private void UpdateRoleSkinButton()
		{
			bool flag = this.RoleViewAgent.GetCurSelectRoleData().IsTrialRole();
			base.GetButton(21).RootUIComp.Get().SetUIActive(!flag);
		}

		// Token: 0x0603502F RID: 217135 RVA: 0x00D4BB28 File Offset: 0x00D49D28
		private void UpdateRename()
		{
			base.GetText(11).SetText(this.RoleInstance.GetName(null), true);
		}

		// Token: 0x06035030 RID: 217136 RVA: 0x00D4BB58 File Offset: 0x00D49D58
		private void UpdateTrial()
		{
			bool flag = this.RoleInstance.IsTrialRole();
			base.GetItem(13).SetUIActive(flag);
			if (flag)
			{
				int trialRoleId = (this.RoleInstance as RoleRobotData).GetTrialRoleId();
				string trailRoleLabelIconById = RoleUtils.GetTrailRoleLabelIconById(trialRoleId);
				string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(trailRoleLabelIconById);
				this.SetSpriteByPath(resourcePath, base.GetSprite(24), false, null, null);
				ETrialRoleType trialRoleType = RoleUtils.GetTrialRoleType(trialRoleId);
				string text;
				FColor color = FColor.FromHex(RoleDefine.trialRoleHexColor.TryGetValue(trialRoleType, out text) ? text : RoleDefine.trialRoleHexColor[ETrialRoleType.NormalTrial]);
				UUIText text2 = base.GetText(25);
				if (text2 != null)
				{
					text2.SetColor(color);
				}
				if (this.RoleViewAgent.Source == ERoleViewSource.WheelTower)
				{
					Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(25), "WheelTower_Template_Role", Array.Empty<object>());
				}
			}
		}

		// Token: 0x06035031 RID: 217137 RVA: 0x00D4BC30 File Offset: 0x00D49E30
		protected void UpdateButtonState()
		{
			if (this.RoleInstance.IsTrialRole())
			{
				this.LevelUpButtonItem.SetActive(false);
				this.BreakthroughButtonItem.SetActive(false);
				return;
			}
			string id = "RoleMaxLevelPreview";
			this.LevelUpButtonItem.SetActive(this.RoleState != ERoleState.NoRole && this.RoleState != ERoleState.CanBreakthrough);
			if (this.RoleState != ERoleState.NoRole)
			{
				if (this.RoleState == ERoleState.MaxLevel)
				{
					id = "RoleReachMaxLevel";
				}
				else if (this.RoleState == ERoleState.CanBreakthrough)
				{
					id = "RoleBreakup";
				}
				else if (this.RoleState == ERoleState.CanLevelUp)
				{
					id = "RoleLevelUp";
				}
				string textById = ConfigBase<TextConfig>.Instance.GetTextById(id);
				this.LevelUpButtonItem.SetText(textById);
				this.LevelUpButtonItem.SetEnableClick(this.RoleState != ERoleState.MaxLevel);
			}
			this.BreakthroughButtonItem.SetActive(this.RoleState != ERoleState.NoRole && this.RoleState == ERoleState.CanBreakthrough);
			string textById2 = ConfigBase<TextConfig>.Instance.GetTextById("RoleBreakup");
			this.BreakthroughButtonItem.SetText(textById2);
		}

		// Token: 0x06035032 RID: 217138 RVA: 0x00D4BD30 File Offset: 0x00D49F30
		protected void SetRoleLevelUpState()
		{
			RoleLevelData levelData = this.RoleInstance.GetLevelData();
			if (levelData.GetRoleIsMaxLevel())
			{
				this.RoleState = ERoleState.MaxLevel;
				return;
			}
			if (levelData.GetRoleNeedBreakUp())
			{
				this.RoleState = ERoleState.CanBreakthrough;
				return;
			}
			this.RoleState = ERoleState.CanLevelUp;
		}

		// Token: 0x06035033 RID: 217139 RVA: 0x00D4BD70 File Offset: 0x00D49F70
		protected void PlayMontageStart()
		{
			ControllerBase<RoleController>.Instance.PlayRoleMontage(EPerformanceRoleState.Attribute_Perform, false, false, false);
		}

		// Token: 0x06035034 RID: 217140 RVA: 0x00D4BD80 File Offset: 0x00D49F80
		protected void PlayMontageStartWithReLoop()
		{
			ControllerBase<RoleController>.Instance.PlayRoleMontage(EPerformanceRoleState.Attribute_Perform, false, true, false);
		}

		// Token: 0x06035035 RID: 217141 RVA: 0x00D4BD90 File Offset: 0x00D49F90
		protected void UpdateAttribute()
		{
			IReadOnlyList<int> intArrayConfig = ConfigCommonParamById.GetIntArrayConfig("RoleAttributeDisplay6");
			for (int i = 0; i < this.AttributeItemList.Count; i++)
			{
				AttributeItem attributeItem = this.AttributeItemList[i];
				int id = intArrayConfig[i];
				float showAttributeValueById = this.RoleInstance.GetShowAttributeValueById(id);
				attributeItem.SetCurrentValue(showAttributeValueById);
				attributeItem.SetActive(true);
			}
		}

		// Token: 0x06035036 RID: 217142 RVA: 0x00D4BDEC File Offset: 0x00D49FEC
		protected override void OnBeforeShow()
		{
			this.RoleInstance = this.RoleViewAgent.GetCurSelectRoleData();
			this.UpdateRoleInfo();
			this.UpdateTeachBtn();
			this.LevelUpButtonItem.BindRedDot(ERedDotName.RoleAttributeTabLevelUp, this.RoleInstance.GetDataId());
		}

		// Token: 0x06035037 RID: 217143 RVA: 0x00D4BE23 File Offset: 0x00D4A023
		protected override void OnAfterShow()
		{
			this.PlayMontageStart();
		}

		// Token: 0x06035038 RID: 217144 RVA: 0x00D4BE2B File Offset: 0x00D4A02B
		protected override void OnBeforeHide()
		{
			this.LevelUpButtonItem.UnBindRedDot();
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.RoleSkin, null, 0);
		}

		// Token: 0x06035039 RID: 217145 RVA: 0x00D4BE48 File Offset: 0x00D4A048
		protected override void OnBeforeDestroy()
		{
			foreach (AttributeItem attributeItem in this.AttributeItemList)
			{
				attributeItem.Destroy(null);
			}
			this.AttributeItemList.Clear();
			this.LevelUpButtonItem = null;
		}

		// Token: 0x0401E87C RID: 125052
		private ERoleState RoleState;

		// Token: 0x0401E87D RID: 125053
		private ButtonItem LevelUpButtonItem;

		// Token: 0x0401E87E RID: 125054
		private ButtonItem BreakthroughButtonItem;

		// Token: 0x0401E87F RID: 125055
		protected RoleViewAgent RoleViewAgent;

		// Token: 0x0401E880 RID: 125056
		protected RoleDataBase RoleInstance;

		// Token: 0x0401E881 RID: 125057
		[Nullable(1)]
		protected List<AttributeItem> AttributeItemList = new List<AttributeItem>();

		// Token: 0x0401E882 RID: 125058
		protected IRoleSystemUiParams RoleSystemUiParams;

		// Token: 0x0401E883 RID: 125059
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<StarItem, IStarItemData> StarLayout;

		// Token: 0x0401E884 RID: 125060
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<RoleTagSmallIconItem, int> RoleTagLayout;

		// Token: 0x0401E885 RID: 125061
		private TsUiSceneRoleActor SceneRoleActor;

		// Token: 0x0200B013 RID: 45075
		[NullableContext(0)]
		private enum ERoleAttributeTabViewDefine
		{
			// Token: 0x040369D3 RID: 223699
			DetailButton,
			// Token: 0x040369D4 RID: 223700
			LevelUpButton,
			// Token: 0x040369D5 RID: 223701
			ExpText,
			// Token: 0x040369D6 RID: 223702
			ExpImage,
			// Token: 0x040369D7 RID: 223703
			BreakLevelText,
			// Token: 0x040369D8 RID: 223704
			AttributeItem,
			// Token: 0x040369D9 RID: 223705
			MaxLevelText,
			// Token: 0x040369DA RID: 223706
			LevelText,
			// Token: 0x040369DB RID: 223707
			ElementText,
			// Token: 0x040369DC RID: 223708
			ElementTexture,
			// Token: 0x040369DD RID: 223709
			StarRoot,
			// Token: 0x040369DE RID: 223710
			RoleNameText,
			// Token: 0x040369DF RID: 223711
			AttributeRootItem,
			// Token: 0x040369E0 RID: 223712
			TrialRootItem,
			// Token: 0x040369E1 RID: 223713
			BtnTeaching,
			// Token: 0x040369E2 RID: 223714
			BreakthroughButton,
			// Token: 0x040369E3 RID: 223715
			RoleChangeButton,
			// Token: 0x040369E4 RID: 223716
			RoleTagRoot,
			// Token: 0x040369E5 RID: 223717
			RoleTagItem,
			// Token: 0x040369E6 RID: 223718
			RoleTagButton,
			// Token: 0x040369E7 RID: 223719
			RoleBreakPreviewButton,
			// Token: 0x040369E8 RID: 223720
			RoleSkinButton,
			// Token: 0x040369E9 RID: 223721
			RoleSkinRedDot,
			// Token: 0x040369EA RID: 223722
			RoleChangeRedDot,
			// Token: 0x040369EB RID: 223723
			TrialRoleIcon,
			// Token: 0x040369EC RID: 223724
			TrialRoleTxt,
			// Token: 0x040369ED RID: 223725
			BgElementTexture,
			// Token: 0x040369EE RID: 223726
			MaxSpriteItem
		}
	}
}
