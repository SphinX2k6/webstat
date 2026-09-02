using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Activity.ActivityContent.MoonChasing;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Skin.Tab.Role
{
	// Token: 0x02004F67 RID: 20327
	public class RoleSkinItemContent : UiPanelBase
	{
		// Token: 0x060346DC RID: 214748 RVA: 0x00D1E115 File Offset: 0x00D1C315
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(USpineSkeletonAnimationComponent))
			};
		}

		// Token: 0x060346DD RID: 214749 RVA: 0x00D1E150 File Offset: 0x00D1C350
		protected override UniTask OnBeforeStartAsync()
		{
			RoleSkinItemContent.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoleSkinItemContent.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060346DE RID: 214750 RVA: 0x00D1E194 File Offset: 0x00D1C394
		public void Refresh(int recommendId)
		{
			RoleSkinRecommendItem roleSkinRecommendItem = this.RoleSkinRecommendItem;
			if (roleSkinRecommendItem != null)
			{
				roleSkinRecommendItem.Refresh(recommendId);
			}
			RoleSkinRecommendItem roleSkinRecommendItem2 = this.RoleSkinRecommendItem;
			if (roleSkinRecommendItem2 != null)
			{
				roleSkinRecommendItem2.SetActive(true);
			}
			base.GetSpine(1).SetAnimation(0, ESpineAnimation.Idle.ToString(), true);
		}

		// Token: 0x0401E34A RID: 123722
		[Nullable(2)]
		private RoleSkinRecommendItem RoleSkinRecommendItem;

		// Token: 0x0200AF7F RID: 44927
		private enum EContentComponent
		{
			// Token: 0x04036750 RID: 223056
			Content,
			// Token: 0x04036751 RID: 223057
			SpineTexture
		}
	}
}
