using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049E6 RID: 18918
	public class UiScenePathResolver : IStaticVariableResetter
	{
		// Token: 0x0603179B RID: 202651 RVA: 0x00C5546B File Offset: 0x00C5366B
		static UiScenePathResolver()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(UiScenePathResolver.CreateStaticDefaultValue), new Action(UiScenePathResolver.ResetStaticDefaultValue));
		}

		// Token: 0x17008426 RID: 33830
		// (get) Token: 0x0603179C RID: 202652 RVA: 0x00C5548A File Offset: 0x00C5368A
		[Nullable(1)]
		public static Dictionary<EUiViewName, EUiViewName> UiViewToRootViewForUiScene
		{
			[NullableContext(1)]
			get
			{
				return UiScenePathResolver._uiViewToRootViewForUiScene;
			}
		}

		// Token: 0x0603179D RID: 202653 RVA: 0x00C55494 File Offset: 0x00C53694
		public static void CreateStaticDefaultValue()
		{
			UiScenePathResolver._uiViewToRootViewForUiScene = new Dictionary<EUiViewName, EUiViewName>
			{
				{
					EUiViewName.RoleBreachView,
					EUiViewName.RoleRootView
				},
				{
					EUiViewName.RoleSkillView,
					EUiViewName.RoleRootView
				},
				{
					EUiViewName.RoleBreachSuccessView,
					EUiViewName.RoleRootView
				},
				{
					EUiViewName.RoleElementView,
					EUiViewName.RoleRootView
				},
				{
					EUiViewName.RoleAttributeDetailView,
					EUiViewName.RoleRootView
				},
				{
					EUiViewName.RoleLevelUpView,
					EUiViewName.RoleRootView
				},
				{
					EUiViewName.RoleFavorInfoView,
					EUiViewName.RoleRootView
				},
				{
					EUiViewName.RoleSelectionView,
					EUiViewName.RoleRootView
				},
				{
					EUiViewName.PhantomBattleFettersView,
					EUiViewName.RoleRootView
				},
				{
					EUiViewName.RoleDevRootView,
					EUiViewName.RoleRootView
				},
				{
					EUiViewName.RoleSkillMergeView,
					EUiViewName.RoleRootView
				},
				{
					EUiViewName.RoleDevelopRootView,
					EUiViewName.RoleRootView
				},
				{
					EUiViewName.WeaponReplaceView,
					EUiViewName.WeaponRootView
				},
				{
					EUiViewName.WeaponBreachSuccessView,
					EUiViewName.WeaponRootView
				},
				{
					EUiViewName.WeaponResonanceSuccessView,
					EUiViewName.WeaponRootView
				},
				{
					EUiViewName.SkinRootView,
					EUiViewName.WeaponRootView
				},
				{
					EUiViewName.VisionRecoveryResultView,
					EUiViewName.CalabashRootView
				},
				{
					EUiViewName.VisionRecoveryBatchResultView,
					EUiViewName.CalabashRootView
				},
				{
					EUiViewName.VisionRefineResultView,
					EUiViewName.CalabashRootView
				},
				{
					EUiViewName.VisionRefineSubResultView,
					EUiViewName.CalabashRootView
				},
				{
					EUiViewName.GachaScanView,
					EUiViewName.DrawMainView
				},
				{
					EUiViewName.WeeklyRogueAttributeDetailView,
					EUiViewName.WeeklyRogueInfo
				},
				{
					EUiViewName.PhantomManageConfigView,
					EUiViewName.CalabashRootView
				},
				{
					EUiViewName.SurvivorsAttributeDetailView,
					EUiViewName.SurvivorsHandbookView
				},
				{
					EUiViewName.MotorcycleTechTreeDetailView,
					EUiViewName.MotorcycleRootView
				},
				{
					EUiViewName.MotorcycleTechTreeLevelDetailView,
					EUiViewName.MotorcycleRootView
				},
				{
					EUiViewName.MotorcycleLevelAttrDetailView,
					EUiViewName.MotorcycleRootView
				},
				{
					EUiViewName.MotorcycleConditionView,
					EUiViewName.MotorcycleRootView
				},
				{
					EUiViewName.MotorcycleLevelUpView,
					EUiViewName.MotorcycleRootView
				},
				{
					EUiViewName.MotorcycleDiyRootView,
					EUiViewName.MotorcycleRootView
				},
				{
					EUiViewName.MotorcycleDiyEditRootView,
					EUiViewName.MotorcycleRootView
				},
				{
					EUiViewName.MotorcycleDiyEditOverviewView,
					EUiViewName.MotorcycleRootView
				},
				{
					EUiViewName.MotorcycleDiyImportPresetView,
					EUiViewName.MotorcycleRootView
				},
				{
					EUiViewName.MotorcycleDiyOverviewView,
					EUiViewName.MotorcycleRootView
				},
				{
					EUiViewName.MotorcycleDiyStickerPreviewView,
					EUiViewName.MotorcycleRootView
				},
				{
					EUiViewName.MotorcycleDiyDecorationPreviewView,
					EUiViewName.MotorcycleRootView
				},
				{
					EUiViewName.MotorcycleDiySkinView,
					EUiViewName.MotorcycleRootView
				},
				{
					EUiViewName.MotorcycleScenePopupView,
					EUiViewName.MotorcycleRootView
				}
			};
		}

		// Token: 0x0603179E RID: 202654 RVA: 0x00C5570B File Offset: 0x00C5390B
		public static void ResetStaticDefaultValue()
		{
			UiScenePathResolver._uiViewToRootViewForUiScene = null;
		}

		// Token: 0x0401CC85 RID: 117893
		[Nullable(2)]
		private static Dictionary<EUiViewName, EUiViewName> _uiViewToRootViewForUiScene;
	}
}
