using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Map.MapDefine;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView.Components
{
	// Token: 0x020058A5 RID: 22693
	public class MarkGravityReverseIconComponent : MarkPanelBase
	{
		// Token: 0x06039A93 RID: 236179 RVA: 0x00E9F48C File Offset: 0x00E9D68C
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

		// Token: 0x06039A94 RID: 236180 RVA: 0x00E9F4D4 File Offset: 0x00E9D6D4
		protected override void OnStart()
		{
			base.GetSprite(0).SetUIActive(false);
			this.UpdateIcon();
		}

		// Token: 0x06039A95 RID: 236181 RVA: 0x00E9F4EC File Offset: 0x00E9D6EC
		private void UpdateIcon()
		{
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath((this.Gravity == EMapGravityDirection.Down) ? "SP_OverviewDown" : "SP_OverviewUp");
			this.SetSpriteByPath(resourcePath, base.GetSprite(0), false, null, delegate(bool success)
			{
				base.GetSprite(0).SetUIActive(true);
			});
		}

		// Token: 0x17009310 RID: 37648
		// (get) Token: 0x06039A96 RID: 236182 RVA: 0x00E9F53D File Offset: 0x00E9D73D
		// (set) Token: 0x06039A97 RID: 236183 RVA: 0x00E9F545 File Offset: 0x00E9D745
		public EMapGravityDirection Gravity
		{
			get
			{
				return this.GravityDirection;
			}
			set
			{
				this.GravityDirection = value;
				if (base.GetSprite(0) != null)
				{
					this.UpdateIcon();
				}
			}
		}

		// Token: 0x04020AF0 RID: 133872
		private EMapGravityDirection GravityDirection = EMapGravityDirection.Down;

		// Token: 0x0200B8D8 RID: 47320
		public static class EComponents
		{
			// Token: 0x04039231 RID: 234033
			public const int Icon = 0;
		}
	}
}
