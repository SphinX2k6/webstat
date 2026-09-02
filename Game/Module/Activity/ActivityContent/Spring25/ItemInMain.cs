using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Spring25
{
	// Token: 0x0200636A RID: 25450
	internal class ItemInMain : UiPanelBase
	{
		// Token: 0x0603FE73 RID: 261747 RVA: 0x01064452 File Offset: 0x01062652
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUITexture)),
				new ValueTuple<int, Type>(1, typeof(UUITexture))
			};
		}

		// Token: 0x0603FE74 RID: 261748 RVA: 0x0106448C File Offset: 0x0106268C
		protected override UniTask OnBeforeStartAsync()
		{
			ItemInMain.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<ItemInMain.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603FE75 RID: 261749 RVA: 0x010644D0 File Offset: 0x010626D0
		public UniTask RefreshByInvitedAsync(bool isInvited, bool isNew = false)
		{
			ItemInMain.<RefreshByInvitedAsync>d__5 <RefreshByInvitedAsync>d__;
			<RefreshByInvitedAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshByInvitedAsync>d__.<>4__this = this;
			<RefreshByInvitedAsync>d__.isInvited = isInvited;
			<RefreshByInvitedAsync>d__.isNew = isNew;
			<RefreshByInvitedAsync>d__.<>1__state = -1;
			<RefreshByInvitedAsync>d__.<>t__builder.Start<ItemInMain.<RefreshByInvitedAsync>d__5>(ref <RefreshByInvitedAsync>d__);
			return <RefreshByInvitedAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603FE76 RID: 261750 RVA: 0x01064524 File Offset: 0x01062724
		private UniTask PlayUnlockAnimAsync()
		{
			ItemInMain.<PlayUnlockAnimAsync>d__6 <PlayUnlockAnimAsync>d__;
			<PlayUnlockAnimAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayUnlockAnimAsync>d__.<>4__this = this;
			<PlayUnlockAnimAsync>d__.<>1__state = -1;
			<PlayUnlockAnimAsync>d__.<>t__builder.Start<ItemInMain.<PlayUnlockAnimAsync>d__6>(ref <PlayUnlockAnimAsync>d__);
			return <PlayUnlockAnimAsync>d__.<>t__builder.Task;
		}

		// Token: 0x04023E80 RID: 147072
		[Nullable(1)]
		private UiSequencePlayer Player;

		// Token: 0x0200C3D7 RID: 50135
		private static class EItemComponent
		{
			// Token: 0x0403C53C RID: 247100
			public const int LockTexture = 0;

			// Token: 0x0403C53D RID: 247101
			public const int SelfTexture = 1;
		}
	}
}
