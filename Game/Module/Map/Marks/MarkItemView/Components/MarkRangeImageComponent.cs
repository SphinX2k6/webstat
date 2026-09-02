using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView.Components
{
	// Token: 0x020058AA RID: 22698
	[NullableContext(2)]
	[Nullable(0)]
	public class MarkRangeImageComponent : MarkPanelBase
	{
		// Token: 0x06039AB9 RID: 236217 RVA: 0x00E9F808 File Offset: 0x00E9DA08
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06039ABA RID: 236218 RVA: 0x00E9F894 File Offset: 0x00E9DA94
		protected override UniTask OnBeforeStartAsync()
		{
			MarkRangeImageComponent.<OnBeforeStartAsync>d__2 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MarkRangeImageComponent.<OnBeforeStartAsync>d__2>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06039ABB RID: 236219 RVA: 0x00E9F8D7 File Offset: 0x00E9DAD7
		protected override void OnStart()
		{
			this.RootItem.SetAnchorOffset(Vector2D.ZeroVector);
			this.RootItem.SetUIItemScale(Vector.OneVector);
			this.RangeSprite.SetUIActive(true);
			this.RangeImage.SetUIActive(false);
		}

		// Token: 0x1700931B RID: 37659
		// (get) Token: 0x06039ABC RID: 236220 RVA: 0x00E9F911 File Offset: 0x00E9DB11
		public UUITexture RangeImage
		{
			get
			{
				return base.GetTexture(0);
			}
		}

		// Token: 0x1700931C RID: 37660
		// (get) Token: 0x06039ABD RID: 236221 RVA: 0x00E9F91A File Offset: 0x00E9DB1A
		public UUIItem RangeArea
		{
			get
			{
				return base.GetItem(1);
			}
		}

		// Token: 0x1700931D RID: 37661
		// (get) Token: 0x06039ABE RID: 236222 RVA: 0x00E9F923 File Offset: 0x00E9DB23
		public UUISprite RangeSprite
		{
			get
			{
				return base.GetSprite(2);
			}
		}

		// Token: 0x0200B8DB RID: 47323
		[NullableContext(0)]
		public static class EChildComponents
		{
			// Token: 0x04039234 RID: 234036
			public const int RangeImage = 0;

			// Token: 0x04039235 RID: 234037
			public const int RangeArea = 1;

			// Token: 0x04039236 RID: 234038
			public const int RangeAreaSprite = 2;
		}
	}
}
