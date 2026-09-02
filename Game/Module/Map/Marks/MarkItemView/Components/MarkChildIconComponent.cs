using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView.Components
{
	// Token: 0x020058A3 RID: 22691
	[NullableContext(2)]
	[Nullable(0)]
	public class MarkChildIconComponent : MarkPanelBase
	{
		// Token: 0x06039A85 RID: 236165 RVA: 0x00E9F26C File Offset: 0x00E9D46C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06039A86 RID: 236166 RVA: 0x00E9F2B4 File Offset: 0x00E9D4B4
		protected override void OnStart()
		{
			base.GetSprite(0).SetUIActive(false);
			this.UpdateIcon();
		}

		// Token: 0x06039A87 RID: 236167 RVA: 0x00E9F2CC File Offset: 0x00E9D4CC
		private void UpdateIcon()
		{
			if (string.IsNullOrEmpty(this.Path))
			{
				base.GetSprite(0).SetUIActive(false);
				return;
			}
			this.SetSpriteByPath(this.Path, base.GetSprite(0), false, null, delegate(bool success)
			{
				base.GetSprite(0).SetUIActive(true);
			});
		}

		// Token: 0x1700930E RID: 37646
		// (get) Token: 0x06039A88 RID: 236168 RVA: 0x00E9F31D File Offset: 0x00E9D51D
		// (set) Token: 0x06039A89 RID: 236169 RVA: 0x00E9F325 File Offset: 0x00E9D525
		public string Icon
		{
			get
			{
				return this.Path;
			}
			set
			{
				this.Path = value;
				if (base.GetSprite(0) != null)
				{
					this.UpdateIcon();
				}
			}
		}

		// Token: 0x04020AEE RID: 133870
		private string Path;

		// Token: 0x0200B8D5 RID: 47317
		[NullableContext(0)]
		public static class EChildComponents
		{
			// Token: 0x0403922B RID: 234027
			public const int Icon = 0;
		}
	}
}
