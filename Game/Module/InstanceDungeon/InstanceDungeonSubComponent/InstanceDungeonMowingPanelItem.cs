using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.InstanceDungeon.InstanceDungeonSubComponent
{
	// Token: 0x02005BEC RID: 23532
	public class InstanceDungeonMowingPanelItem : UiPanelBase
	{
		// Token: 0x0603B913 RID: 243987 RVA: 0x00F19920 File Offset: 0x00F17B20
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnLeftClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnRightClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603B914 RID: 243988 RVA: 0x00F19A8E File Offset: 0x00F17C8E
		protected override void OnStart()
		{
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.RedDotMowingRiskBuffAll, base.GetItem(1), null, 0);
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.RedDotMowingRiskReward, base.GetItem(3), null, 0);
			if (this.Data != null)
			{
				this.RefreshItem();
			}
		}

		// Token: 0x0603B915 RID: 243989 RVA: 0x00F19ACE File Offset: 0x00F17CCE
		protected override void OnBeforeDestroy()
		{
			ControllerBase<RedDotController>.Instance.UnBindRedDot(ERedDotName.RedDotMowingRiskBuffAll);
			ControllerBase<RedDotController>.Instance.UnBindRedDot(ERedDotName.RedDotMowingRiskReward);
		}

		// Token: 0x0603B916 RID: 243990 RVA: 0x00F19AEE File Offset: 0x00F17CEE
		[NullableContext(1)]
		public void RefreshItemByData(InstanceDungeonMowingPanelItemData data)
		{
			this.Data = data;
			if (base.InAsyncLoading())
			{
				return;
			}
			this.RefreshItem();
		}

		// Token: 0x0603B917 RID: 243991 RVA: 0x00F19B08 File Offset: 0x00F17D08
		public void RefreshItem()
		{
			if (this.Data == null)
			{
				return;
			}
			UUIItem item = base.GetItem(6);
			if (item != null)
			{
				item.SetUIActive(this.Data.ScoreItemActive);
			}
			if (this.Data.ScoreItemActive && !string.IsNullOrEmpty(this.Data.ScoreText))
			{
				base.GetText(4).SetText(this.Data.ScoreText, true);
			}
		}

		// Token: 0x0603B918 RID: 243992 RVA: 0x00F19B72 File Offset: 0x00F17D72
		private void OnLeftClick()
		{
			InstanceDungeonMowingPanelItemData data = this.Data;
			if (data == null)
			{
				return;
			}
			Action leftBtnClickCallBack = data.LeftBtnClickCallBack;
			if (leftBtnClickCallBack == null)
			{
				return;
			}
			leftBtnClickCallBack();
		}

		// Token: 0x0603B919 RID: 243993 RVA: 0x00F19B8E File Offset: 0x00F17D8E
		private void OnRightClick()
		{
			InstanceDungeonMowingPanelItemData data = this.Data;
			if (data == null)
			{
				return;
			}
			Action rightBtnClickCallBack = data.RightBtnClickCallBack;
			if (rightBtnClickCallBack == null)
			{
				return;
			}
			rightBtnClickCallBack();
		}

		// Token: 0x0402188E RID: 137358
		[Nullable(2)]
		private InstanceDungeonMowingPanelItemData Data;

		// Token: 0x0200BC64 RID: 48228
		private enum EChildType
		{
			// Token: 0x0403A175 RID: 237941
			LeftButton,
			// Token: 0x0403A176 RID: 237942
			LeftRedDotItem,
			// Token: 0x0403A177 RID: 237943
			RightButton,
			// Token: 0x0403A178 RID: 237944
			RightRedDotItem,
			// Token: 0x0403A179 RID: 237945
			ProgressText,
			// Token: 0x0403A17A RID: 237946
			LeftItem,
			// Token: 0x0403A17B RID: 237947
			ScoreItem
		}
	}
}
