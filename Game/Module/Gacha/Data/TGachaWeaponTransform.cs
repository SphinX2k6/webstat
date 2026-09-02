using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Data.GaCha.Struct;
using UnrealEngine;

namespace CSharpScript.Game.Module.Gacha.Data
{
	// Token: 0x02005D18 RID: 23832
	[NullableContext(1)]
	[Nullable(0)]
	public class TGachaWeaponTransform
	{
		// Token: 0x0603C159 RID: 246105 RVA: 0x00F3C85F File Offset: 0x00F3AA5F
		[NullableContext(2)]
		private TGachaWeaponTransform(object value)
		{
			this._value = value;
		}

		// Token: 0x0603C15A RID: 246106 RVA: 0x00F3C86E File Offset: 0x00F3AA6E
		public static implicit operator TGachaWeaponTransform(GachaWeaponTransform? value)
		{
			return new TGachaWeaponTransform(value);
		}

		// Token: 0x0603C15B RID: 246107 RVA: 0x00F3C87B File Offset: 0x00F3AA7B
		public static implicit operator TGachaWeaponTransform(SGachaWeaponTransform? value)
		{
			return new TGachaWeaponTransform(value);
		}

		// Token: 0x0603C15C RID: 246108 RVA: 0x00F3C888 File Offset: 0x00F3AA88
		[NullableContext(2)]
		public bool Is<T>()
		{
			return this._value is T;
		}

		// Token: 0x0603C15D RID: 246109 RVA: 0x00F3C898 File Offset: 0x00F3AA98
		[NullableContext(0)]
		public T? As<T>() where T : struct
		{
			object value = this._value;
			if (value is T)
			{
				T value2 = (T)((object)value);
				return new T?(value2);
			}
			return null;
		}

		// Token: 0x0603C15E RID: 246110 RVA: 0x00F3C8CD File Offset: 0x00F3AACD
		[return: Nullable(2)]
		public T AsClass<T>() where T : class
		{
			return this._value as T;
		}

		// Token: 0x17009875 RID: 39029
		// (get) Token: 0x0603C15F RID: 246111 RVA: 0x00F3C8E0 File Offset: 0x00F3AAE0
		public bool ShowScabbard
		{
			get
			{
				object value = this._value;
				if (value is GachaWeaponTransform)
				{
					return ((GachaWeaponTransform)value).ShowScabbard;
				}
				value = this._value;
				if (value is SGachaWeaponTransform)
				{
					SGachaWeaponTransform sgachaWeaponTransform = (SGachaWeaponTransform)value;
					return sgachaWeaponTransform.ShowScabbard;
				}
				return false;
			}
		}

		// Token: 0x17009876 RID: 39030
		// (get) Token: 0x0603C160 RID: 246112 RVA: 0x00F3C92C File Offset: 0x00F3AB2C
		public float Size
		{
			get
			{
				object value = this._value;
				if (value is GachaWeaponTransform)
				{
					return ((GachaWeaponTransform)value).Size;
				}
				value = this._value;
				if (value is SGachaWeaponTransform)
				{
					SGachaWeaponTransform sgachaWeaponTransform = (SGachaWeaponTransform)value;
					return sgachaWeaponTransform.Size;
				}
				return 0f;
			}
		}

		// Token: 0x17009877 RID: 39031
		// (get) Token: 0x0603C161 RID: 246113 RVA: 0x00F3C97C File Offset: 0x00F3AB7C
		public float RotateTime
		{
			get
			{
				object value = this._value;
				if (value is GachaWeaponTransform)
				{
					return (float)((GachaWeaponTransform)value).RotateTime;
				}
				value = this._value;
				if (value is SGachaWeaponTransform)
				{
					SGachaWeaponTransform sgachaWeaponTransform = (SGachaWeaponTransform)value;
					return sgachaWeaponTransform.RotateTime;
				}
				return 0f;
			}
		}

