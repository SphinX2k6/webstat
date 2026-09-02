using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Util
{
	// Token: 0x02004C75 RID: 19573
	[NullableContext(1)]
	[Nullable(0)]
	public class LoopAutoScrollView<TItem, [Nullable(2)] TData> where TItem : class, ILoopAutoScrollItem<TData>
	{
		// Token: 0x06033012 RID: 208914 RVA: 0x00CC62F4 File Offset: 0x00CC44F4
		public LoopAutoScrollView(UUIItem viewport, UUIItem templateItem, UUIItem parent, Func<TItem> createFunction, bool isHorizontal = true)
		{
			this.Viewport = viewport;
			this.TemplateItem = templateItem;
			this.TemplateItem.SetUIActive(false);
			this.Parent = parent;
			this.CreateFunction = createFunction;
			this.Horizontal = isHorizontal;
		}

		// Token: 0x06033013 RID: 208915 RVA: 0x00CC6370 File Offset: 0x00CC4570
		public UniTask ReloadItems(IReadOnlyList<TData> data)
		{
			LoopAutoScrollView<TItem, TData>.<ReloadItems>d__17 <ReloadItems>d__;
			<ReloadItems>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ReloadItems>d__.<>4__this = this;
			<ReloadItems>d__.data = data;
			<ReloadItems>d__.<>1__state = -1;
			<ReloadItems>d__.<>t__builder.Start<LoopAutoScrollView<TItem, TData>.<ReloadItems>d__17>(ref <ReloadItems>d__);
			return <ReloadItems>d__.<>t__builder.Task;
		}

		// Token: 0x06033014 RID: 208916 RVA: 0x00CC63BB File Offset: 0x00CC45BB
		public void StartAutoScroll(float speed)
		{
			this.Speed = speed;
			this.StopAutoScroll();
			this.IsRunning = true;
			this.TickId = Singleton<TickSystem>.Instance.Add(new Action<float>(this.OnTick), "LoopAutoScrollView", ETickingGroup.TG_PrePhysics, true, 0, true).Id;
		}

		// Token: 0x06033015 RID: 208917 RVA: 0x00CC63FB File Offset: 0x00CC45FB
		public void StopAutoScroll()
		{
			this.IsRunning = false;
			if (this.TickId != -1)
			{
				Singleton<TickSystem>.Instance.Remove(this.TickId);
				this.TickId = -1;
			}
		}

		// Token: 0x06033016 RID: 208918 RVA: 0x00CC6425 File Offset: 0x00CC4625
		private int CalcTotalItemCount()
		{
			return (int)Math.Ceiling((double)(this.Horizontal ? this.Viewport.GetWidth() : this.Viewport.GetHeight()) / (double)this.ItemLength) + this.BufferCount;
		}

		// Token: 0x06033017 RID: 208919 RVA: 0x00CC6460 File Offset: 0x00CC4660
		private void OnTick(float deltaTime)
		{
			if (!this.IsRunning || this.Speed == 0f || this.ActiveItems.Count <= 0)
			{
				return;
			}
			float num = -(this.Speed * deltaTime);
			foreach (TItem titem in this.ActiveItems)
			{
				UUIItem rootItem = titem.GetRootItem();
				if (this.Horizontal)
				{
					rootItem.SetAnchorOffsetX(rootItem.GetAnchorOffsetX() + num);
				}
				else
				{
					rootItem.SetAnchorOffsetY(rootItem.GetAnchorOffsetY() + num);
				}
			}
			this.AccumulatedOffset += num;
			if (Math.Abs(this.AccumulatedOffset) >= this.ItemLength)
			{
				int num2 = (int)Math.Floor((double)(Math.Abs(this.AccumulatedOffset) / this.ItemLength));
				bool flag = this.AccumulatedOffset < 0f;
				for (int i = 0; i < num2; i++)
				{
					this.Recycle(flag);
				}
				float num3 = (float)((flag ? -1 : 1) * num2) * this.ItemLength;
				this.AccumulatedOffset -= num3;
			}
		}

		// Token: 0x06033018 RID: 208920 RVA: 0x00CC6590 File Offset: 0x00CC4790
		private void Recycle(bool isForward)
		{
			if (this.TotalItemCount <= 0 || this.ActiveItems.Count <= 0 || this.Data.Count <= 0)
			{
				return;
			}
			int count = this.Data.Count;
			TItem titem = default(TItem);
			int index;
			if (isForward)
			{
				titem = this.ActiveItems[0];
				this.ActiveItems.RemoveAt(0);
				this.WindowStartIndex = (this.WindowStartIndex + 1) % count;
				index = (this.WindowStartIndex + this.TotalItemCount - this.BufferCount) % count;
				List<TItem> activeItems = this.ActiveItems;
				UUIItem rootItem = activeItems[activeItems.Count - 1].GetRootItem();
				UUIItem rootItem2 = titem.GetRootItem();
				if (this.Horizontal)
				{
					rootItem2.SetAnchorOffsetX(rootItem.GetAnchorOffsetX() + this.ItemLength);
				}
				else
				{
					rootItem2.SetAnchorOffsetY(rootItem.GetAnchorOffsetY() + this.ItemLength);
				}
				this.ActiveItems.Add(titem);
			}
			else
			{
				List<TItem> activeItems2 = this.ActiveItems;
				titem = activeItems2[activeItems2.Count - 1];
				this.ActiveItems.RemoveAt(this.ActiveItems.Count - 1);
				this.WindowStartIndex = (this.WindowStartIndex - 1 + count) % count;
				index = this.WindowStartIndex;
				UUIItem rootItem3 = this.ActiveItems[0].GetRootItem();
				UUIItem rootItem4 = titem.GetRootItem();
				if (this.Horizontal)
				{
					rootItem4.SetAnchorOffsetX(rootItem3.GetAnchorOffsetX() - this.ItemLength);
				}
				else
				{
					rootItem4.SetAnchorOffsetY(rootItem3.GetAnchorOffsetY() - this.ItemLength);
				}
				this.ActiveItems.Insert(0, titem);
			}
			TItem titem2 = titem;
			if (titem2 == null)
			{
				return;
			}
			titem2.Refresh(this.Data[index]);
		}

		// Token: 0x0401DAA3 RID: 121507
		protected bool Horizontal = true;

		// Token: 0x0401DAA4 RID: 121508
		private readonly UUIItem Viewport;

		// Token: 0x0401DAA5 RID: 121509
		private readonly UUIItem TemplateItem;

		// Token: 0x0401DAA6 RID: 121510
		private IReadOnlyList<TData> Data = Array.Empty<TData>();

		// Token: 0x0401DAA7 RID: 121511
		private readonly List<TItem> Items = new List<TItem>();

		// Token: 0x0401DAA8 RID: 121512
		private readonly List<TItem> ActiveItems = new List<TItem>();

		// Token: 0x0401DAA9 RID: 121513
		private float Speed;

		// Token: 0x0401DAAA RID: 121514
		private readonly int BufferCount = 2;

		// Token: 0x0401DAAB RID: 121515
		private bool IsRunning;

		// Token: 0x0401DAAC RID: 121516
		protected float ItemLength;

		// Token: 0x0401DAAD RID: 121517
		private int WindowStartIndex;

		// Token: 0x0401DAAE RID: 121518
		private float AccumulatedOffset;

		// Token: 0x0401DAAF RID: 121519
		private int TickId = -1;

		// Token: 0x0401DAB0 RID: 121520
		private readonly Func<TItem> CreateFunction;

		// Token: 0x0401DAB1 RID: 121521
		private int TotalItemCount;

		// Token: 0x0401DAB2 RID: 121522
		private readonly UUIItem Parent;
	}
}
