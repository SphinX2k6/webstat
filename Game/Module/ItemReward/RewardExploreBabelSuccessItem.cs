using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B4E RID: 23374
	public class RewardExploreBabelSuccessItem : UiPanelBase
	{
		// Token: 0x0603B236 RID: 242230 RVA: 0x00EF6614 File Offset: 0x00EF4814
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIHorizontalLayout));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603B237 RID: 242231 RVA: 0x00EF66BF File Offset: 0x00EF48BF
		protected override void OnStart()
		{
			this.BuffItemLayout = new GenericLayout<RewardExploreBabelSuccessItem.BabelTowerUnlockBuffItem, IBabelTowerBuffItemData>(base.GetHorizontalLayout(3), new Func<RewardExploreBabelSuccessItem.BabelTowerUnlockBuffItem>(this.CreateBuffItem), null, false, true);
		}

		// Token: 0x0603B238 RID: 242232 RVA: 0x00EF66E2 File Offset: 0x00EF48E2
		[NullableContext(1)]
		private RewardExploreBabelSuccessItem.BabelTowerUnlockBuffItem CreateBuffItem()
		{
			return new RewardExploreBabelSuccessItem.BabelTowerUnlockBuffItem();
		}

		// Token: 0x0603B239 RID: 242233 RVA: 0x00EF66EC File Offset: 0x00EF48EC
		[NullableContext(1)]
		public void Refresh(IBabelTowerSuccessData data)
		{
			TableTextArgNew starTextParam = data.StarTextParam;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), starTextParam.TextKey, starTextParam.Params);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.TipTextId, Array.Empty<object>());
			List<int> newBabelBuffIds = data.NewBabelBuffIds;
			List<int> newBabelDeTermIds = data.NewBabelDeTermIds;
			base.GetText(1).SetUIActive(newBabelBuffIds.Count != 0 || newBabelDeTermIds.Count != 0);
			if (newBabelBuffIds.Count == 0 && newBabelDeTermIds.Count == 0)
			{
				base.GetItem(2).SetUIActive(false);
				return;
			}
			base.GetItem(2).SetUIActive(true);
			List<IBabelTowerBuffItemData> list = new List<IBabelTowerBuffItemData>();
			foreach (int id in newBabelBuffIds)
			{
				BabelTowerBuffItemData item = new BabelTowerBuffItemData
				{
					Id = id,
					IsDeTerm = false,
					CanClick = false
				};
				list.Add(item);
			}
			foreach (int id2 in newBabelDeTermIds)
			{
				BabelTowerBuffItemData item2 = new BabelTowerBuffItemData
				{
					Id = id2,
					IsDeTerm = true,
					CanClick = false
				};
				list.Add(item2);
			}
			list.Sort(delegate(IBabelTowerBuffItemData a, IBabelTowerBuffItemData b)
			{
				if (a.IsDeTerm == b.IsDeTerm)
				{
					return a.Id - b.Id;
				}
				if (!a.IsDeTerm)
				{
					return -1;
				}
				return 1;
			});
			GenericLayout<RewardExploreBabelSuccessItem.BabelTowerUnlockBuffItem, IBabelTowerBuffItemData> buffItemLayout = this.BuffItemLayout;
			if (buffItemLayout == null)
			{
				return;
			}
			buffItemLayout.RefreshByData(list, null, false);
		}

		// Token: 0x04021575 RID: 136565
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<RewardExploreBabelSuccessItem.BabelTowerUnlockBuffItem, IBabelTowerBuffItemData> BuffItemLayout;

		// Token: 0x0200BB4C RID: 47948
		private class ESuccessItemComponent
		{
			// Token: 0x04039CD5 RID: 236757
			public const int StarNumText = 0;

			// Token: 0x04039CD6 RID: 236758
			public const int TipText = 1;

			// Token: 0x04039CD7 RID: 236759
			public const int UnlockParentItem = 2;

			// Token: 0x04039CD8 RID: 236760
			public const int BuffItemLayout = 3;
		}

		// Token: 0x0200BB4D RID: 47949
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public class BabelTowerUnlockBuffItem : GridProxyAbstract<IBabelTowerBuffItemData>
		{
			// Token: 0x0604D9AF RID: 317871 RVA: 0x015700B8 File Offset: 0x0156E2B8
			protected unsafe override void OnRegisterComponent()
			{
				int num = 6;
				List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
				CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
				Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
				int num2 = 0;
				*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
				this.ComponentRegisterInfos = list;
				num2 = 1;
				List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
				CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
				Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
				num = 0;
				*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnItemButtonClick));
				this.BtnBindInfo = list2;
			}

			// Token: 0x0604D9B0 RID: 317872 RVA: 0x015701E4 File Offset: 0x0156E3E4
			[NullableContext(1)]
			public override void Refresh(IBabelTowerBuffItemData data, bool isSelected, int gridIndex)
			{
				this.Data = data;
				bool isDeTerm = data.IsDeTerm;
				UUIItem item = base.GetItem(5);
				UUIItem uuiitem = item;
				bool bUseChangeColor = !isDeTerm;
				FColor? fcolor = new FColor?(item.changeColor);
				uuiitem.SetChangeColor(bUseChangeColor, fcolor);
				string nameText;
				string texture;
				if (isDeTerm)
				{
					BabelTowerDeTerm value = ConfigBabelTowerDeTermById.GetConfig(data.Id, true).Value;
					nameText = value.NameText;
					texture = value.Texture;
				}
				else
				{
					BabelTowerBuff value2 = ConfigBabelTowerBuffById.GetConfig(data.Id, true).Value;
					nameText = value2.NameText;
					texture = value2.Texture;
				}
				base.GetItem(3).SetUIActive(!isDeTerm);
				base.GetItem(4).SetUIActive(isDeTerm);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), nameText, Array.Empty<object>());
				base.SetTextureByPath(texture, base.GetTexture(0), null, null);
			}

			// Token: 0x0604D9B1 RID: 317873 RVA: 0x015702C4 File Offset: 0x0156E4C4
			private void OnItemButtonClick()
			{
				BabelTowerItemInfoViewInfo param = new BabelTowerItemInfoViewInfo
				{
					IsDeTerm = this.Data.IsDeTerm,
					ConfigId = this.Data.Id,
					ShowWays = false
				};
				Singleton<UiManager>.Instance.OpenView(EUiViewName.BabelTowerItemInfoView, param, null);
			}

			// Token: 0x04039CD9 RID: 236761
			[Nullable(2)]
			private IBabelTowerBuffItemData Data;

			// Token: 0x0200CF3D RID: 53053
			private class EUnlockBuffItemComponent
			{
				// Token: 0x0403FD76 RID: 261494
				public const int IconTexture = 0;

				// Token: 0x0403FD77 RID: 261495
				public const int NameText = 1;

				// Token: 0x0403FD78 RID: 261496
				public const int ItemButton = 2;

				// Token: 0x0403FD79 RID: 261497
				public const int BuffBgItem = 3;

				// Token: 0x0403FD7A RID: 261498
				public const int DeTermBgItem = 4;

				// Token: 0x0403FD7B RID: 261499
				public const int CommonBgItem = 5;
			}
		}
	}
}
