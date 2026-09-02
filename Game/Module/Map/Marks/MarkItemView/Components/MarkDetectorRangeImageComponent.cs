using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView.Components
{
	// Token: 0x020058A4 RID: 22692
	public class MarkDetectorRangeImageComponent : MarkPanelBase
	{
		// Token: 0x06039A8C RID: 236172 RVA: 0x00E9F354 File Offset: 0x00E9D554
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06039A8D RID: 236173 RVA: 0x00E9F39C File Offset: 0x00E9D59C
		protected override UniTask OnBeforeStartAsync()
		{
			MarkDetectorRangeImageComponent.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MarkDetectorRangeImageComponent.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06039A8E RID: 236174 RVA: 0x00E9F3DF File Offset: 0x00E9D5DF
		protected override void OnStart()
		{
			this.RootItem.SetAnchorOffset(Vector2D.ZeroVector);
			this.RootItem.SetUIItemScale(Vector.OneVector);
		}

		// Token: 0x06039A8F RID: 236175 RVA: 0x00E9F404 File Offset: 0x00E9D604
		protected override void OnBeforeShow()
		{
			UUIItem rootItem = base.GetRootItem();
			if (ObjectUtils.IsValid(rootItem))
			{
				rootItem.D_SetRelativeScale3D(this.TempRangeScale);
			}
		}

		// Token: 0x1700930F RID: 37647
		// (get) Token: 0x06039A90 RID: 236176 RVA: 0x00E9F42C File Offset: 0x00E9D62C
		[Nullable(2)]
		public UUITexture RangeImage
		{
			[NullableContext(2)]
			get
			{
				return base.GetTexture(0);
			}
		}

		// Token: 0x06039A91 RID: 236177 RVA: 0x00E9F438 File Offset: 0x00E9D638
		public void SetRangeScale(double x, double y, double z)
		{
			this.TempRangeScale.Set(x, y, z);
			if (base.IsShowOrShowing)
			{
				UUIItem rootItem = base.GetRootItem();
				if (ObjectUtils.IsValid(rootItem))
				{
					rootItem.D_SetRelativeScale3D(this.TempRangeScale);
				}
			}
		}

		// Token: 0x04020AEF RID: 133871
		private FVectorDouble TempRangeScale = new FVectorDouble();

		// Token: 0x0200B8D6 RID: 47318
		public static class EChildComponents
		{
			// Token: 0x0403922C RID: 234028
			public const int RangeImage = 0;
		}
	}
}
