using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.KuroCS.ClothPath
{
	// Token: 0x02003C03 RID: 15363
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(92, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 92)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/KuroCS/ClothPath/particle_cloth_path.particle_cloth_path")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 92)]
	public struct particle_cloth_path : IEqualityOperators<particle_cloth_path, particle_cloth_path, bool>, IEquatable<particle_cloth_path>, IUnrealScriptStruct
	{
		// Token: 0x06022CFE RID: 142590 RVA: 0x0096FC1C File Offset: 0x0096DE1C
		public particle_cloth_path(float dis_top, float dis_bottom, float dis_left, float dis_right, float dis_topLeft, float dis_topRight, float dis_bottomLeft, float dis_bottomRight, int topID, int bottomID, int leftID, int rightID, int topLeftID, int topRightID, int bottomLeftID, int bottomRightID, FVector pos, float pinWeight, FVector normal)
		{
			this.dis_top = dis_top;
			this.dis_bottom = dis_bottom;
			this.dis_left = dis_left;
			this.dis_right = dis_right;
			this.dis_topLeft = dis_topLeft;
			this.dis_topRight = dis_topRight;
			this.dis_bottomLeft = dis_bottomLeft;
			this.dis_bottomRight = dis_bottomRight;
			this.topID = topID;
			this.bottomID = bottomID;
			this.leftID = leftID;
			this.rightID = rightID;
			this.topLeftID = topLeftID;
			this.topRightID = topRightID;
			this.bottomLeftID = bottomLeftID;
			this.bottomRightID = bottomRightID;
			this.pos = pos;
			this.pinWeight = pinWeight;
			this.normal = normal;
		}

		// Token: 0x06022CFF RID: 142591 RVA: 0x0096FCC0 File Offset: 0x0096DEC0
		public static bool operator ==(particle_cloth_path left, particle_cloth_path right)
		{
			return left.dis_top == right.dis_top && left.dis_bottom == right.dis_bottom && left.dis_left == right.dis_left && left.dis_right == right.dis_right && left.dis_topLeft == right.dis_topLeft && left.dis_topRight == right.dis_topRight && left.dis_bottomLeft == right.dis_bottomLeft && left.dis_bottomRight == right.dis_bottomRight && left.topID == right.topID && left.bottomID == right.bottomID && left.leftID == right.leftID && left.rightID == right.rightID && left.topLeftID == right.topLeftID && left.topRightID == right.topRightID && left.bottomLeftID == right.bottomLeftID && left.bottomRightID == right.bottomRightID && left.pos == right.pos && left.pinWeight == right.pinWeight && left.normal == right.normal;
		}

		// Token: 0x06022D00 RID: 142592 RVA: 0x0096FDFF File Offset: 0x0096DFFF
		public static bool operator !=(particle_cloth_path left, particle_cloth_path right)
		{
			return !(left == right);
		}

		// Token: 0x06022D01 RID: 142593 RVA: 0x0096FE0B File Offset: 0x0096E00B
		public bool Equals(particle_cloth_path other)
		{
			return this == other;
		}

		// Token: 0x06022D02 RID: 142594 RVA: 0x0096FE1C File Offset: 0x0096E01C
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is particle_cloth_path)
			{
				particle_cloth_path other = (particle_cloth_path)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x06022D03 RID: 142595 RVA: 0x0096FE44 File Offset: 0x0096E044
		public override int GetHashCode()
		{
			HashCode hashCode = default(HashCode);
			hashCode.Add<float>(this.dis_top);
			hashCode.Add<float>(this.dis_bottom);
			hashCode.Add<float>(this.dis_left);
			hashCode.Add<float>(this.dis_right);
			hashCode.Add<float>(this.dis_topLeft);
			hashCode.Add<float>(this.dis_topRight);
			hashCode.Add<float>(this.dis_bottomLeft);
			hashCode.Add<float>(this.dis_bottomRight);
			hashCode.Add<int>(this.topID);
			hashCode.Add<int>(this.bottomID);
			hashCode.Add<int>(this.leftID);
			hashCode.Add<int>(this.rightID);
			hashCode.Add<int>(this.topLeftID);
			hashCode.Add<int>(this.topRightID);
			hashCode.Add<int>(this.bottomLeftID);
			hashCode.Add<int>(this.bottomRightID);
			hashCode.Add<FVector>(this.pos);
			hashCode.Add<float>(this.pinWeight);
			hashCode.Add<FVector>(this.normal);
			return hashCode.ToHashCode();
		}

		// Token: 0x06022D04 RID: 142596 RVA: 0x0096FF57 File Offset: 0x0096E157
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (particle_cloth_path._ScriptStructPtr != 0) ? particle_cloth_path._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/PCG/KuroCS/ClothPath/particle_cloth_path.particle_cloth_path", ref particle_cloth_path._ScriptStructPtr);
		}

		// Token: 0x04011A98 RID: 72344
		[FieldOffset(0)]
		public float dis_top;

		// Token: 0x04011A99 RID: 72345
		[FieldOffset(4)]
		public float dis_bottom;

		// Token: 0x04011A9A RID: 72346
		[FieldOffset(8)]
		public float dis_left;

		// Token: 0x04011A9B RID: 72347
		[FieldOffset(12)]
		public float dis_right;

		// Token: 0x04011A9C RID: 72348
		[FieldOffset(16)]
		public float dis_topLeft;

		// Token: 0x04011A9D RID: 72349
		[FieldOffset(20)]
		public float dis_topRight;

		// Token: 0x04011A9E RID: 72350
		[FieldOffset(24)]
		public float dis_bottomLeft;

		// Token: 0x04011A9F RID: 72351
		[FieldOffset(28)]
		public float dis_bottomRight;

		// Token: 0x04011AA0 RID: 72352
		[FieldOffset(32)]
		public int topID;

		// Token: 0x04011AA1 RID: 72353
		[FieldOffset(36)]
		public int bottomID;

		// Token: 0x04011AA2 RID: 72354
		[FieldOffset(40)]
		public int leftID;

		// Token: 0x04011AA3 RID: 72355
		[FieldOffset(44)]
		public int rightID;

		// Token: 0x04011AA4 RID: 72356
		[FieldOffset(48)]
		public int topLeftID;

		// Token: 0x04011AA5 RID: 72357
		[FieldOffset(52)]
		public int topRightID;

		// Token: 0x04011AA6 RID: 72358
		[FieldOffset(56)]
		public int bottomLeftID;

		// Token: 0x04011AA7 RID: 72359
		[FieldOffset(60)]
		public int bottomRightID;

		// Token: 0x04011AA8 RID: 72360
		[FieldOffset(64)]
		public FVector pos;

		// Token: 0x04011AA9 RID: 72361
		[FieldOffset(76)]
		public float pinWeight;

		// Token: 0x04011AAA RID: 72362
		[FieldOffset(80)]
		public FVector normal;

		// Token: 0x04011AAB RID: 72363
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/KuroCS/ClothPath/particle_cloth_path.particle_cloth_path";

		// Token: 0x04011AAC RID: 72364
		private static IntPtr _ScriptStructPtr;
	}
}
