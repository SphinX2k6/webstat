using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorFight
{
	// Token: 0x020066DA RID: 26330
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1,
		1
	})]
	public class MotorFightLevelListPanel : GridProxyAbstract<List<MotorFightLevelData>>
	{
		// Token: 0x06041BE2 RID: 269282 RVA: 0x010DC478 File Offset: 0x010DA678
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUIVerticalLayout));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06041BE3 RID: 269283 RVA: 0x010DC4C0 File Offset: 0x010DA6C0
		protected override void OnStart()
		{
			this.LevelLayout = new GenericLayout<MotorFightLevelItem, MotorFightLevelData>(base.GetVerticalLayout(0), new Func<MotorFightLevelItem>(this.CreateMotorFightLevelItem), null, false, true);
		}

		// Token: 0x06041BE4 RID: 269284 RVA: 0x010DC4E4 File Offset: 0x010DA6E4
		public override UniTask RefreshAsync(List<MotorFightLevelData> dataList, bool isSelected, int gridIndex)
		{
			MotorFightLevelListPanel.<RefreshAsync>d__4 <RefreshAsync>d__;
			<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshAsync>d__.<>4__this = this;
			<RefreshAsync>d__.dataList = dataList;
			<RefreshAsync>d__.<>1__state = -1;
			<RefreshAsync>d__.<>t__builder.Start<MotorFightLevelListPanel.<RefreshAsync>d__4>(ref <RefreshAsync>d__);
			return <RefreshAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041BE5 RID: 269285 RVA: 0x010DC52F File Offset: 0x010DA72F
		private MotorFightLevelItem CreateMotorFightLevelItem()
		{
			return new MotorFightLevelItem();
		}

		// Token: 0x06041BE6 RID: 269286 RVA: 0x010DC536 File Offset: 0x010DA736
		[NullableContext(2)]
		public UUIItem GuideGetLevelItem(int index)
		{
			return this.LevelLayout.GetItemByIndex(index);
		}

		// Token: 0x06041BE7 RID: 269287 RVA: 0x010DC544 File Offset: 0x010DA744
		[NullableContext(2)]
		public UUIItem GetLevelNavigationItem()
		{
			IReadOnlyList<MotorFightLevelData> datas = this.LevelLayout.GetDatas();
			int index = 0;
			for (int i = 0; i < datas.Count; i++)
			{
				if (!datas[i].IsFinished)
				{
					index = i;
					break;
				}
			}
			MotorFightLevelItem layoutItemByIndex = this.LevelLayout.GetLayoutItemByIndex(index);
			if (layoutItemByIndex == null)
			{
				return null;
			}
			return layoutItemByIndex.GetNavigationItem();
		}

		// Token: 0x04024AE6 RID: 150246
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<MotorFightLevelItem, MotorFightLevelData> LevelLayout;

		// Token: 0x0200C709 RID: 50953
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x0403D479 RID: 251001
			public const int LayoutLevel = 0;
		}
	}
}
