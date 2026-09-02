using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.TotalTopUp
{
	// Token: 0x02006272 RID: 25202
	public class TotalTopUpPickRoleItemPanel : UiPanelBase
	{
		// Token: 0x0603F7B2 RID: 260018 RVA: 0x010469E4 File Offset: 0x01044BE4
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(1, new Action(this.OnClickCheck))
			};
		}

		// Token: 0x0603F7B3 RID: 260019 RVA: 0x01046A4C File Offset: 0x01044C4C
		[NullableContext(1)]
		public void Refresh(TotalTopUpPickRoleViewModel viewModel)
		{
			if (viewModel.CurrentRoleId > 0)
			{
				return;
			}
			this.ItemId = viewModel.CurrentItemId;
			CSharpScript.Game.Module.Inventory.ItemConfig currentSelectItemConfigData = viewModel.CurrentSelectItemConfigData;
			UUIText text = base.GetText(0);
			TableTextArgNew tableTextArgNew = new TableTextArgNew((currentSelectItemConfigData != null) ? currentSelectItemConfigData.Name : null, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "Text_ItemNameShowCount_Text", new <>z__ReadOnlyArray<object>(new object[]
			{
				tableTextArgNew,
				viewModel.CurrentItemCount
			}));
		}

		// Token: 0x0603F7B4 RID: 260020 RVA: 0x01046AC1 File Offset: 0x01044CC1
		private void OnClickCheck()
		{
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(this.ItemId, false, null);
		}

		// Token: 0x04023A2A RID: 145962
		private int ItemId;
	}
}
