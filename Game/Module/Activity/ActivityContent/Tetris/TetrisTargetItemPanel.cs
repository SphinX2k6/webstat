using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x020062CD RID: 25293
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class TetrisTargetItemPanel : GridProxyAbstract<ITetrisTargetData>
	{
		// Token: 0x0603FA0D RID: 260621 RVA: 0x0104ED68 File Offset: 0x0104CF68
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUISprite)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIText))
			};
		}

		// Token: 0x0603FA0E RID: 260622 RVA: 0x0104EDC4 File Offset: 0x0104CFC4
		public override void Refresh(ITetrisTargetData data, bool isSelected, int gridIndex)
		{
			this.SetSpriteByPath(data.Icon, base.GetSprite(0), false, null, null);
			base.GetText(1).SetText(data.Num.ToString(), true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), data.Tip, Array.Empty<object>());
		}
	}
}
