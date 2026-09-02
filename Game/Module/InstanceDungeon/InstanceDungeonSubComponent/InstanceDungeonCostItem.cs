using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.InstanceDungeon.InstanceDungeonSubComponent
{
	// Token: 0x02005BE4 RID: 23524
	public class InstanceDungeonCostItem : UiPanelBase
	{
		// Token: 0x0603B8CD RID: 243917 RVA: 0x00F1838C File Offset: 0x00F1658C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickBtnPowerHelp));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603B8CE RID: 243918 RVA: 0x00F18474 File Offset: 0x00F16674
		protected override void OnStart()
		{
			UUIItem item = base.GetItem(3);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUIButtonComponent button = base.GetButton(2);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(false);
			}
			if (this.ItemDataHandle != null)
			{
				this.RefreshItem(this.ItemDataHandle.Item);
			}
			Singleton<EventSystem>.Instance.Add(EEventName.OnPowerChanged, new Action(this.OnPowerChanged));
		}

		// Token: 0x0603B8CF RID: 243919 RVA: 0x00F184E9 File Offset: 0x00F166E9
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnPowerChanged, new Action(this.OnPowerChanged));
		}

		// Token: 0x0603B8D0 RID: 243920 RVA: 0x00F18507 File Offset: 0x00F16707
		private void OnPowerChanged()
		{
			if (this.ItemDataHandle != null && this.ItemDataHandle.Item.ItemData.ItemId == 5)
			{
				this.RefreshItem(this.ItemDataHandle.Item);
			}
		}

		// Token: 0x0603B8D1 RID: 243921 RVA: 0x00F1853C File Offset: 0x00F1673C
		public void RefreshItem(TItem item)
		{
			this.ItemDataHandle = new InstanceDungeonCostItemData
			{
				Item = item
			};
			if (base.InAsyncLoading())
			{
				return;
			}
			bool flag = item.ItemData.ItemId == 5 && !ModelBase<PowerModel>.Instance.IsPowerEnough(new int?(item.Count));
			UUIText text = base.GetText(1);
			if (text != null)
			{
				text.SetText("x" + item.Count.ToString(), true);
			}
			if (text != null)
			{
				UUIItem uuiitem = text;
				bool bUseChangeColor = flag;
				FColor? fcolor = new FColor?(text.changeColor);
				uuiitem.SetChangeColor(bUseChangeColor, fcolor);
			}
			base.SetItemIcon(base.GetTexture(0), item.ItemData.ItemId, null, null);
		}

		// Token: 0x0603B8D2 RID: 243922 RVA: 0x00F185F0 File Offset: 0x00F167F0
		private void OnClickBtnPowerHelp()
		{
			ControllerBase<HelpController>.Instance.OpenHelpById(26);
		}

		// Token: 0x0402186C RID: 137324
		[Nullable(2)]
		private InstanceDungeonCostItemData ItemDataHandle;

		// Token: 0x0200BC4C RID: 48204
		private enum EChildType
		{
			// Token: 0x0403A128 RID: 237864
			TextureConsume,
			// Token: 0x0403A129 RID: 237865
			TextConsume,
			// Token: 0x0403A12A RID: 237866
			ButtonPowerHelp,
			// Token: 0x0403A12B RID: 237867
			PowerCostDiscountsItem
		}
	}
}
