using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004ED7 RID: 20183
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class TowerDefensePhantomSkillItem : GridProxyAbstract<ITowerDefensePhantomSkillItemData>
	{
		// Token: 0x06034221 RID: 213537 RVA: 0x00D08CA4 File Offset: 0x00D06EA4
		[NullableContext(1)]
		public override void Refresh(ITowerDefensePhantomSkillItemData data, bool isSelected, int gridIndex)
		{
			UUIText text = base.GetText(0);
			if (StringUtils.IsEmpty(data.SkillTextId))
			{
				if (text != null)
				{
					text.SetUIActive(false);
				}
			}
			else
			{
				if (text != null)
				{
					text.SetUIActive(true);
				}
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), data.SkillTextId, Array.Empty<object>());
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "Text_InstanceDungeonRecommendLevel_Text", new <>z__ReadOnlySingleElementList<object>(data.Level));
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), data.DescriptionTextId, data.DescriptionArgs);
		}

		// Token: 0x06034222 RID: 213538 RVA: 0x00D08D38 File Offset: 0x00D06F38
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
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0200AE7F RID: 44671
		private class EComponent
		{
			// Token: 0x040362DF RID: 221919
			public const int SkillText = 0;

			// Token: 0x040362E0 RID: 221920
			public const int LevelText = 1;

			// Token: 0x040362E1 RID: 221921
			public const int DescriptionText = 2;
		}
	}
}
