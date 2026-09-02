using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;

namespace CSharpScript.Game.Module.Manufacture.Common.Item
{
	// Token: 0x020059F7 RID: 23031
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class ManufactureMaterialItem : LoopScrollMediumItemGrid<ISingleItemInfo>
	{
		// Token: 0x0603A58E RID: 238990 RVA: 0x00ECB524 File Offset: 0x00EC9724
		protected override void OnRefresh(ISingleItemInfo data, bool isSelected, int gridIndex)
		{
			this.ItemData = data;
			if (data.IsEmpty != null && data.IsEmpty.Value)
			{
				EmptyItemGrid parameters = new EmptyItemGrid();
				base.Apply<EmptyItemGrid>(parameters);
				this.SetSelected(false, false);
				return;
			}
			PropMediumItemGrid propMediumItemGrid = new PropMediumItemGrid
			{
				Data = data,
				BottomText = this.GetBottomShowText(null)
			};
			if (data.Proto_IsUnlock)
			{
				propMediumItemGrid.ItemConfigId = new int?(data.Proto_ItemId);
			}
			base.Apply<PropMediumItemGrid>(propMediumItemGrid);
			base.SetIsPhantomLock(new bool?(!data.Proto_IsUnlock));
			this.SetSelected(false, false);
		}

		// Token: 0x0603A58F RID: 238991 RVA: 0x00ECB5CC File Offset: 0x00EC97CC
		private string GetBottomShowText(int? need = null)
		{
			if (this.ItemData == null)
			{
				return string.Empty;
			}
			if (this.ItemData.Proto_IsUnlock)
			{
				int num = need ?? (this.ItemData.Proto_ItemNum * this.Times);
				int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(this.ItemData.Proto_ItemId, 0);
				string result = string.Empty;
				if (itemCountByConfigId < num)
				{
					result = StringUtils.Format("<color=#f55e66>{0}</color>/{1}", new string[]
					{
						itemCountByConfigId.ToString(),
						num.ToString()
					});
				}
				else
				{
					result = StringUtils.Format("<color=#f7eba6>{0}</color>/{1}", new string[]
					{
						itemCountByConfigId.ToString(),
						num.ToString()
					});
				}
				return result;
			}
			return ConfigMultiTextLang.GetLocalTextNew("Text_ItemSelectCookUnlock_text", null);
		}

		// Token: 0x0603A590 RID: 238992 RVA: 0x00ECB698 File Offset: 0x00EC9898
		public void SetTimes(int times)
		{
			this.Times = times;
			base.SetBottomText(this.GetBottomShowText(null));
		}

		// Token: 0x0603A591 RID: 238993 RVA: 0x00ECB6C1 File Offset: 0x00EC98C1
		public void SetNeedNum(int needNum)
		{
			base.SetBottomText(this.GetBottomShowText(new int?(needNum)));
		}

		// Token: 0x0603A592 RID: 238994 RVA: 0x00ECB6D5 File Offset: 0x00EC98D5
		public override void OnSelected(bool fireEvent)
		{
			this.SetSelected(true, false);
		}

		// Token: 0x0603A593 RID: 238995 RVA: 0x00ECB6DF File Offset: 0x00EC98DF
		public override void OnDeselected(bool fireEvent)
		{
			this.SetSelected(false, false);
		}

		// Token: 0x040210AF RID: 135343
		[Nullable(2)]
		private ISingleItemInfo ItemData;

		// Token: 0x040210B0 RID: 135344
		private int Times;
	}
}
