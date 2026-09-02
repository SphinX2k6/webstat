using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004EA6 RID: 20134
	public class TowerDefenseRankTabItemV2 : GridProxyAbstract<TowerDefenceDefine.ETabType>
	{
		// Token: 0x06034056 RID: 213078 RVA: 0x00D03758 File Offset: 0x00D01958
		protected unsafe override void OnRegisterComponent()
		{
			this.ParentModel = (this.OpenParam as TowerDefenseRankViewModelV2);
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.ToggleClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06034057 RID: 213079 RVA: 0x00D03830 File Offset: 0x00D01A30
		protected override void OnStart()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle != null)
			{
				extendToggle.CanExecuteChange.Bind(() => this.ParentModel.TabItemCanExecuteChange(this.TabType));
			}
			UUIItem item = base.GetItem(2);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
		}

		// Token: 0x06034058 RID: 213080 RVA: 0x00D03867 File Offset: 0x00D01A67
		private void ToggleClick(EToggleState toggleState)
		{
			this.ParentModel.TabItemToggle(this.TabType);
		}

		// Token: 0x06034059 RID: 213081 RVA: 0x00D0387A File Offset: 0x00D01A7A
		[NullableContext(1)]
		public override object GetKey(TowerDefenceDefine.ETabType data, int displayIndex)
		{
			return data;
		}

		// Token: 0x0603405A RID: 213082 RVA: 0x00D03882 File Offset: 0x00D01A82
		public override void Refresh(TowerDefenceDefine.ETabType data, bool isSelected, int gridIndex)
		{
			this.TabType = data;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), TowerDefenceDefine.tabText[data], Array.Empty<object>());
		}

		// Token: 0x0603405B RID: 213083 RVA: 0x00D038AC File Offset: 0x00D01AAC
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

		// Token: 0x0401E10A RID: 123146
		private TowerDefenceDefine.ETabType TabType;

		// Token: 0x0401E10B RID: 123147
		[Nullable(1)]
		private TowerDefenseRankViewModelV2 ParentModel;

		// Token: 0x0200AE58 RID: 44632
		private class ETabItemComponent
		{
			// Token: 0x0403620C RID: 221708
			public const int Toggle = 0;

			// Token: 0x0403620D RID: 221709
			public const int TitleTxt = 1;

			// Token: 0x0403620E RID: 221710
			public const int RedDotItem = 2;
		}
	}
}
