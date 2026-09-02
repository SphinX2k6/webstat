using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.WheelTower.View.Season
{
	// Token: 0x0200623E RID: 25150
	[NullableContext(1)]
	[Nullable(0)]
	public class WheelTowerSeasonBgItem : UiPanelBase
	{
		// Token: 0x0603F6B6 RID: 259766 RVA: 0x0104188C File Offset: 0x0103FA8C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(USpineSkeletonAnimationComponent));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603F6B7 RID: 259767 RVA: 0x010418F8 File Offset: 0x0103FAF8
		protected override void OnStart()
		{
			this.SequencePlayer = new UiSequencePlayer(this.RootItem);
			this.TweenComponent = (ULGUIPlayTweenComponent)base.GetItem(0).GetOwner().GetComponentByClass(ULGUIPlayTweenComponent.StaticClass());
			this.TweenComponent.Play();
		}

		// Token: 0x0603F6B8 RID: 259768 RVA: 0x01041947 File Offset: 0x0103FB47
		public UiSequencePlayer GetSequencePlayer()
		{
			return this.SequencePlayer;
		}

		// Token: 0x0603F6B9 RID: 259769 RVA: 0x0104194F File Offset: 0x0103FB4F
		public ULGUIPlayTweenComponent GetTweenComponent()
		{
			return this.TweenComponent;
		}

		// Token: 0x0603F6BA RID: 259770 RVA: 0x01041957 File Offset: 0x0103FB57
		public void StopAllTweenAndSpine()
		{
			this.TweenComponent.Stop();
			base.GetSpine(1).SetTimeScale(0f);
		}

		// Token: 0x0402395E RID: 145758
		private UiSequencePlayer SequencePlayer;

		// Token: 0x0402395F RID: 145759
		[Nullable(2)]
		private ULGUIPlayTweenComponent TweenComponent;

		// Token: 0x0200C34A RID: 49994
		[NullableContext(0)]
		private enum ESeasonBgItemComponent
		{
			// Token: 0x0403C304 RID: 246532
			TweenRoot,
			// Token: 0x0403C305 RID: 246533
			SpineActor
		}
	}
}
