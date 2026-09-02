using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorFight
{
	// Token: 0x020066E4 RID: 26340
	public class MotorFightItemTypeItem : SyncGridProxyAbstract<MotorFightItemType>
	{
		// Token: 0x06041C20 RID: 269344 RVA: 0x010DDF24 File Offset: 0x010DC124
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06041C21 RID: 269345 RVA: 0x010DDFB0 File Offset: 0x010DC1B0
		public override void Refresh(MotorFightItemType data)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), data.Name, Array.Empty<object>());
			this.SetSpriteByPath(data.Icon, base.GetSprite(1), false, null, null);
			Tuple<int, int> tuple = this.GetUnlockNum(data.Id);
			int item = tuple.Item1;
			int item2 = tuple.Item2;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "PrefabTextItem_3218283778_Text", new <>z__ReadOnlyArray<object>(new object[]
			{
				item,
				item2
			}));
		}

		// Token: 0x04024B00 RID: 150272
		[Nullable(1)]
		public Func<int, Tuple<int, int>> GetUnlockNum = (int type) => new Tuple<int, int>(0, 0);

		// Token: 0x0200C71B RID: 50971
		private class EComponents
		{
			// Token: 0x0403D4CC RID: 251084
			public const int TextTypeName = 0;

			// Token: 0x0403D4CD RID: 251085
			public const int SpriteIcon = 1;

			// Token: 0x0403D4CE RID: 251086
			public const int TextUnlockNum = 2;
		}
	}
}
