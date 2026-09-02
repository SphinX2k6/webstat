using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E60 RID: 20064
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class TrapDefenseBuildingDevelopBranchSelectItem : GridProxyAbstract<ITrapDefenseDevelopBranchSelectInfo>
	{
		// Token: 0x06033D97 RID: 212375 RVA: 0x00CF77C8 File Offset: 0x00CF59C8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.OnClickedToggle));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06033D98 RID: 212376 RVA: 0x00CF7890 File Offset: 0x00CF5A90
		public override void Refresh(ITrapDefenseDevelopBranchSelectInfo data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			ITrapDefenseMachineIdInfo trapDefenseMachineIdInfo = ModelBase<TrapDefenseModel>.Instance.DecomposeMachineId(data.Id);
			string branchName = ModelBase<TrapDefenseModel>.Instance.ViewModelBuildingDevelop.GetBranchName(trapDefenseMachineIdInfo.Branch);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), branchName, Array.Empty<object>());
			if (trapDefenseMachineIdInfo.MachineType == ETrapDefenseMachineType.Building)
			{
				TrapDefenseBuilding? buildingById = ConfigBase<TrapDefenseConfig>.Instance.GetBuildingById(data.Id);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), buildingById.Value.DescDetail, buildingById.Value.DescArgs());
			}
			else
			{
				TrapDefenseAuxiliary? auxiliaryById = ConfigBase<TrapDefenseConfig>.Instance.GetAuxiliaryById(data.Id);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), auxiliaryById.Value.DescDetail, auxiliaryById.Value.DescArgs());
			}
			if (data.IsSelected)
			{
				UUIExtendToggle extendToggle = base.GetExtendToggle(1);
				if (extendToggle == null)
				{
					return;
				}
				extendToggle.SetToggleState(EToggleState.ETT_Checked, false, false, false);
				return;
			}
			else
			{
				UUIExtendToggle extendToggle2 = base.GetExtendToggle(1);
				if (extendToggle2 == null)
				{
					return;
				}
				extendToggle2.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
				return;
			}
		}

		// Token: 0x06033D99 RID: 212377 RVA: 0x00CF79A5 File Offset: 0x00CF5BA5
		public void UpdateSelected()
		{
			if (this.Data.IsSelected)
			{
				UUIExtendToggle extendToggle = base.GetExtendToggle(1);
				if (extendToggle == null)
				{
					return;
				}
				extendToggle.SetToggleState(EToggleState.ETT_Checked, false, false, false);
				return;
			}
			else
			{
				UUIExtendToggle extendToggle2 = base.GetExtendToggle(1);
				if (extendToggle2 == null)
				{
					return;
				}
				extendToggle2.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
				return;
			}
		}

		// Token: 0x06033D9A RID: 212378 RVA: 0x00CF79E1 File Offset: 0x00CF5BE1
		private void OnClickedToggle(EToggleState state)
		{
			if (this.OnClickCb != null)
			{
				this.OnClickCb(this.Data.Id);
			}
		}

		// Token: 0x0401DFD8 RID: 122840
		protected ITrapDefenseDevelopBranchSelectInfo Data;

		// Token: 0x0401DFD9 RID: 122841
		public Action<int> OnClickCb;

		// Token: 0x0200AE0C RID: 44556
		[NullableContext(0)]
		internal class EItem
		{
			// Token: 0x040360DB RID: 221403
			public const int Desc = 0;

			// Token: 0x040360DC RID: 221404
			public const int Toggle = 1;

			// Token: 0x040360DD RID: 221405
			public const int Title = 2;
		}
	}
}
