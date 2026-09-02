using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Manufacture.Common;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Cook.View
{
	// Token: 0x02005E10 RID: 24080
	[NullableContext(1)]
	[Nullable(0)]
	public class MaterialItem : UiPanelBase
	{
		// Token: 0x0603C98B RID: 248203 RVA: 0x00F63178 File Offset: 0x00F61378
		public MaterialItem(UUIItem uiItem)
		{
			base.CreateThenShowByActor(uiItem.GetOwner(), null);
		}

		// Token: 0x0603C98C RID: 248204 RVA: 0x00F63190 File Offset: 0x00F61390
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

		// Token: 0x0603C98D RID: 248205 RVA: 0x00F6329C File Offset: 0x00F6149C
		public void Update(ISingleItemInfo info, int index)
		{
			this.ItemData = info;
			this.Index = index;
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

		// Token: 0x0603C98E RID: 248206 RVA: 0x00F63308 File Offset: 0x00F61508
		public void RefreshNeed(int num = 1)
		{
			int num2 = this.ItemData.Proto_ItemNum;
			if (num != 1)
			{
				num2 = num * num2;
			}
			base.GetText(2).SetText(num2.ToString(), true);
		}

		// Token: 0x0603C98F RID: 248207 RVA: 0x00F63340 File Offset: 0x00F61540
		protected void RefreshHave()
		{
			int commonItemCount = ModelBase<InventoryModel>.Instance.GetCommonItemCount(this.ItemData.Proto_ItemId, 0);
			string newText;
			if (this.ItemData.Proto_IsUnlock)
			{
				if (commonItemCount < this.ItemData.Proto_ItemNum)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(17, 2);
					defaultInterpolatedStringHandler.AppendLiteral("<color=#");
					defaultInterpolatedStringHandler.AppendFormatted("ece5d8");
					defaultInterpolatedStringHandler.AppendLiteral(">");
					defaultInterpolatedStringHandler.AppendFormatted<int>(commonItemCount);
					defaultInterpolatedStringHandler.AppendLiteral("</color>");
					newText = defaultInterpolatedStringHandler.ToStringAndClear();
				}
				else
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(17, 2);
					defaultInterpolatedStringHandler.AppendLiteral("<color=#");
					defaultInterpolatedStringHandler.AppendFormatted("aa9b6a");
					defaultInterpolatedStringHandler.AppendLiteral(">");
					defaultInterpolatedStringHandler.AppendFormatted<int>(commonItemCount);
					defaultInterpolatedStringHandler.AppendLiteral("</color>");
					newText = defaultInterpolatedStringHandler.ToStringAndClear();
				}
			}
			else
			{
				newText = "<color=#aa9b6a>--</color>";
			}
			base.GetText(1).SetText(newText, true);
		}

		// Token: 0x0603C990 RID: 248208 RVA: 0x00F63430 File Offset: 0x00F61630
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

		// Token: 0x0603C991 RID: 248209 RVA: 0x00F63490 File Offset: 0x00F61690
		private void RefreshQuality()
		{
			if (this.ItemData.Proto_IsUnlock)
			{
				base.GetSprite(4).SetUIActive(true);
				base.SetItemQualityIcon(base.GetSprite(4), this.ItemData.Proto_ItemId, null, global::CommonDefine.EQualityIconType.BackgroundSprite, null);
				return;
			}
			base.GetSprite(4).SetUIActive(false);
		}

		// Token: 0x0603C992 RID: 248210 RVA: 0x00F634E8 File Offset: 0x00F616E8
		public void BindOnClickedCallback(Action<ISingleItemInfo, int> onItemButtonClicked)
		{
			this.OnClickedCallback = onItemButtonClicked;
		}

		// Token: 0x0603C993 RID: 248211 RVA: 0x00F634F1 File Offset: 0x00F616F1
		private void OnClick(EToggleState state)
		{
			if (this.OnClickedCallback != null)
			{
				this.OnClickedCallback(this.ItemData, this.Index);
			}
		}

		// Token: 0x040220E2 RID: 139490
		[Nullable(2)]
		protected ISingleItemInfo ItemData;

		// Token: 0x040220E3 RID: 139491
		protected ItemInfo? ItemInfo;

		// Token: 0x040220E4 RID: 139492
		protected int Index;

		// Token: 0x040220E5 RID: 139493
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<ISingleItemInfo, int> OnClickedCallback;

		// Token: 0x0200BE4A RID: 48714
		[NullableContext(0)]
		public enum EMaterialDefine
		{
			// Token: 0x0403A95B RID: 239963
			MaterialExtendToggle,
			// Token: 0x0403A95C RID: 239964
			HaveText,
			// Token: 0x0403A95D RID: 239965
			NeedText,
			// Token: 0x0403A95E RID: 239966
			MaterialIconTexture,
			// Token: 0x0403A95F RID: 239967
			MaterialQualitySprite
		}
	}
}
