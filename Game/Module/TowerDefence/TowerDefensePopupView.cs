using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004EDE RID: 20190
	public class TowerDefensePopupView : UiViewBase, IExtraUiPopFrameType
	{
		// Token: 0x0603425E RID: 213598 RVA: 0x00D09FCB File Offset: 0x00D081CB
		[NullableContext(1)]
		public TowerDefensePopupView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603425F RID: 213599 RVA: 0x00D09FD4 File Offset: 0x00D081D4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickBtnCancel));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickBtnConfirm));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06034260 RID: 213600 RVA: 0x00D0A121 File Offset: 0x00D08321
		[NullableContext(2)]
		public EUiBehaviourPopType? GetExtraPopFrameType(object param = null)
		{
			return new EUiBehaviourPopType?(EUiBehaviourPopType.TowerDefense);
		}

		// Token: 0x06034261 RID: 213601 RVA: 0x00D0A12C File Offset: 0x00D0832C
		protected override void OnStart()
		{
			ITowerDefensePopupViewArgs towerDefensePopupViewArgs = this.OpenParam as ITowerDefensePopupViewArgs;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), ((towerDefensePopupViewArgs != null) ? towerDefensePopupViewArgs.TextTitle : null) ?? "", Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), ((towerDefensePopupViewArgs != null) ? towerDefensePopupViewArgs.TextTips : null) ?? "", ((towerDefensePopupViewArgs != null) ? towerDefensePopupViewArgs.TextTipsArgs : null) ?? new List<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), ((towerDefensePopupViewArgs != null) ? towerDefensePopupViewArgs.TextContent : null) ?? "", Array.Empty<object>());
			UUIItem item = base.GetItem(4);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
		}

		// Token: 0x06034262 RID: 213602 RVA: 0x00D0A1E8 File Offset: 0x00D083E8
		private void OnClickBtnCancel()
		{
			ITowerDefensePopupViewArgs towerDefensePopupViewArgs = this.OpenParam as ITowerDefensePopupViewArgs;
			if (towerDefensePopupViewArgs != null)
			{
				Action cancelBack = towerDefensePopupViewArgs.CancelBack;
				if (cancelBack != null)
				{
					cancelBack();
				}
			}
			base.CloseMe(null);
		}

		// Token: 0x06034263 RID: 213603 RVA: 0x00D0A212 File Offset: 0x00D08412
		private void OnClickBtnConfirm()
		{
			ITowerDefensePopupViewArgs towerDefensePopupViewArgs = this.OpenParam as ITowerDefensePopupViewArgs;
			if (towerDefensePopupViewArgs != null)
			{
				Action confirmBack = towerDefensePopupViewArgs.ConfirmBack;
				if (confirmBack != null)
				{
					confirmBack();
				}
			}
			base.CloseMe(null);
		}

		// Token: 0x0200AE92 RID: 44690
		private class EComponent
		{
			// Token: 0x04036335 RID: 222005
			public const int TextTips = 0;

			// Token: 0x04036336 RID: 222006
			public const int TextContent = 1;

			// Token: 0x04036337 RID: 222007
			public const int BtnCancel = 2;

			// Token: 0x04036338 RID: 222008
			public const int BtnConfirm = 3;

			// Token: 0x04036339 RID: 222009
			public const int WaitingItem = 4;

			// Token: 0x0403633A RID: 222010
			public const int TextTitle = 5;
		}
	}
}
