using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using UnrealEngine;

// Token: 0x020019F1 RID: 6641
public class MediumItemGridVisionSlotComponent : MediumItemGridComponent
{
	// Token: 0x0600BE32 RID: 48690 RVA: 0x00325D34 File Offset: 0x00323F34
	protected unsafe override void OnRegisterComponent()
	{
		int num = 12;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600BE33 RID: 48691 RVA: 0x00325EEB File Offset: 0x003240EB
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_ItemVisionStateA";
	}

	// Token: 0x0600BE34 RID: 48692 RVA: 0x00325EF4 File Offset: 0x003240F4
	protected override void OnActivate()
	{
		this.SlotSpriteList = new UUISprite[][]
		{
			new UUISprite[]
			{
				base.GetSprite(0),
				base.GetSprite(1),
				base.GetSprite(2),
				base.GetSprite(3)
			},
			new UUISprite[]
			{
				base.GetSprite(4),
				base.GetSprite(5),
				base.GetSprite(6),
				base.GetSprite(7)
			},
			new UUISprite[]
			{
				base.GetSprite(8),
				base.GetSprite(9),
				base.GetSprite(10),
				base.GetSprite(11)
			}
		};
	}

	// Token: 0x0600BE35 RID: 48693 RVA: 0x00325FA3 File Offset: 0x003241A3
	protected override void OnDeactivate()
	{
		this.SlotSpriteList = new UUISprite[0][];
	}

	// Token: 0x0600BE36 RID: 48694 RVA: 0x00325FB4 File Offset: 0x003241B4
	[NullableContext(2)]
	protected override void OnRefresh(object data)
	{
		EMediumItemGridVisionSlotState[] array = data as EMediumItemGridVisionSlotState[];
		if (array == null)
		{
			this.SetActive(false);
			return;
		}
		for (int i = 0; i < 3; i++)
		{
			EMediumItemGridVisionSlotState? state = (i < array.Length) ? new EMediumItemGridVisionSlotState?(array[i]) : null;
			this.SetState(i, state);
		}
		this.SetActive(true);
	}

	// Token: 0x0600BE37 RID: 48695 RVA: 0x00326008 File Offset: 0x00324208
	private void SetState(int slotIndex, EMediumItemGridVisionSlotState? state)
	{
		if (slotIndex >= this.SlotSpriteList.Length)
		{
			return;
		}
		UUISprite[] array = this.SlotSpriteList[slotIndex];
		if (array == null || array.Length < 4)
		{
			return;
		}
		if (state == null)
		{
			foreach (UUISprite uuisprite in array)
			{
				if (uuisprite != null)
				{
					uuisprite.SetUIActive(false);
				}
			}
			return;
		}
		switch (state.Value)
		{
		case EMediumItemGridVisionSlotState.Lock:
		{
			UUISprite uuisprite2 = array[0];
			if (uuisprite2 != null)
			{
				uuisprite2.SetUIActive(false);
			}
			UUISprite uuisprite3 = array[1];
			if (uuisprite3 != null)
			{
				uuisprite3.SetUIActive(false);
			}
			UUISprite uuisprite4 = array[2];
			if (uuisprite4 != null)
			{
				uuisprite4.SetUIActive(false);
			}
			UUISprite uuisprite5 = array[3];
			if (uuisprite5 == null)
			{
				return;
			}
			uuisprite5.SetUIActive(true);
			return;
		}
		case EMediumItemGridVisionSlotState.UnlockAndNoProp:
		{
			UUISprite uuisprite6 = array[0];
			if (uuisprite6 != null)
			{
				uuisprite6.SetUIActive(false);
			}
			UUISprite uuisprite7 = array[1];
			if (uuisprite7 != null)
			{
				uuisprite7.SetUIActive(true);
			}
			UUISprite uuisprite8 = array[2];
			if (uuisprite8 != null)
			{
				uuisprite8.SetUIActive(false);
			}
			UUISprite uuisprite9 = array[3];
			if (uuisprite9 == null)
			{
				return;
			}
			uuisprite9.SetUIActive(false);
			return;
		}
		case EMediumItemGridVisionSlotState.PreviewUnLock:
		{
			UUISprite uuisprite10 = array[0];
			if (uuisprite10 != null)
			{
				uuisprite10.SetUIActive(false);
			}
			UUISprite uuisprite11 = array[1];
			if (uuisprite11 != null)
			{
				uuisprite11.SetUIActive(false);
			}
			UUISprite uuisprite12 = array[2];
			if (uuisprite12 != null)
			{
				uuisprite12.SetUIActive(true);
			}
			UUISprite uuisprite13 = array[3];
			if (uuisprite13 == null)
			{
				return;
			}
			uuisprite13.SetUIActive(false);
			return;
		}
		case EMediumItemGridVisionSlotState.UnlockAndHaveProp:
		{
			UUISprite uuisprite14 = array[0];
			if (uuisprite14 != null)
			{
				uuisprite14.SetUIActive(true);
			}
			UUISprite uuisprite15 = array[1];
			if (uuisprite15 != null)
			{
				uuisprite15.SetUIActive(false);
			}
			UUISprite uuisprite16 = array[2];
			if (uuisprite16 != null)
			{
				uuisprite16.SetUIActive(false);
			}
			UUISprite uuisprite17 = array[3];
			if (uuisprite17 == null)
			{
				return;
			}
			uuisprite17.SetUIActive(false);
			return;
		}
		default:
			return;
		}
	}

	// Token: 0x04005973 RID: 22899
	private const int UNLOCK_AND_HAVE_PROP_INDEX = 0;

	// Token: 0x04005974 RID: 22900
	private const int UNLOCK_AND_NO_PROP_INDEX = 1;

	// Token: 0x04005975 RID: 22901
	private const int PREVIEW_UNLOCK_INDEX = 2;

	// Token: 0x04005976 RID: 22902
	private const int LOCK_INDEX = 3;

	// Token: 0x04005977 RID: 22903
	private const int STATE_COUNT = 4;

	// Token: 0x04005978 RID: 22904
	private const int STATE_SLOT_COUNT = 3;

	// Token: 0x04005979 RID: 22905
	[Nullable(1)]
	private UUISprite[][] SlotSpriteList = new UUISprite[0][];

	// Token: 0x02007CE0 RID: 31968
	private class EChildType
	{
		// Token: 0x0402A9A4 RID: 174500
		public const int OneStateASprite = 0;

		// Token: 0x0402A9A5 RID: 174501
		public const int OneStateBSprite = 1;

		// Token: 0x0402A9A6 RID: 174502
		public const int OneStateCSprite = 2;

		// Token: 0x0402A9A7 RID: 174503
		public const int OneStateDSprite = 3;

		// Token: 0x0402A9A8 RID: 174504
		public const int TwoStateASprite = 4;

		// Token: 0x0402A9A9 RID: 174505
		public const int TwoStateBSprite = 5;

		// Token: 0x0402A9AA RID: 174506
		public const int TwoStateCSprite = 6;

		// Token: 0x0402A9AB RID: 174507
		public const int TwoStateDSprite = 7;

		// Token: 0x0402A9AC RID: 174508
		public const int ThreeStateASprite = 8;

		// Token: 0x0402A9AD RID: 174509
		public const int ThreeStateBSprite = 9;

		// Token: 0x0402A9AE RID: 174510
		public const int ThreeStateCSprite = 10;

		// Token: 0x0402A9AF RID: 174511
		public const int ThreeStateDSprite = 11;
	}
}
