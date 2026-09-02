using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004EA1 RID: 20129
	public class RankTabItem : GridProxyAbstract<TowerDefenceDefine.ETabType>
	{
		// Token: 0x06034020 RID: 213024 RVA: 0x00D029F8 File Offset: 0x00D00BF8
		protected unsafe override void OnRegisterComponent()
		{
			this.ParentModel = (this.OpenParam as TowerDefenseRankViewModel);
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.ToggleClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06034021 RID: 213025 RVA: 0x00D02AAF File Offset: 0x00D00CAF
		protected override void OnStart()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.CanExecuteChange.Bind(() => this.ParentModel.TabItemCanExecuteChange(this.TabType));
		}

		// Token: 0x06034022 RID: 213026 RVA: 0x00D02AD3 File Offset: 0x00D00CD3
		private void ToggleClick(EToggleState toggleState)
		{
			this.ParentModel.TabItemToggle(this.TabType);
		}

		// Token: 0x06034023 RID: 213027 RVA: 0x00D02AE6 File Offset: 0x00D00CE6
		[NullableContext(1)]
		public override object GetKey(TowerDefenceDefine.ETabType data, int displayIndex)
		{
			return data;
		}

		// Token: 0x06034024 RID: 213028 RVA: 0x00D02AEE File Offset: 0x00D00CEE
		public override void Refresh(TowerDefenceDefine.ETabType data, bool isSelected, int gridIndex)
		{
			this.TabType = data;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), TowerDefenceDefine.tabText[data], Array.Empty<object>());
		}

		// Token: 0x06034025 RID: 213029 RVA: 0x00D02B18 File Offset: 0x00D00D18
		public void SetToggleState(bool isActive, bool bFire = false)
		{
			EToggleState state = isActive ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleState(state, bFire, false, false);
		}

		// Token: 0x0401E0F6 RID: 123126
		[Nullable(1)]
		private TowerDefenseRankViewModel ParentModel;

		// Token: 0x0401E0F7 RID: 123127
		private TowerDefenceDefine.ETabType TabType;

		// Token: 0x0200AE45 RID: 44613
		private class ERankTabItem
		{
			// Token: 0x040361C0 RID: 221632
			public const int Toggle = 0;

			// Token: 0x040361C1 RID: 221633
			public const int Text = 1;
		}
	}
}
