using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Level
{
	// Token: 0x02006604 RID: 26116
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PinballLevelInfoStarItem : GridProxyAbstract<IPinballLevelStarData>
	{
		// Token: 0x06041423 RID: 267299 RVA: 0x010BE1A8 File Offset: 0x010BC3A8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06041424 RID: 267300 RVA: 0x010BE214 File Offset: 0x010BC414
		[NullableContext(1)]
		public override void Refresh(IPinballLevelStarData data, bool isSelected, int gridIndex)
		{
			string textStringId = data.ConfigConditionDesc ?? "";
			int valueOrDefault = data.ConfigTargetValue.GetValueOrDefault();
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textStringId, new <>z__ReadOnlySingleElementList<object>(valueOrDefault));
			UUISprite sprite = base.GetSprite(0);
			if (sprite == null)
			{
				return;
			}
			sprite.SetUIActive(data.Passed);
		}

		// Token: 0x0200C626 RID: 50726
		private enum EComponent
		{
			// Token: 0x0403CFEC RID: 249836
			SprLight,
			// Token: 0x0403CFED RID: 249837
			TxtConditionDesc
		}
	}
}
