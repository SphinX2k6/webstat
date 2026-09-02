using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardItem.Component.Bvb
{
	// Token: 0x02005563 RID: 21859
	public class BattleCardSpineItem : UiPanelBase
	{
		// Token: 0x06037B6E RID: 228206 RVA: 0x00E209AC File Offset: 0x00E1EBAC
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(USpineSkeletonAnimationComponent))
			};
		}

		// Token: 0x06037B6F RID: 228207 RVA: 0x00E209D0 File Offset: 0x00E1EBD0
		protected override UniTask OnBeforeStartAsync()
		{
			BattleCardSpineItem.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<BattleCardSpineItem.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037B70 RID: 228208 RVA: 0x00E20A14 File Offset: 0x00E1EC14
		private UniTask RefreshSpine(int configId)
		{
			BattleCardSpineItem.<RefreshSpine>d__4 <RefreshSpine>d__;
			<RefreshSpine>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshSpine>d__.<>4__this = this;
			<RefreshSpine>d__.configId = configId;
			<RefreshSpine>d__.<>1__state = -1;
			<RefreshSpine>d__.<>t__builder.Start<BattleCardSpineItem.<RefreshSpine>d__4>(ref <RefreshSpine>d__);
			return <RefreshSpine>d__.<>t__builder.Task;
		}

		// Token: 0x06037B71 RID: 228209 RVA: 0x00E20A60 File Offset: 0x00E1EC60
		public UniTask RefreshSpineById(int configId)
		{
			BattleCardSpineItem.<RefreshSpineById>d__5 <RefreshSpineById>d__;
			<RefreshSpineById>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshSpineById>d__.<>4__this = this;
			<RefreshSpineById>d__.configId = configId;
			<RefreshSpineById>d__.<>1__state = -1;
			<RefreshSpineById>d__.<>t__builder.Start<BattleCardSpineItem.<RefreshSpineById>d__5>(ref <RefreshSpineById>d__);
			return <RefreshSpineById>d__.<>t__builder.Task;
		}

		// Token: 0x06037B72 RID: 228210 RVA: 0x00E20AAC File Offset: 0x00E1ECAC
		[NullableContext(1)]
		public void PlaySpineAnim(string animName, bool isLoop)
		{
			USpineSkeletonAnimationComponent spine = base.GetSpine(0);
			if (spine != null && spine.IsValid())
			{
				UTrackEntry utrackEntry = spine.SetAnimation(0, animName, isLoop);
				if (animName == ECardSpineAnimation.Start.ToString() && utrackEntry != null)
				{
					utrackEntry.AnimationComplete.Add(delegate(UTrackEntry _)
					{
						this.PlaySpineAnim(ECardSpineAnimation.Idle.ToString(), true);
					});
				}
			}
		}

		// Token: 0x06037B73 RID: 228211 RVA: 0x00E20B08 File Offset: 0x00E1ED08
		public void SetCardConfigId(int cardConfigId)
		{
			this.CardConfigId = cardConfigId;
		}

		// Token: 0x0401FE8D RID: 130701
		protected int CardConfigId;

		// Token: 0x0200B506 RID: 46342
		private static class EBattleCardSpineItem
		{
			// Token: 0x04038096 RID: 229526
			public const int CardSpine = 0;
		}
	}
}
