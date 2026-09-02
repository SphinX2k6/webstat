using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorFight
{
	// Token: 0x020066EB RID: 26347
	[NullableContext(1)]
	[Nullable(0)]
	public class MotorFightHandBookView : UiViewBase
	{
		// Token: 0x06041C4B RID: 269387 RVA: 0x010DEBC3 File Offset: 0x010DCDC3
		public MotorFightHandBookView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06041C4C RID: 269388 RVA: 0x010DEBE0 File Offset: 0x010DCDE0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIMultiTemplateScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06041C4D RID: 269389 RVA: 0x010DECD0 File Offset: 0x010DCED0
		protected override UniTask OnBeforeStartAsync()
		{
			MotorFightHandBookView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MotorFightHandBookView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041C4E RID: 269390 RVA: 0x010DED14 File Offset: 0x010DCF14
		private void InitScrollViewData()
		{
			foreach (MotorFightItemType data in this.MotorFightActivityData.GetMotorFightItemTypeList())
			{
				MotorFightItemTypeTemplateData motorFightItemTypeTemplateData = new MotorFightItemTypeTemplateData();
				motorFightItemTypeTemplateData.Data = data;
				motorFightItemTypeTemplateData.GetUnlockNum = new Func<int, Tuple<int, int>>(this.GetUnlockNum);
				this.ScrollDataList.Add(motorFightItemTypeTemplateData);
				foreach (MotorFightItemData data2 in this.MotorFightActivityData.GetMotorFightItemDataListByType(data.Id))
				{
					MotorFightGridTemplateData motorFightGridTemplateData = new MotorFightGridTemplateData();
					motorFightGridTemplateData.Data = data2;
					motorFightGridTemplateData.OnClickCb = new Action<MotorFightItemData, int>(this.OnItemClick);
					motorFightGridTemplateData.IsSelected = new Func<int, bool>(this.IsSelected);
					this.ScrollDataList.Add(motorFightGridTemplateData);
				}
			}
		}

		// Token: 0x06041C4F RID: 269391 RVA: 0x010DEE24 File Offset: 0x010DD024
		protected override void OnBeforeHide()
		{
			this.MotorFightActivityData.ReadHandBookRedDot();
		}

		// Token: 0x06041C50 RID: 269392 RVA: 0x010DEE31 File Offset: 0x010DD031
		private Tuple<int, int> GetUnlockNum(int type)
		{
			return this.MotorFightActivityData.GetItemUnlockNum(type);
		}

		// Token: 0x06041C51 RID: 269393 RVA: 0x010DEE40 File Offset: 0x010DD040
		private void OnItemClick(MotorFightItemData data, int index)
		{
			this.SelectedItemData = data;
			this.ItemMultiTemplateScrollView.RefreshProxyDirectly(this.SelectedIndex);
			this.SelectedIndex = index;
			this.ItemMultiTemplateScrollView.RefreshProxyDirectly(index);
			MotorFightItemDetailPanel detailPanel = this.DetailPanel;
			if (detailPanel != null)
			{
				detailPanel.Refresh(data);
			}
			base.PlayOrReplaySequence("Switch", false, null);
		}

		// Token: 0x06041C52 RID: 269394 RVA: 0x010DEEA1 File Offset: 0x010DD0A1
		private bool IsSelected(int id)
		{
			return this.SelectedItemData != null && this.SelectedItemData.Id == id;
		}

		// Token: 0x06041C53 RID: 269395 RVA: 0x010DEEBB File Offset: 0x010DD0BB
		private void OnCloseBtnClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x04024B0F RID: 150287
		[Nullable(2)]
		private MotorFightActivityData MotorFightActivityData;

		// Token: 0x04024B10 RID: 150288
		private int SelectedIndex = 1;

		// Token: 0x04024B11 RID: 150289
		private readonly List<IMultiTemplateGridData> ScrollDataList = new List<IMultiTemplateGridData>();

		// Token: 0x04024B12 RID: 150290
		private MotorFightItemDetailPanel DetailPanel;

		// Token: 0x04024B13 RID: 150291
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x04024B14 RID: 150292
		[Nullable(2)]
		private MotorFightItemData SelectedItemData;

		// Token: 0x04024B15 RID: 150293
		[Nullable(2)]
		private MultiTemplateScrollView ItemMultiTemplateScrollView;

		// Token: 0x0200C72A RID: 50986
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403D501 RID: 251137
			public const int ItemCaption = 0;

			// Token: 0x0403D502 RID: 251138
			public const int ItemDetailPanel = 1;

			// Token: 0x0403D503 RID: 251139
			public const int MultiTemplateScrollView = 2;

			// Token: 0x0403D504 RID: 251140
			public const int ItemTitle = 3;

			// Token: 0x0403D505 RID: 251141
			public const int ItemGrid = 4;

			// Token: 0x0403D506 RID: 251142
			public const int TextCollectNum = 5;
		}
	}
}
