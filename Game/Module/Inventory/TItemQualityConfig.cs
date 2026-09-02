using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Inventory
{
	// Token: 0x02005B8B RID: 23435
	[NullableContext(2)]
	[Nullable(0)]
	public class TItemQualityConfig
	{
		// Token: 0x0603B410 RID: 242704 RVA: 0x00F0005B File Offset: 0x00EFE25B
		[NullableContext(1)]
		private TItemQualityConfig(object value)
		{
			this._value = value;
		}

		// Token: 0x0603B411 RID: 242705 RVA: 0x00F0006A File Offset: 0x00EFE26A
		[NullableContext(1)]
		public static implicit operator TItemQualityConfig(AbyssQuality value)
		{
			return new TItemQualityConfig(value);
		}

		// Token: 0x0603B412 RID: 242706 RVA: 0x00F00077 File Offset: 0x00EFE277
		[NullableContext(1)]
		public static implicit operator TItemQualityConfig(QualityInfo value)
		{
			return new TItemQualityConfig(value);
		}

		// Token: 0x0603B413 RID: 242707 RVA: 0x00F00084 File Offset: 0x00EFE284
		[NullableContext(1)]
		public static implicit operator TItemQualityConfig(HonamiStoryItemQuality value)
		{
			return new TItemQualityConfig(value);
		}

		// Token: 0x0603B414 RID: 242708 RVA: 0x00F00091 File Offset: 0x00EFE291
		public bool Is<T>()
		{
			return this._value is T;
		}

		// Token: 0x0603B415 RID: 242709 RVA: 0x00F000A4 File Offset: 0x00EFE2A4
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

		// Token: 0x0603B416 RID: 242710 RVA: 0x00F000D9 File Offset: 0x00EFE2D9
		[NullableContext(1)]
		public T AsClass<T>() where T : class
		{
			return this._value as T;
		}

		// Token: 0x17009752 RID: 38738
		// (get) Token: 0x0603B417 RID: 242711 RVA: 0x00F000EC File Offset: 0x00EFE2EC
		public string TextColor
		{
			get
			{
				object value = this._value;
				if (value is AbyssQuality)
				{
					return ((AbyssQuality)value).TextColor;
				}
				value = this._value;
				if (value is QualityInfo)
				{
					return ((QualityInfo)value).TextColor;
				}
				value = this._value;
				if (value is HonamiStoryItemQuality)
				{
					return ((HonamiStoryItemQuality)value).TextColor;
				}
				return null;
			}
		}

		// Token: 0x17009753 RID: 38739
		// (get) Token: 0x0603B418 RID: 242712 RVA: 0x00F00154 File Offset: 0x00EFE354
		public string AcquireQualityTexPath
		{
			get
			{
				object value = this._value;
				if (value is AbyssQuality)
				{
					return ((AbyssQuality)value).AcquireQualityTexPath;
				}
				value = this._value;
				if (value is QualityInfo)
				{
					return ((QualityInfo)value).AcquireQualityTexPath;
				}
				value = this._value;
				if (value is HonamiStoryItemQuality)
				{
					return ((HonamiStoryItemQuality)value).AcquireQualityTexPath;
				}
				return null;
			}
		}

		// Token: 0x17009754 RID: 38740
		// (get) Token: 0x0603B419 RID: 242713 RVA: 0x00F001BC File Offset: 0x00EFE3BC
		public string AcquireQualitySpritePath
		{
			get
			{
				object value = this._value;
				if (value is AbyssQuality)
				{
					return ((AbyssQuality)value).AcquireQualitySpritePath;
				}
				value = this._value;
				if (value is QualityInfo)
				{
					return ((QualityInfo)value).AcquireQualitySpritePath;
				}
				value = this._value;
				if (value is HonamiStoryItemQuality)
				{
					return ((HonamiStoryItemQuality)value).AcquireQualitySpritePath;
				}
				return null;
			}
		}

		// Token: 0x17009755 RID: 38741
		// (get) Token: 0x0603B41A RID: 242714 RVA: 0x00F00224 File Offset: 0x00EFE424
		public int? Id
		{
			get
			{
				object value = this._value;
				if (value is AbyssQuality)
				{
					return new int?(((AbyssQuality)value).Id);
				}
				value = this._value;
				if (value is QualityInfo)
				{
					return new int?(((QualityInfo)value).Id);
				}
				value = this._value;
				if (value is HonamiStoryItemQuality)
				{
					return new int?(((HonamiStoryItemQuality)value).Id);
				}
				return null;
			}
		}

		// Token: 0x17009756 RID: 38742
		// (get) Token: 0x0603B41B RID: 242715 RVA: 0x00F002A4 File Offset: 0x00EFE4A4
		public string AcquireNewItemQualityTexPath
		{
			get
			{
				object value = this._value;
				if (value is AbyssQuality)
				{
					return ((AbyssQuality)value).AcquireNewItemQualityTexPath;
				}
				value = this._value;
				if (value is QualityInfo)
				{
					return ((QualityInfo)value).AcquireNewItemQualityTexPath;
				}
				value = this._value;
				if (value is HonamiStoryItemQuality)
				{
					return ((HonamiStoryItemQuality)value).AcquireNewItemQualityTexPath;
				}
				return null;
			}
		}

		// Token: 0x17009757 RID: 38743
		// (get) Token: 0x0603B41C RID: 242716 RVA: 0x00F0030C File Offset: 0x00EFE50C
		public string TextureAcquireFlow
		{
			get
			{
				object value = this._value;
				if (value is AbyssQuality)
				{
					return ((AbyssQuality)value).TextureAcquireFlow;
				}
				value = this._value;
				if (value is QualityInfo)
				{
					return ((QualityInfo)value).TextureAcquireFlow;
				}
				value = this._value;
				if (value is HonamiStoryItemQuality)
				{
					return ((HonamiStoryItemQuality)value).TextureAcquireFlow;
				}
				return null;
			}
		}

		// Token: 0x17009758 RID: 38744
		// (get) Token: 0x0603B41D RID: 242717 RVA: 0x00F00374 File Offset: 0x00EFE574
		public string TextureAcquireBg
		{
			get
			{
				object value = this._value;
				if (value is AbyssQuality)
				{
					return ((AbyssQuality)value).TextureAcquireBg;
				}
				value = this._value;
				if (value is QualityInfo)
				{
					return ((QualityInfo)value).TextureAcquireBg;
				}
				value = this._value;
				if (value is HonamiStoryItemQuality)
				{
					return ((HonamiStoryItemQuality)value).TextureAcquireBg;
				}
				return null;
			}
		}

		// Token: 0x0402167B RID: 136827
		[Nullable(1)]
		private readonly object _value;
	}
}
