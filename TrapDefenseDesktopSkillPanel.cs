using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.TrapDefense;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001D9C RID: 7580
public class TrapDefenseDesktopSkillPanel : TrapDefenseSkillPanelBase
{
	// Token: 0x0600DF76 RID: 57206 RVA: 0x003C202D File Offset: 0x003C022D
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
	}

	// Token: 0x0600DF77 RID: 57207 RVA: 0x003C2068 File Offset: 0x003C0268
	public override UniTask InitializeAsync()
	{
		TrapDefenseDesktopSkillPanel.<InitializeAsync>d__3 <InitializeAsync>d__;
		<InitializeAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitializeAsync>d__.<>4__this = this;
		<InitializeAsync>d__.<>1__state = -1;
		<InitializeAsync>d__.<>t__builder.Start<TrapDefenseDesktopSkillPanel.<InitializeAsync>d__3>(ref <InitializeAsync>d__);
		return <InitializeAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600DF78 RID: 57208 RVA: 0x003C20AB File Offset: 0x003C02AB
	protected override void OnChildStart()
	{
		this.RefreshExploreSkillItem();
	}

	// Token: 0x0600DF79 RID: 57209 RVA: 0x003C20B4 File Offset: 0x003C02B4
	private UniTask NewAllBattleSkillItems()
	{
		TrapDefenseDesktopSkillPanel.<NewAllBattleSkillItems>d__5 <NewAllBattleSkillItems>d__;
		<NewAllBattleSkillItems>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<NewAllBattleSkillItems>d__.<>4__this = this;
		<NewAllBattleSkillItems>d__.<>1__state = -1;
		<NewAllBattleSkillItems>d__.<>t__builder.Start<TrapDefenseDesktopSkillPanel.<NewAllBattleSkillItems>d__5>(ref <NewAllBattleSkillItems>d__);
		return <NewAllBattleSkillItems>d__.<>t__builder.Task;
	}

	// Token: 0x0600DF7A RID: 57210 RVA: 0x003C20F8 File Offset: 0x003C02F8
	private void RefreshExploreSkillItem()
	{
		TrapDefenseBattleSkillData trapDefenseBattleSkillData;
		if (this.DataMap.TryGetValue(1, out trapDefenseBattleSkillData))
		{
			bool flag = ModelBase<RouletteModel>.Instance.IsExploreRouletteOpen(false);
			bool curInstToLevelDataHasShop = ModelBase<TrapDefenseModel>.Instance.GetCurInstToLevelDataHasShop();
			trapDefenseBattleSkillData.SetVisible(flag && curInstToLevelDataHasShop);
		}
		this.BattleSkillItemList[1].RefreshVisible();
	}

	// Token: 0x0600DF7B RID: 57211 RVA: 0x003C2148 File Offset: 0x003C0348
	public void RefreshButtonByIsInBuild(bool isInBuild)
	{
		bool visible = !isInBuild;
		TrapDefenseBattleSkillData trapDefenseBattleSkillData;
		if (this.DataMap.TryGetValue(0, out trapDefenseBattleSkillData))
		{
			trapDefenseBattleSkillData.SetVisible(visible);
		}
		this.BattleSkillItemList[0].RefreshVisible();
	}

	// Token: 0x0600DF7C RID: 57212 RVA: 0x003C2182 File Offset: 0x003C0382
	[NullableContext(1)]
	protected override string[] GetActionNameList()
	{
		return TrapDefenseDesktopSkillPanel.actionNameList;
	}

	// Token: 0x04006B6D RID: 27501
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	private static readonly string[] actionNameList = new string[]
	{
		"塔防射击",
		"塔防道具"
	};

	// Token: 0x02008136 RID: 33078
	private static class EComponentDefine
	{
		// Token: 0x0402BEB2 RID: 179890
		public const int Attack = 0;

		// Token: 0x0402BEB3 RID: 179891
		public const int Explore = 1;
	}
}
