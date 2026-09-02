using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Kurotato.Data;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.EnemyDetailBook
{
	// Token: 0x02005AC0 RID: 23232
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class KurotatoEnemyDetailBookBigItem : GridProxyAbstract<KurotatoEnemyDetailBookBigItemData>
	{
		// Token: 0x0603ABCF RID: 240591 RVA: 0x00EE43C4 File Offset: 0x00EE25C4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 10;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIGridLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603ABD0 RID: 240592 RVA: 0x00EE4537 File Offset: 0x00EE2737
		protected override void OnStart()
		{
			this.Layout = new GenericLayout<KurotatoEnemyDetailBookGridItem, KurotatoEnemyData>(base.GetGridLayout(8), new Func<KurotatoEnemyDetailBookGridItem>(this.InitGridItem), null, false, true);
		}

		// Token: 0x0603ABD1 RID: 240593 RVA: 0x00EE455A File Offset: 0x00EE275A
		private KurotatoEnemyDetailBookGridItem InitGridItem()
		{
			return new KurotatoEnemyDetailBookGridItem
			{
				OnItemClickCallback = new Action<KurotatoEnemyData>(this.OnClickGridItem)
			};
		}

		// Token: 0x0603ABD2 RID: 240594 RVA: 0x00EE4573 File Offset: 0x00EE2773
		public bool GetChildRefreshed()
		{
			return this.IsRefreshed;
		}

		// Token: 0x0603ABD3 RID: 240595 RVA: 0x00EE457C File Offset: 0x00EE277C
		public override void Refresh(KurotatoEnemyDetailBookBigItemData data, bool isSelected, int gridIndex)
		{
			if (this.Layout == null)
			{
				this.Layout = new GenericLayout<KurotatoEnemyDetailBookGridItem, KurotatoEnemyData>(base.GetGridLayout(8), new Func<KurotatoEnemyDetailBookGridItem>(this.InitGridItem), null, false, true);
			}
			this.DataList = data.GetMonsterGridItemDataList();
			this.Layout.RefreshByData(this.DataList, delegate
			{
				foreach (KurotatoEnemyDetailBookGridItem kurotatoEnemyDetailBookGridItem in this.Layout.GetLayoutItemList())
				{
					UUIItem rootItem = kurotatoEnemyDetailBookGridItem.GetRootItem();
					if (rootItem != null)
					{
						rootItem.SetAlpha(1f);
					}
				}
				EKurotatoEnemyDetailBookTabAllOrWave tabAllOrWave = data.TabAllOrWave;
				if (tabAllOrWave != EKurotatoEnemyDetailBookTabAllOrWave.All)
				{
					if (tabAllOrWave == EKurotatoEnemyDetailBookTabAllOrWave.Wave)
					{
						this.RefreshAsWaveItem(data);
					}
				}
				else
				{
					this.RefreshAsAllItem(data);
				}
				if (this.Data.CurSelectedGridItemData != null)
				{
					int num = this.DataList.IndexOf(this.Data.CurSelectedGridItemData);
					if (num != -1)
					{
						this.Layout.SelectGridProxy(num, false);
						return;
					}
					this.Layout.DeselectCurrentGridProxy();
				}
			}, true);
			bool flag = data.TabAllOrWave == EKurotatoEnemyDetailBookTabAllOrWave.All;
			base.GetItem(1).SetUIActive(flag);
			base.GetText(3).SetUIActive(!flag);
			base.GetItem(5).SetUIActive(false);
			base.GetItem(7).SetUIActive(false);
			base.GetItem(6).SetUIActive(false);
			base.GetItem(0).SetAlpha(1f);
		}

		// Token: 0x0603ABD4 RID: 240596 RVA: 0x00EE465C File Offset: 0x00EE285C
		private void RefreshAsAllItem(KurotatoEnemyDetailBookBigItemData data)
		{
			this.Data = data;
			KurotatoEnemyDetailBookBigItemDataAll kurotatoEnemyDetailBookBigItemDataAll = data as KurotatoEnemyDetailBookBigItemDataAll;
			if (kurotatoEnemyDetailBookBigItemDataAll == null)
			{
				return;
			}
			KurotatoMonsterRisk? monsterRiskConfig = ConfigBase<KurotatoConfig>.Instance.GetMonsterRiskConfig(kurotatoEnemyDetailBookBigItemDataAll.RiskType);
			if (monsterRiskConfig == null)
			{
				return;
			}
			string icon = monsterRiskConfig.Value.Icon;
			string name = monsterRiskConfig.Value.Name;
			this.SetSpriteByPath(icon, base.GetSprite(2), false, null, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), name, Array.Empty<object>());
		}

		// Token: 0x0603ABD5 RID: 240597 RVA: 0x00EE46EC File Offset: 0x00EE28EC
		private void RefreshAsWaveItem(KurotatoEnemyDetailBookBigItemData data)
		{
			this.Data = data;
			KurotatoEnemyDetailBookBigItemDataWave kurotatoEnemyDetailBookBigItemDataWave = data as KurotatoEnemyDetailBookBigItemDataWave;
			if (kurotatoEnemyDetailBookBigItemDataWave == null)
			{
				return;
			}
			base.GetText(3).SetText(kurotatoEnemyDetailBookBigItemDataWave.ThisWave.ToString().PadLeft(2, '0'), true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "Survivor_Wave", Array.Empty<object>());
			base.GetItem(5).SetUIActive(kurotatoEnemyDetailBookBigItemDataWave.IsHighDiff);
			bool flag = false;
			switch (kurotatoEnemyDetailBookBigItemDataWave.WaveStatus)
			{
			case EKurotatoWaveStatus.Current:
				flag = true;
				base.GetItem(7).SetUIActive(true);
				break;
			case EKurotatoWaveStatus.Completed:
				base.GetItem(6).SetUIActive(true);
				foreach (KurotatoEnemyDetailBookGridItem kurotatoEnemyDetailBookGridItem in this.Layout.GetLayoutItemList())
				{
					UUIItem rootItem = kurotatoEnemyDetailBookGridItem.GetRootItem();
					if (rootItem != null)
					{
						rootItem.SetAlpha(0.5f);
					}
				}
				flag = false;
				break;
			case EKurotatoWaveStatus.NotCompleted:
				flag = false;
				break;
			}
			UUIText text = base.GetText(3);
			UUIItem uuiitem = text;
			bool bUseChangeColor = flag;
			FColor? fcolor = new FColor?(text.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
			UUIText text2 = base.GetText(4);
			UUIItem uuiitem2 = text2;
			bool bUseChangeColor2 = flag;
			fcolor = new FColor?(text2.changeColor);
			uuiitem2.SetChangeColor(bUseChangeColor2, fcolor);
		}

		// Token: 0x0603ABD6 RID: 240598 RVA: 0x00EE4838 File Offset: 0x00EE2A38
		public void CheckSelectedStateIsInBigItem(KurotatoEnemyData data)
		{
			this.Layout.DeselectCurrentGridProxy();
			int gridIndex = this.DataList.IndexOf(data);
			GenericLayout<KurotatoEnemyDetailBookGridItem, KurotatoEnemyData> layout = this.Layout;
			if (layout == null)
			{
				return;
			}
			layout.SelectGridProxy(gridIndex, false);
		}

		// Token: 0x0603ABD7 RID: 240599 RVA: 0x00EE486F File Offset: 0x00EE2A6F
		private void OnClickGridItem(KurotatoEnemyData data)
		{
			Singleton<EventSystem>.Instance.Emit<KurotatoEnemyData>(EEventName.KurotatoEnemyDetailBookGridItemClick, data);
		}

		// Token: 0x04021361 RID: 136033
		[Nullable(2)]
		private KurotatoEnemyDetailBookBigItemData Data;

		// Token: 0x04021362 RID: 136034
		private List<KurotatoEnemyData> DataList = new List<KurotatoEnemyData>();

		// Token: 0x04021363 RID: 136035
		private readonly bool IsRefreshed;

		// Token: 0x04021364 RID: 136036
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		protected GenericLayout<KurotatoEnemyDetailBookGridItem, KurotatoEnemyData> Layout;

		// Token: 0x04021365 RID: 136037
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Func<KurotatoEnemyData, bool> CanGridItemExecuteChangeCb;

		// Token: 0x0200BAD4 RID: 47828
		[NullableContext(0)]
		private class EBigItemComponent
		{
			// Token: 0x04039ABA RID: 236218
			public const int TitleHorizontalLayout = 0;

			// Token: 0x04039ABB RID: 236219
			public const int ItemIconAll = 1;

			// Token: 0x04039ABC RID: 236220
			public const int SpriteIconAll = 2;

			// Token: 0x04039ABD RID: 236221
			public const int TextNumWave = 3;

			// Token: 0x04039ABE RID: 236222
			public const int TextTitle = 4;

			// Token: 0x04039ABF RID: 236223
			public const int ItemWarringWave = 5;

			// Token: 0x04039AC0 RID: 236224
			public const int ItemDoneWave = 6;

			// Token: 0x04039AC1 RID: 236225
			public const int ItemChoose = 7;

			// Token: 0x04039AC2 RID: 236226
			public const int GridItemLayout = 8;

			// Token: 0x04039AC3 RID: 236227
			public const int GridItem = 9;
		}
	}
}
