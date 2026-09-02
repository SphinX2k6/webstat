using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.InstanceDungeon.InstanceDungeonSubComponent;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.InstanceDungeon
{
	// Token: 0x02005BC8 RID: 23496
	public class InstanceDungeonMonsterView : UiViewBase
	{
		// Token: 0x0603B7EE RID: 243694 RVA: 0x00F1522A File Offset: 0x00F1342A
		[NullableContext(1)]
		public InstanceDungeonMonsterView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603B7EF RID: 243695 RVA: 0x00F15234 File Offset: 0x00F13434
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIGridLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603B7F0 RID: 243696 RVA: 0x00F15324 File Offset: 0x00F13524
		protected override void OnStart()
		{
			InstanceDungeonMonsterView.InstanceDungeonMonsterViewOpenParam instanceDungeonMonsterViewOpenParam = this.OpenParam as InstanceDungeonMonsterView.InstanceDungeonMonsterViewOpenParam;
			this.CurrentInstanceId = instanceDungeonMonsterViewOpenParam.InstanceId;
			InstanceDungeonBuffItem.EBuffInfoType? infoType = instanceDungeonMonsterViewOpenParam.InfoType;
			if (infoType != null)
			{
				InstanceDungeonBuffItem.EBuffInfoType valueOrDefault = infoType.GetValueOrDefault();
				if (valueOrDefault != InstanceDungeonBuffItem.EBuffInfoType.Buff)
				{
					if (valueOrDefault == InstanceDungeonBuffItem.EBuffInfoType.Resistance)
					{
						Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "WeeklyBossInfo_Text", Array.Empty<object>());
						Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), "WeeklyBossInfo_Title", Array.Empty<object>());
					}
				}
				else
				{
					Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "PrefabTextItem_3355612697_Text", Array.Empty<object>());
					Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), "PrefabTextItem_2611535427_Text", Array.Empty<object>());
				}
			}
			base.GetText(0).ShowTextNew(ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(this.CurrentInstanceId).Value.MonsterTips);
			this.MonsterLayout = new GenericLayout<InstanceDungeonMonsterGrid, int>(base.GetGridLayout(1), new Func<InstanceDungeonMonsterGrid>(this.CreateMonsterItem), null, false, true);
			this.ElementLayout = new GenericLayout<TowerElementItem, int>(base.GetHorizontalLayout(3), new Func<TowerElementItem>(this.CreateElementItem), null, false, true);
		}

		// Token: 0x0603B7F1 RID: 243697 RVA: 0x00F15448 File Offset: 0x00F13648
		protected override void OnBeforeShow()
		{
			InstanceDungeon value = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(this.CurrentInstanceId).Value;
			this.MonsterLayout.RefreshByData(value.MonsterPreviewIter().ToList<int>(), null, false);
			if (value.RecommendElementLength > 0)
			{
				UUIItem item = base.GetItem(2);
				if (item != null)
				{
					item.SetUIActive(true);
				}
				this.ElementLayout.RefreshByData(value.RecommendElementIter().ToList<int>(), null, false);
				return;
			}
			UUIItem item2 = base.GetItem(2);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(false);
		}

		// Token: 0x0603B7F2 RID: 243698 RVA: 0x00F154D0 File Offset: 0x00F136D0
		protected override void OnBeforeDestroy()
		{
			this.MonsterLayout.ClearChildren();
		}

		// Token: 0x0603B7F3 RID: 243699 RVA: 0x00F154DD File Offset: 0x00F136DD
		[NullableContext(1)]
		private InstanceDungeonMonsterGrid CreateMonsterItem()
		{
			return new InstanceDungeonMonsterGrid
			{
				CurrentInstanceId = this.CurrentInstanceId
			};
		}

		// Token: 0x0603B7F4 RID: 243700 RVA: 0x00F154F0 File Offset: 0x00F136F0
		[NullableContext(1)]
		private TowerElementItem CreateElementItem()
		{
			return new TowerElementItem();
		}

		// Token: 0x0402182F RID: 137263
		private int CurrentInstanceId;

		// Token: 0x04021830 RID: 137264
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<TowerElementItem, int> ElementLayout;

		// Token: 0x04021831 RID: 137265
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<InstanceDungeonMonsterGrid, int> MonsterLayout;

		// Token: 0x0200BC31 RID: 48177
		private static class EChildCom
		{
			// Token: 0x0403A0C5 RID: 237765
			public const int UITextMonsterTips = 0;

			// Token: 0x0403A0C6 RID: 237766
			public const int UILayoutMonster = 1;

			// Token: 0x0403A0C7 RID: 237767
			public const int UIElementItem = 2;

			// Token: 0x0403A0C8 RID: 237768
			public const int UIElementLayout = 3;

			// Token: 0x0403A0C9 RID: 237769
			public const int BigTitle = 4;

			// Token: 0x0403A0CA RID: 237770
			public const int SmallTitle = 5;
		}

		// Token: 0x0200BC32 RID: 48178
		public class InstanceDungeonMonsterViewOpenParam
		{
			// Token: 0x1700A9F4 RID: 43508
			// (get) Token: 0x0604DC16 RID: 318486 RVA: 0x0157AE19 File Offset: 0x01579019
			// (set) Token: 0x0604DC17 RID: 318487 RVA: 0x0157AE21 File Offset: 0x01579021
			public int InstanceId { get; set; }

			// Token: 0x1700A9F5 RID: 43509
			// (get) Token: 0x0604DC18 RID: 318488 RVA: 0x0157AE2A File Offset: 0x0157902A
			// (set) Token: 0x0604DC19 RID: 318489 RVA: 0x0157AE32 File Offset: 0x01579032
			public InstanceDungeonBuffItem.EBuffInfoType? InfoType { get; set; }
		}
	}
}
