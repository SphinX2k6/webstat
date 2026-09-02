using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.AutoAttach
{
	// Token: 0x02006159 RID: 24921
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1,
		1
	})]
	public class CircleAttachView<[Nullable(2)] T, [Nullable(0)] TAttachItem> : AutoAttachBaseView<T, TAttachItem> where TAttachItem : AutoAttachItem<T>
	{
		// Token: 0x0603EFB3 RID: 257971 RVA: 0x01024B6E File Offset: 0x01022D6E
		public CircleAttachView(AActor controllerActor, bool isNeedScrollCallback = false) : base(controllerActor, isNeedScrollCallback)
		{
		}

		// Token: 0x0603EFB4 RID: 257972 RVA: 0x01024B78 File Offset: 0x01022D78
		public override TAttachItem FindAutoAttachItem()
		{
			return base.FindNearestMiddleItem();
		}

		// Token: 0x0603EFB5 RID: 257973 RVA: 0x01024B80 File Offset: 0x01022D80
		protected override float RecalculateMoveOffset(float offset)
		{
			return offset;
		}

		// Token: 0x0603EFB6 RID: 257974 RVA: 0x01024B84 File Offset: 0x01022D84
		protected override void ReloadItems(int showItemNum, T[] data, int attachTo = 0)
		{
			if (showItemNum < this.ShowItemNum)
			{
				Singleton<Log>.Instance.Error(ELogModule.UiCommon, ELogAuthor.YZY, "组件数据长度需要大于等于展示长度", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			int count = this.Items.Count;
			for (int i = 0; i < count; i++)
			{
				this.Items[i].SetUiActive(false);
			}
			for (int j = 0; j < this.ShowItemNum + 1; j++)
			{
				if (j >= this.Items.Count)
				{
					AActor arg = Singleton<LguiUtil>.Instance.DuplicateActor(this.SourceActor as AUIBaseActor, this.ControllerItem);
					TAttachItem tattachItem = this.CreateItemFunction(arg, j, this.ShowItemNum);
					tattachItem.SetSourceView(this);
					this.Items.Add(tattachItem);
				}
				this.Items[j].SetItemIndex(j);
				this.Items[j].SetUiActive(true);
				this.Items[j].SetData(data);
				this.Items[j].InitItem();
			}
			base.RefreshItems();
			base.ForceUnSelectItems();
			base.AttachToIndex(attachTo, true);
		}

		// Token: 0x0603EFB7 RID: 257975 RVA: 0x01024CCC File Offset: 0x01022ECC
		[NullableContext(2)]
		protected override TAttachItem FindNextDirectionItem(int direction)
		{
			TAttachItem tattachItem = base.FindNearestMiddleItem();
			List<TAttachItem> items = base.GetItems();
			if (items == null || tattachItem == null)
			{
				return default(TAttachItem);
			}
			TAttachItem result = tattachItem;
			float currentPosition = tattachItem.GetCurrentPosition();
			int count = items.Count;
			float num = 99999f;
			if (direction > 0)
			{
				for (int i = 0; i < count; i++)
				{
					float currentPosition2 = items[i].GetCurrentPosition();
					if (currentPosition2 > currentPosition && currentPosition2 - currentPosition < num)
					{
						result = items[i];
						num = currentPosition2 - currentPosition;
					}
				}
			}
			else
			{
				for (int j = 0; j < count; j++)
				{
					float currentPosition3 = items[j].GetCurrentPosition();
					if (currentPosition3 < currentPosition && currentPosition - currentPosition3 < num)
					{
						result = items[j];
						num = currentPosition - currentPosition3;
					}
				}
			}
			return result;
		}

		// Token: 0x0603EFB8 RID: 257976 RVA: 0x01024DA3 File Offset: 0x01022FA3
		public override bool GetIfCircle()
		{
			return true;
		}

		// Token: 0x0603EFB9 RID: 257977 RVA: 0x01024DA8 File Offset: 0x01022FA8
		public void MoveToNextItem(int direction)
		{
			if (base.MovingState())
			{
				return;
			}
			base.ForceUnSelectItems();
			int num = base.GetCurrentSelectIndex() + direction;
			if (num < 0)
			{
				num = this.DataLength - 1;
			}
			else if (num >= this.DataLength)
			{
				num = 0;
			}
			this.CurrentSelectItemIndex = num;
			float num2 = (float)base.GetAutoAttachMoveMinusOffsetDirection() * base.GetItemGapSize();
			base.SetMoveTypeOffset(EMoveType.Inertia, -num2 * (float)direction);
			this.CurrentRunningElasticTime = 0f;
			this.InertiaState = true;
			base.Tick(0f);
		}
	}
}
