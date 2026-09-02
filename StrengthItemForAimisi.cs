using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02001FC8 RID: 8136
public class StrengthItemForAimisi : StrengthItem
{
	// Token: 0x0600F5A7 RID: 62887 RVA: 0x004340F5 File Offset: 0x004322F5
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_EnduranceAimisi";
	}

	// Token: 0x0600F5A8 RID: 62888 RVA: 0x004340FC File Offset: 0x004322FC
	protected override void OnRegisterComponent()
	{
		Dictionary<int, Type> dictionary = new Dictionary<int, Type>
		{
			{
				1,
				typeof(UUISprite)
			},
			{
				0,
				typeof(UUISprite)
			},
			{
				6,
				typeof(UUISprite)
			}
		};
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>();
		for (int i = 0; i < 21; i++)
		{
			Type type;
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(i, dictionary.TryGetValue(i, out type) ? type : typeof(UUIItem)));
		}
	}

	// Token: 0x0600F5A9 RID: 62889 RVA: 0x00434184 File Offset: 0x00432384
	private int GetEnumValue(int value)
	{
		int result;
		if (!this.ChildTypeMap.TryGetValue(value, out result))
		{
			return value;
		}
		return result;
	}

	// Token: 0x0600F5AA RID: 62890 RVA: 0x004341A4 File Offset: 0x004323A4
	protected override int ResolveChildType(int name)
	{
		return this.GetEnumValue(name);
	}

	// Token: 0x0600F5AB RID: 62891 RVA: 0x004341AD File Offset: 0x004323AD
	protected override void OnBeforeShow()
	{
		base.OnBeforeShow();
		if (this.IsEnableStrengthItem)
		{
			this.OnEnableStrengthItem(this.IsEnableStrengthItem);
		}
	}

	// Token: 0x0600F5AC RID: 62892 RVA: 0x004341C9 File Offset: 0x004323C9
	protected override void InitUi()
	{
	}

	// Token: 0x0600F5AD RID: 62893 RVA: 0x004341CB File Offset: 0x004323CB
	protected override void OnAddEntityEvents()
	{
	}

	// Token: 0x0600F5AE RID: 62894 RVA: 0x004341D0 File Offset: 0x004323D0
	protected override void SetNormal(bool bNormal)
	{
		if (this.IsNormalState == bNormal)
		{
			return;
		}
		this.IsNormalState = bNormal;
		UUISprite sprite = base.GetSprite(1);
		UUISprite sprite2 = base.GetSprite(0);
		if (sprite.IsUIActiveSelf() == bNormal)
		{
			sprite.SetUIActive(!bNormal);
		}
		if (sprite.IsUIActiveSelf() != bNormal)
		{
			sprite2.SetUIActive(bNormal);
		}
	}

	// Token: 0x040076BC RID: 30396
	[Nullable(1)]
	private readonly Dictionary<int, int> ChildTypeMap = new Dictionary<int, int>
	{
		{
			8,
			0
		},
		{
			7,
			1
		},
		{
			11,
			2
		},
		{
			10,
			3
		},
		{
			3,
			5
		},
		{
			9,
			6
		},
		{
			13,
			7
		},
		{
			12,
			8
		},
		{
			14,
			9
		},
		{
			15,
			10
		},
		{
			16,
			11
		},
		{
			17,
			12
		},
		{
			18,
			13
		},
		{
			19,
			14
		},
		{
			20,
			15
		},
		{
			21,
			16
		},
		{
			2,
			17
		},
		{
			4,
			18
		},
		{
			5,
			19
		},
		{
			6,
			20
		}
	};

	// Token: 0x02008358 RID: 33624
	private new enum EChildType
	{
		// Token: 0x0402C8BE RID: 182462
		NormalBarSprite,
		// Token: 0x0402C8BF RID: 182463
		LowBarSprite,
		// Token: 0x0402C8C0 RID: 182464
		StrengthLineItem,
		// Token: 0x0402C8C1 RID: 182465
		StrengthSingleLineItem,
		// Token: 0x0402C8C2 RID: 182466
		FrontMarker,
		// Token: 0x0402C8C3 RID: 182467
		TemporaryItem,
		// Token: 0x0402C8C4 RID: 182468
		TemporaryBarSprite,
		// Token: 0x0402C8C5 RID: 182469
		TemporaryLineItem,
		// Token: 0x0402C8C6 RID: 182470
		TemporarySingleLineItem,
		// Token: 0x0402C8C7 RID: 182471
		AnimStart,
		// Token: 0x0402C8C8 RID: 182472
		AnimClose,
		// Token: 0x0402C8C9 RID: 182473
		AnimFull,
		// Token: 0x0402C8CA RID: 182474
		AnimNone,
		// Token: 0x0402C8CB RID: 182475
		AnimPickUp,
		// Token: 0x0402C8CC RID: 182476
		AnimTempStart,
		// Token: 0x0402C8CD RID: 182477
		AnimTempClose,
		// Token: 0x0402C8CE RID: 182478
		AutoMovingItem,
		// Token: 0x0402C8CF RID: 182479
		NoneItem,
		// Token: 0x0402C8D0 RID: 182480
		BuffItem,
		// Token: 0x0402C8D1 RID: 182481
		DeBuffItem,
		// Token: 0x0402C8D2 RID: 182482
		DisableItem,
		// Token: 0x0402C8D3 RID: 182483
		MaxCount
	}
}
