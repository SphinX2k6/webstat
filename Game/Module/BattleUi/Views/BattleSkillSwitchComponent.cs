using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FD8 RID: 24536
	public class BattleSkillSwitchComponent : UiPanelBase
	{
		// Token: 0x0603DBD6 RID: 252886 RVA: 0x00FBA650 File Offset: 0x00FB8850
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603DBD7 RID: 252887 RVA: 0x00FBA71C File Offset: 0x00FB891C
		protected override void OnStart()
		{
			foreach (Action action in this.OperationMap.Values)
			{
				action();
			}
		}

		// Token: 0x0603DBD8 RID: 252888 RVA: 0x00FBA774 File Offset: 0x00FB8974
		protected override void OnBeforeDestroy()
		{
			this.OperationMap.Clear();
		}

		// Token: 0x0603DBD9 RID: 252889 RVA: 0x00FBA784 File Offset: 0x00FB8984
		public void SetComponentActive(bool visibility)
		{
			BattleSkillSwitchComponent.<>c__DisplayClass8_0 CS$<>8__locals1 = new BattleSkillSwitchComponent.<>c__DisplayClass8_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.visibility = visibility;
			if (base.InAsyncLoading())
			{
				this.OperationMap["SetActive"] = new Action(CS$<>8__locals1.<SetComponentActive>g__Callback|0);
				return;
			}
			CS$<>8__locals1.<SetComponentActive>g__Callback|0();
		}

		// Token: 0x0603DBDA RID: 252890 RVA: 0x00FBA7D0 File Offset: 0x00FB89D0
		public void RefreshSwitch()
		{
			if (base.InAsyncLoading())
			{
				this.OperationMap["RefreshComponent"] = new Action(this.<RefreshSwitch>g__Callback|9_0);
				return;
			}
			this.<RefreshSwitch>g__Callback|9_0();
		}

		// Token: 0x0603DBDB RID: 252891 RVA: 0x00FBA800 File Offset: 0x00FB8A00
		public void UpdateSwitch(int index)
		{
			BattleSkillSwitchComponent.<>c__DisplayClass10_0 CS$<>8__locals1 = new BattleSkillSwitchComponent.<>c__DisplayClass10_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.index = index;
			int? switchIndex = this.SwitchIndex;
			int index2 = CS$<>8__locals1.index;
			if (switchIndex.GetValueOrDefault() == index2 & switchIndex != null)
			{
				return;
			}
			if (CS$<>8__locals1.index >= BattleSkillSwitchComponent.RotatorAngles.Length)
			{
				return;
			}
			if (base.InAsyncLoading())
			{
				this.OperationMap["UpdateSwitch"] = new Action(CS$<>8__locals1.<UpdateSwitch>g__Callback|0);
				return;
			}
			CS$<>8__locals1.<UpdateSwitch>g__Callback|0();
		}

		// Token: 0x0603DBDC RID: 252892 RVA: 0x00FBA880 File Offset: 0x00FB8A80
		public void UpdateNumPanel(bool bVisible, int? num = null)
		{
			BattleSkillSwitchComponent.<>c__DisplayClass11_0 CS$<>8__locals1 = new BattleSkillSwitchComponent.<>c__DisplayClass11_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.bVisible = bVisible;
			CS$<>8__locals1.num = num;
			if (base.InAsyncLoading())
			{
				this.OperationMap["UpdateNumPanel"] = new Action(CS$<>8__locals1.<UpdateNumPanel>g__Callback|0);
				return;
			}
			CS$<>8__locals1.<UpdateNumPanel>g__Callback|0();
		}

		// Token: 0x0603DBDD RID: 252893 RVA: 0x00FBA8D4 File Offset: 0x00FB8AD4
		public void UpdatePointPanel(bool bVisible, int? totalNum = null, int? setNum = null)
		{
			BattleSkillSwitchComponent.<>c__DisplayClass12_0 CS$<>8__locals1 = new BattleSkillSwitchComponent.<>c__DisplayClass12_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.bVisible = bVisible;
			CS$<>8__locals1.totalNum = totalNum;
			CS$<>8__locals1.setNum = setNum;
			if (base.InAsyncLoading())
			{
				this.OperationMap["UpdatePointPanel"] = new Action(CS$<>8__locals1.<UpdatePointPanel>g__Callback|0);
				return;
			}
			CS$<>8__locals1.<UpdatePointPanel>g__Callback|0();
		}

		// Token: 0x0603DBE0 RID: 252896 RVA: 0x00FBA95C File Offset: 0x00FB8B5C
		[CompilerGenerated]
		private void <RefreshSwitch>g__Callback|9_0()
		{
			int currentExploreSkillId = ModelBase<RouletteModel>.Instance.CurrentExploreSkillId;
			int index = ModelBase<RouletteModel>.Instance.GetCurrentExploreRouletteListData().GetRouletteIdList().IndexOf(currentExploreSkillId);
			if (currentExploreSkillId == 3002 || currentExploreSkillId == 3001)
			{
				this.UpdateSwitch(7);
				return;
			}
			this.UpdateSwitch(index);
		}

		// Token: 0x04022A35 RID: 141877
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		private static readonly int[] RotatorAngles = new int[]
		{
			135,
			90,
			45,
			0,
			-45,
			-90,
			-135,
			-180
		};

		// Token: 0x04022A36 RID: 141878
		private const int ITEM_ANGLE_INDEX = 7;

		// Token: 0x04022A37 RID: 141879
		private int? SwitchIndex;

		// Token: 0x04022A38 RID: 141880
		[Nullable(1)]
		private readonly Dictionary<string, Action> OperationMap = new Dictionary<string, Action>();

		// Token: 0x0200C049 RID: 49225
		private enum ESkillNumItem
		{
			// Token: 0x0403B2FD RID: 242429
			ArrowSprite,
			// Token: 0x0403B2FE RID: 242430
			PanelNum,
			// Token: 0x0403B2FF RID: 242431
			TextNum,
			// Token: 0x0403B300 RID: 242432
			ItemTimesRoot,
			// Token: 0x0403B301 RID: 242433
			TxtTimes
		}
	}
}
