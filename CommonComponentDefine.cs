using System;
using System.Runtime.CompilerServices;

// Token: 0x0200189E RID: 6302
public class CommonComponentDefine
{
	// Token: 0x04005576 RID: 21878
	public const int WEAPON_ITEMTYPE = 2;

	// Token: 0x04005577 RID: 21879
	public const int WEAPONMATERIAL_ITEMTYPE = 4;

	// Token: 0x04005578 RID: 21880
	public const float UNPHANTOMTYPEALPHA = 0.5f;

	// Token: 0x04005579 RID: 21881
	public const int PHANTOMTYPEALPHA = 1;

	// Token: 0x0400557A RID: 21882
	public const int MINLEVEL = 5;

	// Token: 0x0400557B RID: 21883
	public const int RATIO = 2;

	// Token: 0x0400557C RID: 21884
	public const int FIXED = 1;

	// Token: 0x02007C1A RID: 31770
	public enum ECommonTipsType
	{
		// Token: 0x0402A644 RID: 173636
		Weapon = 2,
		// Token: 0x0402A645 RID: 173637
		Phantom = 9
	}

	// Token: 0x02007C1B RID: 31771
	public enum ECommonTipsHighType
	{
		// Token: 0x0402A647 RID: 173639
		WeaponType,
		// Token: 0x0402A648 RID: 173640
		PhantomType
	}

	// Token: 0x02007C1C RID: 31772
	public enum ENurturePropType
	{
		// Token: 0x0402A64A RID: 173642
		Weapon = 2,
		// Token: 0x0402A64B RID: 173643
		WeaponMaterial = 4
	}

	// Token: 0x02007C1D RID: 31773
	public enum ENurturePropUseType
	{
		// Token: 0x0402A64D RID: 173645
		UseItemId,
		// Token: 0x0402A64E RID: 173646
		UseIncId
	}

	// Token: 0x02007C1E RID: 31774
	public class TipsAttributeData
	{
		// Token: 0x06047BA8 RID: 293800 RVA: 0x0132249A File Offset: 0x0132069A
		public TipsAttributeData(int id, double value, bool isRatio)
		{
			this.Id = id;
			this.Value = value;
			this.IsRatio = isRatio;
		}

		// Token: 0x0402A64F RID: 173647
		public int Id;

		// Token: 0x0402A650 RID: 173648
		public double Value;

		// Token: 0x0402A651 RID: 173649
		public bool IsRatio;
	}

	// Token: 0x02007C1F RID: 31775
	[NullableContext(1)]
	[Nullable(0)]
	public class NurturePropItemData
	{
		// Token: 0x0402A652 RID: 173650
		public int Id;

		// Token: 0x0402A653 RID: 173651
		public int Count;

		// Token: 0x0402A654 RID: 173652
		public CommonComponentDefine.ENurturePropType ItemType = CommonComponentDefine.ENurturePropType.Weapon;

		// Token: 0x0402A655 RID: 173653
		public string BottomText = "";

		// Token: 0x0402A656 RID: 173654
		public string TopText = "";

		// Token: 0x0402A657 RID: 173655
		public int RoleId;

		// Token: 0x0402A658 RID: 173656
		public bool IsSingle;

		// Token: 0x0402A659 RID: 173657
		public int? HoleId;
	}

	// Token: 0x02007C20 RID: 31776
	public enum EAttributeType
	{
		// Token: 0x0402A65B RID: 173659
		NormalType,
		// Token: 0x0402A65C RID: 173660
		PhantomType,
		// Token: 0x0402A65D RID: 173661
		VisionLevelUp,
		// Token: 0x0402A65E RID: 173662
		VisionSlotLevelUp,
		// Token: 0x0402A65F RID: 173663
		VisionSlot
	}
}
