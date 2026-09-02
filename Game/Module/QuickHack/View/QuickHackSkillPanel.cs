using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.QuickHack.View
{
	// Token: 0x02005309 RID: 21257
	[NullableContext(1)]
	[Nullable(0)]
	public class QuickHackSkillPanel
	{
		// Token: 0x06036452 RID: 222290 RVA: 0x00DAE23C File Offset: 0x00DAC43C
		public UniTask InitSkillItemsAsync(List<UUIItem> items)
		{
			QuickHackSkillPanel.<InitSkillItemsAsync>d__3 <InitSkillItemsAsync>d__;
			<InitSkillItemsAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitSkillItemsAsync>d__.<>4__this = this;
			<InitSkillItemsAsync>d__.items = items;
			<InitSkillItemsAsync>d__.<>1__state = -1;
			<InitSkillItemsAsync>d__.<>t__builder.Start<QuickHackSkillPanel.<InitSkillItemsAsync>d__3>(ref <InitSkillItemsAsync>d__);
			return <InitSkillItemsAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036453 RID: 222291 RVA: 0x00DAE287 File Offset: 0x00DAC487
		[NullableContext(2)]
		public QuickHackSkillItem GetItem(int index)
		{
			if (index >= this.SkillItemList.Count)
			{
				return null;
			}
			return this.SkillItemList[index];
		}

		// Token: 0x06036454 RID: 222292 RVA: 0x00DAE2A8 File Offset: 0x00DAC4A8
		public void RefreshByData(List<QuickHackSkillInstance> dataList)
		{
			int count = this.SkillItemList.Count;
			int count2 = dataList.Count;
			for (int i = 0; i < count; i++)
			{
				QuickHackSkillItem quickHackSkillItem = this.SkillItemList[i];
				if (i >= count2)
				{
					quickHackSkillItem.SetActive(false);
				}
				else
				{
					QuickHackSkillInstance data = dataList[i];
					quickHackSkillItem.Refresh(data, i == this.CurrentIndex, i);
					quickHackSkillItem.SetActive(true);
				}
			}
		}

		// Token: 0x06036455 RID: 222293 RVA: 0x00DAE310 File Offset: 0x00DAC510
		public void Select(int index)
		{
			if (index == this.CurrentIndex)
			{
				return;
			}
			if (index >= this.SkillItemList.Count)
			{
				return;
			}
			QuickHackSkillItem currentItem = this.CurrentItem;
			if (currentItem != null)
			{
				currentItem.OnDeselected();
			}
			this.CurrentIndex = index;
			QuickHackSkillItem quickHackSkillItem = this.SkillItemList[index];
			this.CurrentItem = quickHackSkillItem;
			quickHackSkillItem.OnSelected();
		}

		// Token: 0x0401F327 RID: 127783
		private readonly List<QuickHackSkillItem> SkillItemList = new List<QuickHackSkillItem>();

		// Token: 0x0401F328 RID: 127784
		[Nullable(2)]
		private QuickHackSkillItem CurrentItem;

		// Token: 0x0401F329 RID: 127785
		private int CurrentIndex = -1;
	}
}
