using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Activity.ActivityContent.MoonChasing;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Skin.Tab.Motor
{
	// Token: 0x02004F6B RID: 20331
	public class MotorSkinItemContent : UiPanelBase
	{
		// Token: 0x060346FA RID: 214778 RVA: 0x00D1EB56 File Offset: 0x00D1CD56
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(USpineSkeletonAnimationComponent))
			};
		}

		// Token: 0x060346FB RID: 214779 RVA: 0x00D1EB90 File Offset: 0x00D1CD90
		protected override UniTask OnBeforeStartAsync()
		{
			MotorSkinItemContent.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MotorSkinItemContent.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060346FC RID: 214780 RVA: 0x00D1EBD4 File Offset: 0x00D1CDD4
		public void Refresh(int recommendId)
		{
			MotorSkinRecommendItem motorSkinRecommendItem = this.MotorSkinRecommendItem;
			if (motorSkinRecommendItem != null)
			{
				motorSkinRecommendItem.Refresh(recommendId);
			}
			MotorSkinRecommendItem motorSkinRecommendItem2 = this.MotorSkinRecommendItem;
			if (motorSkinRecommendItem2 != null)
			{
				motorSkinRecommendItem2.SetActive(true);
			}
			base.GetSpine(1).SetAnimation(0, ESpineAnimation.Idle.ToString(), true);
		}

		// Token: 0x0401E353 RID: 123731
		[Nullable(2)]
		private MotorSkinRecommendItem MotorSkinRecommendItem;

		// Token: 0x0200AF85 RID: 44933
		private enum EContentComponent
		{
			// Token: 0x0403676F RID: 223087
			Content,
			// Token: 0x04036770 RID: 223088
			SpineTexture
		}
	}
}
