using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorFight
{
	// Token: 0x020066D4 RID: 26324
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class MotorFightGridItem : SyncGridProxyAbstract<MotorFightItemData>
	{
		// Token: 0x06041BBE RID: 269246 RVA: 0x010DB464 File Offset: 0x010D9664
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

		// Token: 0x06041BBF RID: 269247 RVA: 0x010DB4AC File Offset: 0x010D96AC
		protected override void OnStart()
		{
			this.GridItem = new MotorFightGridMediumItemGrid();
			this.GridItem.CreateThenShowByActor(base.GetItem(0).GetOwner(), null);
			this.GridItem.OnClickCallBack = this.OnClickCb;
		}

		// Token: 0x06041BC0 RID: 269248 RVA: 0x010DB4E4 File Offset: 0x010D96E4
		public override void Refresh(MotorFightItemData data)
		{
			this.Data = data;
			MotorFightGridMediumItemGrid gridItem = this.GridItem;
			if (gridItem != null)
			{
				gridItem.Refresh(data);
			}
			bool toggleState = this.IsSelected(data.Id);
			MotorFightGridMediumItemGrid gridItem2 = this.GridItem;
			if (gridItem2 == null)
			{
				return;
			}
			gridItem2.SetToggleState(toggleState);
		}

		// Token: 0x06041BC1 RID: 269249 RVA: 0x010DB52D File Offset: 0x010D972D
		public void SetToggleState(bool state)
		{
			MotorFightGridMediumItemGrid gridItem = this.GridItem;
			if (gridItem == null)
			{
				return;
			}
			gridItem.SetToggleState(state);
		}

		// Token: 0x04024ADB RID: 150235
		[Nullable(2)]
		public MotorFightItemData Data;

		// Token: 0x04024ADC RID: 150236
		public Func<int, bool> IsSelected = (int id) => false;

		// Token: 0x04024ADD RID: 150237
		[Nullable(2)]
		private MotorFightGridMediumItemGrid GridItem;

		// Token: 0x04024ADE RID: 150238
		public Action<MotorFightItemData> OnClickCb;

		// Token: 0x0200C701 RID: 50945
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403D44C RID: 250956
			public const int ItemBaseGrid = 0;
		}
	}
}
