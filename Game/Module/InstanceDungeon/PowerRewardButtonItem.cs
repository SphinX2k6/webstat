using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.InstanceDungeon
{
	// Token: 0x02005BD7 RID: 23511
	public class PowerRewardButtonItem : UiPanelBase
	{
		// Token: 0x0603B86F RID: 243823 RVA: 0x00F17374 File Offset: 0x00F15574
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnRewardButtonClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603B870 RID: 243824 RVA: 0x00F1747D File Offset: 0x00F1567D
		private void OnRewardButtonClick()
		{
			IPowerRewardButtonItemData data = this.Data;
			if (data == null)
			{
				return;
			}
			data.RewardCallBack();
		}

		// Token: 0x0603B871 RID: 243825 RVA: 0x00F17494 File Offset: 0x00F15694
		protected override void OnStart()
		{
			base.SetItemIcon(base.GetTexture(3), 5, null, null);
		}

		// Token: 0x0603B872 RID: 243826 RVA: 0x00F174B9 File Offset: 0x00F156B9
		[NullableContext(1)]
		public void Update(IPowerRewardButtonItemData data)
		{
			this.Data = data;
			this.Refresh();
		}

		// Token: 0x0603B873 RID: 243827 RVA: 0x00F174C8 File Offset: 0x00F156C8
		public void Refresh()
		{
			if (this.Data == null)
			{
				return;
			}
			UUIText text = base.GetText(4);
			if (text != null)
			{
				text.SetText(this.Data.PowerNum.ToString(), true);
			}
			string[] args = this.Data.RewardTextArgs ?? Array.Empty<string>();
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), this.Data.RewardTextId, args);
			this.RefreshPowerState();
		}

		// Token: 0x0603B874 RID: 243828 RVA: 0x00F1753C File Offset: 0x00F1573C
		public void RefreshPowerState()
		{
			if (this.Data == null)
			{
				return;
			}
			int powerNum = this.Data.PowerNum;
			bool flag = ModelBase<PowerModel>.Instance.IsPowerEnough(new int?(powerNum));
			UUIText text = base.GetText(4);
			UUIItem uuiitem = text;
			bool bUseChangeColor = !flag;
			FColor? fcolor = new FColor?(text.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
		}

		// Token: 0x0603B875 RID: 243829 RVA: 0x00F1758F File Offset: 0x00F1578F
		public void SetIsEnable(bool isEnable)
		{
			UUIButtonComponent button = base.GetButton(0);
			if (button == null)
			{
				return;
			}
			button.SetSelfInteractive(isEnable);
		}

		// Token: 0x0402185C RID: 137308
		[Nullable(2)]
		private IPowerRewardButtonItemData Data;

		// Token: 0x0200BC43 RID: 48195
		private enum EComponent
		{
			// Token: 0x0403A107 RID: 237831
			RewardButton,
			// Token: 0x0403A108 RID: 237832
			RewardText,
			// Token: 0x0403A109 RID: 237833
			RedDotItem,
			// Token: 0x0403A10A RID: 237834
			PowerTexture,
			// Token: 0x0403A10B RID: 237835
			PowerNumText
		}
	}
}
