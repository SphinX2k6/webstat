using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.BossPiling.View.Item;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BossPiling.View
{
	// Token: 0x02005EF3 RID: 24307
	[NullableContext(1)]
	[Nullable(0)]
	public class BossPilingBuffView : UiViewBase
	{
		// Token: 0x0603D10F RID: 250127 RVA: 0x00F8174F File Offset: 0x00F7F94F
		public BossPilingBuffView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603D110 RID: 250128 RVA: 0x00F8176C File Offset: 0x00F7F96C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIMultiTemplateScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603D111 RID: 250129 RVA: 0x00F8187C File Offset: 0x00F7FA7C
		protected override UniTask OnBeforeStartAsync()
		{
			BossPilingBuffView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<BossPilingBuffView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603D112 RID: 250130 RVA: 0x00F818C0 File Offset: 0x00F7FAC0
		protected override void OnStart()
		{
			this.LevelSequence = new LevelSequencePlayer(base.GetRootItem());
			this.DataInfo = (this.OpenParam as BossPilingBuffViewInfo);
			Dictionary<int, List<BossPilingBuffCountInfo>> buffList = ModelBase<BossPilingModel>.Instance.GetBuffList(this.DataInfo.LevelId, this.DataInfo.InGame);
			UUIItem item = base.GetItem(5);
			if (item != null)
			{
				item.SetUIActive(buffList.Count == 0);
			}
			UUIItem item2 = base.GetItem(6);
			if (item2 != null)
			{
				item2.SetUIActive(buffList.Count > 0);
			}
			this.DetailPanel.SetUiActive(buffList.Count > 0);
			if (buffList.Count == 0)
			{
				return;
			}
			this.InitScrollDataList(buffList);
			MultiTemplateScrollViewRefreshContext multiTemplateScrollViewRefreshContext = new MultiTemplateScrollViewRefreshContext(this.ScrollDataList);
			multiTemplateScrollViewRefreshContext.ScrollToGridIndex = 0;
			this.MultiScroll.RefreshByData(multiTemplateScrollViewRefreshContext);
			this.RefreshTips();
		}

		// Token: 0x0603D113 RID: 250131 RVA: 0x00F81990 File Offset: 0x00F7FB90
		protected void InitScrollDataList(Dictionary<int, List<BossPilingBuffCountInfo>> buffMap)
		{
			foreach (KeyValuePair<int, List<BossPilingBuffCountInfo>> keyValuePair in buffMap)
			{
				int num;
				List<BossPilingBuffCountInfo> list;
				keyValuePair.Deconstruct(out num, out list);
				int data = num;
				List<BossPilingBuffCountInfo> list2 = list;
				BossPilingBuffTitleItemData item = new BossPilingBuffTitleItemData(data);
				this.ScrollDataList.Add(item);
				foreach (BossPilingBuffCountInfo bossPilingBuffCountInfo in list2)
				{
					if (this.CurSelect == -1)
					{
						this.CurSelect = bossPilingBuffCountInfo.BuffId;
						this.CurInfo = bossPilingBuffCountInfo;
					}
					BossPilingBuffItemData bossPilingBuffItemData = new BossPilingBuffItemData(bossPilingBuffCountInfo);
					bossPilingBuffItemData.OnToggleClicked = new Action<BossPilingBuffCountInfo>(this.OnToggleClicked);
					bossPilingBuffItemData.IsSelectedCb = new Func<int, bool>(this.IsSelectedCb);
					this.ScrollDataList.Add(bossPilingBuffItemData);
				}
			}
		}

		// Token: 0x0603D114 RID: 250132 RVA: 0x00F81A94 File Offset: 0x00F7FC94
		protected void RefreshTips()
		{
			this.LevelSequence.PlayOrReplaySequenceByName("Switch", false, null);
			this.DetailPanel.Refresh(this.CurInfo);
		}

		// Token: 0x0603D115 RID: 250133 RVA: 0x00F81ACC File Offset: 0x00F7FCCC
		private void OnToggleClicked(BossPilingBuffCountInfo buffInfo)
		{
			this.CurSelect = buffInfo.BuffId;
			this.CurInfo = buffInfo;
			this.RefreshTips();
			for (int i = 0; i < this.ScrollDataList.Count; i++)
			{
				this.MultiScroll.RefreshProxyDirectly(i);
			}
		}

		// Token: 0x0603D116 RID: 250134 RVA: 0x00F81B15 File Offset: 0x00F7FD15
		private bool IsSelectedCb(int buffId)
		{
			return buffId == this.CurSelect;
		}

		// Token: 0x0603D117 RID: 250135 RVA: 0x00F81B20 File Offset: 0x00F7FD20
		private void OnClickedClose()
		{
			base.CloseMe(null);
		}

		// Token: 0x0402240C RID: 140300
		protected BossPilingBuffViewInfo DataInfo;

		// Token: 0x0402240D RID: 140301
		protected PopupCaptionItem CaptionItem;

		// Token: 0x0402240E RID: 140302
		protected BossPilingBuffTipsPanel DetailPanel;

		// Token: 0x0402240F RID: 140303
		protected MultiTemplateScrollView MultiScroll;

		// Token: 0x04022410 RID: 140304
		protected int CurSelect = -1;

		// Token: 0x04022411 RID: 140305
		protected BossPilingBuffCountInfo CurInfo;

		// Token: 0x04022412 RID: 140306
		protected LevelSequencePlayer LevelSequence;

		// Token: 0x04022413 RID: 140307
		private List<IMultiTemplateGridData> ScrollDataList = new List<IMultiTemplateGridData>();

		// Token: 0x0200BEE7 RID: 48871
		[NullableContext(0)]
		private enum EDefine
		{
			// Token: 0x0403AC04 RID: 240644
			CaptionItem,
			// Token: 0x0403AC05 RID: 240645
			MultiSvList,
			// Token: 0x0403AC06 RID: 240646
			PanelListTitle,
			// Token: 0x0403AC07 RID: 240647
			PanelItem,
			// Token: 0x0403AC08 RID: 240648
			DetailItem,
			// Token: 0x0403AC09 RID: 240649
			PanelNone,
			// Token: 0x0403AC0A RID: 240650
			PanelContent
		}
	}
}
