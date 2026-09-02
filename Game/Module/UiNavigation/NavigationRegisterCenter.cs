using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.UiNavigation.New.PhantomArena;
using CSharpScript.Game.Module.UiNavigation.New.Vision;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004C90 RID: 19600
	[NullableContext(1)]
	[Nullable(0)]
	public class NavigationRegisterCenter : IStaticVariableResetter
	{
		// Token: 0x0603316F RID: 209263 RVA: 0x00CCB6F6 File Offset: 0x00CC98F6
		static NavigationRegisterCenter()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(NavigationRegisterCenter.CreateStaticDefaultValue), new Action(NavigationRegisterCenter.ResetStaticDefaultValue));
		}

		// Token: 0x170087B7 RID: 34743
		// (get) Token: 0x06033170 RID: 209264 RVA: 0x00CCB715 File Offset: 0x00CC9915
		private static Dictionary<ENavigationSelectableDefine, Type> SelectableCtorMap
		{
			get
			{
				return NavigationRegisterCenter._selectableCtorMap;
			}
		}

		// Token: 0x170087B8 RID: 34744
		// (get) Token: 0x06033171 RID: 209265 RVA: 0x00CCB71C File Offset: 0x00CC991C
		private static Dictionary<ESpecialPanelHandleDefine, Type> PanelHandleCtorMap
		{
			get
			{
				return NavigationRegisterCenter._panelHandleCtorMap;
			}
		}

		// Token: 0x06033172 RID: 209266 RVA: 0x00CCB723 File Offset: 0x00CC9923
		public static void Init()
		{
			NavigationRegisterCenter.RegisterNavigationComponent();
			NavigationRegisterCenter.RegisterNavigationSpecialPanelHandle();
		}

		// Token: 0x06033173 RID: 209267 RVA: 0x00CCB730 File Offset: 0x00CC9930
		private static void RegisterNavigationComponent()
		{
			foreach (KeyValuePair<ENavigationSelectableDefine, Type> keyValuePair in NavigationRegisterCenter.SelectableCtorMap)
			{
				NavigationSelectableCreator.RegisterNavigationBehavior(keyValuePair.Key.ToString(), keyValuePair.Value);
			}
		}

		// Token: 0x06033174 RID: 209268 RVA: 0x00CCB79C File Offset: 0x00CC999C
		private static void RegisterNavigationSpecialPanelHandle()
		{
			foreach (KeyValuePair<ESpecialPanelHandleDefine, Type> keyValuePair in NavigationRegisterCenter.PanelHandleCtorMap)
			{
				NavigationPanelHandleCreator.RegisterSpecialPanelHandle(keyValuePair.Key.ToString(), keyValuePair.Value);
			}
		}

		// Token: 0x06033175 RID: 209269 RVA: 0x00CCB808 File Offset: 0x00CC9A08
		public static void CreateStaticDefaultValue()
		{
			NavigationRegisterCenter._selectableCtorMap = new Dictionary<ENavigationSelectableDefine, Type>
			{
				{
					ENavigationSelectableDefine.Button,
					typeof(NavigationButton)
				},
				{
					ENavigationSelectableDefine.Toggle,
					typeof(NavigationToggle)
				},
				{
					ENavigationSelectableDefine.Scrollbar,
					typeof(NavigationScrollbar)
				},
				{
					ENavigationSelectableDefine.Slider,
					typeof(NavigationSlider)
				},
				{
					ENavigationSelectableDefine.DragComponent,
					typeof(NavigationDragComponent)
				},
				{
					ENavigationSelectableDefine.Selectable,
					typeof(NavigationSelectable)
				},
				{
					ENavigationSelectableDefine.VisionReplaceViewToggle,
					typeof(NavigationVisionToggle)
				},
				{
					ENavigationSelectableDefine.VisionTabViewToggle,
					typeof(NavigationVisionTabViewToggle)
				},
				{
					ENavigationSelectableDefine.VisionTabViewReplaceButton,
					typeof(NavigationVisionTabViewReplaceButton)
				},
				{
					ENavigationSelectableDefine.FunctionPageButton,
					typeof(NavigationFunctionPageButton)
				},
				{
					ENavigationSelectableDefine.FunctionPageLeftButton,
					typeof(NavigationFunctionPageLeftButton)
				},
				{
					ENavigationSelectableDefine.FunctionPageRightButton,
					typeof(NavigationFunctionPageRightButton)
				},
				{
					ENavigationSelectableDefine.RoleSkillTreeToggle,
					typeof(NavigationRoleSkillTreeToggle)
				},
				{
					ENavigationSelectableDefine.RoleSkillTreeExitButton,
					typeof(NavigationRoleSkillTreeExitButton)
				},
				{
					ENavigationSelectableDefine.RoleSkillPreviewToggle,
					typeof(NavigationRoleSkillPreviewToggle)
				},
				{
					ENavigationSelectableDefine.RoleSkillPreviewExitButton,
					typeof(NavigationRoleSkillPreviewExitButton)
				},
				{
					ENavigationSelectableDefine.RoleResonanceToggle,
					typeof(NavigationRoleResonanceToggle)
				},
				{
					ENavigationSelectableDefine.RoleResonanceLockToggle,
					typeof(NavigationRoleResonanceLockToggle)
				},
				{
					ENavigationSelectableDefine.RoleResonanceExitButton,
					typeof(NavigationRoleResonanceExitButton)
				},
				{
					ENavigationSelectableDefine.InventoryDestroyEnterButton,
					typeof(NavigationInventoryDestroyEnterButton)
				},
				{
					ENavigationSelectableDefine.InventoryDestroyExitButton,
					typeof(NavigationInventoryDestroyExitButton)
				},
				{
					ENavigationSelectableDefine.InventoryItemGridToggle,
					typeof(NavigationInventoryItemGridToggle)
				},
				{
					ENavigationSelectableDefine.RouletteExitButton,
					typeof(NavigationRouletteExitButton)
				},
				{
					ENavigationSelectableDefine.RoguelikeGridToggle,
					typeof(NavigationRoguelikeGridToggle)
				},
				{
					ENavigationSelectableDefine.QuestTitleToggle,
					typeof(NavigationQuestTitleToggle)
				},
				{
					ENavigationSelectableDefine.VisionReplaceSortTabToggle,
					typeof(NavigationVisionReplaceSortTabToggle)
				},
				{
					ENavigationSelectableDefine.CalabashDetailExitBtn,
					typeof(NavigationCalabashDetailExitButton)
				},
				{
					ENavigationSelectableDefine.VisionAssembleToggle,
					typeof(NavigationVisionAssembleToggle)
				},
				{
					ENavigationSelectableDefine.VisionAssembleCompareToggle,
					typeof(NavigationVisionAssembleCompareToggle)
				},
				{
					ENavigationSelectableDefine.CommonRefreshNavigationButton,
					typeof(NavigationCommonRefreshNavigationButton)
				},
				{
					ENavigationSelectableDefine.PhantomArenaOwnHandToggle,
					typeof(NavigationPhantomArenaOwnHandToggle)
				},
				{
					ENavigationSelectableDefine.PhantomArenaOwnBattleToggle,
					typeof(NavigationPhantomArenaOwnBattleToggle)
				},
				{
					ENavigationSelectableDefine.PhantomArenaOwnFunctionalToggle,
					typeof(NavigationPhantomArenaOwnFunctionalToggle)
				},
				{
					ENavigationSelectableDefine.PhantomArenaOpponentBattleToggle,
					typeof(NavigationPhantomArenaOpponentBattleToggle)
				},
				{
					ENavigationSelectableDefine.PhantomArenaOpponentFunctionalToggle,
					typeof(NavigationPhantomArenaOpponentFunctionalToggle)
				},
				{
					ENavigationSelectableDefine.PhantomArenaVisionButton,
					typeof(NavigationPhantomArenaVisionButton)
				},
				{
					ENavigationSelectableDefine.PhantomArenaEmptyButton,
					typeof(NavigationPhantomArenaEmptyButton)
				},
				{
					ENavigationSelectableDefine.PhantomArenaCardToggle,
					typeof(NavigationPhantomArenaCardToggle)
				},
				{
					ENavigationSelectableDefine.PhantomManageConfigGridBig,
					typeof(NavigationPhantomManageConfigGridBig)
				},
				{
					ENavigationSelectableDefine.HonamiStoryGridItem,
					typeof(NavigationHonamiStoryGridItem)
				},
				{
					ENavigationSelectableDefine.CantFocusInScrollOrLayoutByJumpGroup,
					typeof(NavigationCantFocusInScrollOrLayoutByJumpGroupButton)
				},
				{
					ENavigationSelectableDefine.FormationSelectPosition,
					typeof(FormationSelectPositionButton)
				},
				{
					ENavigationSelectableDefine.ReFindMultipleScrollGridToggle,
					typeof(NavigationReFindMultipleScrollGridToggle)
				},
				{
					ENavigationSelectableDefine.NavigationChatTalkToggle,
					typeof(NavigationChatTalkToggle)
				},
				{
					ENavigationSelectableDefine.NavigationChatPhraseToggle,
					typeof(NavigationChatPhraseToggle)
				},
				{
					ENavigationSelectableDefine.NavigationChatTalkPartnerToggle,
					typeof(NavigationChatTalkPartnerToggle)
				}
			};
			NavigationRegisterCenter._panelHandleCtorMap = new Dictionary<ESpecialPanelHandleDefine, Type>
			{
				{
					ESpecialPanelHandleDefine.Default,
					typeof(BasePanelHandle)
				},
				{
					ESpecialPanelHandleDefine.VisionChooseMain,
					typeof(VisionChooseMainPanelHandle)
				},
				{
					ESpecialPanelHandleDefine.FunctionView,
					typeof(FunctionViewPanelHandle)
				},
				{
					ESpecialPanelHandleDefine.RoleSkill,
					typeof(RoleSkillPanelHandle)
				},
				{
					ESpecialPanelHandleDefine.RoleResonance,
					typeof(RoleResonancePanelHandle)
				},
				{
					ESpecialPanelHandleDefine.Inventory,
					typeof(InventoryViewPanelHandle)
				},
				{
					ESpecialPanelHandleDefine.Roulette,
					typeof(RouletteViewPanelHandle)
				},
				{
					ESpecialPanelHandleDefine.ExploreReward,
					typeof(ExploreRewardPanelHandle)
				},
				{
					ESpecialPanelHandleDefine.VisionAssemble,
					typeof(VisionAssemblePanelHandle)
				},
				{
					ESpecialPanelHandleDefine.PhantomArenaBattle,
					typeof(PhantomArenaBattlePanelHandle)
				},
				{
					ESpecialPanelHandleDefine.PhantomManageConfig,
					typeof(PhantomManageConfigPanelHandle)
				},
				{
					ESpecialPanelHandleDefine.HonamiStoryBackpack,
					typeof(HonamiStoryPanelHandle)
				}
			};
		}

		// Token: 0x06033176 RID: 209270 RVA: 0x00CCBC58 File Offset: 0x00CC9E58
		public static void ResetStaticDefaultValue()
		{
			NavigationRegisterCenter._selectableCtorMap = null;
			NavigationRegisterCenter._panelHandleCtorMap = null;
		}

		// Token: 0x0401DB5C RID: 121692
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private static Dictionary<ENavigationSelectableDefine, Type> _selectableCtorMap;

		// Token: 0x0401DB5D RID: 121693
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private static Dictionary<ESpecialPanelHandleDefine, Type> _panelHandleCtorMap;
	}
}
