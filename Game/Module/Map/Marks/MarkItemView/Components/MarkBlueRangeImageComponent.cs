using System;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView.Components
{
	// Token: 0x020058A2 RID: 22690
	public class MarkBlueRangeImageComponent : MarkRangeImageComponent
	{
		// Token: 0x06039A82 RID: 236162 RVA: 0x00E9F1D0 File Offset: 0x00E9D3D0
		protected override UniTask OnBeforeStartAsync()
		{
			MarkBlueRangeImageComponent.<OnBeforeStartAsync>d__0 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MarkBlueRangeImageComponent.<OnBeforeStartAsync>d__0>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06039A83 RID: 236163 RVA: 0x00E9F214 File Offset: 0x00E9D414
		protected override void OnStart()
		{
			this.RootItem.SetAnchorOffset(Vector2D.ZeroVector);
			this.RootItem.SetUIItemScale(Vector.OneVector);
			UUISprite rangeSprite = base.RangeSprite;
			if (rangeSprite != null)
			{
				rangeSprite.SetUIActive(false);
			}
			UUITexture rangeImage = base.RangeImage;
			if (rangeImage == null)
			{
				return;
			}
			rangeImage.SetUIActive(true);
		}
	}
}
