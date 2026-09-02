using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Plot.PlotView.PlotComponent;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Plot
{
	// Token: 0x020065EA RID: 26090
	public class PinballPlotSpineItem : UiPanelBase, IPlotAvgCharacterMove
	{
		// Token: 0x060412A8 RID: 266920 RVA: 0x010B7768 File Offset: 0x010B5968
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(USpineSkeletonAnimationComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060412A9 RID: 266921 RVA: 0x010B77D4 File Offset: 0x010B59D4
		protected override UniTask OnBeforeStartAsync()
		{
			PinballPlotSpineItem.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PinballPlotSpineItem.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060412AA RID: 266922 RVA: 0x010B7817 File Offset: 0x010B5A17
		[NullableContext(1)]
		public void PlayAnimation(string animationName, bool isLoop)
		{
			base.GetSpine(0).SetAnimation(0, animationName, isLoop);
		}

		// Token: 0x060412AB RID: 266923 RVA: 0x010B7829 File Offset: 0x010B5A29
		public void SetAnchorOffsetX(float offsetX)
		{
			this.GetOriginalItem().SetAnchorOffsetX(offsetX);
		}

		// Token: 0x060412AC RID: 266924 RVA: 0x010B7837 File Offset: 0x010B5A37
		public void SetAnchorOffsetY(float offsetY)
		{
			this.GetOriginalItem().SetAnchorOffsetY(offsetY);
		}

		// Token: 0x060412AD RID: 266925 RVA: 0x010B7845 File Offset: 0x010B5A45
		public void UpdateSpeakStatus(bool isSpeaking)
		{
			if (this.IsSpeaking == isSpeaking)
			{
				return;
			}
			this.IsSpeaking = isSpeaking;
			this.RefreshArrowStatus();
		}

		// Token: 0x060412AE RID: 266926 RVA: 0x010B785E File Offset: 0x010B5A5E
		public void RefreshArrowStatus()
		{
			base.GetItem(1).SetUIActive(this.IsSpeaking);
		}

		// Token: 0x060412AF RID: 266927 RVA: 0x010B7874 File Offset: 0x010B5A74
		public UniTask OnEnterAsync()
		{
			PinballPlotSpineItem.<OnEnterAsync>d__10 <OnEnterAsync>d__;
			<OnEnterAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnEnterAsync>d__.<>1__state = -1;
			<OnEnterAsync>d__.<>t__builder.Start<PinballPlotSpineItem.<OnEnterAsync>d__10>(ref <OnEnterAsync>d__);
			return <OnEnterAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060412B0 RID: 266928 RVA: 0x010B78AF File Offset: 0x010B5AAF
		public void SetPosition(float position)
		{
			this.SetAnchorOffsetX(position);
		}

		// Token: 0x060412B1 RID: 266929 RVA: 0x010B78B8 File Offset: 0x010B5AB8
		public float GetPosition()
		{
			return this.GetOriginalItem().GetAnchorOffsetX();
		}

		// Token: 0x060412B2 RID: 266930 RVA: 0x010B78C8 File Offset: 0x010B5AC8
		public UniTask OnExitAsync()
		{
			PinballPlotSpineItem.<OnExitAsync>d__13 <OnExitAsync>d__;
			<OnExitAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnExitAsync>d__.<>1__state = -1;
			<OnExitAsync>d__.<>t__builder.Start<PinballPlotSpineItem.<OnExitAsync>d__13>(ref <OnExitAsync>d__);
			return <OnExitAsync>d__.<>t__builder.Task;
		}

		// Token: 0x040247E1 RID: 149473
		private int? TalkerId;

		// Token: 0x040247E2 RID: 149474
		private bool IsSpeaking;

		// Token: 0x0200C5EC RID: 50668
		private enum EComponent
		{
			// Token: 0x0403CEB5 RID: 249525
			RoleSpine,
			// Token: 0x0403CEB6 RID: 249526
			ArrowItem
		}
	}
}
