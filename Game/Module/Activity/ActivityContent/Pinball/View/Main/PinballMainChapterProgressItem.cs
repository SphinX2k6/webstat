using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Main
{
	// Token: 0x020065F7 RID: 26103
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PinballMainChapterProgressItem : GridProxyAbstract<PinballLevelRecordData>
	{
		// Token: 0x06041363 RID: 267107 RVA: 0x010BA83C File Offset: 0x010B8A3C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06041364 RID: 267108 RVA: 0x010BA8A5 File Offset: 0x010B8AA5
		[NullableContext(1)]
		public override void Refresh(PinballLevelRecordData levelData, bool isSelected, int gridIndex)
		{
			base.GetSprite(1).SetUIActive(levelData.PassStatus == EPinballLevelPassStatus.Finished);
			base.GetSprite(0).SetUIActive(levelData.PassStatus == EPinballLevelPassStatus.Perfect);
		}

		// Token: 0x0200C5FD RID: 50685
		private enum EComponent
		{
			// Token: 0x0403CF24 RID: 249636
			SprPointPerfect,
			// Token: 0x0403CF25 RID: 249637
			SprPointFinish
		}
	}
}
