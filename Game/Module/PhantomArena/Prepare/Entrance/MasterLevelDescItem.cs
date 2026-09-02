using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.Entrance
{
	// Token: 0x020054DD RID: 21725
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class MasterLevelDescItem : GridProxyAbstract<MasterLevelDescData>
	{
		// Token: 0x0603759F RID: 226719 RVA: 0x00E0BC10 File Offset: 0x00E09E10
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUISprite)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUISprite))
			};
		}

		// Token: 0x060375A0 RID: 226720 RVA: 0x00E0BC6C File Offset: 0x00E09E6C
		[NullableContext(1)]
		public override void Refresh(MasterLevelDescData data, bool isSelected, int gridIndex)
		{
			base.GetSprite(0).SetUIActive(data.IsDone);
			base.GetSprite(2).SetUIActive(!data.IsDone);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.StringId, Array.Empty<object>());
		}

		// Token: 0x0200B457 RID: 46167
		private class EDescComponent
		{
			// Token: 0x04037D13 RID: 228627
			public const int SpriteDone = 0;

			// Token: 0x04037D14 RID: 228628
			public const int TextDesc = 1;

			// Token: 0x04037D15 RID: 228629
			public const int SpritePending = 2;
		}
	}
}
