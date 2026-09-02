using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Kurotato.Data;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.Activity
{
	// Token: 0x02005AE2 RID: 23266
	public class KurotatoCollectBtn : UiPanelBase
	{
		// Token: 0x0603AD21 RID: 240929 RVA: 0x00EEADE8 File Offset: 0x00EE8FE8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
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
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnSelfBtnClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603AD22 RID: 240930 RVA: 0x00EEAEB0 File Offset: 0x00EE90B0
		public void RefreshView()
		{
			KurotatoActivityData activityData = ControllerBase<KurotatoActivityController>.Instance.GetActivityData();
			ValueTuple<int, int> roleUnlockNum = activityData.GetRoleUnlockNum();
			int item = roleUnlockNum.Item1;
			int item2 = roleUnlockNum.Item2;
			ValueTuple<int, int> itemUnlockNum = activityData.GetItemUnlockNum();
			int item3 = itemUnlockNum.Item1;
			int item4 = itemUnlockNum.Item2;
			ValueTuple<int, int> weaponUnlockNum = activityData.GetWeaponUnlockNum();
			int item5 = weaponUnlockNum.Item1;
			int item6 = weaponUnlockNum.Item2;
			int num = item + item3 + item5;
			int num2 = item2 + item4 + item6;
			UUIText text = base.GetText(1);
			if (text != null)
			{
				text.SetText(num.ToString() + "/" + num2.ToString(), true);
			}
			bool uiactive = activityData.IsRoleHasRedDot() || activityData.IsKurotatoItemHasRedDot() || activityData.IsKurotatoWeaponHasRedDot();
			base.GetItem(2).SetUIActive(uiactive);
		}

		// Token: 0x0603AD23 RID: 240931 RVA: 0x00EEAF65 File Offset: 0x00EE9165
		private void OnSelfBtnClick()
		{
			Action clickCallback = this.ClickCallback;
			if (clickCallback == null)
			{
				return;
			}
			clickCallback();
		}

		// Token: 0x040213CD RID: 136141
		[Nullable(2)]
		public Action ClickCallback;

		// Token: 0x0200BB14 RID: 47892
		private enum ECollectBtnComponents
		{
			// Token: 0x04039BDE RID: 236510
			BtnSelf,
			// Token: 0x04039BDF RID: 236511
			TextNum,
			// Token: 0x04039BE0 RID: 236512
			RedDot
		}
	}
}
