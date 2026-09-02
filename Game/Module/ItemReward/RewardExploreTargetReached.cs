using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B5D RID: 23389
	[NullableContext(1)]
	[Nullable(0)]
	public class RewardExploreTargetReached : UiPanelBase
	{
		// Token: 0x0603B2A3 RID: 242339 RVA: 0x00EF88B6 File Offset: 0x00EF6AB6
		public RewardExploreTargetReached(AActor rootActor)
		{
			base.CreateThenShowByActor(rootActor, null);
		}

		// Token: 0x0603B2A4 RID: 242340 RVA: 0x00EF88C8 File Offset: 0x00EF6AC8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>();
		}

		// Token: 0x0603B2A5 RID: 242341 RVA: 0x00EF893C File Offset: 0x00EF6B3C
		public void Refresh(IRewardExploreTargetReached rewardExploreBarData)
		{
			this.SetTargetSpriteActive(rewardExploreBarData.IsReached);
			this.SetDescriptionText(rewardExploreBarData.DescriptionTextId, rewardExploreBarData.Target);
		}

		// Token: 0x0603B2A6 RID: 242342 RVA: 0x00EF895C File Offset: 0x00EF6B5C
		private void SetTargetSpriteActive(bool active)
		{
			UUISprite sprite = base.GetSprite(0);
			if (sprite == null)
			{
				return;
			}
			sprite.SetUIActive(active);
		}

		// Token: 0x0603B2A7 RID: 242343 RVA: 0x00EF8970 File Offset: 0x00EF6B70
		private void SetDescriptionText(string descriptionTextId, List<string> target)
		{
			UUIText text = base.GetText(1);
			if (StringUtils.IsEmpty(descriptionTextId))
			{
				if (text != null)
				{
					text.SetUIActive(false);
				}
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, descriptionTextId, target);
			if (text != null)
			{
				text.SetUIActive(true);
			}
		}

		// Token: 0x0200BB69 RID: 47977
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x04039D35 RID: 236853
			public const int TargetSprite = 0;

			// Token: 0x04039D36 RID: 236854
			public const int DescriptionText = 1;
		}
	}
}
