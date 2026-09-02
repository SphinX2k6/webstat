using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.SceneGameplayPanel
{
	// Token: 0x02004B8C RID: 19340
	[NullableContext(1)]
	[Nullable(0)]
	public class SceneGameplayTipGrid : UiPanelBase
	{
		// Token: 0x06032837 RID: 206903 RVA: 0x00CA4B69 File Offset: 0x00CA2D69
		public void Initialize(AActor actor)
		{
			base.CreateThenShowByActor(actor, null);
		}

		// Token: 0x06032838 RID: 206904 RVA: 0x00CA4B74 File Offset: 0x00CA2D74
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickPreview));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06032839 RID: 206905 RVA: 0x00CA4C7D File Offset: 0x00CA2E7D
		protected override void OnStart()
		{
			UUIItem item = base.GetItem(2);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
		}

		// Token: 0x0603283A RID: 206906 RVA: 0x00CA4C91 File Offset: 0x00CA2E91
		protected override void OnBeforeDestroy()
		{
			this.ItemGridList.Clear();
			this.OnClickPreviewCall = null;
		}

		// Token: 0x0603283B RID: 206907 RVA: 0x00CA4CA5 File Offset: 0x00CA2EA5
		public void Refresh(Dictionary<int, int> reward, string title, bool useNew = false, bool showGet = false, bool showDouble = false)
		{
			this.Reward = reward;
			if (useNew)
			{
				this.UpdateTitleNew(title);
			}
			else
			{
				this.UpdateTitle(title);
			}
			UUIItem item = base.GetItem(4);
			if (item != null)
			{
				item.SetUIActive(showDouble);
			}
			this.UpdateRewardPreview(showGet);
		}

		// Token: 0x0603283C RID: 206908 RVA: 0x00CA4CE0 File Offset: 0x00CA2EE0
		public void SetBtnPreviewVisible(bool visible)
		{
			base.GetButton(3).RootUIComp.Get().SetUIActive(visible);
		}

		// Token: 0x0603283D RID: 206909 RVA: 0x00CA4D08 File Offset: 0x00CA2F08
		private void UpdateRewardPreview(bool showGet = false)
		{
			Dictionary<int, int> reward = this.Reward;
			this.IsShowReward = (reward != null && reward.Count > 0);
			int num = 0;
			if (this.IsShowReward)
			{
				UUIItem item = base.GetItem(2);
				AActor actor = (item != null) ? item.GetOwner() : null;
				UUIItem item2 = base.GetItem(1);
				int num2 = 0;
				foreach (KeyValuePair<int, int> keyValuePair in this.Reward)
				{
					CommonItemSmallItemGrid commonItemSmallItemGrid;
					if (num2 < this.ItemGridList.Count)
					{
						commonItemSmallItemGrid = this.ItemGridList[num2];
					}
					else
					{
						commonItemSmallItemGrid = new CommonItemSmallItemGrid();
						commonItemSmallItemGrid.Initialize(Singleton<LguiUtil>.Instance.DuplicateActor(actor, item2));
						this.ItemGridList.Add(commonItemSmallItemGrid);
					}
					this.OnRefreshItemGrid(commonItemSmallItemGrid, keyValuePair.Key, keyValuePair.Value, showGet);
					commonItemSmallItemGrid.SetActive(true);
					num2++;
				}
				num = this.Reward.Count;
			}
			for (int i = num; i < this.ItemGridList.Count; i++)
			{
				this.ItemGridList[i].SetActive(false);
			}
		}

		// Token: 0x0603283E RID: 206910 RVA: 0x00CA4E40 File Offset: 0x00CA3040
		protected virtual void OnRefreshItemGrid(CommonItemSmallItemGrid grid, int itemId, int itemCount, bool showGet = false)
		{
			grid.RefreshByConfigId(itemId, new int?(itemCount), null, showGet, false);
		}

		// Token: 0x0603283F RID: 206911 RVA: 0x00CA4E53 File Offset: 0x00CA3053
		private void UpdateTitle(string title)
		{
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(0), title, Array.Empty<object>());
		}

		// Token: 0x06032840 RID: 206912 RVA: 0x00CA4E6C File Offset: 0x00CA306C
		private void UpdateTitleNew(string title)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), title, Array.Empty<object>());
		}

		// Token: 0x06032841 RID: 206913 RVA: 0x00CA4E85 File Offset: 0x00CA3085
		private void OnClickPreview()
		{
			Action onClickPreviewCall = this.OnClickPreviewCall;
			if (onClickPreviewCall == null)
			{
				return;
			}
			onClickPreviewCall();
		}

		// Token: 0x0401D759 RID: 120665
		[Nullable(2)]
		public Action OnClickPreviewCall;

		// Token: 0x0401D75A RID: 120666
		[Nullable(2)]
		private Dictionary<int, int> Reward;

		// Token: 0x0401D75B RID: 120667
		private bool IsShowReward;

		// Token: 0x0401D75C RID: 120668
		private readonly List<CommonItemSmallItemGrid> ItemGridList = new List<CommonItemSmallItemGrid>();

		// Token: 0x0200AC62 RID: 44130
		[NullableContext(0)]
		public static class EChildCom
		{
			// Token: 0x0403598A RID: 219530
			public const int RewardTitle = 0;

			// Token: 0x0403598B RID: 219531
			public const int UiItemContainer = 1;

			// Token: 0x0403598C RID: 219532
			public const int UiItemItem = 2;

			// Token: 0x0403598D RID: 219533
			public const int BtnPreview = 3;

			// Token: 0x0403598E RID: 219534
			public const int DoubleTip = 4;
		}
	}
}