		// Token: 0x17009878 RID: 39032
		// (get) Token: 0x0603C162 RID: 246114 RVA: 0x00F3C9CC File Offset: 0x00F3ABCC
		public global::Vector Rotation
		{
			get
			{
				global::Vector vector = global::Vector.Create();
				object value = this._value;
				if (value is GachaWeaponTransform)
				{
					Aki.Config.Vector? rotation = ((GachaWeaponTransform)value).Rotation;
					if (rotation != null)
					{
						vector.Set((double)rotation.Value.X, (double)rotation.Value.Y, (double)rotation.Value.Z);
					}
				}
				else
				{
					value = this._value;
					if (value is SGachaWeaponTransform)
					{
						SGachaWeaponTransform sgachaWeaponTransform = (SGachaWeaponTransform)value;
						FVector rotation2 = sgachaWeaponTransform.Rotation;
						vector.Set((double)rotation2.X, (double)rotation2.Y, (double)rotation2.Z);
					}
				}
				return vector;
			}
		}

		// Token: 0x17009879 RID: 39033
		// (get) Token: 0x0603C163 RID: 246115 RVA: 0x00F3CA80 File Offset: 0x00F3AC80
		public global::Vector Location
		{
			get
			{
				global::Vector vector = global::Vector.Create();
				object value = this._value;
				if (value is GachaWeaponTransform)
				{
					Aki.Config.Vector? location = ((GachaWeaponTransform)value).Location;
					if (location != null)
					{
						vector.Set((double)location.Value.X, (double)location.Value.Y, (double)location.Value.Z);
					}
				}
				else
				{
					value = this._value;
					if (value is SGachaWeaponTransform)
					{
						SGachaWeaponTransform sgachaWeaponTransform = (SGachaWeaponTransform)value;
						FVector location2 = sgachaWeaponTransform.Location;
						vector.Set((double)location2.X, (double)location2.Y, (double)location2.Z);
					}
				}
				return vector;
			}
		}

		// Token: 0x1700987A RID: 39034
		// (get) Token: 0x0603C164 RID: 246116 RVA: 0x00F3CB34 File Offset: 0x00F3AD34
		public global::Vector AxisRotate
		{
			get
			{
				global::Vector vector = global::Vector.Create();
				object value = this._value;
				if (value is GachaWeaponTransform)
				{
					Aki.Config.Vector? axisRotate = ((GachaWeaponTransform)value).AxisRotate;
					if (axisRotate != null)
					{
						vector.Set((double)axisRotate.Value.X, (double)axisRotate.Value.Y, (double)axisRotate.Value.Z);
					}
				}
				else
				{
					value = this._value;
					if (value is SGachaWeaponTransform)
					{
						SGachaWeaponTransform sgachaWeaponTransform = (SGachaWeaponTransform)value;
						FVector axisRotate2 = sgachaWeaponTransform.AxisRotate;
						vector.Set((double)axisRotate2.X, (double)axisRotate2.Y, (double)axisRotate2.Z);
					}
				}
				return vector;
			}
		}

		// Token: 0x1700987B RID: 39035
		// (get) Token: 0x0603C165 RID: 246117 RVA: 0x00F3CBE8 File Offset: 0x00F3ADE8
		public global::Vector ScabbardOffset
		{
			get
			{
				global::Vector vector = global::Vector.Create();
				object value = this._value;
				if (value is GachaWeaponTransform)
				{
					Aki.Config.Vector? scabbardOffset = ((GachaWeaponTransform)value).ScabbardOffset;
					if (scabbardOffset != null)
					{
						vector.Set((double)scabbardOffset.Value.X, (double)scabbardOffset.Value.Y, (double)scabbardOffset.Value.Z);
					}
				}
				else
				{
					value = this._value;
					if (value is SGachaWeaponTransform)
					{
						SGachaWeaponTransform sgachaWeaponTransform = (SGachaWeaponTransform)value;
						FVector scabbardOffset2 = sgachaWeaponTransform.ScabbardOffset;
						vector.Set((double)scabbardOffset2.X, (double)scabbardOffset2.Y, (double)scabbardOffset2.Z);
					}
				}
				return vector;
			}
		}

		// Token: 0x04021BE2 RID: 138210
		[Nullable(2)]
		private readonly object _value;
	}
}
