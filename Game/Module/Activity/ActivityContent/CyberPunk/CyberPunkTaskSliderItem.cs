using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.CyberPunk
{
	// Token: 0x02006981 RID: 27009
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class CyberPunkTaskSliderItem : GridProxyAbstract<CyberPunkTaskData>
	{
		// Token: 0x0604304E RID: 274510 RVA: 0x011358CF File Offset: 0x01133ACF
		public int GetCurrentItemId()
		{
			return this.CurrentItemId;
		}

		// Token: 0x0604304F RID: 274511 RVA: 0x011358D7 File Offset: 0x01133AD7
		public void SetOnClaim(Action<int> callback)
		{
			this.OnClaimCallback = callback;
		}

		// Token: 0x06043050 RID: 274512 RVA: 0x011358E0 File Offset: 0x01133AE0
		public override void Refresh(CyberPunkTaskData data, bool isSelected, int gridIndex)
		{
			this.TaskData = data;
			EdgeRunnerScoreReward? edgeRunnerScoreRewardConfigById = ConfigBase<CyberPunkConfig>.Instance.GetEdgeRunnerScoreRewardConfigById(data.Id);
			if (edgeRunnerScoreRewardConfigById == null)
			{
				return;
			}
			this.RefreshProgress(edgeRunnerScoreRewardConfigById.Value.Score, data.Current);
			this.RefreshRewardItem(edgeRunnerScoreRewardConfigById.Value.DropId);
			this.RefreshState(data.Status);
		}

		// Token: 0x06043051 RID: 274513 RVA: 0x0113594B File Offset: 0x01133B4B
		public override object GetKey(CyberPunkTaskData data, int displayIndex)
		{
			return data.Id;
		}

		// Token: 0x06043052 RID: 274514 RVA: 0x01135958 File Offset: 0x01133B58
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickGetBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06043053 RID: 274515 RVA: 0x01135AE8 File Offset: 0x01133CE8
		protected override void OnStart()
		{
			UUIItem item = base.GetItem(0);
			if (item != null)
			{
				this.RewardItemGrid = new CommonItemSmallItemGrid();
				this.RewardItemGrid.Initialize(item.GetOwner());
				this.RewardItemGrid.SetAllowClickBack(true);
			}
		}

		// Token: 0x06043054 RID: 274516 RVA: 0x01135B28 File Offset: 0x01133D28
		private void RefreshProgress(int targetScore, int currentValue)
		{
			float fillAmount = Math.Min((float)currentValue / (float)targetScore, 1f);
			UUIText text = base.GetText(3);
			if (text != null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler.AppendFormatted<int>(Math.Min(currentValue, targetScore));
				defaultInterpolatedStringHandler.AppendLiteral("/");
				defaultInterpolatedStringHandler.AppendFormatted<int>(targetScore);
				text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			}
			UUISprite sprite = base.GetSprite(4);
			if (sprite == null)
			{
				return;
			}
			sprite.SetFillAmount(fillAmount);
		}

		// Token: 0x06043055 RID: 274517 RVA: 0x01135B9C File Offset: 0x01133D9C
		private void RefreshRewardItem(int dropId)
		{
			if (dropId <= 0)
			{
				return;
			}
			List<TItem> dropPackagePreviewItemList = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(dropId);
			if (dropPackagePreviewItemList == null || dropPackagePreviewItemList.Count == 0)
			{
				return;
			}
			int itemId = dropPackagePreviewItemList[0].ItemData.ItemId;
			this.CurrentItemId = itemId;
			ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(itemId);
			if (itemConfigData != null)
			{
				string text = ConfigMultiTextLang.GetLocalTextNew(ECyberPunkTextIdHelper.ToTextId(ECyberPunkTextId.REWARD), null) ?? "";
				string newValue = ConfigMultiTextLang.GetLocalTextNew(itemConfigData.Name, null) ?? "";
				string newText = text.Replace("{0}", newValue);
				UUIText text2 = base.GetText(1);
				if (text2 != null)
				{
					text2.SetText(newText, true);
				}
			}
			CommonItemSmallItemGrid rewardItemGrid = this.RewardItemGrid;
			if (rewardItemGrid == null)
			{
				return;
			}
			rewardItemGrid.RefreshByConfigId(itemId, null, null, false, false);
		}

		// Token: 0x06043056 RID: 274518 RVA: 0x01135C5C File Offset: 0x01133E5C
		private void RefreshState(ConditionTaskState status)
		{
			bool uiactive = status == ConditionTaskState.ConditionTaskRunning;
			bool uiactive2 = status == ConditionTaskState.ConditionTaskFinish;
			bool uiactive3 = status == ConditionTaskState.ConditionTaskTaken;
			UUIText text = base.GetText(5);
			if (text != null)
			{
				text.SetUIActive(uiactive);
			}
			UUIButtonComponent button = base.GetButton(6);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(uiactive2);
			}
			UUIItem item = base.GetItem(7);
			if (item != null)
			{
				item.SetUIActive(uiactive3);
			}
			UUIItem item2 = base.GetItem(8);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(uiactive2);
		}

		// Token: 0x06043057 RID: 274519 RVA: 0x01135CD0 File Offset: 0x01133ED0
		private void OnClickGetBtn()
		{
			if (this.TaskData == null || this.OnClaimCallback == null)
			{
				return;
			}
			this.OnClaimCallback(this.TaskData.Id);
		}

		// Token: 0x04025532 RID: 152882
		[Nullable(2)]
		private CyberPunkTaskData TaskData;

		// Token: 0x04025533 RID: 152883
		[Nullable(2)]
		private Action<int> OnClaimCallback;

		// Token: 0x04025534 RID: 152884
		[Nullable(2)]
		private CommonItemSmallItemGrid RewardItemGrid;

		// Token: 0x04025535 RID: 152885
		private int CurrentItemId;

		// Token: 0x0200C92F RID: 51503
		[NullableContext(0)]
		private static class EComponentDefine
		{
			// Token: 0x0403DE1E RID: 253470
			public const int PropItem = 0;

			// Token: 0x0403DE1F RID: 253471
			public const int TxtName = 1;

			// Token: 0x0403DE20 RID: 253472
			public const int TxtDesc = 2;

			// Token: 0x0403DE21 RID: 253473
			public const int TxtValue = 3;

			// Token: 0x0403DE22 RID: 253474
			public const int ExpBarFill = 4;

			// Token: 0x0403DE23 RID: 253475
			public const int TxtDoing = 5;

			// Token: 0x0403DE24 RID: 253476
			public const int GetBtn = 6;

			// Token: 0x0403DE25 RID: 253477
			public const int FinishState = 7;

			// Token: 0x0403DE26 RID: 253478
			public const int RedPoint = 8;
		}
	}
}
