using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E18 RID: 19992
	public class TrapDefenseBuildingBranchSelectBtnItem : UiPanelBase
	{
		// Token: 0x06033B28 RID: 211752 RVA: 0x00CEBA10 File Offset: 0x00CE9C10
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickedBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06033B29 RID: 211753 RVA: 0x00CEBAF8 File Offset: 0x00CE9CF8
		private void OnClickedBtn()
		{
			if (this.OnClickCb != null)
			{
				this.OnClickCb();
			}
		}

		// Token: 0x06033B2A RID: 211754 RVA: 0x00CEBB10 File Offset: 0x00CE9D10
		[NullableContext(1)]
		public void RefreshButton(TrapDefenseBuildingDevelopItemData data)
		{
			ITrapDefenseMachineIdInfo trapDefenseMachineIdInfo = ModelBase<TrapDefenseModel>.Instance.DecomposeMachineId(data.Id);
			UUIItem item = base.GetItem(3);
			if (item != null)
			{
				item.SetUIActive(trapDefenseMachineIdInfo.Branch == 0);
			}
			UUIItem item2 = base.GetItem(1);
			if (item2 != null)
			{
				item2.SetUIActive(trapDefenseMachineIdInfo.Branch > 0);
			}
			string textStringId = (trapDefenseMachineIdInfo.Branch > 0) ? data.GetBranchDesc() : "TowerDefense_Building_BranchSelection_Text";
			string[] branchDescArgs = data.GetBranchDescArgs();
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), textStringId, branchDescArgs);
		}

		// Token: 0x0401DEFC RID: 122620
		[Nullable(1)]
		public Action OnClickCb;

		// Token: 0x0200AD94 RID: 44436
		private class EBranchSelect
		{
			// Token: 0x04035E7B RID: 220795
			public const int Btn = 0;

			// Token: 0x04035E7C RID: 220796
			public const int UpgradeState = 1;

			// Token: 0x04035E7D RID: 220797
			public const int TxtTitle = 2;

			// Token: 0x04035E7E RID: 220798
			public const int RedDot = 3;
		}
	}
}
