using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Kurotato.Data;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.EnemyDetailBook
{
	// Token: 0x02005ABD RID: 23229
	[NullableContext(1)]
	[Nullable(0)]
	public class KurotatoEnemyDetailBookInfoPanel : UiPanelBase
	{
		// Token: 0x0603ABC3 RID: 240579 RVA: 0x00EE3E70 File Offset: 0x00EE2070
		public KurotatoEnemyDetailBookInfoPanel(KurotatoEnemyDetailBookMainView parentView)
		{
			this.ParentView = parentView;
		}

		// Token: 0x0603ABC4 RID: 240580 RVA: 0x00EE3E80 File Offset: 0x00EE2080
		protected unsafe override void OnRegisterComponent()
		{
			int num = 10;
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
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603ABC5 RID: 240581 RVA: 0x00EE3FF4 File Offset: 0x00EE21F4
		protected override void OnStart()
		{
			this.Grid = new SmallItemGrid();
			this.Grid.Initialize(base.GetItem(0).GetOwner());
			this.BasePropertyLayout = new GenericLayout<KurotatoEnemyBasePropertyItem, KurotatoEnemyBasePropertyData>(base.GetVerticalLayout(4), new Func<KurotatoEnemyBasePropertyItem>(this.CreateBasePropertyItem), null, false, true);
			this.CharacteristicLayout = new GenericLayout<KurotatoEnemyCharacteristicItem, KurotatoEnemyCharacteristicData>(base.GetVerticalLayout(6), new Func<KurotatoEnemyCharacteristicItem>(this.CreateCharacteristicItem), null, false, true);
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		}

		// Token: 0x0603ABC6 RID: 240582 RVA: 0x00EE4078 File Offset: 0x00EE2278
		[NullableContext(2)]
		public void RefreshMonsterInfoShow(KurotatoEnemyData monsterData)
		{
			if (monsterData == null)
			{
				return;
			}
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.StopSequenceByKey("Select", false, true);
			}
			LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
			if (levelSequencePlayer2 != null)
			{
				levelSequencePlayer2.PlayLevelSequenceByName("Select", false, null, false);
			}
			PropSmallItemGrid parameters = new PropSmallItemGrid
			{
				Data = null,
				IconPath = monsterData.IconPath,
				QualityIcon = monsterData.GetQualityPathGrid()
			};
			this.Grid.ApplyPropSmallItemGrid(parameters);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), monsterData.Name, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), monsterData.GetRiskTypeText(), Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), monsterData.GetBodyTypeText(), Array.Empty<object>());
			bool flag = !string.IsNullOrEmpty(monsterData.Desc);
			base.GetText(8).SetUIActive(flag);
			if (flag)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), monsterData.Desc, Array.Empty<object>());
			}
			this.BasePropertyLayout.RefreshByData(monsterData.BasePropertyDataList, null, false);
			this.CharacteristicLayout.RefreshByData(monsterData.CharacteristicDataList, null, false);
			base.GetItem(9).SetUIActive(monsterData.CharacteristicDataList.Count > 0);
		}

		// Token: 0x0603ABC7 RID: 240583 RVA: 0x00EE41C3 File Offset: 0x00EE23C3
		private KurotatoEnemyBasePropertyItem CreateBasePropertyItem()
		{
			return new KurotatoEnemyBasePropertyItem();
		}

		// Token: 0x0603ABC8 RID: 240584 RVA: 0x00EE41CA File Offset: 0x00EE23CA
		private KurotatoEnemyCharacteristicItem CreateCharacteristicItem()
		{
			return new KurotatoEnemyCharacteristicItem();
		}

		// Token: 0x0402135C RID: 136028
		protected KurotatoEnemyDetailBookMainView ParentView;

		// Token: 0x0402135D RID: 136029
		[Nullable(2)]
		private SmallItemGrid Grid;

		// Token: 0x0402135E RID: 136030
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<KurotatoEnemyBasePropertyItem, KurotatoEnemyBasePropertyData> BasePropertyLayout;

		// Token: 0x0402135F RID: 136031
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<KurotatoEnemyCharacteristicItem, KurotatoEnemyCharacteristicData> CharacteristicLayout;

		// Token: 0x04021360 RID: 136032
		[Nullable(2)]
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0200BAD1 RID: 47825
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x04039AAA RID: 236202
			public const int ItemIconBox = 0;

			// Token: 0x04039AAB RID: 236203
			public const int TextName = 1;

			// Token: 0x04039AAC RID: 236204
			public const int TextType = 2;

			// Token: 0x04039AAD RID: 236205
			public const int TextSize = 3;

			// Token: 0x04039AAE RID: 236206
			public const int PanelBasePropertyLayout = 4;

			// Token: 0x04039AAF RID: 236207
			public const int ItemBaseProperty = 5;

			// Token: 0x04039AB0 RID: 236208
			public const int PanelCharacteristicLayout = 6;

			// Token: 0x04039AB1 RID: 236209
			public const int ItemCharacteristic = 7;

			// Token: 0x04039AB2 RID: 236210
			public const int TextDesc = 8;

			// Token: 0x04039AB3 RID: 236211
			public const int Line = 9;
		}
	}
}
