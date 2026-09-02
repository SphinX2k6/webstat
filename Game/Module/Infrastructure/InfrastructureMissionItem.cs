using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Infrastructure
{
	// Token: 0x02005C5E RID: 23646
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class InfrastructureMissionItem : GridProxyAbstract<InfrastructureMissionItemData>
	{
		// Token: 0x0603BBE9 RID: 244713 RVA: 0x00F23004 File Offset: 0x00F21204
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603BBEA RID: 244714 RVA: 0x00F230D0 File Offset: 0x00F212D0
		[NullableContext(1)]
		public override void Refresh(InfrastructureMissionItemData data, bool isSelected, int gridIndex)
		{
			base.GetText(2).SetUIActive(true);
			base.GetText(2).ShowTextNew(data.DesText);
			base.GetSprite(1).SetUIActive(data.CurrentCount >= data.MaxCount);
			UUIText text = base.GetText(3);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(data.CurrentCount);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(data.MaxCount);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			if (data.CurrentCount >= data.MaxCount)
			{
				base.GetText(3).SetColor(FColor.FromHex("#d5ec20"));
				base.GetText(2).SetColor(FColor.FromHex("#d5ec20"));
				return;
			}
			base.GetText(3).SetColor(FColor.FromHex("#ffffff"));
			base.GetText(2).SetColor(FColor.FromHex("#ffffff"));
		}

		// Token: 0x0200BCE9 RID: 48361
		private class EChildType
		{
			// Token: 0x0403A346 RID: 238406
			public const int SpriteCompleteIcon = 0;

			// Token: 0x0403A347 RID: 238407
			public const int SpriteDone = 1;

			// Token: 0x0403A348 RID: 238408
			public const int TextName = 2;

			// Token: 0x0403A349 RID: 238409
			public const int TextNum = 3;

			// Token: 0x0403A34A RID: 238410
			public const int SpriteLine = 4;
		}
	}
}
