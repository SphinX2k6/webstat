using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.QuestMultiLine.QuestMultiLineData;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.QuestMultiLine.View.Items
{
	// Token: 0x02005338 RID: 21304
	[NullableContext(2)]
	[Nullable(0)]
	public class QuestMultiLineSelectPanel : UiPanelBase
	{
		// Token: 0x0603659F RID: 222623 RVA: 0x00DB3C48 File Offset: 0x00DB1E48
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIText)),
				new ValueTuple<int, Type>(6, typeof(UUIItem))
			};
		}

		// Token: 0x060365A0 RID: 222624 RVA: 0x00DB3CFC File Offset: 0x00DB1EFC
		protected override UniTask OnBeforeStartAsync()
		{
			QuestMultiLineSelectPanel.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<QuestMultiLineSelectPanel.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060365A1 RID: 222625 RVA: 0x00DB3D3F File Offset: 0x00DB1F3F
		protected override void OnStart()
		{
			this.AdjustItemsWidth();
		}

		// Token: 0x060365A2 RID: 222626 RVA: 0x00DB3D48 File Offset: 0x00DB1F48
		private void AdjustItemsWidth()
		{
			UUIItem item = base.GetItem(0);
			UUIItem item2 = base.GetItem(6);
			if (item == null || item2 == null)
			{
				return;
			}
			float num = item.GetWidth() - item2.GetWidth();
			if (num <= 0f)
			{
				return;
			}
			float num2 = num / 2f;
			foreach (int name in new int[]
			{
				1,
				2,
				3,
				4
			})
			{
				UUIItem item3 = base.GetItem(name);
				if (item3 != null)
				{
					item3.SetWidth(item3.GetWidth() + num2);
				}
			}
		}

		// Token: 0x060365A3 RID: 222627 RVA: 0x00DB3DD8 File Offset: 0x00DB1FD8
		[NullableContext(1)]
		public unsafe void RefreshPanel(QuestMultiLineTimePointData timePoint)
		{
			this.ResetButton();
			QuestMultiLineBranchPageData branchPageData = timePoint.BranchPageData;
			if (branchPageData == null)
			{
				return;
			}
			this.BranchPageData = branchPageData;
			List<QuestMultiLineBranchData> list = branchPageData.BranchData ?? new List<QuestMultiLineBranchData>();
			if (list.Count != 2)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.QuestMultiLine;
				ELogAuthor author = ELogAuthor.CCJ;
				string message = "QuestMultiLineSelectPanel: 分线数据数量异常，应为2条";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("pageId", branchPageData.Id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("count", list.Count);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			QuestMultiLineBranchData branchData = list[0];
			QuestMultiLineBranchData branchData2 = list[1];
			this.LeftNormalItem.RefreshItem(branchData);
			this.LeftNormalItem.SetClickFunction(new Action<int>(this.OnClickItem));
			this.LeftSelectItem.RefreshItem(branchData);
			this.LeftSelectItem.SetClickFunction(new Action<int>(this.OnClickEnsure));
			this.RightNormalItem.RefreshItem(branchData2);
			this.RightNormalItem.SetClickFunction(new Action<int>(this.OnClickItem));
			this.RightSelectItem.RefreshItem(branchData2);
			this.RightSelectItem.SetClickFunction(new Action<int>(this.OnClickEnsure));
		}

		// Token: 0x060365A4 RID: 222628 RVA: 0x00DB3F1C File Offset: 0x00DB211C
		public void RefreshButton(int branchId)
		{
			bool flag = branchId == this.BranchPageData.BranchData[0].BranchId;
			bool flag2 = branchId == this.BranchPageData.BranchData[1].BranchId;
			this.LeftNormalItem.SetUiActive(!flag);
			this.LeftSelectItem.SetUiActive(flag);
			this.RightNormalItem.SetUiActive(!flag2);
			this.RightSelectItem.SetUiActive(flag2);
		}

		// Token: 0x060365A5 RID: 222629 RVA: 0x00DB3F93 File Offset: 0x00DB2193
		[NullableContext(1)]
		public void SetClickFunction(Action<int, int> clickFunction)
		{
			this.ClickFunction = clickFunction;
		}

		// Token: 0x060365A6 RID: 222630 RVA: 0x00DB3F9C File Offset: 0x00DB219C
		[NullableContext(1)]
		public void SetEnsureFunction(Action<int, int> clickFunction)
		{
			this.EnsureFunction = clickFunction;
		}

		// Token: 0x060365A7 RID: 222631 RVA: 0x00DB3FA8 File Offset: 0x00DB21A8
		private void ResetButton()
		{
			this.LeftNormalItem.SetUiActive(true);
			this.LeftNormalItem.ResetFinishIcon();
			this.LeftSelectItem.SetUiActive(false);
			this.RightNormalItem.SetUiActive(true);
			this.RightNormalItem.ResetFinishIcon();
			this.RightSelectItem.SetUiActive(false);
		}

		// Token: 0x060365A8 RID: 222632 RVA: 0x00DB3FFB File Offset: 0x00DB21FB
		private void OnClickItem(int branchId)
		{
			this.RefreshButton(branchId);
			Action<int, int> clickFunction = this.ClickFunction;
			if (clickFunction == null)
			{
				return;
			}
			clickFunction(this.BranchPageData.Id, branchId);
		}

		// Token: 0x060365A9 RID: 222633 RVA: 0x00DB4020 File Offset: 0x00DB2220
		private void OnClickEnsure(int branchId)
		{
			Action<int, int> ensureFunction = this.EnsureFunction;
			if (ensureFunction == null)
			{
				return;
			}
			ensureFunction(this.BranchPageData.Id, branchId);
		}

		// Token: 0x0401F410 RID: 128016
		private Action<int, int> ClickFunction;

		// Token: 0x0401F411 RID: 128017
		private Action<int, int> EnsureFunction;

		// Token: 0x0401F412 RID: 128018
		private QuestMultiLineBranchPageData BranchPageData;

		// Token: 0x0401F413 RID: 128019
		private QuestMultiLineNormalItem LeftNormalItem;

		// Token: 0x0401F414 RID: 128020
		private QuestMultiLineNormalItem RightNormalItem;

		// Token: 0x0401F415 RID: 128021
		private QuestMultiLineSelectItem LeftSelectItem;

		// Token: 0x0401F416 RID: 128022
		private QuestMultiLineSelectItem RightSelectItem;
	}
}
