using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.InstanceDungeon
{
	// Token: 0x02005BC7 RID: 23495
	public class InstanceDungeonMonsterGrid : GridProxyAbstract<int>
	{
		// Token: 0x0603B7E9 RID: 243689 RVA: 0x00F1501C File Offset: 0x00F1321C
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
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIHorizontalLayout));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603B7EA RID: 243690 RVA: 0x00F150C7 File Offset: 0x00F132C7
		protected override void OnStart()
		{
			this.ElementLayout = new GenericLayout<TowerElementItem, int>(base.GetHorizontalLayout(3), new Func<TowerElementItem>(this.CreateElementItem), null, false, true);
		}

		// Token: 0x0603B7EB RID: 243691 RVA: 0x00F150EC File Offset: 0x00F132EC
		public override void Refresh(int data, bool isSelected, int gridIndex)
		{
			this.CurrentMonsterId = data;
			string monsterName = ConfigBase<MonsterInfoConfig>.Instance.GetMonsterName(this.CurrentMonsterId);
			base.GetText(0).SetText(monsterName, true);
			int num = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(this.CurrentInstanceId).Value.EntityLevel;
			if (num == 0)
			{
				int currentInstanceId = this.CurrentInstanceId;
				int curWorldLevel = ModelBase<WorldLevelModel>.Instance.CurWorldLevel;
				ValueTuple<bool, int> valueTuple = ModelBase<ActivityModel>.Instance.CheckActivityLevelBelongToType(currentInstanceId);
				bool item = valueTuple.Item1;
				int item2 = valueTuple.Item2;
				if (item)
				{
					num = ModelBase<ActivityModel>.Instance.GetActivityLevelRecommendLevel(currentInstanceId, curWorldLevel, item2);
				}
				else
				{
					num = ConfigBase<InstanceDungeonConfig>.Instance.GetRecommendLevel(currentInstanceId, curWorldLevel);
				}
			}
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(1), "LevelText", new <>z__ReadOnlySingleElementList<object>(num));
			string monsterIcon = ConfigBase<MonsterInfoConfig>.Instance.GetMonsterIcon(this.CurrentMonsterId);
			base.SetTextureByPath(monsterIcon, base.GetTexture(2), null, null);
			List<int> data2 = ConfigBase<MonsterInfoConfig>.Instance.GetMonsterInfoConfig(data).Value.ElementIdArrayIter().ToList<int>();
			GenericLayout<TowerElementItem, int> elementLayout = this.ElementLayout;
			if (elementLayout == null)
			{
				return;
			}
			elementLayout.RefreshByData(data2, null, false);
		}

		// Token: 0x0603B7EC RID: 243692 RVA: 0x00F1521B File Offset: 0x00F1341B
		[NullableContext(1)]
		private TowerElementItem CreateElementItem()
		{
			return new TowerElementItem();
		}

		// Token: 0x0402182C RID: 137260
		public int CurrentInstanceId;

		// Token: 0x0402182D RID: 137261
		private int CurrentMonsterId;

		// Token: 0x0402182E RID: 137262
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<TowerElementItem, int> ElementLayout;

		// Token: 0x0200BC30 RID: 48176
		private static class EChildType
		{
			// Token: 0x0403A0C1 RID: 237761
			public const int NameText = 0;

			// Token: 0x0403A0C2 RID: 237762
			public const int LevelText = 1;

			// Token: 0x0403A0C3 RID: 237763
			public const int MonsterIcon = 2;

			// Token: 0x0403A0C4 RID: 237764
			public const int ElementLayout = 3;
		}
	}
}
