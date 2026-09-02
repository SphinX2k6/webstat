using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.BattleUi.Views;
using CSharpScript.Game.Module.GameMainView.TrapDefense;
using CSharpScript.Game.Module.TrapDefense;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001DA1 RID: 7585
[NullableContext(1)]
[Nullable(0)]
public class TrapDefenseMobileSkillPanel : TrapDefenseSkillPanelBase
{
	// Token: 0x0600DFB7 RID: 57271 RVA: 0x003C33E0 File Offset: 0x003C15E0
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
			new ValueTuple<int, Type>(6, typeof(UUIItem))
		};
	}

	// Token: 0x0600DFB8 RID: 57272 RVA: 0x003C3494 File Offset: 0x003C1694
	public override UniTask InitializeAsync()
	{
		TrapDefenseMobileSkillPanel.<InitializeAsync>d__7 <InitializeAsync>d__;
		<InitializeAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitializeAsync>d__.<>4__this = this;
		<InitializeAsync>d__.<>1__state = -1;
		<InitializeAsync>d__.<>t__builder.Start<TrapDefenseMobileSkillPanel.<InitializeAsync>d__7>(ref <InitializeAsync>d__);
		return <InitializeAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600DFB9 RID: 57273 RVA: 0x003C34D8 File Offset: 0x003C16D8
	protected override void OnChildStart()
	{
		bool flag = ModelBase<RouletteModel>.Instance.IsExploreRouletteOpen(false);
		bool curInstToLevelDataHasShop = ModelBase<TrapDefenseModel>.Instance.GetCurInstToLevelDataHasShop();
		this.RefreshSkillItemActive(2, flag && curInstToLevelDataHasShop);
		((TrapDefenseBattleSkillItem)this.BattleSkillItemList[5]).SetIsBanLongPress(true);
	}

	// Token: 0x0600DFBA RID: 57274 RVA: 0x003C3520 File Offset: 0x003C1720
	private UniTask NewAllBattleSkillItems()
	{
		TrapDefenseMobileSkillPanel.<NewAllBattleSkillItems>d__9 <NewAllBattleSkillItems>d__;
		<NewAllBattleSkillItems>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<NewAllBattleSkillItems>d__.<>4__this = this;
		<NewAllBattleSkillItems>d__.<>1__state = -1;
		<NewAllBattleSkillItems>d__.<>t__builder.Start<TrapDefenseMobileSkillPanel.<NewAllBattleSkillItems>d__9>(ref <NewAllBattleSkillItems>d__);
		return <NewAllBattleSkillItems>d__.<>t__builder.Task;
	}

	// Token: 0x0600DFBB RID: 57275 RVA: 0x003C3564 File Offset: 0x003C1764
	private void RefreshSkillItemActive(int index, bool active)
	{
		TrapDefenseBattleSkillData trapDefenseBattleSkillData;
		if (this.DataMap.TryGetValue(index, out trapDefenseBattleSkillData))
		{
			trapDefenseBattleSkillData.SetVisible(active);
		}
		this.BattleSkillItemList[index].RefreshVisible();
	}

	// Token: 0x0600DFBC RID: 57276 RVA: 0x003C359C File Offset: 0x003C179C
	private void RefreshSkillItemEnable(int index, bool enable)
	{
		TrapDefenseBattleSkillData trapDefenseBattleSkillData;
		if (this.DataMap.TryGetValue(index, out trapDefenseBattleSkillData))
		{
			trapDefenseBattleSkillData.SetEnable(enable);
		}
		this.BattleSkillItemList[index].RefreshEnable(false);
	}

	// Token: 0x0600DFBD RID: 57277 RVA: 0x003C35D2 File Offset: 0x003C17D2
	public void SetRecyclePrice(int recyclePrice)
	{
		this.RecyclePriceItem.UpdatePrice(recyclePrice);
	}

	// Token: 0x0600DFBE RID: 57278 RVA: 0x003C35E0 File Offset: 0x003C17E0
	public void RefreshButtonByTipsType(ETrapDefenseBuildTipsType type)
	{
		this.Type = type;
		bool active = (this.Type & ETrapDefenseBuildTipsType.Recycle) > ETrapDefenseBuildTipsType.None;
		this.RefreshSkillItemActive(6, active);
		this.RefreshAttackAndRotate();
	}

	// Token: 0x0600DFBF RID: 57279 RVA: 0x003C3610 File Offset: 0x003C1810
	private void RefreshAttackAndRotate()
	{
		bool flag = !this.IsInBuild;
		bool flag2 = (this.Type & ETrapDefenseBuildTipsType.Build) > ETrapDefenseBuildTipsType.None && this.IsInBuild;
		bool active = (this.Type & ETrapDefenseBuildTipsType.Rotate) > ETrapDefenseBuildTipsType.None && this.IsInBuild;
		this.RefreshSkillItemActive(1, active);
		this.RefreshSkillItemActive(5, flag);
		this.RefreshSkillItemActive(0, true);
		this.RefreshSkillItemEnable(0, flag || flag2);
	}

	// Token: 0x0600DFC0 RID: 57280 RVA: 0x003C3673 File Offset: 0x003C1873
	public void SetIsInBuild(bool isInBuild)
	{
		this.IsInBuild = isInBuild;
		this.RefreshBuildData();
		this.RefreshBuildIcon();
		this.RefreshSkillName();
		this.RefreshMachineCdState();
		this.RefreshAttackAndRotate();
	}

	// Token: 0x0600DFC1 RID: 57281 RVA: 0x003C369C File Offset: 0x003C189C
	private void RefreshBuildData()
	{
		TrapDefenseBattleSkillData trapDefenseBattleSkillData;
		if (this.DataMap.TryGetValue(0, out trapDefenseBattleSkillData))
		{
			trapDefenseBattleSkillData.SetIsBuilding(this.IsInBuild);
		}
		TrapDefenseBattleSkillData trapDefenseBattleSkillData2;
		if (this.DataMap.TryGetValue(5, out trapDefenseBattleSkillData2))
		{
			trapDefenseBattleSkillData2.SetIsBuilding(this.IsInBuild);
		}
	}

	// Token: 0x0600DFC2 RID: 57282 RVA: 0x003C36E4 File Offset: 0x003C18E4
	private void RefreshBuildIcon()
	{
		BattleSkillItem battleSkillItem = this.BattleSkillItemList[0];
		BattleSkillItem battleSkillItem2 = this.BattleSkillItemList[5];
		if (this.IsInBuild)
		{
			if (battleSkillItem != null)
			{
				battleSkillItem.SetSkillIcon("/Game/Aki/UI/UIResources/Common/Atlas/SkillIcon/SkillIconNor/SP_IconT62.SP_IconT62");
				return;
			}
		}
		else
		{
			if (battleSkillItem != null)
			{
				battleSkillItem.RefreshSkillIcon();
			}
			if (battleSkillItem2 != null)
			{
				battleSkillItem2.RefreshSkillIcon();
			}
		}
	}

	// Token: 0x0600DFC3 RID: 57283 RVA: 0x003C3734 File Offset: 0x003C1934
	private void RefreshSkillName()
	{
		BattleSkillItem battleSkillItem = this.BattleSkillItemList[0];
		BattleSkillItem battleSkillItem2 = this.BattleSkillItemList[5];
		if (battleSkillItem != null)
		{
			battleSkillItem.RefreshSkillName();
		}
		if (battleSkillItem2 == null)
		{
			return;
		}
		battleSkillItem2.RefreshSkillName();
	}

	// Token: 0x0600DFC4 RID: 57284 RVA: 0x003C376D File Offset: 0x003C196D
	protected override string[] GetActionNameList()
	{
		return TrapDefenseMobileSkillPanel.actionNameList;
	}

	// Token: 0x0600DFC5 RID: 57285 RVA: 0x003C3774 File Offset: 0x003C1974
	public void RefreshMachineCdState()
	{
		TrapDefenseBattleSkillItem trapDefenseBattleSkillItem = this.BattleSkillItemList[0] as TrapDefenseBattleSkillItem;
		TrapDefenseBattleSkillItem trapDefenseBattleSkillItem2 = this.BattleSkillItemList[5] as TrapDefenseBattleSkillItem;
		if (trapDefenseBattleSkillItem == null || trapDefenseBattleSkillItem2 == null)
		{
			return;
		}
		if (this.IsInBuild)
		{
			trapDefenseBattleSkillItem.ResetSkillCoolDown();
			trapDefenseBattleSkillItem2.ResetSkillCoolDown();
			return;
		}
		trapDefenseBattleSkillItem.RefreshTrapDefenseSkillCoolDown();
		trapDefenseBattleSkillItem2.RefreshTrapDefenseSkillCoolDown();
	}

	// Token: 0x04006B7D RID: 27517
	[StaticVariableRuleIgnore]
	private static readonly string[] actionNameList = new string[]
	{
		"塔防射击",
		"塔防旋转",
		"塔防道具",
		"塔防冲刺",
		"塔防跳跃",
		"塔防射击",
		"塔防回收机关"
	};

	// Token: 0x04006B7E RID: 27518
	private const string BUILD_ICON_PATH = "/Game/Aki/UI/UIResources/Common/Atlas/SkillIcon/SkillIconNor/SP_IconT62.SP_IconT62";

	// Token: 0x04006B7F RID: 27519
	protected bool IsInBuild;

	// Token: 0x04006B80 RID: 27520
	protected ETrapDefenseBuildTipsType Type;

	// Token: 0x04006B81 RID: 27521
	[Nullable(2)]
	private TrapDefenseRecyclePriceItem RecyclePriceItem;

	// Token: 0x02008143 RID: 33091
	[NullableContext(0)]
	private static class EComponentDefine
	{
		// Token: 0x0402BEE2 RID: 179938
		public const int AttackOrBuild = 0;

		// Token: 0x0402BEE3 RID: 179939
		public const int Rotate = 1;

		// Token: 0x0402BEE4 RID: 179940
		public const int Explore = 2;

		// Token: 0x0402BEE5 RID: 179941
		public const int Run = 3;

		// Token: 0x0402BEE6 RID: 179942
		public const int Jump = 4;

		// Token: 0x0402BEE7 RID: 179943
		public const int SubAttack = 5;

		// Token: 0x0402BEE8 RID: 179944
		public const int Recover = 6;
	}
}
