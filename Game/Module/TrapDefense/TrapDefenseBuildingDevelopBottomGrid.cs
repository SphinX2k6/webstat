using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E13 RID: 19987
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class TrapDefenseBuildingDevelopBottomGrid : GridProxyAbstract<TrapDefenseBuildingSlotData>
	{
		// Token: 0x06033B01 RID: 211713 RVA: 0x00CEAB6C File Offset: 0x00CE8D6C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06033B02 RID: 211714 RVA: 0x00CEABB4 File Offset: 0x00CE8DB4
		protected override UniTask OnBeforeStartAsync()
		{
			TrapDefenseBuildingDevelopBottomGrid.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TrapDefenseBuildingDevelopBottomGrid.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06033B03 RID: 211715 RVA: 0x00CEABF7 File Offset: 0x00CE8DF7
		protected override void OnBeforeDestroy()
		{
			this.DataItem = null;
		}

		// Token: 0x06033B04 RID: 211716 RVA: 0x00CEAC00 File Offset: 0x00CE8E00
		public override void Refresh(TrapDefenseBuildingSlotData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			this.UpdateData();
		}

		// Token: 0x06033B05 RID: 211717 RVA: 0x00CEAC0F File Offset: 0x00CE8E0F
		public void UpdateData()
		{
			this.DataItem.Refresh(this.Data);
		}

		// Token: 0x06033B06 RID: 211718 RVA: 0x00CEAC22 File Offset: 0x00CE8E22
		public override void OnSelected(bool fireEvent)
		{
			TrapDefenseBuildingDevelopBottomInfoItem dataItem = this.DataItem;
			if (dataItem != null)
			{
				dataItem.SetSelected(true);
			}
			if (fireEvent)
			{
				Action<TrapDefenseBuildingSlotData> onClickCb = this.OnClickCb;
				if (onClickCb == null)
				{
					return;
				}
				onClickCb(this.Data);
			}
		}

		// Token: 0x06033B07 RID: 211719 RVA: 0x00CEAC4F File Offset: 0x00CE8E4F
		public override void OnDeselected(bool fireEvent)
		{
			TrapDefenseBuildingDevelopBottomInfoItem dataItem = this.DataItem;
			if (dataItem == null)
			{
				return;
			}
			dataItem.SetSelected(false);
		}

		// Token: 0x06033B08 RID: 211720 RVA: 0x00CEAC62 File Offset: 0x00CE8E62
		public TrapDefenseBuildingDevelopBottomInfoItem GetDataItem()
		{
			return this.DataItem;
		}

		// Token: 0x0401DEE9 RID: 122601
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<TrapDefenseBuildingSlotData> OnClickCb;

		// Token: 0x0401DEEA RID: 122602
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Func<TrapDefenseBuildingSlotData, bool> CanExecuteChangeCb;

		// Token: 0x0401DEEB RID: 122603
		[Nullable(2)]
		protected TrapDefenseBuildingSlotData Data;

		// Token: 0x0401DEEC RID: 122604
		[Nullable(2)]
		protected TrapDefenseBuildingDevelopBottomInfoItem DataItem;

		// Token: 0x0200AD8A RID: 44426
		[NullableContext(0)]
		private class EGrid
		{
			// Token: 0x04035E4F RID: 220751
			public const int Item = 0;
		}
	}
}
