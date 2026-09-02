using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Data.GaCha.Struct;
using UnrealEngine;

namespace CSharpScript.Game.Module.Weapon.Data
{
	// Token: 0x02004C00 RID: 19456
	[NullableContext(1)]
	[Nullable(0)]
	public class TWeaponModelTransform
	{
		// Token: 0x06032C64 RID: 207972 RVA: 0x00CB822C File Offset: 0x00CB642C
		private TWeaponModelTransform(object value)
		{
			this._value = value;
		}

		// Token: 0x06032C65 RID: 207973 RVA: 0x00CB823B File Offset: 0x00CB643B
		public static implicit operator TWeaponModelTransform(WeaponModelTransform value)
		{
			return new TWeaponModelTransform(value);
		}

		// Token: 0x06032C66 RID: 207974 RVA: 0x00CB8248 File Offset: 0x00CB6448
		public static implicit operator TWeaponModelTransform(SGachaWeaponTransform value)
		{
			return new TWeaponModelTransform(value);
		}

		// Token: 0x06032C67 RID: 207975 RVA: 0x00CB8258 File Offset: 0x00CB6458
		public bool ShowScabbard()
		{
			object value = this._value;
			if (value is WeaponModelTransform)
			{
				return ((WeaponModelTransform)value).ShowScabbard;
			}
			value = this._value;
			if (value is SGachaWeaponTransform)
			{
				SGachaWeaponTransform sgachaWeaponTransform = (SGachaWeaponTransform)value;
				return sgachaWeaponTransform.ShowScabbard;
			}
			return false;
		}

		// Token: 0x06032C68 RID: 207976 RVA: 0x00CB82A4 File Offset: 0x00CB64A4
		public float Size()
		{
			object value = this._value;
			if (value is WeaponModelTransform)
			{
				return ((WeaponModelTransform)value).Size;
			}
			value = this._value;
			if (value is SGachaWeaponTransform)
			{
				SGachaWeaponTransform sgachaWeaponTransform = (SGachaWeaponTransform)value;
				return sgachaWeaponTransform.Size;
			}
			return 0f;
		}

		// Token: 0x06032C69 RID: 207977 RVA: 0x00CB82F4 File Offset: 0x00CB64F4
		public global::Vector Location()
		{
			global::Vector vector = new global::Vector();
			object value = this._value;
			if (value is WeaponModelTransform)
			{
				Aki.Config.Vector? location = ((WeaponModelTransform)value).Location;
				vector.Set((double)location.Value.X, (double)location.Value.Y, (double)location.Value.Z);
			}
			value = this._value;
			if (value is SGachaWeaponTransform)
			{
				SGachaWeaponTransform sgachaWeaponTransform = (SGachaWeaponTransform)value;
				FVector location2 = sgachaWeaponTransform.Location;
				vector.Set((double)location2.X, (double)location2.Y, (double)location2.Z);
			}
			return vector;
		}

		// Token: 0x06032C6A RID: 207978 RVA: 0x00CB839C File Offset: 0x00CB659C
		public global::Vector ScabbardOffset()
		{
			global::Vector vector = new global::Vector();
			object value = this._value;
			if (value is WeaponModelTransform)
			{
				Aki.Config.Vector? scabbardOffset = ((WeaponModelTransform)value).ScabbardOffset;
				vector.Set((double)scabbardOffset.Value.X, (double)scabbardOffset.Value.Y, (double)scabbardOffset.Value.Z);
			}
			value = this._value;
			if (value is SGachaWeaponTransform)
			{
				SGachaWeaponTransform sgachaWeaponTransform = (SGachaWeaponTransform)value;
				FVector scabbardOffset2 = sgachaWeaponTransform.ScabbardOffset;
				vector.Set((double)scabbardOffset2.X, (double)scabbardOffset2.Y, (double)scabbardOffset2.Z);
			}
			return vector;
		}

		// Token: 0x06032C6B RID: 207979 RVA: 0x00CB8444 File Offset: 0x00CB6644
		public global::Vector ScabbardRotationOffset()
		{
			global::Vector vector = new global::Vector();
			object value = this._value;
			if (value is WeaponModelTransform)
			{
				Aki.Config.Vector? scabbardRotationOffset = ((WeaponModelTransform)value).ScabbardRotationOffset;
				vector.Set((double)scabbardRotationOffset.Value.X, (double)scabbardRotationOffset.Value.Y, (double)scabbardRotationOffset.Value.Z);
			}
			value = this._value;
			if (value is SGachaWeaponTransform)
			{
				SGachaWeaponTransform sgachaWeaponTransform = (SGachaWeaponTransform)value;
				FVector scabbardRotationOffset2 = sgachaWeaponTransform.ScabbardRotationOffset;
				vector.Set((double)scabbardRotationOffset2.X, (double)scabbardRotationOffset2.Y, (double)scabbardRotationOffset2.Z);
			}
			return vector;
		}

		// Token: 0x06032C6C RID: 207980 RVA: 0x00CB84EC File Offset: 0x00CB66EC
		public bool HasScabbardValue()
		{
			global::Vector vector = this.ScabbardRotationOffset();
			return vector.X != 0.0 || vector.Y != 0.0 || vector.Z != 0.0;
		}

		// Token: 0x06032C6D RID: 207981 RVA: 0x00CB8538 File Offset: 0x00CB6738
		public float RotateTime()
		{
			object value = this._value;
			if (value is WeaponModelTransform)
			{
				return (float)((WeaponModelTransform)value).RotateTime;
			}
			value = this._value;
			if (value is SGachaWeaponTransform)
			{
				SGachaWeaponTransform sgachaWeaponTransform = (SGachaWeaponTransform)value;
				return sgachaWeaponTransform.RotateTime;
			}
			return 0f;
		}

		// Token: 0x06032C6E RID: 207982 RVA: 0x00CB8588 File Offset: 0x00CB6788
		public global::Vector Rotation()
		{
			global::Vector vector = new global::Vector();
			object value = this._value;
			if (value is WeaponModelTransform)
			{
				Aki.Config.Vector? rotation = ((WeaponModelTransform)value).Rotation;
				vector.Set((double)rotation.Value.X, (double)rotation.Value.Y, (double)rotation.Value.Z);
			}
			value = this._value;
			if (value is SGachaWeaponTransform)
			{
				SGachaWeaponTransform sgachaWeaponTransform = (SGachaWeaponTransform)value;
				FVector rotation2 = sgachaWeaponTransform.Rotation;
				vector.Set((double)rotation2.X, (double)rotation2.Y, (double)rotation2.Z);
			}
			return vector;
		}

		// Token: 0x06032C6F RID: 207983 RVA: 0x00CB8630 File Offset: 0x00CB6830
		public global::Vector AxisRotate()
		{
			global::Vector vector = new global::Vector();
			object value = this._value;
			if (value is WeaponModelTransform)
			{
				Aki.Config.Vector? axisRotate = ((WeaponModelTransform)value).AxisRotate;
				vector.Set((double)axisRotate.Value.X, (double)axisRotate.Value.Y, (double)axisRotate.Value.Z);
			}
			value = this._value;
			if (value is SGachaWeaponTransform)
			{
				SGachaWeaponTransform sgachaWeaponTransform = (SGachaWeaponTransform)value;
				FVector axisRotate2 = sgachaWeaponTransform.AxisRotate;
				vector.Set((double)axisRotate2.X, (double)axisRotate2.Y, (double)axisRotate2.Z);
			}
			return vector;
		}

		// Token: 0x0401D8B4 RID: 121012
		private readonly object _value;
	}
}
