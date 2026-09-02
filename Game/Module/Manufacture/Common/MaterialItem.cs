using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Manufacture.Common
{
	// Token: 0x020059E1 RID: 23009
	[NullableContext(1)]
	[Nullable(0)]
	public class MaterialItem : UiPanelBase
	{
		// Token: 0x0603A4A0 RID: 238752 RVA: 0x00EC78BB File Offset: 0x00EC5ABB
		public MaterialItem(UUIItem uiItem)
		{
			base.CreateThenShowByActor(uiItem.GetOwner(), null);
		}

		// Token: 0x0603A4A1 RID: 238753 RVA: 0x00EC78D0 File Offset: 0x00EC5AD0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603A4A2 RID: 238754 RVA: 0x00EC79DC File Offset: 0x00EC5BDC
		public void Update(ISingleItemInfo info)
		{
			this.ItemData = info;
			if (this.ItemData.Proto_ItemId != 0)
			{
				this.ItemInfo = ConfigBase<ItemConfig>.Instance.GetConfig(this.ItemData.Proto_ItemId);
			}
			else
			{
				this.ItemInfo = null;
			}
			this.RefreshNeed(1);
			this.RefreshHave();
			this.RefreshIcon();
			this.RefreshQuality();
		}

		// Token: 0x0603A4A3 RID: 238755 RVA: 0x00EC7A40 File Offset: 0x00EC5C40
		public void RefreshNeed(int num = 1)
		{
			int num2 = this.ItemData.Proto_ItemNum;
			if (num != 1)
			{
				num2 = num * num2;
			}
			base.GetText(2).SetText(num2.ToString(), true);
		}

		// Token: 0x0603A4A4 RID: 238756 RVA: 0x00EC7A78 File Offset: 0x00EC5C78
		protected void RefreshHave()
		{
			int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(this.ItemData.Proto_ItemId, 0);
			string newText;
			if (this.ItemData.Proto_IsUnlock)
			{
				if (itemCountByConfigId < this.ItemData.Proto_ItemNum)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(23, 1);
					defaultInterpolatedStringHandler.AppendLiteral("<color=#dc0300>");
					defaultInterpolatedStringHandler.AppendFormatted<int>(itemCountByConfigId);
					defaultInterpolatedStringHandler.AppendLiteral("</color>");
					newText = defaultInterpolatedStringHandler.ToStringAndClear();
				}
				else
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(23, 1);
					defaultInterpolatedStringHandler.AppendLiteral("<color=#ffffff>");
					defaultInterpolatedStringHandler.AppendFormatted<int>(itemCountByConfigId);
					defaultInterpolatedStringHandler.AppendLiteral("</color>");
					newText = defaultInterpolatedStringHandler.ToStringAndClear();
				}
			}
			else
			{
				newText = "<color=#ffffff>--</color>";
			}
			base.GetText(1).SetText(newText, true);
		}

		// Token: 0x0603A4A5 RID: 238757 RVA: 0x00EC7B38 File Offset: 0x00EC5D38
		private void RefreshIcon()
		{
			if (this.ItemData.Proto_IsUnlock)
			{
				base.GetTexture(3).SetUIActive(true);
				base.SetTextureByPath(this.ItemInfo.Value.Icon, base.GetTexture(3), null, null);
				return;
			}
			base.GetTexture(3).SetUIActive(false);
		}

		// Token: 0x0603A4A6 RID: 238758 RVA: 0x00EC7B98 File Offset: 0x00EC5D98
		private void RefreshQuality()
		{
			if (this.ItemData.Proto_IsUnlock)
			{
				base.GetSprite(4).SetUIActive(true);
				base.SetItemQualityIcon(base.GetSprite(4), this.ItemInfo.Value.Id, null, CommonDefine.EQualityIconType.BackgroundSprite, null);
				return;
			}
			base.GetSprite(4).SetUIActive(false);
		}

		// Token: 0x0603A4A7 RID: 238759 RVA: 0x00EC7BF8 File Offset: 0x00EC5DF8
		public void BindOnClickedCallback(Action<ISingleItemInfo> onItemButtonClicked)
		{
			this.OnClickedCallback = onItemButtonClicked;
		}

		// Token: 0x0603A4A8 RID: 238760 RVA: 0x00EC7C01 File Offset: 0x00EC5E01
		protected void OnClick(EToggleState state)
		{
			if (this.OnClickedCallback != null)
			{
				this.OnClickedCallback(this.ItemData);
			}
		}

		// Token: 0x0402107B RID: 135291
		[Nullable(2)]
		protected ISingleItemInfo ItemData;

		// Token: 0x0402107C RID: 135292
		protected ItemInfo? ItemInfo;

		// Token: 0x0402107D RID: 135293
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<ISingleItemInfo> OnClickedCallback;

		// Token: 0x0200B9B5 RID: 47541
		[NullableContext(0)]
		private class EMaterialDefine
		{
			// Token: 0x04039623 RID: 235043
			public const int MaterialExtendToggle = 0;

			// Token: 0x04039624 RID: 235044
			public const int HaveText = 1;

			// Token: 0x04039625 RID: 235045
			public const int NeedText = 2;

			// Token: 0x04039626 RID: 235046
			public const int MaterialIconTexture = 3;

			// Token: 0x04039627 RID: 235047
			public const int MaterialQualitySprite = 4;
		}
	}
}
