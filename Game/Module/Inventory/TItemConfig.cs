using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Inventory
{
	// Token: 0x02005B8A RID: 23434
	[NullableContext(1)]
	[Nullable(0)]
	public class TItemConfig
	{
		// Token: 0x0603B3F8 RID: 242680 RVA: 0x00EFFE26 File Offset: 0x00EFE026
		private TItemConfig(object value)
		{
			this._value = value;
		}

		// Token: 0x0603B3F9 RID: 242681 RVA: 0x00EFFE35 File Offset: 0x00EFE035
		public static implicit operator TItemConfig(AbyssItem value)
		{
			return new TItemConfig(value);
		}

		// Token: 0x0603B3FA RID: 242682 RVA: 0x00EFFE42 File Offset: 0x00EFE042
		public static implicit operator TItemConfig(BackgroundCard value)
		{
			return new TItemConfig(value);
		}

		// Token: 0x0603B3FB RID: 242683 RVA: 0x00EFFE4F File Offset: 0x00EFE04F
		public static implicit operator TItemConfig(CalabashSkin value)
		{
			return new TItemConfig(value);
		}

		// Token: 0x0603B3FC RID: 242684 RVA: 0x00EFFE5C File Offset: 0x00EFE05C
		public static implicit operator TItemConfig(FlySkinConfig value)
		{
			return new TItemConfig(value);
		}

		// Token: 0x0603B3FD RID: 242685 RVA: 0x00EFFE69 File Offset: 0x00EFE069
		public static implicit operator TItemConfig(ItemInfo value)
		{
			return new TItemConfig(value);
		}

		// Token: 0x0603B3FE RID: 242686 RVA: 0x00EFFE76 File Offset: 0x00EFE076
		public static implicit operator TItemConfig(PhantomBattleBadge value)
		{
			return new TItemConfig(value);
		}

		// Token: 0x0603B3FF RID: 242687 RVA: 0x00EFFE83 File Offset: 0x00EFE083
		public static implicit operator TItemConfig(PhantomBattleCard value)
		{
			return new TItemConfig(value);
		}

		// Token: 0x0603B400 RID: 242688 RVA: 0x00EFFE90 File Offset: 0x00EFE090
		public static implicit operator TItemConfig(PhantomItem value)
		{
			return new TItemConfig(value);
		}

		// Token: 0x0603B401 RID: 242689 RVA: 0x00EFFE9D File Offset: 0x00EFE09D
		public static implicit operator TItemConfig(PlayerHeadRe value)
		{
			return new TItemConfig(value);
		}

		// Token: 0x0603B402 RID: 242690 RVA: 0x00EFFEAA File Offset: 0x00EFE0AA
		public static implicit operator TItemConfig(PreviewItem value)
		{
			return new TItemConfig(value);
		}

		// Token: 0x0603B403 RID: 242691 RVA: 0x00EFFEB7 File Offset: 0x00EFE0B7
		public static implicit operator TItemConfig(RogueCurrency value)
		{
			return new TItemConfig(value);
		}

		// Token: 0x0603B404 RID: 242692 RVA: 0x00EFFEC4 File Offset: 0x00EFE0C4
		public static implicit operator TItemConfig(RogueResCurrency value)
		{
			return new TItemConfig(value);
		}

		// Token: 0x0603B405 RID: 242693 RVA: 0x00EFFED1 File Offset: 0x00EFE0D1
		public static implicit operator TItemConfig(RoleInfo value)
		{
			return new TItemConfig(value);
		}

		// Token: 0x0603B406 RID: 242694 RVA: 0x00EFFEDE File Offset: 0x00EFE0DE
		public static implicit operator TItemConfig(RoleSkin value)
		{
			return new TItemConfig(value);
		}

		// Token: 0x0603B407 RID: 242695 RVA: 0x00EFFEEB File Offset: 0x00EFE0EB
		public static implicit operator TItemConfig(WeaponConf value)
		{
			return new TItemConfig(value);
		}

		// Token: 0x0603B408 RID: 242696 RVA: 0x00EFFEF8 File Offset: 0x00EFE0F8
		public static implicit operator TItemConfig(WeaponSkin value)
		{
			return new TItemConfig(value);
		}

		// Token: 0x0603B409 RID: 242697 RVA: 0x00EFFF05 File Offset: 0x00EFE105
		public static implicit operator TItemConfig(Ornament value)
		{
			return new TItemConfig(value);
		}

		// Token: 0x0603B40A RID: 242698 RVA: 0x00EFFF12 File Offset: 0x00EFE112
		[NullableContext(2)]
		public bool Is<T>()
		{
			return this._value is T;
		}

		// Token: 0x0603B40B RID: 242699 RVA: 0x00EFFF24 File Offset: 0x00EFE124
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

		// Token: 0x0603B40C RID: 242700 RVA: 0x00EFFF59 File Offset: 0x00EFE159
		public T AsClass<T>() where T : class
		{
			return this._value as T;
		}

		// Token: 0x1700974F RID: 38735
		[Nullable(2)]
		public object this[string propertyName]
		{
			[return: Nullable(2)]
			get
			{
				PropertyInfo property = this._value.GetType().GetProperty(propertyName);
				if (property == null)
				{
					return null;
				}
				return property.GetValue(this._value);
			}
		}

		// Token: 0x17009750 RID: 38736
		// (get) Token: 0x0603B40E RID: 242702 RVA: 0x00EFFF90 File Offset: 0x00EFE190
		public int[] ShowTypes
		{
			get
			{
				object value = this._value;
				if (value is ItemInfo)
				{
					return ((ItemInfo)value).GetShowTypesArray();
				}
				value = this._value;
				if (value is PreviewItem)
				{
					return ((PreviewItem)value).GetShowTypesArray();
				}
				return Array.Empty<int>();
			}
		}

		// Token: 0x17009751 RID: 38737
		// (get) Token: 0x0603B40F RID: 242703 RVA: 0x00EFFFE0 File Offset: 0x00EFE1E0
		public Dictionary<int, int> Parameters
		{
			get
			{
				object value = this._value;
				if (value is ItemInfo)
				{
					ItemInfo itemInfo = (ItemInfo)value;
					Dictionary<int, int> dictionary = new Dictionary<int, int>();
					for (int i = 0; i < itemInfo.ParametersLength; i++)
					{
						DicIntInt? dicIntInt = itemInfo.Parameters(i);
						if (dicIntInt != null)
						{
							dictionary[dicIntInt.Value.Key] = dicIntInt.Value.Value;
						}
					}
					return dictionary;
				}
				return new Dictionary<int, int>();
			}
		}

		// Token: 0x0402167A RID: 136826
		private readonly object _value;
	}
}
