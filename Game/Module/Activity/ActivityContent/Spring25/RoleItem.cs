using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Spring25
{
	// Token: 0x02006362 RID: 25442
	[NullableContext(1)]
	[Nullable(0)]
	public class RoleItem : UiPanelBase
	{
		// Token: 0x0603FE0B RID: 261643 RVA: 0x01062B8C File Offset: 0x01060D8C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(USpineSkeletonAnimationComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(USpineSkeletonAnimationComponent));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603FE0C RID: 261644 RVA: 0x01062C38 File Offset: 0x01060E38
		public UniTask RefreshExternalByDataAsync(Spring25DialogueSpineData data)
		{
			RoleItem.<RefreshExternalByDataAsync>d__2 <RefreshExternalByDataAsync>d__;
			<RefreshExternalByDataAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshExternalByDataAsync>d__.<>4__this = this;
			<RefreshExternalByDataAsync>d__.data = data;
			<RefreshExternalByDataAsync>d__.<>1__state = -1;
			<RefreshExternalByDataAsync>d__.<>t__builder.Start<RoleItem.<RefreshExternalByDataAsync>d__2>(ref <RefreshExternalByDataAsync>d__);
			return <RefreshExternalByDataAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603FE0D RID: 261645 RVA: 0x01062C83 File Offset: 0x01060E83
		public void RefreshText(string textId)
		{
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(2), textId, Array.Empty<object>());
		}

		// Token: 0x0603FE0E RID: 261646 RVA: 0x01062C9C File Offset: 0x01060E9C
		public void RefreshAnim(string animName)
		{
			base.GetSpine(0).SetAnimation(0, animName, true);
		}

		// Token: 0x0200C3C4 RID: 50116
		[NullableContext(0)]
		private class ERoleComponent
		{
			// Token: 0x0403C4CD RID: 246989
			public const int RoleSpine = 0;

			// Token: 0x0403C4CE RID: 246990
			public const int ChatItem = 1;

			// Token: 0x0403C4CF RID: 246991
			public const int ChatText = 2;

			// Token: 0x0403C4D0 RID: 246992
			public const int RoleSpinAnother = 3;
		}
	}
}
