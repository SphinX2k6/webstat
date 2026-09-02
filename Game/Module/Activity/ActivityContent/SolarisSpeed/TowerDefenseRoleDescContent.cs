using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SolarisSpeed
{
	// Token: 0x0200639B RID: 25499
	[NullableContext(1)]
	[Nullable(0)]
	internal class TowerDefenseRoleDescContent : UiPanelBase
	{
		// Token: 0x06040058 RID: 262232 RVA: 0x01068CE8 File Offset: 0x01066EE8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06040059 RID: 262233 RVA: 0x01068D72 File Offset: 0x01066F72
		protected override void OnStart()
		{
			this.Scroll = new GenericScrollViewNew<TowerDefenseRoleDescItem, ITowerDefenseRoleDescData>(base.GetScrollViewWithScrollbar(1), new Func<TowerDefenseRoleDescItem>(this.InitScrollItem), base.GetItem(2).GetOwner() as AUIBaseActor, false, null);
		}

		// Token: 0x0604005A RID: 262234 RVA: 0x01068DA5 File Offset: 0x01066FA5
		private TowerDefenseRoleDescItem InitScrollItem()
		{
			return new TowerDefenseRoleDescItem();
		}

		// Token: 0x0604005B RID: 262235 RVA: 0x01068DAC File Offset: 0x01066FAC
		private void RefreshDescLayout(ITowerDefenseRoleDescData[] data)
		{
			TowerDefenseRoleDescContent.<>c__DisplayClass5_0 CS$<>8__locals1 = new TowerDefenseRoleDescContent.<>c__DisplayClass5_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.data = data;
			UiAsyncTask task = new UiAsyncTask("TowerDefenseRoleDescContent.Refresh", delegate()
			{
				TowerDefenseRoleDescContent.<>c__DisplayClass5_0.<<RefreshDescLayout>b__0>d <<RefreshDescLayout>b__0>d;
				<<RefreshDescLayout>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<RefreshDescLayout>b__0>d.<>4__this = CS$<>8__locals1;
				<<RefreshDescLayout>b__0>d.<>1__state = -1;
				<<RefreshDescLayout>b__0>d.<>t__builder.Start<TowerDefenseRoleDescContent.<>c__DisplayClass5_0.<<RefreshDescLayout>b__0>d>(ref <<RefreshDescLayout>b__0>d);
				return <<RefreshDescLayout>b__0>d.<>t__builder.Task;
			}, null);
			base.RunAsyncTask(task);
		}

		// Token: 0x0604005C RID: 262236 RVA: 0x01068DF0 File Offset: 0x01066FF0
		public void Refresh(ITowerDefenseRolePanelData data)
		{
			TowerDefenseSettle value = ConfigBase<InstanceDungeonConfig>.Instance.GetTowerDefenseSettleById(data.BestTitle).Value;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), value.Title, Array.Empty<object>());
			this.RefreshDescLayout(data.DescDataList.ToArray());
		}

		// Token: 0x04023F2A RID: 147242
		protected GenericScrollViewNew<TowerDefenseRoleDescItem, ITowerDefenseRoleDescData> Scroll;

		// Token: 0x0200C3FA RID: 50170
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403C5C7 RID: 247239
			public const int Title = 0;

			// Token: 0x0403C5C8 RID: 247240
			public const int DescScroll = 1;

			// Token: 0x0403C5C9 RID: 247241
			public const int DescItem = 2;
		}
	}
}
