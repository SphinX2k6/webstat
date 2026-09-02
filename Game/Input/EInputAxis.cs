using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Input
{
	// Token: 0x02006FCD RID: 28621
	[NullableContext(1)]
	[Nullable(0)]
	public readonly struct EInputAxis : IEquatable<EInputAxis>
	{
		// Token: 0x0604540E RID: 283662 RVA: 0x01217656 File Offset: 0x01215856
		private EInputAxis(string name, byte inputAxisEnum)
		{
			this.Name = name;
			this.Value = inputAxisEnum;
		}

		// Token: 0x0604540F RID: 283663 RVA: 0x01217666 File Offset: 0x01215866
		public override string ToString()
		{
			return this.Name;
		}

		// Token: 0x06045410 RID: 283664 RVA: 0x0121766E File Offset: 0x0121586E
		public bool Equals(EInputAxis other)
		{
			return this.Name == other.Name;
		}

		// Token: 0x06045411 RID: 283665 RVA: 0x01217684 File Offset: 0x01215884
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is EInputAxis)
			{
				EInputAxis other = (EInputAxis)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x06045412 RID: 283666 RVA: 0x012176A9 File Offset: 0x012158A9
		public override int GetHashCode()
		{
			string name = this.Name;
			if (name == null)
			{
				return 0;
			}
			return name.GetHashCode();
		}

		// Token: 0x06045413 RID: 283667 RVA: 0x012176BC File Offset: 0x012158BC
		public static bool operator ==(EInputAxis left, EInputAxis right)
		{
			return left.Value == right.Value;
		}

		// Token: 0x06045414 RID: 283668 RVA: 0x012176CC File Offset: 0x012158CC
		public static bool operator !=(EInputAxis left, EInputAxis right)
		{
			return left.Value != right.Value;
		}

		// Token: 0x06045415 RID: 283669 RVA: 0x012176DF File Offset: 0x012158DF
		public static implicit operator byte(EInputAxis axis)
		{
			return axis.Value;
		}

		// Token: 0x06045416 RID: 283670 RVA: 0x012176E8 File Offset: 0x012158E8
		public static explicit operator EInputAxis(byte value)
		{
			switch (value)
			{
			case 0:
				return EInputAxis.None;
			case 1:
				return EInputAxis.LookUp;
			case 2:
				return EInputAxis.Turn;
			case 3:
				return EInputAxis.MoveForward;
			case 4:
				return EInputAxis.MoveRight;
			case 5:
				return EInputAxis.Zoom;
			case 6:
				return EInputAxis.WheelAxis;
			default:
				return default(EInputAxis);
			}
		}

		// Token: 0x04026A40 RID: 158272
		public readonly string Name;

		// Token: 0x04026A41 RID: 158273
		public readonly byte Value;

		// Token: 0x04026A42 RID: 158274
		public const byte NoneValue = 0;

		// Token: 0x04026A43 RID: 158275
		public static readonly EInputAxis None = new EInputAxis("None", 0);

		// Token: 0x04026A44 RID: 158276
		public const byte LookUpValue = 1;

		// Token: 0x04026A45 RID: 158277
		public static readonly EInputAxis LookUp = new EInputAxis("LookUp", 1);

		// Token: 0x04026A46 RID: 158278
		public const byte TurnValue = 2;

		// Token: 0x04026A47 RID: 158279
		public static readonly EInputAxis Turn = new EInputAxis("Turn", 2);

		// Token: 0x04026A48 RID: 158280
		public const byte MoveForwardValue = 3;

		// Token: 0x04026A49 RID: 158281
		public static readonly EInputAxis MoveForward = new EInputAxis("MoveForward", 3);

		// Token: 0x04026A4A RID: 158282
		public const byte MoveRightValue = 4;

		// Token: 0x04026A4B RID: 158283
		public static readonly EInputAxis MoveRight = new EInputAxis("MoveRight", 4);

		// Token: 0x04026A4C RID: 158284
		public const byte ZoomValue = 5;

		// Token: 0x04026A4D RID: 158285
		public static readonly EInputAxis Zoom = new EInputAxis("Zoom", 5);

		// Token: 0x04026A4E RID: 158286
		public const byte WheelAxisValue = 6;

		// Token: 0x04026A4F RID: 158287
		public static readonly EInputAxis WheelAxis = new EInputAxis("WheelAxis", 6);

		// Token: 0x04026A50 RID: 158288
		[StaticVariableRuleIgnore]
		public static IReadOnlyList<EInputAxis> Defines = new List<EInputAxis>
		{
			EInputAxis.None,
			EInputAxis.LookUp,
			EInputAxis.Turn,
			EInputAxis.MoveForward,
			EInputAxis.MoveRight,
			EInputAxis.Zoom,
			EInputAxis.WheelAxis
		};
	}
}
