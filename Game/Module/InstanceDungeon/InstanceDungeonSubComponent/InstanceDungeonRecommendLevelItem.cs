using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.TowerDefence;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.InstanceDungeon.InstanceDungeonSubComponent
{
	// Token: 0x02005BF2 RID: 23538
	public class InstanceDungeonRecommendLevelItem : UiPanelBase
	{
		// Token: 0x0603B92C RID: 244012 RVA: 0x00F19E48 File Offset: 0x00F18048
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603B92D RID: 244013 RVA: 0x00F19E90 File Offset: 0x00F18090
		protected override void OnStart()
		{
			if (this.ItemDataHandle != null)
			{
				this.RefreshItem(this.ItemDataHandle.Level);
			}
		}

		// Token: 0x0603B92E RID: 244014 RVA: 0x00F19EAC File Offset: 0x00F180AC
		[NullableContext(1)]
		public void RefreshItem(TowerDefenseRecommendLevel level)
		{
			if (base.InAsyncLoading())
			{
				this.ItemDataHandle = new InstanceDungeonRecommendLevelItemData
				{
					Level = level
				};
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), level.TextId, new <>z__ReadOnlySingleElementList<object>(level.Level));
		}

		// Token: 0x04021894 RID: 137364
		[Nullable(2)]
		private InstanceDungeonRecommendLevelItemData ItemDataHandle;

		// Token: 0x0200BC68 RID: 48232
		private enum EChildType
		{
			// Token: 0x0403A184 RID: 237956
			RecommendLevelText
		}
	}
}
