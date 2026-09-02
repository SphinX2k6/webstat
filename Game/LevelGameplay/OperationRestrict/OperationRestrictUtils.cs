using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using AkiClient.Game.Aki.Character.Input.Enum;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Input;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.NewWorld.Character.Common.Component.Explore;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.LevelGamePlay.OperationRestrict
{
	// Token: 0x02006B38 RID: 27448
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class OperationRestrictUtils : Singleton<OperationRestrictUtils>
	{
		// Token: 0x06043D2F RID: 277807 RVA: 0x01187410 File Offset: 0x01185610
		public void SetOperationRestrictByOption(SetPlayerOperationRestriction option)
		{
			switch (option.Type)
			{
			case EPlayerOperationType.EnableAll:
				this.SetOperationRestrictEnableAll();
				return;
			case EPlayerOperationType.DisableAll:
				this.SetOperationRestrictByDisableOption(option as IDisableAllPlayerOperation);
				return;
			case EPlayerOperationType.DisableModule:
				this.SetOperationRestrictByDisableSectionalOption(option as IDisableModulePlayerOperation);
				return;
			default:
				return;
			}
		}

		// Token: 0x06043D30 RID: 277808 RVA: 0x01187458 File Offset: 0x01185658
		public void SetOperationRestrictEnableAll()
		{
			this.SetInputUnlock();
			this.ClearInputLimitView();
			this.SetBattleUiEnableAll(false);
			this.SetInputBlockRestrict(false);
			this.SetMoveEnableAll();
			this.SetInteractEnable(false);
			this.SetSkillEnableAll();
			ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
			ModelBase<LevelGamePlayModel>.Instance.LevelRestrictOperationBlockAll = false;
			ControllerBase<PhoneMsgController>.Instance.IsPhoneMsgTipEnable = true;
			Singleton<EventSystem>.Instance.Emit(EEventName.OnNewPhoneMsgNeedShowTips);
		}

		// Token: 0x06043D31 RID: 277809 RVA: 0x011874C4 File Offset: 0x011856C4
		public void SetOperationRestrictByDisableOption(IDisableAllPlayerOperation option)
		{
			this.SetInputDisableAll();
			this.ClearInputLimitView();
			if (option.DisplayMode.GetValueOrDefault() == EDisplayModeInPlayerOp.HideUi)
			{
				this.SetBattleUiDisableAll(true);
			}
			else
			{
				this.SetBattleUiEnableAll(false);
			}
			if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.BattleView))
			{
				this.SetInputBlockRestrict(true);
			}
			else
			{
				this.SetInputBlockRestrict(false);
			}
			this.SetMoveDisableAll();
			this.SetInteractDisable(true);
			this.SetSkillDisableAll();
			ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
			ModelBase<LevelGamePlayModel>.Instance.LevelRestrictOperationBlockAll = true;
			ControllerBase<PhoneMsgController>.Instance.IsPhoneMsgTipEnable = false;
		}

		// Token: 0x06043D32 RID: 277810 RVA: 0x01187554 File Offset: 0x01185754
		public void SetOperationRestrictByDisableSectionalOption(IDisableModulePlayerOperation option)
		{
			this.SetInputEnableAll();
			this.SetBattleUiEnableAll(false);
			this.ClearInputLimitView();
			this.SetBattleUiRestrictByUiOption(option.UiOption);
			this.SetInputBlockRestrict(false);
			this.SetMoveRestrictByMoveOption(option.MoveOption);
			this.SetCameraRestrictByCameraOption(option.CameraOption);
			this.SetInteractRestrictByInteractOption(option.SceneInteractionOption);
			this.SetSkillRestrictBySkillOption(option.SkillOption);
			ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
			ModelBase<LevelGamePlayModel>.Instance.LevelRestrictOperationBlockAll = false;
		}

		// Token: 0x06043D33 RID: 277811 RVA: 0x011875CC File Offset: 0x011857CC
		public void SetInputUnlock()
		{
			Singleton<LevelEventLockInputState>.Instance.Unlock();
		}

		// Token: 0x06043D34 RID: 277812 RVA: 0x011875D8 File Offset: 0x011857D8
		public void SetInputLimitView(EUiViewName viewName, bool enable)
		{
			int num = Singleton<LevelEventLockInputState>.Instance.InputLimitView.IndexOf(viewName);
			bool flag = num != -1;
			if (enable)
			{
				if (!flag)
				{
					Singleton<LevelEventLockInputState>.Instance.InputLimitView.Add(viewName);
					return;
				}
			}
			else if (flag)
			{
				Singleton<LevelEventLockInputState>.Instance.InputLimitView.RemoveAt(num);
			}
		}

		// Token: 0x06043D35 RID: 277813 RVA: 0x01187628 File Offset: 0x01185828
		public void ClearInputLimitView()
		{
			Singleton<LevelEventLockInputState>.Instance.InputLimitEsc = false;
			Singleton<LevelEventLockInputState>.Instance.InputLimitView.Clear();
		}

		// Token: 0x06043D36 RID: 277814 RVA: 0x01187644 File Offset: 0x01185844
		public void SetInputEnableAll()
		{
			List<string> list = new List<string>
			{
				"FightInputRoot",
				"UiInputRoot",
				"InteractionRoot"
			};
			if (!Singleton<LevelEventLockInputState>.Instance.RealLockInput)
			{
				Singleton<LevelEventLockInputState>.Instance.Lock(list);
				return;
			}
			Singleton<LevelEventLockInputState>.Instance.InputTagNames = list;
		}

		// Token: 0x06043D37 RID: 277815 RVA: 0x0118769B File Offset: 0x0118589B
		public void SetInputDisableAll()
		{
			if (!Singleton<LevelEventLockInputState>.Instance.RealLockInput)
			{
				Singleton<LevelEventLockInputState>.Instance.Lock(new List<string>());
				return;
			}
			Singleton<LevelEventLockInputState>.Instance.InputTagNames.Clear();
		}

		// Token: 0x06043D38 RID: 277816 RVA: 0x011876C8 File Offset: 0x011858C8
		public void SetInputRestrictByTag(string targetTagName, bool enable)
		{
			if (!Singleton<LevelEventLockInputState>.Instance.RealLockInput)
			{
				Singleton<LevelEventLockInputState>.Instance.Lock(new List<string>
				{
					"FightInputRoot",
					"UiInputRoot",
					"InteractionRoot"
				});
			}
			Singleton<InputTagModifyUtils>.Instance.SetEnableInputTag(Singleton<LevelEventLockInputState>.Instance.InputTagNames, targetTagName, enable);
		}

		// Token: 0x06043D39 RID: 277817 RVA: 0x01187727 File Offset: 0x01185927
		public bool GetInputEnableByTag(string targetTagName)
		{
			return !Singleton<LevelEventLockInputState>.Instance.RealLockInput || Singleton<InputTagModifyUtils>.Instance.GetIsInputTagEnable(Singleton<LevelEventLockInputState>.Instance.InputTagNames, targetTagName, false);
		}

		// Token: 0x06043D3A RID: 277818 RVA: 0x0118774D File Offset: 0x0118594D
		public void SetExploreSkillInputRestrict(bool enable)
		{
			ModelBase<BattleInputModel>.Instance.SetInputEnable(AkiClient.Game.Aki.Character.Input.Enum.EInputAction.幻象1, !enable, EBattleInputReason.LevelEvent);
		}

		// Token: 0x06043D3B RID: 277819 RVA: 0x01187764 File Offset: 0x01185964
		public void SetBattleUiEnableAll(bool bLockInput)
		{
			ModelBase<BattleUiModel>.Instance.ChildViewData.ShowBattleView(EBattleUiVisibleReason.LevelEvent, 0);
			if (bLockInput)
			{
				this.SetInputRestrictByTag("UiInputRoot.ShortcutKeyTag", true);
				Singleton<LevelEventLockInputState>.Instance.InputLimitEsc = false;
				ViewHotKeyHandle[] allViewHotKeyHandle = Singleton<InputManager>.Instance.GetAllViewHotKeyHandle();
				for (int i = 0; i < allViewHotKeyHandle.Length; i++)
				{
					EUiViewName? viewName = allViewHotKeyHandle[i].ViewName;
					if (viewName != null)
					{
						this.SetInputLimitView(viewName.Value, false);
					}
				}
			}
		}

		// Token: 0x06043D3C RID: 277820 RVA: 0x011877D8 File Offset: 0x011859D8
		public void SetBattleUiDisableAll(bool bLockInput)
		{
			ModelBase<BattleUiModel>.Instance.ChildViewData.HideBattleView(EBattleUiVisibleReason.LevelEvent, null, 0);
			if (bLockInput)
			{
				this.SetInputRestrictByTag("UiInputRoot.ShortcutKeyTag", false);
				Singleton<LevelEventLockInputState>.Instance.InputLimitEsc = true;
				ViewHotKeyHandle[] allViewHotKeyHandle = Singleton<InputManager>.Instance.GetAllViewHotKeyHandle();
				for (int i = 0; i < allViewHotKeyHandle.Length; i++)
				{
					EUiViewName? viewName = allViewHotKeyHandle[i].ViewName;
					if (viewName != null)
					{
						this.SetInputLimitView(viewName.Value, true);
					}
				}
			}
		}

		// Token: 0x06043D3D RID: 277821 RVA: 0x0118784A File Offset: 0x01185A4A
		[NullableContext(2)]
		public void SetBattleUiRestrictByUiOption(IUiOperationType uiOption)
		{
			if (uiOption != null && uiOption.Type == EUiOperationType.Disable)
			{
				this.SetBattleUiRestrictByDisableUiOption(uiOption as IDisableUiOperation);
				return;
			}
			if (uiOption != null && uiOption.Type == EUiOperationType.EnableSectionalUi)
			{
				this.SetBattleUiRestrictByEnableSectionalUiOption(uiOption as IEnableSectionalUi);
				return;
			}
			this.SetBattleUiRestrictByEnableUiOption(uiOption as IEnableUiOperation);
		}

		// Token: 0x06043D3E RID: 277822 RVA: 0x0118788C File Offset: 0x01185A8C
		[NullableContext(2)]
		public void SetBattleUiRestrictByEnableUiOption(IEnableUiOperation uiOption)
		{
			ModelBase<BattleUiModel>.Instance.ChildViewData.SetChildrenVisible(EBattleUiVisibleReason.LevelEvent, this.BattleUiChildrenControlledByUiOption, true, true, 0);
			if (Singleton<LevelEventLockInputState>.Instance.RealLockInput)
			{
				this.SetInputRestrictByTag("UiInputRoot.ShortcutKeyTag", true);
				Singleton<LevelEventLockInputState>.Instance.InputLimitEsc = false;
				ViewHotKeyHandle[] allViewHotKeyHandle = Singleton<InputManager>.Instance.GetAllViewHotKeyHandle();
				for (int i = 0; i < allViewHotKeyHandle.Length; i++)
				{
					EUiViewName? viewName = allViewHotKeyHandle[i].ViewName;
					if (viewName != null)
					{
						this.SetInputLimitView(viewName.Value, false);
					}
				}
			}
		}

		// Token: 0x06043D3F RID: 277823 RVA: 0x01187910 File Offset: 0x01185B10
		public void SetBattleUiRestrictByDisableUiOption(IDisableUiOperation uiOption)
		{
			ModelBase<BattleUiModel>.Instance.ChildViewData.SetChildrenVisible(EBattleUiVisibleReason.LevelEvent, this.BattleUiChildrenControlledByUiOption, false, true, 0);
			this.SetInputRestrictByTag("UiInputRoot.ShortcutKeyTag", false);
			Singleton<LevelEventLockInputState>.Instance.InputLimitEsc = true;
			ViewHotKeyHandle[] allViewHotKeyHandle = Singleton<InputManager>.Instance.GetAllViewHotKeyHandle();
			for (int i = 0; i < allViewHotKeyHandle.Length; i++)
			{
				EUiViewName? viewName = allViewHotKeyHandle[i].ViewName;
				if (viewName != null)
				{
					this.SetInputLimitView(viewName.Value, true);
				}
			}
		}

		// Token: 0x06043D40 RID: 277824 RVA: 0x01187988 File Offset: 0x01185B88
		public void SetBattleUiRestrictByEnableSectionalUiOption(IEnableSectionalUi uiOption)
		{
			HashSet<EBattleUiChild> hashSet = new HashSet<EBattleUiChild>();
			HashSet<EBattleUiChild> hashSet2 = new HashSet<EBattleUiChild>();
			if (uiOption.ShowEsc.GetValueOrDefault())
			{
				hashSet.Add(EBattleUiChild.ExitButton);
			}
			else
			{
				hashSet2.Add(EBattleUiChild.ExitButton);
				Singleton<LevelEventLockInputState>.Instance.InputLimitEsc = true;
			}
			if (uiOption.ShowMiniMap.GetValueOrDefault())
			{
				hashSet.Add(EBattleUiChild.MiniMap);
			}
			else
			{
				hashSet2.Add(EBattleUiChild.MiniMap);
				this.SetInputLimitView(EUiViewName.WorldMapView, true);
			}
			if (uiOption.ShowQuestTrack.GetValueOrDefault())
			{
				hashSet.Add(EBattleUiChild.Mission);
				hashSet.Add(EBattleUiChild.BattleHud);
			}
			else
			{
				hashSet2.Add(EBattleUiChild.Mission);
				hashSet2.Add(EBattleUiChild.BattleHud);
			}
			if (uiOption.ShowScreenEffect.GetValueOrDefault())
			{
				hashSet.Add(EBattleUiChild.ScreenEffect);
			}
			else
			{
				hashSet2.Add(EBattleUiChild.ScreenEffect);
			}
			if (uiOption.ShowPositionOfficial.GetValueOrDefault())
			{
				hashSet.Add(EBattleUiChild.PositionOfficial);
			}
			else
			{
				hashSet2.Add(EBattleUiChild.PositionOfficial);
			}
			if (uiOption.ShowSystem.GetValueOrDefault())
			{
				hashSet.Add(EBattleUiChild.TopButton);
				hashSet.Add(EBattleUiChild.HomeButton);
				hashSet.Add(EBattleUiChild.Chat);
			}
			else
			{
				hashSet2.Add(EBattleUiChild.TopButton);
				hashSet2.Add(EBattleUiChild.HomeButton);
				hashSet2.Add(EBattleUiChild.Chat);
				ViewHotKeyHandle[] allViewHotKeyHandle = Singleton<InputManager>.Instance.GetAllViewHotKeyHandle();
				for (int i = 0; i < allViewHotKeyHandle.Length; i++)
				{
					EUiViewName? viewName = allViewHotKeyHandle[i].ViewName;
					if (viewName != null && viewName != EUiViewName.WorldMapView)
					{
						this.SetInputLimitView(viewName.Value, true);
					}
				}
			}
			if (uiOption.ShowOther.GetValueOrDefault())
			{
				foreach (EBattleUiChild item in this.BattleUiChildrenControlledByUiOption)
				{
					if (!hashSet2.Contains(item) && !hashSet.Contains(item))
					{
						hashSet.Add(item);
					}
				}
			}
			else
			{
				bool? showOther = uiOption.ShowOther;
				bool flag = false;
				if (showOther.GetValueOrDefault() == flag & showOther != null)
				{
					foreach (EBattleUiChild item2 in this.BattleUiChildrenControlledByUiOption)
					{
						if (!hashSet2.Contains(item2) && !hashSet.Contains(item2))
						{
							hashSet2.Add(item2);
						}
					}
					hashSet2.Add(EBattleUiChild.GuideTipsView);
				}
				else
				{
					if (uiOption.ShowRoleFormation.GetValueOrDefault())
					{
						hashSet.Add(EBattleUiChild.Formation);
						hashSet.Add(EBattleUiChild.GamepadFormation);
					}
					else
					{
						hashSet2.Add(EBattleUiChild.Formation);
						hashSet2.Add(EBattleUiChild.GamepadFormation);
					}
					if (uiOption.ShowRoleStatus.GetValueOrDefault())
					{
						hashSet.Add(EBattleUiChild.RoleState);
					}
					else
					{
						hashSet2.Add(EBattleUiChild.RoleState);
					}
					if (uiOption.ShowBossStatus.GetValueOrDefault())
					{
						hashSet.Add(EBattleUiChild.BossState);
					}
					else
					{
						hashSet2.Add(EBattleUiChild.BossState);
					}
					if (uiOption.ShowMonsterHpBar.GetValueOrDefault())
					{
						hashSet.Add(EBattleUiChild.HeadState);
						hashSet.Add(EBattleUiChild.PartState);
					}
					else
					{
						hashSet2.Add(EBattleUiChild.HeadState);
						hashSet2.Add(EBattleUiChild.PartState);
					}
					if (uiOption.ShowDamageText.GetValueOrDefault())
					{
						hashSet.Add(EBattleUiChild.DamageView);
					}
					else
					{
						hashSet2.Add(EBattleUiChild.DamageView);
					}
					if (uiOption.ShowGuideLayer.GetValueOrDefault())
					{
						hashSet.Add(EBattleUiChild.GuideTipsView);
					}
					else
					{
						hashSet2.Add(EBattleUiChild.GuideTipsView);
					}
					foreach (EBattleUiChild item3 in this.BattleUiChildrenControlledByUiOption)
					{
						if (!hashSet2.Contains(item3) && !hashSet.Contains(item3))
						{
							hashSet2.Add(item3);
						}
					}
				}
			}
			if (uiOption.AlwaysShowUiSections != null)
			{
				using (List<EUiElement>.Enumerator enumerator = uiOption.AlwaysShowUiSections.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current == EUiElement.Guide)
						{
							hashSet2.Remove(EBattleUiChild.GuideTipsView);
							hashSet.Add(EBattleUiChild.GuideTipsView);
						}
					}
				}
			}
			ModelBase<BattleUiModel>.Instance.ChildViewData.SetChildrenVisible(EBattleUiVisibleReason.LevelEvent, hashSet2.ToArray<EBattleUiChild>(), false, true, 0);
			ModelBase<BattleUiModel>.Instance.ChildViewData.SetChildrenVisible(EBattleUiVisibleReason.LevelEvent, hashSet.ToArray<EBattleUiChild>(), true, true, 0);
		}

		// Token: 0x06043D41 RID: 277825 RVA: 0x01187DA4 File Offset: 0x01185FA4
		[NullableContext(2)]
		public void SetBattleUiRestrictByUiChildType(EBattleUiChild[] uiShow, EBattleUiChild[] uiHide)
		{
			if (uiHide != null && uiHide.Length != 0)
			{
				ModelBase<BattleUiModel>.Instance.ChildViewData.SetChildrenVisible(EBattleUiVisibleReason.LevelEvent, uiHide, false, true, 0);
			}
			if (uiShow != null && uiShow.Length != 0)
			{
				ModelBase<BattleUiModel>.Instance.ChildViewData.SetChildrenVisible(EBattleUiVisibleReason.LevelEvent, uiShow, true, true, 0);
			}
		}

		// Token: 0x1700A321 RID: 41761
		// (get) Token: 0x06043D42 RID: 277826 RVA: 0x01187DDC File Offset: 0x01185FDC
		private EBattleUiChild[] BattleUiChildrenControlledByUiOption
		{
			get
			{
				if (this.BattleUiChildrenControlledByUiOptionCache != null)
				{
					return this.BattleUiChildrenControlledByUiOptionCache;
				}
				this.BattleUiChildrenControlledByUiOptionCache = new List<EBattleUiChild>().ToArray();
				List<EBattleUiChild> list = new List<EBattleUiChild>();
				for (int i = 0; i < 46; i++)
				{
					if (i != 12 && i != 18 && i != 19 && i != 9 && i != 10 && i != 39 && i != 40 && i != 20 && i != 21)
					{
						list.Add((EBattleUiChild)i);
					}
				}
				this.BattleUiChildrenControlledByUiOptionCache = list.ToArray();
				return this.BattleUiChildrenControlledByUiOptionCache;
			}
		}

		// Token: 0x06043D43 RID: 277827 RVA: 0x01187E61 File Offset: 0x01186061
		public void SetInputBlockRestrict(bool enable)
		{
			LevelEventLockMaskModule.SetLockMask(enable);
		}

		// Token: 0x06043D44 RID: 277828 RVA: 0x01187E69 File Offset: 0x01186069
		[NullableContext(2)]
		public void SetMoveRestrictByMoveOption(IMoveOperationType moveOption)
		{
			if (moveOption != null && moveOption.Type == EMoveOperationType.Disable)
			{
				this.SetMoveRestrictByDisableMoveOption((IDisableMoveOperation)moveOption);
				return;
			}
			this.SetMoveEnableAll();
		}

		// Token: 0x06043D45 RID: 277829 RVA: 0x01187E8C File Offset: 0x0118608C
		public void SetMoveEnableAll()
		{
			ControllerBase<InputController>.Instance.SetMoveControlEnabled(true, true, true, true);
			this.SetMoveRestrictTag(GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.禁止冲刺"], false);
			this.SetMoveRestrictTag(GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.强制行走"], false);
			this.SetMoveRestrictTag(GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.强制慢跑"], false);
		}

		// Token: 0x06043D46 RID: 277830 RVA: 0x01187EE9 File Offset: 0x011860E9
		public void SetMoveDisableAll()
		{
			ControllerBase<InputController>.Instance.SetMoveControlEnabled(false, false, false, false);
		}

		// Token: 0x06043D47 RID: 277831 RVA: 0x01187EF9 File Offset: 0x011860F9
		public void SetSwitchTeamRoleRestrict(bool enable)
		{
			this.SetPlayerRestrictTag(GameplayTagDefine.EGameplayTagId["角色.Common.BUFF通用标识.不能切人"], enable);
		}

		// Token: 0x06043D48 RID: 277832 RVA: 0x01187F14 File Offset: 0x01186114
		public void SetMoveRestrictByDisableMoveOption(IDisableMoveOperation moveOption)
		{
			this.SetMoveRestrictTag(GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.禁止冲刺"], moveOption.ForbidSprint.GetValueOrDefault());
			this.SetMoveRestrictTag(GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.强制行走"], moveOption.ForceWalk.GetValueOrDefault());
			this.SetMoveRestrictTag(GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.强制慢跑"], !moveOption.ForceWalk.GetValueOrDefault() && moveOption.ForceJog.GetValueOrDefault());
			ControllerBase<InputController>.Instance.SetMoveControlEnabled(moveOption.Forward, moveOption.Back, moveOption.Left, moveOption.Right);
		}

		// Token: 0x06043D49 RID: 277833 RVA: 0x01187FBF File Offset: 0x011861BF
		private void SetMoveRestrictTag(int tagId, bool enable)
		{
			this.SetPlayerRestrictTag(tagId, enable);
		}

		// Token: 0x06043D4A RID: 277834 RVA: 0x01187FCC File Offset: 0x011861CC
		private unsafe void SetPlayerRestrictTag(int tagId, bool enable)
		{
			int playerId = ModelBase<CreatureModel>.Instance.GetPlayerId();
			if (!ControllerBase<FormationDataController>.Instance.IsPlayerExist(playerId))
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.LevelEvent;
				ELogAuthor author = ELogAuthor.ZYL;
				string message = "[OperationRestrictUtils.SetPlayerRestrictTag] 找不到当前玩家";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("PlayerId", playerId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("TagName", GameplayTagUtils.GetNameByTagId(tagId));
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			if (enable)
			{
				if (!ControllerBase<FormationDataController>.Instance.HasPlayerTag(playerId, tagId, true))
				{
					ControllerBase<FormationDataController>.Instance.AddPlayerTag(playerId, new int?(tagId));
					return;
				}
			}
			else if (ControllerBase<FormationDataController>.Instance.HasPlayerTag(playerId, tagId, true))
			{
				ControllerBase<FormationDataController>.Instance.RemovePlayerTag(playerId, new int?(tagId));
			}
		}

		// Token: 0x06043D4B RID: 277835 RVA: 0x01188093 File Offset: 0x01186293
		[NullableContext(2)]
		public void SetInteractRestrictByInteractOption(ISceneInteractionOperationType interactOption)
		{
			if (interactOption != null && interactOption.Type == ESceneInteractionOperationType.Disable)
			{
				this.SetInteractDisable(true);
				return;
			}
			this.SetInteractEnable(true);
		}

		// Token: 0x06043D4C RID: 277836 RVA: 0x011880B0 File Offset: 0x011862B0
		public void SetInteractEnable(bool bLockInput)
		{
			if (bLockInput)
			{
				this.SetInputRestrictByTag("InteractionRoot", true);
			}
			this.SetBattleUiRestrictByUiChildType(new EBattleUiChild[]
			{
				EBattleUiChild.InteractionHint
			}, null);
		}

		// Token: 0x06043D4D RID: 277837 RVA: 0x011880D3 File Offset: 0x011862D3
		public void SetInteractDisable(bool bLockInput)
		{
			if (bLockInput)
			{
				this.SetInputRestrictByTag("InteractionRoot", false);
			}
			this.SetBattleUiRestrictByUiChildType(null, new EBattleUiChild[]
			{
				EBattleUiChild.InteractionHint
			});
		}

		// Token: 0x06043D4E RID: 277838 RVA: 0x011880F6 File Offset: 0x011862F6
		[NullableContext(2)]
		public void SetCameraRestrictByCameraOption(ICameraOperationType cameraOption)
		{
			if (cameraOption != null && cameraOption.Type == ECameraOperationType.Disable)
			{
				this.SetCameraDisable();
				return;
			}
			if (cameraOption != null && cameraOption.Type == ECameraOperationType.EnableSection)
			{
				this.SetCameraDisable();
				this.SetCameraEnableSection((IEnableSectionalCameraOperation)cameraOption);
				return;
			}
			this.SetCameraEnable();
		}

		// Token: 0x06043D4F RID: 277839 RVA: 0x01188130 File Offset: 0x01186330
		public void SetCameraEnable()
		{
			this.SetInputRestrictByTag("FightInputRoot.FightInput.AxisInput.CameraInput", true);
		}

		// Token: 0x06043D50 RID: 277840 RVA: 0x0118813E File Offset: 0x0118633E
		public void SetCameraDisable()
		{
			this.SetInputRestrictByTag("FightInputRoot.FightInput.AxisInput.CameraInput", false);
		}

		// Token: 0x06043D51 RID: 277841 RVA: 0x0118814C File Offset: 0x0118634C
		public void SetCameraEnableSection(IEnableSectionalCameraOperation cameraOption)
		{
			if (cameraOption.EnableRotate.GetValueOrDefault())
			{
				this.SetInputRestrictByTag("FightInputRoot.FightInput.AxisInput.CameraInput.CameraRotation", true);
			}
			if (cameraOption.EnableZoom.GetValueOrDefault())
			{
				this.SetInputRestrictByTag("FightInputRoot.FightInput.AxisInput.CameraInput.CameraZoom", true);
			}
		}

		// Token: 0x06043D52 RID: 277842 RVA: 0x01188194 File Offset: 0x01186394
		[NullableContext(2)]
		public void SetSkillRestrictBySkillOption(ISkillOperationType skillOption)
		{
			if (skillOption == null || (skillOption != null && skillOption.Type == ESkillOperationType.Enable))
			{
				this.SetSkillEnableAll();
				return;
			}
			if (skillOption != null && skillOption.Type == ESkillOperationType.DisableSection)
			{
				this.SetSkillRestrictByDisableSectionalSkillOption((IDisableSectionalSkillOperation)skillOption);
				return;
			}
			if (skillOption != null && skillOption.Type == ESkillOperationType.Disable)
			{
				this.SetSkillRestrictByDisableSkillOption((IDisableSkillOperation)skillOption);
			}
		}

		// Token: 0x06043D53 RID: 277843 RVA: 0x011881E8 File Offset: 0x011863E8
		public void SetSkillEnableAll()
		{
			ModelBase<LevelFuncFlagModel>.Instance.SetFuncFlagEnable(ELevelFuncFlagId.ExploreSkillRoulette, true);
			ModelBase<CharacterExploreModel>.Instance.MotorcycleHookDetectRestriction.SetDisabled(false, "SetSkillEnableAll");
			ModelBase<CharacterExploreModel>.Instance.MotorcycleHookDetectRestriction.ClearSkillIdRestrictions("SetSkillEnableAll");
			ModelBase<ExploreSkillFlagModel>.Instance.EnableAllExploreSkillFlag();
			ModelBase<LevelFuncFlagModel>.Instance.SetFuncFlagEnable(ELevelFuncFlagId.TempTeleporterPlacement, true);
			this.SetSwitchTeamRoleRestrict(false);
			this.SetBattleUiRestrictByUiChildType(this.SkillButtonUiChildTypeList, null);
			ModelBase<BattleInputModel>.Instance.SetAllInputEnable(true, EBattleInputReason.LevelEvent);
		}

		// Token: 0x06043D54 RID: 277844 RVA: 0x01188264 File Offset: 0x01186464
		public void SetSkillDisableAll()
		{
			this.SetInputRestrictByTag("FightInputRoot.FightInput.ActionInput", false);
			ModelBase<LevelFuncFlagModel>.Instance.SetFuncFlagEnable(ELevelFuncFlagId.ExploreSkillRoulette, false);
			ModelBase<CharacterExploreModel>.Instance.MotorcycleHookDetectRestriction.SetDisabled(true, "SetSkillDisableAll");
			ModelBase<ExploreSkillFlagModel>.Instance.DisableAllExploreSkillFlag();
			ModelBase<LevelFuncFlagModel>.Instance.SetFuncFlagEnable(ELevelFuncFlagId.TempTeleporterPlacement, false);
			this.SetBattleUiRestrictByUiChildType(null, this.SkillButtonUiChildTypeList);
			ModelBase<BattleInputModel>.Instance.SetAllInputEnable(false, EBattleInputReason.LevelEvent);
		}

		// Token: 0x06043D55 RID: 277845 RVA: 0x011882D0 File Offset: 0x011864D0
		public void SetSkillRestrictByDisableSkillOption(IDisableSkillOperation skillOption)
		{
			this.SetInputRestrictByTag("FightInputRoot.FightInput.ActionInput", false);
			ModelBase<LevelFuncFlagModel>.Instance.SetFuncFlagEnable(ELevelFuncFlagId.ExploreSkillRoulette, !skillOption.DisableSkillWheel.GetValueOrDefault());
			ModelBase<CharacterExploreModel>.Instance.MotorcycleHookDetectRestriction.SetDisabled(true, "SetSkillDisableAll");
			ModelBase<ExploreSkillFlagModel>.Instance.DisableAllExploreSkillFlag();
			ModelBase<LevelFuncFlagModel>.Instance.SetFuncFlagEnable(ELevelFuncFlagId.TempTeleporterPlacement, false);
			if (skillOption.DisplayMode.GetValueOrDefault() == EDisplayModeInSkillOp.Hide)
			{
				this.SetBattleUiRestrictByUiChildType(null, this.SkillButtonUiChildTypeList);
				ModelBase<BattleInputModel>.Instance.SetAllInputEnable(false, EBattleInputReason.LevelEvent);
				return;
			}
			EDisplayModeInSkillOp? displayMode = skillOption.DisplayMode;
			EDisplayModeInSkillOp edisplayModeInSkillOp = EDisplayModeInSkillOp.Ashen;
			if (displayMode.GetValueOrDefault() == edisplayModeInSkillOp & displayMode != null)
			{
				this.SetBattleUiRestrictByUiChildType(this.SkillButtonUiChildTypeList, null);
				ModelBase<BattleInputModel>.Instance.SetAllInputEnable(false, EBattleInputReason.LevelEvent);
				return;
			}
			if (skillOption.DisplayMode == null)
			{
				this.SetBattleUiRestrictByUiChildType(this.SkillButtonUiChildTypeList, null);
				ModelBase<BattleInputModel>.Instance.SetAllInputEnable(true, EBattleInputReason.LevelEvent);
				return;
			}
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.LevelEvent;
			ELogAuthor author = ELogAuthor.ZYL;
			string message = "[OperationRestrictUtils.SetSkillRestrictByDisableSkillOption] 配置出错";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("SkillOption", skillOption);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x06043D56 RID: 277846 RVA: 0x011883E4 File Offset: 0x011865E4
		public void SetSkillRestrictByDisableSectionalSkillOption(IDisableSectionalSkillOperation skillOption)
		{
			ModelBase<LevelFuncFlagModel>.Instance.SetFuncFlagEnable(ELevelFuncFlagId.ExploreSkillRoulette, !skillOption.DisableSkillWheel.GetValueOrDefault());
			IDisableExploreSkill disableExploreSkill = skillOption.DisableExploreSkill;
			List<EExploreSkillType> list = (disableExploreSkill != null) ? disableExploreSkill.ExploreSkillList : null;
			IDisableExploreSkill disableExploreSkill2 = skillOption.DisableExploreSkill;
			bool valueOrDefault = ((disableExploreSkill2 != null) ? disableExploreSkill2.IsComplementary : null).GetValueOrDefault();
			MotorcycleHookDetectRestriction motorcycleHookDetectRestriction = ModelBase<CharacterExploreModel>.Instance.MotorcycleHookDetectRestriction;
			string reason = "SetSkillRestrictByDisableSectionalSkillOption";
			motorcycleHookDetectRestriction.SetDisabled(false, reason);
			foreach (EExploreSkillType eexploreSkillType in ExploreSkillFlagDefine.levelOperationRestrictExploreSkillTypes)
			{
				bool flag = list != null && list.Contains(eexploreSkillType);
				bool flag2 = valueOrDefault ? flag : (!flag);
				if (motorcycleHookDetectRestriction.CanHandleSkillId((int)eexploreSkillType))
				{
					motorcycleHookDetectRestriction.SetDisabledBySkillId((int)eexploreSkillType, !flag2, reason);
				}
				else
				{
					ModelBase<ExploreSkillFlagModel>.Instance.SetExploreSkillFlagEnable(eexploreSkillType, flag2);
				}
			}
			bool flag3 = list != null && list.Contains(EExploreSkillType.PlaceTemporaryTeleport);
			bool enable = valueOrDefault ? flag3 : (!flag3);
			ModelBase<LevelFuncFlagModel>.Instance.SetFuncFlagEnable(ELevelFuncFlagId.TempTeleporterPlacement, enable);
			this.SetSwitchTeamRoleRestrict(skillOption.DisableSwitchRole.GetValueOrDefault());
			HashSet<int> hashSet = new HashSet<int>();
			IDisableBattleSkillOptions disableBattleSkill = skillOption.DisableBattleSkill;
			if (disableBattleSkill != null && disableBattleSkill.IsDisableCharacterSkill.GetValueOrDefault())
			{
				this.AddDisableCharacterSectionalSkillsToSet(new IDisableCharacterSectionalSkillOption
				{
					DisableJump = new bool?(true),
					DisableShowClimb = new bool?(true),
					DisableAttack = new bool?(true),
					DisableDodge = new bool?(true),
					DisableSkill1 = new bool?(true),
					DisableUltimateSkill = new bool?(true),
					DisableSwitchRole1 = new bool?(true),
					DisableSwitchRole2 = new bool?(true),
					DisableSwitchRole3 = new bool?(true),
					DisableLock = new bool?(true),
					DisableAim = new bool?(true)
				}, hashSet);
			}
			IDisableBattleSkillOptions disableBattleSkill2 = skillOption.DisableBattleSkill;
			if (disableBattleSkill2 != null && disableBattleSkill2.IsDisablePhantomSkill.GetValueOrDefault())
			{
				hashSet.Add(9);
			}
			IDisableBattleSkillOptions disableBattleSkill3 = skillOption.DisableBattleSkill;
			if (((disableBattleSkill3 != null) ? disableBattleSkill3.IsDisableCharacterSectionalSkill : null) != null)
			{
				this.AddDisableCharacterSectionalSkillsToSet(skillOption.DisableBattleSkill.IsDisableCharacterSectionalSkill, hashSet);
			}
			if (skillOption.DisplayMode != null && skillOption.DisplayMode.GetValueOrDefault() != EDisplayModeInSkillOp.Disable)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.LevelEvent;
				ELogAuthor author = ELogAuthor.ZYL;
				string message = "[OperationRestrictUtils.SetSkillRestrictByDisableSectionalSkillOption] 配置出错";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("SkillOption", skillOption);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.SetBattleUiRestrictByUiChildType(this.SkillButtonUiChildTypeList, null);
			if (hashSet.Count <= 0)
			{
				ModelBase<BattleInputModel>.Instance.SetAllInputEnable(true, EBattleInputReason.LevelEvent);
				return;
			}
			ModelBase<BattleInputModel>.Instance.SetAllInputEnableWithIgnoreSet(true, hashSet, EBattleInputReason.LevelEvent);
		}

		// Token: 0x06043D57 RID: 277847 RVA: 0x01188690 File Offset: 0x01186890
		private void AddDisableCharacterSectionalSkillsToSet(IDisableCharacterSectionalSkillOption sectionalSkillOption, HashSet<int> disableInputAction)
		{
			if (sectionalSkillOption.DisableJump.GetValueOrDefault())
			{
				disableInputAction.Add(1);
			}
			if (sectionalSkillOption.DisableShowClimb.GetValueOrDefault())
			{
				disableInputAction.Add(2);
			}
			if (sectionalSkillOption.DisableAttack.GetValueOrDefault())
			{
				disableInputAction.Add(4);
			}
			if (sectionalSkillOption.DisableDodge.GetValueOrDefault())
			{
				disableInputAction.Add(5);
			}
			if (sectionalSkillOption.DisableSkill1.GetValueOrDefault())
			{
				disableInputAction.Add(6);
			}
			if (sectionalSkillOption.DisableUltimateSkill.GetValueOrDefault())
			{
				disableInputAction.Add(8);
			}
			if (sectionalSkillOption.DisableExploreInput.GetValueOrDefault())
			{
				disableInputAction.Add(7);
			}
			if (sectionalSkillOption.DisableSwitchRole1.GetValueOrDefault())
			{
				disableInputAction.Add(10);
			}
			if (sectionalSkillOption.DisableSwitchRole2.GetValueOrDefault())
			{
				disableInputAction.Add(11);
			}
			if (sectionalSkillOption.DisableSwitchRole3.GetValueOrDefault())
			{
				disableInputAction.Add(12);
			}
			if (sectionalSkillOption.DisableLock.GetValueOrDefault())
			{
				disableInputAction.Add(13);
			}
			if (sectionalSkillOption.DisableAim.GetValueOrDefault())
			{
				disableInputAction.Add(14);
			}
		}

		// Token: 0x04025EF5 RID: 155381
		private readonly EBattleUiChild[] SkillButtonUiChildTypeList = new EBattleUiChild[]
		{
			EBattleUiChild.SkillButton,
			EBattleUiChild.GamepadSkillButton,
			EBattleUiChild.MotorcycleMobileSkillButton
		};

		// Token: 0x04025EF6 RID: 155382
		[Nullable(2)]
		private EBattleUiChild[] BattleUiChildrenControlledByUiOptionCache;

		// Token: 0x04025EF7 RID: 155383
		private readonly ISkillOptionToInputAction[] SkillOptionToInputAction = new ISkillOptionToInputAction[]
		{
			new ISkillOptionToInputAction
			{
				OptionKey = "DisableJump",
				InputAction = AkiClient.Game.Aki.Character.Input.Enum.EInputAction.跳跃
			},
			new ISkillOptionToInputAction
			{
				OptionKey = "DisableShowClimb",
				InputAction = AkiClient.Game.Aki.Character.Input.Enum.EInputAction.攀爬
			},
			new ISkillOptionToInputAction
			{
				OptionKey = "DisableAttack",
				InputAction = AkiClient.Game.Aki.Character.Input.Enum.EInputAction.攻击
			},
			new ISkillOptionToInputAction
			{
				OptionKey = "DisableDodge",
				InputAction = AkiClient.Game.Aki.Character.Input.Enum.EInputAction.闪避
			},
			new ISkillOptionToInputAction
			{
				OptionKey = "DisableSkill1",
				InputAction = AkiClient.Game.Aki.Character.Input.Enum.EInputAction.技能1
			},
			new ISkillOptionToInputAction
			{
				OptionKey = "DisableUltimateSkill",
				InputAction = AkiClient.Game.Aki.Character.Input.Enum.EInputAction.大招
			},
			new ISkillOptionToInputAction
			{
				OptionKey = "DisableExploreInput",
				InputAction = AkiClient.Game.Aki.Character.Input.Enum.EInputAction.幻象1
			},
			new ISkillOptionToInputAction
			{
				OptionKey = "DisableSwitchRole1",
				InputAction = AkiClient.Game.Aki.Character.Input.Enum.EInputAction.切换角色1
			},
			new ISkillOptionToInputAction
			{
				OptionKey = "DisableSwitchRole2",
				InputAction = AkiClient.Game.Aki.Character.Input.Enum.EInputAction.切换角色2
			},
			new ISkillOptionToInputAction
			{
				OptionKey = "DisableSwitchRole3",
				InputAction = AkiClient.Game.Aki.Character.Input.Enum.EInputAction.切换角色3
			},
			new ISkillOptionToInputAction
			{
				OptionKey = "DisableLock",
				InputAction = AkiClient.Game.Aki.Character.Input.Enum.EInputAction.锁定目标
			},
			new ISkillOptionToInputAction
			{
				OptionKey = "DisableAim",
				InputAction = AkiClient.Game.Aki.Character.Input.Enum.EInputAction.瞄准
			}
		};
	}
}
