using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Input;
using CSharpScript.Game.Module.Battle;
using CSharpScript.Game.Module.SkillButtonUi;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FCF RID: 24527
	[NullableContext(2)]
	public interface ISkillButtonData
	{
		// Token: 0x0603DACC RID: 252620
		bool IsEnable();

		// Token: 0x0603DACD RID: 252621
		bool IsVisible();

		// Token: 0x0603DACE RID: 252622
		bool IsEnableInput();

		// Token: 0x0603DACF RID: 252623
		void RefreshIsEnable();

		// Token: 0x0603DAD0 RID: 252624
		ESkillButtonType GetButtonType();

		// Token: 0x17009A70 RID: 39536
		// (get) Token: 0x0603DAD1 RID: 252625
		bool IsExploreAsFight { get; }

		// Token: 0x0603DAD2 RID: 252626
		bool GetExploreSkillChange();

		// Token: 0x0603DAD3 RID: 252627
		void SetExploreSkillChange(bool isExploreSkillChange);

		// Token: 0x0603DAD4 RID: 252628
		bool HasConfigFollower();

		// Token: 0x0603DAD5 RID: 252629
		SkillButtonTypeFormationData GetFormationData();

		// Token: 0x0603DAD6 RID: 252630
		EInputAction GetActionType();

		// Token: 0x0603DAD7 RID: 252631
		[NullableContext(1)]
		string GetInputAction();

		// Token: 0x17009A71 RID: 39537
		// (get) Token: 0x0603DAD8 RID: 252632
		bool IsEnableSlideControl { get; }

		// Token: 0x0603DAD9 RID: 252633
		bool IsEnableLongPress();

		// Token: 0x0603DADA RID: 252634
		bool IsShowLongPress();

		// Token: 0x0603DADB RID: 252635
		bool GetIsLongPressing();

		// Token: 0x0603DADC RID: 252636
		bool GetIsConfigShowLongPress();

		// Token: 0x0603DADD RID: 252637
		bool? GetIsLongPressControlCamera();

		// Token: 0x0603DADE RID: 252638
		double GetLongPressTime();

		// Token: 0x0603DADF RID: 252639
		double GetLongPressDuration();

		// Token: 0x0603DAE0 RID: 252640
		void RefreshLongPressTime();

		// Token: 0x0603DAE1 RID: 252641
		void RefreshLongPressDuration();

		// Token: 0x17009A72 RID: 39538
		// (get) Token: 0x0603DAE2 RID: 252642
		int TotalCoolDownCustom { get; }

		// Token: 0x0603DAE3 RID: 252643
		float GetRemainingCoolDownCustom();

		// Token: 0x0603DAE4 RID: 252644
		float GetSkillRemainingCoolDown();

		// Token: 0x0603DAE5 RID: 252645
		bool HasCdComponent();

		// Token: 0x0603DAE6 RID: 252646
		bool IsCdVisible();

		// Token: 0x17009A73 RID: 39539
		// (get) Token: 0x0603DAE7 RID: 252647
		bool HideCoolDownTextCustom { get; }

		// Token: 0x0603DAE8 RID: 252648
		int GetSkillId();

		// Token: 0x0603DAE9 RID: 252649
		string GetSkillIconName();

		// Token: 0x0603DAEA RID: 252650
		string GetActionName();

		// Token: 0x0603DAEB RID: 252651
		string GetSkillTexturePath();

		// Token: 0x0603DAEC RID: 252652
		bool IsSkillIdChangeByTag();

		// Token: 0x0603DAED RID: 252653
		bool? IsMultiStageSkill();

		// Token: 0x0603DAEE RID: 252654
		string GetMultiSkillTexturePath();

		// Token: 0x0603DAEF RID: 252655
		MultiSkillInfo GetMultiSkillInfo();

		// Token: 0x0603DAF0 RID: 252656
		GroupSkillCdInfo GetGroupSkillCdInfo();

		// Token: 0x0603DAF1 RID: 252657
		bool HasAttribute();

		// Token: 0x17009A74 RID: 39540
		// (get) Token: 0x0603DAF2 RID: 252658
		EAttributeType AttributeId { get; }

		// Token: 0x17009A75 RID: 39541
		// (get) Token: 0x0603DAF3 RID: 252659
		ESkillButtonAttributeUsageMode AttributeUsageMode { get; }

		// Token: 0x17009A76 RID: 39542
		// (get) Token: 0x0603DAF4 RID: 252660
		int[] AttributeUsageParams { get; }

		// Token: 0x0603DAF5 RID: 252661
		float GetAttribute();

		// Token: 0x0603DAF6 RID: 252662
		float GetMaxAttribute();

		// Token: 0x0603DAF7 RID: 252663
		string GetMaxAttributeEffectPath();

		// Token: 0x0603DAF8 RID: 252664
		FLinearColor? GetMaxAttributeColor();

		// Token: 0x0603DAF9 RID: 252665
		int GetMaxAttributeBurstEffectId();

		// Token: 0x0603DAFA RID: 252666
		SkillButtonEffect? GetMaxAttributeBurstEffectConfig();

		// Token: 0x17009A77 RID: 39543
		// (get) Token: 0x0603DAFB RID: 252667
		bool IsLimitCountCustom { get; }

		// Token: 0x17009A78 RID: 39544
		// (get) Token: 0x0603DAFC RID: 252668
		int RemainingCountCustom { get; }

		// Token: 0x17009A79 RID: 39545
		// (get) Token: 0x0603DAFD RID: 252669
		bool IsLimitCountVehicleSkill { get; }

		// Token: 0x17009A7A RID: 39546
		// (get) Token: 0x0603DAFE RID: 252670
		int RemainingCountVehicleSkill { get; }

		// Token: 0x0603DAFF RID: 252671
		bool IsVehicleSkillInCd();

		// Token: 0x0603DB00 RID: 252672
		[NullableContext(0)]
		[return: TupleElementNames(new string[]
		{
			"remainTime",
			"totalTime"
		})]
		ValueTuple<double, double> GetVehicleSkillCd();

		// Token: 0x0603DB01 RID: 252673
		void InitVehicleHandle();

		// Token: 0x0603DB02 RID: 252674
		bool IsSkillInItemUseBuffCd();

		// Token: 0x0603DB03 RID: 252675
		[NullableContext(0)]
		[return: TupleElementNames(new string[]
		{
			"remainTime",
			"totalTime"
		})]
		ValueTuple<double, double> GetEquippedItemUsingBuffCd();

		// Token: 0x0603DB04 RID: 252676
		bool IsSkillInItemUseSkillCd();

		// Token: 0x0603DB05 RID: 252677
		[NullableContext(0)]
		[return: TupleElementNames(new string[]
		{
			"remainTime",
			"totalTime"
		})]
		ValueTuple<double, double> GetEquippedItemUsingSkillCd();

		// Token: 0x0603DB06 RID: 252678
		FColor? GetFrameSpriteColor();

		// Token: 0x0603DB07 RID: 252679
		SkillButtonEffect? GetCdCompletedEffectConfig();

		// Token: 0x0603DB08 RID: 252680
		SkillButtonEffect? GetDynamicEffectConfig();

		// Token: 0x0603DB09 RID: 252681
		int GetCdCompletedEffectId();

		// Token: 0x0603DB0A RID: 252682
		List<EInputAction> GetValidSharedHoldRingFxActions();

		// Token: 0x17009A7B RID: 39547
		// (get) Token: 0x0603DB0B RID: 252683
		bool IsEnableDotIndicator { get; }

		// Token: 0x17009A7C RID: 39548
		// (get) Token: 0x0603DB0C RID: 252684
		int DotIndicatorCount { get; }
	}
}
