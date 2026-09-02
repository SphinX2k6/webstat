using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060A1 RID: 24737
	public class ShopButton : BattleChildView
	{
		// Token: 0x0603E740 RID: 255808 RVA: 0x00FF62F8 File Offset: 0x00FF44F8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickedShopButton));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603E741 RID: 255809 RVA: 0x00FF639E File Offset: 0x00FF459E
		[NullableContext(2)]
		public override void Initialize(object param = null)
		{
			base.Initialize(param);
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.BattleViewShopButton, base.GetItem(1), null, 0);
		}

		// Token: 0x0603E742 RID: 255810 RVA: 0x00FF63BB File Offset: 0x00FF45BB
		public override void Reset()
		{
			ControllerBase<RedDotController>.Instance.UnBindRedDot(ERedDotName.BattleViewShopButton);
			base.Reset();
		}

		// Token: 0x0603E743 RID: 255811 RVA: 0x00FF63D0 File Offset: 0x00FF45D0
		private void OnClickedShopButton()
		{
			int? intConfig = ConfigCommonParamById.GetIntConfig("BattleViewShopId");
			if (intConfig == null)
			{
				return;
			}
			ControllerBase<ShopController>.Instance.OpenShop(intConfig.Value, null, null);
			LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.FirstOpenShop, false);
		}

		// Token: 0x0200C1AF RID: 49583
		private enum EChildType
		{
			// Token: 0x0403BA2F RID: 244271
			ShopButton,
			// Token: 0x0403BA30 RID: 244272
			RedDotItem
		}
	}
}
