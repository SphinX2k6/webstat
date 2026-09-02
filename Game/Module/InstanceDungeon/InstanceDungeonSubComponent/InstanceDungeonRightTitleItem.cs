using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.InstanceDungeon.InstanceDungeonSubComponent
{
	// Token: 0x02005BF3 RID: 23539
	[NullableContext(1)]
	[Nullable(0)]
	public class InstanceDungeonRightTitleItem : UiPanelBase
	{
		// Token: 0x0603B930 RID: 244016 RVA: 0x00F19F04 File Offset: 0x00F18104
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603B931 RID: 244017 RVA: 0x00F19F8E File Offset: 0x00F1818E
		public void RefreshItem(string name, string desc, List<int> element)
		{
			this.SetActive(true);
			base.GetText(0).ShowTextNew(name);
			base.GetText(1).ShowTextNew(desc);
			this.UpdateInstanceDungeonRecommendElementItem(element);
		}

		// Token: 0x0603B932 RID: 244018 RVA: 0x00F19FB8 File Offset: 0x00F181B8
		public void RefreshName(string name)
		{
			base.GetText(0).SetText(name, true);
		}

		// Token: 0x0603B933 RID: 244019 RVA: 0x00F19FC8 File Offset: 0x00F181C8
		public void RefreshDesc(string desc)
		{
			base.GetText(1).SetText(desc, true);
		}

		// Token: 0x0603B934 RID: 244020 RVA: 0x00F19FD8 File Offset: 0x00F181D8
		[NullableContext(2)]
		public void UpdateInstanceDungeonRecommendElementItem(List<int> element)
		{
			if (element == null || element.Count <= 0)
			{
				InstanceDungeonRecommendElementItem instanceDungeonRecommendElementItem = this.InstanceDungeonRecommendElementItem;
				if (instanceDungeonRecommendElementItem == null)
				{
					return;
				}
				instanceDungeonRecommendElementItem.SetActive(false);
				return;
			}
			else
			{
				if (this.InstanceDungeonRecommendElementItem == null)
				{
					this.InstanceDungeonRecommendElementItem = new InstanceDungeonRecommendElementItem();
					this.InstanceDungeonRecommendElementItem.CreateThenShowByResourceIdAsync("UiItem_InstanceDungeon_RecommendElement", base.GetItem(2), false).ContinueWith(delegate()
					{
						InstanceDungeonRecommendElementItem instanceDungeonRecommendElementItem4 = this.InstanceDungeonRecommendElementItem;
						if (instanceDungeonRecommendElementItem4 == null)
						{
							return;
						}
						instanceDungeonRecommendElementItem4.RefreshItem(element);
					});
					return;
				}
				InstanceDungeonRecommendElementItem instanceDungeonRecommendElementItem2 = this.InstanceDungeonRecommendElementItem;
				if (instanceDungeonRecommendElementItem2 != null)
				{
					instanceDungeonRecommendElementItem2.SetActive(true);
				}
				InstanceDungeonRecommendElementItem instanceDungeonRecommendElementItem3 = this.InstanceDungeonRecommendElementItem;
				if (instanceDungeonRecommendElementItem3 == null)
				{
					return;
				}
				instanceDungeonRecommendElementItem3.RefreshItem(element);
				return;
			}
		}

		// Token: 0x04021895 RID: 137365
		[Nullable(2)]
		private InstanceDungeonRecommendElementItem InstanceDungeonRecommendElementItem;

		// Token: 0x0200BC69 RID: 48233
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403A186 RID: 237958
			TextInstanceName,
			// Token: 0x0403A187 RID: 237959
			TextInstanceDesc,
			// Token: 0x0403A188 RID: 237960
			ElementItem
		}
	}
}
