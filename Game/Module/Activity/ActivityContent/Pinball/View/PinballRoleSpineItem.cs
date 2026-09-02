using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View
{
	// Token: 0x0200659F RID: 26015
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballRoleSpineItem : UiPanelBase
	{
		// Token: 0x06040FFF RID: 266239 RVA: 0x010ADBD4 File Offset: 0x010ABDD4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(USpineSkeletonAnimationComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(USpineSkeletonAnimationComponent));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06041000 RID: 266240 RVA: 0x010ADC40 File Offset: 0x010ABE40
		public void RefreshRole(int roleId, string spineAnim = "Idle_Fight", bool bLoop = true)
		{
			PinballRoleSpineItem.<>c__DisplayClass7_0 CS$<>8__locals1 = new PinballRoleSpineItem.<>c__DisplayClass7_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.roleId = roleId;
			CS$<>8__locals1.spineAnim = spineAnim;
			CS$<>8__locals1.bLoop = bLoop;
			UiAsyncTask task = new UiAsyncTask("PinballRoleSpineItem", delegate()
			{
				PinballRoleSpineItem.<>c__DisplayClass7_0.<<RefreshRole>b__0>d <<RefreshRole>b__0>d;
				<<RefreshRole>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<RefreshRole>b__0>d.<>4__this = CS$<>8__locals1;
				<<RefreshRole>b__0>d.<>1__state = -1;
				<<RefreshRole>b__0>d.<>t__builder.Start<PinballRoleSpineItem.<>c__DisplayClass7_0.<<RefreshRole>b__0>d>(ref <<RefreshRole>b__0>d);
				return <<RefreshRole>b__0>d.<>t__builder.Task;
			}, null);
			base.RunAsyncTask(task).Forget();
		}

		// Token: 0x06041001 RID: 266241 RVA: 0x010ADC94 File Offset: 0x010ABE94
		public UniTask RefreshRoleAsync(int roleId, string spineAnim = "Idle_Fight", bool bLoop = true)
		{
			PinballRoleSpineItem.<RefreshRoleAsync>d__8 <RefreshRoleAsync>d__;
			<RefreshRoleAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshRoleAsync>d__.<>4__this = this;
			<RefreshRoleAsync>d__.roleId = roleId;
			<RefreshRoleAsync>d__.spineAnim = spineAnim;
			<RefreshRoleAsync>d__.bLoop = bLoop;
			<RefreshRoleAsync>d__.<>1__state = -1;
			<RefreshRoleAsync>d__.<>t__builder.Start<PinballRoleSpineItem.<RefreshRoleAsync>d__8>(ref <RefreshRoleAsync>d__);
			return <RefreshRoleAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041002 RID: 266242 RVA: 0x010ADCF0 File Offset: 0x010ABEF0
		[NullableContext(0)]
		public UniTask<bool> LoadRoleSpineAsync(int roleId)
		{
			PinballRoleSpineItem.<LoadRoleSpineAsync>d__9 <LoadRoleSpineAsync>d__;
			<LoadRoleSpineAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<LoadRoleSpineAsync>d__.<>4__this = this;
			<LoadRoleSpineAsync>d__.roleId = roleId;
			<LoadRoleSpineAsync>d__.<>1__state = -1;
			<LoadRoleSpineAsync>d__.<>t__builder.Start<PinballRoleSpineItem.<LoadRoleSpineAsync>d__9>(ref <LoadRoleSpineAsync>d__);
			return <LoadRoleSpineAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041003 RID: 266243 RVA: 0x010ADD3B File Offset: 0x010ABF3B
		public void CancelLoadRoleSpine()
		{
			if (this.SpineAtlasPromise != null)
			{
				this.SpineAtlasPromise.CancelAsyncLoad();
				this.SpineAtlasPromise = null;
			}
			if (this.SpineSkeletonDataPromise != null)
			{
				this.SpineSkeletonDataPromise.CancelAsyncLoad();
				this.SpineSkeletonDataPromise = null;
			}
		}

		// Token: 0x06041004 RID: 266244 RVA: 0x010ADD71 File Offset: 0x010ABF71
		public void SetSpineAnim(string anim, bool bLoop = true)
		{
			if (this.IsLoading)
			{
				return;
			}
			base.GetSpine(0).SetAnimation(0, anim, bLoop);
			base.GetSpine(1).SetAnimation(0, anim, bLoop);
		}

		// Token: 0x04024725 RID: 149285
		protected int RoleId;

		// Token: 0x04024726 RID: 149286
		protected string RoleSpineAnim;

		// Token: 0x04024727 RID: 149287
		private bool IsLoading;

		// Token: 0x04024728 RID: 149288
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private LoadAsyncPromise<USpineAtlasAsset> SpineAtlasPromise;

		// Token: 0x04024729 RID: 149289
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private LoadAsyncPromise<USpineSkeletonDataAsset> SpineSkeletonDataPromise;

		// Token: 0x0200C597 RID: 50583
		[NullableContext(0)]
		private enum EComponent
		{
			// Token: 0x0403CCFE RID: 249086
			RoleShadowSpine,
			// Token: 0x0403CCFF RID: 249087
			RoleSpine
		}
	}
}
