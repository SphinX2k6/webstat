using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardItem.Component
{
	// Token: 0x02005558 RID: 21848
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class CardSpineComponent : CardComponentBase<ICardSpineComponentData>
	{
		// Token: 0x06037ACB RID: 228043 RVA: 0x00E1ECD4 File Offset: 0x00E1CED4
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(USpineSkeletonAnimationComponent))
			};
		}

		// Token: 0x06037ACC RID: 228044 RVA: 0x00E1ECF7 File Offset: 0x00E1CEF7
		protected override void OnStart()
		{
			this.SetActive(true);
		}

		// Token: 0x06037ACD RID: 228045 RVA: 0x00E1ED00 File Offset: 0x00E1CF00
		public override void Refresh(ICardSpineComponentData data)
		{
			CardSpineComponent.<>c__DisplayClass2_0 CS$<>8__locals1 = new CardSpineComponent.<>c__DisplayClass2_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.data = data;
			new UiAsyncTask("Refresh", delegate()
			{
				CardSpineComponent.<>c__DisplayClass2_0.<<Refresh>b__0>d <<Refresh>b__0>d;
				<<Refresh>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<Refresh>b__0>d.<>4__this = CS$<>8__locals1;
				<<Refresh>b__0>d.<>1__state = -1;
				<<Refresh>b__0>d.<>t__builder.Start<CardSpineComponent.<>c__DisplayClass2_0.<<Refresh>b__0>d>(ref <<Refresh>b__0>d);
				return <<Refresh>b__0>d.<>t__builder.Task;
			}, null).Run();
		}

		// Token: 0x06037ACE RID: 228046 RVA: 0x00E1ED40 File Offset: 0x00E1CF40
		public UniTask RefreshAsync(ICardSpineComponentData data)
		{
			CardSpineComponent.<RefreshAsync>d__3 <RefreshAsync>d__;
			<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshAsync>d__.<>4__this = this;
			<RefreshAsync>d__.data = data;
			<RefreshAsync>d__.<>1__state = -1;
			<RefreshAsync>d__.<>t__builder.Start<CardSpineComponent.<RefreshAsync>d__3>(ref <RefreshAsync>d__);
			return <RefreshAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0200B4DF RID: 46303
		[NullableContext(0)]
		private static class EComponents
		{
			// Token: 0x04037FCC RID: 229324
			public const int CardSpine = 0;
		}
	}
}
