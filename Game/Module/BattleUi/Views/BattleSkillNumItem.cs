using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FD4 RID: 24532
	public class BattleSkillNumItem : UiPanelBase
	{
		// Token: 0x0603DBAE RID: 252846 RVA: 0x00FB9C27 File Offset: 0x00FB7E27
		[NullableContext(1)]
		public BattleSkillNumItem(UUIItem rootUiItem)
		{
			base.CreateByResourceIdAsync("UiItem_BattleSkillNumItem", rootUiItem, false).Forget();
		}

		// Token: 0x0603DBAF RID: 252847 RVA: 0x00FB9C54 File Offset: 0x00FB7E54
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603DBB0 RID: 252848 RVA: 0x00FB9CC0 File Offset: 0x00FB7EC0
		protected override void OnStart()
		{
			foreach (Action action in this.OperationMap.Values)
			{
				action();
			}
		}

		// Token: 0x0603DBB1 RID: 252849 RVA: 0x00FB9D18 File Offset: 0x00FB7F18
		public void SetComponentActive(bool visibility)
		{
			BattleSkillNumItem.<>c__DisplayClass7_0 CS$<>8__locals1 = new BattleSkillNumItem.<>c__DisplayClass7_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.visibility = visibility;
			this.TargetActive = CS$<>8__locals1.visibility;
			if (base.InAsyncLoading())
			{
				this.OperationMap["SetActive"] = new Action(CS$<>8__locals1.<SetComponentActive>g__Callback|0);
				return;
			}
			CS$<>8__locals1.<SetComponentActive>g__Callback|0();
		}

		// Token: 0x0603DBB2 RID: 252850 RVA: 0x00FB9D70 File Offset: 0x00FB7F70
		public void SetTotalCount(int count)
		{
		}

		// Token: 0x0603DBB3 RID: 252851 RVA: 0x00FB9D74 File Offset: 0x00FB7F74
		public void SetRemainingCount(int remainingUseCount)
		{
			BattleSkillNumItem.<>c__DisplayClass9_0 CS$<>8__locals1 = new BattleSkillNumItem.<>c__DisplayClass9_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.remainingUseCount = remainingUseCount;
			if (base.InAsyncLoading())
			{
				this.OperationMap["SetRemainingCount"] = new Action(CS$<>8__locals1.<SetRemainingCount>g__Callback|0);
				return;
			}
			CS$<>8__locals1.<SetRemainingCount>g__Callback|0();
		}

		// Token: 0x0603DBB4 RID: 252852 RVA: 0x00FB9DC0 File Offset: 0x00FB7FC0
		public void RefreshCountType(int totalUseCount)
		{
		}

		// Token: 0x0603DBB5 RID: 252853 RVA: 0x00FB9DC2 File Offset: 0x00FB7FC2
		public void RefreshTotalCount(int totalLimitUseCount)
		{
		}

		// Token: 0x04022A24 RID: 141860
		private int RemainingUseCount = -1;

		// Token: 0x04022A25 RID: 141861
		public bool TargetActive;

		// Token: 0x04022A26 RID: 141862
		[Nullable(1)]
		private readonly Dictionary<string, Action> OperationMap = new Dictionary<string, Action>();

		// Token: 0x0200C042 RID: 49218
		private enum ESkillNumItem
		{
			// Token: 0x0403B2EA RID: 242410
			BgSprite,
			// Token: 0x0403B2EB RID: 242411
			NumText
		}
	}
}
