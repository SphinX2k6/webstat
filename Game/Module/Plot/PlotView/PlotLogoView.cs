using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.PlotView
{
	// Token: 0x020053BD RID: 21437
	public class PlotLogoView : UiViewBase
	{
		// Token: 0x06036A98 RID: 223896 RVA: 0x00DD95EC File Offset: 0x00DD77EC
		[NullableContext(1)]
		public PlotLogoView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06036A99 RID: 223897 RVA: 0x00DD95F8 File Offset: 0x00DD77F8
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

		// Token: 0x06036A9A RID: 223898 RVA: 0x00DD9640 File Offset: 0x00DD7840
		protected override UniTask OnCreateAsync()
		{
			PlotLogoView.<OnCreateAsync>d__4 <OnCreateAsync>d__;
			<OnCreateAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnCreateAsync>d__.<>4__this = this;
			<OnCreateAsync>d__.<>1__state = -1;
			<OnCreateAsync>d__.<>t__builder.Start<PlotLogoView.<OnCreateAsync>d__4>(ref <OnCreateAsync>d__);
			return <OnCreateAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036A9B RID: 223899 RVA: 0x00DD9683 File Offset: 0x00DD7883
		protected override void OnBeforeShow()
		{
			if (this.Texture != null)
			{
				UUITexture texture = base.GetTexture(0);
				if (texture == null)
				{
					return;
				}
				texture.SetTexture(this.Texture);
			}
		}

		// Token: 0x0401F7CA RID: 128970
		[Nullable(2)]
		private UTexture Texture;

		// Token: 0x0200B327 RID: 45863
		private static class EChildComp
		{
			// Token: 0x04037806 RID: 227334
			public const int Logo = 0;
		}
	}
}
