using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.View.InstanceEntrance
{
	// Token: 0x020061ED RID: 25069
	[NullableContext(2)]
	[Nullable(0)]
	public class ActivityInstanceEntranceScrollItem : UiPanelBase, IDynamicScrollItem<ActivityEntranceItemData>
	{
		// Token: 0x0603F400 RID: 259072 RVA: 0x0103B9A4 File Offset: 0x01039BA4
		[NullableContext(1)]
		public UniTask Init(UUIItem actor)
		{
			ActivityInstanceEntranceScrollItem.<Init>d__7 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.actor = actor;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<ActivityInstanceEntranceScrollItem.<Init>d__7>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x0603F401 RID: 259073 RVA: 0x0103B9F0 File Offset: 0x01039BF0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603F402 RID: 259074 RVA: 0x0103BA9C File Offset: 0x01039C9C
		private UniTask InitChildItem()
		{
			ActivityInstanceEntranceScrollItem.<InitChildItem>d__9 <InitChildItem>d__;
			<InitChildItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitChildItem>d__.<>4__this = this;
			<InitChildItem>d__.<>1__state = -1;
			<InitChildItem>d__.<>t__builder.Start<ActivityInstanceEntranceScrollItem.<InitChildItem>d__9>(ref <InitChildItem>d__);
			return <InitChildItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603F403 RID: 259075 RVA: 0x0103BAE0 File Offset: 0x01039CE0
		[NullableContext(1)]
		public AUIBaseActor GetUsingItem(ActivityEntranceItemData data)
		{
			bool flag = !data.GetLockState();
			if (data.GetStyle() == 0)
			{
				return (flag ? base.GetItem(0) : base.GetItem(2)).GetOwner() as AUIBaseActor;
			}
			return (flag ? base.GetItem(1) : base.GetItem(3)).GetOwner() as AUIBaseActor;
		}

		// Token: 0x0603F404 RID: 259076 RVA: 0x0103BB3C File Offset: 0x01039D3C
		[NullableContext(1)]
		public void Update(ActivityEntranceItemData data, int index)
		{
			this.Data = data;
			bool flag = !data.GetLockState();
			int style = data.GetStyle();
			if (style == 0)
			{
				if (flag)
				{
					this.MainContentItem.RefreshView(data);
				}
				else
				{
					this.LockMainContentItem.RefreshView(data);
				}
			}
			else if (flag)
			{
				this.SubContentItem.RefreshView(data);
			}
			else
			{
				this.LockSubContentItem.RefreshView(data);
			}
			UUIItem uuiitem;
			if (style == 0)
			{
				uuiitem = (flag ? base.GetItem(0) : base.GetItem(2));
			}
			else
			{
				uuiitem = (flag ? base.GetItem(1) : base.GetItem(3));
			}
			if (this.CurrentUsingItem != uuiitem)
			{
				UUIItem currentUsingItem = this.CurrentUsingItem;
				if (currentUsingItem != null)
				{
					currentUsingItem.SetUIActive(false);
				}
			}
			this.CurrentUsingItem = uuiitem;
			UUIItem currentUsingItem2 = this.CurrentUsingItem;
			if (currentUsingItem2 == null)
			{
				return;
			}
			currentUsingItem2.SetUIActive(true);
		}

		// Token: 0x0603F405 RID: 259077 RVA: 0x0103BC00 File Offset: 0x01039E00
		public void ClearItem()
		{
			base.Destroy(null);
		}

		// Token: 0x0402382E RID: 145454
		protected ActivityEntranceItemData Data;

		// Token: 0x0402382F RID: 145455
		private MainContentItem MainContentItem;

		// Token: 0x04023830 RID: 145456
		private SubContentItem SubContentItem;

		// Token: 0x04023831 RID: 145457
		private MainContentItem LockMainContentItem;

		// Token: 0x04023832 RID: 145458
		private SubContentItem LockSubContentItem;

		// Token: 0x04023833 RID: 145459
		private UUIItem CurrentUsingItem;

		// Token: 0x0200C32E RID: 49966
		[NullableContext(0)]
		private enum EComponent
		{
			// Token: 0x0403C275 RID: 246389
			InstanceSeriesItem,
			// Token: 0x0403C276 RID: 246390
			InstanceItem,
			// Token: 0x0403C277 RID: 246391
			LockInstanceSeriesItem,
			// Token: 0x0403C278 RID: 246392
			LockInstanceItem
		}
	}
}
