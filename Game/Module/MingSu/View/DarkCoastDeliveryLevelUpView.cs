using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.MingSu.View
{
	// Token: 0x0200573E RID: 22334
	public class DarkCoastDeliveryLevelUpView : UiViewBase
	{
		// Token: 0x06038D83 RID: 232835 RVA: 0x00E6611B File Offset: 0x00E6431B
		[NullableContext(1)]
		public DarkCoastDeliveryLevelUpView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06038D84 RID: 232836 RVA: 0x00E66124 File Offset: 0x00E64324
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUITexture)),
				new ValueTuple<int, Type>(2, typeof(UUITexture)),
				new ValueTuple<int, Type>(3, typeof(UUIHorizontalLayout))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnClickCloseBtn))
			};
		}

		// Token: 0x06038D85 RID: 232837 RVA: 0x00E661B8 File Offset: 0x00E643B8
		protected override UniTask OnBeforeStartAsync()
		{
			DarkCoastDeliveryLevelUpView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<DarkCoastDeliveryLevelUpView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06038D86 RID: 232838 RVA: 0x00E661FB File Offset: 0x00E643FB
		[NullableContext(1)]
		private DarkCoastDeliveryLevelUpItem InitLevelUpItem()
		{
			return new DarkCoastDeliveryLevelUpItem();
		}

		// Token: 0x06038D87 RID: 232839 RVA: 0x00E66202 File Offset: 0x00E64402
		private void OnClickCloseBtn()
		{
			base.CloseMe(null);
		}

		// Token: 0x040205FA RID: 132602
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<DarkCoastDeliveryLevelUpItem, DarkCoastDeliveryLevelData> VisionLayout;

		// Token: 0x0200B7EA RID: 47082
		private static class EComponent
		{
			// Token: 0x04038E18 RID: 232984
			public const int CloseBtn = 0;

			// Token: 0x04038E19 RID: 232985
			public const int PreLevelTexture = 1;

			// Token: 0x04038E1A RID: 232986
			public const int CurLevelTexture = 2;

			// Token: 0x04038E1B RID: 232987
			public const int VisionLayout = 3;
		}
	}
}
